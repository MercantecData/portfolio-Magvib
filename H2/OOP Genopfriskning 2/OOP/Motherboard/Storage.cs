using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Storage : Global
    {
        public int dataRate { get; private set; }

        public int capacity { get; private set; }

        public Storage(string name, string model, int price, int dataRate, int capacity) : base(name, model, price)
        {
            this.dataRate = dataRate;
            this.capacity = capacity;
        }
    }
}
