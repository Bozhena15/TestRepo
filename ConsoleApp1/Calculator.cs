using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public delegate T CalcDelegate<T>(T x, T y);
    internal class Calculator : TestDiv
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public static double Sub(double x, double y)
        {
            return x - y;
        }

        public int Add(int x, int y)
        {
            return x + y;
        }

        public static int Sub(int x, int y)
        {
            return x - y;
        }

        public static double Mult(double x, double y)
        {
            return x * y;
        }

        public override double Div(double x, double y)
        {
            return x / y;
        }
    }
}
