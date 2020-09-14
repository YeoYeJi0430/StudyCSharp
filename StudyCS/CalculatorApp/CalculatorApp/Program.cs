using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    double a = 4.5, b = 2.5;
        //    double result = Add(a, b);
        //    Console.WriteLine($"result is {result}");
        //}

        //private static double Add(double a, double b)
        //{
        //    return a + b;
        //}
        //디버깅 : 로컬창,직접실행창

        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            double a = 4.5, b = 2.5;
            double result = calc.Add(a,b);
            Console.WriteLine($"result is {result}");
            double result2 = calc.Subtract(a, b);
            Console.WriteLine($"result2 is {result2}");
            double result3 = calc.Multiple(a, b);
            Console.WriteLine($"result3 is {result3}");
            double result4 = calc.Divide(a, b);
            Console.WriteLine($"result4 is {result4}");
        }

        
    }
}
