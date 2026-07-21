# Problem Statement — Library Book Management System

## Background

You are asked to build a console-based C++ program that manages books in a library.
The program should make use of **classes**, **linked lists (built from scratch)**, **pointers**, and **basic OOP concepts**.

> **Important:** Do NOT use `std::list`, `std::vector`, or any STL containers.
> You must build the linked list yourself using a class with a `next` pointer.

---

## Core Concepts to Understand Before You Start

### What is a Linked List?

A linked list is a chain of **nodes**. Each node holds:
- Some data (in this case, book details)
- A pointer to the **next node** in the chain

```
[Book 1 | next] --> [Book 2 | next] --> [Book 3 | next] --> nullptr
```

The list starts at a pointer called `head`. If `head == nullptr`, the list is empty.

### What is a Pointer?

A pointer stores the **memory address** of another variable or object.

```cpp
Book* head;       // head is a pointer to a Book object
head = nullptr;   // nullptr means it points to nothing (empty list)
```

### What is `new` and `delete`?

- `new` creates an object in memory and gives you its address.
- `delete` frees that memory when you no longer need it.

```cpp
Book* b = new Book(...);   // create a book in memory
delete b;                  // free it when done
```

> If you use `new` and forget `delete`, the memory is never freed.
> This is called a **memory leak** — a common interview question!

---

## Classes to Build

### Class 1 — `Book` (the node)

This class represents a **single book** AND acts as a **node** in the linked list.

**Data members (keep these `public` for simplicity):**

| Member | Type | Description |
|---|---|---|
| `bookId` | `int` | Unique ID for the book |
| `title` | `string` | Title of the book |
| `author` | `string` | Author name |
| `isBorrowed` | `bool` | `true` if borrowed, `false` if available |
| `next` | `Book*` | Pointer to the next book in the list |

**Constructor:**
- Takes `id`, `title`, and `author` as parameters.
- Sets `isBorrowed` to `false` by default.
- Sets `next` to `nullptr` by default.

---

### Class 2 — `Library` (the linked list manager)

This class owns the list and provides all operations on it.

**Data members (keep these `private`):**

| Member | Type | Description |
|---|---|---|
| `head` | `Book*` | Points to the first book in the list |
| `totalBooks` | `int` | Count of books currently in the library |

**Constructor:**
- Sets `head` to `nullptr`.
- Sets `totalBooks` to `0`.

**Methods to implement (explained in detail below):**

| Method | Purpose |
|---|---|
| `addBook(id, title, author)` | Add a new book at the end of the list |
| `removeBook(id)` | Remove a book by its ID |
| `searchBook(title)` | Search and display books by title |
| `borrowBook(id)` | Mark a book as borrowed |
| `returnBook(id)` | Mark a book as returned |
| `displayAll()` | Print all books with their status |
| `~Library()` | Destructor — free all nodes from memory |

---

## Method Details and Hints

### `addBook(int id, string title, string author)`

Create a new `Book` node using `new`. Attach it at the **end** of the list.

**Steps:**
1. Create `Book* newBook = new Book(id, title, author);`
2. If `head == nullptr`, set `head = newBook` (first book in list).
3. Otherwise, traverse to the last node (where `temp->next == nullptr`) and set `temp->next = newBook`.
4. Increment `totalBooks`.

---

### `removeBook(int id)`

Find the book with the given ID and remove it from the list.

**This is the hardest method. There are 3 cases to handle:**

**Case 1 — List is empty:**
```
head == nullptr → print "Library is empty"
```

**Case 2 — The book to remove is the head node:**
```
head->bookId == id → move head to head->next → delete old head
```

**Case 3 — The book is somewhere in the middle or end:**
```
Use two pointers: prev and curr
Traverse until curr->bookId == id
Set prev->next = curr->next
Delete curr
```

> **Hint:** Always check `curr == nullptr` after the loop.
> If it is `nullptr`, the book was not found.

---

### `searchBook(string title)`

Traverse the entire list. For every node where `temp->title == title`, display that book.
Use a `bool found` flag — if no match is found, print "Book not found".

---

### `borrowBook(int id)`

Traverse the list to find the book with the given ID.
- If `isBorrowed == true` → print "Already borrowed"
- If `isBorrowed == false` → set `isBorrowed = true` and print success

---

### `returnBook(int id)`

Traverse the list to find the book with the given ID.
- If `isBorrowed == false` → print "This book was not borrowed"
- If `isBorrowed == true` → set `isBorrowed = false` and print success

---

### `displayAll()`

Traverse the entire list from `head` to the last node.
For each book, print all details and whether it is **Available** or **Borrowed**.

---

### `~Library()` — Destructor

This is called automatically when the program ends.
You must free every node to avoid memory leaks.

```
while head is not nullptr:
    save head->next in a temp pointer
    delete head
    move head to temp
```

> **Interview tip:** If asked "what happens if you skip the destructor?" — the answer is
> memory leak. All the `new` allocations stay in memory even after the program ends.

---

## Expected Flow

```
===== library menu =====
1. Add book
2. Remove book
3. Search book
4. Borrow book
5. Return book
6. Display all books
0. Exit
Enter choice: 1

Enter ID: 101
Enter title: LetUsC
Enter author: YashavantKanetkar
Book added successfully.

Enter choice: 6

===== all books =====

ID     : 101
Title  : LetUsC
Author : YashavantKanetkar
Status : Available

Total books: 1
=====================

Enter choice: 4
Enter book ID to borrow: 101
You borrowed: LetUsC

Enter choice: 6

===== all books =====

ID     : 101
Title  : LetUsC
Author : YashavantKanetkar
Status : Borrowed

Total books: 1
=====================

Enter choice: 2
Enter book ID to remove: 101
Book removed.

Enter choice: 6
No books in library.
```

---

## Constraints and Rules

- Build the linked list from scratch using a `Book*` pointer — do NOT use STL.
- `head` and `totalBooks` must be `private` inside `Library`.
- Every `new` must have a matching `delete` — implement the destructor properly.
- `removeBook()` must handle all 3 cases (empty list, head node, middle/end node).
- Do not use global variables.

---

## Suggested Order to Code

Work in this order so each part is testable before moving to the next:

1. Write the `Book` class with constructor.
2. Write the `Library` class with only `addBook()` and `displayAll()`.
3. Test — add 2–3 books and display them.
4. Add `searchBook()` and test.
5. Add `borrowBook()` and `returnBook()` and test.
6. Add `removeBook()` — test all 3 cases.
7. Add the destructor last.
8. Add the menu in `main()` and wire everything together.

---

## Bonus (Optional)

- Add a `borrowCount` field to `Book` that increments every time the book is borrowed.
- At the end, display which book was borrowed the most number of times.

---

## Key Interview Questions to Prepare

| Question | What to say |
|---|---|
| What is a linked list? | A chain of nodes where each node holds data and a pointer to the next node |
| Why use a linked list instead of an array? | Size is dynamic — no fixed limit needed upfront |
| What is `head`? | A pointer to the first node. If `head == nullptr`, the list is empty |
| Why do you need `prev` in `removeBook()`? | To re-link the previous node to skip over the deleted one |
| What is a memory leak? | When `new` is used but `delete` is never called, wasting memory |
| What does the destructor do here? | Traverses the entire list and `delete`s every node |
