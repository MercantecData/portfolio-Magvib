using System;
using OOP;

namespace OOP_GUI
{
    class Program
    {
        static void Main(string[] args)
        {

            Computer bestComp = new Computer("Beast Computer", "ASUS");

            bestComp.setKeyboard("K-100 CORE LED", "NOS", 500);
            bestComp.setMouse("Aerox 3", "SteelSeries", 799);
            bestComp.addMonitor("24G2U", "AOC", 1289, 24, 144);
            bestComp.addMonitor("24G2U", "AOC", 1289, 24, 144);

            bestComp.setPowerSupply("RM550x", "Corsair", 789, 550);

            bestComp.setMotherboard("B550M Phantom Gaming", "ASRock", 777, 4);

            bestComp.motherboard.setCPU("Ryzen 5 5600X", "AMD", 2399, 6, 1440);
            bestComp.motherboard.setGPU("GeForce RTX 3080", "MSI", 6390, 10);

            bestComp.motherboard.addMemory("Vengeance LP", "Corsair", 565, 1600, 16);
            bestComp.motherboard.addMemory("Vengeance LP", "Corsair", 565, 1600, 16);


            bestComp.motherboard.addStorage("860 EVO", "Samsung", 899, 550, 1000);
            bestComp.motherboard.addStorage("860 EVO", "Samsung", 899, 550, 1000);


            Console.WriteLine(bestComp.mouse.model);



        }
    }
}
