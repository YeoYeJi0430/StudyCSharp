using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyingArray
{
    class Program
    {
        static void CopyArray<T>(T[] source, T[] target)//<T> : 일반화 쓰겠다는 키워드
        {
            for (int i = 0; i < source.Length; i++)
            {
                target[i] = source[i];
            }
        }
        static void Main(string[] args)
        {
            //Test(); 사용 하려면 *
            int[] source = { 1, 2, 3, 4, 5 };
            int[] target = new int[source.Length];

            CopyArray<int>(source, target);

            foreach (int item in target)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();

            string[] source2 = { "하나", "둘", "셋", "넷", "다섯" };
            string[] target2 = new string[source2.Length];

            CopyArray<string>(source2, target2);

            foreach (string itemm in target2)
            {
                Console.Write($"{itemm} ");
            }
            Console.WriteLine();
        }
        //priavte static void Test() <- static 써야함*
    }
}
