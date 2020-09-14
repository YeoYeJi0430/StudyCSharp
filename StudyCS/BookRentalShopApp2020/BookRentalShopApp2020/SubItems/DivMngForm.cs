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
    public partial class DivMngForm : MetroForm
    {
        //db실행시필요
        //private readonly string strConnectionString =
        //   "Data Source=localhost;Port=3306;Database=bookrentalshop;Uid=root;Password=mysql_p@ssw0rd";
        //Commons의 클래스 확인
        //Commons.CONNSTR

        //readonly strTblName = "divtbl";
        BaseMode mymode = BaseMode.NONE;//초기상태
        public DivMngForm()
        {
            InitializeComponent();
        }

        private void DivMngForm_Load(object sender, EventArgs e)
        {
            UpdateData();//메소드만들기
        }

        private void UpdateData()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR)) //Commons.CONNSTR
            {
                //sql connection 안에서 sqlcommand, sqlparameter, sqldatareader 다 필요
                //mysqldataAdapter가 위에 애들의 역할 가능
                string strQuery = "SELECT Division, Names FROM divtbl";
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
            column.HeaderText = "구분코드";

            column = GrdDivTbl.Columns[1];
            column.Width = 150;
            column.HeaderText = "이름";
            /*
            //구분코드테이블 1행 이름 바뀜
            GrdDivTbl.Columns[0].Width = 100;
            GrdDivTbl.Columns[0].HeaderText = "구분코드";
            GrdDivTbl.Columns[1].Width = 150;
            GrdDivTbl.Columns[1].HeaderText = "이름";
            */
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
            TxtDivision.Text = TxtNames.Text = string.Empty;
            TxtDivision.Focus();

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
            TxtDivision.Text = TxtNames.Text = string.Empty;    //모두 빈칸
            TxtDivision.ReadOnly = false;                       //리드온리 켜뒀던걸 꺼주기, 데이터 입력해야하기때문
            mymode = BaseMode.INSERT;//신규입력모드

            TxtDivision.Focus();
        }
        /// <summary>
        /// DB 업데이트 및 입력 처리
        /// </summary>
        private void SaveData()
        {
            //update
            //빈값이면 실행x
            if (string.IsNullOrEmpty(TxtDivision.Text) || string.IsNullOrEmpty(TxtNames.Text))
            {
                MetroMessageBox.Show(this, "빈값은 넣을 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /*
            if(mymode != BaseMode.INSERT || mymode != BaseMode.UPDATE)
            {
                //신규버튼누르고 데이터 눌러야하는데 그냥 눌렀을때 알림띄워줌
                MetroMessageBox.Show(this, "신규등록시 신규버튼을 눌러주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            */
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
                {
                    conn.Open();//커넥션오픈,using쓰면 자동으로 conn.close();해줌
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    if(mymode == BaseMode.UPDATE)
                    {
                        cmd.CommandText = "UPDATE divtbl " +
                                      "   SET Names = @Names " +
                                      " WHERE Division = @Division; ";//update문
                    }

                    else if(mymode == BaseMode.INSERT)
                    {
                        cmd.CommandText = "INSERT INTO divtbl " +
                                          " (Division,Names) " +
                                          " VALUES(@Division, @Names) ";//insert문
                    }
                    else if(mymode == BaseMode.DELETE)
                    {
                        cmd.CommandText = "DELETE FROM divtbl " +
                                      " WHERE Division = @Division ";   //@Names가없어서 밑에 파라미터 처리할필요없음
                    }

                    if(mymode == BaseMode.INSERT || mymode == BaseMode.UPDATE)  //@(파라미터)가 두개인것들
                    {
                        MySqlParameter paramNames = new MySqlParameter("@Names", MySqlDbType.VarChar, 45);
                        paramNames.Value = TxtNames.Text;
                        cmd.Parameters.Add(paramNames);
                    }
                    /*
                    MySqlParameter paramNames = new MySqlParameter("@Names", MySqlDbType.VarChar, 45);
                    paramNames.Value = TxtNames.Text;
                    cmd.Parameters.Add(paramNames);
                    */
                    MySqlParameter paramDivision = new MySqlParameter("@Division", MySqlDbType.VarChar);
                    paramDivision.Value = TxtDivision.Text;
                    cmd.Parameters.Add(paramDivision);

                    var result = cmd.ExecuteNonQuery();//제대로 insert,update 되면 1이 넘어옴

                    if(mymode == BaseMode.INSERT)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 신규입력되었습니다.", "신규입력");
                    }
                    else if (mymode == BaseMode.UPDATE)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 수정되었습니다.", "수정");
                    }
                    else if(mymode == BaseMode.DELETE)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 삭제되었습니다.", "삭제");
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
                TxtDivision.Text = data.Cells[0].Value.ToString();//cells = column, txt개체는 string이라서 value를 tostring으로
                TxtNames.Text = data.Cells[1].Value.ToString();
                //왼쪽에 테이블에 값 선택시 오른쪽 상세 페이지에 확인가능

                //왼쪽테이블은 pk이기때문에 리드온리 해두기!
                TxtDivision.ReadOnly = true;

                mymode = BaseMode.UPDATE;   //수정모드변경
            }
        }
    }
}
