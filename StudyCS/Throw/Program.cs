using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Throw
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DoSomthing(1);
                DoSomthing(2);
                DoSomthing(9);
                DoSomthing(12);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"예외 발생 : {ex.Message}");
                Console.WriteLine($"도움말링크 : {ex.HelpLink}");
                Console.WriteLine($"소스 : {ex.Source}");
            }
            finally
            {
                Console.WriteLine("무조건 실행");
            }
        }

        private static void DoSomthing(int arg)
        {
            //throw new NotImplementedException(); // 이상태로 돌리면 -> 예외 : 메서드 또는 연산이 구현되지 않았습니다.
            if (arg < 10)//arg가 10보다 크면?
                Console.WriteLine($"arg : {arg}");
            else
                throw new Exception("arg가 10보다 큽니다")
                {
                    HelpLink = "http://naver.com",
                    Source = "Throw line 34",
                    //Message : get이라서 값을 넣을 수 없음.
                };
        }
    }
}
