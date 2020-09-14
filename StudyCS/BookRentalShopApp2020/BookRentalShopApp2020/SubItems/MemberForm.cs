using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRentalShopApp2020.SubItems
{
    public partial class MemberForm : MetroForm
    {
        //db실행시필요
        //private readonly string strConnectionString =
        //   "Data Source=localhost;Port=3306;Database=bookrentalshop;Uid=root;Password=mysql_p@ssw0rd";
        //Commons의 클래스 확인
        //Commons.CONNSTR

        readonly string strTblName = "membertbl";
        BaseMode mymode = BaseMode.NONE;//초기상태
        public MemberForm()
        {
            InitializeComponent();
        }

        private void DivMngForm_Load(object sender, EventArgs e)
        {
            UpdateComboLevles();
            UpdateData();//메소드만들기
        }
        
        private void UpdateComboLevles()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR)) //Commons.CONNSTR
            {
                //A,B,C,D : 콤보박스에 자료 넣는 다른 방법
                /*
                var keyValues = new Dictionary<string, string>();
                keyValues.Add("선택", "");
                keyValues.Add("A", "A");
                CboLevels.DataSource = new BindingSource(keyValues, null);
                CboLevels.DisplayMember = "Key";
                CboLevels.ValueMember = "Value";
                */

                //DB이용해서 콤보박스에 데이터 넣기
                //sql connection 안에서 sqlcommand, sqlparameter, sqldatareader 다 필요
                //mysqldataAdapter가 위에 애들의 역할 가능
                string strQuery = "SELECT DISTINCT Levels FROM membertbl ORDER BY Levels";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlDataReader reader = cmd.ExecuteReader(); //where절없어서 심플
                Dictionary<string, string> temps = new Dictionary<string, string>();
                temps.Add("선택", "");
                while (reader.Read()) // 리드가 트루일때까지 돌기
                {
                    temps.Add(reader[0].ToString(), reader[0].ToString());
                }
                CboLevels.DataSource = new BindingSource(temps, null);//콤보박스에 데이터 넣기,(dic,데이터멤버)
                CboLevels.DisplayMember = "Key";  //화면에 나오는값은 서울특별시 but 소스상에서 넘어가는 데이터는 11
                CboLevels.ValueMember = "Value";  //값
                //CboDivision.SelectedIndex = -1;

            }
        }
        
        private void UpdateData()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR)) //Commons.CONNSTR
            {
                //sql connection 안에서 sqlcommand, sqlparameter, sqldatareader 다 필요
                //mysqldataAdapter가 위에 애들의 역할 가능
                string strQuery = "SELECT Idx,  "+
                                  "   Names,    "+
                                  "   Levels,   "+
                                  "   Addr, "+
                                  "   Mobile,   "+
                                  "   Email "+   
                                  "   FROM membertbl ";
                conn.Open();
                //MySqlCommand cmd = new MySqlCommand();
                //cmd.Connection = conn;
                //cmd.CommandText = strQuery;

                MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();//데이터 넣을때, 구조체(?)
                adapter.Fill(ds, "divtbl");//ds에 테이블넣기

                //외쪽에 테이블 띄울때 필요한 key,value인듯?
                GrdDivTbl.DataSource = ds;
                GrdDivTbl.DataMember = "divtbl";
            }
            SetColumnHeaders();
        }

        private void SetColumnHeaders()
        {
            DataGridViewColumn column;//= new DataGridViewColumn
            //같은 타입에게 할당(column == GrdDivTbl)
            column = GrdDivTbl.Columns[0];
            column.Width = 100;
            column.HeaderText = "번호";

            column = GrdDivTbl.Columns[1];
            column.Width = 150;
            column.HeaderText = "이름";

            column = GrdDivTbl.Columns[2];
            column.Width = 150;
            column.HeaderText = "등급";

            column = GrdDivTbl.Columns[3];
            column.Width = 150;
            column.HeaderText = "주소";

            column = GrdDivTbl.Columns[4];
            column.Width = 150;
            column.HeaderText = "전화번호";

            column = GrdDivTbl.Columns[5];
            column.Width = 150;
            column.HeaderText = "이메일";

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if(mymode != BaseMode.UPDATE)
            {
                MetroMessageBox.Show(this, "삭제할 데이터를 선택하세요.", "알림");
                return;
            }
            mymode = BaseMode.DELETE;
            SaveData();
            InitControls();
        }

        private void InitControls()
        {
            TxtIdx.Text = TxtNames.Text = string.Empty;
            TxtAddr.Text = TxtEmail.Text = TxtMobile.Text = string.Empty;
            CboLevels.SelectedIndex = 0;
            TxtIdx.Focus();

            mymode = BaseMode.NONE;
        }

        #region 삭제처리 제거
        /*
        private void DeleteProcess()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
                {
                    conn.Open();//커넥션오픈,using쓰면 자동으로 conn.close();해줌
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "DELETE FROM divtbl " +
                                      " WHERE Division = @Division ";

                    MySqlParameter paramDivision = new MySqlParameter("@Division", MySqlDbType.VarChar);
                    paramDivision.Value = TxtDivision.Text;
                    cmd.Parameters.Add(paramDivision);

                    var result = cmd.ExecuteNonQuery();

                    MetroMessageBox.Show(this, $"{result}건이 삭제되었습니다.", "삭제");
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"에러발생{ex.Message}", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            finally
            {

            }
        }
        */
        #endregion
        private void BtnNew_Click(object sender, EventArgs e)
        {
            /*
            TxtIdx.Text = TxtNames.Text = string.Empty;    //모두 빈칸
            TxtIdx.ReadOnly = false;                       //리드온리 켜뒀던걸 꺼주기, 데이터 입력해야하기때문
            */
            InitControls();
            mymode = BaseMode.INSERT;//신규입력모드

            TxtNames.Focus();
        }
        /// <summary>
        /// DB 업데이트 및 입력 처리
        /// </summary>
        private void SaveData()
        {
            //update
            //빈값이면 실행x
            if (string.IsNullOrEmpty(TxtNames.Text)||
                CboLevels.SelectedIndex<1||
                string.IsNullOrEmpty(TxtAddr.Text) ||
                string.IsNullOrEmpty(TxtMobile.Text) ||
                string.IsNullOrEmpty(TxtEmail.Text)
                )
            {
                MetroMessageBox.Show(this, "빈값은 넣을 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
                {
                    conn.Open();//커넥션오픈,using쓰면 자동으로 conn.close();해줌
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    if(mymode == BaseMode.UPDATE)
                    {
                        cmd.CommandText = "UPDATE membertbl "+
                                          " SET Names = @Names,"+
                                          "     Levels = @Levels,"+
                                          "     Addr = @Addr,"+
                                          "     Mobile = @Mobile,"+
                                          "     Email = @Email"+
                                          "     WHERE Idx = @Idx";//update문
                    }

                    else if(mymode == BaseMode.INSERT)
                    {
                        cmd.CommandText = @"INSERT INTO membertbl
                                            (
                                            Names,
                                            Levels,
                                            Addr,
                                            Mobile,
                                            Email)
                                            VALUES
                                            (
                                            @Names,
                                            @Levels,
                                            @Addr,
                                            @Mobile,
                                            @Email)";//insert문
                    }
                    

                    MySqlParameter paramNames = new MySqlParameter("@Names", MySqlDbType.VarChar, 45)
                    {
                        Value = TxtNames.Text
                    };
                    cmd.Parameters.Add(paramNames);

                    MySqlParameter paramLevels = new MySqlParameter("@Levels", MySqlDbType.VarChar, 1)
                    {
                        Value = CboLevels.SelectedValue
                    };
                    cmd.Parameters.Add(paramLevels);

                    MySqlParameter paramAddr = new MySqlParameter("@Addr", MySqlDbType.VarChar, 100)
                    {
                        Value = TxtAddr.Text
                    };
                    cmd.Parameters.Add(paramAddr);

                    MySqlParameter paramMobile = new MySqlParameter("@Mobile", MySqlDbType.VarChar, 13)
                    {
                        Value = TxtMobile.Text
                    };
                    cmd.Parameters.Add(paramMobile);

                    MySqlParameter paramEmail = new MySqlParameter("@Email", MySqlDbType.VarChar, 50)
                    {
                        Value = TxtEmail.Text
                    };
                    cmd.Parameters.Add(paramEmail);

                    if(mymode == BaseMode.UPDATE)
                    {
                        MySqlParameter paramIdx = new MySqlParameter("@Idx", MySqlDbType.Int32)
                        {
                            Value = TxtIdx.Text
                        };
                        cmd.Parameters.Add(paramIdx);
                    }

                    var result = cmd.ExecuteNonQuery();//제대로 insert,update 되면 1이 넘어옴

                    if(mymode == BaseMode.INSERT)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 신규입력되었습니다.", "신규입력");
                    }
                    else if (mymode == BaseMode.UPDATE)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 수정되었습니다.", "수정");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"에러발생{ex.Message}", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UpdateData();
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            InitControls();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            InitControls();
        }

        private void GrdDivTbl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //a b c
            //d e f
            //a클릭시 b랑c도 가져옴
            if(e.RowIndex > -1)//데이터는 0이상
            {
                DataGridViewRow data = GrdDivTbl.Rows[e.RowIndex];
                TxtIdx.Text = data.Cells[0].Value.ToString();//cells = column, txt개체는 string이라서 value를 tostring으로
                TxtNames.Text = data.Cells[1].Value.ToString();
                TxtAddr.Text = data.Cells[3].Value.ToString();
                TxtMobile.Text = data.Cells[4].Value.ToString();
                TxtEmail.Text = data.Cells[5].Value.ToString();

                //CboLevels.SelectedIndex = CboLevels.FindString(data.Cells[2].Value.ToString());
                CboLevels.SelectedValue = data.Cells[2].Value;


                //왼쪽테이블은 pk이기때문에 리드온리 해두기!
                TxtIdx.ReadOnly = true;

                mymode = BaseMode.UPDATE;   //수정모드변경
            }
        }
    }
}
