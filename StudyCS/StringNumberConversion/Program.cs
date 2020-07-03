using System;
//.NET(CORE)
namespace StringNumberConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 12345;
            string b = a.ToString();    //b는 문자열
            Console.WriteLine(b);

            float c = 3.141592f;
            string d = c.ToString();    //c를 문자열로 바꿔서 d로 ㄱㄱ
            Console.WriteLine(d);

            //정상작동
            /*string e = "123456";
            int f = Convert.ToInt32(e);
            Console.WriteLine($"f = {f}");

            string g = "3.141592";
            float h = float.Parse(g);
            Console.WriteLine($"h = {h}");*/

            
            //error
            string e = "123456*";
            //int f = Convert.ToInt32(e);
            int f ;
            /*
            bool result = int.TryParse(e, out f);       //(바꾸고자하는값, 변수), 숫자형은 tryparse 가능
            Console.WriteLine($"result = {result}");
            Console.WriteLine($"f = {f}");              //f에 0들어감 왜냐하면 e에 특수문자 들어가서 error 뜨기때문에
                                                        //e의값이 옳아서 f에 값 들어가면 result가 True 나오면서 f에 값 들어감
            */
            if(int.TryParse(e, out f))
            {
                Console.WriteLine($"f = {f}");
            }

            string g = "3:141592";
            float h;
            if(float.TryParse(g, out h))
            {
                Console.WriteLine($"h = {h}");
            }
            else
            {
                Console.WriteLine("g변환시 에러발생, 문자열 확인 요망");
            }

            //const int z = 10;
            //z = 21; // error : const 값 변경 x
        }
    }
}
