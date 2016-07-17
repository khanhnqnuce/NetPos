using System;
using System.Windows.Forms;
using FDI;
using FDI.Base;
using FDI.DA;

namespace NetPos.Frm
{
    public partial class frmMatDoiThe : Form
    {
        public string CardNumber;
        public int IdCard;
        public bool IsUpdate = false;
        public bool IsLockCard = false;
        readonly CardDA _da = new CardDA();
        readonly BackListDA _backListDa = new BackListDA();
        public frmMatDoiThe()
        {
            InitializeComponent();
        }

        private void frmMatDoiThe_Load(object sender, EventArgs e)
        {
            var item = _da.Get(CardNumber);
            labMaThe.Text = item.CardNumber;
            labTenTaiKhoan.Text = item.AccountName;
            labLoaiThe.Text = item.CardTypeCode;

            dgv_DanhSach.DataSource = _da.GetRecord(CardNumber);
            txtCard.Visible = false;
            lbMatheMoi.Visible = false;
            txtDes.Visible = false;
            lbMoTa.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {


                if (rdoBlock.Checked)
                {
                    var item = _da.Get(IdCard);
                    item.IsLockCard = true;
                    IsLockCard = true;
                    IsUpdate = true;
                    _da.Save();
                    MessageBox.Show(@"Khóa thẻ thành công !");
                }
                else if (rdoRename.Checked)
                {
                    if (string.IsNullOrEmpty(txtCard.Text))
                    {
                        txtError.SetError(txtCard, "Không được để trống.");
                    }
                    else
                    {
                        txtError.Dispose();
                        _da.UpdateCard(CardNumber, txtCard.Text);
                        MessageBox.Show(@"Cập nhật thành công !");
                        IsUpdate = true;
                        CardNumber = txtCard.Text;
                    }
                }

                if (cbAddBackList.Checked)
                {
                    var item = _backListDa.Get(CardNumber);
                    if (item != null)
                    {
                        MessageBox.Show(@"Thẻ đã thuộc danh sách đen !");
                    }
                    else
                    {
                        var tblBlacklist = new tblBlackList
                        {
                            Date = DateTime.Now,
                            CardNumber = CardNumber,
                            Desc = txtDes.Text,
                            MemoryID = _backListDa.Count(),
                            IsInActive = false
                        };
                        _backListDa.Add(tblBlacklist);
                        _backListDa.Save();
                        MessageBox.Show(@"Thẻ đã được thêm vào danh sách đen !");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void rdoRename_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRename.Checked)
            {
                txtCard.Visible = true;
                lbMatheMoi.Visible = true;
            }
        }

        private void cbAddBackList_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAddBackList.Checked)
            {
                lbMoTa.Visible = true;
                txtDes.Visible = true;
            }
            else
            {
                lbMoTa.Visible = false;
                txtDes.Visible = false;
            }
        }

        private void rdoBlock_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdoBlock.Checked) return;
            txtCard.Visible = false;
            lbMatheMoi.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
