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

            // Test borrowing and returning items
            ILibraryUser User_Thanay = new LibraryUser("Thanay", 1);
            ILibraryUser User_Saikat = new LibraryUser("Saikat", 2);
            ILibraryItem book_Narayan = library.SearchItemsByAuthor("R. K. Narayan").FirstOrDefault();
            ILibraryItem book_Shakespeare = library.SearchItemsByAuthor("William Shakespeare").FirstOrDefault();

            library.BorrowItem(User_Thanay, book_Narayan);
            library.BorrowItem(User_Saikat, book_Shakespeare);

            library.ReturnItem(User_Thanay, book_Narayan);
            library.ReturnItem(User_Saikat, book_Shakespeare);

        }
    }
}
