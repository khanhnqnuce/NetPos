using System;
using System.Windows.Forms;
using FDI.DA;

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
            dataGridView1.DataSource = _da.GetAdminAllSimple();
            //MyString.Slug("nguyen quang khanh");
            //label1.Text = MyString.Slug("nguyen quang khanh");
            //label2.Text = Common.UserName;fdfd    
            
        }

        private void quảnLýThẻToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuThem_Click(object sender, EventArgs e)
        {
            var form = new frmAddCard();
            form.Show();
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
            this.Close();
        }
       
    }
}
