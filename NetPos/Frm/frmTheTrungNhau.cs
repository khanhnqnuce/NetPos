using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FDI.DA;

namespace NetPos.Frm
{
    public partial class frmTheTrungNhau : Form
    {
        readonly CardDA _da = new CardDA();
        public frmTheTrungNhau()
        {
            InitializeComponent();
        }

        private void menuThoat_Click(object sender, EventArgs e)
        {
            dataGridViewCard.DataSource = _da.GetAll();
            this.Close();
        }
    }
}
