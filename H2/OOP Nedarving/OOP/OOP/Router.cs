using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Router : Computer
    {
        public int wifiRangeInMeters { get; set; }

        public Router(string name, int storageInGb, int memorySizeInGb, int wifiRangeInMeters) : base(name, storageInGb, memorySizeInGb)
        {
            this.wifiRangeInMeters = wifiRangeInMeters;
        }
    }
}
