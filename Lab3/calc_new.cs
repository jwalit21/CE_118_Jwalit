using System;
using System.Reflection;
[assembly:AssemblyVersion("1.0.0.0")]
namespace calc
{
    public class Calc_Class
    {
        public int addition(int x, int y)
        {
            Console.WriteLine("In addition");
            return x + y;
        }
        public int multiplication(int x, int y)
        {
            Console.WriteLine("In multiplication");
            return x * y;
        }
    }
}