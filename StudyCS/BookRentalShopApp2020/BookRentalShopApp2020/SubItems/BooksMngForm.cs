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
    public partial class BooksMngForm : MetroForm
    {
        //db실행시필요
        //private readonly string strConnectionString =
        //   "Data Source=localhost;Port=3306;Database=bookrentalshop;Uid=root;Password=mysql_p@ssw0rd";
        //Commons의 클래스 확인
        //Commons.CONNSTR

        //readonly strTblName = "divtbl";
        //readonly strT

        //SELECT->UPDATE->INSERT->DELETE 순서로 코딩

        //[디자인]-삭제:속성:visible:false하면 실행시 보이지않게함
        BaseMode mymode = BaseMode.NONE;//초기상태
        public BooksMngForm()
        {
            InitializeComponent();
        }

        private void DivMngForm_Load(object sender, EventArgs e)
        {
            UpdateComboDivision();
            UpdateData();//메소드만들기

            InitControls();//폼로드시작에사용
        }

        private void UpdateComboDivision()
        {
            //DB에 데이터를 콤보박스에 넣기
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR)) //Commons.CONNSTR
            {
                //sql connection 안에서 sqlcommand, sqlparameter, sqldatareader 다 필요
                //mysqldataAdapter가 위에 애들의 역할 가능
                string strQuery = "SELECT Division, Names FROM divTbl ";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlDataReader reader = cmd.ExecuteReader(); //where절없어서 심플
                Dictionary<string, string> temps = new Dictionary<string, string>();
                temps.Add("선택", "");
                while (reader.Read()) // 리드가 트루일때까지 돌기
                {
                    temps.Add(reader[1].ToString(),reader[0].ToString());
                }
                CboDivision.DataSource = new BindingSource(temps, null);//콤보박스에 데이터 넣기,(dic,데이터멤버)
                CboDivision.DisplayMember = "Key";  //화면에 나오는값은 서울특별시 but 소스상에서 넘어가는 데이터는 11
                CboDivision.ValueMember = "Value";  //값
                //CboDivision.SelectedIndex = -1;

            }
        }

        private void UpdateData()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR)) //Commons.CONNSTR
            {
                //sql connection 안에서 sqlcommand, sqlparameter, sqldatareader 다 필요
                //mysqldataAdapter가 위에 애들의 역할 가능
                string strQuery = "SELECT b.Idx,    " +
                                  "       b.Author, " +
                                  "       b.Division, " +
                                  "       d.Names AS DivisionName, " +
                                  "       b.Names, " +
                                  "       b.ReleaseDate, " +
                                  "       b.ISBN, " +
                                  "       b.Price " +
                                  " FROM bookstbl AS b " +
                                  " INNER JOIN divtbl AS d " +
                                  " ON b.Division = d.Division " +
                                  " ORDER BY b.Idx ASC "; //정렬추가
                conn.Open();
                //MySqlCommand cmd = new MySqlCommand();
                //cmd.Connection = conn;
                //cmd.CommandText = strQuery;

                MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();//데이터 넣을때
                adapter.Fill(ds, "divtbl");

                GrdBooksTbl.DataSource = ds;
                GrdBooksTbl.DataMember = "divtbl";
            }
            SetColumnHeaders();
        }

        private void SetColumnHeaders()
        {
            //도서관리 왼쪽 테이블 변경
            DataGridViewColumn column;//= new DataGridViewColumn
            //같은 타입에게 할당(column == GrdDivTbl)
            column = GrdBooksTbl.Columns[0];
            column.Width = 50;
            column.HeaderText = "번호";

            column = GrdBooksTbl.Columns[1];
            column.Width = 150;
            column.HeaderText = "저자명";

            column = GrdBooksTbl.Columns[2];
            column.Visible = false; //구분코드라서 안씀

            column = GrdBooksTbl.Columns[3]; //구분코드명
            column.Width = 100;
            column.HeaderText = "장르";

            column = GrdBooksTbl.Columns[4];
            column.Width = 200;
            column.HeaderText = "이름";

            column = GrdBooksTbl.Columns[5];
            column.Width = 150;
            column.HeaderText = "출간일";

            column = GrdBooksTbl.Columns[6];
            column.Width = 150;
            column.HeaderText = "ISBN";

            column = GrdBooksTbl.Columns[7];
            column.Width = 100;
            column.HeaderText = "가격";
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

        private void InitControls() //초기화
        {
            TxtIdx.Text = TxtAuthor.Text = string.Empty;
            TxtISBN.Text = TxtNames.Text = TxtPrice.Text = string.Empty;
            CboDivision.SelectedIndex = 0; // 선택
            TxtIdx.Focus();
            TxtIdx.ReadOnly = true;

            DtpReleaseDate.CustomFormat = "yyyy-MM-dd";
            DtpReleaseDate.Format = DateTimePickerFormat.Custom; //형식쓰겠다고 지정
            DtpReleaseDate.Value = DateTime.Now; // 현재 날짜로 초기화
            

            mymode = BaseMode.NONE;

            #region 콤보박스 데이터 바인딩(코드로 가져오기)
            /*
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("선택", "00");//선택에대한값 00
            dic.Add("서울특별시", "11");
            dic.Add("부산광역시", "21");
            dic.Add("대구광역시", "22");
            dic.Add("인천광역시", "23");
            dic.Add("광주광역시", "24");
            dic.Add("대전광역시", "25");

            CboDivision.DataSource = new BindingSource(dic, null);//콤보박스에 데이터 넣기,(dic,데이터멤버)
            CboDivision.DisplayMember = "Key";  //화면에 나오는값은 서울특별시 but 소스상에서 넘어가는 데이터는 11
            CboDivision.ValueMember = "Value";  //값
            */
            #endregion
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

            mymode = BaseMode.INSERT;//신규입력모드

            TxtIdx.Focus();
        }
        /// <summary>
        /// DB 업데이트 및 입력 처리
        /// </summary>
        private void SaveData()
        {
            //update
            //빈값이면 실행x
            //빈값비교, null체크
            if ( 
                string.IsNullOrEmpty(TxtAuthor.Text) ||
                CboDivision.SelectedIndex<1 || //0 : '선택'이라는 칸을 선택한거 : 빈칸이니까 오류 띄우기
                string.IsNullOrEmpty(TxtNames.Text) ||
                string.IsNullOrEmpty(TxtISBN.Text)
                )
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
                        cmd.CommandText = "UPDATE bookstbl " +
                                          "   SET Author      = @Author,    " +
                                          "       Division    = @Division,   "+    
                                          "       Names       = @Names, "+
                                          "       ReleaseDate = @ReleaseDate, "+
                                          "       ISBN        = @ISBN,       "+
                                          "       Price       = @Price      "+
                                          " WHERE Idx = @Idx  ";//update문
                    }

                    else if(mymode == BaseMode.INSERT)
                    {
                        cmd.CommandText = "INSERT INTO bookstbl "+
                                          "   (   "+
                                          "   Author, "+
                                          "   Division,   "+
                                          "   Names,  "+
                                          "   ReleaseDate,    "+
                                          "   ISBN,   "+
                                          "   Price)  "+
                                          "   VALUES  "+
                                          "   (   "+
                                          "   @Author,    "+
                                          "   @Division,  "+
                                          "   @Names, "+
                                          "   @ReleaseDate,   "+
                                          "   @ISBN,  "+
                                          "   @Price) ";//insert문
                    }

                    //저자명
                    MySqlParameter paramAuthor = new MySqlParameter("@Author", MySqlDbType.VarChar,45)
                    {
                        Value = TxtAuthor.Text
                    };
                    cmd.Parameters.Add(paramAuthor);
                    //장르
                    MySqlParameter paramDivision = new MySqlParameter("@Division", MySqlDbType.VarChar,4)
                    {
                        Value = CboDivision.SelectedValue // B001, B002
                    };
                    cmd.Parameters.Add(paramDivision);
                    //책이름
                    MySqlParameter paramNames = new MySqlParameter("@Names", MySqlDbType.VarChar,100)
                    {
                        Value = TxtNames.Text
                    };
                    cmd.Parameters.Add(paramNames);
                    //날짜
                    MySqlParameter paramReleaseDate = new MySqlParameter("@ReleaseDate", MySqlDbType.Date)
                    {
                        Value = DtpReleaseDate.Value
                    };
                    cmd.Parameters.Add(paramReleaseDate);
                    //ISBN
                    MySqlParameter paramISBN = new MySqlParameter("@ISBN", MySqlDbType.VarChar,13)
                    {
                        Value = TxtISBN.Text
                    };
                    cmd.Parameters.Add(paramISBN);
                    //가격
                    MySqlParameter paramPrice = new MySqlParameter("@Price", MySqlDbType.Decimal)
                    {
                        Value = TxtPrice.Text
                    };
                    cmd.Parameters.Add(paramPrice);
                    //idx
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
            if(e.RowIndex > -1)//데이터는 0이상,Select
            {
                DataGridViewRow data = GrdBooksTbl.Rows[e.RowIndex];
                //Todo 클릭시 입력컨트롤에 데이터 할당
                TxtIdx.Text = data.Cells[0].Value.ToString();//cells = column, txt개체는 string이라서 value를 tostring으로
                TxtAuthor.Text = data.Cells[1].Value.ToString();
                //왼쪽에 테이블에 값 선택시 오른쪽 상세 페이지에 확인가능

                //Todo : 장르콤보박스 Cells[2]
                //콤보박스 방법1.로맨스, 추리 등 디스플레이 되는 글자로 인덱스 찾기
                //CboDivision.SelectedIndex = CboDivision.FindString(data.Cells[2].Value.ToString());//콤보박스에 데이터를 스트링이아니라 인덱스로 받음
                                                                                                   //data.Cells[2].Value.ToString() <= B001
                                                                                                   //CboDivision.FindString
                //콤보박스 방법2.코드값을 그대로 할당 = B001,B002
                CboDivision.SelectedValue = data.Cells[2].Value.ToString();

                //Todo : 출간일 날짜픽커 : Cells[5]
                //출간일 초기화
                TxtNames.Text = data.Cells[4].Value.ToString();
                DtpReleaseDate.CustomFormat = "yyyy-MM-dd";
                DtpReleaseDate.Format = DateTimePickerFormat.Custom; //형식쓰겠다고 지정
                DtpReleaseDate.Value = DateTime.Parse(data.Cells[5].Value.ToString());

                TxtISBN.Text = data.Cells[6].Value.ToString();
                TxtPrice.Text = data.Cells[7].Value.ToString();
                //왼쪽테이블은 pk이기때문에 리드온리 해두기!
                TxtIdx.ReadOnly = true;

                mymode = BaseMode.UPDATE;   //수정모드변경
            }
        }

        
    }
}
