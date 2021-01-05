using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Motherboard : Global
    {
        public int memorySlots { get; private set; }

        public CPU cpu { get; private set; }

        public GPU gpu { get; private set; }

        public List<Memory> memory { get; private set; }

        public List<Storage> storage { get; private set; }

        public Motherboard(string name, string model, int price, int memorySlots) : base(name, model, price)
        {
            this.memorySlots = memorySlots;
            this.memory = new List<Memory>();
            this.storage = new List<Storage>();
        }

        public void setCPU(CPU c)
        {
            this.cpu = c;
        }

        public void setGPU(GPU g)
        {
            this.gpu = g;
        }

        public void addMemory(Memory m)
        {
            this.memory.Add(m);
        }

        public void addStorage(Storage s)
        {
            this.storage.Add(s);
        }
    }
}
