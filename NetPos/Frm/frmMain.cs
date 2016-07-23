using System;
using System.Windows.Forms;
using FDI;
using FDI.Base;
using FDI.DA;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using NetPos.FrmCtrl;

namespace NetPos.Frm
{
    public partial class frmMain : Form
    {
        #region Contructor
        readonly frmCard _frmCard;
        frmRecord _frmRecord;
        #endregion

        private int _process;
        public frmMain()
        {
            InitializeComponent();
            _frmCard = new frmCard();
            _frmRecord = new frmRecord();
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
            ShowControl(_frmCard, pn_Main);
        }

        private void menuThem_Click(object sender, EventArgs e)
        {
            _frmCard.Add();
        }

        private void menuSua_Click(object sender, EventArgs e)
        {
            _frmCard.Edit();
        }

        private void menuTheTrungNhau_Click(object sender, EventArgs e)
        {
            var frm = new frmTheTrungNhau();
            ShowControl(frm, pn_Main);
        }

        private void menuDanhSachDen_Click(object sender, EventArgs e)
        {
            var form = new frmDachSachDen();
            ShowControl(form, pn_Main);
        }

        private void menuThoat_Click(object sender, EventArgs e)
        {
            var kq = MessageBox.Show(@"Bạn có chắc muốn thoát chương trình?", "", MessageBoxButtons.YesNo);
            if (kq == DialogResult.Yes)
            {
                Application.Exit();
            }
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
            
            ShowControl(_frmRecord, pn_Main);
        }

        private void menuMatDoiThe_Click(object sender, EventArgs e)
        {
            _frmCard.Rename();
        }

        private void menuXoa_Click(object sender, EventArgs e)
        {
            _frmCard.Delete();
        }

        private void menuDSThe_Click(object sender, EventArgs e)
        {
            _process = (int)Process.Card;
            var form = new frmCard();
            ShowControl(form, pn_Main);
        }

        private void menuLoc_Click(object sender, EventArgs e)
        {
            _frmRecord.Loc();
        }

        private void menuBaoCaoTongHop_Click(object sender, EventArgs e)
        {
            var form = new frmBCDoanhThuTongHop();
            ShowControl(form, pn_Main);
        }

    }
}
