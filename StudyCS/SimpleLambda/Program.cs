using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLambda
{
    class Program
    {
        /*이 방법 귀찮
        delegate int Calculate(int a, int b);

        static int Plus(int a, int b)
        {
            return a + b;
        }
        static void Main(string[] args)
        {
            Calculate calc = new Calculate(Plus);
            Console.WriteLine(calc(3, 4));
        }
        */
        /*
        delegate int Calculate(int a, int b);
        static void Main(string[] args)
        {
            Calculate calc = (a, b) => a + b;
            Console.WriteLine(calc(3, 4));
        }
        */
        //461p
        delegate string Concatenate(string[] args); // args랑 main문에 arr이랑 같음
        

        static void Main(string[] args)
        {
            #region 불필요한 부분 주석처리
            
            Concatenate concat = (arr) =>
                {
                    string result = string.Empty;   // == "";
                    foreach (string s in arr)
                        result += $"{s}";
                    return result;
                };
            
            #endregion
            Console.WriteLine(concat(args));
            //속성에서 디버그에 명령줄인수에 문장 입력후 확인
        }
    }
}
