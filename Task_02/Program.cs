using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace Task_02
{
    class Book {

        string title;
        string author;
        string ISBN;
        bool availability;

        public Book(string title, string author, string iSBN, bool availability = true)
        {
            this.title = title;
            this.author = author;
            ISBN = iSBN;
            this.availability = availability;
        }

        public string GetTitle() { 
            return this.title;
        }

        public string GetAuthor()
        {
            return this.author;
        }

        public string GetISBN()
        {
            return this.ISBN;
        }

        public bool GetAvailability()
        {
            return this.availability;
        }

        public void SetTitle(string title) { 
            this.title = title;
        }

        public void SetAuthor(string author)
        {
            this.author = author;
        }

        public void SetISBN(string ISBN)
        {
            this.ISBN = ISBN;
        }

        public void SetAvailability(bool availability)
        {
            this.availability = availability;
        }



    }
    class Library {
        List<Book> books = new List<Book>();

        public Library()
        {
            
        }

        public void AddBook(Book book) {
            books.Add(book);
        }

        (bool,int) SearchBook(string title) {
            bool flag = false;
            int index = -1;
            for(int i = 0; i < books.Count; i++)
            {
                if (books[i].GetTitle() == title)
                {
                    flag = true;
                    index = i;
                    break;
                }
            }
            return (flag,index);
        }

        public void BorrowBook(string title) {
            bool flag = false;
            int index = -1;
            (flag,index)= SearchBook(title);
            if (flag && index !=-1 )
            {
                if (books[index].GetAvailability() == true)
                {
                    books[index].SetAvailability(false);
                    Console.WriteLine("DONE");
                }
            }
            else if (flag)
            {

                Console.WriteLine("This book is not available");
            }
            else {
                Console.WriteLine("This book is not in the library");
            }
            
        }

        public void ReturnBook(string title)
        {
            bool flag = default;
            int index = -1;
            (flag, index) = SearchBook(title);
            if (flag && index != -1)
            {
                if (books[index].GetAvailability() == false)
                {
                    books[index].SetAvailability(true);
                    Console.WriteLine("DONE");
                }
            }
            else
            {
                Console.WriteLine("This book is not in the library");
            }

        }


    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Adding books to the library
            library.AddBook(new Book("Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            library.BorrowBook("Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter"); // This book is not in the library

            // Returning books
            Console.WriteLine("\nReturning books...");
            library.ReturnBook("Gatsby");
            library.ReturnBook("Harry Potter"); // This book is not borrowed

            Console.ReadLine();

        }
    }
}
