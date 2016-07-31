using System.Windows.Forms;
using FDI.Base;
using FDI.DA;
using FDI.Simple;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace NetPos.Frm
{
    public partial class FrmCardDetails : Form
    {
        public string CardNumber;
        public int Id;
        readonly CardDA _cardDa = new CardDA();
        public CustomerItem CustomerItem;
        public bool IsUpdate = false;
        public FrmCardDetails()
        {
            InitializeComponent();
        }

        private void FrmCardDetails_Load(object sender, System.EventArgs e)
        {
            CustomerItem = _cardDa.GetCustomer(Id);
            txtMaKH.Text = CustomerItem.CustomerID;
            txtTenKH.Text = CustomerItem.CustomerName;
            lbBirthday.Text = CustomerItem.BirthDate.ToString("dd/MM/yyyy");
            lbNamhoc.Text = CustomerItem.SchoolYear;
            lbClass.Text = CustomerItem.CustomerClass.ToString();

            txtSoDu.Text = CustomerItem.Balance.ToString();
            txtMaThe.Text = CustomerItem.CardNumber;
            txtloaiThe.Text = CustomerItem.CardType;
            switch (CustomerItem.CardStatus)
            {
                case "00":
                    lbStatus.Text = @"Chưa phát hành";
                    break;
                case "01":
                    lbStatus.Text = @"Đã phát hành";
                    break;
                default:
                    lbStatus.Text = @"Đã khóa";
                    break;
            }


            txtloaiThe.Text = CustomerItem.CardType;
            var CardNumber = CustomerItem.CardNumber;
            dgv_DanhSach.DataSource = _cardDa.GiaoDichGanNhat(CardNumber);
        }

        private void dgv_DanhSach_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            var band = e.Layout.Bands[0];
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            band.Columns["ID"].Hidden = true;

            //band.Columns["Action"].CellActivation = Activation.NoEdit;
            //band.Columns["Date"].CellActivation = Activation.NoEdit;
            //band.Columns["Value"].CellActivation = Activation.NoEdit;
            //band.Columns["Balance"].CellActivation = Activation.NoEdit;
            //band.Columns["Object"].CellActivation = Activation.NoEdit;
            //band.Columns["ProductCode"].CellActivation = Activation.NoEdit;

            //band.Columns["Action"].CellAppearance.TextHAlign = HAlign.Right;
            //band.Columns["Date"].CellAppearance.TextHAlign = HAlign.Right;
            //band.Columns["Value"].CellAppearance.TextHAlign = HAlign.Right;
            //band.Columns["Balance"].CellAppearance.TextHAlign = HAlign.Right;
            //band.Columns["Object"].CellAppearance.TextHAlign = HAlign.Left;
            //band.Columns["ProductCode"].CellAppearance.TextHAlign = HAlign.Right;

            //#region Caption
            //band.Columns["Action"].Header.Caption = @"Miêu tả";
            //band.Columns["Date"].Header.Caption = @"Thời gian";
            //band.Columns["Value"].Header.Caption = @"Thanh toán";
            //band.Columns["Balance"].Header.Caption = @"Số dư tài khoản";
            //band.Columns["Object"].Header.Caption = @"Đối tượng";
            //band.Columns["ProductCode"].Header.Caption = @"Mã hàng";

            //#endregion
            band.Override.HeaderClickAction = HeaderClickAction.SortSingle;
        }

    }
}
