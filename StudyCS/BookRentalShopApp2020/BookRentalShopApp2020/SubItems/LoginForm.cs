using System;
using System.Security.Cryptography;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;

namespace BookRentalShopApp2020.SubItems
{
    public partial class LoginForm : MetroForm
    {
        //읽기전용. 데이터 한번만 넣고 값 안바뀌기때문
        //private readonly string strConnectionString =
        //    "Data Source=localhost;Port=3306;Database=bookrentalshop;Uid=root;Password=mysql_p@ssw0rd";
        //Commons에 static했음
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            LoginProcess();
        }

        private void LoginProcess()
        {
            //빈값비교처리
            if(string.IsNullOrEmpty(TxtUserID.Text)||string.IsNullOrEmpty(TxtUserPwd.Text))//아래와 같은 역할. 빈칸인지 확인
                                                                                           //string.IsNullOrWhiteSpace() : 띄어쓰기도 확인
            {
                MetroMessageBox.Show(this, "아이디나 패스워드를 입력하세요!", "로그인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtUserID.Focus();
                return;
            }
            /*
            if(TxtUserID.Text == "" || TxtUserID.Text== null|| 
                TxtUserPwd.Text =="" || TxtUserPwd.Text == null)
            {
                MetroMessageBox.Show(this,"아이디나 패스워드를 입력하세요!", "로그인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            */

            //실제 db처리
            string resultID = string.Empty; // ""
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
                {
                    conn.Open();
                    //MetroMessageBox.Show(this, "DB접속성공!!");
                    MySqlCommand cmd = new MySqlCommand();//mysql에 명령날릴때 쓰는 개체
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT userID FROM userTBL " +     //쿼리문
                                      " WHERE userID = @userID " +
                                      "   AND password = @password ";
                    //userTBLWHERE <- 띄어쓰기! 여러줄 쓸 때 띄우고 줄 맞추기

                    MySqlParameter paramUserid = new MySqlParameter("@userID",MySqlDbType.VarChar,12);//class
                    paramUserid.Value = TxtUserID.Text.Trim();//띄어쓰기 때문에 사용
                    MySqlParameter paramPassword = new MySqlParameter("@password", MySqlDbType.VarChar);
                    
                    //암호화
                    var md5Hash = MD5.Create();
                    var cryptoPassword = Commons.GetMd4Hash(md5Hash, TxtUserPwd.Text.Trim());
                    paramPassword.Value = cryptoPassword;
                    //paramPassword.Value = TxtUserPwd.Text.Trim(); // 값을 txt로 대입
                    //디버그해서 cryptoPassword 값 확인 후 mysql에 passoword에 값 넣기

                    cmd.Parameters.Add(paramUserid);
                    cmd.Parameters.Add(paramPassword);

                    MySqlDataReader reader = cmd.ExecuteReader();   //데이터 날려서 userID가져옴.값이있는지 확인후가져오기
                    reader.Read();
                    if(!reader.HasRows)//(reader.HasRows != true)
                    {
                        MetroMessageBox.Show(this, "아이디나 패스워드를 정확히 입력하세요", "로그인실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TxtUserID.Text = TxtUserPwd.Text = string.Empty;//틀렸을때 모두 빈칸으로 만들고
                        TxtUserID.Focus();//아이디칸으로 포커스이동
                        return;
                    }
                    else
                    {
                        resultID = reader["userID"] != null ? reader["userID"].ToString() : string.Empty;
                        Commons.USERID = resultID; // 20200720 12:31 추가
                        MetroMessageBox.Show(this, $"{resultID}로그인성공");
                    }
                   
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"DB접속에러{ex.Message}", "로그인에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //resultID에 값이 있으면 로그인 성공
            if(string.IsNullOrEmpty(resultID))
            {
                MetroMessageBox.Show(this, "아이디나 패스워드를 정확히 입력하세요", "로그인실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtUserID.Text = TxtUserPwd.Text = string.Empty;//틀렸을때 모두 빈칸으로 만들고
                TxtUserID.Focus();//아이디칸으로 포커스이동
                return;
            }
            else//로그인실패시 꺼짐
            {
                this.Close();
            }
                    
            
        }

        private void BtnCancle_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);    //(0) : 에러없이 끝남
        }

        private void TxtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                TxtUserPwd.Focus();
            }
        }

        private void TxtUserPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                BtnOk_Click(sender, new EventArgs());
            }
        }
    }
}
