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

        public void setCapacity(int capacity)
        {
            this.capacity = capacity;
        }

        public void setDataRate(int dataRate)
        {
            this.dataRate = dataRate;
        }
    }
}
