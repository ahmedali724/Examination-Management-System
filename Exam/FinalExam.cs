namespace ExaminationManagementSystem.Exam
{
    /// <summary>
    /// Final exam – shows only student answers (no correct answers revealed).
    /// </summary>
    public class FinalExam : ExamAbs
    {
        public override void ShowExam()
        {
            foreach (var q in Questions)
            {
                q.Display();
            }

            CorrectExam();

            Console.WriteLine($"Your Grade = {Grade}");
            Console.WriteLine("Exam Finished");
        }

        public override void Finish()
        {
            base.Finish();
            Console.WriteLine("Final Exam Submitted:");
            // prints questions + student answers only
            foreach (var question in Questions)
            {
                Console.WriteLine($"{question.Header}: {question.Body} ({question.Marks} marks)");
                Console.WriteLine("Possible answers:");
                foreach (var ans in question.Answers.GetAll())
                {
                    Console.WriteLine($"{ans.ID}. {ans.Text}");
                }
                Console.WriteLine("Your answer: " + string.Join(", ", StudentAnswers[question].Select(a => a.Text)));
                Console.WriteLine();
            }
        }
    }
}
