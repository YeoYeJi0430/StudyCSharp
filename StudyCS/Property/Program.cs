using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace Property
{
    //옛날 방식의 get set
    class BirthdayInfo
    {
        private string name;
        private DateTime birthday;

        public void SetName(string name) //private 접근
        {
            this.name = name;
        }

        public void SetBirthday(DateTime birth)
        {
            this.birthday = birth;
        }

        public string GetName()
        {
            return this.name;
        }

        public DateTime GetBirthday() //문자열로 받고싶을땐 string으로 바꾸면댐
        {
            return this.birthday;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            BirthdayInfo info = new BirthdayInfo();
            info.SetName("yj");//set
            info.SetBirthday(new DateTime(1996, 04, 30));//set

            Console.WriteLine(info.GetName());
            Console.WriteLine(info.GetBirthday());
            Console.WriteLine($"이름 : {info.GetName()}, 출생 : {info.GetBirthday()}");
        }
    }
}
*/
namespace Property
{
    class BirthdayInfo
    {
        private DateTime birthday;
        /*
        private string name;    //얘를 간단화 시키면
                                //public string Name  
                                //{ get; set; }
                                //이렇게 가능함
        public string Name  //위엔 소문자 여긴 대문자로 구분
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        */
        public string Name                              
        { get; set; } = "Unknown";                      //초기값
        //public DateTime Birthday { get; set; } = new DateTime(0000, 00, 00);
        public DateTime Birthday                        //위엔 소문자 여긴 대문자로 구분
        {
            get
            {
                return birthday;
            }
            set
            {
                if (value.Year >= DateTime.Now.Year)     //value가 2021이 들어오면~ (불가능)
                {
                    birthday = DateTime.Now;             //birthday를 지금 날짜로 바꿈
                }
                else
                {
                    birthday = value;                     //set부분 지우면 값을 줄 수 없음.
                }
            }
        }

        public int Age
        {
            get
            {
                return new DateTime(DateTime.Now.Subtract(birthday).Ticks).Year;    //set 필요 없음
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            BirthdayInfo info = new BirthdayInfo();
            Console.WriteLine($"알수없는이름 : {info.Name}");
            info.Name = "yj";
            //info.SetName("yj");//set
            info.Birthday = new DateTime(1996, 04, 30);
            //info.SetBirthday(new DateTime(1996, 04, 30));//set

            
            //Console.WriteLine(info.GetName());
            //Console.WriteLine(info.GetBirthday());
            //Console.WriteLine($"이름 : {info.GetName()}, 출생 : {info.GetBirthday()}");
            Console.WriteLine($"이름 : {info.Name}, 출생 : {info.Birthday}, 나이 : {info.Age}");

            //318p 무명형식
            var myInstance = new { Name = "yj", Home = "busan" };
            Console.WriteLine($"{myInstance.Name},{myInstance.Home}");
            //myInstance.Name = "yyj"; 불가능함
            var b = new { Subject = "su", Scores = new int[] { 90, 80, 70, 60 } };
            Console.Write($"Subject : {b.Subject}, Scores : ");
            foreach (var score in b.Scores)
            {
                Console.Write($"{score} ");
            }
            Console.WriteLine();
        }
    }
}
