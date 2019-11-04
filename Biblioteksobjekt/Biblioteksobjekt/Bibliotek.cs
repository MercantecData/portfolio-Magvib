using System;
using System.Collections.Generic;

namespace Biblioteksobjekt
{
    public class Bibliotek
    {
        public string name;
        public List<Bog> Bog = new List<Bog>();

        public Bibliotek(string name)
        {
            this.name = name;
        }

        public void BogCount()
        {
            Console.WriteLine("Books: " + Bog.Count);
        }

        public void AddBog(Bog Title)
        {
            Bog.Add(Title);
            Console.WriteLine("You have now added a book");
        }

        public void RemoveBog(int id)
        {
            Bog.RemoveAt(id);
            Console.WriteLine("You have now deleted this book");
        }

        public void RentBog(int id, int days)
        {
            Bog[id].isRented = true;
            Bog[id].dueDate = days;
            Console.WriteLine("You have rented this book in " + Bog[id].dueDate + " days");
        }

        public void RentCheck(int id)
        {
            if (Bog[id].isRented)
            {
                Console.WriteLine("This book is rented in " + Bog[id].dueDate + " days");
            }
            else
            {
                Console.WriteLine("This book is not rented");
            }
        }

        public void ReturnBog(int id)
        {
            if (Bog[id].isRented)
            {
                Bog[id].isRented = false;
                Bog[id].dueDate = 0;
                Console.WriteLine("You have now returned the book");
            }
            else
            {
                Console.WriteLine("Book not rented");
            }
        }

        public void BogTitle(int id)
        {
            Console.WriteLine(Bog[id].title);
        }
    }
}
