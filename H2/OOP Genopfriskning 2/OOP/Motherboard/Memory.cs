using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Memory
    {
        public string name { get; private set; }
        public string model { get; private set; }
        public int price { get; private set; }
        public int speed { get; private set; }

        public int memory { get; private set; }

        public Memory(string name, string model, int price, int speed, int memory)
        {
            this.name = name;
            this.model = model;
            this.price = price;
            this.speed = speed;
            this.memory = memory;
        }

        public void setMemory(int memory)
        {
            this.memory = memory;
        }

        public void setSpeed(int speed)
        {
            this.speed = speed;
        }
    }
}
