using System;
using System.Linq;

namespace Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Array Fucker!");
            Console.Write("Araray Number: ");
            string[] af = new string[Int32.Parse(Console.ReadLine())];

            for (int i = 0; i < af.Length; i++)
            {
                af[i] = Console.ReadLine();
            }

            Console.WriteLine("");

            for (int i = 0; i < af.Length; i++)
            {
                Console.WriteLine(af[i]);
            }

            Console.Write("Insert a tal: ");
            foreach (int item in IntReturner(Int32.Parse(Console.ReadLine())))
            { 
                Console.WriteLine(item+",");
            }

            int[] ST = { 12, 15, 21, 100 };
            Console.WriteLine(StørsteTal(ST));

            int[] ArraySorter = { 5, 3, 8, 5, 4, 6, 94, 5, 7, 85, 4, 3, 68, 8, 5, 47 };

            TalSorter(ArraySorter);

            foreach (var item in ArraySorter)
            {
                Console.WriteLine(item);
            }


        }

        static int[] IntReturner(int tal)
        {
            int[] TalArray = new int[tal];

            for (int i = 0; i < tal; i++)
            {
                TalArray[i] = i+1;
            }
            return TalArray;
        }

        static int StørsteTal(int[] ST)
        {
            return ST.Max();
        }
        static int[] TalSorter(int[] ST)
        {
            System.Array.Sort(ST);
            return ST;
        }
    }
}
