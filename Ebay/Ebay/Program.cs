using System;
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
        static void Main(string[] args)
        {
            Console.Title = "Mini Ebay";
            Database test = new Database();
            string cs = @"server=localhost;userid=root;password=;database=csharp";
            using var con = new MySqlConnection(cs);
            con.Open();

            using var cmd = new MySqlCommand("SELECT * FROM users", con);
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    test.AddUser(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2));
                }
            }

            using var cmd2 = new MySqlCommand("SELECT * FROM products", con);
            using (MySqlDataReader rdr2 = cmd2.ExecuteReader())
            {
                while (rdr2.Read())
                {
                    test.AddProduct(rdr2.GetInt32(0), rdr2.GetString(1), rdr2.GetInt32(2));
                }
            }

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

        public static void Login(Database test, int id)
        {
            Console.Clear();
            Console.WriteLine("Username: {0}", test.UserID(id).name);
            Console.Write("Password: ");
            var pass = Console.ReadLine();
            if (test.CheckPassword(id, pass) == true)
            {
                Menu(test, id);
            }
        }

        public static void Menu(Database test, int id)
        {
            Console.Clear();
            string s = "Welcome " + test.UserID(id).name + ", to Mini Ebay";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine("Welcome {0}, to Mini Ebay", test.UserID(id).name);
            Console.ReadLine();
        }
    }
}
