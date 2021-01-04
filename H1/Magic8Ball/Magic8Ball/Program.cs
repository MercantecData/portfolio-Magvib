using System;

namespace Magic8Ball
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Magic 8 Ball!");
            string[] array = { "Yes", "No", "Maby", "42" };
            Random random = new Random();
            while (true)
            {
                string q = Console.ReadLine();
                Console.WriteLine(q + " is " + array[random.Next(array.Length)]);
            }
        }
    }
}
