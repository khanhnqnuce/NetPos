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
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBalance = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDiemThuong = new System.Windows.Forms.TextBox();
            this.cboCardType = new System.Windows.Forms.ComboBox();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.chkIsEdit = new System.Windows.Forms.CheckBox();
            this.chkIsRelease = new System.Windows.Forms.CheckBox();
            this.chkIsLockCard = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtBalance)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(143, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(220, 24);
            this.label7.TabIndex = 38;
            this.label7.Text = "Cập Nhật Thông Tin Thẻ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(101, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Điểm thưởng:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(123, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Loại thẻ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(86, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Số dư tài khoản:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Tên tài khoản:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Mã thẻ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Mã khách hàng:";
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(177, 177);
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
            this.btnHuyBo.Location = new System.Drawing.Point(267, 392);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(75, 23);
            this.btnHuyBo.TabIndex = 48;
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(177, 392);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 47;
            this.btnSave.Text = "Lưu lại";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDiemThuong
            // 
            this.txtDiemThuong.Location = new System.Drawing.Point(177, 244);
            this.txtDiemThuong.Name = "txtDiemThuong";
            this.txtDiemThuong.Size = new System.Drawing.Size(227, 20);
            this.txtDiemThuong.TabIndex = 43;
            // 
            // cboCardType
            // 
            this.cboCardType.DisplayMember = "Name";
            this.cboCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCardType.FormattingEnabled = true;
            this.cboCardType.Location = new System.Drawing.Point(177, 211);
            this.cboCardType.Name = "cboCardType";
            this.cboCardType.Size = new System.Drawing.Size(227, 21);
            this.cboCardType.TabIndex = 42;
            this.cboCardType.ValueMember = "Code";
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(177, 150);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(227, 20);
            this.txtAccountName.TabIndex = 41;
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.Location = new System.Drawing.Point(177, 117);
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.ReadOnly = true;
            this.txtCardNumber.Size = new System.Drawing.Size(227, 20);
            this.txtCardNumber.TabIndex = 40;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(177, 84);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(227, 20);
            this.txtCode.TabIndex = 39;
            // 
            // chkIsEdit
            // 
            this.chkIsEdit.AutoSize = true;
            this.chkIsEdit.Location = new System.Drawing.Point(177, 284);
            this.chkIsEdit.Name = "chkIsEdit";
            this.chkIsEdit.Size = new System.Drawing.Size(98, 17);
            this.chkIsEdit.TabIndex = 44;
            this.chkIsEdit.Text = "Thẻ thành viên";
            this.chkIsEdit.UseVisualStyleBackColor = true;
            // 
            // chkIsRelease
            // 
            this.chkIsRelease.AutoSize = true;
            this.chkIsRelease.Location = new System.Drawing.Point(177, 319);
            this.chkIsRelease.Name = "chkIsRelease";
            this.chkIsRelease.Size = new System.Drawing.Size(140, 17);
            this.chkIsRelease.TabIndex = 45;
            this.chkIsRelease.Text = "Thẻ đã được phát hành";
            this.chkIsRelease.UseVisualStyleBackColor = true;
            // 
            // chkIsLockCard
            // 
            this.chkIsLockCard.AutoSize = true;
            this.chkIsLockCard.Location = new System.Drawing.Point(177, 350);
            this.chkIsLockCard.Name = "chkIsLockCard";
            this.chkIsLockCard.Size = new System.Drawing.Size(73, 17);
            this.chkIsLockCard.TabIndex = 46;
            this.chkIsLockCard.Text = "Khóa Thẻ";
            this.chkIsLockCard.UseVisualStyleBackColor = true;
            // 
            // frmEditCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 450);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.btnHuyBo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkIsLockCard);
            this.Controls.Add(this.chkIsRelease);
            this.Controls.Add(this.chkIsEdit);
            this.Controls.Add(this.txtDiemThuong);
            this.Controls.Add(this.cboCardType);
            this.Controls.Add(this.txtAccountName);
            this.Controls.Add(this.txtCardNumber);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmEditCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sửa thông tin thẻ";
            this.Load += new System.EventHandler(this.frmEditCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtBalance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtBalance;
        private System.Windows.Forms.Button btnHuyBo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDiemThuong;
        private System.Windows.Forms.ComboBox cboCardType;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.TextBox txtCardNumber;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.CheckBox chkIsEdit;
        private System.Windows.Forms.CheckBox chkIsRelease;
        private System.Windows.Forms.CheckBox chkIsLockCard;
    }
}