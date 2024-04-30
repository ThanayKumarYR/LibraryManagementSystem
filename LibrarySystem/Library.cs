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
        public Library()
        {
            _catalog = new List<ILibraryItem>();
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
    }
}
