using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nullable
{
    class Program
    {
        static void Main(string[] args)
        {
            //Nullable 형식은 "비어 있는 상태가 될 수 있는"형식
            //데이터형식? 변수이름;
            //위 처럼 선언하면 선언한 변수는 모두 null 초기화
            //Nullable형식은 HasValue와 Value 두 가지 속성을 가지고 있음.
            //HasValue = 해당 변수가 값을 갖고 있는지 또는 그렇지 않은지
            //Value = 변수에 담겨 있는 값

            int? a = null;
            double? b = null;
            float? c = null;
            string s = null;

            Console.WriteLine(a.HasValue);                      //hasvalue 값이 있는지 확인
            Console.WriteLine(b==null);
            Console.WriteLine(string.IsNullOrEmpty(s));         // s가 널값인지 확인
            Console.WriteLine(string.IsNullOrWhiteSpace(s));
            //Console.WriteLine(a.Value);                       //error <- 처리를 위해 아래의 if문 사용
            if (a.HasValue)
            {
                Console.WriteLine(a.Value);
            }

            c = 3.141592F;
            if(c.HasValue)
            {
                Console.WriteLine($"c = {c}");
            }

        }
    }
}
