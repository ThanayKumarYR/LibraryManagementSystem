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

            library.AddItem(new Book("MalgudiDays", "R. K. Narayan", "9788185986173"));
            library.AddItem( new Book("Romeo and Juliet", "William Shakespeare", "9789380816272"));

            // Test borrowing and returning items
            ILibraryUser User_Thanay = new LibraryUser("Thanay", 1);
            ILibraryUser User_Saikat = new LibraryUser("Saikat", 2);

            library.AddUsers(User_Thanay);
            library.AddUsers(User_Saikat);

            ILibraryItem book_Narayan = library.SearchItemsByAuthor("R. K. Narayan").FirstOrDefault();
            ILibraryItem book_Shakespeare = library.SearchItemsByAuthor("William Shakespeare").FirstOrDefault();

            library.BorrowItem(User_Thanay, book_Narayan);
            library.BorrowItem(User_Saikat, book_Shakespeare);

            library.ReturnItem(User_Thanay, book_Narayan);
            library.ReturnItem(User_Saikat, book_Shakespeare);

            // Test LINQ queries
            List<ILibraryItem> itemsByAuthor = library.SearchItemsByAuthor("William Shakespeare");

            foreach (ILibraryItem item in itemsByAuthor)
            {
                Console.WriteLine($"Book by Author {item.Author}: {item.Title}");
            }

            library.SortItemsByTitle();

            Console.WriteLine("Books,");
            foreach (ILibraryItem item in library)
            {
                Console.WriteLine(item.Title);
            }

            List<ILibraryUser> usersWithName = library.FindUsersByName("Thanay");

            Console.WriteLine($"Numbers of user with name Thanay: {usersWithName.Count}");

        }
    }
}
