using ExaminationManagementSystem.Answer;

namespace ExaminationManagementSystem.Question
{
    public class ChooseOneQuestion : QuestionAbs
    {
        public ChooseOneQuestion(string header, string body, int marks)
        : base(header, body, marks)
        {
        }

        public override bool CheckAnswer(AnswerCls studentAnswer)
        {
            return CorrectAnswers.GetById(studentAnswer.ID) != null;
        }

        public override void Display()
        {
            Console.Write(Body);
            Console.WriteLine($" ({Marks}) Marks");
            foreach (var ans in Answers.GetAll())
                Console.WriteLine(ans);
        }
    }
}
