﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Mouse
    {
        public string name { get; private set; }
        public string model { get; private set; }
        public int price { get; private set; }
        public Mouse(string name, string model, int price)
        {
            this.name = name;
            this.model = model;
            this.price = price;
        }
    }
}
