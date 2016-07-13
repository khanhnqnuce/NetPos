using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using FDI;
using FDI.Base;
using FDI.DA;
using FDI.Simple;

namespace NetPos.Frm
{
    public partial class frmMain : Form
    {
        readonly CardDA _da = new CardDA();
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var lst = _da.GetAdminAllSimple();
            //var a = ToDataTable(lst);
            dgv_DanhSach.DataSource = lst.ToDataTable();
            //dataGridViewCard.Columns[0].HeaderText = "My Header";
        }

        private void quảnLýThẻToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void menuMatDoiThe_Click(object sender, EventArgs e)
        {
            var form = new frmMatDoiThe();
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
            var form = new frmDanhSachDen();
            form.Show();
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

            #region Caption
            band.Columns["CardNumber"].Header.Caption = @"Số tài khoản";
            #endregion
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
    }
}
