using System;

namespace OOP
{
    public class Computer
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
    }
}
