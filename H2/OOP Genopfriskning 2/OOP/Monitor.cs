using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Monitor : Global
    {
        public int inches { get; set; }

        public int hz { get; set; }

        public Monitor(string name, string model, int price, int inches, int hz) : base(name, model, price)
        {
            this.inches = inches;
            this.hz = hz;
        }
    }
}
