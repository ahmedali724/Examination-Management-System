# Examination Management System

A console-based Examination Management System built in C# that supports different question types, 
practice & final exams, student enrollment, automatic grading, and result logging.

Designed with clean architecture principles, object-oriented design patterns, and proper separation of concerns.

## Features

- Multiple question types:
  - True/False
  - Choose One (single correct answer)
  - Choose All That Apply (multiple correct answers)

- Two exam modes:
  - Practice Exam — shows correct answers after submission
  - Final Exam — shows only student answers and final grade

- Automatic grading with support for partial/multi-choice questions
- Subject & student enrollment system
- Event-based exam start notifications
- Questions and correct answers logged to text files
- Clean console UI with color highlighting
- Proper implementation of IComparable, ICloneable, equality & hashing

## Project Structure

ExaminationManagementSystem/
├── Answer/
│   ├── AnswerCls.cs           → Single answer option
│   └── AnswerList.cs          → Collection with ID lookup
├── Question/
│   ├── QuestionAbs.cs         → Abstract base question
│   ├── TrueFalseQuestion.cs
│   ├── ChooseOneQuestion.cs
│   ├── ChooseAllQuestion.cs
│   └── QuestionList.cs        → List that auto-logs questions to file
├── Exam/
│   ├── ExamAbs.cs             → Abstract exam base class
│   ├── PracticeExam.cs
│   ├── FinalExam.cs
│   └── Subject.cs             → Subject with enrolled students
├── Student.cs
└── Program.cs                 → Main application flow & console UI

## Technologies & Patterns Used

- C# (.NET)
- Object-Oriented Programming (OOP)
- Abstract classes & inheritance
- Events & delegates
- Generics & LINQ
- File I/O (question logging)
- Console UI with color formatting
- IComparable<T>, ICloneable, proper Equals/GetHashCode

## Sample Output

=================================================
           EXAMINATION MANAGEMENT SYSTEM         
=================================================

Select Exam Type:
1 - Practice Exam
2 - Final Exam
Your choice (1 or 2): 1

Starting PracticeExam ...

Student Ahmed notified: Exam started for Object Oriented Programming
Student Ali notified: Exam started for Object Oriented Programming

Question (5 Marks)
C# is an OOP language (5) Marks
1. True
2. False
Enter Answer Id: 1
Answer recorded.
...
