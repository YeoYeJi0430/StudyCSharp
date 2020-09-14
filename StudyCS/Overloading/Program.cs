using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloading
{
    class Program
    {
        static int Plus(int a, int b)
        {
            return a + b;
        }
        static int Plus(int a, int b, int c)
        {
            return a + b + c;
        }
        /// <summary>
        /// double형 두 수를 더함.
        /// </summary>
        /// <param name="a">double a</param>
        /// <param name="b">double b</param>
        /// <returns></returns>
        static double Plus(double a, double b)
        {
            return a + b;
        }
        
        static double Plus(int a, double b)
        {
            return a + b;
        }
        static float Plus(float a, float b)
        {
            return a + b;
        }
        static float Plus(int a, float b)
        {
            return a + b;
        }

        static int Sum(params int[] args)
        {
            int result = 0;
            foreach (var item in args)
            {
                result += item;
            }
            return result;
        }

        static void MyMethod(string arg1 = "", string arg2 = "")
        {
            Console.WriteLine("MyMethod A");
        }

        static void MyMethod()
        {
            Console.WriteLine("MyMethod B");
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Plus(3.14f, 5.02f));
            Console.WriteLine(Plus(3.14, 5.02));            //xml주석 확인
            int sum = Sum(3, 4, 5, 6, 7, 8, 9, 10);
            Console.WriteLine($"sum = {sum}");              //배열로 받을 수 있음 params int[] args
            MyMethod();
            MyMethod("are", "you");                         //오버로딩 알림 잘 확인하고 사용
            MyMethod();
        }
    }
}
