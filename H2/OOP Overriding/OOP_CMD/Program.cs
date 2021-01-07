using System;
using System.Collections.Generic;
using OOP;

namespace OOP_CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            ComputerShop cp = new ComputerShop("Elgiganten");

            cp.addComputer(new Router("ASUS Router", 115, 8, 12));
            cp.addComputer(new Laptop("ASUS Laptop", 500, 16, 24, "Bose", 32000));
            cp.addComputer(new Phone("Iphone", 128, 8, 6, 16000, 80));
            cp.addComputer(new Server("Homelab Server", 10000, 100, "AMD epyc 7742", 64, 3.4));


            // Virtual calls
            foreach (KeyValuePair<string, Computer> c in cp.computers)
            {
                c.Value.systemCheck();
            }

            // Abstract calls
            foreach (KeyValuePair<string, Computer> c in cp.computers)
            {
                Console.WriteLine(c.Value.GetDescription());
            }
        }
    }
}
