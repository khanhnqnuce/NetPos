using System;
using System.IO;
using System.Windows.Forms;
using FDI.DA;
using FDI.Simple;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using PerpetuumSoft.Reporting.View;

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

        private void FrmCardDetails_Load(object sender, EventArgs e)
        {
            CustomerItem = _cardDa.GetCustomer(Id);
            txtMaKH.Text = CustomerItem.CustomerID;
            txtTenKH.Text = CustomerItem.CustomerName;
            lbBirthday.Text = CustomerItem.BirthDate;
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
            lbDate.Text = CustomerItem.DateIssue.ToString("dd/MM/yyyy HH:mm:ss");
            var CardNumber = CustomerItem.CardNumber;
            datStartDate.CustomFormat = @"dd/MM/yyyy HH:mm:ss";
            datEndDate.CustomFormat = @"dd/MM/yyyy HH:mm:ss";

            var date = DateTime.Now;
            var startDate = new DateTime(date.Year, date.Month, 1, 0, 0, 0);
            var endDate = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
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

        private void btnXem_Click(object sender, EventArgs e)
        {
            var CardNumber = txtMaThe.Text;
            var startDate = datStartDate.Value;
            var endDate = datEndDate.Value;
            dgv_DanhSach.DataSource = _cardDa.GiaoDichGanNhat(CardNumber, startDate, endDate);
        }

        private void menuExcel_Click(object sender, EventArgs e)
        {
            CustomerItem = _cardDa.GetCustomer(Id);
            var result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fileName = string.Format("danh_sach_the_{0}.xlsx", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
                var filePath = Path.Combine(folderBrowserDialog1.SelectedPath, fileName);
                Excel.ChiTietThe(filePath, CustomerItem, dgv_DanhSach, datStartDate.Value.ToString("dd/MM/yyyy"), datEndDate.Value.ToString("dd/MM/yyyy"));
            }
        }

        private void menuIn_Click(object sender, EventArgs e)
        {
            try
            {
                //var lst = _da.GetAll();
                reportManager.DataSources.Clear();
                reportManager.DataSources.Add("danhsach", dgv_DanhSach.DataSource);
                rpCardDetail.FilePath = Application.StartupPath + @"\Reports\rpDetailCard.rst";
                rpCardDetail.GetReportParameter += GetParameter;
                rpCardDetail.Prepare();
                var previewForm = new PreviewForm(rpCardDetail)
                {
                    WindowState = FormWindowState.Maximized
                };
                previewForm.Show();

            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }

        private void GetParameter(object sender,
           PerpetuumSoft.Reporting.Components.GetReportParameterEventArgs e)
        {
            try
            {
                CustomerItem = _cardDa.GetCustomer(Id);
                e.Parameters["CustomerID"].Value = CustomerItem.CustomerID;
                e.Parameters["CustomerName"].Value = CustomerItem.CustomerName;
                e.Parameters["BirthDate"].Value = CustomerItem.BirthDate;
                e.Parameters["SchoolYear"].Value = CustomerItem.SchoolYear;
                e.Parameters["CustomerClass"].Value = CustomerItem.CustomerClass.ToString();
                e.Parameters["Balance"].Value = string.Format("{0:0,0}", CustomerItem.Balance);
                e.Parameters["CardNumber"].Value = CustomerItem.CardNumber;
                e.Parameters["CardType"].Value = CustomerItem.CardType;
                switch (CustomerItem.CardStatus)
                {
                    case "00":
                        e.Parameters["CardStatus"].Value = @"Chưa phát hành";
                        break;
                    case "01":
                        e.Parameters["CardStatus"].Value = @"Đã phát hành";
                        break;
                    default:
                        e.Parameters["CardStatus"].Value = @"Đã khóa";
                        break;
                }
                e.Parameters["DateIssue"].Value = CustomerItem.DateIssue.ToString("dd/MM/yyyy HH:mm:ss");
                e.Parameters["Time"].Value = "(" + datStartDate.Value.ToString("dd/MM/yyyy") + " - " +
                                             datEndDate.Value.ToString("dd/MM/yyyy") + ")";
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
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
