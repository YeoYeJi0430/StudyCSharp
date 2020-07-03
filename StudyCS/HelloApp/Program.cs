//using System;                                                           //namespace : 같은일들을 하기위한 클래스들의 집합체, System을 쓰겠다고 선언
using static System.Console;                                            //Console = 클래스, 클래스를 정적으로 항상 쓰겠다고 선언

namespace HelloApp
{
    class Program
    {
        // 프로그램 실행이 시작되는 곳
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                //Console.WriteLine("ex : HelloApp.exe <이름>");
                WriteLine("ex : HelloApp.exe <이름>");
                return;
            }

            //Console.WriteLine($"Hello, {args[0]}!");
            WriteLine($"Hello, {args[0]}!");                            //using static System.Console 선언하면 Console. 안써도됨.
            
        }
    }
}
