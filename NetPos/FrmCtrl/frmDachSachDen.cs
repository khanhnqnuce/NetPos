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
            band.Columns["CardNumber"].Header.Caption = @"Thời gian";
            band.Columns["CardStatus"].Header.Caption = @"Thời gian";
            band.Columns["CustomerID"].Header.Caption = @"Thời gian";
            band.Columns["CustomerClass"].Header.Caption = @"Thời gian";
            band.Columns["CustomerName"].Header.Caption = @"Thời gian";
            band.Columns["CardType"].Header.Caption = @"Thời gian";
            band.Columns["CardTypeCode"].Header.Caption = @"Thời gian";
            band.Columns["SchoolYear"].Header.Caption = @"Thời gian";
            band.Columns["Desc"].Header.Caption = @"Thời gian";
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
                var fileName = string.Format("danh_sach_the_{0}.xlsx", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
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
