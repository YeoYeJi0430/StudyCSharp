using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace BoxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            object a = 20;  //박싱
            int b = (int)a;         //언박싱

            WriteLine(a);
            WriteLine(b);

        }
    }
}
