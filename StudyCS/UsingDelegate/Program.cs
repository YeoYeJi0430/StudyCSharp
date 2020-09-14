using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingDelegate
{
    delegate int MyDelegate(int a, int b);  //대리자 선언
    class Calculator
    {
        public int Plus(int a, int b)       //대리자는 인스턴스 메소드 참조 가능
        {
            return a + b;
        }
        public static int Minus(int a, int b)//정적 메소드도 참조 가능
        {
            return a - b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Calculator Calc = new Calculator();
            //Console.WriteLine(Calc.Plus(3, 4)); // 이전까지 형식
            MyDelegate Callback;
            
            Callback = new MyDelegate(Calc.Plus);
            Console.WriteLine(Callback(3, 4));

            Callback = new MyDelegate(Calculator.Minus);
            Console.WriteLine(Callback(7, 5));
        }
    }
}
