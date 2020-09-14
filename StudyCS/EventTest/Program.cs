using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTest
{
    delegate void EventHandler(string message);

    class MyNotifier
    {
        public event EventHandler SomethingHappened;
        public void DoSomething(int number)
        {
            int temp = number % 10;                                 //3,6,9는 ㄱㅊ 12가아닌 13에서 "짝"을 해야하니까 

            if(temp != 0 && temp % 3 == 0)                          //temp가 0이 아니고, temp를 3으로 나눴을때 나머지가 0이면
            {
                //SomethingHappened(String.Format($"{number} : 짝"));
                SomethingHappened($"{number} : 짝");
            }
        }
    }
    class Program
    {
        static public void MyHandler(string message)
        {
            Console.WriteLine(message);
        }
        static void Main(string[] args)
        {
            MyNotifier notifier = new MyNotifier();
            notifier.SomethingHappened += new EventHandler(MyHandler);  //SomethingHappened : 이벤트
                                                                        //이벤트가 일어났을때 내가 만든 메소드(MyNotifier)를 연결해서 작동

            for (int i = 1; i < 30; i++)
            {
                notifier.DoSomething(i);
            }
        }
    }
}
