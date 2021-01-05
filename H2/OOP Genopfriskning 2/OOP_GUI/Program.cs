using System;
using OOP;

namespace OOP_GUI
{
    class Program
    {
        static void Main(string[] args)
        {

            Computer bestComp = new Computer("Beast Computer", "ASUS");

            // Keyboard and Mouse
            bestComp.setKeyboard(new Keyboard("K-100 CORE LED", "NOS", 500));
            bestComp.setMouse(new Mouse("Aerox 3", "SteelSeries", 799));

            // Monitor
            bestComp.addMonitor(new Monitor("24G2U", "AOC", 1289, 24, 144));
            bestComp.addMonitor(new Monitor("24G2U", "AOC", 1289, 24, 144));
            bestComp.monitor.RemoveRange(0, 1);

            // PowerSupply and MotherBoard
            bestComp.setPowerSupply(new PowerSupply("RM550x", "Corsair", 789, 550));
            bestComp.setMotherboard(new Motherboard("B550M Phantom Gaming", "ASRock", 777, 4));

            // CPU and GPU
            bestComp.motherboard.setCPU(new CPU("Ryzen 5 5600X", "AMD", 2399, 6, 1440));
            bestComp.motherboard.setGPU(new GPU("GeForce RTX 3080", "MSI", 6390, 10));

            // Memory
            bestComp.motherboard.addMemory(new Memory("Vengeance LP", "Corsair", 565, 1600, 16));
            bestComp.motherboard.addMemory(new Memory("Vengeance LP", "Corsair", 565, 1600, 16));

            // Storage
            bestComp.motherboard.addStorage(new Storage("860 EVO", "Samsung", 899, 550, 1000));
            bestComp.motherboard.addStorage(new Storage("860 EVO", "Samsung", 899, 550, 1000));


            Console.WriteLine(bestComp.mouse.model);

            Console.WriteLine(bestComp.totalPrice());

        }
    }
}
