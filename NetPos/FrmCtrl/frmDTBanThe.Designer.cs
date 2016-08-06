namespace NetPos.FrmCtrl
{
    partial class frmDTBanThe
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_DanhSachChiTiet = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.pn_Main = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_DanhSach = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSachChiTiet)).BeginInit();
            this.pn_Main.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(875, 576);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Báo cáo doanh thu bán thẻ:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.dgv_DanhSachChiTiet);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(869, 557);
            this.panel2.TabIndex = 28;
            // 
            // dgv_DanhSachChiTiet
            // 
            this.dgv_DanhSachChiTiet.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.dgv_DanhSachChiTiet.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.dgv_DanhSachChiTiet.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.True;
            this.dgv_DanhSachChiTiet.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgv_DanhSachChiTiet.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgv_DanhSachChiTiet.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv_DanhSachChiTiet.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgv_DanhSachChiTiet.Location = new System.Drawing.Point(0, 0);
            this.dgv_DanhSachChiTiet.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_DanhSachChiTiet.Name = "dgv_DanhSachChiTiet";
            this.dgv_DanhSachChiTiet.Size = new System.Drawing.Size(869, 110);
            this.dgv_DanhSachChiTiet.TabIndex = 27;
            this.dgv_DanhSachChiTiet.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.dgv_DanhSachChiTiet_InitializeLayout);
            // 
            // pn_Main
            // 
            this.pn_Main.Controls.Add(this.groupBox1);
            this.pn_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_Main.Location = new System.Drawing.Point(0, 0);
            this.pn_Main.Name = "pn_Main";
            this.pn_Main.Size = new System.Drawing.Size(875, 576);
            this.pn_Main.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(869, 447);
            this.panel1.TabIndex = 28;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_DanhSach);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(869, 447);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách chi tiết:";
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
            this.dgv_DanhSach.Size = new System.Drawing.Size(863, 428);
            this.dgv_DanhSach.TabIndex = 28;
            this.dgv_DanhSach.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.dgv_DanhSach_InitializeLayout_1);
            // 
            // frmDTBanThe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pn_Main);
            this.Name = "frmDTBanThe";
            this.Size = new System.Drawing.Size(875, 576);
            this.Load += new System.EventHandler(this.frmDTBanThe_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSachChiTiet)).EndInit();
            this.pn_Main.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pn_Main;
        private System.Windows.Forms.Panel panel2;
        private Infragistics.Win.UltraWinGrid.UltraGrid dgv_DanhSachChiTiet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Infragistics.Win.UltraWinGrid.UltraGrid dgv_DanhSach;
    }
}
