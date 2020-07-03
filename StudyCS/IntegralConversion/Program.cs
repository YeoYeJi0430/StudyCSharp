using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace IntegralConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte a = sbyte.MaxValue;       // = 127
            WriteLine($"a = {a}");
            int b = a;                      // 책에는 형변환 있음, 작은타입의 변수를 큰타입에 넣을땐 형변환 상관없음
            WriteLine($"b = {b}");
            int x = 128;
            WriteLine($"x = {x}");
            sbyte y = (sbyte)x;                    // x를 형변환 안할시 오버플러우 발생
            WriteLine($"y = {y}");
            
            
        }
    }
}
