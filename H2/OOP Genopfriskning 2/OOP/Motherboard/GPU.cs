using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class GPU : Global
    {
        public int memory { get; private set; }

        public GPU(string name, string model, int price, int memory) : base(name, model, price)
        {
            this.memory = memory;
        }
    }
}
