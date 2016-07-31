using System;
using System.Windows.Forms;
using FDI.Base;
using FDI.DA;

namespace NetPos.Frm
{
    public partial class frmEditCard : Form
    {
        public int Id;
        readonly CardDA _cardDa = new CardDA();
        public tblCard TblCardItem;
        public bool IsUpdate = false;
        public frmEditCard()
        {
            InitializeComponent();
        }

        private void frmEditCard_Load(object sender, EventArgs e)
        {
            //TblCardItem = _cardDa.Get(Id);
            //txtAccountName.Text = TblCardItem.AccountName;
            //txtBalance.Value = TblCardItem.Balance;
            //txtCardNumber.Text = TblCardItem.CardNumber;
            //txtCode.Text = TblCardItem.Code;
            //txtDiemThuong.Text = @"0";
            //chkIsEdit.Checked = TblCardItem.IsEdit;
            //chkIsLockCard.Checked = TblCardItem.IsLockCard ?? false;
            //chkIsRelease.Checked = TblCardItem.IsRelease ?? false;
            //var lstCardType = _cardDa.GetTypeCard();
            //cboCardType.DataSource = lstCardType;
            //cboCardType.SelectedValue = TblCardItem.CardTypeCode;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                TblCardItem.Code = txtCode.Text;
                TblCardItem.AccountName = txtAccountName.Text;
                TblCardItem.IsEdit = chkIsEdit.Checked;
                TblCardItem.IsLockCard = chkIsLockCard.Checked;
                TblCardItem.IsRelease = chkIsRelease.Checked;
                if (cboCardType.SelectedValue != null)
                {
                    TblCardItem.CardTypeCode = cboCardType.SelectedValue.ToString();
                }
                _cardDa.Save();
                IsUpdate = true;
                MessageBox.Show(@"Cập nhật dữ liệu thành công !");
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
            Close();
        }
    }
}
