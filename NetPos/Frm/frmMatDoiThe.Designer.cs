namespace NetPos.Frm
{
    partial class frmMatDoiThe
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
            this.groupThongTinThe = new System.Windows.Forms.GroupBox();
            this.labLoaiThe = new System.Windows.Forms.Label();
            this.labTenTaiKhoan = new System.Windows.Forms.Label();
            this.labMaThe = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupThongTinGiaoDich = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupXuLyThe = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.chkThemDanhSachDen = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupThongTinThe.SuspendLayout();
            this.groupThongTinGiaoDich.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupXuLyThe.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupThongTinThe
            // 
            this.groupThongTinThe.Controls.Add(this.labLoaiThe);
            this.groupThongTinThe.Controls.Add(this.labTenTaiKhoan);
            this.groupThongTinThe.Controls.Add(this.labMaThe);
            this.groupThongTinThe.Controls.Add(this.label3);
            this.groupThongTinThe.Controls.Add(this.label2);
            this.groupThongTinThe.Controls.Add(this.label1);
            this.groupThongTinThe.Location = new System.Drawing.Point(25, 25);
            this.groupThongTinThe.Name = "groupThongTinThe";
            this.groupThongTinThe.Size = new System.Drawing.Size(605, 145);
            this.groupThongTinThe.TabIndex = 0;
            this.groupThongTinThe.TabStop = false;
            this.groupThongTinThe.Text = "Thông Tin Thẻ";
            this.groupThongTinThe.Enter += new System.EventHandler(this.groupThongTinThe_Enter);
            // 
            // labLoaiThe
            // 
            this.labLoaiThe.AutoSize = true;
            this.labLoaiThe.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labLoaiThe.Location = new System.Drawing.Point(153, 109);
            this.labLoaiThe.Name = "labLoaiThe";
            this.labLoaiThe.Size = new System.Drawing.Size(48, 13);
            this.labLoaiThe.TabIndex = 5;
            this.labLoaiThe.Text = "Loại thẻ:";
            // 
            // labTenTaiKhoan
            // 
            this.labTenTaiKhoan.AutoSize = true;
            this.labTenTaiKhoan.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labTenTaiKhoan.Location = new System.Drawing.Point(153, 72);
            this.labTenTaiKhoan.Name = "labTenTaiKhoan";
            this.labTenTaiKhoan.Size = new System.Drawing.Size(76, 13);
            this.labTenTaiKhoan.TabIndex = 4;
            this.labTenTaiKhoan.Text = "Tên tài khoản:";
            // 
            // labMaThe
            // 
            this.labMaThe.AutoSize = true;
            this.labMaThe.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labMaThe.Location = new System.Drawing.Point(153, 40);
            this.labMaThe.Name = "labMaThe";
            this.labMaThe.Size = new System.Drawing.Size(39, 13);
            this.labMaThe.TabIndex = 3;
            this.labMaThe.Text = "mã thẻ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Loại thẻ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên tài khoản:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Thẻ:";
            // 
            // groupThongTinGiaoDich
            // 
            this.groupThongTinGiaoDich.Controls.Add(this.dataGridView1);
            this.groupThongTinGiaoDich.Location = new System.Drawing.Point(25, 188);
            this.groupThongTinGiaoDich.Name = "groupThongTinGiaoDich";
            this.groupThongTinGiaoDich.Size = new System.Drawing.Size(605, 303);
            this.groupThongTinGiaoDich.TabIndex = 1;
            this.groupThongTinGiaoDich.TabStop = false;
            this.groupThongTinGiaoDich.Text = "Thông tin giao dịch gần nhất:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(593, 270);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupXuLyThe
            // 
            this.groupXuLyThe.Controls.Add(this.button1);
            this.groupXuLyThe.Controls.Add(this.textBox2);
            this.groupXuLyThe.Controls.Add(this.label5);
            this.groupXuLyThe.Controls.Add(this.textBox1);
            this.groupXuLyThe.Controls.Add(this.label4);
            this.groupXuLyThe.Controls.Add(this.radioButton2);
            this.groupXuLyThe.Controls.Add(this.radioButton1);
            this.groupXuLyThe.Controls.Add(this.chkThemDanhSachDen);
            this.groupXuLyThe.Location = new System.Drawing.Point(648, 24);
            this.groupXuLyThe.Name = "groupXuLyThe";
            this.groupXuLyThe.Size = new System.Drawing.Size(273, 466);
            this.groupXuLyThe.TabIndex = 2;
            this.groupXuLyThe.TabStop = false;
            this.groupXuLyThe.Text = "Xử lý thẻ:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(73, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Xử lý mất thẻ/ đổi thẻ";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(28, 245);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(210, 20);
            this.textBox2.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Mã tả:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(28, 181);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(210, 20);
            this.textBox1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mã thẻ mới:";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(28, 119);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(78, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Đổi thẻ mới";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(28, 85);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(68, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Khóa thẻ";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // chkThemDanhSachDen
            // 
            this.chkThemDanhSachDen.AutoSize = true;
            this.chkThemDanhSachDen.Location = new System.Drawing.Point(28, 45);
            this.chkThemDanhSachDen.Name = "chkThemDanhSachDen";
            this.chkThemDanhSachDen.Size = new System.Drawing.Size(167, 17);
            this.chkThemDanhSachDen.TabIndex = 0;
            this.chkThemDanhSachDen.Text = "Thêm thẻ vào danh sách đen";
            this.chkThemDanhSachDen.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(848, 511);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // frmMatDoiThe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 558);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupXuLyThe);
            this.Controls.Add(this.groupThongTinGiaoDich);
            this.Controls.Add(this.groupThongTinThe);
            this.Name = "frmMatDoiThe";
            this.Text = "Mất Thẻ/ Đổi Thẻ";
            this.groupThongTinThe.ResumeLayout(false);
            this.groupThongTinThe.PerformLayout();
            this.groupThongTinGiaoDich.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupXuLyThe.ResumeLayout(false);
            this.groupXuLyThe.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupThongTinThe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labLoaiThe;
        private System.Windows.Forms.Label labTenTaiKhoan;
        private System.Windows.Forms.Label labMaThe;
        private System.Windows.Forms.GroupBox groupThongTinGiaoDich;
        private System.Windows.Forms.GroupBox groupXuLyThe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.CheckBox chkThemDanhSachDen;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
    }
}