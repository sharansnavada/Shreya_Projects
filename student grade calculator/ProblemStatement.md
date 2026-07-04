# Problem Statement — Student Grade Calculator

## Background

You are asked to build a console-based C++ program that manages student records and calculates their grades based on subject marks. The program should make use of **classes**, **arrays**, and **basic OOP concepts**.

---

## What the Program Must Do

### 1. Subject Details

- Each subject has a name and marks (out of 100).
- Create a `Subject` class to store these two pieces of information.
- The class should have a method to take input from the user and a method to display the subject name and marks.

### 2. Student Details

- Each student has a name, roll number, and a list of subjects.
- Create a `Student` class to store this information.
- A student can have a maximum of **10 subjects**.
- The `Student` class must contain an array of `Subject` objects (not a separate array in `main`).

### 3. Calculations (inside the `Student` class)

After all subject marks are entered, the program must automatically calculate:

- **Total marks** — sum of all subject marks
- **Percentage** — total marks ÷ number of subjects
- **Grade** — based on the following table:

| Percentage     | Grade |
|----------------|-------|
| 90 and above   | A+    |
| 80 – 89        | A     |
| 70 – 79        | B     |
| 60 – 69        | C     |
| 50 – 59        | D     |
| Below 50       | F     |

### 4. Multiple Students

- The program should ask how many students' records need to be entered (maximum **50**).
- Use an array of `Student` objects in `main` — not individual variables.
- After all students are entered, display the result card for every student one by one.

---

## Expected Flow

```
How many students? 2

--- Student 1 ---
Enter student name: Priya
Enter roll number: 101
How many subjects? (max 10): 3

Subject 1:
Enter subject name: Maths
Enter marks (out of 100): 88

Subject 2:
Enter subject name: Physics
Enter marks (out of 100): 76

Subject 3:
Enter subject name: Chemistry
Enter marks (out of 100): 91

--- Student 2 ---
...

========== all results ==========

===== result card =====
Name      : Priya
Roll No   : 101

Subject-wise marks:
Maths: 88
Physics: 76
Chemistry: 91

Total     : 255
Percentage: 85%
Grade     : A
=======================
```

---

## Constraints and Rules

- Do **NOT** use `std::vector`, `std::list`, or any STL containers — only plain arrays.
- The `calculate()` logic must be inside the `Student` class, not in `main`.
- `main()` should only handle input/output flow and array iteration — no grade logic there.
- Each class must be written with `private` data members and `public` methods wherever appropriate.

---

## Bonus (Optional)

- After displaying all results, find and print the name of the **student with the highest percentage**.
- Handle the edge case where a student has **0 subjects** entered.
