# 📚 Library Book Manager

A colorful, object-oriented **C# console application** for managing a small library: add books, borrow and return them, search by title or author, and print a full status report, all with a random ASCII-art logo on startup.

Built as a clean, beginner-friendly demonstration of **OOP principles**, **collections**, and **console UI** in modern C#.

---

## ✨ Features

- **Add books** with title, author, and ISBN (duplicate ISBNs are rejected)
- **Borrow books** by ISBN and record the borrower's name
- **Return books** and see who had borrowed them
- **Search** by title or author (case-insensitive, partial match)
- **Library report** showing totals (all / available / borrowed) and per-book details
- **Colored console output**: green for success, red for errors, yellow for borrowed items, cyan/magenta for headers
- **Random ASCII-art logo** (one of three) shown at startup
- **Input validation**: handles missing ISBNs, already-borrowed books, and books that were never borrowed

---

## 🧱 Project Structure

```
Library_Book_Manager_Project/
├── Program.cs     # Entry point: demo scenario that exercises every feature
├── Book.cs        # Book model (title, author, ISBN, borrow status)
├── Library.cs     # Core logic: add, borrow, return, search, report
└── Logo.cs        # Random ASCII-art logo displayed at startup
```

| File | Responsibility |
|------|----------------|
| `Program.cs` | Creates the library, adds sample books, runs borrow/return/search scenarios, prints reports |
| `Book.cs` | Data model with a custom `ToString()` that formats the book's info and status |
| `Library.cs` | Stores books in a `Dictionary<string, Book>` keyed by ISBN for O(1) lookup and contains all business logic |
| `Logo.cs` | Picks a random logo using `Random` and prints it using C# raw string literals |

---

## 🧠 Design Overview

### `Book`
Declared with a **primary constructor** (C# 12) to keep the model concise.

| Property | Type | Description |
|----------|------|-------------|
| `Title` | `string` | Book title |
| `Author` | `string` | Book author |
| `ISBN` | `string` | Unique identifier |
| `IsBorrowed` | `bool` | `false` by default |
| `BorrowerName` | `string?` | `null` when the book is available |

### `Library`
Books are stored in a `Dictionary<string, Book>` using the ISBN as the key, which guarantees uniqueness and fast lookups.

| Method | Description |
|--------|-------------|
| `AddBook(Book book)` | Adds a book, or shows an error if the ISBN already exists |
| `BorrowBook(string isbn, string borrowerName)` | Marks a book as borrowed; fails if not found or already borrowed |
| `ReturnBook(string isbn)` | Marks a book as available; fails if not found or not borrowed |
| `Search(string query)` | Case-insensitive search across title and author |
| `PrintReport()` | Prints totals and a detailed list of all books |
| `PrintColored(...)` *(private)* | Helper that prints a message in a given color, then resets it |

### `Logo`
Randomly selects one of **three ASCII-art logos** each run using `Random.Next(1, 4)`.

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download) or later (the code uses C# 12 primary constructors and C# 11 raw string literals)
- Any terminal, or Visual Studio / VS Code / JetBrains Rider

### Run the project

```bash
# Clone the repository
git clone https://github.com/<your-username>/<your-repo-name>.git
cd <your-repo-name>

# Build and run
dotnet run
```

Press **Enter** at the end to close the program.

---

## 🖥️ Demo Scenario

`Program.cs` runs the following flow:

1. Display a random logo
2. Add three books: *The Great Gatsby*, *1984*, *To Kill a Mockingbird*
3. Borrow *The Great Gatsby* as **Tomas** ✅
4. Try to borrow the same book as **Mary** ❌ (already borrowed)
5. Search for `"Orwell"`
6. Print the library report
7. Return *The Great Gatsby*
8. Print the report again

### Sample output

```
Welcome to the Library Book Manager
<random ASCII logo>

Success: 'The Great Gatsby' added to the library.
Success: '1984' added to the library.
Success: 'To Kill a Mockingbird' added to the library.
Success: 'The Great Gatsby' borrowed by Tomas.
Error: 'The Great Gatsby' is already borrowed by Tomas.

--- Search Results for 'orwell' ---
Title: 1984 | Author: George Orwell | ISBN: 9780451524935 | Status: Available

========== LIBRARY REPORT ==========

Total Books: 3
Available Books: 2
Borrowed Books: 1

Book 1: The Great Gatsby
Author: F. Scott Fitzgerald
ISBN: 9780743273565
Status: Borrowed
Borrowed By: Tomas
------------------------------------
...
====================================

Success: 'The Great Gatsby' returned. (Was borrowed by Tomas).
```

---

## 🎓 Concepts Demonstrated

- Object-oriented design (encapsulation and separation of concerns)
- Primary constructors (C# 12)
- Raw string literals (C# 11)
- `Dictionary<TKey, TValue>` for fast key-based lookup
- LINQ (`Count` with a predicate)
- Nullable reference types (`string?`)
- Method overriding (`ToString()`)
- Console color formatting with `Console.ForegroundColor` / `ResetColor`

---

## 🔮 Possible Improvements

- [ ] Interactive menu so users can add, borrow, and search at runtime
- [ ] Persist data to JSON, CSV, or a database (e.g. SQLite)
- [ ] Remove or edit books
- [ ] Borrow due dates and late-return tracking
- [ ] Support multiple copies per ISBN
- [ ] Unit tests (xUnit) for `Library` logic
- [ ] Separate the UI (console output) from the business logic

---

## 👤 Author

**Tomas Makram**

---

## 📄 License

This project is open source and available under the [MIT License](LICENSE).
