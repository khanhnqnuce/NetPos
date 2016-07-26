using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using FDI;
using FDI.Base;
using FDI.DA;
using FDI.Simple;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using NetPos.Frm;
using PerpetuumSoft.Reporting.View;
using QLSV.Frm.Frm;

namespace NetPos.FrmCtrl
{
    public partial class frmCard : BaseControl
    {
        readonly CardDA _da = new CardDA();

        public frmCard()
        {
            InitializeComponent();
        }

        private void frmCard_Load(object sender, EventArgs e)
        {
            var thread = new Thread(LoadGrid) { IsBackground = true };
            thread.Start();
            OnShowDialog("Loading...");
        }

        private void LoadGrid()
        {
            var a = dgv_DanhSach;

            var lst = _da.GetAll();
            dgv_DanhSach.DataSource = lst.ToDataTable();

            lock (LockTotal)
            {
                OnCloseDialog();
            }
        }

        private void dgv_DanhSach_InitializeLayout(object sender, InitializeLayoutEventArgs e)
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
            band.Columns["Balance"].FormatMonney();
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

        private void dgv_DanhSach_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            View();
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
                if (dgv_DanhSach.ActiveRow == null) return;
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

        public void View()
        {
            try
            {
                if (dgv_DanhSach.ActiveRow == null) return;
                var frm = new FrmCardDetails();
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

        public void Rename()
        {
            try
            {
                if (dgv_DanhSach.ActiveRow == null) return;
                var frm = new frmMatDoiThe();
                var cardNumber = dgv_DanhSach.ActiveRow.Cells["CardNumber"].Text;
                var idCard = dgv_DanhSach.ActiveRow.Cells["ID"].Text;
                frm.IdCard = int.Parse(idCard);
                if (string.IsNullOrEmpty(cardNumber)) return;
                frm.CardNumber = cardNumber;
                frm.ShowDialog();
                if (frm.IsUpdate)
                {
                    dgv_DanhSach.ActiveRow.Cells["CardNumber"].Value = frm.CardNumber;
                    dgv_DanhSach.ActiveRow.Cells["IsLockCard"].Value = frm.IsLockCard;
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

        private void dgv_DanhSach_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    ContextMenu m = new ContextMenu();
            //    m.MenuItems.Add(new MenuItem("Cut"));
            //    m.MenuItems.Add(new MenuItem("Copy"));
            //    m.MenuItems.Add(new MenuItem("Paste"));

            //    int currentMouseOverRow = dgv_DanhSach.HitTest(e.X, e.Y).RowIndex;

            //    if (currentMouseOverRow >= 0)
            //    {
            //        m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
            //    }

            //    m.Show(dgv_DanhSach, new Point(e.X, e.Y));

            //}
        }

        //private void btnTimKiem_Click(object sender, EventArgs e)
        //{
        //    var code = txtMaKhachHang.Text;
        //    var NumberCard = txtMaThe.Text;
        //    var name = txtName.Text;
        //    var TypeCard = cboTypeCard.SelectedValue.ToString();

        //    var lst = _da.FindCardItems(code, NumberCard, name, TypeCard);
        //    dgv_DanhSach.DataSource = lst.ToDataTable();

        //}

        //private void btnReset_Click(object sender, EventArgs e)
        //{
        //    txtMaKhachHang.Text = "";
        //    txtMaThe.Text = "";
        //    txtName.Text = "";
        //    cboTypeCard.SelectedItem = 0;
        //    var lst = _da.GetAll();
        //    dgv_DanhSach.DataSource = lst.ToDataTable();
        //}

        public void LocCard()
        {
            var form = new frmLocCard();
            form.FillterRecord += FillterRecord;
            form.ShowDialog();
        }

        #region Event
        private void FillterRecord(object sender, List<CardItem> lst)
        {
            dgv_DanhSach.DataSource = lst.ToDataTable();
        }
        #endregion

        #region Loadding

        private FrmLoadding _loading;

        private void ShowLoading(object sender, string msg)
        {
            _loading = new FrmLoadding();
            _loading.Update(msg);
            _loading.ShowDialog();
        }

        private void KillLoading(object sender)
        {
            try
            {
                if (_loading != null)
                {
                    _loading.Invoke((Action)(() =>
                    {
                        _loading.Close();
                        //_loading.Dispose();
                        _loading = null;
                    }));
                }
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }

        public void UpdateLoading(object sender, string strInfo)
        {
            if (_loading != null)
            {
                _loading.Invoke((Action)(() => _loading.Update(strInfo)));
            }
        }

        #endregion
    }
}


