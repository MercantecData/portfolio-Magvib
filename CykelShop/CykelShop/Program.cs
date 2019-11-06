using System;
using System.Collections.Generic;

namespace CykelShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Koncern Koncern = new Koncern();

            // Butik nr.1
            Koncern.AddButik(new CykelButik("Jensens CykelShop"));
            Koncern.CykelButik[0].AddCykel(new Cykler("Cykel Ford", 15, "Blue", 2018));
            Koncern.CykelButik[0].AddCykel(new Cykler("Ford Fiesta", 12, "Red", 2013));

            // Butik nr.2
            Koncern.AddButik(new CykelButik("Nielsens CykelShop"));
            Koncern.CykelButik[1].AddCykel(new Cykler("Cykel 1", 17, "Blue", 2011));
            Koncern.CykelButik[1].AddCykel(new Cykler("Cykel 2", 10, "Red", 2015));

            // Hvor mange cykler har Butik nr.1
            Console.WriteLine(Koncern.CykelButik[0].CyklerAntal());

            /* Returner alle models fra Butik nr.1
             * Og laver et forloop som skriver alle modellerne ud i konsollen
            */
            var array = Koncern.CykelButik[0].CyklerModels();
            for (int i = 0; i < array.Count; i++)
            {
                Console.WriteLine(array[i]);
            }


            /* Her retunere vi alle cyker som er under 14
             * Og laver et forloop som skriver dem ud i konsollen
            */
            var array2 = Koncern.CykelButik[0].CyklerWheelsUnder(14);
            for (int i = 0; i < array2.Count; i++)
            {
                Console.WriteLine(array2[i]);
            }

            // All red bikes from all the Bikeshops
            List<string> allRed = Koncern.ReturnAllRedBikes();
            for (int z = 0; z < allRed.Count; z++)
            {
                Console.WriteLine(allRed[z]);
            }
        }
    }
}
