using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class ComputerShop
    {
        public string name{ get; private set; }
        public Dictionary<string, Computer> computers { get; private set; }

        public ComputerShop(string name)
        {
            this.name = name;
            this.computers = new Dictionary<string, Computer>();
        }

        public void addComputer(Computer c)
        {
            this.computers.Add(c.name, c);
        }

        public void removeComputer(string name)
        {
            this.computers.Remove(name);
        }

        public void removeComputer(Computer c)
        {
            this.computers.Remove(c.name);
        }

        public Computer getComputer(string name)
        {
            return this.computers[name];
        }

        public string[] GetAllDescriptions()
        {
            List<string> desc = new List<string>();

            foreach (KeyValuePair<string, Computer> c in this.computers)
            {
                desc.Add(c.Value.GetDescription());
            }

            return desc.ToArray();
        }
    }
}
