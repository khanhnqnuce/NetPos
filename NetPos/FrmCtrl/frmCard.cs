using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FDI;
using FDI.DA;

namespace NetPos.FrmCtrl
{
    public partial class frmCard : UserControl
    {
        readonly CardDA _da = new CardDA();
        public frmCard()
        {
            InitializeComponent();
        }

        private void frmCard_Load(object sender, EventArgs e)
        {
            var lst = _da.GetAdminAllSimple();
            //var a = ToDataTable(lst);
            dgv_DanhSach.DataSource = lst.ToDataTable();
        }
    }
}
