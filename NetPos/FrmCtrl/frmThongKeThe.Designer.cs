namespace NetPos.FrmCtrl
{
    partial class frmThongKeThe
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
            this.dgv_DanhSach = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.pn_Main = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_DanhSachChitiet = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSach)).BeginInit();
            this.pn_Main.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSachChitiet)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_DanhSach
            // 
            this.dgv_DanhSach.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.dgv_DanhSach.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.dgv_DanhSach.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.True;
            this.dgv_DanhSach.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgv_DanhSach.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgv_DanhSach.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv_DanhSach.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgv_DanhSach.Location = new System.Drawing.Point(3, 16);
            this.dgv_DanhSach.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_DanhSach.Name = "dgv_DanhSach";
            this.dgv_DanhSach.Size = new System.Drawing.Size(1101, 147);
            this.dgv_DanhSach.TabIndex = 26;
            this.dgv_DanhSach.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.dgv_DanhSach_InitializeLayout);
            // 
            // pn_Main
            // 
            this.pn_Main.Controls.Add(this.groupBox1);
            this.pn_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_Main.Location = new System.Drawing.Point(0, 0);
            this.pn_Main.Name = "pn_Main";
            this.pn_Main.Size = new System.Drawing.Size(1107, 574);
            this.pn_Main.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.dgv_DanhSach);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1107, 574);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống kê thẻ:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 163);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1101, 408);
            this.panel1.TabIndex = 27;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_DanhSachChitiet);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1101, 408);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách thẻ chi tiết:";
            // 
            // dgv_DanhSachChitiet
            // 
            this.dgv_DanhSachChitiet.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.dgv_DanhSachChitiet.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.dgv_DanhSachChitiet.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.True;
            this.dgv_DanhSachChitiet.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgv_DanhSachChitiet.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgv_DanhSachChitiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_DanhSachChitiet.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgv_DanhSachChitiet.Location = new System.Drawing.Point(3, 16);
            this.dgv_DanhSachChitiet.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_DanhSachChitiet.Name = "dgv_DanhSachChitiet";
            this.dgv_DanhSachChitiet.Size = new System.Drawing.Size(1095, 389);
            this.dgv_DanhSachChitiet.TabIndex = 27;
            this.dgv_DanhSachChitiet.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.dgv_DanhSachChiTiet_InitializeLayout);
            // 
            // frmThongKeThe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pn_Main);
            this.Name = "frmThongKeThe";
            this.Size = new System.Drawing.Size(1107, 574);
            this.Load += new System.EventHandler(this.frmThongKeThe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSach)).EndInit();
            this.pn_Main.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSachChitiet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid dgv_DanhSach;
        private System.Windows.Forms.Panel pn_Main;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Infragistics.Win.UltraWinGrid.UltraGrid dgv_DanhSachChitiet;
    }
}
