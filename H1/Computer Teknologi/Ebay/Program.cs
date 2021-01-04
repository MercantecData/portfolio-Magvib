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

        public static void DatabaseConnection(MySqlConnection con, Database test)
        {
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Mini Ebay!"));
                Console.WriteLine("Can't connect to the database");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) Change database info");
                Console.WriteLine("2) Exit");
                Console.Write("\r\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Mini Ebay!"));

                        Console.Write("Server: ");
                        var server = Console.ReadLine();
                        Console.Write("UserID: ");
                        var userid = Console.ReadLine();
                        Console.Write("password: ");
                        var password = Console.ReadLine();
                        Console.Write("Database(the name of the database to create): ");
                        var database = Console.ReadLine();

                        string cs = @"server=" + server + ";userid=" + userid + ";password=" + password + "";
                        con = new MySqlConnection(cs);

                        using (var cmd = con.CreateCommand())
                        {
                            con.Open();
                            cmd.CommandText = ("CREATE DATABASE IF NOT EXISTS `" + database + "`");
                            cmd.ExecuteNonQuery();
                        }
                        con.Close();
                        cs = @"server=" + server + ";userid=" + userid + ";password=" + password + ";database="+database;
                        con = null;
                        con = new MySqlConnection(cs);
                        con.Open();
                        new MySqlCommand("CREATE TABLE IF NOT EXISTS `users` (`id` int(11) NOT NULL AUTO_INCREMENT, `name` varchar(255) NOT NULL, `password` varchar(255) NOT NULL, PRIMARY KEY (`id`));", con).ExecuteScalar();
                        new MySqlCommand("CREATE TABLE IF NOT EXISTS `products` (`id` int(11) NOT NULL AUTO_INCREMENT,`name` varchar(255) NOT NULL,`price` varchar(255) NOT NULL,PRIMARY KEY (`id`));", con).ExecuteScalar();
                        new MySqlCommand("CREATE TABLE IF NOT EXISTS `orders` (`id` int(11) NOT NULL AUTO_INCREMENT,`seller_id` int(11) NOT NULL,`product_id` int(11) NOT NULL,`buyer_id` int(11) DEFAULT NULL,PRIMARY KEY (`id`),KEY `seller_id` (`seller_id`),KEY `product_id` (`product_id`),KEY `buyer_id` (`buyer_id`),CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`seller_id`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE RESTRICT,CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`) ON DELETE CASCADE ON UPDATE RESTRICT,CONSTRAINT `orders_ibfk_3` FOREIGN KEY (`buyer_id`) REFERENCES `users` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT);", con).ExecuteScalar();

                        CollectUsers(con, test);
                        CollectProducts(con, test);
                        CollectOrders(con, test);
                        Start(con, test);

                        break;
                    case "2":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }

            }
        }

        static void Main(string[] args)
        {
            Console.Title = "Mini Ebay";
            string cs = @"server=localhost;userid=root;password=toor;database=csharp";
            MySqlConnection con = new MySqlConnection(cs);
            Database test = new Database();
            DatabaseConnection(con, test);

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
            if (test.UserCount() == 0)
            {
                allow = true;
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
                            Console.Clear();
                            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Mini Ebay!"));
                            test.ListAvailableOrders();
                            Console.Write("\r\nSelect a product to buy: ");
                            int bproduct = Convert.ToInt32(Console.ReadLine());
                            if (bproduct < test.OrderCount() || bproduct >= 0)
                            {
                                new MySqlCommand("UPDATE orders SET buyer_id = '" + test.UserID(id).id + "' WHERE id = " + test.OrderID(bproduct).id + "", con).ExecuteScalar();
                            }
                            CollectOrders(con, test);
                            CollectProducts(con, test);
                        }
                        catch (Exception)
                        {
                            break;
                        }
                        break;
                    case "2":
                        try
                        {
                            Console.Clear();
                            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Mini Ebay!"));
                            Console.Write("\r\nName of product to sell: ");
                            var product = Console.ReadLine();
                            Console.Write("Price: ");
                            int price = Convert.ToInt32(Console.ReadLine());
                            new MySqlCommand("INSERT INTO products(name, price) VALUES ('"+product+"',"+price+")", con).ExecuteScalar();
                            new MySqlCommand("INSERT INTO orders(seller_id, product_id) VALUES (" + test.UserID(id).id + ", LAST_INSERT_ID())", con).ExecuteScalar();
                            CollectOrders(con, test);
                            CollectProducts(con, test);
                        }
                        catch (Exception)
                        {
                            break;
                        }
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Mini Ebay!"));

                        try
                        {
                            test.SellOrdersWithID(test.UserID(id).id);
                            Console.Write("\r\nSelect a product to delete: ");
                            int dproduct = Convert.ToInt32(Console.ReadLine());
                            if (dproduct < test.OrderCount() || dproduct >= 0)
                            {
                                new MySqlCommand("DELETE FROM products WHERE id = "+test.OrderID(dproduct).product_id+"", con).ExecuteScalar();
                            }
                            CollectOrders(con, test);
                            CollectProducts(con, test);

                        }
                        catch (Exception)
                        {
                            break;
                        }
                        break;
                    case "4":
                        try
                        {
                            Console.Clear();
                            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Mini Ebay!"));
                            test.ListOrdersWithID(test.UserID(id).id);
                            Console.Write("\r\nPress Enter to return...");
                            Console.ReadLine();
                        }
                        catch (Exception)
                        {
                            break;
                        }
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
