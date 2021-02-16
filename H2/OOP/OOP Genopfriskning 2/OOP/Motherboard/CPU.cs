using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class CPU
    {
        public string name { get; private set; }
        public string model { get; private set; }
        public int price { get; private set; }
        public int cores { get; private set; }

        public double clock { get; private set; }

        public CPU(string name, string model, int price, int cores, double clock)
        {
            this.name = name;
            this.model = model;
            this.price = price;
            this.cores = cores;
            this.clock = clock;
        }

        public void setCores(int cores)
        {
            this.cores = cores;
        }

        public void setClock(double clock)
        {
            this.clock = clock;
        }
    }
}
