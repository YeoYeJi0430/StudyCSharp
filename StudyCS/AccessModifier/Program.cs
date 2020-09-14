using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifier
{
    class WaterHeater
    {
        protected int temp;

        public void SetTemp(int temp)
        {
            if(temp < -5 || temp > 42)  
            {
                throw new Exception("Out of temp range"); //예외처리
            }

            this.temp = temp;                               //temp필드는 protected로 수식 되었으므로 외부에서 직접 접근 x
                                                            //이렇게 public메소드를 통해 접근해야함
        }
        
        internal void TurnOnWater()
        {
            Console.WriteLine($"Turn on water : {temp}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WaterHeater heater = new WaterHeater();
                heater.SetTemp(20);
                heater.TurnOnWater();
                //class WaterHeater에서  protected int temp를 public int temp으로 바꾸면 main문에서 사용가능
                heater.SetTemp(-2);
                heater.TurnOnWater();

                heater.SetTemp(50);                         //42행에서 예외발생 -> 45행의 catch 블록으로 실행위치 이동
                heater.TurnOnWater();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
        }
    }
}
