using System;
namespace Ebay
{
    public class Product
    {
        public int id;
        public string name;
        public int price;

        public Product(int id, string name, int price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }
    }
}
