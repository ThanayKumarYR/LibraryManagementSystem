﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public interface ILibraryItem
    {
        string Title { get; }
        string Author { get; }
    }
}
