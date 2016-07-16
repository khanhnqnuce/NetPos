using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FDI;
using FDI.Base;
using FDI.DA;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using NetPos.Frm;

namespace NetPos.FrmCtrl
{
    public partial class frmCard : UserControl
    {
        readonly CardDA _da = new CardDA(); 

        public frmCard()
        {
            InitializeComponent();
        }

        private void frmCard_Load(object sender, EventArgs e)
        {
            var lst = _da.GetAll();
            //var a = ToDataTable(lst);
            dgv_DanhSach.DataSource = lst.ToDataTable();
        }

        private void dgv_DanhSach_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            var band = e.Layout.Bands[0];
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
            band.Columns["RowNumber"].MinWidth = 50;
            band.Columns["RowNumber"].MaxWidth = 70;

            band.Columns["Code"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["CardNumber"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["AccountName"].CellAppearance.TextHAlign = HAlign.Left;
            band.Columns["Balance"].CellAppearance.TextHAlign = HAlign.Right;
            band.Columns["Balance"].FormatMonney();
            band.Columns["CardTypeCode"].CellAppearance.TextHAlign = HAlign.Left;
            band.Columns["IsRelease"].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["IsLockCard"].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["IsEdit"].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["RowNumber"].CellAppearance.TextHAlign = HAlign.Center;

            #region Caption
            band.Columns["Code"].Header.Caption = @"Mã khách hàng";
            band.Columns["CardNumber"].Header.Caption = @"Số thẻ";
            band.Columns["AccountName"].Header.Caption = @"Tên tài khoản";
            band.Columns["Balance"].Header.Caption = @"Số dư tài khoản";
            band.Columns["CardTypeCode"].Header.Caption = @"Loại thẻ";
            band.Columns["IsRelease"].Header.Caption = @"Đã được phát hành";
            band.Columns["IsEdit"].Header.Caption = @"Thẻ thành viên";
            band.Columns["IsLockCard"].Header.Caption = @"Khóa thẻ";
            band.Columns["RowNumber"].Header.Caption = @"STT";

            #endregion
            band.Override.HeaderClickAction = HeaderClickAction.SortSingle;
        }

        private void dgv_DanhSach_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            Edit();
        }

        public void Add()
        {
            try
            {
                var form = new frmAddCard();
                form.AddCard += AddCard;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }

        public void Edit()
        {
            try
            {
                var frm = new frmEditCard();
                var id = dgv_DanhSach.ActiveRow.Cells["ID"].Text;
                if (string.IsNullOrEmpty(id)) return;
                frm.Id = int.Parse(id);
                frm.ShowDialog();
                if (frm.IsUpdate)
                {
                    dgv_DanhSach.ActiveRow.Cells["Code"].Value = frm.TblCardItem.Code;
                    dgv_DanhSach.ActiveRow.Cells["AccountName"].Value = frm.TblCardItem.AccountName;
                    dgv_DanhSach.ActiveRow.Cells["CardTypeCode"].Value = frm.TblCardItem.CardTypeCode;
                    dgv_DanhSach.ActiveRow.Cells["IsEdit"].Value = frm.TblCardItem.IsEdit;
                    dgv_DanhSach.ActiveRow.Cells["IsLockCard"].Value = frm.TblCardItem.IsLockCard;
                    dgv_DanhSach.ActiveRow.Cells["IsRelease"].Value = frm.TblCardItem.IsRelease;
                }
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }

        public void Delete()
        {
            var lst = new List<int>();
            try
            {
                var check = MessageBox.Show(@"Bạn có chắc chắn muốn xóa thẻ ?", @"Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.No == check) return;

                if (dgv_DanhSach.Selected.Rows.Count > 0)
                {
                    lst.AddRange(from UltraGridRow row in dgv_DanhSach.Selected.Rows select row.Cells["ID"].Text into id where !string.IsNullOrEmpty(id) select int.Parse(id));
                    dgv_DanhSach.DeleteSelectedRows(false);
                }
                else if (dgv_DanhSach.ActiveRow != null)
                {
                    var id = dgv_DanhSach.ActiveRow.Cells["ID"].Text;
                    if (!string.IsNullOrEmpty(id))
                    {
                        lst.Add(int.Parse(id));
                    }
                    dgv_DanhSach.ActiveRow.Delete(false);
                }
                else
                {
                    MessageBox.Show(@"Bạn chưa chọn bản ghi nào !");
                }

                var lstCard = _da.Get(lst);
                foreach (var item in lstCard)
                {
                    _da.Delete(item);
                }
                _da.Save();
                
                
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }

        #region Event
        private void AddCard(object sender, tblCard cardItem)
        {
            try
            {
                var row = dgv_DanhSach.DisplayLayout.Bands[0].AddNew();
                row.Cells["ID"].Value = cardItem.Id;
                row.Cells["Code"].Value = cardItem.Code;
                row.Cells["CardNumber"].Value = cardItem.CardNumber;
                row.Cells["CardTypeCode"].Value = cardItem.CardTypeCode;
                row.Cells["AccountName"].Value = cardItem.AccountName;
                row.Cells["Balance"].Value = cardItem.Balance;
                row.Cells["IsEdit"].Value = cardItem.IsEdit;
                row.Cells["IsLockCard"].Value = cardItem.IsLockCard;
                row.Cells["IsRelease"].Value = cardItem.IsRelease;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }
        #endregion
    }
}
