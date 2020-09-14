using System;
using BookRentalShopApp2020.SubItems;
using MetroFramework;
using MetroFramework.Forms;
using System.Windows.Forms;

namespace BookRentalShopApp2020
{
    public partial class MainForm :  MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.ShowDialog();

            LbUserId.Text = $"LOGIN : {Commons.USERID}";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MetroMessageBox.Show(this, "종료하시겠습니까?", "종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)//프로그램종료
            {
                e.Cancel = false;//cancel = true = 종료x 따라서 false 하기
                Environment.Exit(0);//완전종료
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void 끝내기XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void MnuItemCodeMng_Click(object sender, EventArgs e)
        {
            DivMngForm mngForm = new DivMngForm();
            ShowFormControl(mngForm,"구분코드관리");
        }
        
        private void MnuItemBooksMng_Click(object sender, EventArgs e)
        {
            BooksMngForm mngForm = new BooksMngForm();
            ShowFormControl(mngForm,"도서관리");
        }

        private void MnuItemMemberMng_Click(object sender, EventArgs e)
        {
            MemberForm mngForm = new MemberForm();
            ShowFormControl(mngForm, "멤버관리");
        }

        private void MnuItemBenMng_Click(object sender, EventArgs e)
        {
            RentalMngForm mngForm = new RentalMngForm();
            ShowFormControl(mngForm, "대여관리");
        }
        private void MnuItemUserMng_Click(object sender, EventArgs e)
        {

        }

        private void ShowFormControl(Form mngForm,string title)  //mngForm은 Form의 인스턴스
        {
            mngForm.MdiParent = this;
            mngForm.Text = title;
            mngForm.Dock = DockStyle.Fill;
            mngForm.Show();
            mngForm.WindowState = FormWindowState.Maximized;
        }

        
    }
}
