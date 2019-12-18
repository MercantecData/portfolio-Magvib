using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

// Execute Command
// new MySqlCommand("UPDATE users SET name = 'Magnus' WHERE id = 1", con).ExecuteScalar();

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
            using var cmd = new MySqlCommand("SELECT id, seller_id, product_id, buyer_id, (SELECT users.name FROM users WHERE users.id = orders.seller_id) AS seller_name, (SELECT products.name FROM products WHERE products.id = orders.product_id) AS product_name, (SELECT users.name FROM users WHERE users.id = orders.buyer_id) as buyer_name FROM orders WHERE 1", con);
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    try
                    {
                        test.AddOrder(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2), rdr.GetInt32(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6));
                    }
                    catch (Exception)
                    {
                        test.AddOrder(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2), 0, rdr.GetString(4), rdr.GetString(5), "null");
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
            Start(con, test);
        }

        public static void Start(MySqlConnection con, Database test)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Mini Ebay!"));
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) Create User");
                Console.WriteLine("2) Login");
                Console.WriteLine("3) Exit");
                Console.Write("\r\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        CreateUser(con, test);
                        break;
                    case "2":
                        Users(con, test);
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }

        public static void CreateUser(MySqlConnection con, Database test, int checker = 0)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Mini Ebay!"));
            bool allow = false;
            if (checker == 1)
            {
                Console.WriteLine("Username already taken");
                Console.ReadLine();
                Start(con, test);
            }
            else if (checker == 2)
            {
                Console.WriteLine("Password doesn't match");
                Console.ReadLine();
                Start(con, test);
            }
            Console.Write("Username: ");
            var user = Console.ReadLine();
            Console.Write("Password: ");
            var pass = Console.ReadLine();
            Console.Write("Confirm Password: ");
            var confirmpass = Console.ReadLine();
            for (int i = 0; i < test.UserCount(); i++)
            {
                if (user == test.UserID(i).name)
                {
                    CreateUser(con, test, 1);
                }
                else if (pass != confirmpass)
                {
                    CreateUser(con, test, 2);
                }
                else
                {
                    allow = true;
                    
                }
            }
            if (allow == true)
            {
                new MySqlCommand("INSERT INTO users (name, password) VALUES ('" + user + "', '" + pass + "');", con).ExecuteScalar();
                CollectUsers(con, test);
                Console.Clear();
                Console.WriteLine("User Created");
                Console.ReadLine();
                Start(con, test);
            }

        }

        public static void Users(MySqlConnection con, Database test)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Mini Ebay!"));
            Console.WriteLine("Choose a user:");
            test.ListUsers();
            Console.WriteLine("x) Main Menu");
            Console.Write("\r\nSelect a user: ");

            try
            {
                var choiceX = Console.ReadLine();
                if (choiceX == "x")
                {
                    Start(con, test);
                }
                int choice = Int32.Parse(choiceX);
                choice--;
                if (choice < test.UserCount() && choice >= -1)
                {
                    Login(con, test, choice);
                }
                else
                {
                    Users(con, test);
                }
            }
            catch (Exception)
            {
                Users(con, test);
            }
        }

        public static void Login(MySqlConnection con, Database test, int id, int checker = 0)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Mini Ebay!"));
            if (checker == 1)
            {
                Console.WriteLine("Worng Password Try Again");
            }
            Console.WriteLine("Username: {0}", test.UserID(id).name);
            Console.Write("Password: ");
            var pass = Console.ReadLine();
            if (test.CheckPassword(id, pass) == true)
            {
                Menu(con, test, id);
            }
            else
            {
                Login(con, test, id, 1);
            }
        }

        public static void Menu(MySqlConnection con, Database test, int id)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Mini Ebay!"));
                // Console.WriteLine("Welcome {0}, to Mini Ebay", test.UserID(id).name);
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) Buy product");
                Console.WriteLine("2) Sell product");
                Console.WriteLine("3) Delete product");
                Console.WriteLine("4) Bought products");
                Console.WriteLine("5) Exit");
                Console.Write("\r\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        try
                        {
                            test.ListAvailableOrders();
                            Console.Write("\r\nSelect a product to buy: ");
                            int bproduct = Convert.ToInt32(Console.ReadLine());
                            if (bproduct < test.OrderCount() || bproduct >= 0)
                            {
                                new MySqlCommand("UPDATE orders SET buyer_id = '" + test.UserID(id).id + "' WHERE id = " + test.OrderID(bproduct).id + "", con).ExecuteScalar();
                            }
                            CollectOrders(con, test);
                        }
                        catch (Exception)
                        {
                            break;
                        }
                        break;
                    case "2":
                        break;
                    case "3":
                        test.ListOrdersWithID(test.UserID(id).id);
                        Console.ReadLine();
                        break;
                    case "4":
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
