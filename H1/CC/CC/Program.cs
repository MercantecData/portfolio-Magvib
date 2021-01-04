using System;
using System.IO;
using System.Net;
using System.Text;


namespace CC
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("CC System");
                Console.WriteLine("1. create");
                Console.WriteLine("2. list");
                Console.WriteLine("3. exit");
                Console.Write("Command: ");
                string option = Console.ReadLine();
                if (option == "create")
                {
                    Console.Write("Card number: ");
                    string cn = Console.ReadLine();
                    Console.Write("MM:YY: ");
                    string mmyy = Console.ReadLine();
                    Console.Write("CVC: ");
                    string cvc = Console.ReadLine();
                    // Send the info to my backend nodejs application
                    WebRequest request = WebRequest.Create("http://localhost:3000/credit/" + cn + "/" + mmyy + "/" + cvc);
                    WebResponse mywebresponse = request.GetResponse();
                    using (Stream dataStream = mywebresponse.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(dataStream);
                        string responseFromServer = reader.ReadToEnd();
                        string responseFromServerOptifined = responseFromServer.Replace("<br>", "\n");
                        Console.WriteLine("");
                        Console.WriteLine(responseFromServerOptifined);
                    }
                    Console.ReadLine();
                    // break;
                }
                else if (option == "list")
                {
                    WebRequest request = WebRequest.Create("http://localhost:3000/creditcards/");
                    WebResponse mywebresponse = request.GetResponse();
                    using (Stream dataStream = mywebresponse.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(dataStream);
                        string responseFromServer = reader.ReadToEnd();
                        responseFromServer = responseFromServer.Replace("[", "");
                        responseFromServer = responseFromServer.Replace("]", "");
                        responseFromServer = responseFromServer.Replace("\",", "");
                        responseFromServer = responseFromServer.Replace("\"", "\n");

                        Console.WriteLine("");
                        Console.WriteLine(responseFromServer);
                    }

                    Console.Write("No. : ");
                    string number = Console.ReadLine();
                    if (number != "")
                    {
                        WebRequest request2 = WebRequest.Create("http://localhost:3000/creditcard/" + number + "/x");
                        WebResponse mywebresponse2 = request2.GetResponse();
                        using (Stream dataStream = mywebresponse2.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(dataStream);
                            string responseFromServer = reader.ReadToEnd();
                            responseFromServer = responseFromServer.Replace("<a href=\"http://localhost:3000/\">Home</a>", "");
                            string responseFromServerOptifined = responseFromServer.Replace("<br>", "\n");
                            Console.WriteLine("");
                            Console.WriteLine(responseFromServerOptifined);
                        }
                    }
                    Console.ReadLine();


                } else if (option == "exit")
                {
                    System.Environment.Exit(1);
                }
                else
                {

                }
            }
        }
    }
}