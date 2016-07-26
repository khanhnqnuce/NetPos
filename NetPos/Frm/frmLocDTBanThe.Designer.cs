namespace NetPos.Frm
{
    partial class frmLocDTBanThe
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboObject = new System.Windows.Forms.ComboBox();
            this.cboArea = new System.Windows.Forms.ComboBox();
            this.cboBuiding = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.datEndDate = new System.Windows.Forms.DateTimePicker();
            this.datStartDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboObject);
            this.groupBox2.Controls.Add(this.cboArea);
            this.groupBox2.Controls.Add(this.cboBuiding);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(398, 141);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng:";
            // 
            // cboObject
            // 
            this.cboObject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboObject.FormattingEnabled = true;
            this.cboObject.Location = new System.Drawing.Point(135, 95);
            this.cboObject.Name = "cboObject";
            this.cboObject.Size = new System.Drawing.Size(234, 21);
            this.cboObject.TabIndex = 6;
            // 
            // cboArea
            // 
            this.cboArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArea.FormattingEnabled = true;
            this.cboArea.Location = new System.Drawing.Point(135, 59);
            this.cboArea.Name = "cboArea";
            this.cboArea.Size = new System.Drawing.Size(234, 21);
            this.cboArea.TabIndex = 4;
            // 
            // cboBuiding
            // 
            this.cboBuiding.DisplayMember = "Name";
            this.cboBuiding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBuiding.FormattingEnabled = true;
            this.cboBuiding.Location = new System.Drawing.Point(135, 24);
            this.cboBuiding.Name = "cboBuiding";
            this.cboBuiding.Size = new System.Drawing.Size(234, 21);
            this.cboBuiding.TabIndex = 3;
            this.cboBuiding.ValueMember = "Code";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Đầu đọc:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Khu vực:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tòa nhà:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(243, 270);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Đồng ý";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(333, 271);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Hủy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.datEndDate);
            this.groupBox1.Controls.Add(this.datStartDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 82);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thời gian:";
            // 
            // datEndDate
            // 
            this.datEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datEndDate.Location = new System.Drawing.Point(131, 50);
            this.datEndDate.Name = "datEndDate";
            this.datEndDate.Size = new System.Drawing.Size(234, 20);
            this.datEndDate.TabIndex = 2;
            // 
            // datStartDate
            // 
            this.datStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datStartDate.Location = new System.Drawing.Point(131, 19);
            this.datStartDate.Name = "datStartDate";
            this.datStartDate.Size = new System.Drawing.Size(234, 20);
            this.datStartDate.TabIndex = 1;
            this.datStartDate.Value = new System.DateTime(2016, 7, 24, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến ngày:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày:";
            // 
            // frmLocDTBanThe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 303);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmLocDTBanThe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lọc doanh thu bán thẻ";
            this.Load += new System.EventHandler(this.frmLoc_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboObject;
        private System.Windows.Forms.ComboBox cboArea;
        private System.Windows.Forms.ComboBox cboBuiding;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker datEndDate;
        private System.Windows.Forms.DateTimePicker datStartDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}