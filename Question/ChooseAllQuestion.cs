using ExaminationManagementSystem.Answer;

namespace ExaminationManagementSystem.Question
{
    /// <summary>
    /// Question where multiple correct answers are possible.
    /// </summary>
    public class ChooseAllQuestion : QuestionAbs
    {
        public ChooseAllQuestion(string header, string body, int marks)
            : base(header, body, marks)
        {
        }

        /// <summary>
        /// Display the body, marks and answers of the questions
        /// </summary>
        public override void Display()
        {
            Console.WriteLine($"{Body} ({Marks} Marks)");

            foreach (var ans in Answers.GetAll())
                Console.WriteLine(ans);
        }

        /// <summary>
        /// Checks single answer (used during partial validation).
        /// Full correctness is checked in CorrectExam().
        /// </summary>
        public override bool CheckAnswer(AnswerCls studentAnswer)
        {
            return CorrectAnswers.GetById(studentAnswer.ID) != null;
        }
    }
}
