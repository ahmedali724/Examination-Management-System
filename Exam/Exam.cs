using ExaminationManagementSystem.Answer;
using ExaminationManagementSystem.Question;
using System.Diagnostics;

namespace ExaminationManagementSystem.Exam
{
    public enum ExamMode
    {
        Starting, Queued, Finished
    }

    public delegate void ExamStartedHandler(object sender, ExamEventArgs e);

    public class ExamEventArgs : EventArgs
    {
        public Subject Subject { get; }

        public ExamAbs Exam { get; }

        public ExamEventArgs(Subject subject, ExamAbs exam)
        {
            Subject = subject;
            Exam = exam;
        }
    }

    /// <summary>
    /// Abstract base class for all exam types (Practice, Final, etc.).
    /// </summary>
    public abstract class ExamAbs : IComparable<ExamAbs>, ICloneable
    {
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public List<QuestionAbs> Questions { get; set; } = new List<QuestionAbs>();
        public Dictionary<QuestionAbs, List<AnswerCls>> StudentAnswers { get; } = new();
        public Subject Subject { get; set; }
        public ExamMode Mode { get; set; }

        public event ExamStartedHandler ExamStarted;

        public int Grade { get; private set; }

        /// <summary>
        /// Displays exam questions (implemented differently per exam type).
        /// </summary>
        public abstract void ShowExam();

        /// <summary>
        /// Triggers exam start and notifies subscribers.
        /// </summary>
        public virtual void Start()
        {
            Mode = ExamMode.Starting;

            ExamStarted?.Invoke(this, new ExamEventArgs(Subject, this));
        }

        /// <summary>
        /// Marks exam as finished.
        /// </summary>
        public virtual void Finish()
        {
            Mode = ExamMode.Finished;
        }

        /// <summary>
        /// Calculates total grade based on student answers.
        /// Handles single-choice and multi-choice differently.
        /// </summary>
        public void CorrectExam()
        {
            Grade = 0;

            foreach (var pair in StudentAnswers)
            {
                var question = pair.Key;
                var selectedAnswers = pair.Value;

                if (question is ChooseAllQuestion)
                {
                    var correctAnswers = question.CorrectAnswers.GetAll();
                    var selectedIds = selectedAnswers.Select(a => a.ID).ToHashSet();
                    var correctIds = correctAnswers.Select(a => a.ID).ToHashSet();

                    if (selectedIds.SetEquals(correctIds))
                    {
                        Grade += question.Marks;
                    }
                }
                else
                {
                    if (selectedAnswers.Count == 1)
                    {
                        var singleAnswer = selectedAnswers[0];
                        if (question.CheckAnswer(singleAnswer))
                        {
                            Grade += question.Marks;
                        }
                    }
                }
            }
        }
        public override string ToString()
        {
            return $"Time: {Time}, Questions: {NumberOfQuestions}, Mode: {Mode}";
        }

        public override bool Equals(object obj)
        {
            if (obj is ExamAbs other)
            {
                return Time == other.Time && NumberOfQuestions == other.NumberOfQuestions;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Time, NumberOfQuestions);
        }

        public int CompareTo(ExamAbs other)
        {
            if (other != null)
            {
                if (Time != other.Time)
                {
                    return Time.CompareTo(other.Time);
                }
                return NumberOfQuestions.CompareTo(other.NumberOfQuestions);
            }
            return 1;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
