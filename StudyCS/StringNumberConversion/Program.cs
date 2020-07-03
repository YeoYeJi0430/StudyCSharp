using System;
//.NET(CORE) 코어와 프레임워크 차이~?(참조,종속성)
namespace StringNumberConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 12345;
            string b = a.ToString();                    //b는 문자열
            Console.WriteLine(b);

            float c = 3.141592f;
            string d = c.ToString();                    //c를 문자열로 바꿔서 d로 ㄱㄱ
            Console.WriteLine(d);

            //정상작동
            /*string e = "123456";
            int f = Convert.ToInt32(e);
            Console.WriteLine($"f = {f}");

            string g = "3.141592";
            float h = float.Parse(g);
            Console.WriteLine($"h = {h}");*/

            
            //error
            string e = "123456";
            int f ;

            /*
            bool result = int.TryParse(e, out f);       //(바꾸고자하는값, 변수), 숫자형은 tryparse 가능
            Console.WriteLine($"result = {result}");    //출력 = true/false
            Console.WriteLine($"f = {f}");              //f에 0들어감 왜냐하면 e에 특수문자 들어가서 error 뜨기때문에
                                                        //e의 값이 맞으면 f에 값 들어가서 result가 True 나오고 f에 값 들어감
            */

            if(int.TryParse(e, out f))                  //tryparse의 값이 true가 아니면 f에 값 들어가지않음
            {
                Console.WriteLine($"성공! f = {f}");     //f의 값 출력
            }

            string g = "3:141592";
            float h;
            if(float.TryParse(g, out h))
            {
                Console.WriteLine($"h = {h}");
            }
            else
            {
                Console.WriteLine("g변환시 에러발생, 문자열 확인 요망");  //g에 콜론 들어가 있어서 h에 값 안들어감. 따라서 else 실행
            }

            /*
             TryParse()와 Parse()의 차이
             변환이 실패하는 경우 어떻게 다루는가?
             Parse()메소드는 변환이 실패하면 현재의 코드의 실행을 멈추고 흐름을 다른 곳으로 이동
             TryParse()메소드느 변환의 성공 여부를 반환하기 때문에 현재의 코드 흐름을 유지할 수 있음
             */

            //const int z = 10;
            //z = 21; // error : const 값 변경 x
        }
    }
}
