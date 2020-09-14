using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExMember
{
    class FriendList
    {
        private List<string> list = new List<string>();

        public void Add(string name) => list.Add(name);
        public void Remove(string name) => list.Remove(name);
        public void PrintAll()
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        public FriendList() => Console.WriteLine("FriendList()");
        

        //public int Capacity => list.Capacity; //읽기 전용

        public int Capacity
        {
            get => list.Capacity;
            set => list.Capacity = value;
        }

        //public string this[int index] => list[index]; //읽기전용
        public string this[int index]
        {
            get => list[index];
            set => list[index] = value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FriendList obj = new FriendList();
            obj.Add("aeji");
            obj.Add("beji");
            obj.Add("ceji");
            obj.PrintAll();
            Console.WriteLine("-----------");
            obj.Remove("ceji");
            obj.PrintAll();

            Console.WriteLine($"{obj.Capacity}");
            obj.Capacity = 10;
            obj[0] = "yeji";
            obj.PrintAll();
        }
    }
}
