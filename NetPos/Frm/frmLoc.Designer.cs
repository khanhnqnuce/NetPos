namespace NetPos.Frm
{
    partial class frmLoc
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.datEndDate = new System.Windows.Forms.DateTimePicker();
            this.datStartDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.cboUser = new System.Windows.Forms.ComboBox();
            this.cboTypeCard = new System.Windows.Forms.ComboBox();
            this.cboEventCode = new System.Windows.Forms.ComboBox();
            this.cboFunction = new System.Windows.Forms.ComboBox();
            this.cboObject = new System.Windows.Forms.ComboBox();
            this.cboPC = new System.Windows.Forms.ComboBox();
            this.cboArea = new System.Windows.Forms.ComboBox();
            this.cboBuiding = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
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
            this.groupBox1.TabIndex = 0;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCardNumber);
            this.groupBox2.Controls.Add(this.cboUser);
            this.groupBox2.Controls.Add(this.cboTypeCard);
            this.groupBox2.Controls.Add(this.cboEventCode);
            this.groupBox2.Controls.Add(this.cboFunction);
            this.groupBox2.Controls.Add(this.cboObject);
            this.groupBox2.Controls.Add(this.cboPC);
            this.groupBox2.Controls.Add(this.cboArea);
            this.groupBox2.Controls.Add(this.cboBuiding);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(398, 352);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng:";
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.Location = new System.Drawing.Point(136, 277);
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(234, 20);
            this.txtCardNumber.TabIndex = 10;
            // 
            // cboUser
            // 
            this.cboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUser.FormattingEnabled = true;
            this.cboUser.Location = new System.Drawing.Point(136, 311);
            this.cboUser.Name = "cboUser";
            this.cboUser.Size = new System.Drawing.Size(234, 21);
            this.cboUser.TabIndex = 12;
            // 
            // cboTypeCard
            // 
            this.cboTypeCard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTypeCard.FormattingEnabled = true;
            this.cboTypeCard.Location = new System.Drawing.Point(135, 245);
            this.cboTypeCard.Name = "cboTypeCard";
            this.cboTypeCard.Size = new System.Drawing.Size(234, 21);
            this.cboTypeCard.TabIndex = 9;
            // 
            // cboEventCode
            // 
            this.cboEventCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEventCode.FormattingEnabled = true;
            this.cboEventCode.Location = new System.Drawing.Point(135, 208);
            this.cboEventCode.Name = "cboEventCode";
            this.cboEventCode.Size = new System.Drawing.Size(234, 21);
            this.cboEventCode.TabIndex = 8;
            // 
            // cboFunction
            // 
            this.cboFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFunction.FormattingEnabled = true;
            this.cboFunction.Location = new System.Drawing.Point(135, 170);
            this.cboFunction.Name = "cboFunction";
            this.cboFunction.Size = new System.Drawing.Size(234, 21);
            this.cboFunction.TabIndex = 7;
            // 
            // cboObject
            // 
            this.cboObject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboObject.FormattingEnabled = true;
            this.cboObject.Location = new System.Drawing.Point(135, 133);
            this.cboObject.Name = "cboObject";
            this.cboObject.Size = new System.Drawing.Size(234, 21);
            this.cboObject.TabIndex = 6;
            // 
            // cboPC
            // 
            this.cboPC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPC.FormattingEnabled = true;
            this.cboPC.Location = new System.Drawing.Point(135, 98);
            this.cboPC.Name = "cboPC";
            this.cboPC.Size = new System.Drawing.Size(234, 21);
            this.cboPC.TabIndex = 5;
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 314);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Nhân viên bán vé:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 283);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Thẻ:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 250);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Loại thẻ:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 212);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Sự kiện:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Chức năng:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Đầu đọc:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Máy tính:";
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
            this.button1.Location = new System.Drawing.Point(244, 472);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Đồng ý";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(335, 472);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Hủy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmLoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 508);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmLoc";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lọc danh sách";
            this.Load += new System.EventHandler(this.frmLoc_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker datEndDate;
        private System.Windows.Forms.DateTimePicker datStartDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboUser;
        private System.Windows.Forms.ComboBox cboTypeCard;
        private System.Windows.Forms.ComboBox cboEventCode;
        private System.Windows.Forms.ComboBox cboFunction;
        private System.Windows.Forms.ComboBox cboObject;
        private System.Windows.Forms.ComboBox cboPC;
        private System.Windows.Forms.ComboBox cboArea;
        private System.Windows.Forms.ComboBox cboBuiding;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtCardNumber;
    }
}