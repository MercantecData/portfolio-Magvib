using System;

namespace OOP
{
    public abstract class Computer
    {
        public string name { get; set; }
        public int storageInGb { get; set; }
        public int memorySizeInGb { get; set; }

        public Computer(string name, int storageInGb, int memorySizeInGb)
        {
            this.name = name;
            this.storageInGb = storageInGb;
            this.memorySizeInGb = memorySizeInGb;
        }

        public virtual void systemCheck()
        {
            Console.WriteLine("--------");
            Console.WriteLine(this.name + ": is online");
            Console.WriteLine("System is up to date.");
        }

        public abstract string GetDescription();
    }
}
