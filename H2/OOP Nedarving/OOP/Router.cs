using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Router : Computer
    {
        public bool wifiOnline { get; set; }
        public int wifiRangeInMeters { get; set; }

        public Router(string name, int storageInGb, int memorySizeInGb, int wifiRangeInMeters) : base(name, storageInGb, memorySizeInGb)
        {
            this.wifiRangeInMeters = wifiRangeInMeters;
            this.wifiOnline = true;
        }

        public override void systemCheck()
        {
            base.systemCheck();

            if(this.wifiOnline)
            {
                Console.WriteLine("Wifi is online");
            } else
            {
                Console.WriteLine("Wifi is not online");
            }
        }

        public string isOnline()
        {
            if(this.wifiOnline)
            {
                return "Wifi is online";
            } else
            {
                return "Wifi is not online";
            } 
        }
    }
}
