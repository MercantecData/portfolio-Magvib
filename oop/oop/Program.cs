using System;

namespace oop
{
    public class Penalhus
    {
        public int blyanter;
        public bool hasEraser;

        public Penalhus(int blyanter, bool hasEraser)
        {
            this.blyanter = blyanter;
            this.hasEraser = hasEraser;
        }
        public void say()
        {
            if(hasEraser == true)
            {
                Console.WriteLine("Du har " + blyanter + " blyanter og du har også et viskelæder");
            } else
            {
                Console.WriteLine("Du har " + blyanter + " blyanter men du har ikke et viskelæder");
            }
        }
    }

    public class Cars
    {
        public string model;
        public int price;
        public int doors;
        public int kmh;

        public Cars(string model, int price, int doors, int kmh)
        {
            this.model = model;
            this.price = price;
            this.doors = doors;
            this.kmh = kmh;
        }

        public void say()
        {
            Console.WriteLine("Your car is a " + model + " and it has " + doors + " doors and it costs " + price + " and it can run " + kmh + " Km/h");
        }
    }

    public class Computer
    {
        public string name;
        public int price;
        public bool canPlayGames;

        public Computer(string name, int price, bool canPlayGames)
        {
            this.name = name;
            this.price = price;
            this.canPlayGames = canPlayGames;
        }

        public void say()
        {
            if (canPlayGames == true)
            {
                Console.WriteLine("Your computer is a " + name + " and it costs " + price + " and it can play games");
            }
            else
            {
                Console.WriteLine("Your computer is a " + name + " and it costs " + price + " and it can't play games");
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("---------------------");
            var myComputer = new Computer("MacBook", 9000, false);
            myComputer.say();

            Console.WriteLine("---------------------");
            myComputer = new Computer("Lenovo", 7500, true);
            myComputer.say();

            Console.WriteLine("---------------------");
            var myCar = new Cars("Ford", 320000, 5, 210);
            myCar.say();

            Console.WriteLine("---------------------");
            myCar = new Cars("Audi", 420000, 5, 260);
            myCar.say();

            Console.WriteLine("---------------------");
            var mitPenalhus = new Penalhus(15, true);
            mitPenalhus.say();

        }
    }
}
