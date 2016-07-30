using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FDI;
using FDI.Simple;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using NetPos.Frm;

namespace NetPos.FrmCtrl
{
    public partial class frmDTBanHang : UserControl
    {
        readonly frmLocDTBanHang _formLoc;
        private ModelItem _modelItem = new ModelItem();
        private UserItem _userItem;
        public frmDTBanHang(UserItem userItem)
        {
            _userItem = userItem;
            _formLoc = new frmLocDTBanHang(_modelItem);
            _formLoc.FillterRecordBuyProduct += FillterRecordBuyProduct;
            InitializeComponent();
        }

        private void frmDTBanThe_Load(object sender, EventArgs e)
        {

        }

        public void Loc()
        {
            _formLoc.ModelItem = _modelItem;
            //_formLoc.LoadDefault();
            _formLoc.User = _userItem;
            _modelItem = _formLoc.ModelItem;
            _formLoc.ShowDialog();
        }

        #region Event
        private void FillterRecordBuyProduct(object sender, List<ThongKeItem> lst)
        {
            dgv_DanhSach.DataSource = lst.ToDataTable();
        }
        #endregion

        private void dgv_DanhSach_InitializeLayout_1(object sender, InitializeLayoutEventArgs e)
        {
            var band = e.Layout.Bands[0];
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            band.Columns["ID"].Hidden = true;

            band.Columns["Name"].CellActivation = Activation.NoEdit;
            band.Columns["Value"].CellActivation = Activation.NoEdit;

            band.Columns["Name"].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["Value"].CellAppearance.TextHAlign = HAlign.Right;

            band.Columns["Name"].Header.Caption = @"Thông tin";
            band.Columns["Value"].Header.Caption = @"Số lượng";
            band.Columns["Value"].FormatMonney();
        }

    }
}
