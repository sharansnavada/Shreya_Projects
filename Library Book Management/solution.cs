#include <iostream>
#include <string>
using namespace std;

// ── single book node ─────────────────────────────────────────────────────────
class Book {
public:
    int    bookId;
    string title;
    string author;
    bool   isBorrowed;
    Book*  next;

    Book(int id, string t, string a)
        : bookId(id), title(t), author(a), isBorrowed(false), next(nullptr) {}
};

// ── linked list that manages all books ───────────────────────────────────────
class Library {
private:
    Book* head;
    int   totalBooks;

public:
    Library() : head(nullptr), totalBooks(0) {}

    // ── add a new book at the end ─────────────────────────────────────────
    void addBook(int id, string title, string author) {
        Book* newBook = new Book(id, title, author);

        if (head == nullptr) {
            head = newBook;
        } else {
            Book* temp = head;
            while (temp->next != nullptr) {
                temp = temp->next;
            }
            temp->next = newBook;
        }

        totalBooks++;
        cout << "Book added successfully.\n";
    }

    // ── remove a book by ID ───────────────────────────────────────────────
    void removeBook(int id) {
        if (head == nullptr) {
            cout << "Library is empty.\n";
            return;
        }

        // if head node itself matches
        if (head->bookId == id) {
            Book* temp = head;
            head = head->next;
            delete temp;
            totalBooks--;
            cout << "Book removed.\n";
            return;
        }

        Book* prev = nullptr;
        Book* curr = head;
        while (curr != nullptr && curr->bookId != id) {
            prev = curr;
            curr = curr->next;
        }

        if (curr == nullptr) {
            cout << "Book with ID " << id << " not found.\n";
            return;
        }

        prev->next = curr->next;
        delete curr;
        totalBooks--;
        cout << "Book removed.\n";
    }

    // ── search by title (case-sensitive) ─────────────────────────────────
    void searchBook(string title) {
        Book* temp = head;
        bool  found = false;

        for (; temp != nullptr; temp = temp->next) {
            if (temp->title == title) {
                displayBook(temp);
                found = true;
            }
        }

        if (!found) {
            cout << "No book found with title \"" << title << "\".\n";
        }
    }

    // ── borrow a book ─────────────────────────────────────────────────────
    void borrowBook(int id) {
        Book* temp = head;
        for (; temp != nullptr; temp = temp->next) {
            if (temp->bookId == id) {
                if (temp->isBorrowed) {
                    cout << "Sorry, this book is already borrowed.\n";
                } else {
                    temp->isBorrowed = true;
                    cout << "You borrowed: " << temp->title << "\n";
                }
                return;
            }
        }
        cout << "Book not found.\n";
    }

    // ── return a book ─────────────────────────────────────────────────────
    void returnBook(int id) {
        Book* temp = head;
        for (; temp != nullptr; temp = temp->next) {
            if (temp->bookId == id) {
                if (!temp->isBorrowed) {
                    cout << "This book was not borrowed.\n";
                } else {
                    temp->isBorrowed = false;
                    cout << "Book returned: " << temp->title << "\n";
                }
                return;
            }
        }
        cout << "Book not found.\n";
    }

    // ── display all books ─────────────────────────────────────────────────
    void displayAll() {
        if (head == nullptr) {
            cout << "No books in library.\n";
            return;
        }

        cout << "\n===== all books =====\n";
        Book* temp = head;
        for (; temp != nullptr; temp = temp->next) {
            displayBook(temp);
        }
        cout << "=====================\n";
        cout << "Total books: " << totalBooks << "\n";
    }

    // ── destructor: free all nodes ────────────────────────────────────────
    ~Library() {
        Book* temp = head;
        while (temp != nullptr) {
            Book* next = temp->next;
            delete temp;
            temp = next;
        }
    }

private:
    void displayBook(Book* b) {
        cout << "\nID     : " << b->bookId   << "\n"
             << "Title  : " << b->title     << "\n"
             << "Author : " << b->author    << "\n"
             << "Status : " << (b->isBorrowed ? "Borrowed" : "Available") << "\n";
    }
};

// ── main with menu ────────────────────────────────────────────────────────────
int main() {
    Library lib;
    int choice;

    // seed with a few books
    lib.addBook(1, "Let Us C",          "Yashavant Kanetkar");
    lib.addBook(2, "Data Structures",   "Reema Thareja");
    lib.addBook(3, "The Pragmatic Programmer", "Andy Hunt");

    do {
        cout << "\n===== library menu =====\n"
             << "1. Add book\n"
             << "2. Remove book\n"
             << "3. Search book\n"
             << "4. Borrow book\n"
             << "5. Return book\n"
             << "6. Display all books\n"
             << "0. Exit\n"
             << "Enter choice: ";
        cin >> choice;

        if (choice == 1) {
            int id; string title, author;
            cout << "Enter ID: ";    cin >> id;
            cout << "Enter title: "; cin >> title;
            cout << "Enter author: "; cin >> author;
            lib.addBook(id, title, author);

        } else if (choice == 2) {
            int id;
            cout << "Enter book ID to remove: "; cin >> id;
            lib.removeBook(id);

        } else if (choice == 3) {
            string title;
            cout << "Enter title to search: "; cin >> title;
            lib.searchBook(title);

        } else if (choice == 4) {
            int id;
            cout << "Enter book ID to borrow: "; cin >> id;
            lib.borrowBook(id);

        } else if (choice == 5) {
            int id;
            cout << "Enter book ID to return: "; cin >> id;
            lib.returnBook(id);

        } else if (choice == 6) {
            lib.displayAll();
        }

    } while (choice != 0);

    cout << "Goodbye!\n";
    return 0;
}
