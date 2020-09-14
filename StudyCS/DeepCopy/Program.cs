using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepCopy
{
    class MyClass
    {
        public int MyField1;
        public int MyField2;
        public MyClass DeepCopy()
        {
            MyClass newCopy = new MyClass
            {
                MyField1 = MyField1,
                MyField2 = MyField2//인스턴스만들기
            }; // 메서드, 책보다 더 간단. alt+enter, this 옛날방식

            return newCopy;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shallow Coppy");
            {
                MyClass source = new MyClass
                {
                    MyField1 = 10,
                    MyField2 = 20
                };// 책보다 편

                MyClass target = source;    //얕은 복사 : 소스복사
                target.MyField2 = 300;
                Console.WriteLine($"{source.MyField1} : {source.MyField2}");
                Console.WriteLine($"{target.MyField1} : {target.MyField2}");


            }
            Console.WriteLine("Deep Copy");
            {
                MyClass source = new MyClass
                {
                    MyField1 = 10,
                    MyField2 = 20
                };// 책ㄱ보다 편
                MyClass target = source.DeepCopy();    //깊은 복사 : 소스복사
                target.MyField2 = 300;
                Console.WriteLine($"{source.MyField1} : {source.MyField2}");
                Console.WriteLine($"{target.MyField1} : {target.MyField2}");
            }
        }
    }
}
