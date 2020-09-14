using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstraintsOnTypeParameters
{
    class StructArray<T> where T : struct           //struct 값 형식을 쓰겠다 , 값형식 : 값을 바로 대입, 참조형식 : 참조하여 대입
    {                                               //struct말고 class는 참조형식임 
        public T[] Array { get; set; }
        public StructArray(int size)
        {
            Array = new T[size];                    //배열을 T타입으로 만듦
        }
    }

    class RefArray<T> where T : class                //class는 참조형식
    {
        public T[] Array { get; set; }
        public RefArray(int size)
        {
            Array = new T[size];                    //배열을 T타입으로 만듦
        }
    }

    class Base
    {

    }
    class Derived : Base
    {

    }

    class BaseArray<U> where U:Base                 //U는 Base클래스만 쓸 수 있음
    {
        public U[] Array { get; set; }

        public BaseArray(int size)
        {
            Array = new U[size];
        }

        public void CopyArray<T>(T[] source) where T : U
        {
            source.CopyTo(Array, 0);
        }
    }


    class Program
    {
        public static T CreatedInstance<T>() where T : new()
        {
            return new T();
        }
        static void Main(string[] args)
        {
            StructArray<int> a = new StructArray<int>(3);       //int 배열 3사이즈로 만듦
            a.Array[0] = 0;

            //StructArray<string> b = new StructArray<string>(3);//string은 참조형식

            //RefArray(skip)

            //BaseArray
            BaseArray<Base> b = new BaseArray<Base>(3);
            b.Array[0] = new Base();
            b.Array[1] = new Derived();
            b.Array[2] = CreatedInstance<Base>();
            //b.Array[2] = CreatedInstance<Derived>(); 이것도 가능

            BaseArray<Derived> d = new BaseArray<Derived>(3);
        }
    }
}
