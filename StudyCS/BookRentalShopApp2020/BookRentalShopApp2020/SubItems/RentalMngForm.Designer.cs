namespace BookRentalShopApp2020.SubItems
{
    partial class RentalMngForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GrdRentalTbl = new MetroFramework.Controls.MetroGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnExport = new System.Windows.Forms.Button();
            this.DtpReturnDate = new MetroFramework.Controls.MetroDateTime();
            this.DtpRentalDate = new MetroFramework.Controls.MetroDateTime();
            this.CboMember = new MetroFramework.Controls.MetroComboBox();
            this.CboBook = new MetroFramework.Controls.MetroComboBox();
            this.BtnCancel = new MetroFramework.Controls.MetroButton();
            this.BtnSave = new MetroFramework.Controls.MetroButton();
            this.BtnNew = new MetroFramework.Controls.MetroButton();
            this.BtnDelete = new MetroFramework.Controls.MetroButton();
            this.TxtIdx = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdRentalTbl)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(20, 60);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.GrdRentalTbl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(909, 510);
            this.splitContainer1.SplitterDistance = 411;
            this.splitContainer1.TabIndex = 0;
            // 
            // GrdRentalTbl
            // 
            this.GrdRentalTbl.AllowUserToAddRows = false;
            this.GrdRentalTbl.AllowUserToDeleteRows = false;
            this.GrdRentalTbl.AllowUserToResizeRows = false;
            this.GrdRentalTbl.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.GrdRentalTbl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrdRentalTbl.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GrdRentalTbl.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrdRentalTbl.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.GrdRentalTbl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrdRentalTbl.DefaultCellStyle = dataGridViewCellStyle8;
            this.GrdRentalTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdRentalTbl.EnableHeadersVisualStyles = false;
            this.GrdRentalTbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.GrdRentalTbl.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.GrdRentalTbl.Location = new System.Drawing.Point(0, 0);
            this.GrdRentalTbl.Name = "GrdRentalTbl";
            this.GrdRentalTbl.ReadOnly = true;
            this.GrdRentalTbl.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrdRentalTbl.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.GrdRentalTbl.RowHeadersWidth = 51;
            this.GrdRentalTbl.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.GrdRentalTbl.RowTemplate.Height = 27;
            this.GrdRentalTbl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdRentalTbl.Size = new System.Drawing.Size(411, 510);
            this.GrdRentalTbl.TabIndex = 0;
            this.GrdRentalTbl.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdRentalTbl_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnExport);
            this.groupBox1.Controls.Add(this.DtpReturnDate);
            this.groupBox1.Controls.Add(this.DtpRentalDate);
            this.groupBox1.Controls.Add(this.CboMember);
            this.groupBox1.Controls.Add(this.CboBook);
            this.groupBox1.Controls.Add(this.BtnCancel);
            this.groupBox1.Controls.Add(this.BtnSave);
            this.groupBox1.Controls.Add(this.BtnNew);
            this.groupBox1.Controls.Add(this.BtnDelete);
            this.groupBox1.Controls.Add(this.TxtIdx);
            this.groupBox1.Controls.Add(this.metroLabel5);
            this.groupBox1.Controls.Add(this.metroLabel4);
            this.groupBox1.Controls.Add(this.metroLabel3);
            this.groupBox1.Controls.Add(this.metroLabel2);
            this.groupBox1.Controls.Add(this.metroLabel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("나눔고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 510);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "상세";
            // 
            // BtnExport
            // 
            this.BtnExport.Location = new System.Drawing.Point(48, 380);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(84, 42);
            this.BtnExport.TabIndex = 9;
            this.BtnExport.Text = "Export";
            this.BtnExport.UseVisualStyleBackColor = true;
            this.BtnExport.Visible = false;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // DtpReturnDate
            // 
            this.DtpReturnDate.Location = new System.Drawing.Point(129, 264);
            this.DtpReturnDate.MinimumSize = new System.Drawing.Size(0, 30);
            this.DtpReturnDate.Name = "DtpReturnDate";
            this.DtpReturnDate.Size = new System.Drawing.Size(226, 30);
            this.DtpReturnDate.TabIndex = 4;
            this.DtpReturnDate.ValueChanged += new System.EventHandler(this.DtpReturnDate_ValueChanged);
            // 
            // DtpRentalDate
            // 
            this.DtpRentalDate.Location = new System.Drawing.Point(129, 204);
            this.DtpRentalDate.MinimumSize = new System.Drawing.Size(0, 30);
            this.DtpRentalDate.Name = "DtpRentalDate";
            this.DtpRentalDate.Size = new System.Drawing.Size(226, 30);
            this.DtpRentalDate.TabIndex = 3;
            // 
            // CboMember
            // 
            this.CboMember.FormattingEnabled = true;
            this.CboMember.ItemHeight = 24;
            this.CboMember.Location = new System.Drawing.Point(129, 98);
            this.CboMember.Name = "CboMember";
            this.CboMember.Size = new System.Drawing.Size(226, 30);
            this.CboMember.TabIndex = 1;
            this.CboMember.UseSelectable = true;
            // 
            // CboBook
            // 
            this.CboBook.FormattingEnabled = true;
            this.CboBook.ItemHeight = 24;
            this.CboBook.Location = new System.Drawing.Point(129, 151);
            this.CboBook.Name = "CboBook";
            this.CboBook.Size = new System.Drawing.Size(226, 30);
            this.CboBook.TabIndex = 2;
            this.CboBook.UseSelectable = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.BtnCancel.Location = new System.Drawing.Point(346, 434);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(102, 43);
            this.BtnCancel.TabIndex = 8;
            this.BtnCancel.Text = "취소";
            this.BtnCancel.UseSelectable = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.BtnSave.Location = new System.Drawing.Point(238, 434);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(102, 43);
            this.BtnSave.TabIndex = 7;
            this.BtnSave.Text = "저장";
            this.BtnSave.UseSelectable = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnNew
            // 
            this.BtnNew.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.BtnNew.Location = new System.Drawing.Point(139, 434);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(93, 43);
            this.BtnNew.TabIndex = 6;
            this.BtnNew.Text = "신규";
            this.BtnNew.UseSelectable = true;
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.BtnDelete.Location = new System.Drawing.Point(44, 434);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(89, 43);
            this.BtnDelete.TabIndex = 5;
            this.BtnDelete.Text = "삭제";
            this.BtnDelete.UseSelectable = true;
            this.BtnDelete.Visible = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // TxtIdx
            // 
            // 
            // 
            // 
            this.TxtIdx.CustomButton.Image = null;
            this.TxtIdx.CustomButton.Location = new System.Drawing.Point(193, 2);
            this.TxtIdx.CustomButton.Name = "";
            this.TxtIdx.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.TxtIdx.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TxtIdx.CustomButton.TabIndex = 1;
            this.TxtIdx.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TxtIdx.CustomButton.UseSelectable = true;
            this.TxtIdx.CustomButton.Visible = false;
            this.TxtIdx.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TxtIdx.Lines = new string[0];
            this.TxtIdx.Location = new System.Drawing.Point(129, 45);
            this.TxtIdx.MaxLength = 4;
            this.TxtIdx.Name = "TxtIdx";
            this.TxtIdx.PasswordChar = '\0';
            this.TxtIdx.ReadOnly = true;
            this.TxtIdx.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxtIdx.SelectedText = "";
            this.TxtIdx.SelectionLength = 0;
            this.TxtIdx.SelectionStart = 0;
            this.TxtIdx.ShortcutsEnabled = true;
            this.TxtIdx.Size = new System.Drawing.Size(227, 36);
            this.TxtIdx.TabIndex = 0;
            this.TxtIdx.UseSelectable = true;
            this.TxtIdx.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxtIdx.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel5
            // 
            this.metroLabel5.Location = new System.Drawing.Point(28, 264);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(95, 20);
            this.metroLabel5.TabIndex = 0;
            this.metroLabel5.Text = "반납일 :";
            this.metroLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel4
            // 
            this.metroLabel4.Location = new System.Drawing.Point(28, 204);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(95, 20);
            this.metroLabel4.TabIndex = 0;
            this.metroLabel4.Text = "대여일 :";
            this.metroLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel3
            // 
            this.metroLabel3.Location = new System.Drawing.Point(28, 152);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(95, 20);
            this.metroLabel3.TabIndex = 0;
            this.metroLabel3.Text = "책 :";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel2
            // 
            this.metroLabel2.Location = new System.Drawing.Point(28, 97);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(95, 20);
            this.metroLabel2.TabIndex = 0;
            this.metroLabel2.Text = "회원 : ";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Location = new System.Drawing.Point(28, 45);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(95, 20);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "번호 :";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RentalMngForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 590);
            this.Controls.Add(this.splitContainer1);
            this.Name = "RentalMngForm";
            this.Style = MetroFramework.MetroColorStyle.Pink;
            this.Text = "RentalForm";
            this.Load += new System.EventHandler(this.RentalMngForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdRentalTbl)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private MetroFramework.Controls.MetroGrid GrdRentalTbl;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroButton BtnCancel;
        private MetroFramework.Controls.MetroButton BtnSave;
        private MetroFramework.Controls.MetroButton BtnNew;
        private MetroFramework.Controls.MetroButton BtnDelete;
        private MetroFramework.Controls.MetroTextBox TxtIdx;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroComboBox CboBook;
        private MetroFramework.Controls.MetroComboBox CboMember;
        private MetroFramework.Controls.MetroDateTime DtpReturnDate;
        private MetroFramework.Controls.MetroDateTime DtpRentalDate;
        private System.Windows.Forms.Button BtnExport;
    }
}