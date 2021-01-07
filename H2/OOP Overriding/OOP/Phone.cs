using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Phone : Computer
    {
        public int screenSize { get; set; }
        public int batterySizeInMAH { get; set; }
        public int batteryLevel { get; set; }

        public Phone(string name, int storageInGb, int memorySizeInGb, int screenSize, int batterySizeInMAH, int batteryLevel) : base(name, storageInGb, memorySizeInGb)
        {
            this.screenSize = screenSize;
            this.batterySizeInMAH = batterySizeInMAH;
            this.batteryLevel = batteryLevel;
        }

        public override void systemCheck()
        {
            base.systemCheck();

            Console.WriteLine("Battery level: " + this.batteryLevel);
        }

        public int getBatteryLevel()
        {
            return this.batteryLevel;
        }
    }
}
