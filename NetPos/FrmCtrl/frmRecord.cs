using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using FDI;
using FDI.DA;
using FDI.Simple;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using NetPos.Frm;
using PerpetuumSoft.Reporting.View;

namespace NetPos.FrmCtrl
{
    public partial class frmRecord : UserControl
    {
        public frmRecord()
        {
            InitializeComponent();
        }
        private void dgv_DanhSach_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            var band = e.Layout.Bands[0];
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;            

            band.Columns["Date"].CellActivation = Activation.NoEdit;
            band.Columns["CardNumber"].CellActivation = Activation.NoEdit;
            band.Columns["Event"].CellActivation = Activation.NoEdit;
            band.Columns["Value"].CellActivation = Activation.NoEdit;
            band.Columns["Object"].CellActivation = Activation.NoEdit;
            band.Columns["Area"].CellActivation = Activation.NoEdit;

            band.Columns["Date"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["CardNumber"].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["Value"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["Event"].CellAppearance.TextHAlign = HAlign.Center;

            #region Caption
            band.Columns["Date"].Header.Caption = @"Thời gian";
            band.Columns["CardNumber"].Header.Caption = @"Mã thẻ";
            band.Columns["Event"].Header.Caption = @"Loại giao dịch";
            band.Columns["Value"].Header.Caption = @"Số tiền";
            band.Columns["Object"].Header.Caption = @"Đối tượng";
            band.Columns["Area"].Header.Caption = @"Khu vực";

            #endregion
            band.Override.HeaderClickAction = HeaderClickAction.SortSingle;
        }

        public void Loc()
        {
            lbTongGD.Text = @"0";
            var form = new frmLoc();
            form.FillterRecord += FillterRecord;
            form.ShowDialog();
        }

        #region Event
        private void FillterRecord(object sender, List<EventItem> lst)
        {
            dgv_DanhSach.DataSource = lst.ToDataTable();
            lbTongGD.Text = lst.Count.ToString();
        }
        #endregion

        public void Printf()
        {
            try
            {
                reportManager.DataSources.Add("danhsach", dgv_DanhSach.DataSource);
                rpRecord.FilePath = Application.StartupPath + @"\Reports\rpRecord.rst";
                rpRecord.Prepare();
                var previewForm = new PreviewForm(rpRecord)
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
                var fileName = string.Format("chi_tiet_giao_dich{0}.xlsx", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
                var filePath = Path.Combine(path, fileName);
                Excel.ExportToReportCardDetail(filePath, dgv_DanhSach);

            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }

    }
}
