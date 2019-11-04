using System;

namespace Biblioteksobjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Biblioteks System!");

            Bibliotek Bibliotek = new Bibliotek("Viborg");

            Bibliotek.AddBog(new Bog("Test"));
            Bibliotek.AddBog(new Bog("Test2"));
            
            Bibliotek.BogCount();
            Bibliotek.BogTitle(0);
            Bibliotek.RentCheck(0);
            Bibliotek.RentBog(0, 3);
            Bibliotek.RentCheck(0);
            Bibliotek.ReturnBog(0);
            Bibliotek.RentCheck(0);
            Bibliotek.RemoveBog(0);
        }
    }
}
