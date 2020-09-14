
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Base
    {
        protected string Name { get; set; }  //Name = 변수 protected string Name{ get; set; } 속성이라는것 보여짐

        public Base(string name)    //name = 멤버변수 : 소문자대문자로 구분
        {
            Name = name;
            Console.WriteLine($"{Name}.Base()");
        }

        public void BaseMethod()
        {
            Console.WriteLine($"{Name}.BaseMethod()");
        }
    }

    
    class Derived : Base// class Child : Parent
    {
        public Derived(string name) : base(name)
        {
            Console.WriteLine($"{this.Name}.Derived");
        }

        public void DerivedMethod()
        {
            Console.WriteLine($"{Name}.DerivedMethod()");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Base a = new Base("a");
            a.BaseMethod();

            Derived b = new Derived("b");
            b.BaseMethod();
            b.DerivedMethod();
        }
    }
}
