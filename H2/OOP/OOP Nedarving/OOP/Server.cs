using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Server : Computer
    {
        public string processor { get; set; }
        public double processorSpeed { get; set; }
        public int cores { get; set; }

        public Server(string name, int storageInGb, int memorySizeInGb, string processor, int cores, double processorSpeed) : base(name, storageInGb, memorySizeInGb)
        {
            this.processor = processor;
            this.cores = cores;
            this.processorSpeed = processorSpeed;
        }

        public override void systemCheck()
        {
            base.systemCheck();

            Console.WriteLine("Processor: " + this.processor);
            Console.WriteLine("Processor speed: " + this.processorSpeed + " Ghz");
            Console.WriteLine("Server total cores: " + this.cores);
        }

        public string getNameWithProcessor()
        {
            return this.name + " : " + this.processor;
        }
    }
}
