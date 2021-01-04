using System;

namespace dataTypes
{
    class Program
    {
        static void Main(string[] args)
        {

            string stringVar = "Hello World!!";

            // 32bit: 2,147,483,647 / 64bit: 9,223,372,036,854,775,807
            int intVar = 100;

            int i = 21474836470;

            // 32bit: 3.402823e38
            float floatVar = 10.2f;

            // 64bit: 1.79769313486232e308
            double doubleVar = 12.3d;

            // En character
            char charVar = 'A';

            // 8bit: True / False
            bool boolVar = true;


            var varInt = 3d;
            var varString = "string";


            Console.WriteLine(stringVar);
            Console.WriteLine(intVar);
            Console.WriteLine(floatVar);
            Console.WriteLine(doubleVar);
            Console.WriteLine(charVar);
            Console.WriteLine(boolVar);
            Console.WriteLine(varInt);
            Console.WriteLine(varString);
        }
    }
}
