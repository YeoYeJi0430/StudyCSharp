using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateChains
{
    delegate void Notify(string message);   //대리자선언

    class Notifier                          //Notify대리자의 인스턴스
                                            //EventOccured를 가지는 클래스 
                                            //Notifier선언
    {
        public Notify Event0ccured;
    }

    class EventListener
    {
        private string name;
        public EventListener(string name)
        {
            this.name = name;
        }
        public void SomethingHappend(string message)
        {
            Console.WriteLine($"{name}.SomethingHappened : {message}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Notifier notifier = new Notifier();
            EventListener listener1 = new EventListener("Listener1");
            EventListener listener2 = new EventListener("Listener2");

            //대리자체인 대리자연결
            notifier.Event0ccured += listener1.SomethingHappend;//대리자(notifier.Event0ccured)에게 값 넘겨주는 문장, +=는 약속임.
            notifier.Event0ccured += listener2.SomethingHappend;
            notifier.Event0ccured("You've got mail.");          //메시지

            Console.WriteLine();

            notifier.Event0ccured -= listener2.SomethingHappend;//-=연산자 이용해서 체인 끊기
            notifier.Event0ccured("Download complete.");

            Console.WriteLine();

        }
    }
}
