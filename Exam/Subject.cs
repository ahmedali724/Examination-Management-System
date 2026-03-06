using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationManagementSystem.Exam
{
    /// <summary>
    /// Represents an academic subject that students can enroll in.
    /// </summary>
    public class Subject
    {
        public string Name { get; set; }

        private List<Student> students = new List<Student>();

        /// <summary>
        /// Creates a new subject with the given name.
        /// </summary>  
        public Subject(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Enrolls a student in this subject.
        /// </summary>
        public void Enroll(Student student)
        {
            students.Add(student);
        }

        /// <summary>
        /// Returns the list of enrolled students (read-only view recommended in production).
        /// </summary>
        public List<Student> GetStudents()
        {
            return students;
        }
    }
}
