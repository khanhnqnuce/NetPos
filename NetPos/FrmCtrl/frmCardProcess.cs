using System;
using System.Windows.Forms;
using FDI;
using FDI.DA;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace NetPos.FrmCtrl
{
    public partial class frmCardProcess : UserControl
    {
        readonly CardProcessDA _da = new CardProcessDA();
        public frmCardProcess()
        {
            InitializeComponent();
        }

        private void frmCardProcess_Load(object sender, EventArgs e)
        {
            var lst = _da.GetAdminAllSimple();
            dgv_DanhSach.DataSource = lst.ToDataTable();
        }

        private void dgv_DanhSach_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            var band = e.Layout.Bands[0];

            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;

            band.Columns["ID"].Hidden = true;

            band.Columns["Date"].CellActivation = Activation.NoEdit;
            band.Columns["CardNumber"].CellActivation = Activation.NoEdit;
            band.Columns["Value"].CellActivation = Activation.NoEdit;

            band.Columns["Date"].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["CardNumber"].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["Value"].CellAppearance.TextHAlign = HAlign.Right;

            #region Caption
            //band.Columns["Date"].Header.Caption = @"Thời gian";
            //band.Columns["MemoryID"].Header.Caption = @"MemoryID";
            //band.Columns["CardNumber"].Header.Caption = @"Mã thẻ";

            #endregion
            band.Override.HeaderClickAction = HeaderClickAction.SortSingle;
        }
    }
}
