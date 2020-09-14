using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingList
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < 10; i++)
            {
                int iresult = list.Add(i);//제일 마지막에 추가됨 insert와 다름
                Console.WriteLine($"{iresult}번째에 데이터 {i}추가 완료");
            }
            foreach (var item in list)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();

            
            //삭제
            list.RemoveAt(2); //인덱스 2 삭제 (0,1,2,..)
            foreach (var item in list)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();

            //추가
            list.Insert(5, 4.5);            //지정 위치에 값 추가
            foreach (var item in list)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();

            //clear
            list.Clear();                   //전체삭제
            foreach (var item in list)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();

        }
    }
}
