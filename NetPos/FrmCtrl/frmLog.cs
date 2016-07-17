using System;
using System.Windows.Forms;
using FDI;
using FDI.DA;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace NetPos.FrmCtrl
{
    public partial class frmLog : UserControl
    {
        readonly LogDA _da = new LogDA();
        public frmLog()
        {
            InitializeComponent();
        }

        private void frmLog_Load(object sender, EventArgs e)
        {
            var lst = _da.GetAdminAllSimple();
            dgv_DanhSach.DataSource = lst.ToDataTable();
        }

        private void dgv_DanhSach_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            var band = e.Layout.Bands[0];
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            band.Columns["ID"].Hidden = true;

            band.Columns["Datetime"].CellActivation = Activation.NoEdit;
            band.Columns["Object"].CellActivation = Activation.NoEdit;
            band.Columns["Message"].CellActivation = Activation.NoEdit;

            band.Columns["Datetime"].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["Object"].CellAppearance.TextHAlign = HAlign.Left;
            band.Columns["Message"].CellAppearance.TextHAlign = HAlign.Left;

            #region Caption
            //band.Columns["Date"].Header.Caption = @"Thời gian";
            //band.Columns["MemoryID"].Header.Caption = @"MemoryID";
            //band.Columns["CardNumber"].Header.Caption = @"Mã thẻ";

            #endregion
            band.Override.HeaderClickAction = HeaderClickAction.SortSingle;
        }
    }
}
