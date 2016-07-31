using System;
using System.IO;
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

            txtSoDu.Text = string.Format("{0:0,0}",CustomerItem.Balance);
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

            datStartDate.CustomFormat = @"dd/MM/yyyy HH:mm:ss";
            datEndDate.CustomFormat = @"dd/MM/yyyy HH:mm:ss";
            var date = DateTime.Now;
            var startDate = new DateTime(date.Year, date.Month, 1, 0, 0, 0, 0);
            var endDate = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
            datStartDate.Value = startDate;
            datEndDate.Value = endDate;

            dgv_DanhSach.DataSource = _cardDa.GiaoDichGanNhat(CardNumber, startDate, endDate);
        }

        private void dgv_DanhSach_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            var band = e.Layout.Bands[0];
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            band.Columns["ID"].Hidden = true;

            band.Columns["Event"].CellActivation = Activation.NoEdit;
            band.Columns["Date"].CellActivation = Activation.NoEdit;
            band.Columns["Value"].CellActivation = Activation.NoEdit;
            band.Columns["Object"].CellActivation = Activation.NoEdit;

            band.Columns["Value"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["Value"].FormatMonney();

            #region Caption
            band.Columns["Event"].Header.Caption = @"Miêu tả";
            band.Columns["Date"].Header.Caption = @"Thời gian";
            band.Columns["Value"].Header.Caption = @"Thanh toán";
            band.Columns["Object"].Header.Caption = @"Đối tượng";

            #endregion
            band.Override.HeaderClickAction = HeaderClickAction.SortSingle;
        }

        private void btnXem_Click(object sender, System.EventArgs e)
        {
            var CardNumber = txtMaThe.Text;
            var startDate = datStartDate.Value;
            var endDate = datEndDate.Value;
            dgv_DanhSach.DataSource = _cardDa.GiaoDichGanNhat(CardNumber, startDate, endDate);
        }

        private void menuExcel_Click(object sender, EventArgs e)
        {
            //Export(folderBrowserDialog1.SelectedPath);
        }

        private void menuIn_Click(object sender, EventArgs e)
        {

        }

        public void Export(string path)
        {
            try
            {
                var fileName = string.Format("thong_tin_the_{0}.xlsx", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
                var filePath = Path.Combine(path, fileName);
                Excel.ExportToCard(filePath, dgv_DanhSach);

            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }
    }
}
