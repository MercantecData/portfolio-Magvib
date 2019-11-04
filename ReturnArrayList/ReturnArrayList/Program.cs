using System;

namespace ReturnArrayList
{
    class Program
    {
        static int[] ArrayRetuner(int tal)
        {
            int[] arrayCounter = new int[tal];
            int i = 0;
            while (i < arrayCounter.Length)
            {
                arrayCounter[i] = i+1;
                i += 1;
            }
            return arrayCounter;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Counting to the number you choose!");
            var CounterTal = Console.ReadLine();
            var arrayet = ArrayRetuner(Convert.ToInt32(CounterTal));
            foreach (int i in arrayet)
            {
                Console.Write(i + " ");
            }
        }
    }
}
