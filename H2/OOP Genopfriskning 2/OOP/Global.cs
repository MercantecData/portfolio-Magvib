using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    static class totalP
    {
        public static int price;
    }

    public class Global
    {
        public string name { get;  private set; }
        public string model { get; private set; }

        public int price { get; private set; }

        public Global(string name, string model, int price)
        {
            this.name = name;
            this.model = model;
            this.price = price;
            totalP.price = totalP.price + price;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setPrice(int price)
        {
            this.price = price;
        }

        public int totalPrice()
        {
            return totalP.price;
        }
    }
}
