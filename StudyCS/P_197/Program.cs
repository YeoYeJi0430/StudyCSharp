using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_197
{
    class Product
    {
        private int price = 100;

        public ref int GetPrice()
        {
            return ref price;
        }

        public void PrintPrice()
        {
            Console.WriteLine($"Price : {price}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Product yj = new Product();
            //ref
            ref int ref_price = ref yj.GetPrice();
            Console.WriteLine($"ref_price : {ref_price}");
            //nomal
            int nomal_price = yj.GetPrice();
            Console.WriteLine($"nomal_price : {nomal_price}");

            ref_price = 200;
            Console.WriteLine($"change : ref_price : {ref_price}");
            Console.WriteLine($"change : nomal_price : {nomal_price}");


        }
    }
}
