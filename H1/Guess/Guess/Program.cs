using System;

namespace Guess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Guess The Number!");
            Console.WriteLine("The Number That Im Thinking Of Is Between 1 And 10");
            Random rnd = new Random();
            int number = rnd.Next(1, 10);
            int counter = 0;
            bool b = true;
            while (b)
            {
                Console.Write("Guess: ");
                string Guess = Console.ReadLine();
                if (number == Int32.Parse(Guess))
                {
                    Console.WriteLine("Good job the number was: " + number);
                    counter++;
                    Console.WriteLine("And it took you " + counter + " tries");
                    b = false;
                } else
                {
                    counter++;
                }
            }
        }
    }
}
