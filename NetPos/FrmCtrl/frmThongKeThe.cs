using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FDI;
using FDI.DA;
using FDI.Simple;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using NetPos.Frm;

namespace NetPos.FrmCtrl
{
    public partial class frmThongKeThe : UserControl
    {
        readonly ThongKeTheDA _da = new ThongKeTheDA();
        readonly CardDA _cardDa = new CardDA();
        readonly FrmLogThongKeThe _formLoc;
        readonly ModelItem _modelItem = new ModelItem();
        private UserItem _userItem;

        public frmThongKeThe(UserItem userItem)
        {
            _userItem = userItem;
            _formLoc = new FrmLogThongKeThe(_modelItem);
            _formLoc.FillterTkThe += FillterTkThe;
            _formLoc.FillterTkTheChiTiet += FillterTkTheChiTiet;
            InitializeComponent();
        }

        private void frmThongKeThe_Load(object sender, EventArgs e)
        {
            
        }

        public void LoadGrid()
        {
            if (_userItem.Right1 == 1)
            {
                var lst = _da.GetThongKeTheItems("", "", "");
                dgv_DanhSach.DataSource = lst.ToDataTable();

                var row = dgv_DanhSach.DisplayLayout.Bands[0].AddNew();

                row.Cells["NameType"].Value = "Tổng";
                row.Cells["TotalCard"].Value = lst.Sum(c => c.TotalCard);
                row.Cells["TotalUsed"].Value = lst.Sum(c => c.TotalUsed);
                row.Cells["TotalNotUsed"].Value = lst.Sum(c => c.TotalNotUsed);
                row.Cells["TotalBlock"].Value = lst.Sum(c => c.TotalBlock);
                row.Cells["TotalBalance"].Value = lst.Sum(c => c.TotalBalance);
                row.CellAppearance.BackColor = Color.LightCyan;
                row.CellAppearance.FontData.Bold = DefaultableBoolean.True;
                row.CellAppearance.FontData.SizeInPoints = 14;

                var listCT = _cardDa.ReportDetailCard("", "", "");
                dgv_DanhSachChitiet.DataSource = listCT.ToDataTable();
            }
        }

        private void dgv_DanhSach_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            var band = e.Layout.Bands[0];
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            band.Override.HeaderAppearance.FontData.Bold = DefaultableBoolean.True;
            band.Columns["ID"].Hidden = true;

            band.Columns["NameType"].CellActivation = Activation.NoEdit;
            band.Columns["TotalCard"].CellActivation = Activation.NoEdit;
            band.Columns["TotalUsed"].CellActivation = Activation.NoEdit;
            band.Columns["TotalNotUsed"].CellActivation = Activation.NoEdit;
            band.Columns["TotalBlock"].CellActivation = Activation.NoEdit;
            band.Columns["TotalBalance"].CellActivation = Activation.NoEdit;

            band.Columns["NameType"].CellAppearance.TextHAlign = HAlign.Left;
            band.Columns["TotalCard"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["TotalUsed"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["TotalNotUsed"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["TotalBlock"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["TotalBalance"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["TotalBalance"].FormatMonney();

            #region Caption
            band.Columns["NameType"].Header.Caption = @"Mô Tả";
            band.Columns["TotalCard"].Header.Caption = @"Tổng số thẻ";
            band.Columns["TotalUsed"].Header.Caption = @"Tổng số thẻ đã phát hành - T";
            band.Columns["TotalNotUsed"].Header.Caption = @"Tổng số thẻ còn lại - R";
            band.Columns["TotalBlock"].Header.Caption = @"Tổng số thẻ đã khóa";
            band.Columns["TotalBalance"].Header.Caption = @"Số dư tài khoản";

            #endregion
            band.Override.HeaderClickAction = HeaderClickAction.SortSingle;
        }

        public void LocThongKeThe()
        {
            _formLoc.ModelItem = _modelItem;
            _formLoc.User = _userItem;
            _formLoc.ShowDialog();
        }

        #region Event
        private void FillterTkThe(object sender, List<ThongKeTheItem> lst)
        {
            dgv_DanhSach.DataSource = lst.ToDataTable();
            var row = dgv_DanhSach.DisplayLayout.Bands[0].AddNew();
            row.Cells["NameType"].Value = "Tổng";
            row.Cells["TotalCard"].Value = lst.Sum(c => c.TotalCard);
            row.Cells["TotalUsed"].Value = lst.Sum(c => c.TotalUsed);
            row.Cells["TotalNotUsed"].Value = lst.Sum(c => c.TotalNotUsed);
            row.Cells["TotalBlock"].Value = lst.Sum(c => c.TotalBlock);
            row.Cells["TotalBalance"].Value = lst.Sum(c => c.TotalBalance);
            row.CellAppearance.BackColor = Color.LightCyan;
            row.CellAppearance.FontData.Bold = DefaultableBoolean.True;
            row.CellAppearance.FontData.SizeInPoints = 14;
        }

        private void FillterTkTheChiTiet(object sender, List<CardItem> lst)
        {
            dgv_DanhSachChitiet.DataSource = lst.ToDataTable();
        }
        #endregion

        public void Export(string path)
        {
            try
            {
                var fileName = string.Format("thong_ke_the{0}.xlsx", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
                var filePath = Path.Combine(path, fileName);
                Excel.ExportToTalCard(filePath, dgv_DanhSach);
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }

        private void dgv_DanhSachChiTiet_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            var band = e.Layout.Bands[0];
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            band.Override.HeaderAppearance.FontData.Bold = DefaultableBoolean.True;
            band.Columns["ID"].Hidden = true;

            band.Columns["CustomerID"].CellActivation = Activation.NoEdit;
            band.Columns["CardNumber"].CellActivation = Activation.NoEdit;
            band.Columns["CustomerName"].CellActivation = Activation.NoEdit;
            band.Columns["Balance"].CellActivation = Activation.NoEdit;
            band.Columns["CardType"].CellActivation = Activation.NoEdit;
            band.Columns["CardStatus"].CellActivation = Activation.NoEdit;
            band.Columns["DateIssue"].CellActivation = Activation.NoEdit;

            band.Columns["Balance"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["Balance"].FormatMonney();

            #region Caption
            band.Columns["CustomerID"].Header.Caption = @"Mã khách hàng";
            band.Columns["CardNumber"].Header.Caption = @"Số thẻ";
            band.Columns["CustomerName"].Header.Caption = @"Tên tài khoản";
            band.Columns["Balance"].Header.Caption = @"Số dư tài khoản";
            band.Columns["CardType"].Header.Caption = @"Loại thẻ";
            band.Columns["CardStatus"].Header.Caption = @"Trạng thái";
            band.Columns["DateIssue"].Header.Caption = @"Ngày phát hành";

            #endregion

            band.Override.HeaderClickAction = HeaderClickAction.SortSingle;
        }
    }
}
