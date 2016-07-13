using System;
using System.Windows.Forms;
using FDI.Base;
using FDI.DA;
using FDI.Simple;

namespace NetPos.Frm
{
    public partial class frmAddCard : Form
    {
        public delegate void CustomHandler(object sender, tblCard hs);
        public event CustomHandler AddCard;
        protected virtual void OnAddCard(tblCard hs)
        {
            var handler = AddCard;
            if (handler != null) handler(this, hs);
        }

        readonly CardDA _cardDa = new CardDA();
        public frmAddCard()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Checkghi())
            {
                return;
            }
            var carditem = new tblCard
            {
                Code = txtCode.Text,
                AccountName = txtAccountName.Text,
                CardNumber = txtCardNumber.Text,
                Balance = int.Parse(txtBalance.Text),
                IsEdit = chkIsEdit.Checked,
                IsLockCard = chkIsLockCard.Checked,
                IsRelease = chkIsRelease.Checked,
                CardTypeCode = cboCardType.SelectedValue.ToString()
            };
            _cardDa.Add(carditem);
            _cardDa.Save();
            OnAddCard(carditem);
        }

        private bool Checkghi()
        {
            try
            {
                txtError.Dispose();
                if (string.IsNullOrEmpty(txtCode.Text))
                {
                    txtError.SetError(txtCode, "Không được để trống");
                    txtCode.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtCardNumber.Text))
                {
                    txtError.SetError(txtCardNumber, "Không được để trống");
                    txtCardNumber.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtAccountName.Text))
                {
                    txtError.SetError(txtAccountName, "Không được để trống");
                    txtAccountName.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtBalance.Text))
                {
                    txtError.SetError(txtBalance, "Không được để trống");
                    txtBalance.Focus();
                    return false;
                }
                
                if (string.IsNullOrEmpty(txtDiemThuong.Text))
                {
                    txtError.SetError(txtDiemThuong, "Không được để trống");
                    txtDiemThuong.Focus();
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
                return false;
            }
        }
        private void frmAddCard_Load(object sender, EventArgs e)
        {
            var lstCardType = _cardDa.GetTypeCard();
            cboCardType.DataSource = lstCardType;
        }
    }
}
