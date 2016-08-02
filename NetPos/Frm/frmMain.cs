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

        frmCard _frmCard;
        frmRecord _frmRecord;
        readonly frmTheTrungNhau _frmTheTrung;
        readonly frmDachSachDen _frmDachSachDen;
        readonly frmThongKeThe _frmTkThe;
        readonly frmDTBanThe _frmDtBanThe;
        readonly frmDTBanHang _frmDtBanHang;
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
            _frmDtBanThe = new frmDTBanThe(_userItem);
            _frmDtBanHang = new frmDTBanHang(_userItem);
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
            ShowControl(_frmCard, pn_Main);
            _frmCard.LoadGrid();
        }

        private void menuSua_Click(object sender, EventArgs e)
        {
            _frmCard.Edit();
        }

        private void menuTheTrungNhau_Click(object sender, EventArgs e)
        {
            _process = Process.DoubleCard;
            Function();
            ShowControl(_frmTheTrung, pn_Main);
            _frmTheTrung.LoadGird();
        }

        private void menuDanhSachDen_Click(object sender, EventArgs e)
        {
            _process = Process.BackList;
            Function();
            ShowControl(_frmDachSachDen, pn_Main);
            _frmDachSachDen.LoadGrid();
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
            _frmRecord = new frmRecord();
            ShowControl(_frmRecord, pn_Main);
            _frmRecord.Loc();
        }

        private void menuMatDoiThe_Click(object sender, EventArgs e)
        {
            _frmCard.Rename();
        }

        private void menuXoa_Click(object sender, EventArgs e)
        {
            switch (_process)
            {
                case Process.Card:
                    _frmCard.Delete();
                    break;
                case Process.DoubleCard:
                    _frmTheTrung.Delete();
                    break;
            }

        }

        private void menuDSThe_Click(object sender, EventArgs e)
        {
            _process = Process.Card;
            Function();
            _frmCard = new frmCard();
            ShowControl(_frmCard, pn_Main);
            _frmCard.LoadGrid();
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
                    _frmDtBanThe.Loc();
                    break;
                case Process.DTBanHang:
                    _frmDtBanHang.Loc();
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
                    menuSua.Visible = false;
                    menuXoa.Visible = true;
                    menuMatDoiThe.Visible = false;
                    menuLoc.Visible = false;
                    menuIn.Visible = true;
                    menuXuatKhau.Visible = true;
                    menuThoat.Visible = true;
                    break;
                case Process.ReportCard:
                    menuXemThongTin.Visible = false;
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
            ShowControl(_frmDtBanThe, pn_Main);
            _frmDtBanThe.Loc();
        }

        private void menuBCDTBanHang_Click(object sender, EventArgs e)
        {
            _process = Process.DTBanHang;
            Function();
            ShowControl(_frmDtBanHang, pn_Main);
            _frmDtBanHang.Loc();
        }
    }
}
