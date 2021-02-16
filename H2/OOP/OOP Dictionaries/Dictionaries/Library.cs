using System;
using System.Collections.Generic;

namespace Dictionaries
{
    public class Library
    {
        public string name { get; private set; }
        public Dictionary<string, Book> books { get; private set; }

        public Library(string name)
        {
            this.name = name;
            this.books = new Dictionary<string, Book>();
        }

        public void addBook(Book b)
        {
            this.books.Add(b.name, b);
        }
        public void removeBook(Book b)
        {
            this.books.Remove(b.name);
        }
        public void removeBook(string name)
        {
            this.books.Remove(name);
        }
        public Book getBook(string name)
        {
            return this.books[name];
        }

        public void changeKey(string oldName, string newName)
        {
            Book b = this.books[oldName];
            this.books.Remove(oldName);
            this.books.Add(newName, b);
        }
    }
}
