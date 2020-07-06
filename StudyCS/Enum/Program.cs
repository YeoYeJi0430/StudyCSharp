using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enum
{
    class Program
    {
        enum DialogResult
        {
            YES,        //int : 0, YES위에 마우스 올리면 뜸
            //YES = 10, //int : 10, 값을 지정하는경우는 많지않음
            NO,         //int : 1
            //NO,       //int : 11, 1씩 증가함
            CONFIRM,    //int : 2
            OK          //int : 3
        }
        static void Main(string[] args)
        {
            //Console.WriteLine(DialogResult.OK); //enum에 있는값을 문자열로 변환하여 ok를 보여줌 실제로 ok는 문자열이 아님 실제로 enum은 int값을 가지고 있음
            //Console.WriteLine((int)DialogResult.OK); //enum이 가지고 있는 int값 확인하기
            DialogResult result = DialogResult.YES;
            if(result == DialogResult.YES)
            {
                Console.WriteLine("YES를 선택했습니다.");
            }
        }
    }
}
