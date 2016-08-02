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
            //LoadGrid();
            //var thread = new Thread(LoadGrid) { IsBackground = true };
            //thread.Start();
            //OnShowDialog("Loading...");
            //LocCard();
        }

        public void LoadGrid()
        {
            var lst = _da.GetAll();
            dgv_DanhSach.DataSource = lst.ToDataTable();
            lbTongGD.Text = lst.Count.ToString();
            //lock (LockTotal)
            //{
            //    OnCloseDialog();
            //}
        }

        private void dgv_DanhSach_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            var band = e.Layout.Bands[0];
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
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
                    dgv_DanhSach.ActiveRow.Cells["CustomerID"].Value = frm.CustomerItem.CustomerID;
                    dgv_DanhSach.ActiveRow.Cells["CustomerName"].Value = frm.CustomerItem.CustomerName;
                    dgv_DanhSach.ActiveRow.Cells["CardStatus"].Value = frm.CustomerItem.CardStatus;
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
                
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }

        public void LocCard()
        {
            var form = new frmLocCard();
            form.FillterRecord += FillterRecord;
            form.ShowDialog();
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

        private void FillterRecord(object sender, List<CardItem> lst)
        {
            dgv_DanhSach.DataSource = lst.ToDataTable();
            lbTongGD.Text = lst.Count.ToString();
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


