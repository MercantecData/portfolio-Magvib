using System;
using System.Collections.Generic;

namespace Biblioteksobjekt
{
    public class Bibliotek
    {
        public string name;
        public List<Bog> Bog = new List<Bog>();
        public List<Kunder> Kunder = new List<Kunder>();

        public Bibliotek(string name)
        {
            this.name = name;
        }

        public int BogCount()
        {
            return Bog.Count;
        }

        public void AddKunde(Kunder Name)
        {
            Kunder.Add(Name);
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

        public string RentBog(int id, int days, int kundeid)
        {
            Bog[id].isRented = true;
            Bog[id].dueDate = days;
            Bog[id].rentedBy = Kunder[kundeid];
            Bog[id].rentedById = kundeid;
            Kunder[kundeid].AddBog(Bog[id]);
            return "You have rented " + Bog[id].title + " in " + Bog[id].dueDate + " days";

        }

        public string RentCheck(int id)
        {
            string message;
            if (Bog[id].isRented)
            {
                message = "This book is rented by " + Bog[id].rentedBy.name + " in " + Bog[id].dueDate + " days";
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
                Bog[id].rentedBy = null;
                Kunder[Bog[id].rentedById].Bog.Remove(Bog[id]);
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

        public string BogEdit(int id, string title)
        {
            Bog[id].title = title;
            return "Now the book title is " + Bog[id].title;
        }
    }
}
