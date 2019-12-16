using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Ebay
{
    public class Database
    {
        List<User> users = new List<User>();
        List<Product> products = new List<Product>();


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
    }
}
