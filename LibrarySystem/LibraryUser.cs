using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class LibraryUser : ILibraryUser
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public LibraryUser(string name, int id)
        {
            Name = name;
            ID = id;
        }
    }
}
