using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace IntegralTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            sbyte a = sbyte.MaxValue;              //signed byte
            byte b = byte.MinValue;

            short c = short.MinValue;
            ushort d = ushort.MaxValue;             //unsigned

            int e = int.MinValue;
            uint f = uint.MaxValue;

            long g = long.MaxValue;
            ulong h = ulong.MaxValue;
            ulong i = 20_000_000_000;               //자릿수구분자 _
            Console.WriteLine(i);
            */
            /*
            byte a = 255;
            WriteLine($"a = {a}");
            byte b = 0b1111_0000; //2진수
            WriteLine($"b = {b}");
            byte c = 0xF0;
            WriteLine($"c = {c}");
            */
            byte d = byte.MaxValue;
            WriteLine($"d = {d}");
            d += 1;
            WriteLine($"d = {d}");

            float f = float.MaxValue;
            WriteLine($"f = {f}");
            double g = double.MaxValue;
            WriteLine($"g = {g}");
        }
    }
}
