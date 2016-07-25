using System.Windows.Forms;
using FDI.Base;
using FDI.DA;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace NetPos.Frm
{
    public partial class FrmCardDetails : Form
    {
        public string CardNumber;
        public int Id;
        readonly CardDA _cardDa = new CardDA();
        public tblCard TblCardItem;
        public bool IsUpdate = false;
        public FrmCardDetails()
        {
            InitializeComponent();
        }

        private void FrmCardDetails_Load(object sender, System.EventArgs e)
        {
            TblCardItem = _cardDa.Get(Id);
            txtMaKH.Text = TblCardItem.Code;
            txtTenKH.Text = TblCardItem.AccountName;
            txtSoDu.Text = TblCardItem.Balance.ToString();
            txtMaThe.Text = TblCardItem.CardNumber;
            chkIsEdit.Checked = TblCardItem.IsEdit;
            chkIsLockCard.Checked = TblCardItem.IsLockCard ?? false;
            chkIsRelease.Checked = TblCardItem.IsRelease ?? false;

            //chkIsEdit.Enabled = false;
            //chkIsLockCard.Enabled = false;
            //chkIsRelease.Enabled = false;

            CardNumber = TblCardItem.CardNumber;
            var item = _cardDa.Get(CardNumber);
            txtloaiThe.Text = item.CardTypeCode;

            dgv_DanhSach.DataSource = _cardDa.GetRecord(CardNumber);
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
