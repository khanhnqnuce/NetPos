namespace NetPos.Frm
{
    partial class frmTheTrungNhau
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNapLai = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIn = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuXuatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuXoa,
            this.menuNapLai,
            this.menuIn,
            this.MenuXuatKhau,
            this.menuThoat});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(888, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuXoa
            // 
            this.menuXoa.Name = "menuXoa";
            this.menuXoa.Size = new System.Drawing.Size(39, 20);
            this.menuXoa.Text = "Xóa";
            // 
            // menuNapLai
            // 
            this.menuNapLai.Name = "menuNapLai";
            this.menuNapLai.Size = new System.Drawing.Size(59, 20);
            this.menuNapLai.Text = "Nạp Lại";
            // 
            // menuIn
            // 
            this.menuIn.Name = "menuIn";
            this.menuIn.Size = new System.Drawing.Size(29, 20);
            this.menuIn.Text = "In";
            // 
            // MenuXuatKhau
            // 
            this.MenuXuatKhau.Name = "MenuXuatKhau";
            this.MenuXuatKhau.Size = new System.Drawing.Size(72, 20);
            this.MenuXuatKhau.Text = "Xuất khẩu";
            // 
            // menuThoat
            // 
            this.menuThoat.Name = "menuThoat";
            this.menuThoat.Size = new System.Drawing.Size(50, 20);
            this.menuThoat.Text = "Thoát";
            this.menuThoat.Click += new System.EventHandler(this.menuThoat_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(864, 472);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách thẻ trùng nhau: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 524);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Số Lượng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 524);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Số Lượng:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(852, 447);
            this.dataGridView1.TabIndex = 0;
            // 
            // frmTheTrungNhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 547);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmTheTrungNhau";
            this.Text = "Danh sách thẻ trùng nhau";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuXoa;
        private System.Windows.Forms.ToolStripMenuItem menuNapLai;
        private System.Windows.Forms.ToolStripMenuItem menuIn;
        private System.Windows.Forms.ToolStripMenuItem MenuXuatKhau;
        private System.Windows.Forms.ToolStripMenuItem menuThoat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}