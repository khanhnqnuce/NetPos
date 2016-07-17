using System;
using System.Drawing;
using System.Windows.Forms;
using FDI;
using FDI.DA;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace NetPos.FrmCtrl
{
    public partial class frmTheTrungNhau : UserControl
    {
        readonly CardDA _da = new CardDA();
        public frmTheTrungNhau()
        {
            InitializeComponent();
        }

        private void frmTheTrungNhau_Load(object sender, EventArgs e)
        {
            var lst = _da.GetDuplicateCardTypeItems();
            dgv_DanhSach.DataSource = lst.ToDataTable();
        }

        private void dgv_DanhSach_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            var band = e.Layout.Bands[0];
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            band.Columns["ID"].Hidden = true;

            band.Columns["Code"].CellActivation = Activation.NoEdit;
            band.Columns["CardNumber"].CellActivation = Activation.NoEdit;
            band.Columns["AccountName"].CellActivation = Activation.NoEdit;
            band.Columns["Balance"].CellActivation = Activation.NoEdit;
            band.Columns["CardTypeCode"].CellActivation = Activation.NoEdit;
            band.Columns["IsRelease"].CellActivation = Activation.NoEdit;
            band.Columns["IsLockCard"].CellActivation = Activation.NoEdit;
            band.Columns["IsEdit"].CellActivation = Activation.NoEdit;

            band.Columns["Code"].MinWidth = 80;
            band.Columns["CardNumber"].MinWidth = 80;
            band.Columns["AccountName"].MinWidth = 200;
            band.Columns["Balance"].MinWidth = 120;
            band.Columns["CardTypeCode"].MinWidth = 150;
            band.Columns["IsRelease"].MinWidth = 120;
            band.Columns["IsLockCard"].MinWidth = 120;
            band.Columns["IsEdit"].MinWidth = 120;
             
            band.Columns["Code"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["CardNumber"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["AccountName"].CellAppearance.TextHAlign = HAlign.Left;
            band.Columns["Balance"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["CardTypeCode"].CellAppearance.TextHAlign = HAlign.Left;
            band.Columns["IsRelease"].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["IsLockCard"].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["IsEdit"].CellAppearance.TextHAlign = HAlign.Center;

            #region Caption
            band.Columns["Code"].Header.Caption = @"Mã khách hàng";
            band.Columns["CardNumber"].Header.Caption = @"Số thẻ";
            band.Columns["AccountName"].Header.Caption = @"Tên tài khoản";
            band.Columns["Balance"].Header.Caption = @"Số dư tài khoản";
            band.Columns["CardTypeCode"].Header.Caption = @"Loại thẻ";
            band.Columns["IsRelease"].Header.Caption = @"Đã được phát hành";
            band.Columns["IsEdit"].Header.Caption = @"Thẻ thành viên";
            band.Columns["IsLockCard"].Header.Caption = @"Khóa thẻ";

            #endregion
            band.Override.HeaderClickAction = HeaderClickAction.SortSingle;
        }
    }
}
