using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasicThread
{
    class Program
    {
        static void DoSomething()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Dosomething : {i}");
                Thread.Sleep(1000);     //1000=1s
            }
        }

        static void Anything()
        {
            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine($"Anysomething : {i}");
                Thread.Sleep(300);     
            }
        }

        static void Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(DoSomething));       //ThreadStart(대리자),thread(생성자)
            Thread thread1 = new Thread(new ThreadStart(Anything));

            Console.WriteLine("Starting thread...");
            thread.Start();//스레드시작 DoSomething호출 <-- 대리자이기 때문
            thread1.Start();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Main : {i}");
                Thread.Sleep(500);         //DoSomething부분의 for문이랑은 따로돎
            }

            Console.WriteLine("Wating untill thread stops...");
            thread.Join();
            thread1.Join();

            Console.WriteLine("Finished");
        }
    }
}
