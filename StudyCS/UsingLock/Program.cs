using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UsingLock
{
    class Counter
    {
        const int LOOP_COUNT = 1000;

        readonly object thisLock;
        public int Count { get; set; }   

        public Counter()
        {
            thisLock = new object();
            Count = 0;
        }

        public void Increas()
        {
            int loopcount = LOOP_COUNT;
            while (loopcount-- > 0)
            {
                lock (thisLock)
                {
                    Count++;
                    Console.WriteLine(Count);
                }
                Thread.Sleep(1);
            }
        }

        public void Decreas()
        {
            int loopcount = LOOP_COUNT;
            while (loopcount-- > 0)
            {
                lock (thisLock)
                {
                    Count--;
                    Console.WriteLine(Count);
                }
                Thread.Sleep(1);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter();

            //스레드 두개 실행. 뭐가 먼저일지 알수 없지만 상관없음
            Thread inThread = new Thread(new ThreadStart(counter.Increas)); // 호출
            Thread deThread = new Thread(new ThreadStart(counter.Decreas));

            inThread.Start();
            deThread.Start();

            inThread.Join();
            inThread.Join();

            Console.WriteLine(counter.Count);
        }
    }
}
