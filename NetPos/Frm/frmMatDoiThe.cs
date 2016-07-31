using System;
using System.Windows.Forms;
using FDI.Base;
using FDI.DA;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

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
            //labTenTaiKhoan.Text = item.AccountName;
            //labLoaiThe.Text = item.CardTypeCode;
            var date = DateTime.Now;
            var startDate = new DateTime(date.Year, date.Month, 1, 0, 0, 0, 0);
            var endDate = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
            dgv_DanhSach.DataSource = _da.GiaoDichGanNhat(CardNumber, startDate, endDate);
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
                    //var item = _da.Get(IdCard);
                    //item.IsLockCard = true;
                    //IsLockCard = true;
                    //IsUpdate = true;
                    //_da.Save();
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

        private void dgv_DanhSach_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            var band = e.Layout.Bands[0];
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            band.Columns["ID"].Hidden = true;

            band.Columns["Action"].CellActivation = Activation.NoEdit;
            band.Columns["Date"].CellActivation = Activation.NoEdit;
            band.Columns["Value"].CellActivation = Activation.NoEdit;
            band.Columns["Balance"].CellActivation = Activation.NoEdit;
            band.Columns["Object"].CellActivation = Activation.NoEdit;
            band.Columns["ProductCode"].CellActivation = Activation.NoEdit;

            band.Columns["Action"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["Date"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["Value"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["Balance"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["Object"].CellAppearance.TextHAlign = HAlign.Left;
            band.Columns["ProductCode"].CellAppearance.TextHAlign = HAlign.Right;

            #region Caption
            band.Columns["Action"].Header.Caption = @"Miêu tả";
            band.Columns["Date"].Header.Caption = @"Thời gian";
            band.Columns["Value"].Header.Caption = @"Thanh toán";
            band.Columns["Balance"].Header.Caption = @"Số dư tài khoản";
            band.Columns["Object"].Header.Caption = @"Đối tượng";
            band.Columns["ProductCode"].Header.Caption = @"Mã hàng";

            #endregion
            band.Override.HeaderClickAction = HeaderClickAction.SortSingle;
        }

    }
}
