using System;
using System.Windows.Forms;
using FDI;
using FDI.DA;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace NetPos.FrmCtrl
{
    public partial class frmBCDoanhThuTongHop : UserControl
    {
        readonly RecordDA _da = new RecordDA();
        public frmBCDoanhThuTongHop()
        {
            InitializeComponent();
        }

        private void frmBCDoanhThuTongHop_Load(object sender, EventArgs e)
        {
            var lst = _da.GetBcKhuVucItems();
            dgv_DanhSach.DataSource = lst.ToDataTable();
        }

        private void dgv_DanhSach_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            var band = e.Layout.Bands[0];
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            band.Columns["ID"].Hidden = true;

            band.Columns["Area"].CellActivation = Activation.NoEdit;
            band.Columns["CountValue"].CellActivation = Activation.NoEdit;

            band.Columns["Area"].CellAppearance.TextHAlign = HAlign.Left;
            band.Columns["CountValue"].CellAppearance.TextHAlign = HAlign.Right;

            #region Caption
            band.Columns["Area"].Header.Caption = @"Khu vực";
            band.Columns["CountValue"].Header.Caption = @"Tổng giao dịch";

            #endregion
            band.Override.HeaderClickAction = HeaderClickAction.SortSingle;
        }
    }
}
