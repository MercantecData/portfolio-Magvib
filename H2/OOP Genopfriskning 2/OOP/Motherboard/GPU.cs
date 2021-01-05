using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class GPU
    {
        public string name { get; private set; }
        public string model { get; private set; }
        public int price { get; private set; }
        public int memory { get; private set; }

        public GPU(string name, string model, int price, int memory)
        {
            this.name = name;
            this.model = model;
            this.price = price;
            this.memory = memory;
        }

        public void setMemory(int memory)
        {
            this.memory = memory;
        }
    }
}
