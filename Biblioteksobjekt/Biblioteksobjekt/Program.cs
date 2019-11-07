﻿using System;

namespace Biblioteksobjekt
{
    class Program
    {
        static void Main(string[] args)
        {

            Bibliotek Bibliotek = new Bibliotek("Viborg");
            Bibliotek.AddKunde(new Kunder("Magnus"));

            void List()
            {
                Console.WriteLine("[9] Exit");
                for (int i = 0; i < Bibliotek.BogCount(); i++)
                {
                    Console.WriteLine("[" + (i + 1) + "] " + Bibliotek.BogTitle(i));
                }
            }
            void Range()
            {
                Console.WriteLine("Out of range");
                Console.ReadLine();
            }
            void Empty()
            {
                Console.WriteLine("There is no books in this collection");
                Console.ReadLine();
            }
            

            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(Bibliotek.name + "s " + "Biblioteks System!");
                Console.WriteLine("[9] Exit");
                Console.WriteLine("[1] Create Book");
                Console.WriteLine("[2] Check if Book is rented and list of books");
                Console.WriteLine("[3] Rent Book");
                Console.WriteLine("[4] Return Book");
                Console.WriteLine("[5] Remove Book");
                Console.WriteLine("[6] Rename Book");
                Console.WriteLine("[7] Kunder List");
                Console.Write(": ");
                int key;
                bool res = int.TryParse(Console.ReadLine(), out key);
                if (res == false)
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
                            List();
                            int choice;
                            bool res2 = int.TryParse(Console.ReadLine(), out choice);
                            if(res2 == false)
                            {
                                choice = 101;
                                break;
                            }
                            if (choice == 9)
                            {
                                break;
                            }
                            else
                            {
                                if(choice - 1 < Bibliotek.BogCount() && choice - 1 >= 0)
                                {
                                    Console.WriteLine(Bibliotek.RentCheck(choice - 1));
                                    Console.ReadLine();
                                    break;
                                }
                                else
                                {
                                    Range();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Empty();
                            break;
                        }
                    case 3:
                        Console.Clear();
                        if (Bibliotek.BogCount() != 0)
                        {
                            List();
                            int choice;
                            bool res3 = int.TryParse(Console.ReadLine(), out choice);
                            if (res3 == false)
                            {
                                choice = 101;
                                break;
                            }
                            if (choice == 9)
                            {
                                break;
                            }
                            else
                            {
                                if (choice - 1 < Bibliotek.BogCount() && choice - 1 >= 0)
                                {
                                    Console.WriteLine("How many days do you want the book?");
                                    Console.WriteLine("Between 1 and 14 days");
                                    int days;
                                    bool res4 = int.TryParse(Console.ReadLine(), out days);
                                    if (res4 == false)
                                    {
                                        Range();
                                        break;
                                    }
                                    if (days > 14 && days < 0)
                                    {
                                        Range();
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine(Bibliotek.RentBog(choice - 1, days, 0));
                                        Console.ReadLine();
                                        break;
                                    }
                                }
                                else
                                {
                                    Range();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Empty();
                            break;
                        }
                    case 4:
                        Console.Clear();
                        if (Bibliotek.BogCount() != 0)
                        {
                            List();
                            int choice;
                            bool res2 = int.TryParse(Console.ReadLine(), out choice);
                            if (res2 == false)
                            {
                                choice = 101;
                                break;
                            }
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
                                    Range();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Empty();
                            break;
                        }
                    case 5:
                        Console.Clear();
                        if (Bibliotek.BogCount() != 0)
                        {
                            List();
                            int choice;
                            bool res5 = int.TryParse(Console.ReadLine(), out choice);
                            if (res5 == false)
                            {
                                choice = 101;
                                break;
                            }
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
                                    Range();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Empty();
                            break;
                        }
                    case 6:
                        Console.Clear();
                        if (Bibliotek.BogCount() != 0)
                        {
                            List();
                            int choice;
                            bool res2 = int.TryParse(Console.ReadLine(), out choice);
                            if (res2 == false)
                            {
                                choice = 101;
                                break;
                            }
                            if (choice == 9)
                            {
                                break;
                            }
                            else
                            {
                                if (choice - 1 < Bibliotek.BogCount() && choice - 1 >= 0)
                                {
                                    Console.Write("Rename: ");
                                    string rename = Console.ReadLine();
                                    Console.WriteLine(Bibliotek.BogEdit(choice - 1, rename));
                                    Console.ReadLine();
                                    break;
                                }
                                else
                                {
                                    Range();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Empty();
                            break;
                        }
                    case 7:
                        Console.Clear();
                        if(Bibliotek.Kunder.Count != 0)
                        {
                            Console.WriteLine("[9] Exit");
                            for (int i = 0; i < Bibliotek.Kunder.Count; i++)
                            {
                                Console.WriteLine("[" + (i + 1) + "] " + Bibliotek.Kunder[i].name);
                            }
                            int choice;
                            bool res2 = int.TryParse(Console.ReadLine(), out choice);
                            if (res2 == false)
                            {
                                choice = 101;
                                break;
                            }
                            if (choice == 9)
                            {
                                break;
                            }
                            else
                            {
                                if (choice - 1 < Bibliotek.Kunder.Count && choice - 1 >= 0)
                                {
                                    Console.WriteLine("All rented books from " + Bibliotek.Kunder[choice - 1].name);
                                    for (int i = 0; i < Bibliotek.Kunder[choice - 1].BogCount(); i++)
                                    {
                                        Console.WriteLine("[" + (i + 1) + "] " + Bibliotek.Kunder[choice - 1].BogTitle(i) + " rented in " + Bibliotek.Kunder[choice - 1].Bog[i].dueDate + " days");
                                    }
                                    Console.ReadLine();
                                    break;
                                }
                                else
                                {
                                    Range();
                                    break;
                                }
                            }

                        }
                        else
                        {
                            Empty();
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
        }
    }
}
