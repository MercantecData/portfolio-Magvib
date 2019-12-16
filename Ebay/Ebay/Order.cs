using System;
using System.Collections.Generic;
using System.Text;

namespace Ebay
{
    class Order
    {
        int id;
        int seller_id;
        int product_id;
        int buyer_id;

        public Order(int id, int seller_id, int product_id, int buyer_id)
        {
            this.id = id;
            this.seller_id = seller_id;
            this.product_id = product_id;
            this.buyer_id = buyer_id;
        }
    }
}
