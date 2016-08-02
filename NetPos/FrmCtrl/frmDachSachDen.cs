using System;
using System.IO;
using System.Windows.Forms;
using FDI;
using FDI.DA;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using PerpetuumSoft.Reporting.View;

namespace NetPos.FrmCtrl
{
    public partial class frmDachSachDen : UserControl
    {
        readonly BackListDA _da = new BackListDA();

        public frmDachSachDen()
        {
            InitializeComponent();
        }

        public void LoadGrid()
        {
            var lst = _da.GetAll();
            dgv_DanhSach.DataSource = lst.ToDataTable();
        }

        private void dgv_DanhSach_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            var band = e.Layout.Bands[0];
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            band.Override.HeaderAppearance.FontData.Bold = DefaultableBoolean.True;
            band.Columns["ID"].Hidden = true;

            band.Columns["Date"].CellActivation = Activation.NoEdit;
            band.Columns["CardNumber"].CellActivation = Activation.NoEdit;
            band.Columns["CardStatus"].CellActivation = Activation.NoEdit;
            band.Columns["CustomerID"].CellActivation = Activation.NoEdit;
            band.Columns["CustomerClass"].CellActivation = Activation.NoEdit;
            band.Columns["CustomerName"].CellActivation = Activation.NoEdit;
            band.Columns["CardType"].CellActivation = Activation.NoEdit;
            band.Columns["CardTypeCode"].CellActivation = Activation.NoEdit;
            band.Columns["SchoolYear"].CellActivation = Activation.NoEdit;
            band.Columns["Desc"].CellActivation = Activation.NoEdit;

            #region Caption
            band.Columns["Date"].Header.Caption = @"Thời gian";
            band.Columns["CardNumber"].Header.Caption = @"Mã thẻ";
            band.Columns["CardStatus"].Header.Caption = @"Trạng thái";
            band.Columns["CustomerID"].Header.Caption = @"Mã KH";
            band.Columns["CustomerClass"].Header.Caption = @"Lớp";
            band.Columns["CustomerName"].Header.Caption = @"Tên KH";
            band.Columns["CardType"].Header.Caption = @"Loại thẻ";
            band.Columns["CardTypeCode"].Hidden = true;
            band.Columns["SchoolYear"].Header.Caption = @"Năm học";
            band.Columns["Desc"].Header.Caption = @"Mô tả";
            #endregion
            band.Override.HeaderClickAction = HeaderClickAction.SortSingle;
        }

        public void Printf()
        {
            try
            {
                //var lst = _da.GetAll();
                reportManager.DataSources.Clear();
                reportManager.DataSources.Add("danhsach", dgv_DanhSach.DataSource);
                rpCard.FilePath = Application.StartupPath + @"\Reports\rpCard.rst";
                rpCard.Prepare();
                var previewForm = new PreviewForm(rpCard)
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
                var fileName = string.Format("danh_sach_the_den-{0}.xlsx", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
                var filePath = Path.Combine(path, fileName);
                Excel.ExportToCardBackList(filePath, dgv_DanhSach);

            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }

    }
}
