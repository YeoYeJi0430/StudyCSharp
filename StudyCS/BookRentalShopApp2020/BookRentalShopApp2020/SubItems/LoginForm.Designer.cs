namespace BookRentalShopApp2020.SubItems
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.TxtUserID = new MetroFramework.Controls.MetroTextBox();
            this.TxtUserPwd = new MetroFramework.Controls.MetroTextBox();
            this.BtnOk = new MetroFramework.Controls.MetroButton();
            this.BtnCancle = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(23, 74);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(151, 27);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "ID";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel2
            // 
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(23, 107);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(151, 27);
            this.metroLabel2.TabIndex = 0;
            this.metroLabel2.Text = "PASSWORD";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel2.Click += new System.EventHandler(this.metroLabel2_Click);
            // 
            // TxtUserID
            // 
            // 
            // 
            // 
            this.TxtUserID.CustomButton.Image = null;
            this.TxtUserID.CustomButton.Location = new System.Drawing.Point(232, 2);
            this.TxtUserID.CustomButton.Name = "";
            this.TxtUserID.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.TxtUserID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TxtUserID.CustomButton.TabIndex = 1;
            this.TxtUserID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TxtUserID.CustomButton.UseSelectable = true;
            this.TxtUserID.CustomButton.Visible = false;
            this.TxtUserID.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.TxtUserID.Lines = new string[0];
            this.TxtUserID.Location = new System.Drawing.Point(193, 74);
            this.TxtUserID.MaxLength = 12;
            this.TxtUserID.Name = "TxtUserID";
            this.TxtUserID.PasswordChar = '\0';
            this.TxtUserID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxtUserID.SelectedText = "";
            this.TxtUserID.SelectionLength = 0;
            this.TxtUserID.SelectionStart = 0;
            this.TxtUserID.ShortcutsEnabled = true;
            this.TxtUserID.Size = new System.Drawing.Size(260, 30);
            this.TxtUserID.TabIndex = 0;
            this.TxtUserID.UseSelectable = true;
            this.TxtUserID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxtUserID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.TxtUserID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtUserID_KeyPress);
            // 
            // TxtUserPwd
            // 
            // 
            // 
            // 
            this.TxtUserPwd.CustomButton.Image = null;
            this.TxtUserPwd.CustomButton.Location = new System.Drawing.Point(232, 2);
            this.TxtUserPwd.CustomButton.Name = "";
            this.TxtUserPwd.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.TxtUserPwd.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TxtUserPwd.CustomButton.TabIndex = 1;
            this.TxtUserPwd.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TxtUserPwd.CustomButton.UseSelectable = true;
            this.TxtUserPwd.CustomButton.Visible = false;
            this.TxtUserPwd.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.TxtUserPwd.Lines = new string[0];
            this.TxtUserPwd.Location = new System.Drawing.Point(193, 107);
            this.TxtUserPwd.MaxLength = 32767;
            this.TxtUserPwd.Name = "TxtUserPwd";
            this.TxtUserPwd.PasswordChar = '●';
            this.TxtUserPwd.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxtUserPwd.SelectedText = "";
            this.TxtUserPwd.SelectionLength = 0;
            this.TxtUserPwd.SelectionStart = 0;
            this.TxtUserPwd.ShortcutsEnabled = true;
            this.TxtUserPwd.Size = new System.Drawing.Size(260, 30);
            this.TxtUserPwd.TabIndex = 1;
            this.TxtUserPwd.UseSelectable = true;
            this.TxtUserPwd.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxtUserPwd.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.TxtUserPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtUserPwd_KeyPress);
            // 
            // BtnOk
            // 
            this.BtnOk.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.BtnOk.Location = new System.Drawing.Point(117, 153);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(127, 52);
            this.BtnOk.TabIndex = 2;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseSelectable = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnCancle
            // 
            this.BtnCancle.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.BtnCancle.Location = new System.Drawing.Point(273, 153);
            this.BtnCancle.Name = "BtnCancle";
            this.BtnCancle.Size = new System.Drawing.Size(127, 52);
            this.BtnCancle.TabIndex = 3;
            this.BtnCancle.Text = "Cancel";
            this.BtnCancle.UseSelectable = true;
            this.BtnCancle.Click += new System.EventHandler(this.BtnCancle_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 268);
            this.ControlBox = false;
            this.Controls.Add(this.BtnCancle);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.TxtUserPwd);
            this.Controls.Add(this.TxtUserID);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Resizable = false;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox TxtUserID;
        private MetroFramework.Controls.MetroTextBox TxtUserPwd;
        private MetroFramework.Controls.MetroButton BtnOk;
        private MetroFramework.Controls.MetroButton BtnCancle;
    }
}