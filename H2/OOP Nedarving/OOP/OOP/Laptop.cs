using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Laptop : Computer
    {
        public int screenSize { get; set; }
        public int speakerModel { get; set; }
        public int batterySizeInMAH { get; set; }

        public Laptop(string name, int storageInGb, int memorySizeInGb, int screenSize, int speakerModel, int batterySizeInMAH) : base(name, storageInGb, memorySizeInGb)
        {
            this.screenSize = screenSize;
            this.speakerModel = speakerModel;
            this.batterySizeInMAH = batterySizeInMAH;
        }
    }
}
