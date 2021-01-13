using System;
using System.Threading.Tasks;

namespace OOP_Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Counter!");
            Counter(1, 1000).Wait();


            async Task Counter(int i = 1, int timer = 1000)
            {
                await Task.Delay(timer);
                Console.WriteLine(i);
                Counter(i+1, timer).Wait();
            }
        }
    }
}
