using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingYield
{
    class MyEnumerator
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        public IEnumerator GetEnumerator()
        {
            yield return numbers[0];
            yield return numbers[1];
            yield return numbers[2];
            yield break;
            yield return numbers[3];
            yield return numbers[4];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new MyEnumerator();
            foreach (var item in obj) // obj는 일반 클래스 <- 원래 클래스는 foreach에 쓸수없음, foreach는 컬렉션이나 배열만 가능
                                      // 컬렉션이 아닌것을 컬렉션으로 쓸수있는것이 IEnumerable
            {
                Console.WriteLine(item);
            }
        }
    }
}
