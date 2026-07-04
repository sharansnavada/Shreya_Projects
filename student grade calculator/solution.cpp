#include <iostream>
#include <string>
using namespace std;

// ── class to represent one subject ──────────────────────────────────────────
class Subject {
public:
    string name;
    float  marks;

    Subject() : name(""), marks(0) {}

    void input() {
        cout << "Enter subject name: ";
        cin >> name;
        cout << "Enter marks (out of 100): ";
        cin >> marks;
    }

    void display() const {
        cout << name << ": " << marks << endl;
    }
};

// ── class to represent one student ──────────────────────────────────────────
class Student {
private:
    string  name;
    int     rollNo;
    int     numSubjects;
    Subject subjects[10];   // max 10 subjects

    float   totalMarks;
    float   percentage;
    string  grade;

public:
    Student() : name(""), rollNo(0), numSubjects(0),
                totalMarks(0), percentage(0), grade("") {}

    void inputDetails() {
        cout << "\nEnter student name: ";
        cin >> name;
        cout << "Enter roll number: ";
        cin >> rollNo;
        cout << "How many subjects? (max 10): ";
        cin >> numSubjects;

        for (int i = 0; i < numSubjects; i++) {
            cout << "\nSubject " << (i + 1) << ":\n";
            subjects[i].input();
        }
    }

    void calculate() {
        totalMarks = 0;
        for (int i = 0; i < numSubjects; i++) {
            totalMarks += subjects[i].marks;
        }

        percentage = totalMarks / numSubjects;

        if      (percentage >= 90) grade = "A+";
        else if (percentage >= 80) grade = "A";
        else if (percentage >= 70) grade = "B";
        else if (percentage >= 60) grade = "C";
        else if (percentage >= 50) grade = "D";
        else                       grade = "F";
    }

    void displayResult() const {
        cout << "\n===== result card =====\n";
        cout << "Name      : " << name       << endl;
        cout << "Roll No   : " << rollNo     << endl;
        cout << "\nSubject-wise marks:\n";

        for (int i = 0; i < numSubjects; i++) {
            subjects[i].display();
        }

        cout << "\nTotal     : " << totalMarks  << endl;
        cout << "Percentage: " << percentage  << "%" << endl;
        cout << "Grade     : " << grade        << endl;
        cout << "=======================\n";
    }
};

// ── main ─────────────────────────────────────────────────────────────────────
int main() {
    int n;
    cout << "How many students? ";
    cin >> n;

    Student students[50];   // max 50 students

    for (int i = 0; i < n; i++) {
        cout << "\n--- Student " << (i + 1) << " ---";
        students[i].inputDetails();
        students[i].calculate();
    }

    cout << "\n\n========== all results ==========\n";
    for (int i = 0; i < n; i++) {
        students[i].displayResult();
    }

    return 0;
}
