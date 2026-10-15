namespace Library_Book_Manager_Project
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Display the logo
            Logo logo = new Logo();
            logo.Display();

            // Create an instance of the Library class
            Library myLibrary = new Library();

            //Add some books to the library
            Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565");
            Book book2 = new Book("1984", "George Orwell", "9780451524935");
            Book book3 = new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084");

            myLibrary.AddBook(book1);
            myLibrary.AddBook(book2);
            myLibrary.AddBook(book3);

            //Borrow a book
            myLibrary.BorrowBook("9780743273565", "Tomas");
            myLibrary.BorrowBook("9780743273565", "Mary");

            // Search for books by title or author
            myLibrary.Search("Orwell");

            // 5. Print the final report
            myLibrary.PrintReport();

            // 6. Return a book
            myLibrary.ReturnBook("9780743273565");
            myLibrary.PrintReport();

            Console.ReadLine();
        }
    }
}
