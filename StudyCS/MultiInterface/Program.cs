using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiInterface
{
    class Program
    {
        interface IRunnable
        {
            void Run();
        }
        interface IFlyable
        {
            void Fly();
        }
        class Vehicle
        {
            public string Year;
            public string Company;
            public float HorsePower;
        }
        class FlyingCar : Vehicle, IRunnable, IFlyable
        {
            //인터페이스 구현하기
            public void Fly()
            {
                Console.WriteLine("Fly!");
            }
            //인터페이스 구현
            public void Run()
            {
                Console.WriteLine("Run!");
            }
        }
        static void Main(string[] args)
        {
            FlyingCar car = new FlyingCar();
            car.Run();
            car.Fly();
            car.Company = "현대";

            IRunnable runnable = car as IRunnable;      //형변환, 형변환 안되면 null값 들어감
            runnable.Run();

            IFlyable flyable = car as IFlyable;
            flyable.Fly();
        }
    }
}
