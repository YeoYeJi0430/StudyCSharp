using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRentalShopApp2020.SubItems
{
    public partial class RentalMngForm : MetroForm
    {
        //db실행시필요
        //private readonly string strConnectionString =
        //   "Data Source=localhost;Port=3306;Database=bookrentalshop;Uid=root;Password=mysql_p@ssw0rd";
        //Commons의 클래스 확인
        //Commons.CONNSTR

        readonly string strTblName = "membertbl";
        BaseMode mymode = BaseMode.NONE;//초기상태
        public RentalMngForm()
        {
            InitializeComponent();
        }

        private void RentalMngForm_Load(object sender, EventArgs e)
        {
            UdateComboMember();
            UpdateComboBook();
            UpdateData();//메소드만들기


            InitControls();//폼로드시작에사용
        }
        

        private void UdateComboMember()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR)) //Commons.CONNSTR
            {
                string strQuery = "SELECT Idx, Names From membertbl ";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlDataReader reader = cmd.ExecuteReader(); //where절없어서 심플
                Dictionary<string, string> temps = new Dictionary<string, string>();
                temps.Add("선택", "");
                while (reader.Read()) // 리드가 트루일때까지 돌기
                {
                    temps.Add(reader[1].ToString(), reader[0].ToString());
                }
                CboMember.DataSource = new BindingSource(temps, null);//콤보박스에 데이터 넣기,(dic,데이터멤버)
                CboMember.DisplayMember = "Key";  //화면에 나오는값은 서울특별시 but 소스상에서 넘어가는 데이터는 11
                CboMember.ValueMember = "Value";  //값
             
            }
        }

        private void UpdateComboBook()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR)) //Commons.CONNSTR
            {
                string strQuery = "SELECT b.Idx, b.Names, "+
                                  "       (SELECT Names FROM divtbl WHERE Division = b.Division) AS Division "+ /*서브쿼리,속도가 join보다 떨어짐,대용량 데이터는 join사용*/
                                  " From bookstbl AS b ";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlDataReader reader = cmd.ExecuteReader(); //where절없어서 심플

                Dictionary<string, string> temps = new Dictionary<string, string>();
                temps.Add("선택", "");

                while (reader.Read()) 
                {
                    //temps.Add($"[{reader[2].ToString()}] {reader[1].ToString()}",reader[0].ToString());
                    temps.Add($"[{reader[2]}] {reader[1]}", $"{reader[0]}");
                }
                CboBook.DataSource = new BindingSource(temps, null);//콤보박스에 데이터 넣기,(dic,데이터멤버)
                CboBook.DisplayMember = "Key";  //화면에 나오는값은 서울특별시 but 소스상에서 넘어가는 데이터는 11
                CboBook.ValueMember = "Value";  //값

            }
        }
        private void UpdateData()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR)) //Commons.CONNSTR
            {
                //sql connection 안에서 sqlcommand, sqlparameter, sqldatareader 다 필요
                //mysqldataAdapter가 위에 애들의 역할 가능
                string strQuery = @"SELECT 
                                        r.idx AS '대여번호',
                                        m.Names AS '대여회원',
                                        b.Names AS '대여책제목',
                                        b.ISBN,
                                        r.rentalDate AS '대여일',
                                        r.returnDate AS '반납일',
                                        r.memberIdx,
                                        r.bookIdx
                                    FROM
                                        rentaltbl AS r
                                            INNER JOIN
                                        membertbl AS m ON r.memberIdx = m.Idx
                                            INNER JOIN
                                        bookstbl AS b ON r.bookIdx = b.Idx";
                conn.Open();
                //MySqlCommand cmd = new MySqlCommand();
                //cmd.Connection = conn;
                //cmd.CommandText = strQuery;

                MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();//데이터 넣을때, 구조체(?)
                adapter.Fill(ds, "divtbl");//ds에 테이블넣기

                //외쪽에 테이블 띄울때 필요한 key,value인듯?
                GrdRentalTbl.DataSource = ds;
                GrdRentalTbl.DataMember = "divtbl";
            }
            SetColumnHeaders();
        }

        private void SetColumnHeaders()
        {
            DataGridViewColumn column;//= new DataGridViewColumn
            //같은 타입에게 할당(column == GrdDivTbl)
            column = GrdRentalTbl.Columns[0];
            column.Width = 100;
            column.HeaderText = "번호";

            column = GrdRentalTbl.Columns[1];
            column.Width = 150;
            column.HeaderText = "회원";

            column = GrdRentalTbl.Columns[2];
            column.Width = 200;
            column.HeaderText = "책";

            column = GrdRentalTbl.Columns[3];
            column.Width = 100;
            column.HeaderText = "ISBN";

            column = GrdRentalTbl.Columns[4];
            column.Width = 90;
            column.HeaderText = "대여일";

            column = GrdRentalTbl.Columns[5];
            column.Width = 150;
            column.HeaderText = "반납일";

            //6,7은 화면에 나올 필요 x
            column = GrdRentalTbl.Columns[6];
            //column.Visible = false; //memberIdx

            column = GrdRentalTbl.Columns[7];
            //column.Visible = false; //bookIdx

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
            //TxtIdx.Text = TxtNames.Text = string.Empty;
            //TxtAddr.Text = TxtEmail.Text = TxtMobile.Text = string.Empty;
            //CboBook.SelectedIndex = 0;
            TxtIdx.Text = String.Empty;  //string : C# class, String : .NET class

            TxtIdx.Focus();
            TxtIdx.ReadOnly = true;

            CboMember.SelectedIndex = CboBook.SelectedIndex = 0;

            DtpRentalDate.CustomFormat = "yyyy-MM-dd";
            DtpRentalDate.Format = DateTimePickerFormat.Custom;
            DtpRentalDate.Value = DateTime.Now;

            DtpReturnDate.CustomFormat = " "; //반납일.빈값넣기
            DtpReturnDate.Format = DateTimePickerFormat.Custom;




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
            InitControls();
            mymode = BaseMode.INSERT;
            //SaveData();
            //신규입력모드

            //TxtNames.Focus();
        }
        /// <summary>
        /// DB 업데이트 및 입력 처리
        /// </summary>
        private void SaveData()
        {
            //update
            //빈값이면 실행x
            /*if (string.IsNullOrEmpty(TxtNames.Text)||
               CboBook.SelectedIndex<1||
                string.IsNullOrEmpty(TxtAddr.Text) ||
                string.IsNullOrEmpty(TxtMobile.Text) ||
                string.IsNullOrEmpty(TxtEmail.Text)
               )
            {
                MetroMessageBox.Show(this, "빈값은 넣을 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
                {
                    conn.Open();//커넥션오픈,using쓰면 자동으로 conn.close();해줌
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    if(mymode == BaseMode.UPDATE)
                    {
                        cmd.CommandText = @"UPDATE rentaltbl 
                                            SET 
                                                memberIdx = @memberIdx,
                                                bookIdx = @bookIdx,
                                                rentalDate = @rentalDate,
                                                returnDate = @returnDate
                                            WHERE
                                                Idx = @Idx";//update문
                    }

                    else if(mymode == BaseMode.INSERT)
                    {
                        cmd.CommandText = @"INSERT INTO rentaltbl
                                            (
                                            memberIdx,
                                            bookIdx,
                                            rentalDate,
                                            returnDate)
                                            VALUES
                                            (
                                            @memberIdx,
                                            @bookIdx,
                                            @rentalDate,
                                            @returnDate)";//insert문
                    }


                    MySqlParameter paramMemberIdx = new MySqlParameter("@memberIdx", MySqlDbType.Int32);
                    paramMemberIdx.Value = CboMember.SelectedValue;
                    cmd.Parameters.Add(paramMemberIdx); // memberIdx

                    MySqlParameter parambookIdx = new MySqlParameter("@bookIdx", MySqlDbType.Int32);
                    parambookIdx.Value = CboMember.SelectedValue;
                    cmd.Parameters.Add(parambookIdx); // bookIdx

                    MySqlParameter paramrentalDate = new MySqlParameter("@rentalDate", MySqlDbType.Date);
                    paramrentalDate.Value = DtpRentalDate.Value;
                    cmd.Parameters.Add(paramrentalDate); // rentalDate

                    MySqlParameter paramreturnDate = new MySqlParameter("@returnDate", MySqlDbType.Date);
                    if (mymode == BaseMode.INSERT)
                    {
                        paramreturnDate.Value = null;
                    }
                    else
                    {
                        paramreturnDate.Value = DtpReturnDate.Value;
                    }
                    cmd.Parameters.Add(paramreturnDate);
                    if (mymode == BaseMode.UPDATE)
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


        private void GrdRentalTbl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)//데이터는 0이상,Select
            {
                DataGridViewRow data = GrdRentalTbl.Rows[e.RowIndex];
                TxtIdx.Text = data.Cells[0].Value.ToString();//cells = column, txt개체는 string이라서 value를 tostring으로
                CboMember.SelectedValue = data.Cells[6].Value.ToString();
                CboBook.SelectedValue = data.Cells[7].Value.ToString();
                DtpRentalDate.Value = DateTime.Parse(data.Cells[4].Value.ToString());

                if(!string.IsNullOrEmpty(data.Cells[5].Value.ToString())) // true가 아니면 아래쪽 실행
                {
                    DtpReturnDate.CustomFormat = "yyyy-MM-dd";
                    DtpReturnDate.Format = DateTimePickerFormat.Custom;
                    DtpReturnDate.Value = DateTime.Parse(data.Cells[5].Value.ToString());//값이 없을 수도 있기 때문에 추가하기
                }
                else
                {
                    DtpReturnDate.CustomFormat = " "; // 반납일 없으면 빈칸
                    DtpReturnDate.Format = DateTimePickerFormat.Custom;
                }
                

                mymode = BaseMode.UPDATE;   //수정모드변경
            }
        }

        private void DtpReturnDate_ValueChanged(object sender, EventArgs e)
        {
            DtpReturnDate.CustomFormat = "yyyy-MM-dd";
            DtpReturnDate.Format = DateTimePickerFormat.Custom;
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet1 = workbook.CreateSheet("sheet1");//시트이름
            sheet1.CreateRow(0).CreateCell(0).SetCellValue("Rental Book Data");
            int x = 1;

            DataSet ds = GrdRentalTbl.DataSource as DataSet;//형변환

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)//테이블 여러개 중에 0번째꺼
            {
                IRow row = sheet1.CreateRow(i);
                for (int j = 0; j < ds.Tables[0].Rows[0].ItemArray.Length; j++)
                {
                    if(j==4||j==5)//5:값이 없을때도 있음
                    {
                        var value = string.IsNullOrEmpty(ds.Tables[0].Rows[i].ItemArray[j].ToString()) ? "" : ds.Tables[0].Rows[i].ItemArray[j].ToString().Substring(0, 10); // null이면(5값이 0이면)빈값으로, 아니면 자르기
                        row.CreateCell(j).SetCellValue(value);
                        //C:\StudyCSharp\StudyCS\BookRentalShopApp2020\BookRentalShopApp2020\bin\Debug 확인가능
                    }
                    else if (j>5)
                    {
                        break;
                    }
                    else
                    {
                        row.CreateCell(j).SetCellValue(ds.Tables[0].Rows[i].ItemArray[j].ToString());
                    }
                    
                }
            }
            FileStream file = File.Create(Environment.CurrentDirectory + $@"\export.xlsx");
            workbook.Write(file);
            file.Close();

            MessageBox.Show("Export done!");
        }
    }
}
