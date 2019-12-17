using System;
namespace Ebay
{
    public class Order
    {
        public int id;
        public string seller_name;
        public string product_name;
        public string buyer_name;

        public Order(int id, string seller_name, string product_name, string buyer_name)
        {
            this.id = id;
            this.seller_name = seller_name;
            this.product_name = product_name;
            this.buyer_name = buyer_name;
        }
    }
}
