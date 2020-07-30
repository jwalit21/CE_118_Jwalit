using System;
using AdditionExtraClass;

namespace Addition_Driver
{
    class AdditionMain
    {
        static void Main(string[] args)
        {
            int a, b;
            Console.WriteLine("Enter first number : ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number : ");
            b=int.Parse(Console.ReadLine());
            Addition.addition_Method(a, b);
            Console.ReadKey();
        }
    }
}
