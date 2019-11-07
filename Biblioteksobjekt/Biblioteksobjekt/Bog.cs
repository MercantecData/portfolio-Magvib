using System;
namespace Biblioteksobjekt
{
    public class Bog
    {
        public string title;
        public bool isRented;
        public string rentedBy;
        public int rentedById;
        public int dueDate;

        public Bog(string title)
        {
            this.title = title;
        }
    }
}
