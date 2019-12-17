using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Ebay
{
    public class Database
    {
        List<User> users = new List<User>();
        List<Product> products = new List<Product>();
        List<Order> orders = new List<Order>();

        // Users
        public void AddUser(int id, string name, string password)
        {
            users.Add(new User(id, name, password));
        }

        public void ClearUsers()
        {
            users.Clear();
        }

        public void ListUsers()
        {
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine("{0}. {1}", users[i].id, users[i].name);
            }
        }

        public bool CheckPassword(int id, string password)
        {
            return users[id].CheckPassword(password);
        }

        public int UserCount()
        {
            return users.Count;
        }

        public User UserID(int id)
        {
            return users[id];
        }


        // Products
        public void AddProduct(int id, string name, int price)
        {
            products.Add(new Product(id, name, price));
        }

        public void ClearProducts()
        {
            products.Clear();
        }

        public void ListProducts()
        {
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine("{0}. {1} : {2} dk", products[i].id, products[i].name, products[i].price);
            }
        }

        public Product ProductID(int id)
        {
            return products[id];
        }


        // Orders
        public void AddOrder(int id, string seller_name, string product_name, string buyer_name)
        {
            orders.Add(new Order(id, seller_name, product_name, buyer_name));
        }

        public void ClearOrders()
        {
            orders.Clear();
        }

        public void ListOrders()
        {
            for (int i = 0; i < orders.Count; i++)
            {
                Console.WriteLine("{0} : {1} : {2} : {3}", orders[i].id, orders[i].seller_name, orders[i].product_name, orders[i].buyer_name);
            }
        }

        public void ListOrdersWithID(string name)
        {
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].seller_name == name)
                {
                    Console.WriteLine("{0} : {1} : {2} : {3}", orders[i].id, orders[i].seller_name, orders[i].product_name, orders[i].buyer_name);
                }
            }
        }

        public Order OrderID(int id)
        {
            return orders[id];
        }
    }
}
