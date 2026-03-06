namespace ExaminationManagementSystem.Question
{
    /// <summary>
    /// Specialized list that auto-logs added questions to a text file.
    /// </summary>
    public class QuestionList : List<QuestionAbs>
    {
        private string fileName;

        public QuestionList(string _fileName)
        {
            fileName = _fileName;
        }

        /// <summary>
        /// Adds question to list AND appends it to the log file.
        /// </summary>
        public new void Add(QuestionAbs question)
        {
            base.Add(question);

            using (StreamWriter writer = new StreamWriter(fileName, append: true))
            {
                writer.WriteLine("===================================");
                writer.WriteLine($"Header: {question.Header}");
                writer.WriteLine($"Body:   {question.Body}");
                writer.WriteLine($"Marks:  {question.Marks}");

                writer.WriteLine("Correct Answer(s):");

                foreach (var ans in question.CorrectAnswers.GetAll())
                {
                    writer.WriteLine($"  - ID: {ans.ID} | {ans.Text}");
                }

                if (question.CorrectAnswers.Count == 0)
                {
                    writer.WriteLine("  (No correct answers defined)");
                }

                writer.WriteLine("===================================");
            }
        }
    }
}
