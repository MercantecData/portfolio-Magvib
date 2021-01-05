using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class PowerSupply : Global
    {
        public int wattage { get; private set; }

        public PowerSupply(string name, string model, int price, int wattage) : base(name, model, price)
        {
            this.wattage = wattage;
        }

        public void setWattage(int wattage)
        {
            this.wattage = wattage;
        }
    }
}
