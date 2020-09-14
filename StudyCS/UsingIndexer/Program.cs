using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
namespace UsingIndexer
{
    class MyList
    {
        public int[] array;

        public MyList()
        {
            array = new int[3];
        }
        
        public int this[int index] //여기서 this는 array 배열을 말함.
        {
            get
            {
                return array[index];
            }
            set
            {
                
            }
        }
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyList list = new MyList();
            list.array[0] = 1;
            list.array[1] = 2;
            list.array[2] = 3;
            list.array[3] = 4;

            foreach (var item in list.array)
            {
                Console.WriteLine(item);
                //인덱스가 배열 범위를 벗어났다고함.
                //list.array가 4개나 있음
            }
        }
    }
}
*/
namespace UsingIndexer
{
    class MyList
    {
        public int[] array;

        public MyList()
        {
            array = new int[3];
        }
        
        public int this[int index] //여기서 this는 array 배열을 말함.
        {
            get
            {
                return array[index];
            }
            set
            {
                if(index >= array.Length)
                {
                    Array.Resize<int>(ref array, index + 1); //배열의 주소값을 가져와서 사이즈를 늘림, resize뒤에 <int> 없어도 무방
                    Console.WriteLine($"Array resized : {array.Length}");
                }
                array[index] = value;
            }
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyList list = new MyList();
            for (int i = 0; i < 5; i++)
            {
                list[i] = i;
            }
            for (int i = 0; i < list.array.Length; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
