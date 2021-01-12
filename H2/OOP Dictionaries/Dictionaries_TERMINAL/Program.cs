using System;
using System.Collections.Generic;
using Dictionaries;

namespace Dictionaries_TERMINAL
{
    class Program
    {
        static void Main(string[] args)
        {
            Library l = new Library("Viborg Bibliotek");

            l.addBook(new Book("Harry Potter E1", 374));
            l.addBook(new Book("Harry Potter E2", 423));
            l.addBook(new Book("Harry Potter E3", 873));
            l.addBook(new Book("Harry Potter E4", 374));
            l.addBook(new Book("Harry Potter E5", 423));
            l.addBook(new Book("Harry Potter E6", 873));

            l.removeBook("Harry Potter E1");
            l.removeBook(l.getBook("Harry Potter E2"));

            l.getBook("Harry Potter E3").setTotalPages(123);

            Console.WriteLine(l.getBook("Harry Potter E3").totalPages);

            l.getBook("Harry Potter E3").changeName("Harry Potter E7", l);

            Console.WriteLine(l.getBook("Harry Potter E4").name);

            Console.WriteLine("----------");

            foreach (KeyValuePair<string, Book> b in l.books)
            {
                Console.WriteLine(b.Key);
            }
        }
    }
}
