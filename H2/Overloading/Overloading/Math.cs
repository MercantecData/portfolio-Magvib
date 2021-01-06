using System;

namespace Overloading
{
    public class M
    {
        // Plus
        public int Plus(int x, int y)
        {
            return x + y;
        }
        public double Plus(double x, double y)
        {
            return x + y;
        }
        public double Plus(double x, int y)
        {
            return x + y;
        }
        public double Plus(int x, double y)
        {
            return x + y;
        }
        public double Plus(string x, string y)
        {
            return Int32.Parse(x) + Int32.Parse(y);
        }

        // Minus
        public int Minus(int x, int y)
        {
            return x - y;
        }
        public double Minus(double x, double y)
        {
            return x - y;
        }
        public double Minus(double x, int y)
        {
            return x - y;
        }
        public double Minus(int x, double y)
        {
            return x - y;
        }
        public double Minus(string x, string y)
        {
            return Int32.Parse(x) - Int32.Parse(y);
        }

        // Gange
        public int Gange(int x, int y)
        {
            return x * y;
        }
        public double Gange(double x, double y)
        {
            return x * y;
        }
        public double Gange(double x, int y)
        {
            return x * y;
        }
        public double Gange(int x, double y)
        {
            return x * y;
        }
        public double Gange(string x, string y)
        {
            return Int32.Parse(x) * Int32.Parse(y);
        }

        // Dividere
        public int Dividere(int x, int y)
        {
            return x / y;
        }
        public double Dividere(double x, double y)
        {
            return x / y;
        }
        public double Dividere(double x, int y)
        {
            return x / y;
        }
        public double Dividere(int x, double y)
        {
            return x / y;
        }
        public double Dividere(string x, string y)
        {
            return Int32.Parse(x) / Int32.Parse(y);
        }

        // Kvadratrod
        public int Kvadratrod(int x)
        {
            return (int)Math.Sqrt(x);
        }

        public double Kvadratrod(double x)
        {
            return (double)Math.Sqrt(x);
        }
        public double Kvadratrod(string x)
        {
            return Int32.Parse(x);
        }

        // Potens
        public int Potens(int x, int y)
        {
            return (int)Math.Pow(x, y);
        }

        public double Potens(double x, double y)
        {
            return (double)Math.Pow(x, y);
        }

        public double Potens(int x, double y)
        {
            return (double)Math.Pow(x, y);
        }

        public double Potens(double x, int y)
        {
            return (double)Math.Pow(x, y);
        }

        public double Potens(string x, string y)
        {
            return (double)Math.Pow(Int32.Parse(x), Int32.Parse(y));
        }
    }
}
