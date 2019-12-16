using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

// Execute Command
// new MySqlCommand("UPDATE users SET name = 'Magnus' WHERE id = 1", con).ExecuteScalar();

namespace Ebay
{
    class Program
    {
        static void Main(string[] args)
        {
            Database test = new Database();

            string cs = @"server=localhost;userid=root;password=toor;database=csharp";
            using var con = new MySqlConnection(cs);
            con.Open();

            using var cmd = new MySqlCommand("SELECT * FROM users", con);
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    test.AddUser(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2));
                }
                test.ListUsers();
            }

            using var cmd2 = new MySqlCommand("SELECT * FROM products", con);
            using (MySqlDataReader rdr2 = cmd2.ExecuteReader())
            {
                while (rdr2.Read())
                {
                    test.AddProduct(rdr2.GetInt32(0), rdr2.GetString(1), rdr2.GetInt32(2));
                }
                Console.WriteLine("");
                test.ListProducts();
            }

            Console.ReadLine();
        }
    }
}
