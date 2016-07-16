using System.Windows.Forms;
using FDI;
using FDI.DA;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace NetPos.FrmCtrl
{
    public partial class frmDachSachDen : UserControl
    {
        readonly BackListDA _da = new BackListDA();
        public frmDachSachDen()
        {
            InitializeComponent();
        }

        private void frmDachSachDen_Load(object sender, System.EventArgs e)
        {
            var lst = _da.GetAdminAllSimple();
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
    }
}
