using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Computer : Global
    {
        public Keyboard keyboard { get; set; }

        public List<Monitor> monitor{ get; set; }

        public Mouse mouse { get; set; }

        public PowerSupply powerSupply{ get; set; }

        public Motherboard motherboard{ get; set; }

        public Computer(string name, string model) : base(name, model, 0)
        {
            this.monitor = new List<Monitor>();
        }

        public void setKeyboard(string name, string model, int price)
        {
            this.keyboard = new Keyboard(name, model, price);
        }

        public void setMouse(string name, string model, int price)
        {
            this.mouse = new Mouse(name, model, price);
        }

        public void addMonitor(string name, string model, int price, int inches, int hz)
        {
            this.monitor.Add(new Monitor(name, model, price, inches, hz));
        }

        public void setPowerSupply(string name, string model, int price, int wattage)
        {
            this.powerSupply = new PowerSupply(name, model, price, wattage);
        }

        public void setMotherboard(string name, string model, int price, int memorySlots)
        {
            this.motherboard = new Motherboard(name, model, price, memorySlots);
        }
    }
}
