using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public interface ILibrary : IEnumerable<ILibraryItem>
    {
        void AddItem(ILibraryItem item);
        List<ILibraryItem> SearchItemsByAuthor(string author);
        void BorrowItem(ILibraryUser user, ILibraryItem item);
        void ReturnItem(ILibraryUser user, ILibraryItem item);

    }
}
