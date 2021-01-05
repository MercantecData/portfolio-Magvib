using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Computer : Global
    {
        public Keyboard keyboard { get; private set; }

        public List<Monitor> monitor{ get; private set; }

        public Mouse mouse { get; private set; }

        public PowerSupply powerSupply{ get; private set; }

        public Motherboard motherboard{ get; private set; }

        public Computer(string name, string model) : base(name, model, 0)
        {
            this.monitor = new List<Monitor>();
        }

        public void setKeyboard(Keyboard k)
        {
            this.keyboard = k;
        }

        public void setMouse(Mouse m)
        {
            this.mouse = m;
        }

        public void addMonitor(Monitor m)
        {
            this.monitor.Add(m);
        }

        public void setPowerSupply(PowerSupply p)
        {
            this.powerSupply = p;
        }

        public void setMotherboard(Motherboard m)
        {
            this.motherboard = m;
        }
    }
}
