using System;
using System.Windows.Forms;
using FDI.DA;
using FDI.Simple;

namespace NetPos.Frm
{
    public partial class frmEditCard : Form
    {
        public int Id;
        readonly CardDA _cardDa = new CardDA();
        public CustomerItem CustomerItem;
        public bool IsUpdate = false;
        public frmEditCard()
        {
            InitializeComponent();
        }

        private void frmEditCard_Load(object sender, EventArgs e)
        {
            CustomerItem = _cardDa.GetCustomer(Id);
            txtCusName.Text = CustomerItem.CustomerName;
            txtBalance.Value = CustomerItem.Balance;
            txtCardNumber.Text = CustomerItem.CardNumber;
            txtCusCode.Text = CustomerItem.CustomerID;
            cbKhoa.Checked = CustomerItem.CardStatus == "02";
            cbPhatH.Checked = CustomerItem.CardStatus == "01";
            cbChuaPH.Checked = CustomerItem.CardStatus == "00";
            var lstCardType = _cardDa.GetTypeCard();
            cboCardType.DataSource = lstCardType;
            cboCardType.SelectedValue = CustomerItem.CardTypeCode;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var card = _cardDa.GetCard(Id);
                var cus = _cardDa.GetCustomer(card.OwnerCode);

                if (cbChuaPH.Checked)
                { 
                    card.CardStatus = "00";
                    CustomerItem.CardStatus = "Chưa phát hành";
                }
                if (cbPhatH.Checked)
                {
                    card.CardStatus = "01";
                    CustomerItem.CardStatus = "Đã phát hành";
                }
                if (cbKhoa.Checked)
                {
                    card.CardStatus = "02";
                    CustomerItem.CardStatus = "Đã khóa";
                }

                card.CardTypeCode = cboCardType.SelectedValue.ToString();

                cus.CustomerID = txtCusCode.Text;
                cus.CustomerName = txtCusName.Text;

                CustomerItem.CustomerID = txtCusCode.Text;
                CustomerItem.CustomerName = txtCusName.Text;

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
