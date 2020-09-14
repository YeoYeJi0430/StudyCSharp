using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace SWCaseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            object obj = null;                              //object : 어떤 데이터이든지 다룰 수 있는 데이터 형식이다.
            string s = ReadLine();
            if (int.TryParse(s, out int a))                 //정수형으로 파싱 되면 obj에 대입
                                                            //TryParse() : 숫자의 문자열 표현을 해당하는 32비트 부호 있는 정수로 변환 합니다. 
                                                            //반환 값은 변환의 성공 여부를 나타냅니다.
                obj = a;
            else if (float.TryParse(s, out float b))
                obj = b;
            else
                obj = s;

            switch (obj)
            {
                case int i:
                    WriteLine($"{i}는 int 형식");
                    break;
                case float f when f >= 0:
                    WriteLine($"{f}는 양의 float 형식");
                    break;
                case float f:
                    WriteLine($"{f}는 음의 float 형식");
                    break;
                default:
                    WriteLine($"{s}는 모르는 형식");
                    break;
            }
        }
    }
}
