using ExaminationManagementSystem.Answer;
namespace ExaminationManagementSystem.Question
{
    /// <summary>
    /// Abstract base class for all question types.
    /// Defines common properties and behavior.
    /// </summary>
    public abstract class QuestionAbs
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Marks { get; set; }
        public AnswerList Answers { get; set; }
        public AnswerList CorrectAnswers { get; set; } = new AnswerList();

        /// <summary>
        /// Creates a question with validation for marks.
        /// </summary>
        public QuestionAbs(string _header, string _body, int _marks)
        {
            if (_marks <= 0)
                Marks = 1;

            Header = _header;
            Body = _body;

            Marks = _marks;
            Answers = new AnswerList();
        }

        /// <summary>
        /// Displays the question to the console (must be implemented by derived classes).
        /// </summary>
        public abstract void Display();
        public abstract bool CheckAnswer(AnswerCls studentAnswer);

        /// <summary>
        /// Check the Equality of two questions base on Header and Body
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is QuestionAbs other)
            {
                return Header == other.Header && Body == other.Body;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Header, Body);
        }
    }
}
