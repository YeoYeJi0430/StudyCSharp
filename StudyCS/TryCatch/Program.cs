using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3 };
            int x = 100, y = 0;
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(arr[i]);
                }
                Console.WriteLine($"{x/y}");

                string origin = "RR";
                int val = int.Parse(origin);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"예외가 발생했습니다 : {ex.Message}");
                ex.HelpLink = "https://docs.microsoft.com/ko-kr/dotnet/api/system.indexoutofrangeexception?view=netcore-3.1";
                Console.WriteLine($"도움말링크 : {ex.HelpLink}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"다른 예외 발생 : {ex.Message}");
                Console.WriteLine("0으로 된 변수 확인");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"aaa mola{ex.Message}");
            }
            Console.WriteLine("종료");
        }
    }
}
