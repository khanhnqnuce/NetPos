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
            this.pn_Top = new System.Windows.Forms.Panel();
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
            this.pn_Main = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_DanhSach = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.pn_Top.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.pn_Main.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // pn_Top
            // 
            this.pn_Top.Controls.Add(this.menuMain);
            this.pn_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_Top.Location = new System.Drawing.Point(0, 0);
            this.pn_Top.Name = "pn_Top";
            this.pn_Top.Size = new System.Drawing.Size(1350, 34);
            this.pn_Top.TabIndex = 0;
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
            this.menuMain.TabIndex = 8;
            this.menuMain.Text = "menuStrip1";
            // 
            // menuThem
            // 
            this.menuThem.Image = global::NetPos.Properties.Resources.Add;
            this.menuThem.Name = "menuThem";
            this.menuThem.Size = new System.Drawing.Size(66, 20);
            this.menuThem.Text = "Thêm";
            // 
            // menuSua
            // 
            this.menuSua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuSua.Image = global::NetPos.Properties.Resources.Modify;
            this.menuSua.Name = "menuSua";
            this.menuSua.Size = new System.Drawing.Size(54, 20);
            this.menuSua.Text = "Sửa";
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
            // 
            // menuTheTrungNhau
            // 
            this.menuTheTrungNhau.AutoSize = false;
            this.menuTheTrungNhau.Image = global::NetPos.Properties.Resources.Duplicate;
            this.menuTheTrungNhau.Name = "menuTheTrungNhau";
            this.menuTheTrungNhau.Size = new System.Drawing.Size(120, 20);
            this.menuTheTrungNhau.Text = "Thẻ Trùng Nhau";
            // 
            // menuThongKeThe
            // 
            this.menuThongKeThe.Image = global::NetPos.Properties.Resources.Line_Chart;
            this.menuThongKeThe.Name = "menuThongKeThe";
            this.menuThongKeThe.Size = new System.Drawing.Size(109, 20);
            this.menuThongKeThe.Text = "Thống Kê Thẻ";
            this.menuThongKeThe.Click += new System.EventHandler(this.menuThongKeThe_Click);
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
            // 
            // pn_Main
            // 
            this.pn_Main.Controls.Add(this.groupBox1);
            this.pn_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_Main.Location = new System.Drawing.Point(0, 34);
            this.pn_Main.Name = "pn_Main";
            this.pn_Main.Size = new System.Drawing.Size(1350, 708);
            this.pn_Main.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_DanhSach);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1350, 708);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách Thẻ:";
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
            this.dgv_DanhSach.Size = new System.Drawing.Size(1344, 689);
            this.dgv_DanhSach.TabIndex = 26;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 742);
            this.Controls.Add(this.pn_Main);
            this.Controls.Add(this.pn_Top);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NetPOS CardLib";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pn_Top.ResumeLayout(false);
            this.pn_Top.PerformLayout();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.pn_Main.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_Top;
        private System.Windows.Forms.Panel pn_Main;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuThem;
        private System.Windows.Forms.ToolStripMenuItem menuSua;
        private System.Windows.Forms.ToolStripMenuItem menuXoa;
        private System.Windows.Forms.ToolStripMenuItem menuMatDoiThe;
        private System.Windows.Forms.ToolStripMenuItem menuTheTrungNhau;
        private System.Windows.Forms.ToolStripMenuItem menuThongKeThe;
        private System.Windows.Forms.ToolStripMenuItem menuDanhSachDen;
        private System.Windows.Forms.ToolStripMenuItem menuThongKe;
        private System.Windows.Forms.ToolStripMenuItem menuBaoCaoDanhThuChiTiet;
        private System.Windows.Forms.ToolStripMenuItem menuBaoCaoTongHop;
        private System.Windows.Forms.ToolStripMenuItem menuSuKienCanhBao;
        private System.Windows.Forms.ToolStripMenuItem menuNhatKyLog;
        private System.Windows.Forms.ToolStripMenuItem menuDSNapTien;
        private System.Windows.Forms.ToolStripMenuItem menuBackUpDuLieu;
        private System.Windows.Forms.ToolStripMenuItem menuLoc;
        private System.Windows.Forms.ToolStripMenuItem menuNapLai;
        private System.Windows.Forms.ToolStripMenuItem menuIn;
        private System.Windows.Forms.ToolStripMenuItem menuXuatKhau;
        private System.Windows.Forms.ToolStripMenuItem menuThoat;
        private System.Windows.Forms.GroupBox groupBox1;
        private Infragistics.Win.UltraWinGrid.UltraGrid dgv_DanhSach;




    }
}

