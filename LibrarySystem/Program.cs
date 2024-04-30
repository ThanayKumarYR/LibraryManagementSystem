using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Geting started with Library Management System !");

            ILibrary library = new Library();

            library.AddItem(new Book("Book_MalgudiDays", "R. K. Narayan", "9788185986173"));
            library.AddItem( new Book("Romeo and Juliet", "William Shakespeare", "9789380816272"));

            foreach (Book book in library)
            {
                Console.WriteLine($"Book: {book.Title} Author: {book.Author} Isbn: {book.ISBN}");
            }

            // Test borrowing and returning items
            ILibraryUser User_Thanay = new LibraryUser("Thanay", 1);
            ILibraryUser User_Saikat = new LibraryUser("Saikat", 2);
            ILibraryItem book_Narayan = library.SearchItemsByAuthor("R. K. Narayan").FirstOrDefault();
            ILibraryItem book_Shakespeare = library.SearchItemsByAuthor("William Shakespeare").FirstOrDefault();

        }
    }
}
