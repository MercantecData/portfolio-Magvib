using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Computer
    {
        public string name { get; private set; }
        public string model { get; private set; }
        public int price { get; private set; }
        public Keyboard keyboard { get; private set; }

        public List<Monitor> monitor{ get; private set; }

        public Mouse mouse { get; private set; }

        public PowerSupply powerSupply{ get; private set; }

        public Motherboard motherboard{ get; private set; }

        public Computer(string name, string model)
        {
            this.name = name;
            this.model = model;
            this.price = 0;
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

        public int totalPrice()
        {
            int price = this.price + this.keyboard.price + this.mouse.price + this.motherboard.totalPrice() + this.powerSupply.price;

            foreach (Monitor m in this.monitor)
            {
                price = price + m.price;
            }

            return price;
        }
    }
}
