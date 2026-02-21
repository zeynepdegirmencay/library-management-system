namespace KutuphaneUygulamasi.Forms
{
    partial class StudentForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.cmbBooks = new System.Windows.Forms.ComboBox();
            this.lstPopularBooks = new System.Windows.Forms.ListBox();
            this.btnBorrow = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbBooks
            // 
            this.cmbBooks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBooks.FormattingEnabled = true;
            this.cmbBooks.Location = new System.Drawing.Point(1, 12);
            this.cmbBooks.Name = "cmbBooks";
            this.cmbBooks.Size = new System.Drawing.Size(250, 24);
            this.cmbBooks.TabIndex = 4;
            // 
            // lstPopularBooks
            // 
            this.lstPopularBooks.FormattingEnabled = true;
            this.lstPopularBooks.ItemHeight = 16;
            this.lstPopularBooks.Location = new System.Drawing.Point(257, 12);
            this.lstPopularBooks.Name = "lstPopularBooks";
            this.lstPopularBooks.Size = new System.Drawing.Size(250, 100);
            this.lstPopularBooks.TabIndex = 3;
            // 
            // btnBorrow
            // 
            this.btnBorrow.Location = new System.Drawing.Point(12, 142);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(100, 30);
            this.btnBorrow.TabIndex = 2;
            this.btnBorrow.Text = "Ödünç Al";
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(130, 142);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(100, 30);
            this.btnReturn.TabIndex = 1;
            this.btnReturn.Text = "İade Et";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 270);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 16);
            this.lblStatus.TabIndex = 0;
            // 
            // StudentForm
            // 
            this.ClientSize = new System.Drawing.Size(509, 341);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnBorrow);
            this.Controls.Add(this.lstPopularBooks);
            this.Controls.Add(this.cmbBooks);
            this.Name = "StudentForm";
            this.Text = "Öğrenci Paneli";
            this.Load += new System.EventHandler(this.StudentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbBooks;
        private System.Windows.Forms.ListBox lstPopularBooks;
        private System.Windows.Forms.Button btnBorrow;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label lblStatus;
    }
}
