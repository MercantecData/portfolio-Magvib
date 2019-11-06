using System;
using System.Collections.Generic;

namespace CykelShop
{
    class Program
    {
        static void Main(string[] args)
        {
            CykelButik CykelButik = new CykelButik("Jensens CykelShop");
            CykelButik.AddCykel(new Cykler("Cykel Ford", 15, "Blue", 2018));
            CykelButik.AddCykel(new Cykler("Ford Fiesta", 12, "Red", 2013));

            CykelButik CykelButik2 = new CykelButik("Nielsens CykelShop");
            CykelButik2.AddCykel(new Cykler("Cykel 1", 17, "Blue", 2011));
            CykelButik2.AddCykel(new Cykler("Cykel 2", 10, "Red", 2015));

            Console.WriteLine(CykelButik.CyklerAntal());

            var array = CykelButik.CyklerModels();

            for (int i = 0; i < array.Count; i++)
            {
                Console.WriteLine(array[i]);
            }

            var array2 = CykelButik.CyklerWheelsUnder(14);

            for (int i = 0; i < array2.Count; i++)
            {
                Console.WriteLine(array2[i]);
            }
        }
    }
}
