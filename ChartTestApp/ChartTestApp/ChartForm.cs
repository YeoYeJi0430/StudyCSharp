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
using System.Windows.Forms.DataVisualization.Charting;

namespace ChartTestApp
{
    public partial class ChartForm : MetroForm
    {
        public readonly string strConnstring = 
            @"Data Source=localhost;
                    Port=3306;
                    Database=employees;
                    Uid=root;
                    Password=mysql_p@ssw0rd";

        public readonly string strQuery = @"SELECT CONCAT(em.first_name, ' ', em.last_name) AS emp_name,
	                                               em.gender,
                                                   em.hire_date,
                                                   dp.dept_no,
                                                   dt.dept_name,
	                                               MAX(sl.salary) AS max_salary
                                              FROM employees AS em
                                             INNER JOIN dept_emp AS dp
                                                ON em.emp_no = dp.emp_no
                                             INNER JOIN departments AS dt
                                                ON dp.dept_no = dt.dept_no
                                             INNER JOIN salaries AS sl
                                                ON em.emp_no = sl.emp_no
                                             WHERE em.hire_date >= '2000-01-01'
                                             GROUP BY em.first_name, em.last_name, em.gender, em.hire_date, dt.dept_name
                                             ORDER BY em.first_name ASC ";
        public ChartForm()
        {
            InitializeComponent();
        }

        private void BtnYValues_Click(object sender, EventArgs e)
        {
            /*그래프 값 넣기*/
            chart1.Series[0].Points.Clear(); // 초기화
            chart1.Series[0].Points.Add(98); //(y값)
            chart1.Series[0].Points.Add(72);
            chart1.Series[0].Points.Add(50);
            chart1.Series[0].Points.Add(100);
            chart1.Series[0].Points.Add(88);
            chart1.Series[0].Points.Add(63);

            chart1.Series[0].IsValueShownAsLabel = true;
            //chart1.Series[0].ChartType = SeriesChartType.Spline;//곡선
            chart1.Series[0].ChartType = SeriesChartType.Area;
            chart1.Series[0].Color = Color.Aqua;
        }

        private void BtnXYValues_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear(); // 초기화,Series["Score"]
            chart1.Series[0].Points.AddXY("명건띠",98); //(y값)
            chart1.Series[0].Points.AddXY("옏2",72);
            chart1.Series[0].Points.AddXY("오타영",50);
            chart1.Series[0].Points.AddXY("가라미",100);
            chart1.Series[0].Points.AddXY("그르미",88);
            chart1.Series[0].Points.AddXY("하용",63);

            chart1.Series[0].IsValueShownAsLabel = true;

            //chart1.Series[0].ChartType = SeriesChartType.Line; // 꺾은선그래프
            chart1.Series[0].ChartType = SeriesChartType.Pie;
        }

        private void BtnDataBind_Click(object sender, EventArgs e)
        {
            List<Student> students = new List<Student>(); //class
            students.Add(new Student("하용", 44.4));
            students.Add(new Student("그르미", 55.5));
            students.Add(new Student("가라미", 66.6));
            students.Add(new Student("오타영", 77.7));
            students.Add(new Student("옏2", 88.8));
            students.Add(new Student("명건띠", 99.9));

            chart1.Series[0].Points.DataBind(students, "Name", "Score", null);

            chart1.Series[0].ChartType = SeriesChartType.Area;
            chart1.Series[0].IsValueShownAsLabel = true; // 값표시
            chart1.Series[0].Color = Color.Pink;
        }

        private class Student
        {
            public string Name { get; set; }
            public double Score { get; set; }

            public Student(string name, double score)
            {
                Name = name;
                Score = score;
            }//생성자
        }

        private void BtnMultiChart_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
            chart1.ChartAreas.Add("area1");
            chart1.ChartAreas.Add("area2");

            chart1.Series.Add("series1");
            chart1.Series.Add("series2");
            chart1.Series.Add("series3");

            chart1.Series["series1"].ChartArea = "area1";
            chart1.Series["series2"].ChartArea = "area2";
            chart1.Series["series3"].ChartArea = "area2";

            chart1.Series["series1"].ChartType = SeriesChartType.Spline;
            chart1.Series["series2"].ChartType = SeriesChartType.Line;
            chart1.Series["series3"].ChartType = SeriesChartType.Bubble;

            chart1.Series["series1"].Color = Color.Red;
            chart1.Series["series2"].Color = Color.Blue;
            chart1.Series["series3"].Color = Color.Gray;

            chart1.Series["series1"].Points.AddXY(1, 100);
            chart1.Series["series1"].Points.AddXY(2, 400);
            chart1.Series["series1"].Points.AddXY(3, 300);
            chart1.Series["series1"].Points.AddXY(4, 500);
            chart1.Series["series1"].Points.AddXY(5, 900);

            chart1.Series["series2"].Points.AddXY(1, 120);
            chart1.Series["series2"].Points.AddXY(2, 430);
            chart1.Series["series2"].Points.AddXY(3, 340);
            chart1.Series["series2"].Points.AddXY(4, 550);
            chart1.Series["series2"].Points.AddXY(5, 960);

            chart1.Series["series3"].Points.AddXY(1, 102);
            chart1.Series["series3"].Points.AddXY(2, 404);
            chart1.Series["series3"].Points.AddXY(3, 305);
            chart1.Series["series3"].Points.AddXY(4, 509);
            chart1.Series["series3"].Points.AddXY(5, 907);

            chart1.Series["series2"].Points[3].Color = Color.HotPink; //포인트 5개 중에 3번을 컬러 바꿈
            chart1.Series["series2"].Points[4].Color = Color.Orange;

        }

        private void BtnDBBind_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(strConnstring))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);//adapter통해서 쿼리 실행 결과를 ds에 넣음

                chart1.DataSource = ds.Tables[0]; //테이블 컬렉션에 0번째꺼
                chart1.Series[0].XValueMember = "emp_Name";
                chart1.Series[0].YValueMembers = "max_salary";
                chart1.DataBind();

                chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;//x축의 라벨스타일 간격 지정
                chart1.ChartAreas[0].AxisX.Title = "Employees";
                chart1.ChartAreas[0].AxisY.Title = "Salaries";
                chart1.ChartAreas[0].AxisY.LabelStyle.Format = "${0,0}";

                chart1.Series[0].IsValueShownAsLabel = true; //Series[0] = Series["score"]
                chart1.Series[0].Name = "salary";
                chart1.Series[0].LabelFormat = "{0,0}";
                chart1.Series[0].Color = Color.Maroon;

            }
        }
    }
}
