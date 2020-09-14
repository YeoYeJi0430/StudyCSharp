using System;
using System.IO;

namespace Interface
{
    interface ILogger
    {
        void WriteLog(string message);
    }

    class ConsoleLogger : ILogger
    {
        public void WriteLog(string message)
        {
            DateTime now = DateTime.Now;
            Console.WriteLine($"[{now.ToLocalTime()}]{message}");
        }
    }
    class FileLogger : ILogger
    {
        private StreamWriter writer;
        public FileLogger(string path)
        {
            writer = File.CreateText(path);                             //writer
            writer.AutoFlush = true;
        }

        public void WriteLog(string message)
        {
            DateTime now = DateTime.Now;
            writer.WriteLine($"[{now.ToLocalTime()}]{message}");        //파일에 write
        }
    }

    class ClimateMonitor
    {
        private ILogger logger;
        public ClimateMonitor(ILogger logger)
        {
            this.logger = logger;
        }
        public void start()
        {
            while(true)
            {
                Console.Write("온도 입력 : ");
                string temp = Console.ReadLine();
                if (temp == "q")
                    break;
                logger.WriteLog("현재 온도 : " + temp);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //ClimateMonitor monitor = new ClimateMonitor(new FileLogger("climate.log"));
            //폴더 C:\StudyCSharp\StudyCS\Interface\bin\Debug에 저장되어있음.
            ClimateMonitor monitor = new ClimateMonitor(new ConsoleLogger());
            //콘솔에 바로 결과 뜸
            monitor.start();
        }
    }
}


