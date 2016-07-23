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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMatDoiThe));
            this.groupThongTinThe = new System.Windows.Forms.GroupBox();
            this.labLoaiThe = new System.Windows.Forms.Label();
            this.labTenTaiKhoan = new System.Windows.Forms.Label();
            this.labMaThe = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupThongTinGiaoDich = new System.Windows.Forms.GroupBox();
            this.dgv_DanhSach = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.groupXuLyThe = new System.Windows.Forms.GroupBox();
            this.txtDes = new System.Windows.Forms.TextBox();
            this.lbMoTa = new System.Windows.Forms.Label();
            this.txtCard = new System.Windows.Forms.TextBox();
            this.lbMatheMoi = new System.Windows.Forms.Label();
            this.rdoRename = new System.Windows.Forms.RadioButton();
            this.rdoBlock = new System.Windows.Forms.RadioButton();
            this.cbAddBackList = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtError = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupThongTinThe.SuspendLayout();
            this.groupThongTinGiaoDich.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSach)).BeginInit();
            this.groupXuLyThe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtError)).BeginInit();
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
            // 
            // labLoaiThe
            // 
            this.labLoaiThe.AutoSize = true;
            this.labLoaiThe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labLoaiThe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labLoaiThe.Location = new System.Drawing.Point(153, 104);
            this.labLoaiThe.Name = "labLoaiThe";
            this.labLoaiThe.Size = new System.Drawing.Size(83, 20);
            this.labLoaiThe.TabIndex = 5;
            this.labLoaiThe.Text = "Loại thẻ:";
            // 
            // labTenTaiKhoan
            // 
            this.labTenTaiKhoan.AutoSize = true;
            this.labTenTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTenTaiKhoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labTenTaiKhoan.Location = new System.Drawing.Point(153, 65);
            this.labTenTaiKhoan.Name = "labTenTaiKhoan";
            this.labTenTaiKhoan.Size = new System.Drawing.Size(128, 20);
            this.labTenTaiKhoan.TabIndex = 4;
            this.labTenTaiKhoan.Text = "Tên tài khoản:";
            // 
            // labMaThe
            // 
            this.labMaThe.AutoSize = true;
            this.labMaThe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMaThe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labMaThe.Location = new System.Drawing.Point(153, 33);
            this.labMaThe.Name = "labMaThe";
            this.labMaThe.Size = new System.Drawing.Size(66, 20);
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
            this.groupThongTinGiaoDich.Controls.Add(this.dgv_DanhSach);
            this.groupThongTinGiaoDich.Location = new System.Drawing.Point(25, 188);
            this.groupThongTinGiaoDich.Name = "groupThongTinGiaoDich";
            this.groupThongTinGiaoDich.Size = new System.Drawing.Size(605, 303);
            this.groupThongTinGiaoDich.TabIndex = 1;
            this.groupThongTinGiaoDich.TabStop = false;
            this.groupThongTinGiaoDich.Text = "Thông tin giao dịch gần nhất:";
            // 
            // dgv_DanhSach
            // 
            this.dgv_DanhSach.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.dgv_DanhSach.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.dgv_DanhSach.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.True;
            this.dgv_DanhSach.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgv_DanhSach.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgv_DanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_DanhSach.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgv_DanhSach.Location = new System.Drawing.Point(3, 16);
            this.dgv_DanhSach.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_DanhSach.Name = "dgv_DanhSach";
            this.dgv_DanhSach.Size = new System.Drawing.Size(599, 284);
            this.dgv_DanhSach.TabIndex = 27;
            this.dgv_DanhSach.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.dgv_DanhSach_InitializeLayout);
            // 
            // groupXuLyThe
            // 
            this.groupXuLyThe.Controls.Add(this.txtDes);
            this.groupXuLyThe.Controls.Add(this.lbMoTa);
            this.groupXuLyThe.Controls.Add(this.txtCard);
            this.groupXuLyThe.Controls.Add(this.lbMatheMoi);
            this.groupXuLyThe.Controls.Add(this.rdoRename);
            this.groupXuLyThe.Controls.Add(this.rdoBlock);
            this.groupXuLyThe.Controls.Add(this.cbAddBackList);
            this.groupXuLyThe.Location = new System.Drawing.Point(648, 24);
            this.groupXuLyThe.Name = "groupXuLyThe";
            this.groupXuLyThe.Size = new System.Drawing.Size(273, 466);
            this.groupXuLyThe.TabIndex = 2;
            this.groupXuLyThe.TabStop = false;
            this.groupXuLyThe.Text = "Xử lý thẻ:";
            // 
            // txtDes
            // 
            this.txtDes.Location = new System.Drawing.Point(29, 245);
            this.txtDes.Multiline = true;
            this.txtDes.Name = "txtDes";
            this.txtDes.Size = new System.Drawing.Size(210, 49);
            this.txtDes.TabIndex = 9;
            // 
            // lbMoTa
            // 
            this.lbMoTa.AutoSize = true;
            this.lbMoTa.Location = new System.Drawing.Point(29, 220);
            this.lbMoTa.Name = "lbMoTa";
            this.lbMoTa.Size = new System.Drawing.Size(37, 13);
            this.lbMoTa.TabIndex = 8;
            this.lbMoTa.Text = "Mã tả:";
            // 
            // txtCard
            // 
            this.txtCard.Location = new System.Drawing.Point(29, 126);
            this.txtCard.Name = "txtCard";
            this.txtCard.Size = new System.Drawing.Size(210, 20);
            this.txtCard.TabIndex = 7;
            // 
            // lbMatheMoi
            // 
            this.lbMatheMoi.AutoSize = true;
            this.lbMatheMoi.Location = new System.Drawing.Point(29, 97);
            this.lbMatheMoi.Name = "lbMatheMoi";
            this.lbMatheMoi.Size = new System.Drawing.Size(62, 13);
            this.lbMatheMoi.TabIndex = 6;
            this.lbMatheMoi.Text = "Mã thẻ mới:";
            // 
            // rdoRename
            // 
            this.rdoRename.AutoSize = true;
            this.rdoRename.Location = new System.Drawing.Point(29, 64);
            this.rdoRename.Name = "rdoRename";
            this.rdoRename.Size = new System.Drawing.Size(78, 17);
            this.rdoRename.TabIndex = 2;
            this.rdoRename.Text = "Đổi thẻ mới";
            this.rdoRename.UseVisualStyleBackColor = true;
            this.rdoRename.CheckedChanged += new System.EventHandler(this.rdoRename_CheckedChanged);
            // 
            // rdoBlock
            // 
            this.rdoBlock.AutoSize = true;
            this.rdoBlock.Location = new System.Drawing.Point(29, 31);
            this.rdoBlock.Name = "rdoBlock";
            this.rdoBlock.Size = new System.Drawing.Size(68, 17);
            this.rdoBlock.TabIndex = 1;
            this.rdoBlock.Text = "Khóa thẻ";
            this.rdoBlock.UseVisualStyleBackColor = true;
            this.rdoBlock.CheckedChanged += new System.EventHandler(this.rdoBlock_CheckedChanged);
            // 
            // cbAddBackList
            // 
            this.cbAddBackList.AutoSize = true;
            this.cbAddBackList.Location = new System.Drawing.Point(29, 191);
            this.cbAddBackList.Name = "cbAddBackList";
            this.cbAddBackList.Size = new System.Drawing.Size(167, 17);
            this.cbAddBackList.TabIndex = 0;
            this.cbAddBackList.Text = "Thêm thẻ vào danh sách đen";
            this.cbAddBackList.UseVisualStyleBackColor = true;
            this.cbAddBackList.CheckedChanged += new System.EventHandler(this.cbAddBackList_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(705, 511);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(137, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Xử lý mất thẻ/ đổi thẻ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(848, 511);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtError
            // 
            this.txtError.ContainerControl = this;
            this.txtError.Icon = ((System.Drawing.Icon)(resources.GetObject("txtError.Icon")));
            // 
            // frmMatDoiThe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 558);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupXuLyThe);
            this.Controls.Add(this.groupThongTinGiaoDich);
            this.Controls.Add(this.groupThongTinThe);
            this.Name = "frmMatDoiThe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mất Thẻ/ Đổi Thẻ";
            this.Load += new System.EventHandler(this.frmMatDoiThe_Load);
            this.groupThongTinThe.ResumeLayout(false);
            this.groupThongTinThe.PerformLayout();
            this.groupThongTinGiaoDich.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSach)).EndInit();
            this.groupXuLyThe.ResumeLayout(false);
            this.groupXuLyThe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtError)).EndInit();
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
        private System.Windows.Forms.Label lbMoTa;
        private System.Windows.Forms.TextBox txtCard;
        private System.Windows.Forms.Label lbMatheMoi;
        private System.Windows.Forms.RadioButton rdoRename;
        private System.Windows.Forms.RadioButton rdoBlock;
        private System.Windows.Forms.CheckBox cbAddBackList;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDes;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ErrorProvider txtError;
        private Infragistics.Win.UltraWinGrid.UltraGrid dgv_DanhSach;
    }
}