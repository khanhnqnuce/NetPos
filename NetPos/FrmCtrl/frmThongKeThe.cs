﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FDI;
using FDI.DA;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace NetPos.FrmCtrl
{
    public partial class frmThongKeThe : UserControl
    {
        readonly ThongKeTheDA _da = new ThongKeTheDA();
        public frmThongKeThe()
        {
            InitializeComponent();
        }

        private void frmThongKeThe_Load(object sender, EventArgs e)
        {
            var lst = _da.GetAdminAllSimple();
            dgv_DanhSach.DataSource = lst.ToDataTable();

           var row = dgv_DanhSach.DisplayLayout.Bands[0].AddNew();

           row.Cells["NameType"].Value = "Tổng";
           row.Cells["TotalCard"].Value = lst.Sum(c=>c.TotalCard);
           row.Cells["TotalUsed"].Value = lst.Sum(c => c.TotalUsed);
           row.Cells["TotalNotUsed"].Value = lst.Sum(c => c.TotalNotUsed);
           row.Cells["TotalBalance"].Value = lst.Sum(c => c.TotalBalance);
           row.CellAppearance.BackColor = Color.LightCyan;
            row.CellAppearance.FontData.Bold = DefaultableBoolean.True ;
            row.CellAppearance.FontData.SizeInPoints = 14;
        }

        private void dgv_DanhSach_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            var band = e.Layout.Bands[0];
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            band.Columns["ID"].Hidden = true;

            band.Columns["NameType"].CellActivation = Activation.NoEdit;
            band.Columns["TotalCard"].CellActivation = Activation.NoEdit;
            band.Columns["TotalUsed"].CellActivation = Activation.NoEdit;
            band.Columns["TotalNotUsed"].CellActivation = Activation.NoEdit;
            band.Columns["TotalBalance"].CellActivation = Activation.NoEdit;

            band.Columns["NameType"].CellAppearance.TextHAlign = HAlign.Left;
            band.Columns["TotalCard"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["TotalUsed"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["TotalNotUsed"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["TotalBalance"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["TotalBalance"].FormatMonney();

            #region Caption
            band.Columns["NameType"].Header.Caption = @"Mô Tả";
            band.Columns["TotalCard"].Header.Caption = @"Tổng số thẻ";
            band.Columns["TotalUsed"].Header.Caption = @"Tổng số thẻ đã phát hành - T";
            band.Columns["TotalNotUsed"].Header.Caption = @"Tổng số thẻ còn lại - R";
            band.Columns["TotalBalance"].Header.Caption = @"Số dư tài khoản";

            #endregion
            band.Override.HeaderClickAction = HeaderClickAction.SortSingle;
        }
    }
}
