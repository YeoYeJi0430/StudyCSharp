using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    abstract class AbstractBase
    {
        protected void ProtectedMethodA()
        {
            Console.WriteLine("AbstractBase.ProtectedMethodA()"); // 구현은 가능하지만 인스턴스화 안됨.
        }
        public void PublicMethodA()
        {
            Console.WriteLine("AbstractBase.PublicMethodA()");

        }

        public abstract void AbstractMethodA();
    }

    class Derived : AbstractBase
    {
        public override void AbstractMethodA()                      //override 재정의, override -> virtual, abstract 에서 쓰임
        {
            Console.WriteLine("Derived.AbstractMethodA()");
            ProtectedMethodA();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AbstractBase obj = new Derived();                       //protected ->protected void ProtectedMethodA()->Derived 통해서 접근
            obj.AbstractMethodA();
            obj.PublicMethodA();
        }
    }
}
