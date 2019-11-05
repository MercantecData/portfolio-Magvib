﻿using System;

namespace Biblioteksobjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Bibliotek Bibliotek = new Bibliotek("Viborg");

            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Biblioteks System!");
                Console.WriteLine("[9] Exit");
                Console.WriteLine("[1] Create Book");
                Console.WriteLine("[2] Check if Book is rented and list of books");
                Console.WriteLine("[3] Rent Book");
                Console.WriteLine("[4] Return Book");
                Console.WriteLine("[5] Remove Book");
                Console.Write(": ");
                int key = 101;
                bool res;
                res = int.TryParse(Console.ReadLine(), out key);
                if(res == false)
                {
                    key = 101;
                }
                switch (key)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Type in the name of the book: ");
                        string name = Console.ReadLine();
                        Bibliotek.AddBog(new Bog(name));
                        Console.WriteLine("You have now added a book named " + name);
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        if(Bibliotek.BogCount() != 0)
                        {
                            Console.WriteLine("[9] Exit");
                            for (int i = 0; i < Bibliotek.BogCount(); i++)
                            {
                                Console.WriteLine("[" + (i+1) + "] " + Bibliotek.BogTitle(i));
                            }
                            int choice = Convert.ToInt32(Console.ReadLine());
                            if (choice == 9)
                            {
                                break;
                            }
                            else
                            {
                                if(choice - 1 <= Bibliotek.BogCount() && choice - 1 >= 0)
                                {
                                    Console.WriteLine(Bibliotek.RentCheck(choice - 1));
                                    Console.ReadLine();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Out of range");
                                    Console.ReadLine();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no books in this collection");
                            Console.ReadLine();
                            break;
                        }
                    case 3:
                        Console.Clear();
                        if (Bibliotek.BogCount() != 0)
                        {
                            Console.WriteLine("[9] Exit");
                            for (int i = 0; i < Bibliotek.BogCount(); i++)
                            {
                                Console.WriteLine("[" + (i + 1) + "] " + Bibliotek.BogTitle(i));
                            }
                            int choice = Convert.ToInt32(Console.ReadLine());
                            if (choice == 9)
                            {
                                break;
                            }
                            else
                            {
                                if (choice - 1 <= Bibliotek.BogCount() && choice - 1 >= 0)
                                {
                                    Console.WriteLine("How many days do you want the book?");
                                    Console.WriteLine("Between 1 and 14 days");
                                    int days = Convert.ToInt32(Console.ReadLine());
                                    if (days > 14 && days < 0)
                                    {
                                        Console.WriteLine("Out of range");
                                        Console.ReadLine();
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine(Bibliotek.RentBog(choice - 1, days));
                                        Console.ReadLine();
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Out of range");
                                    Console.ReadLine();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no books in this collection");
                            Console.ReadLine();
                            break;
                        }
                    case 4:
                        Console.Clear();
                        if (Bibliotek.BogCount() != 0)
                        {
                            Console.WriteLine("[9] Exit");
                            for (int i = 0; i < Bibliotek.BogCount(); i++)
                            {
                                Console.WriteLine("[" + (i + 1) + "] " + Bibliotek.BogTitle(i));
                            }
                            int choice = Convert.ToInt32(Console.ReadLine());
                            if (choice == 9)
                            {
                                break;
                            }
                            else
                            {
                                if (choice - 1 <= Bibliotek.BogCount() && choice - 1 >= 0)
                                {
                                    Console.WriteLine(Bibliotek.ReturnBog(choice - 1));
                                    Console.ReadLine();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Out of range");
                                    Console.ReadLine();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no books in this collection");
                            Console.ReadLine();
                            break;
                        }
                    case 5:
                        Console.Clear();
                        if (Bibliotek.BogCount() != 0)
                        {
                            Console.WriteLine("[9] Exit");
                            for (int i = 0; i < Bibliotek.BogCount(); i++)
                            {
                                Console.WriteLine("[" + (i + 1) + "] " + Bibliotek.BogTitle(i));
                            }
                            int choice = Convert.ToInt32(Console.ReadLine());
                            if (choice == 9)
                            {
                                break;
                            }
                            else
                            {
                                if (choice - 1 <= Bibliotek.BogCount() && choice - 1 >= 0)
                                {
                                    Console.WriteLine(Bibliotek.RemoveBog(choice - 1));
                                    Console.ReadLine();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Out of range");
                                    Console.ReadLine();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no books in this collection");
                            Console.ReadLine();
                            break;
                        }
                    case 9:
                        isRunning = false;
                        break;

                    default:
                        Console.Clear();
                        break;
                }

            }


            /*
            Bibliotek.AddBog(new Bog("Test"));
            Bibliotek.AddBog(new Bog("Test2"));
            
            Bibliotek.BogCount();
            Bibliotek.BogTitle(0);
            Bibliotek.RentCheck(0);
            Bibliotek.RentBog(0, 3);
            Bibliotek.RentCheck(0);
            Bibliotek.ReturnBog(0);
            Bibliotek.RentCheck(0);
            Bibliotek.RemoveBog(0); */
        }
    }
}
