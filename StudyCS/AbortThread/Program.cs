﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AbortThread
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
                while (count > 0)
                {
                    Console.WriteLine($"{count--} left");
                    Thread.Sleep(10);
                }
                Console.WriteLine("Count : 0");
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

            Thread th = new Thread(new ThreadStart(task.KeepAlive));
            th.IsBackground = false;

            Thread.Sleep(1000);

            Console.WriteLine("Starting thread...");
            th.Start();

            Thread.Sleep(10000);

            Console.WriteLine("Aborting thread...");
            th.Abort();

            Console.WriteLine("Wating until thread stop...");
            th.Join();

            Console.WriteLine("Done..");
            
        }

    }
}
