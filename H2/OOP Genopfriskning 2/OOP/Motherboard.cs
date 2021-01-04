using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Motherboard : Global
    {
        public int memorySlots { get; set; }

        public CPU cpu { get; set; }

        public GPU gpu { get; set; }

        public List<Memory> memory { get; set; }

        public List<Storage> storage { get; set; }

        public Motherboard(string name, string model, int price, int memorySlots) : base(name, model, price)
        {
            this.memorySlots = memorySlots;
            this.memory = new List<Memory>();
            this.storage = new List<Storage>();
        }

        public void setCPU(string name, string model, int price, int cores, float clock)
        {
            this.cpu = new CPU(name, model, price, cores, clock);
        }

        public void setGPU(string name, string model, int price, int memory)
        {
            this.gpu = new GPU(name, model, price, memory);
        }

        public void addMemory(string name, string model, int price, int speed, int memory)
        {
            this.memory.Add(new Memory(name, model, price, speed, memory));
        }

        public void addStorage(string name, string model, int price, int dataRate, int capacity)
        {
            this.storage.Add(new Storage(name, model, price, dataRate, capacity));
        }
    }
}
