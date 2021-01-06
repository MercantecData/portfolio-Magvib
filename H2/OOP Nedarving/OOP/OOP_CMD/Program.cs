using System;
using OOP;

namespace OOP_CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Router r = new Router("ASUS Router", 115, 8, 12);
            r.systemCheck();

            Laptop l = new Laptop("ASUS Laptop", 500, 16, 24, "Bose", 32000);
            l.systemCheck();

            Phone p = new Phone("Iphone", 128, 8, 6, 16000, 80);
            p.systemCheck();

            Server s = new Server("Homelab Server", 10000, 100, "AMD epyc 7742", 64, 3.4);
            s.systemCheck();
        }
    }
}
