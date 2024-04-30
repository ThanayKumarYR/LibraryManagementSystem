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

            Book MalgudiDays = new Book("MalgudiDays", "R. K. Narayan", "9788185986173");
            Book RomeoAndJuliet = new Book("Romeo and Juliet", "William Shakespeare", "9789380816272");

            Console.WriteLine($"Book: {MalgudiDays.Title} Author: {MalgudiDays.Author} Isbn: {MalgudiDays.ISBN}");
            Console.WriteLine($"Book: {RomeoAndJuliet.Title} Author: {RomeoAndJuliet.Author} Isbn: {RomeoAndJuliet.ISBN}");
        }
    }
}
