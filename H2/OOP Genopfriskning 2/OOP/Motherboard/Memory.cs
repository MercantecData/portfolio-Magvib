using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Memory : Global
    {
        public int speed { get; private set; }

        public int memory { get; private set; }

        public Memory(string name, string model, int price, int speed, int memory) : base(name, model, price)
        {
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
