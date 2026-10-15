using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Book_Manager_Project
{
    public class Book(string title, string author, string isbn)
    {
        public string Title { get; set; } = title;
        public string Author { get; set; } = author;
        public string ISBN { get; set; } = isbn;
        public bool IsBorrowed { get; set; } = false;
        public string? BorrowerName { get; set; } = null;

        // Override the ToString method to display book information
        public override string ToString()
        {
            string status;

            if (IsBorrowed)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                status = $"Borrowed by {BorrowerName}";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                status = "Available";
            }

            string result = $"Title: {Title} | Author: {Author} | ISBN: {ISBN} | Status: {status}";

            Console.ResetColor();

            return result;
        }
    }
}
