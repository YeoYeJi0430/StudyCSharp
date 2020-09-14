using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InterruptThread
{
    class SideTask
    {
        int count = 0;

        public SideTask(int count)
        {
            this.count = count;
        }

        public void KeepAlive()
        {
            try
            {
                Console.WriteLine($"Running Thread isn't gonna be interrupted");
                //Thread.SpinWait(1_000_000_000);

                while (count > 0)
                {
                    Console.WriteLine($"{count--} left");
                    Console.WriteLine("Entering into WaitJoinSleep State...");
                    Thread.Sleep(10);
                }
                Console.WriteLine("Count : 0");
            }
            catch(ThreadInterruptedException e)
            {
                Console.WriteLine(e);
            }
            catch (ThreadAbortException ex)
            {
                Console.WriteLine(ex.Message);
                Thread.ResetAbort();
            }
            finally
            {
                Console.WriteLine("Clearing resource...");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SideTask task = new SideTask(500);
            Thread t1 = new Thread(new ThreadStart(task.KeepAlive));
            t1.IsBackground = false;
            Console.WriteLine("Starting thread...");
            t1.Start();

            Thread.Sleep(100);

            //Console.WriteLine("Interrupting thread...");
            //t1.Interrupt();
            t1.Suspend();

            Console.WriteLine("Wating");
            Thread.Sleep(3000);

            t1.Resume();
            t1.Join();

            Console.WriteLine("Finished");
        }
    }
}
