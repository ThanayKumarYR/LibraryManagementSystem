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
        private Dictionary<ILibraryUser, List<ILibraryItem>> _borrowedItems;
        public Library()
        {
            _catalog = new List<ILibraryItem>();
            _borrowedItems = new Dictionary<ILibraryUser, List<ILibraryItem>>();
        }

        // Add an item to the library catalog
        public void AddItem(ILibraryItem item)
        {
            _catalog.Add(item);
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
    }
}
