using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class Library : ILibrary
    {
        private List<ILibraryItem> _catalog;
        private List<ILibraryUser> _libraryUsers;
        private Dictionary<ILibraryUser, List<ILibraryItem>> _borrowedItems;
        public Library()
        {
            _catalog = new List<ILibraryItem>();
            _borrowedItems = new Dictionary<ILibraryUser, List<ILibraryItem>>();
            _libraryUsers = new List<ILibraryUser>();
        }

        // Add an item to the library catalog
        public void AddItem(ILibraryItem item)
        {
            _catalog.Add(item);
        }

        public void AddUsers(ILibraryUser user)
        {
            _libraryUsers.Add(user);
        }

        public IEnumerator<ILibraryItem> GetEnumerator()
        {
            return _catalog.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // LINQ query to filter items by author
        public List<ILibraryItem> SearchItemsByAuthor(string author)
        {
            return _catalog.Where(item => item.Author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void BorrowItem(ILibraryUser user, ILibraryItem item)
        {
            lock (_borrowedItems)
            {
                if (_catalog.Contains(item))
                {
                    _catalog.Remove(item);
                    if (!_borrowedItems.ContainsKey(user))
                    {
                        _borrowedItems[user] = new List<ILibraryItem>();
                    }
                    _borrowedItems[user].Add(item);
                    Console.WriteLine($"{user.Name} borrowed '{item.Title}'.");
                }
                else
                {
                    Console.WriteLine($"Sorry, '{item.Title}' is not available.");
                }
            }
        }

        public void ReturnItem(ILibraryUser user, ILibraryItem item)
        {
            lock (_borrowedItems)
            {
                if (_borrowedItems.ContainsKey(user) && _borrowedItems[user].Contains(item))
                {
                    _borrowedItems[user].Remove(item);
                    _catalog.Add(item);
                    Console.WriteLine($"{user.Name} returned '{item.Title}'.");
                }
                else
                {
                    Console.WriteLine($"Sorry, '{item.Title}' was not borrowed by {user.Name}.");
                }
            }
        }

        // LINQ query to sort items by title
        public void SortItemsByTitle()
        {
            _catalog = _catalog.OrderBy(item => item.Title).ToList();
        }

        // LINQ query to find users by name
        public List<ILibraryUser> FindUsersByName(string name)
        {
            // Assuming users are stored elsewhere
            return _libraryUsers.Where(user => user.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // Method to handle borrowing and returning items concurrently
        public void ConcurrentBorrowReturn()
        {
            // Test borrowing and returning items by multiple users concurrently
            Console.WriteLine("\nTesting the borrowing and returning items by multiple users concurrently");
            ILibraryUser user1 = new LibraryUser("Yashwant", 1);
            ILibraryUser user2 = new LibraryUser("Lakshmi", 2);
            ILibraryItem item1 = _catalog.FirstOrDefault();
            ILibraryItem item2 = _catalog.LastOrDefault();

            Thread thread1 = new Thread(() => BorrowItem(user1, item1));
            Thread thread2 = new Thread(() => BorrowItem(user2, item2));
            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            ReturnItem(user1, item1);
            ReturnItem(user2, item2);
        }
    }
}
