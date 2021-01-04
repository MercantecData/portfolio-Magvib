using System;

namespace Grund
{
    class Program
    {
        static void Main(string[] args)
        {
            IngenRetur();
            Console.WriteLine(Sum(1, 1));
            Console.WriteLine(AllC("hello"));
            Console.WriteLine(SatSammen("sat ", "sammen"));
            Console.WriteLine("Tal i anden: " + IAnden(2));
            RetunerAndetTal(1);
        }

        static void IngenRetur()
        {
            Console.WriteLine("Hello");
        }

        static int Sum(int tal1, int tal2)
        {
            return tal1 + tal2;
        }

        static string AllC(string text)
        {
            String textToUpper = text.ToUpper();
            return textToUpper;
        }

        static string SatSammen(string text1, string text2)
        {
            return text1 + text2;
        }

        static int IAnden(int tal)
        {
            return tal * tal;
        }

        static void RetunerAndetTal(int tal)
        {
            switch (tal)
            {
                case 1:
                    Console.WriteLine(5);
                    break;
                case 2:
                    Console.WriteLine(4);
                    break;
                case 3:
                    Console.WriteLine(1);
                    break;
                case 4:
                    Console.WriteLine(2);
                    break;
                case 5:
                    Console.WriteLine(3);
                    break;
                default:
                    Console.WriteLine("Vælg et tal imellem 1 og 5");
                    break;
            }

        }
    }
}
