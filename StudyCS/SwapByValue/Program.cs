using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapByValue
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 3;
            int y = 4;

            Console.WriteLine($"x:{x}, y:{y}");
            Swap(ref x, ref y);                                 //ref : a는 x의 주소, b는 y의 주소
            Console.WriteLine($"x:{x}, y:{y}");
        }

        private static void Swap(ref int a, ref int b)          //ref 안쓰면 값 바뀌지 않음.
        {
            int temp = b;
            b = a;
            a = temp;
        }
    }
}
