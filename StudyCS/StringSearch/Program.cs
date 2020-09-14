using System;
using System.Globalization;
using static System.Console;


namespace StringSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string g = "Good Morning, Good";
            Console.WriteLine(g);
            /*
            Console.WriteLine($"IndexOf 'Good' : {g.IndexOf("Good")}");              //IndexOf("문자열에 없는 단어 들어가면 -1")
            Console.WriteLine($"LastIndexOf 'Good' : {g.LastIndexOf("Good")}");      //마지막에 들어간 단어의 첫글자 위치를 알려줌

            Console.WriteLine($"IndexOf 'n' : {g.IndexOf('n')}");                    //처음나온 글자 하나 찾기도 가능
            Console.WriteLine($"LastIndexOf 'n' : {g.LastIndexOf('n')}");            //마지막에 나온 글자 하나 찾기

            //StartsWith
            Console.WriteLine($"StartsWith 'Good' : {g.StartsWith("Good")}");       //문장이 Good으로 시작하는가? True
            Console.WriteLine($"StartsWith 'Morning' : {g.StartsWith("Morning")}");

            //Contains
            Console.WriteLine($"Contains 'Good' : {g.Contains("Good")}");           //문장에 Good이 있는가? True

            //Replace
            Console.WriteLine($"Replace 'Morning' to 'Evening' : " +
                $"{g.Replace("Morning", "Evening")}");
            if(g.Contains("Morning"))
            {
                g.Replace("Morning", "Evening");
            }

            Console.WriteLine($"ToLower : {g.ToLower()}");                          //전체 소문자
            Console.WriteLine($"ToUpper : {g.ToUpper()}");                          //전체 대문자

            WriteLine($"Insert : {g.Insert(g.IndexOf("Morning") - 1, " Very")}");   //-1을 하는 이유 : 앞의 빈값에 대입하겠다

            WriteLine($"Remove : '{"I don't Love You".Remove(2, 6)}'");
            WriteLine($"Trim : '{" No Space ".Trim()}'");
            WriteLine($"Trim : '{" No Space ".TrimStart()}'");
            WriteLine($"Trim : '{" No Space ".TrimEnd()}'");
            */
            /*
            string codes = "MSFT,GOOG,AMZN,AAPL, RHT";                              //,로 구분
            var result = codes.Split(',');                                          //result는 string배열이 만들어짐 codes에 분할된 애들이 배열로 들어감
            foreach (var item in result)
            {
                WriteLine($"each item {item.Trim()}");                              //.Trim() : RHT 앞에 있는 띄어쓰기 제거
            }
            WriteLine($"substring : {g.Substring(0, 4)}");                          //0에서 4까지
            WriteLine($"substring : {g.Substring(5)}");                             //5부터 끝까지

            WriteLine(string.Format("{0}DEF", "ABC"));
            WriteLine(string.Format("{0,-10}DEF", "ABC"));
            WriteLine(string.Format("{0,10}DEF", "ABC"));
            */
            DateTime dt = DateTime.Now;                                             //현재시각
            WriteLine(string.Format("{0:yyyy-MM-dd HH:mm:ss}", dt));
            WriteLine(string.Format("{0:y yy yyy yyyy}", dt));
            WriteLine(string.Format("{0:M MM MMM MMMM}", dt));
            WriteLine(string.Format("{0:d dd ddd dddd}", dt));
            WriteLine(string.Format("{0:d/M/yyy HH:mm:ss}", dt));
            WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss", new CultureInfo("ko-KR")));
            WriteLine(dt.ToString("d/M/yyy HH:mm:ss", new CultureInfo("en-US")));
            
            decimal mval = 27000000m;
            WriteLine(string.Format("price {0:C}", mval)); //{0:C} <- 천단위마다 점 찍고 앞에 원화기호표시
            WriteLine(string.Format($"price {mval:C}"));
            WriteLine(mval.ToString("C"));
            WriteLine(mval.ToString("C", new CultureInfo("en-US")));
            WriteLine(mval.ToString("C", new CultureInfo("fr-FR")));
            WriteLine(mval.ToString("C", new CultureInfo("ja-JP")));


        }
    }
}
