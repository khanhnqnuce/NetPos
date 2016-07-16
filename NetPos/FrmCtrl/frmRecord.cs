using System;
using System.Windows.Forms;
using FDI;
using FDI.DA;

namespace NetPos.FrmCtrl
{
    public partial class frmRecord : UserControl
    {
        readonly RecordDA _da = new RecordDA();
        public frmRecord()
        {
            InitializeComponent();
        }

        private void frmRecord_Load(object sender, EventArgs e)
        {
            var lst = _da.GetAdminAllSimple();
            dgv_DanhSach.DataSource = lst.ToDataTable();
        }
    }
}
