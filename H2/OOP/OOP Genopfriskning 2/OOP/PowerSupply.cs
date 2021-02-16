using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class PowerSupply
    {
        public string name { get; private set; }
        public string model { get; private set; }
        public int price { get; private set; }
        public int wattage { get; private set; }

        public PowerSupply(string name, string model, int price, int wattage)
        {
            this.name = name;
            this.model = model;
            this.price = price;
            this.wattage = wattage;
        }

        public void setWattage(int wattage)
        {
            this.wattage = wattage;
        }
    }
}
