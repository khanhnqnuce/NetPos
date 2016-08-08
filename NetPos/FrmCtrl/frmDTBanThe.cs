using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Office2010.Excel;
using FDI;
using FDI.Simple;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using NetPos.Frm;
using PerpetuumSoft.Reporting.View;

namespace NetPos.FrmCtrl
{
    public partial class frmDTBanThe : UserControl
    {
        readonly frmLocDTBanThe _formLoc;
        ModelItem _modelItem = new ModelItem();
        private readonly UserItem _userItem;
        List<ThongKeItem> _lst = new List<ThongKeItem>();

        public frmDTBanThe(UserItem userItem)
        {
            _userItem = userItem;
            _formLoc = new frmLocDTBanThe(_modelItem);
            _formLoc.FillterRecordCard += FillterRecordCard;
            _formLoc.FillterRecordDetailCard += FillterRecordDetailCard;
            InitializeComponent();
        }

        private void frmDTBanThe_Load(object sender, EventArgs e)
        {
        }

        public void Loc()
        {
            _formLoc.ModelItem = _modelItem;
            //_formLoc.LoadDefault();
            _formLoc.User = _userItem;
            _formLoc.ShowDialog();
            _modelItem = _formLoc.ModelItem;
        }

        #region Event
        private void FillterRecordCard(object sender, List<ThongKeItem> lst)
        {
            _lst = lst;
            dgv_DanhSachChiTiet.DataSource = lst.ToDataTable();
            
        }

        private void FillterRecordDetailCard(object sender, List<EventItem> lst)
        {
            dgv_DanhSach.DataSource = lst.ToDataTable();
        }
        #endregion

        private void dgv_DanhSachChiTiet_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            var band = e.Layout.Bands[0];
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            band.Columns["ID"].Hidden = true;

            band.Columns["Name"].CellActivation = Activation.NoEdit;
            band.Columns["Value"].CellActivation = Activation.NoEdit;

            band.Columns["Name"].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["Value"].CellAppearance.TextHAlign = HAlign.Right;

            band.Columns["Name"].Header.Caption = @"Thông tin";
            band.Columns["Value"].Header.Caption = @"Số lượng";
            band.Columns["Value"].FormatMonney();
        }

        private void dgv_DanhSach_InitializeLayout_1(object sender, InitializeLayoutEventArgs e)
        {
            var band = e.Layout.Bands[0];
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            band.Override.HeaderAppearance.FontData.Bold = DefaultableBoolean.True;

            band.Columns["Date"].CellActivation = Activation.NoEdit;
            band.Columns["CardNumber"].CellActivation = Activation.NoEdit;
            band.Columns["Event"].CellActivation = Activation.NoEdit;
            band.Columns["Value"].CellActivation = Activation.NoEdit;
            band.Columns["Object"].CellActivation = Activation.NoEdit;
            band.Columns["Area"].CellActivation = Activation.NoEdit;
            band.Columns["Balance"].CellActivation = Activation.NoEdit;
            band.Columns["OwnerCode"].CellActivation = Activation.NoEdit;

            band.Columns["Date"].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["CardNumber"].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["Value"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["Event"].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["OwnerCode"].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["EventCode"].Hidden = true;
            band.Columns["Balance"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["Balance"].FormatMonney();

            band.Columns["Value"].FormatMonney();
            band.Columns["Date"].Format = @"dd/MM/yyyy hh:mm";

            #region Caption
            band.Columns["Date"].Header.Caption = @"Thời gian";
            band.Columns["OwnerCode"].Header.Caption = @"Mã HS";
            band.Columns["CardNumber"].Header.Caption = @"Mã thẻ";
            band.Columns["Event"].Header.Caption = @"Loại giao dịch";
            band.Columns["Value"].Header.Caption = @"Số tiền";
            band.Columns["Balance"].Header.Caption = @"Số dư";
            band.Columns["Object"].Header.Caption = @"Đối tượng";
            band.Columns["Area"].Header.Caption = @"Khu vực";

            #endregion
            band.Override.HeaderClickAction = HeaderClickAction.SortSingle;
        }

        public void InTongHop()
        {
            try
            {
                //var lst = _da.GetAll();
                reportManager.DataSources.Clear();
                reportManager.DataSources.Add("danhsach", dgv_DanhSachChiTiet.DataSource);
                reportManager.DataSources.Add("danhsachCT", dgv_DanhSach.DataSource);
                rpDTBanThe.FilePath = Application.StartupPath + @"\Reports\rpDTBanThe.rst";
                rpDTBanThe.GetReportParameter += GetParameter;
                rpDTBanThe.Prepare();
                var previewForm = new PreviewForm(rpDTBanThe)
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

        public void Export(string path)
        {
            try
            {
                var fileName = string.Format("thong_ke_ban_the-{0}.xlsx", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
                var filePath = Path.Combine(path, fileName);
                Excel.BCDoanhThuBanThe(filePath, dgv_DanhSach,_modelItem,_lst);

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
                e.Parameters["Buiding"].Value = _modelItem.BuidingName;
                e.Parameters["Area"].Value = _modelItem.AreaName;
                e.Parameters["Object"].Value = _modelItem.ObjectName;

                e.Parameters["Time"].Value = "(" + _modelItem.StartDate.Value.ToString("HH:ss dd/MM/yyyy ") + " - " +
                                              _modelItem.EndDate.Value.ToString("HH:ss dd/MM/yyyy") + ")";
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }

    }
}
