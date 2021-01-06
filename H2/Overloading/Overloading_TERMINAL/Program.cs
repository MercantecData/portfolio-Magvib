using System;
using Overloading;

namespace Overloading_TERMINAL
{
    class Program
    {
        static void Main(string[] args)
        {
            M m = new M();

            Console.WriteLine(m.Plus(1, 1));
            Console.WriteLine(m.Plus(1.9, 1.9));
            Console.WriteLine(m.Plus(1.9, 1));
            Console.WriteLine(m.Plus(1, 1.9));

            Console.WriteLine(m.Minus(1, 1));
            Console.WriteLine(m.Minus(1.9, 1.9));
            Console.WriteLine(m.Minus(1.9, 1));
            Console.WriteLine(m.Minus(1, 1.9));

            Console.WriteLine(m.Dividere(1, 1));
            Console.WriteLine(m.Dividere(1.9, 1.9));
            Console.WriteLine(m.Dividere(1.9, 1));
            Console.WriteLine(m.Dividere(1, 1.9));

            Console.WriteLine(m.Gange(1, 1));
            Console.WriteLine(m.Gange(1.9, 1.9));
            Console.WriteLine(m.Gange(1.9, 1));
            Console.WriteLine(m.Gange(1, 1.9));

            Console.WriteLine(m.Kvadratrod(20));
            Console.WriteLine(m.Kvadratrod(20.5));


            Console.WriteLine(m.Potens(1, 1));
            Console.WriteLine(m.Potens(1.9, 1.9));
            Console.WriteLine(m.Potens(1.9, 1));
            Console.WriteLine(m.Potens(1, 1.9));

        }
    }
}
