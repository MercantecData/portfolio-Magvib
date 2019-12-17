﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

// Execute Command
// new MySqlCommand("UPDATE users SET name = 'Magnus' WHERE id = 1", con).ExecuteScalar();
// Check Password
// Console.WriteLine(test.CheckPassword(0, "toor"));

namespace Ebay
{
    class Program
    {
        public static void CollectUsers(MySqlConnection con, Database test)
        {
            test.ClearUsers();
            using var cmd = new MySqlCommand("SELECT * FROM users", con);
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    test.AddUser(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2));
                }
            }
        }

        public static void CollectProducts(MySqlConnection con, Database test)
        {
            test.ClearProducts();
            using var cmd = new MySqlCommand("SELECT * FROM products", con);
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    test.AddProduct(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2));
                }
            }
        }

        public static void CollectOrders(MySqlConnection con, Database test)
        {
            test.ClearOrders();
            using var cmd = new MySqlCommand("SELECT id, (SELECT users.name FROM users WHERE users.id = orders.seller_id) AS seller_name, (SELECT products.name FROM products WHERE products.id = orders.product_id) AS product_name, (SELECT users.name FROM users WHERE users.id = orders.buyer_id) as buyer_name FROM orders WHERE 1", con);
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    try
                    {
                        test.AddOrder(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3));
                    }
                    catch (Exception)
                    {
                        test.AddOrder(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), "null");
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Title = "Mini Ebay";
            Database test = new Database();
            string cs = @"server=localhost;userid=root;password=toor;database=csharp";
            using var con = new MySqlConnection(cs);
            con.Open();

            CollectUsers(con, test);
            CollectProducts(con, test);
            CollectOrders(con, test);
            Users(test);
        }

        public static void Users(Database test)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            for (int id = 0; id < test.UserCount(); id++)
            {
                Console.WriteLine("{0}. {1}", test.UserID(id).id, test.UserID(id).name);
            }
            Console.Write("Choice: ");
            try
            {
                int choice = Int32.Parse(Console.ReadLine());
                choice--;
                if (choice < test.UserCount() && choice > -1)
                {
                    Login(test, choice);
                }
                else
                {
                    Users(test);
                }
            }
            catch (Exception)
            {
                Users(test);
            }
        }

        public static void Login(Database test, int id, int checker = 0)
        {
            Console.Clear();
            if (checker == 1)
            {
                Console.WriteLine("Worng Password Try Again");
            }
            Console.WriteLine("Username: {0}", test.UserID(id).name);
            Console.Write("Password: ");
            var pass = Console.ReadLine();
            if (test.CheckPassword(id, pass) == true)
            {
                Menu(test, id);
            }
            else
            {
                Login(test, id, 1);
            }
        }

        public static void Menu(Database test, int id)
        {
            Console.Clear();
            Console.WriteLine("Welcome {0}, to Mini Ebay", test.UserID(id).name);
            test.ListOrdersWithID(test.UserID(id).name);
            Console.ReadLine();
        }
    }
}
