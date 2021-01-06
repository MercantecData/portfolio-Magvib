using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionaries
{
    public class Book
    {
        public string name { get; private set; }
        public int totalPages { get; private set; }

        public Book(string name, int totalPages)
        {
            this.name = name;
            this.totalPages = totalPages;
        }

        public void changeName(string name, Library l)
        {
            l.changeKey(this.name, name);
            this.name = name;
        }
    }
}
