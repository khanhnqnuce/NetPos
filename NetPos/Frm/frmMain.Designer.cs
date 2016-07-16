﻿namespace NetPos.Frm
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
            this.menuMatDoiThe = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTKThe = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBaoCaoDanhThuChiTiet = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBaoCaoTongHop = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSuKienCanhBao = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNhatKyLog = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDSNapTien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBackUpDuLieu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSua = new System.Windows.Forms.ToolStripMenuItem();
            this.menuXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuXuatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.pn_Main = new System.Windows.Forms.Panel();
            this.QLT = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDSThe = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDanhSachDen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTheTrungNhau = new System.Windows.Forms.ToolStripMenuItem();
            this.pn_Top.SuspendLayout();
            this.menuMain.SuspendLayout();
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
            this.QLT,
            this.menuThongKe,
            this.toolStripMenuItem2,
            this.menuThem,
            this.menuSua,
            this.menuXoa,
            this.menuMatDoiThe,
            this.toolStripMenuItem3,
            this.menuLoc,
            this.menuIn,
            this.menuXuatKhau,
            this.toolStripMenuItem1,
            this.menuThoat});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(1350, 24);
            this.menuMain.TabIndex = 8;
            this.menuMain.Text = "menuStrip1";
            // 
            // menuMatDoiThe
            // 
            this.menuMatDoiThe.Image = global::NetPos.Properties.Resources.Change_card;
            this.menuMatDoiThe.Name = "menuMatDoiThe";
            this.menuMatDoiThe.Size = new System.Drawing.Size(125, 20);
            this.menuMatDoiThe.Text = "Mất Thẻ/Đổi Thẻ";
            this.menuMatDoiThe.Click += new System.EventHandler(this.menuMatDoiThe_Click);
            // 
            // menuThongKe
            // 
            this.menuThongKe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuTKThe,
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
            // MenuTKThe
            // 
            this.MenuTKThe.Name = "MenuTKThe";
            this.MenuTKThe.Size = new System.Drawing.Size(226, 22);
            this.MenuTKThe.Text = "Thống kê Thẻ";
            this.MenuTKThe.Click += new System.EventHandler(this.MenuTKThe_Click);
            // 
            // menuBaoCaoDanhThuChiTiet
            // 
            this.menuBaoCaoDanhThuChiTiet.Name = "menuBaoCaoDanhThuChiTiet";
            this.menuBaoCaoDanhThuChiTiet.Size = new System.Drawing.Size(226, 22);
            this.menuBaoCaoDanhThuChiTiet.Text = "Báo cáo doanh thu chi tiết";
            this.menuBaoCaoDanhThuChiTiet.Click += new System.EventHandler(this.menuBaoCaoDanhThuChiTiet_Click);
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
            this.menuSuKienCanhBao.Click += new System.EventHandler(this.menuSuKienCanhBao_Click);
            // 
            // menuNhatKyLog
            // 
            this.menuNhatKyLog.Name = "menuNhatKyLog";
            this.menuNhatKyLog.Size = new System.Drawing.Size(226, 22);
            this.menuNhatKyLog.Text = "Nhật ký hệ thống log";
            this.menuNhatKyLog.Click += new System.EventHandler(this.menuNhatKyLog_Click);
            // 
            // menuDSNapTien
            // 
            this.menuDSNapTien.Name = "menuDSNapTien";
            this.menuDSNapTien.Size = new System.Drawing.Size(226, 22);
            this.menuDSNapTien.Text = "Danh sách nạp tiền cho thẻ";
            this.menuDSNapTien.Click += new System.EventHandler(this.menuDSNapTien_Click);
            // 
            // menuBackUpDuLieu
            // 
            this.menuBackUpDuLieu.Name = "menuBackUpDuLieu";
            this.menuBackUpDuLieu.Size = new System.Drawing.Size(226, 22);
            this.menuBackUpDuLieu.Text = "Dữ liệu Backup";
            this.menuBackUpDuLieu.Click += new System.EventHandler(this.menuBackUpDuLieu_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.Red;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Padding = new System.Windows.Forms.Padding(0);
            this.toolStripMenuItem2.Size = new System.Drawing.Size(14, 20);
            this.toolStripMenuItem2.Text = "|";
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
            this.menuXoa.Click += new System.EventHandler(this.menuXoa_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.ForeColor = System.Drawing.Color.Red;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Padding = new System.Windows.Forms.Padding(0);
            this.toolStripMenuItem3.Size = new System.Drawing.Size(14, 20);
            this.toolStripMenuItem3.Text = "|";
            // 
            // menuLoc
            // 
            this.menuLoc.Image = global::NetPos.Properties.Resources.Search;
            this.menuLoc.Name = "menuLoc";
            this.menuLoc.Size = new System.Drawing.Size(57, 20);
            this.menuLoc.Text = "Lọc ";
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
            this.menuXuatKhau.Size = new System.Drawing.Size(72, 20);
            this.menuXuatKhau.Text = "Xuất Excel";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.Red;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStripMenuItem1.Size = new System.Drawing.Size(14, 20);
            this.toolStripMenuItem1.Text = "|";
            // 
            // menuThoat
            // 
            this.menuThoat.Image = global::NetPos.Properties.Resources.Exit;
            this.menuThoat.Name = "menuThoat";
            this.menuThoat.Size = new System.Drawing.Size(66, 20);
            this.menuThoat.Text = "Thoát";
            this.menuThoat.Click += new System.EventHandler(this.menuThoat_Click);
            // 
            // pn_Main
            // 
            this.pn_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_Main.Location = new System.Drawing.Point(0, 34);
            this.pn_Main.Name = "pn_Main";
            this.pn_Main.Size = new System.Drawing.Size(1350, 655);
            this.pn_Main.TabIndex = 1;
            // 
            // QLT
            // 
            this.QLT.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDSThe,
            this.menuTheTrungNhau,
            this.menuDanhSachDen});
            this.QLT.Image = global::NetPos.Properties.Resources.Loading;
            this.QLT.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.QLT.Name = "QLT";
            this.QLT.Size = new System.Drawing.Size(96, 20);
            this.QLT.Text = "Quản lý thẻ";
            // 
            // menuDSThe
            // 
            this.menuDSThe.Image = global::NetPos.Properties.Resources.cards_icon;
            this.menuDSThe.Name = "menuDSThe";
            this.menuDSThe.Size = new System.Drawing.Size(156, 22);
            this.menuDSThe.Text = "Danh sách thẻ";
            this.menuDSThe.Click += new System.EventHandler(this.menuDSThe_Click);
            // 
            // menuDanhSachDen
            // 
            this.menuDanhSachDen.Image = global::NetPos.Properties.Resources.Black_List;
            this.menuDanhSachDen.Name = "menuDanhSachDen";
            this.menuDanhSachDen.Size = new System.Drawing.Size(156, 22);
            this.menuDanhSachDen.Text = "Danh Sách Đen";
            this.menuDanhSachDen.Click += new System.EventHandler(this.menuDanhSachDen_Click);
            // 
            // menuTheTrungNhau
            // 
            this.menuTheTrungNhau.Image = global::NetPos.Properties.Resources.Duplicate;
            this.menuTheTrungNhau.Name = "menuTheTrungNhau";
            this.menuTheTrungNhau.Size = new System.Drawing.Size(156, 22);
            this.menuTheTrungNhau.Text = "Thẻ trùng nhau";
            this.menuTheTrungNhau.Click += new System.EventHandler(this.menuTheTrungNhau_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 689);
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
        private System.Windows.Forms.ToolStripMenuItem menuThongKe;
        private System.Windows.Forms.ToolStripMenuItem menuBaoCaoDanhThuChiTiet;
        private System.Windows.Forms.ToolStripMenuItem menuBaoCaoTongHop;
        private System.Windows.Forms.ToolStripMenuItem menuSuKienCanhBao;
        private System.Windows.Forms.ToolStripMenuItem menuNhatKyLog;
        private System.Windows.Forms.ToolStripMenuItem menuDSNapTien;
        private System.Windows.Forms.ToolStripMenuItem menuBackUpDuLieu;
        private System.Windows.Forms.ToolStripMenuItem menuLoc;
        private System.Windows.Forms.ToolStripMenuItem menuIn;
        private System.Windows.Forms.ToolStripMenuItem menuXuatKhau;
        private System.Windows.Forms.ToolStripMenuItem menuThoat;
        private System.Windows.Forms.ToolStripMenuItem MenuTKThe;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem QLT;
        private System.Windows.Forms.ToolStripMenuItem menuDSThe;
        private System.Windows.Forms.ToolStripMenuItem menuDanhSachDen;
        private System.Windows.Forms.ToolStripMenuItem menuTheTrungNhau;




    }
}

