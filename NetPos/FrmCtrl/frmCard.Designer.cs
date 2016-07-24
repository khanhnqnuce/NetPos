namespace NetPos.FrmCtrl
{
    partial class frmCard
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
            this.components = new System.ComponentModel.Container();
            PerpetuumSoft.Reporting.Export.ExtraParameters extraParameters1 = new PerpetuumSoft.Reporting.Export.ExtraParameters();
            PerpetuumSoft.Reporting.Export.ExtraParameters extraParameters2 = new PerpetuumSoft.Reporting.Export.ExtraParameters();
            this.pn_Main = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_DanhSach = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.cboTypeCard = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaKhachHang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaThe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pn_Top = new System.Windows.Forms.Panel();
            this.groupLoc = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.rpCard = new PerpetuumSoft.Reporting.Components.FileReportSlot(this.components);
            this.pdfExportFilter1 = new PerpetuumSoft.Reporting.Export.Pdf.PdfExportFilter(this.components);
            this.excelExportFilter1 = new PerpetuumSoft.Reporting.Export.OpenXML.ExcelExportFilter(this.components);
            this.reportManager1 = new PerpetuumSoft.Reporting.Components.ReportManager(this.components);
            this.rptCard = new PerpetuumSoft.Reporting.Components.FileReportSlot(this.components);
            this.pn_Main.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSach)).BeginInit();
            this.pn_Top.SuspendLayout();
            this.groupLoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_Main
            // 
            this.pn_Main.Controls.Add(this.groupBox1);
            this.pn_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_Main.Location = new System.Drawing.Point(0, 63);
            this.pn_Main.Name = "pn_Main";
            this.pn_Main.Size = new System.Drawing.Size(1360, 592);
            this.pn_Main.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_DanhSach);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1360, 592);
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
            this.dgv_DanhSach.Size = new System.Drawing.Size(1354, 573);
            this.dgv_DanhSach.TabIndex = 26;
            this.dgv_DanhSach.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.dgv_DanhSach_InitializeLayout);
            this.dgv_DanhSach.DoubleClickCell += new Infragistics.Win.UltraWinGrid.DoubleClickCellEventHandler(this.dgv_DanhSach_DoubleClickCell);
            this.dgv_DanhSach.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgv_DanhSach_MouseClick);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btnTimKiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnTimKiem.Location = new System.Drawing.Point(1060, 18);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 8;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // cboTypeCard
            // 
            this.cboTypeCard.FormattingEnabled = true;
            this.cboTypeCard.Location = new System.Drawing.Point(883, 19);
            this.cboTypeCard.Name = "cboTypeCard";
            this.cboTypeCard.Size = new System.Drawing.Size(121, 21);
            this.cboTypeCard.TabIndex = 7;
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
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(646, 18);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(117, 20);
            this.txtName.TabIndex = 5;
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
            // txtMaKhachHang
            // 
            this.txtMaKhachHang.Location = new System.Drawing.Point(391, 19);
            this.txtMaKhachHang.Name = "txtMaKhachHang";
            this.txtMaKhachHang.Size = new System.Drawing.Size(117, 20);
            this.txtMaKhachHang.TabIndex = 3;
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
            // txtMaThe
            // 
            this.txtMaThe.Location = new System.Drawing.Point(116, 19);
            this.txtMaThe.Name = "txtMaThe";
            this.txtMaThe.Size = new System.Drawing.Size(117, 20);
            this.txtMaThe.TabIndex = 1;
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
            // pn_Top
            // 
            this.pn_Top.Controls.Add(this.groupLoc);
            this.pn_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_Top.Location = new System.Drawing.Point(0, 0);
            this.pn_Top.Name = "pn_Top";
            this.pn_Top.Size = new System.Drawing.Size(1360, 63);
            this.pn_Top.TabIndex = 2;
            // 
            // groupLoc
            // 
            this.groupLoc.Controls.Add(this.btnReset);
            this.groupLoc.Controls.Add(this.btnTimKiem);
            this.groupLoc.Controls.Add(this.cboTypeCard);
            this.groupLoc.Controls.Add(this.label4);
            this.groupLoc.Controls.Add(this.txtName);
            this.groupLoc.Controls.Add(this.label3);
            this.groupLoc.Controls.Add(this.txtMaKhachHang);
            this.groupLoc.Controls.Add(this.label2);
            this.groupLoc.Controls.Add(this.txtMaThe);
            this.groupLoc.Controls.Add(this.label1);
            this.groupLoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupLoc.Location = new System.Drawing.Point(0, 0);
            this.groupLoc.Name = "groupLoc";
            this.groupLoc.Size = new System.Drawing.Size(1360, 63);
            this.groupLoc.TabIndex = 9;
            this.groupLoc.TabStop = false;
            this.groupLoc.Text = "Tìm kiếm:";
            // 
            // btnReset
            // 
            this.btnReset.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnReset.Location = new System.Drawing.Point(1154, 18);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // rpCard
            // 
            this.rpCard.FilePath = "D:\\qlsv-khanhnq\\FDI\\NetPos\\trunk\\NetPos\\bin\\Debug\\Reports\\rpCard.rst";
            this.rpCard.ReportName = "";
            this.rpCard.ReportScriptType = null;
            // 
            // pdfExportFilter1
            // 
            this.pdfExportFilter1.ChangePermissionsPassword = null;
            this.pdfExportFilter1.Compress = true;
            this.pdfExportFilter1.ExtraParameters = extraParameters1;
            this.pdfExportFilter1.UserPassword = null;
            // 
            // excelExportFilter1
            // 
            this.excelExportFilter1.ExportInLargePage = true;
            this.excelExportFilter1.ExportInOnePage = true;
            this.excelExportFilter1.ExportWithoutPageDelimeters = true;
            this.excelExportFilter1.ExtraParameters = extraParameters2;
            // 
            // reportManager1
            // 
            this.reportManager1.DataSources = new PerpetuumSoft.Reporting.Components.ObjectPointerCollection(new string[0], new object[0]);
            this.reportManager1.Reports.AddRange(new PerpetuumSoft.Reporting.Components.ReportSlot[] {
            this.rptCard});
            // 
            // rptCard
            // 
            this.rptCard.FilePath = "D:\\qlsv-khanhnq\\FDI\\NetPos\\trunk\\NetPos\\Reports\\rpCard.rst";
            this.rptCard.ReportName = "";
            this.rptCard.ReportScriptType = typeof(PerpetuumSoft.Reporting.Rendering.ReportScriptBase);
            // 
            // frmCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pn_Main);
            this.Controls.Add(this.pn_Top);
            this.Name = "frmCard";
            this.Size = new System.Drawing.Size(1360, 655);
            this.Load += new System.EventHandler(this.frmCard_Load);
            this.pn_Main.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSach)).EndInit();
            this.pn_Top.ResumeLayout(false);
            this.groupLoc.ResumeLayout(false);
            this.groupLoc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_Main;
        private System.Windows.Forms.GroupBox groupBox1;
        private Infragistics.Win.UltraWinGrid.UltraGrid dgv_DanhSach;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.ComboBox cboTypeCard;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaKhachHang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaThe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pn_Top;
        private System.Windows.Forms.GroupBox groupLoc;
        private System.Windows.Forms.Button btnReset; private PerpetuumSoft.Reporting.Components.ReportManager reportManager;
        private PerpetuumSoft.Reporting.Export.Pdf.PdfExportFilter pdfExportFilter1;
        private PerpetuumSoft.Reporting.Export.OpenXML.ExcelExportFilter excelExportFilter1;
        private PerpetuumSoft.Reporting.Components.FileReportSlot rpCard;
        private PerpetuumSoft.Reporting.Components.ReportManager reportManager1;
        private PerpetuumSoft.Reporting.Components.FileReportSlot rptCard;
    }
}
