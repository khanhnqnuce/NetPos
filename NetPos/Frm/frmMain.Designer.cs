namespace NetPos.Frm
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuThem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSua = new System.Windows.Forms.ToolStripMenuItem();
            this.menuXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMatDoiThe = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTheTrungNhau = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThongKeThe = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDanhSachDen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBaoCaoDanhThuChiTiet = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBaoCaoTongHop = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSuKienCanhBao = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNhatKyLog = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDSNapTien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBackUpDuLieu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNapLai = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuXuatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.groupLoc = new System.Windows.Forms.GroupBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewCard = new System.Windows.Forms.DataGridView();
            this.menuMain.SuspendLayout();
            this.groupLoc.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCard)).BeginInit();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuThem,
            this.menuSua,
            this.menuXoa,
            this.menuMatDoiThe,
            this.menuTheTrungNhau,
            this.menuThongKeThe,
            this.menuDanhSachDen,
            this.menuThongKe,
            this.menuLoc,
            this.menuNapLai,
            this.menuIn,
            this.menuXuatKhau,
            this.menuThoat});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(1350, 24);
            this.menuMain.TabIndex = 1;
            this.menuMain.Text = "menuStrip1";
            // 
            // menuThem
            // 
            this.menuThem.Image = global::NetPos.Properties.Resources.Add;
            this.menuThem.Name = "menuThem";
            this.menuThem.Size = new System.Drawing.Size(66, 20);
            this.menuThem.Text = "Thêm";
            this.menuThem.Click += new System.EventHandler(this.menuThem_Click);
            // 
            // menuSua
            // 
            this.menuSua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuSua.Image = global::NetPos.Properties.Resources.Modify;
            this.menuSua.Name = "menuSua";
            this.menuSua.Size = new System.Drawing.Size(54, 20);
            this.menuSua.Text = "Sửa";
            this.menuSua.Click += new System.EventHandler(this.menuSua_Click);
            // 
            // menuXoa
            // 
            this.menuXoa.Image = global::NetPos.Properties.Resources.Delete;
            this.menuXoa.Name = "menuXoa";
            this.menuXoa.Size = new System.Drawing.Size(55, 20);
            this.menuXoa.Text = "Xóa";
            // 
            // menuMatDoiThe
            // 
            this.menuMatDoiThe.Image = global::NetPos.Properties.Resources.Change_card;
            this.menuMatDoiThe.Name = "menuMatDoiThe";
            this.menuMatDoiThe.Size = new System.Drawing.Size(125, 20);
            this.menuMatDoiThe.Text = "Mất Thẻ/Đổi Thẻ";
            this.menuMatDoiThe.Click += new System.EventHandler(this.menuMatDoiThe_Click);
            // 
            // menuTheTrungNhau
            // 
            this.menuTheTrungNhau.AutoSize = false;
            this.menuTheTrungNhau.Image = global::NetPos.Properties.Resources.Duplicate;
            this.menuTheTrungNhau.Name = "menuTheTrungNhau";
            this.menuTheTrungNhau.Size = new System.Drawing.Size(120, 20);
            this.menuTheTrungNhau.Text = "Thẻ Trùng Nhau";
            this.menuTheTrungNhau.Click += new System.EventHandler(this.menuTheTrungNhau_Click);
            // 
            // menuThongKeThe
            // 
            this.menuThongKeThe.Image = global::NetPos.Properties.Resources.Line_Chart;
            this.menuThongKeThe.Name = "menuThongKeThe";
            this.menuThongKeThe.Size = new System.Drawing.Size(109, 20);
            this.menuThongKeThe.Text = "Thống Kê Thẻ";
            // 
            // menuDanhSachDen
            // 
            this.menuDanhSachDen.Image = global::NetPos.Properties.Resources.Black_List;
            this.menuDanhSachDen.Name = "menuDanhSachDen";
            this.menuDanhSachDen.Size = new System.Drawing.Size(115, 20);
            this.menuDanhSachDen.Text = "Danh Sách Đen";
            this.menuDanhSachDen.Click += new System.EventHandler(this.menuDanhSachDen_Click);
            // 
            // menuThongKe
            // 
            this.menuThongKe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBaoCaoDanhThuChiTiet,
            this.menuBaoCaoTongHop,
            this.menuSuKienCanhBao,
            this.menuNhatKyLog,
            this.menuDSNapTien,
            this.menuBackUpDuLieu});
            this.menuThongKe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuThongKe.Image = global::NetPos.Properties.Resources.Bar_Chart;
            this.menuThongKe.Name = "menuThongKe";
            this.menuThongKe.Size = new System.Drawing.Size(132, 20);
            this.menuThongKe.Text = "Thống kê/Báo cáo";
            this.menuThongKe.Click += new System.EventHandler(this.quảnLýThẻToolStripMenuItem_Click);
            // 
            // menuBaoCaoDanhThuChiTiet
            // 
            this.menuBaoCaoDanhThuChiTiet.Name = "menuBaoCaoDanhThuChiTiet";
            this.menuBaoCaoDanhThuChiTiet.Size = new System.Drawing.Size(226, 22);
            this.menuBaoCaoDanhThuChiTiet.Text = "Báo cáo doanh thu chi tiết";
            // 
            // menuBaoCaoTongHop
            // 
            this.menuBaoCaoTongHop.Name = "menuBaoCaoTongHop";
            this.menuBaoCaoTongHop.Size = new System.Drawing.Size(226, 22);
            this.menuBaoCaoTongHop.Text = "Báo cáo doanh thu tổng hợp";
            // 
            // menuSuKienCanhBao
            // 
            this.menuSuKienCanhBao.Name = "menuSuKienCanhBao";
            this.menuSuKienCanhBao.Size = new System.Drawing.Size(226, 22);
            this.menuSuKienCanhBao.Text = "Sự kiện cảnh báo";
            // 
            // menuNhatKyLog
            // 
            this.menuNhatKyLog.Name = "menuNhatKyLog";
            this.menuNhatKyLog.Size = new System.Drawing.Size(226, 22);
            this.menuNhatKyLog.Text = "Nhật ký hệ thống log";
            // 
            // menuDSNapTien
            // 
            this.menuDSNapTien.Name = "menuDSNapTien";
            this.menuDSNapTien.Size = new System.Drawing.Size(226, 22);
            this.menuDSNapTien.Text = "Danh sách nạp tiền cho thẻ";
            // 
            // menuBackUpDuLieu
            // 
            this.menuBackUpDuLieu.Name = "menuBackUpDuLieu";
            this.menuBackUpDuLieu.Size = new System.Drawing.Size(226, 22);
            this.menuBackUpDuLieu.Text = "Dữ liệu Backup";
            // 
            // menuLoc
            // 
            this.menuLoc.Name = "menuLoc";
            this.menuLoc.Size = new System.Drawing.Size(41, 20);
            this.menuLoc.Text = "Lọc ";
            // 
            // menuNapLai
            // 
            this.menuNapLai.Image = global::NetPos.Properties.Resources.Load;
            this.menuNapLai.Name = "menuNapLai";
            this.menuNapLai.Size = new System.Drawing.Size(78, 20);
            this.menuNapLai.Text = "Nạp Lại ";
            // 
            // menuIn
            // 
            this.menuIn.Image = global::NetPos.Properties.Resources.Print;
            this.menuIn.Name = "menuIn";
            this.menuIn.Size = new System.Drawing.Size(45, 20);
            this.menuIn.Text = "In";
            // 
            // menuXuatKhau
            // 
            this.menuXuatKhau.Name = "menuXuatKhau";
            this.menuXuatKhau.Size = new System.Drawing.Size(73, 20);
            this.menuXuatKhau.Text = "Xuất Khẩu";
            // 
            // menuThoat
            // 
            this.menuThoat.Image = global::NetPos.Properties.Resources.Exit;
            this.menuThoat.Name = "menuThoat";
            this.menuThoat.Size = new System.Drawing.Size(66, 20);
            this.menuThoat.Text = "Thoát";
            this.menuThoat.Click += new System.EventHandler(this.menuThoat_Click);
            // 
            // groupLoc
            // 
            this.groupLoc.Controls.Add(this.btnTimKiem);
            this.groupLoc.Controls.Add(this.comboBox1);
            this.groupLoc.Controls.Add(this.label4);
            this.groupLoc.Controls.Add(this.textBox3);
            this.groupLoc.Controls.Add(this.label3);
            this.groupLoc.Controls.Add(this.textBox2);
            this.groupLoc.Controls.Add(this.label2);
            this.groupLoc.Controls.Add(this.textBox1);
            this.groupLoc.Controls.Add(this.label1);
            this.groupLoc.Location = new System.Drawing.Point(12, 27);
            this.groupLoc.Name = "groupLoc";
            this.groupLoc.Size = new System.Drawing.Size(1326, 52);
            this.groupLoc.TabIndex = 4;
            this.groupLoc.TabStop = false;
            this.groupLoc.Text = "Tìm kiếm:";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btnTimKiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnTimKiem.Location = new System.Drawing.Point(1064, 18);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 8;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(883, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(804, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Loại thẻ:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(646, 16);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(117, 20);
            this.textBox3.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(546, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tên tài khoản:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(391, 19);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(117, 20);
            this.textBox2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã khách hàng:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(116, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(117, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Thẻ:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewCard);
            this.groupBox1.Location = new System.Drawing.Point(12, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1326, 655);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách Thẻ:";
            // 
            // dataGridViewCard
            // 
            this.dataGridViewCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCard.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewCard.Name = "dataGridViewCard";
            this.dataGridViewCard.Size = new System.Drawing.Size(1314, 626);
            this.dataGridViewCard.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 742);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupLoc);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMain;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NetPOS CardLib";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.groupLoc.ResumeLayout(false);
            this.groupLoc.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuThongKe;
        private System.Windows.Forms.ToolStripMenuItem menuBaoCaoTongHop;
        private System.Windows.Forms.ToolStripMenuItem menuSuKienCanhBao;
        private System.Windows.Forms.ToolStripMenuItem menuSua;
        private System.Windows.Forms.ToolStripMenuItem menuXoa;
        private System.Windows.Forms.ToolStripMenuItem menuMatDoiThe;
        private System.Windows.Forms.ToolStripMenuItem menuTheTrungNhau;
        private System.Windows.Forms.ToolStripMenuItem menuThongKeThe;
        private System.Windows.Forms.ToolStripMenuItem menuDanhSachDen;
        private System.Windows.Forms.ToolStripMenuItem menuLoc;
        private System.Windows.Forms.ToolStripMenuItem menuNapLai;
        private System.Windows.Forms.ToolStripMenuItem menuIn;
        private System.Windows.Forms.ToolStripMenuItem menuXuatKhau;
        private System.Windows.Forms.ToolStripMenuItem menuThoat;
        private System.Windows.Forms.ToolStripMenuItem menuBaoCaoDanhThuChiTiet;
        private System.Windows.Forms.ToolStripMenuItem menuThem;
        private System.Windows.Forms.GroupBox groupLoc;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dataGridViewCard;
        private System.Windows.Forms.ToolStripMenuItem menuNhatKyLog;
        private System.Windows.Forms.ToolStripMenuItem menuDSNapTien;
        private System.Windows.Forms.ToolStripMenuItem menuBackUpDuLieu;



    }
}

