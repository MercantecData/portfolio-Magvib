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
            //Mail m = new Mail(7);

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
                Console.WriteLine("3. Inbox ("+u.mailbox.inbox+")");
                Console.WriteLine("4. Send mail (" + u.mailbox.sent + ")");
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

                if (option.Key == ConsoleKey.D3)
                {
                    inbox(u);
                }

                if (option.Key == ConsoleKey.D4)
                {
                    sendMail(u);
                }

                if (option.Key == ConsoleKey.D9 && u.role.role == "Admin")
                {
                    admin(u);
                }
            }

            void sendMail(User u, string msg = "")
            {
                Console.Clear();

                if (msg != "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(msg);
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Hello " + u.username);

                Console.WriteLine("Select user to sent a mail to.");
                var users = User.getAllUsers();
                var count = 0;

                Console.WriteLine("x. Back");

                foreach (User us in users)
                {
                    Console.WriteLine(count + ". " + us.username);
                    count++;
                }

                Console.WriteLine("");
                Console.Write("Option: ");
                var option = Console.ReadLine();

                if(option == "x")
                {
                    home(u);
                }

                try
                {
                    User sendTo = users[Int32.Parse(option)];

                    Console.Write("Title: ");
                    var title = Console.ReadLine();

                    Console.Write("Message: ");
                    var message = Console.ReadLine();

                    Mail m = new Mail();
                    m.inbox_from = u.mailbox.id;
                    m.inbox_to = sendTo.mailbox.id;
                    m.title = title;
                    m.message = message;
                    m.seen = false;

                    m.save();
                    new MailBox(m.inbox_to).save();
                    u.mailbox.updateMails();
                    u.mailbox.save();

                    home(u, "Mail sent");
                } catch
                {
                    sendMail(u, "Can't find the specified user");
                }
            }

            void inbox(User u, string msg = "")
            {
                Console.Clear();

                if (msg != "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(msg);
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Hello " + u.username);

                Console.WriteLine("Inbox.");

                u.mailbox.updateMails();

                Console.WriteLine("x. Back");

                int count = 0;
                foreach (Mail m in u.mailbox.x_allMails)
                {
                    if(m.inbox_to == u.mailbox.id)
                    {
                        Console.WriteLine(count + ". " + m.title + (m.seen ? " (seen)" : ""));
                    }
                    count++;
                }

                Console.Write("Option: ");
                var option = Console.ReadLine();

                if (option == "x")
                {
                    home(u);
                }

                try
                {
                    Mail m = u.mailbox.x_allMails[Int32.Parse(option)];

                    m.seen = true;
                    m.save();
                    u.mailbox.save();

                    Console.WriteLine("Title: " + m.title);
                    Console.WriteLine("Message: " + m.message);
                    Console.WriteLine("From: " + m.from().username);

                    Console.ReadLine();
                    home(u);
                } catch
                {
                    home(u);
                }
            }

            void changePassword(User u)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Change password for " + u.username);

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
                Console.WriteLine("Delete " + u.username);

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
