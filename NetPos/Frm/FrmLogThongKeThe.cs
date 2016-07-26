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
using FDI.Simple;

namespace NetPos.Frm
{
    public partial class FrmLogThongKeThe : Form
    {
        public delegate void CustomHandler(object sender, List<ThongKeTheItem> lst);
        public event FrmLogThongKeThe.CustomHandler FillterTkThe;
        protected virtual void OnFillterTkThe(List<ThongKeTheItem> hs)
        {
            var handler = FillterTkThe;
            if (handler != null) handler(this, hs);
        }
        public FrmLogThongKeThe()
        {
            InitializeComponent();
        }

        private void FrmLogThongKeThe_Load(object sender, EventArgs e)
        {
            RecordDA _recordDa = new RecordDA();
            
            // load buiding
            var lstBuiding = _recordDa.GetBuidingItems();
            lstBuiding.Insert(0, new BuidingItem { Name = "-----------------Chọn------------------", Code = "" });
            cboBuiding.DataSource = lstBuiding;
            cboBuiding.DisplayMember = "Name";
            cboBuiding.ValueMember = "Code";

            // load area
            var lstArea = _recordDa.GetAreaItems();
            lstArea.Insert(0, new AreaItem { Desc = "-----------------Chọn------------------", Code = "" });
            cboArea.DataSource = lstArea;
            cboArea.DisplayMember = "Desc";
            cboArea.ValueMember = "Code";

            // load Object
            var lstObj = _recordDa.GetObjectItems();
            lstObj.Insert(0, new ObjectItem { Name = "-----------------Chọn------------------", Code = "" });
            cboObject.DataSource = lstObj;
            cboObject.DisplayMember = "Name";
            cboObject.ValueMember = "Code";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThongKeTheDA _tkTheDa = new ThongKeTheDA();

            var Buiding = cboBuiding.SelectedValue.ToString();
            var Area = cboArea.SelectedValue.ToString();
            var Object = cboObject.SelectedValue.ToString();

            var items = _tkTheDa.GetThongKeTheItems(Buiding, Area, Object);
            OnFillterTkThe(items);
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            cboBuiding.SelectedValue = "";
            cboArea.SelectedValue = "";
            cboObject.SelectedValue = "";
            this.Close();
        }
    }
}
