using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingEnumerable
{
    class MyList : IEnumerable, IEnumerator
    {
        private int[] array;
        int position = -1;

        public MyList()
        {
            array = new int[3];
        }
        public int this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                if(index >= array.Length)
                {
                    Array.Resize<int>(ref array, index + 1);
                    Console.WriteLine($"Array Resized : {array.Length}");
                }
                array[index] = value;
            }
        }

        //IEnumerator멤버
        public object Current
        {
            get
            {
                return array[position];
            }
        }

        //IEnumerator멤버
        public bool MoveNext()
        {
            if(position==array.Length-1)
            {
                Reset();
                return false;
            }
            position++; // else
            return true;//(position < array.Length);
        }
        //IEnumerator멤버
        public void Reset()
        {
            position = -1;
        }
        //IEnumerable멤버
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
            {
                yield return (array[i]);
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
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
