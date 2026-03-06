namespace ExaminationManagementSystem.Answer
{
    /// <summary>
    /// Manages a collection of AnswerCls objects with ID-based lookup.
    /// </summary>
    public class AnswerList
    {
        private List<AnswerCls> answers = new List<AnswerCls>();
        
        /// <summary>
        /// Number of answers in the list.
        /// </summary>
        public int Count { get { return answers.Count; } }

        /// <summary>
        /// Adds a new answer to the collection.
        /// </summary>
        public void Add(AnswerCls answer)
        {
            answers.Add(answer);
        }

        /// <summary>
        /// Retrieves an answer by its ID, or null if not found.
        /// </summary>
        public AnswerCls GetById(int id)
        {
            return answers.FirstOrDefault(a => a.ID == id);
        }

        /// <summary>
        /// Indexer to get answer by ID (not by position!).
        /// </summary>
        public AnswerCls this[int id]
        {
            get
            {
                return answers.FirstOrDefault(a => a.ID == id);
            }
        }

        /// <summary>
        /// Returns all answers in the list.
        /// </summary>
        public List<AnswerCls> GetAll()
        {
            return answers;
        }
    }
}
