# 🎓 Examination Management System

A **Console-Based Examination Management System** built using **C# (.NET)**.
The system supports multiple question types, different exam modes, automatic grading, and file-based logging.

This project demonstrates **Object-Oriented Programming principles**, **clean architecture**, and the use of **core C# features** such as events, generics, interfaces, and LINQ.

---

# 📌 Features

### 📝 Multiple Question Types

The system supports different types of questions:

* **True / False**
* **Choose One** (Single Correct Answer)
* **Choose All That Apply** (Multiple Correct Answers)

---

### 🧪 Two Exam Modes

#### Practice Exam

* Displays **correct answers after submission**
* Helps students learn and review

#### Final Exam

* Displays **student answers only**
* Shows **final grade at the end**

---

### ⚙️ System Capabilities

* Automatic grading system
* Support for multi-answer questions
* Subject-based exam management
* Student enrollment system
* Event-driven exam start notifications
* Logging questions and answers to text files
* Clean and readable console UI
* Proper implementation of:

```
IComparable<T>
ICloneable
Equals()
GetHashCode()
```

---

# 🏗 Project Structure

```
ExaminationManagementSystem
│
├── Answer
│   ├── AnswerCls.cs
│   └── AnswerList.cs
│
├── Question
│   ├── QuestionAbs.cs
│   ├── TrueFalseQuestion.cs
│   ├── ChooseOneQuestion.cs
│   ├── ChooseAllQuestion.cs
│   └── QuestionList.cs
│
├── Exam
│   ├── ExamAbs.cs
│   ├── PracticeExam.cs
│   ├── FinalExam.cs
│   └── Subject.cs
│
├── Student.cs
│
└── Program.cs
```

---

# 🧠 Design Concepts Used

The project focuses on demonstrating important **C# and OOP concepts**:

* Abstraction
* Inheritance
* Polymorphism
* Encapsulation
* Events & Delegates
* Generics
* LINQ
* File Handling
* Interface Implementation
* Equality & Hashing
* Clean Separation of Concerns

---

# 🖥 Sample Console Output

```
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

C# is an OOP language (5 Marks)

1. True
2. False

Enter Answer Id: 1

Answer recorded.
```

---

# 📂 File Logging

Each **QuestionList** instance logs questions automatically into a text file.

Example:

```
Questions_OOP.txt
Questions_DataStructures.txt
```

Every time a question is added, it is appended to the corresponding file.

---

# 📚 Technologies Used

* **C#**
* **.NET**
* **LINQ**
* **File I/O**
* **Console UI**

---
