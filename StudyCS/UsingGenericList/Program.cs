using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingGenericList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> intlist = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                intlist.Add(i);
            }

            foreach (var item in intlist)
            {
                Console.WriteLine($"{item} ");
            }
            Console.WriteLine();

            intlist.RemoveAt(2);

            foreach (var item in intlist)
            {
                Console.WriteLine($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
