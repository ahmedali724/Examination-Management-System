using ExaminationManagementSystem.Answer;

namespace ExaminationManagementSystem.Question
{
    /// <summary>
    /// Represents a True/False type question.
    /// </summary>
    public class TrueFalseQuestion : QuestionAbs
    {

        public TrueFalseQuestion(string header, string body, int marks)
        : base(header, body, marks)
        {
        }

        /// <summary>
        /// Shows question body and available True/False options.
        /// </summary>
        public override void Display()
        {
            Console.Write(Body);
            Console.WriteLine($" ({Marks}) Marks");
            foreach (var ans in Answers.GetAll())
                Console.WriteLine(ans);
        }

        /// <summary>
        /// Returns true if student selected the correct answer ID.
        /// </summary>
        public override bool CheckAnswer(AnswerCls studentAnswer)
        {
            return CorrectAnswers.GetById(studentAnswer.ID) != null;
        }
    }
}
