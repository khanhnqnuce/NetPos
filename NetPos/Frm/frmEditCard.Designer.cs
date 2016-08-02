namespace NetPos.Frm
{
    partial class frmEditCard
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBalance = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cboCardType = new System.Windows.Forms.ComboBox();
            this.txtCusName = new System.Windows.Forms.TextBox();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.txtCusCode = new System.Windows.Forms.TextBox();
            this.cbKhoa = new System.Windows.Forms.RadioButton();
            this.cbPhatH = new System.Windows.Forms.RadioButton();
            this.cbChuaPH = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtBalance)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Loại thẻ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Số dư tài khoản:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Tên tài khoản:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Mã thẻ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Mã khách hàng:";
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(102, 124);
            this.txtBalance.MaskInput = "{LOC}nnn,nnn,nnn";
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.txtBalance.PromptChar = ' ';
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(227, 21);
            this.txtBalance.TabIndex = 49;
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.Location = new System.Drawing.Point(254, 261);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(75, 23);
            this.btnHuyBo.TabIndex = 48;
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(162, 261);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 47;
            this.btnSave.Text = "Lưu lại";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cboCardType
            // 
            this.cboCardType.DisplayMember = "Name";
            this.cboCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCardType.FormattingEnabled = true;
            this.cboCardType.Location = new System.Drawing.Point(102, 158);
            this.cboCardType.Name = "cboCardType";
            this.cboCardType.Size = new System.Drawing.Size(227, 21);
            this.cboCardType.TabIndex = 42;
            this.cboCardType.ValueMember = "Code";
            // 
            // txtCusName
            // 
            this.txtCusName.Location = new System.Drawing.Point(102, 97);
            this.txtCusName.Name = "txtCusName";
            this.txtCusName.Size = new System.Drawing.Size(227, 20);
            this.txtCusName.TabIndex = 41;
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.Location = new System.Drawing.Point(102, 31);
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.ReadOnly = true;
            this.txtCardNumber.Size = new System.Drawing.Size(227, 20);
            this.txtCardNumber.TabIndex = 40;
            // 
            // txtCusCode
            // 
            this.txtCusCode.Location = new System.Drawing.Point(102, 64);
            this.txtCusCode.Name = "txtCusCode";
            this.txtCusCode.Size = new System.Drawing.Size(227, 20);
            this.txtCusCode.TabIndex = 39;
            // 
            // cbKhoa
            // 
            this.cbKhoa.AutoSize = true;
            this.cbKhoa.Location = new System.Drawing.Point(102, 227);
            this.cbKhoa.Name = "cbKhoa";
            this.cbKhoa.Size = new System.Drawing.Size(68, 17);
            this.cbKhoa.TabIndex = 50;
            this.cbKhoa.TabStop = true;
            this.cbKhoa.Text = "Khóa thẻ";
            this.cbKhoa.UseVisualStyleBackColor = true;
            // 
            // cbPhatH
            // 
            this.cbPhatH.AutoSize = true;
            this.cbPhatH.Location = new System.Drawing.Point(102, 195);
            this.cbPhatH.Name = "cbPhatH";
            this.cbPhatH.Size = new System.Drawing.Size(90, 17);
            this.cbPhatH.TabIndex = 50;
            this.cbPhatH.TabStop = true;
            this.cbPhatH.Text = "Đã phát hành";
            this.cbPhatH.UseVisualStyleBackColor = true;
            // 
            // cbChuaPH
            // 
            this.cbChuaPH.AutoSize = true;
            this.cbChuaPH.Location = new System.Drawing.Point(224, 195);
            this.cbChuaPH.Name = "cbChuaPH";
            this.cbChuaPH.Size = new System.Drawing.Size(101, 17);
            this.cbChuaPH.TabIndex = 50;
            this.cbChuaPH.TabStop = true;
            this.cbChuaPH.Text = "Chưa phát hành";
            this.cbChuaPH.UseVisualStyleBackColor = true;
            // 
            // frmEditCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 295);
            this.Controls.Add(this.cbChuaPH);
            this.Controls.Add(this.cbPhatH);
            this.Controls.Add(this.cbKhoa);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.btnHuyBo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboCardType);
            this.Controls.Add(this.txtCusName);
            this.Controls.Add(this.txtCardNumber);
            this.Controls.Add(this.txtCusCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmEditCard";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sửa thông tin thẻ";
            this.Load += new System.EventHandler(this.frmEditCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtBalance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtBalance;
        private System.Windows.Forms.Button btnHuyBo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cboCardType;
        private System.Windows.Forms.TextBox txtCusName;
        private System.Windows.Forms.TextBox txtCardNumber;
        private System.Windows.Forms.TextBox txtCusCode;
        private System.Windows.Forms.RadioButton cbKhoa;
        private System.Windows.Forms.RadioButton cbPhatH;
        private System.Windows.Forms.RadioButton cbChuaPH;
    }
}