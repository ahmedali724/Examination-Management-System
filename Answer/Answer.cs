namespace ExaminationManagementSystem.Answer
{
    /// <summary>
    /// Represents a single answer option for a question.
    /// Implements IComparable for sorting by ID.
    /// </summary>
    public class AnswerCls : IComparable<AnswerCls>
    {
        public int ID { get; set; }
        public string Text { get; set; }

        /// <summary>
        /// Initializes a new answer with ID and text.
        /// </summary>
        public AnswerCls(int _id, string _text)
        {
            ID = _id;
            Text = _text;
        }

        /// <summary>
        /// Compares this answer to another based on ID.
        /// </summary>
        public int CompareTo(AnswerCls other)
        {
            if (other == null) return 1;
            return ID.CompareTo(other.ID);
        }

        /// <summary>
        /// Determines whether two answers are equal (same ID and Text).
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is not AnswerCls other) return false;
            return ID == other.ID && Text == other.Text;
        }

        /// <summary>
        /// Generates hash code based on ID and Text.
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Text);
        }

        public override string ToString()
        {
            return $"ID: {ID}, Text: {Text}";
        }
    }
}
