using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //visual studio에서 해줌
        private void button1_Click(object sender, EventArgs e)      //  이벤트핸들러
        {
            MessageBox.Show("zzan");
            return;
        }

        //직접 코딩 할 때
        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Click += Button1_Click;   //이벤트를 이벤트핸들러와 연결할때 체인(441p)
            textBox1.KeyPress += TextBox1_KeyPress; //txt박스 1
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //txt박스1에서 치고 엔터 하면 txt박스2로 이동
            if(e.KeyChar==13)   //13은 엔터
            {
                textBox2.Focus();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("zzan");
            return;
        }
        //대리자, 이벤트핸들러는 
    }
}
