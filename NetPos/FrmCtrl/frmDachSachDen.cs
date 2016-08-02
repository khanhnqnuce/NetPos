﻿using System;
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
            band.Columns["MemoryID"].CellActivation = Activation.NoEdit;
            band.Columns["CardNumber"].CellActivation = Activation.NoEdit;
            band.Columns["ToObjects"].CellActivation = Activation.NoEdit;
            band.Columns["IsInActive"].CellActivation = Activation.NoEdit;
            band.Columns["Desc"].CellActivation = Activation.NoEdit;

            band.Columns["Date"].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["MemoryID"].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["CardNumber"].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["ToObjects"].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["IsInActive"].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["Desc"].CellAppearance.TextHAlign = HAlign.Center;

            #region Caption
            band.Columns["Date"].Header.Caption = @"Thời gian";
            band.Columns["MemoryID"].Header.Caption = @"MemoryID";
            band.Columns["CardNumber"].Header.Caption = @"Mã thẻ";
            band.Columns["ToObjects"].Header.Caption = @"Đầu đọc";
            band.Columns["IsInActive"].Header.Caption = @"IsInActive";
            band.Columns["Desc"].Header.Caption = @"Mô Tả";

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
