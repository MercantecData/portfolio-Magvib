using System;
namespace CykelShop
{
    public class Cykler
    {
        public string model;
        public int wheelsize;
        public string color;
        public int year;

        public Cykler(string model, int wheelsize, string color, int year)
        {
            this.model = model;
            this.wheelsize = wheelsize;
            this.color = color;
            this.year = year;
        }
    }
}
