﻿using System;
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

        //readonly RecordDA _da = new RecordDA();
        public frmRecord()
        {
            InitializeComponent();
        }

        private void frmRecord_Load(object sender, EventArgs e)
        {
			Loc();        }


        private void LoadGrid()
        {
            
        }

        private void dgv_DanhSach_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            var band = e.Layout.Bands[0];
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            band.Columns["ID"].Hidden = true;

            band.Columns["CardNumber"].CellActivation = Activation.NoEdit;
            band.Columns["Date"].CellActivation = Activation.NoEdit;
            band.Columns["Value"].CellActivation = Activation.NoEdit;
            band.Columns["Balance"].CellActivation = Activation.NoEdit;
            band.Columns["Action"].CellActivation = Activation.NoEdit;
            band.Columns["AccountName"].CellActivation = Activation.NoEdit;
            band.Columns["CardType"].CellActivation = Activation.NoEdit;
            band.Columns["Buiding"].CellActivation = Activation.NoEdit;
            band.Columns["Area"].CellActivation = Activation.NoEdit;
            band.Columns["UserName"].CellActivation = Activation.NoEdit;
            //band.Columns["EventId"].CellActivation = Activation.NoEdit;
            //band.Columns["ProductCode"].CellActivation = Activation.NoEdit;

            band.Columns["Balance"].MinWidth = 120;
            band.Columns["UserName"].MinWidth = 120;

            band.Columns["CardNumber"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["Date"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["Value"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["Balance"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["Action"].CellAppearance.TextHAlign = HAlign.Left;
            band.Columns["AccountName"].CellAppearance.TextHAlign = HAlign.Left;
            band.Columns["CardType"].CellAppearance.TextHAlign = HAlign.Left;
            band.Columns["Buiding"].CellAppearance.TextHAlign = HAlign.Left;
            band.Columns["Area"].CellAppearance.TextHAlign = HAlign.Left;
            band.Columns["UserName"].CellAppearance.TextHAlign = HAlign.Left;
            //band.Columns["EventId"].CellAppearance.TextHAlign = HAlign.Right;
            //band.Columns["ProductCode"].CellAppearance.TextHAlign = HAlign.Right; 
            band.Columns["EventId"].Hidden = true;
            band.Columns["ProductCode"].Hidden = true;

            #region Caption
            band.Columns["CardNumber"].Header.Caption = @"Mã thẻ";
            band.Columns["Date"].Header.Caption = @"Thời gian";
            band.Columns["Value"].Header.Caption = @"Thanh toán";
            band.Columns["Balance"].Header.Caption = @"Số dư tài khoản";
            band.Columns["Action"].Header.Caption = @"Miêu tả";
            band.Columns["AccountName"].Header.Caption = @"Tên tài khoản";
            band.Columns["CardType"].Header.Caption = @"Loại Thẻ";
            band.Columns["Buiding"].Header.Caption = @"Tòa Nhà";
            band.Columns["Area"].Header.Caption = @"Khu vực";
            band.Columns["UserName"].Header.Caption = @"Nhân viên bán vé";
            band.Columns["EventId"].Header.Caption = @"EventId";
            band.Columns["ProductCode"].Header.Caption = @"Mã hàng";

            #endregion
            band.Override.HeaderClickAction = HeaderClickAction.SortSingle;
        }

        public void Loc()
        {
            var form = new frmLoc();
            form.FillterRecord += FillterRecord;
            form.ShowDialog();
        }

        #region Event
        private void FillterRecord(object sender, List<RecordItem> lst)
        {
            dgv_DanhSach.DataSource = lst.ToDataTable();
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
                var fileName = string.Format("bao_cao_doanh_thu_chi-tiet{0}.xlsx", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
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
