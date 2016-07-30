using System;
using System.Windows.Forms;
using FDI.Simple;
using NetPos.FrmCtrl;

namespace NetPos.Frm
{
    public partial class frmMain : Form
    {
        public delegate void CustomHandler(object sender);
        public event CustomHandler Logout;
        protected virtual void OnLogout()
        {
            var handler = Logout;
            if (handler != null) handler(this);
        }

        #region Contructor
        readonly frmCard _frmCard;
        readonly frmRecord _frmRecord;
        readonly frmThongKeThe _frmTkThe;
        readonly frmTheTrungNhau _frmTheTrung;
        readonly frmDachSachDen _frmDachSachDen;
        readonly frmDTBanThe _frmDTBanThe;
        readonly frmDTBanHang _frmDTBanHang;
        #endregion

        private Process _process = Process.Card;
        private UserItem _userItem;
        public frmMain(UserItem item)
        {
            _userItem = item;
            InitializeComponent();
            _frmCard = new frmCard();
            _frmRecord = new frmRecord();
            _frmTkThe = new frmThongKeThe(_userItem);
            _frmTheTrung = new frmTheTrungNhau();
            _frmDachSachDen = new frmDachSachDen();
            _frmDTBanThe = new frmDTBanThe(_userItem);
            _frmDTBanHang = new frmDTBanHang(_userItem);
        }

