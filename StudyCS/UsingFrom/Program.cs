using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingFrom
{
    class Profile
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }
    class Program
    {
        class Subject
        {
            public string Name { get; set; }
            public int[] Score { get; set; }
        }
        static void Main(string[] args)
        {
            #region UsingFrom
            //from db에서 선택시 썼던 키워드
            //db가 여러개로 나열되어있는 애들 from
            //int = 10;에 사용할 필요 x
            //배열-컬렉션 같은것들을 저장시 from 유용
            int[] numbers = { 9, 2, 6, 4, 5, 3, 7, 8, 1, 10 };

            //LINQ시작(데이터베이스 쿼리와 비슷)
            var result = from n in numbers
                         where n % 2 == 0
                         orderby n
                         select n;
            foreach (var item in result)
            {
                Console.WriteLine($"짝수 : {item}");
            }
            #endregion
            #region SimpleLinq 488p
            List<Profile> profiles = new List<Profile>
            {
                new Profile(){Name="예디",Height=163},
                new Profile(){Name="우성",Height=186},
                new Profile(){Name="수현",Height=185},
                new Profile(){Name="태희",Height=158}
            };
            var newprofiles = from item in profiles
                              where item.Height < 175
                              orderby item.Name
                              select new
                              {
                                  Name = item.Name,
                                  InchHeight = item.Height * 0.393
                              };
            foreach (var item in newprofiles)
            {
                Console.WriteLine($"{item.Name},{item.InchHeight}");
            }
            #endregion
            List<Subject> subjects = new List<Subject>
            {
                new Subject(){Name="연두반",Score=new int[]{99,80,70,24}},
                new Subject(){Name="분홍반",Score=new int[]{60,45,87}},
                new Subject(){Name="파랑반",Score=new int[]{92,30,85,94}},
                new Subject(){Name="노랑반",Score=new int[]{90,88,0,17}}
            };
            var newSubjects = from c in subjects
                              from s in c.Score
                              where s < 60
                              orderby s
                              select new { c.Name, Lowest = s };
            foreach (var item in newSubjects)
            {
                Console.WriteLine($"낙제 : {item.Name} ({item.Lowest})");
            }
        }
    }
}
