using System;
using System.Drawing;
using System.Windows.Forms;
using FDI.DA;

namespace NetPos.Frm
{
    public partial class FrmDangNhap : Form
    {
        readonly UserDA _da = new UserDA();
        private frmMain _frmMain;
        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            lbdangnhap.ForeColor = Color.FromArgb(255, 255, 255);
            lbdangnhap.BackColor = Color.FromArgb(0, 171, 228);
        }

        private void lbdangnhap_MouseEnter(object sender, EventArgs e)
        {
            lbdangnhap.BackColor = Color.FromArgb(0, 255, 230);
        }

        private void lbdangnhap_MouseLeave(object sender, EventArgs e)
        {
            lbdangnhap.BackColor = Color.FromArgb(0, 171, 228);
        }

        private void lbdangnhap_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            if (string.IsNullOrEmpty(txtTaiKhoan.Text))
            {
                txtTaiKhoan.Focus();
            }
            else if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                txtMatKhau.Focus();
            }
            else
            {
                var item = _da.Login(txtTaiKhoan.Text, txtMatKhau.Text);
                if (item != null)
                {
                    Hide();
                    _frmMain = new frmMain(item);
                    _frmMain.Logout += Logout;
                    _frmMain.Show();
                }
                else
                {
                    MessageBox.Show(@"Sai thông tin đăng nhập");
                }
            }
        }

        public void Logout(object sender)
        {
            txtMatKhau.Clear();
            txtTaiKhoan.Clear();
            Show();
            txtTaiKhoan.Focus();
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }
        
    }
}
