using System;
using System.Collections.Generic;
using System.Reflection;
using RoleManagment;

namespace Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            //User u = new User("Magvib");
            //Mail m = new Mail();

            while (true)
            {
                start();
            }

            void start(string msg = "")
            {
                Console.Clear();

                if (msg != "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(msg);
                }

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("1. Login");
                Console.WriteLine("2. Sign up");
                
                var option = Console.ReadKey();

                if (option.Key == ConsoleKey.D1)
                {
                    login();
                }

                if (option.Key == ConsoleKey.D2)
                {
                    signup();
                }
            }

            void login()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                
                Console.Write("Login: ");
                var username = Console.ReadLine();
                User u = new User(username);

                if(u.id == 0)
                {
                    start("No user by that name");
                }

                Console.Write("Password: ");
                var password = Console.ReadLine();

                if(u.checkPassword(password))
                {
                    home(u);
                } else
                {
                    start("Worng password");
                }
            }

            void signup(string msg = "")
            {
                Console.Clear();

                if (msg != "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(msg);
                }

                Console.ForegroundColor = ConsoleColor.Green;

                Console.Write("Username: ");
                var username = Console.ReadLine();
                // Check is another user allready owns this username

                User u = new User();

                u.username = username;

                Console.Write("Password: ");
                var password = Console.ReadLine();
                u.encryptPassword(password, true);

                try
                {
                    u.save();
                } catch (Exception)
                {
                    start("Username allready taken");
                }
            }

            void home(User u, string msg = "")
            {
                Console.Clear();

                if (msg != "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(msg);
                }

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("Welcome " + u.role.prefix + " " + u.username);

                Console.WriteLine("");
                Console.WriteLine("1. Change password");
                Console.WriteLine("2. Delete account");
                Console.WriteLine("3. Send mail (coming soon)");
                Console.WriteLine("5. Logout");

                if (u.role.role == "Admin")
                {
                    Console.WriteLine("9. Admin");
                }

                var option = Console.ReadKey();

                if (option.Key == ConsoleKey.D1)
                {
                    changePassword(u);
                }

                if (option.Key == ConsoleKey.D2)
                {
                    deleteAccount(u);
                }

                if (option.Key == ConsoleKey.D9 && u.role.role == "Admin")
                {
                    admin(u);
                }
            }

            void changePassword(User u)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Hello " + u.username);

                Console.Write("Old password: ");
                var oldPassword = Console.ReadLine();

                Console.Write("New password: ");
                var newPassword = Console.ReadLine();

                Console.Write("New password confirm: ");
                var newPasswordConfirm = Console.ReadLine();



                if (u.password == u.encryptPassword(oldPassword) && newPassword == newPasswordConfirm)
                {
                    u.encryptPassword(newPassword, true);
                    try
                    {
                        u.save();
                    } catch (Exception)
                    {
                        home(u, "Failed to change password");
                    }
                }

                home(u);
            }

            void deleteAccount(User u)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Hello " + u.username);

                Console.Write("Password: ");
                var password = Console.ReadLine();

                if (u.password == u.encryptPassword(password))
                {
                    try
                    {
                        u.delete();
                        start();
                    }
                    catch (Exception)
                    {
                        home(u, "Failed to delete account");
                    }
                }

                home(u);
            }

            void admin(User u)
            {
                if(u.role.role != "Admin")
                {
                    home(u);
                }

                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("Welcome " + u.role.prefix + " " + u.username + " To Admin Panel");

                Console.WriteLine("");
                Console.WriteLine("1. Delete user");
                Console.WriteLine("2. Change user role");
                Console.WriteLine("3. Clear user mail");
                Console.WriteLine("4. Back");

                var option = Console.ReadKey();

                if (option.Key == ConsoleKey.D4)
                {
                    home(u);
                }
            }
        }
    }
}
