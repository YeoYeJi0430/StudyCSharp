using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region func예제 464p
            /*
            try
            {
                Func<int> func1 = () => { return 10; }; // == 10;
                Console.WriteLine(func1());//입력된 매개변수 없음

                Func<int, int> func2 = (x) => { return x * 2; };    // == x*2;
                Console.WriteLine(func2(4));

                Func<double, double, int> func3 = (x, y) => { return (int)(x / y); };
                Console.WriteLine(func3(22, 7));
            }
            catch (Exception)
            {
                Console.WriteLine("ERR");
            }
            */
            #endregion
            Action act1 = () => { Console.WriteLine("Action1()"); };
            act1();

            int result = 0;
            Action<int> act2 = (x) => { result = x * x; };
            act2(3);
            Console.WriteLine($"result : {result}");

            Action<double, double> act3 = (x, y) =>
            {
                double pi = x / y;
                Console.WriteLine($"Action<T1,T2>({x},{y}) : {pi}");
            };
            act3(22.0, 7.0);
        }
    }
}
