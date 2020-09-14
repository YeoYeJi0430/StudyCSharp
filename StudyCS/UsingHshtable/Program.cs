using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingHshtable
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            ht["이름"] = "예디";
            ht["주소"] = "마산부산";
            ht["키"] = 163;
            ht["피곤"] = true;

            Console.WriteLine($"이름 : {ht["이름"]}");
            Console.WriteLine($"피곤? : {ht["피곤"]}");
        }
    }
}
