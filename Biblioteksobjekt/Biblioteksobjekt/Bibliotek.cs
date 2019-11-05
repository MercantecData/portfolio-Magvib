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

        public int BogCount()
        {
            return Bog.Count;
        }

        public void AddBog(Bog Title)
        {
            Bog.Add(Title);
        }

        public string RemoveBog(int id)
        {
            string name = Bog[id].title;
            Bog.RemoveAt(id);
            return "Removed book named " + name;
        }

        public string RentBog(int id, int days)
        {
            Bog[id].isRented = true;
            Bog[id].dueDate = days;
            return "You have rented " + Bog[id].title + " in " + Bog[id].dueDate + " days";

        }

        public string RentCheck(int id)
        {
            string message;
            if (Bog[id].isRented)
            {
                message = "This book is rented in " + Bog[id].dueDate + " days";
            }
            else
            {
                message = "This book is not rented";
            }
            return message;
        }

        public string ReturnBog(int id)
        {
            string message;
            if (Bog[id].isRented)
            {
                Bog[id].isRented = false;
                Bog[id].dueDate = 0;
                message = "You have now returned the book";
            }
            else
            {
                message = "Book is not rented";
            }
            return message;
        }

        public string BogTitle(int id)
        {
            return Bog[id].title;
        }
    }
}
