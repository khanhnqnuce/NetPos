using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using FDI;
using FDI.Base;
using FDI.DA;
using FDI.Simple;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using NetPos.FrmCtrl;

namespace NetPos.Frm
{
    public partial class frmMain : Form
    {
        readonly CardDA _da = new CardDA();
        public frmMain()
        {
            InitializeComponent();
        }

        private static void ShowControl(Control frm, Control panel)
        {
            try
            {
                panel.Controls.Clear();
                frm.Dock = DockStyle.Fill;
                panel.Controls.Add(frm);
                panel.Controls[frm.Name].Focus();
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            var lst = _da.GetAdminAllSimple();
            //var a = ToDataTable(lst);
            dgv_DanhSach.DataSource = lst.ToDataTable();
            //dataGridViewCard.Columns[0].HeaderText = "My Header";
        }

        private void menuThem_Click(object sender, EventArgs e)
        {
            var form = new frmAddCard();
            form.AddCard += AddCard;
            form.ShowDialog();
        }

        private void menuSua_Click(object sender, EventArgs e)
        {
            var form = new frmEditCard();
            form.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuTheTrungNhau_Click(object sender, EventArgs e)
        {
            var form = new frmTheTrungNhau();
            form.Show();
        }

        private void menuDanhSachDen_Click(object sender, EventArgs e)
        {
            var form = new frmDachSachDen();
            ShowControl(form,pn_Main);
        }

        private void menuThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "", MessageBoxButtons.YesNo);
            if (kq == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dgv_DanhSach_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
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

        #region Event
        private void AddCard(object sender, tblCard cardItem)
        {
            try
            {
                var row = dgv_DanhSach.DisplayLayout.Bands[0].AddNew();
                row.Cells["Code"].Value = cardItem.Code;
                row.Cells["CardNumber"].Value = cardItem.CardNumber;
                row.Cells["CardTypeCode"].Value = cardItem.CardTypeCode;
                row.Cells["AccountName"].Value = cardItem.AccountName;
                row.Cells["Balance"].Value = cardItem.Balance;
                row.Cells["IsEdit"].Value = cardItem.IsEdit;
                row.Cells["IsLockCard"].Value = cardItem.IsLockCard;
                row.Cells["IsRelease"].Value = cardItem.IsRelease;
                //var tb = (List<CardItem>)dgv_DanhSach.DataSource;
                //tb.Clear();
                //tb.Add(cardItem);
                //dgv_DanhSach.DataSource = tb;
                //dgv_DanhSach.DataSource = new List<CardItem>();
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }
        #endregion

        private void menuThongKe_Click(object sender, EventArgs e)
        {

        }

        private void menuThongKeThe_Click(object sender, EventArgs e)
        {
            var form = new frmCard();
            ShowControl(form, pn_Main);
        }

        private void menuTheTrungNhau_Click_1(object sender, EventArgs e)
        {
            var form = new frmTheTrungNhau();
            ShowControl(form, pn_Main);
        }

        private void menuNhatKyLog_Click(object sender, EventArgs e)
        {
            var form = new frmLog();
            ShowControl(form, pn_Main);
        }

        private void menuSuKienCanhBao_Click(object sender, EventArgs e)
        {
            var form = new frmEventAlarm();
            ShowControl(form, pn_Main);
        }

        private void menuDSNapTien_Click(object sender, EventArgs e)
        {
            var form = new frmCardProcess();
            ShowControl(form, pn_Main);
        }

        private void menuBackUpDuLieu_Click(object sender, EventArgs e)
        {
            var form = new frmDataBackup();
            ShowControl(form, pn_Main);
        }

        private void MenuTKThe_Click(object sender, EventArgs e)
        {
            var form = new frmThongKeThe();
            ShowControl(form, pn_Main);
        }

        private void menuBaoCaoDanhThuChiTiet_Click(object sender, EventArgs e)
        {
            var form = new frmRecord();
            ShowControl(form, pn_Main);
        }

        private void menuMatDoiThe_Click(object sender, EventArgs e)
        {
            var form = new frmMatDoiThe();
            form.Show();
        }

    }
}
