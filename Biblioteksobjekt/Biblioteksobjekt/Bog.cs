using System;
namespace Biblioteksobjekt
{
    public class Bog
    {
        public string title;
        public bool isRented;
        public Kunder rentedBy;
        public int dueDate;

        public Bog(string title)
        {
            this.title = title;
        }
    }
}
