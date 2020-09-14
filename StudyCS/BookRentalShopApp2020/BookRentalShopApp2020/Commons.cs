using System.Security.Cryptography;
using System.Text;

namespace BookRentalShopApp2020
{
    public enum BaseMode
    {
        //mode에 따라 update와 insert 사용
        NONE,   //기본상태
        INSERT, //입력상태
        UPDATE, //수정상태
        DELETE,
        SELECT
    }
    public class Commons
    {
        public static string USERID = string.Empty;
        //공통 DB 연결 문자열 
        public static readonly string CONNSTR =
            "DataSource=localhost;Port=3306;Database=bookrentalshop;Uid=root;Password=mysql_p@ssw0rd";

        //암호화
        /// <summary>
        /// MD5 암호화 메서드
        /// </summary>
        /// <param name="md5Hash">해시키값</param>
        /// <param name="input">평문 문자열</param>
        /// <returns>암호화된 문자열</returns>
        public static string GetMd4Hash(MD5 md5Hash, string input)//MD5(클래스)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));//string을 byte로 형변환
            StringBuilder sbuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sbuilder.Append(data[i].ToString("x2")); // x2 : 16진수
            }
            return sbuilder.ToString();
        }

    }

    


}
