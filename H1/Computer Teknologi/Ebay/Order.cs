using System;
namespace Ebay
{
    public class Order
    {
        public int id;
        public int seller_id;
        public int product_id;
        public int buyer_id;
        public string seller_name;
        public string product_name;
        public string buyer_name;

        public Order(int id, int seller_id, int product_id, int buyer_id, string seller_name, string product_name, string buyer_name)
        {
            this.id = id;
            this.seller_id = seller_id;
            this.product_id = product_id;
            this.buyer_id = buyer_id;
            this.seller_name = seller_name;
            this.product_name = product_name;
            this.buyer_name = buyer_name;
        }
    }
}
