using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Monitor
    {
        public string name { get; private set; }
        public string model { get; private set; }
        public int price { get; private set; }
        public int inches { get; private set; }

        public int hz { get; private set; }

        public Monitor(string name, string model, int price, int inches, int hz)
        {
            this.name = name;
            this.model = model;
            this.price = price;
            this.inches = inches;
            this.hz = hz;
        }

        public void setInches(int inches)
        {
            this.inches = inches;
        }

        public void setHZ(int hz)
        {
            this.hz = hz;
        }
    }
}
