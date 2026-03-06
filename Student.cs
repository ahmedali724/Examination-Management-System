using ExaminationManagementSystem.Exam;

namespace ExaminationManagementSystem
{
    /// <summary>
    /// Represents a student who can enroll in subjects and receive exam notifications.
    /// </summary>
    public class Student
    {
        public string Name { get; set; }
        public int Id { get; set; }

        /// <summary>
        /// Initializes a new student with ID and name.
        /// </summary>
        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Event handler called when an exam starts for a subject the student is enrolled in.
        /// </summary>
        public void OnExamStarted(object sender, ExamEventArgs e)
        {
            Console.WriteLine($"Student {Name} notified: Exam started for {e.Subject.Name}");
        }
    }
}
