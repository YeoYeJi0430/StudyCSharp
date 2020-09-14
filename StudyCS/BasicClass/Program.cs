using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicClass
{
    class Cat
    {
        public string Name;
        public string Color;
        //alt+enter
        /// <summary>
        /// 파라미터 생성자
        /// </summary>
        /// <param name="name">고양이 이름</param>
        /// <param name="color">고양이 색상</param>
        public Cat(string name, string color)       //생성자
        {
            Name = name;
            Color = color;
        }

        public Cat()
        {
            Name = "";
            Color = null;
        }

        public void Meow()
        {
            Console.WriteLine($"{Name} : 야옹");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Cat kitty = new Cat();          //기본생성자로 인스턴스화
            kitty.Name = "키티";
            kitty.Color = "하얀색";
            kitty.Meow();
            Console.WriteLine($"{kitty.Name} : {kitty.Color}");

            Cat nero = new Cat("네로","검은색");//파라미터생성자로 인스턴스화
            nero.Meow();
            Console.WriteLine($"{nero.Name} : {nero.Color}");
        }
    }
}
