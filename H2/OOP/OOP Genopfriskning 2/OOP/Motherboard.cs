using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Motherboard
    {
        public string name { get; private set; }
        public string model { get; private set; }
        public int price { get; private set; }
        public int memorySlots { get; private set; }

        public CPU cpu { get; private set; }

        public GPU gpu { get; private set; }

        public List<Memory> memory { get; private set; }

        public List<Storage> storage { get; private set; }

        public Motherboard(string name, string model, int price, int memorySlots)
        {
            this.name = name;
            this.model = model;
            this.price = price;
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

        public int totalPrice()
        {
            int price = this.price + this.cpu.price + this.gpu.price;

            foreach (Memory m in this.memory)
            {
                price = price + m.price;
            }

            foreach (Storage s in this.storage)
            {
                price = price + s.price;
            }

            return price;
        }
    }
}
