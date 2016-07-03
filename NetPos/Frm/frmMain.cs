using System;
using System.Windows.Forms;
using FDI.DA.Admin;
using FDI.Utils;

namespace NetPos.Frm
{
    public partial class frmMain : Form
    {
        readonly CustomerDA _da = new CustomerDA("#");
        public frmMain()
        {
           
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = _da.GetAllListSimple();
            //MyString.Slug("nguyen quang khanh");
            //label1.Text = MyString.Slug("nguyen quang khanh");
            //label2.Text = Common.UserName;fdfd    
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
