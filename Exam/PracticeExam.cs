namespace ExaminationManagementSystem.Exam
{
    /// <summary>
    /// Practice exam – shows correct answers after submission.
    /// </summary>
    public class PracticeExam : ExamAbs
    {
        public override void ShowExam()
        {
            foreach (var q in Questions)
            {
                q.Display();
            }

            CorrectExam();

            Console.WriteLine($"Your Grade = {Grade}");
        }

        public override void Finish()
        {
            base.Finish();
            Console.WriteLine("Practice Exam Results:");
            // prints questions, student answers + correct answers
            foreach (var question in Questions)
            {
                Console.WriteLine($"{question.Header}: {question.Body} ({question.Marks} marks)");
                Console.WriteLine("Possible answers:");
                foreach (var ans in question.Answers.GetAll())
                {
                    Console.WriteLine($"{ans.ID}. {ans.Text}");
                }
                Console.WriteLine("Your answer: " + string.Join(", ", StudentAnswers[question].Select(a => a.Text)));
                Console.WriteLine("Correct answer(s): " + string.Join(", ", question.CorrectAnswers.GetAll().Select(a => a.Text)));
                Console.WriteLine();
            }
        }
    }
}
