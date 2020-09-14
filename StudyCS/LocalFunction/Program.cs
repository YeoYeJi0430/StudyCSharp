using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFunction
{
    class Program
    {
        static string ToLowerString(string input)
        {
            var arr = input.ToCharArray();
            for(int i = 0; i<arr.Length; i++)
            {
                arr[i] = ToLowerChar(i);
            }

            char ToLowerChar(int i)                     //로컬 함수 선언
            {
                if (arr[i] < 65 || arr[i] > 90)
                    return arr[i];                      //tolowerstring() 메소드의 지역변수 arr 사용
                else                                    //a~z의 ASCII 값 : 97~122
                    return (char)(arr[i] + 32);         //대문자를 소문자로 바꿔줌.
            }
            return new string(arr);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(ToLowerString("Hello!"));
            Console.WriteLine(ToLowerString("Good Morning"));
            Console.WriteLine(ToLowerString("This is C#."));
        }
    }
}
