using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class PowerSupply : Global
    {
        public int wattage { get; set; }

        public PowerSupply(string name, string model, int price, int wattage) : base(name, model, price)
        {
            this.wattage = wattage;
        }
    }
}
