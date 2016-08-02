using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FDI.DA;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using PerpetuumSoft.Reporting.View;

namespace NetPos.FrmCtrl
{
    public partial class frmTheTrungNhau : UserControl
    {
        readonly CardDA _da = new CardDA();
        public frmTheTrungNhau()
        {
            InitializeComponent();
        }

        public void LoadGird()
        {
            var lst = _da.GetDuplicateCard();
            dgv_DanhSach.DataSource = lst.ToDataTable();
        }

        private void dgv_DanhSach_InitializeLayout(object sender, InitializeLayoutEventArgs e)
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
                MessageBox.Show(@"Xóa thẻ thành công !");

            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }

        public void Printf()
        {
            try
            {
                //var lst = _da.GetAll();
                reportManager.DataSources.Clear();
                reportManager.DataSources.Add("danhsach", dgv_DanhSach.DataSource);
                rpCard.FilePath = Application.StartupPath + @"\Reports\rpCard.rst";
                rpCard.Prepare();
                var previewForm = new PreviewForm(rpCard)
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
                var fileName = string.Format("danh_sach_the_{0}.xlsx", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
                var filePath = Path.Combine(path, fileName);
                Excel.ExportToCard(filePath, dgv_DanhSach);

            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }

    }
}
