using ExaminationManagementSystem.Answer;
using ExaminationManagementSystem.Exam;
using ExaminationManagementSystem.Question;

namespace ExaminationManagementSystem
{
    internal class Program
    {
        /// <summary>
        /// Entry point of the Examination Management System console application.
        /// Demonstrates subject creation, student enrollment, question setup,
        /// exam creation (practice & final), and interactive exam taking.
        /// </summary>
        static void Main(string[] args)
        {
            // ───────────────────────────────────────────────
            // UI Header
            // ───────────────────────────────────────────────
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=================================================");
            Console.WriteLine("           EXAMINATION MANAGEMENT SYSTEM         ");
            Console.WriteLine("=================================================");
            Console.ResetColor();

            // ───────────────────────────────────────────────
            // 1. Create Subject
            // ───────────────────────────────────────────────
            Subject oop = new Subject("Object Oriented Programming");

            // ───────────────────────────────────────────────
            // 2. Create and enroll Students
            // ───────────────────────────────────────────────
            Student s1 = new Student(1, "Ahmed");
            Student s2 = new Student(2, "Ali");

            oop.Enroll(s1);
            oop.Enroll(s2);

            // ───────────────────────────────────────────────
            // 3. Prepare question log files
            // ───────────────────────────────────────────────
            QuestionList practiceQuestions = new QuestionList("PracticeQuestions.txt");
            QuestionList finalQuestions = new QuestionList("FinalQuestions.txt");

            // ───────────────────────────────────────────────
            // 4. Create sample questions (different types)
            // ───────────────────────────────────────────────

            // True/False example
            TrueFalseQuestion q1 = new TrueFalseQuestion("Q1", "C# is an OOP language", 5);
            q1.Answers.Add(new AnswerCls(1, "True"));
            q1.Answers.Add(new AnswerCls(2, "False"));
            q1.CorrectAnswers.Add(q1.Answers.GetById(1));

            // Choose One (single correct answer)
            ChooseOneQuestion q2 = new ChooseOneQuestion("Q2", "Which is a value type?", 5);
            q2.Answers.Add(new AnswerCls(1, "int"));
            q2.Answers.Add(new AnswerCls(2, "string"));
            q2.Answers.Add(new AnswerCls(3, "class"));
            q2.CorrectAnswers.Add(q2.Answers.GetById(1));

            // Choose All That Apply (multiple correct)
            ChooseAllQuestion q3 = new ChooseAllQuestion("Q3", "Select OOP concepts", 10);
            q3.Answers.Add(new AnswerCls(1, "Encapsulation"));
            q3.Answers.Add(new AnswerCls(2, "Inheritance"));
            q3.Answers.Add(new AnswerCls(3, "Loop"));
            q3.CorrectAnswers.Add(q3.Answers.GetById(1));
            q3.CorrectAnswers.Add(q3.Answers.GetById(2));

            // Additional questions
            TrueFalseQuestion q4 = new TrueFalseQuestion("Q4", "C# supports inheritance", 5);
            q4.Answers.Add(new AnswerCls(1, "True"));
            q4.Answers.Add(new AnswerCls(2, "False"));
            q4.CorrectAnswers.Add(q4.Answers.GetById(1));

            ChooseOneQuestion q5 = new ChooseOneQuestion("Q5", "Which is a reference type?", 5);
            q5.Answers.Add(new AnswerCls(1, "int"));
            q5.Answers.Add(new AnswerCls(2, "string"));
            q5.Answers.Add(new AnswerCls(3, "double"));
            q5.CorrectAnswers.Add(q5.Answers.GetById(2));

            ChooseAllQuestion q6 = new ChooseAllQuestion("Q6", "Which are value types?", 10);
            q6.Answers.Add(new AnswerCls(1, "int"));
            q6.Answers.Add(new AnswerCls(2, "double"));
            q6.Answers.Add(new AnswerCls(3, "string"));
            q6.CorrectAnswers.Add(q6.Answers.GetById(1));
            q6.CorrectAnswers.Add(q6.Answers.GetById(2));

            // ───────────────────────────────────────────────
            // 5. Save questions to log files (auto-logged by QuestionList)
            // ───────────────────────────────────────────────
            practiceQuestions.Add(q1);
            practiceQuestions.Add(q2);
            practiceQuestions.Add(q3);
            practiceQuestions.Add(q4);

            finalQuestions.Add(q1);
            finalQuestions.Add(q2);
            finalQuestions.Add(q3);
            finalQuestions.Add(q5);
            finalQuestions.Add(q6);

            // ───────────────────────────────────────────────
            // 6. Create two exam types
            // ───────────────────────────────────────────────
            PracticeExam practiceExam = new PracticeExam();
            FinalExam finalExam = new FinalExam();

            practiceExam.Subject = oop;
            finalExam.Subject = oop;

            practiceExam.Time = 30;
            finalExam.Time = 30;

            practiceExam.Questions = practiceQuestions;
            finalExam.Questions = finalQuestions;

            practiceExam.NumberOfQuestions = practiceExam.Questions.Count;
            finalExam.NumberOfQuestions = finalExam.Questions.Count;

            // ───────────────────────────────────────────────
            // 7. Subscribe students to exam start notifications
            // ───────────────────────────────────────────────
            practiceExam.ExamStarted += s1.OnExamStarted;
            practiceExam.ExamStarted += s2.OnExamStarted;

            finalExam.ExamStarted += s1.OnExamStarted;
            finalExam.ExamStarted += s2.OnExamStarted;

            // ───────────────────────────────────────────────
            // 8. Let user choose exam type
            // ───────────────────────────────────────────────
            Console.WriteLine("\nSelect Exam Type:");
            Console.WriteLine("1 - Practice Exam");
            Console.WriteLine("2 - Final Exam");
            Console.Write("Your choice (1 or 2): ");

            ExamAbs selectedExam = null;

            while (selectedExam == null)
            {
                string input = Console.ReadLine()?.Trim();

                if (int.TryParse(input, out int choice) && (choice == 1 || choice == 2))
                {
                    selectedExam = (choice == 1) ? practiceExam : finalExam;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Invalid choice! Please enter 1 or 2.");
                    Console.ResetColor();
                    Console.Write("Your choice (1 or 2): ");
                }
            }

            Console.WriteLine($"\nStarting {selectedExam.GetType().Name} ...\n");

            // ───────────────────────────────────────────────
            // 9. Start the selected exam → triggers notifications
            // ───────────────────────────────────────────────
            selectedExam.Start();

            // ───────────────────────────────────────────────
            // 10. Interactive question answering loop
            // ───────────────────────────────────────────────
            foreach (var question in selectedExam.Questions)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\nQuestion ({question.Marks} Marks)");
                Console.ResetColor();

                question.Display();

                List<AnswerCls> selectedAnswers = new List<AnswerCls>();

                if (question is ChooseAllQuestion)
                {
                    Console.Write("Enter Answer Ids (space separated): ");
                    string inputLine = Console.ReadLine() ?? "";

                    var tokens = inputLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    foreach (var token in tokens)
                    {
                        if (int.TryParse(token, out int id))
                        {
                            var ans = question.Answers.GetById(id);
                            if (ans != null)
                                selectedAnswers.Add(ans);
                        }
                    }
                }
                else
                {
                    Console.Write("Enter Answer Id: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        var ans = question.Answers.GetById(id);
                        if (ans != null)
                            selectedAnswers.Add(ans);
                    }
                }

                // Store student's answer(s) for this question
                selectedExam.StudentAnswers[question] = selectedAnswers;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Answer recorded.");
                Console.ResetColor();

                Console.WriteLine("\n--------------------------------------------------");
            }

            // ───────────────────────────────────────────────
            // 11. Finish exam, show summary, calculate & display grade
            // ───────────────────────────────────────────────
            selectedExam.Finish();
            selectedExam.CorrectExam();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n=================================================");
            Console.WriteLine($"Final Grade : {selectedExam.Grade} / {selectedExam.Questions.Sum(q => q.Marks)}");
            Console.WriteLine("=================================================");
            Console.ResetColor();
        }
    }
}