        private static void ShowControl(Control frm, Control panel)
        {
            try
            {
                panel.Controls.Clear();
                panel.Controls.Add(frm);
                frm.Dock = DockStyle.Fill;
                panel.Controls[frm.Name].Focus();
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Function();
            //_frmCard.ShowDialog += ShowLoading;
            //_frmCard.CloseDialog += KillLoading;
            //_frmCard.UpdateDialog += UpdateLoading;
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
            _process = Process.DoubleCard;
            ShowControl(_frmTheTrung, pn_Main);
        }

        private void menuDanhSachDen_Click(object sender, EventArgs e)
        {
            _process = Process.BackList;
            Function();
            var form = new frmDachSachDen();
            ShowControl(form, pn_Main);
        }

        private void menuThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuTKThe_Click(object sender, EventArgs e)
        {
            _process = Process.ReportCard;
            Function();
            ShowControl(_frmTkThe, pn_Main);
            if (_userItem.Right1 == 2)
            {
                _frmTkThe.LocThongKeThe();
            }
        }

        private void menuBaoCaoDanhThuChiTiet_Click(object sender, EventArgs e)
        {
            _process = Process.ReportDetail;
            Function();
            //_frmRecord.ShowDialog += ShowLoading;
            //_frmRecord.CloseDialog += KillLoading;
            //_frmRecord.UpdateDialog += UpdateLoading;
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
            _process = Process.Card;
            Function();
            var form = new frmCard();
            form.ShowDialog += ShowLoading;
            form.CloseDialog += KillLoading;
            form.UpdateDialog += UpdateLoading;
            ShowControl(form, pn_Main);
            //var a = new FrmProgessBar();
            //a.ShowDialog();
        }

        private void menuLoc_Click(object sender, EventArgs e)
        {

            switch (_process)
            {
                case Process.Card:
                    _frmCard.LocCard();
                    break;
                case Process.BackList:

                    break;
                case Process.DoubleCard:
                    break;
                case Process.ReportCard:
                    _frmTkThe.LocThongKeThe();
                    break;
                case Process.ReportDetail:
                    _frmRecord.Loc();
                    break;
                case Process.ReportTotal:
                    break;
                case Process.DTBanThe:
                    _frmDTBanThe.Loc();
                    break;
                case Process.DTBanHang:
                    _frmDTBanHang.Loc();
                    break;
            }
        }

        private void menuBaoCaoTongHop_Click(object sender, EventArgs e)
        {
            _process = Process.ReportTotal;
            Function();
            var form = new frmBCDoanhThuTongHop();
            ShowControl(form, pn_Main);
        }

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

        private void menuIn_Click(object sender, EventArgs e)
        {
            switch (_process)
            {
                case Process.Card:
                    _frmCard.Printf();
                    break;
                case Process.BackList:
                    _frmDachSachDen.Printf();
                    break;
                case Process.DoubleCard:
                    _frmTheTrung.Printf();
                    break;
                case Process.ReportCard:

                    break;
                case Process.ReportDetail:
                    _frmRecord.Printf();
                    break;
                case Process.ReportTotal:

                    break;
            }
        }

        private void Function()
        {
            switch (_process)
            {
                case Process.Card:
                    menuXemThongTin.Visible = true;
                    menuThem.Visible = _userItem.Right1 == 1;
                    menuSua.Visible = _userItem.Right1 == 1;
                    menuXoa.Visible = _userItem.Right1 == 1;
                    menuMatDoiThe.Visible = _userItem.Right1 == 1;
                    menuLoc.Visible = true;
                    menuIn.Visible = true;
                    menuXuatKhau.Visible = true;
                    menuThoat.Visible = true;
                    break;
                case Process.BackList:
                    menuXemThongTin.Visible = false;
                    menuThem.Visible = false;
                    menuSua.Visible = false;
                    menuXoa.Visible = false;
                    menuMatDoiThe.Visible = false;
                    menuLoc.Visible = true;
                    menuIn.Visible = true;
                    menuXuatKhau.Visible = true;
                    menuThoat.Visible = true;
                    break;
                case Process.DoubleCard:
                    menuXemThongTin.Visible = false;
                    menuThem.Visible = false;
                    menuSua.Visible = false;
                    menuXoa.Visible = false;
                    menuMatDoiThe.Visible = false;
                    menuLoc.Visible = true;
                    menuIn.Visible = true;
                    menuXuatKhau.Visible = true;
                    menuThoat.Visible = true;
                    break;
                case Process.ReportCard:
                    menuXemThongTin.Visible = false;
                    menuThem.Visible = false;
                    menuSua.Visible = false;
                    menuXoa.Visible = false;
                    menuMatDoiThe.Visible = false;
                    menuLoc.Visible = true;
                    menuIn.Visible = true;
                    menuXuatKhau.Visible = true;
                    menuThoat.Visible = true;
                    break;
                case Process.ReportDetail:
                    menuXemThongTin.Visible = false;
                    menuThem.Visible = false;
                    menuSua.Visible = false;
                    menuXoa.Visible = false;
                    menuMatDoiThe.Visible = false;
                    menuLoc.Visible = true;
                    menuIn.Visible = true;
                    menuXuatKhau.Visible = true;
                    menuThoat.Visible = true;
                    break;
                case Process.ReportTotal:
                    menuXemThongTin.Visible = false;
                    menuThem.Visible = false;
                    menuSua.Visible = false;
                    menuXoa.Visible = false;
                    menuMatDoiThe.Visible = false;
                    menuLoc.Visible = true;
                    menuIn.Visible = true;
                    menuXuatKhau.Visible = true;
                    menuThoat.Visible = true;
                    break;
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                var check = MessageBox.Show(@"Bạn có muốn thoát chương trình không?",
                    @"Thông báo",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) != DialogResult.OK;
                if (!check)
                {
                    OnLogout();
                }
                e.Cancel = check;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }
        private void menuXemThongTin_Click(object sender, EventArgs e)
        {
            _frmCard.View();
        }
        private void menuXuatKhau_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                switch (_process)
                {
                    case Process.Card:
                        _frmCard.Export(folderBrowserDialog1.SelectedPath);
                        break;
                    case Process.BackList:
                        _frmDachSachDen.Export(folderBrowserDialog1.SelectedPath);
                        break;
                    case Process.DoubleCard:
                        _frmTheTrung.Export(folderBrowserDialog1.SelectedPath);
                        break;
                    case Process.ReportCard:
                        _frmTkThe.Export(folderBrowserDialog1.SelectedPath);
                        break;
                    case Process.ReportDetail:
                        _frmRecord.Export(folderBrowserDialog1.SelectedPath);
                        break;
                    case Process.ReportTotal:

                        break;
                }
            }
        }

        private void menuBCDTBanThe_Click(object sender, EventArgs e)
        {
            _process = Process.DTBanThe;
            Function();
            ShowControl(_frmDTBanThe, pn_Main);
            _frmDTBanThe.Loc();
        }

        private void menuBCDTBanHang_Click(object sender, EventArgs e)
        {
            _process = Process.DTBanHang;
            Function();
            ShowControl(_frmDTBanHang, pn_Main);
            _frmDTBanHang.Loc();
        }
    }
}
