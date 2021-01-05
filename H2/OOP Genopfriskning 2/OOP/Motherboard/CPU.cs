using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class CPU : Global
    {
        public int cores { get; private set; }

        public double clock { get; private set; }

        public CPU(string name, string model, int price, int cores, double clock) : base(name, model, price)
        {
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
