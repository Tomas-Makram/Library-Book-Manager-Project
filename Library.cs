using System;
using System.Collections.Generic;

namespace Library_Book_Manager_Project
{
    public class Library
    {
        // Using a dictionary to store books with ISBN as the key for quick lookup
        private Dictionary<string, Book> books = new Dictionary<string, Book>();

        // Helper function to print messages with colors
        private void PrintColored(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color; // Change the color
            Console.WriteLine(message);
            Console.ResetColor(); // Reset to default color
        }

        // Function to add a book
        public void AddBook(Book book)
        {
            if (books.ContainsKey(book.ISBN))
            {
                PrintColored($"Error: Book with ISBN {book.ISBN} already exists.", ConsoleColor.Red);
            }
            else
            {
                books.Add(book.ISBN, book);
                PrintColored($"Success: '{book.Title}' added to the library.", ConsoleColor.Green);
            }
        }

        // Function to borrow a book
        public void BorrowBook(string isbn, string borrowerName)
        {
            if (!books.ContainsKey(isbn))
            {
                PrintColored($"Error: Book with ISBN {isbn} not found.", ConsoleColor.Red);
                return;
            }

            Book book = books[isbn];
            if (book.IsBorrowed)
            {
                PrintColored($"Error: '{book.Title}' is already borrowed by {book.BorrowerName}.", ConsoleColor.Red);
            }
            else
            {
                book.IsBorrowed = true;
                book.BorrowerName = borrowerName;
                PrintColored($"Success: '{book.Title}' borrowed by {borrowerName}.", ConsoleColor.Green);
            }
        }

        // Function to return a book
        public void ReturnBook(string isbn)
        {
            if (!books.ContainsKey(isbn))
            {
                PrintColored($"Error: Book with ISBN {isbn} not found.", ConsoleColor.Red);
                return;
            }

            Book book = books[isbn];
            if (!book.IsBorrowed)
            {
                PrintColored($"Error: '{book.Title}' was not borrowed.", ConsoleColor.Red);
            }
            else
            {
                string borrower = book.BorrowerName!;
                book.IsBorrowed = false;
                book.BorrowerName = null;
                PrintColored($"Success: '{book.Title}' returned. (Was borrowed by {borrower}).", ConsoleColor.Green);
            }
        }

        // Function to search for books by title or author
        public void Search(string query)
        {
            List<Book> results = new List<Book>();
            query = query.ToLower();

            foreach (var book in books.Values)
            {
                if (book.Title.ToLower().Contains(query) || book.Author.ToLower().Contains(query))
                {
                    results.Add(book);
                }
            }

            if (results.Count > 0)
            {
                PrintColored($"\n--- Search Results for '{query}' ---", ConsoleColor.Cyan);
                foreach (var book in results)
                {
                    Console.WriteLine(book);
                }
            }
            else
            {
                PrintColored($"No books found matching '{query}'.", ConsoleColor.Yellow);
            }
        }

        // Function to print the final report
        public void PrintReport()
        {
            int totalBooks = books.Count;
            int borrowedCount = books.Values.Count(book => book.IsBorrowed);
            int availableCount = totalBooks - borrowedCount;

            PrintColored("========== LIBRARY REPORT ==========", ConsoleColor.Magenta);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Total Books: {totalBooks}");
            Console.WriteLine($"Available Books: {availableCount}");
            Console.WriteLine($"Borrowed Books: {borrowedCount}");
            Console.ResetColor();
            Console.WriteLine();

            int index = 1;
            foreach (var book in books.Values)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Book {index}: {book.Title}");
                Console.ResetColor();

                Console.WriteLine($"Author: {book.Author}");
                Console.WriteLine($"ISBN: {book.ISBN}");

                if (book.IsBorrowed)
                {
                    PrintColored("Status: Borrowed", ConsoleColor.Yellow);
                    PrintColored($"Borrowed By: {book.BorrowerName}", ConsoleColor.DarkYellow);
                }
                else
                {
                    PrintColored("Status: Available", ConsoleColor.Green);
                }

                Console.WriteLine("------------------------------------");
                index++;
            }

            PrintColored("====================================", ConsoleColor.Magenta);
            Console.WriteLine();
        }
    }
}