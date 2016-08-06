using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FDI.DA;
using FDI.Simple;

namespace NetPos.Frm
{
    public partial class FrmLogThongKeThe : Form
    {
        readonly CardDA _cardDa = new CardDA();
        readonly RecordDA _recordDa = new RecordDA();
        public ModelItem ModelItem;
        public UserItem User;
        public delegate void CustomHandler(object sender, List<ThongKeTheItem> lst);
        public event FrmLogThongKeThe.CustomHandler FillterTkThe;
        protected virtual void OnFillterTkThe(List<ThongKeTheItem> hs)
        {
            var handler = FillterTkThe;
            if (handler != null) handler(this, hs);
        }

        public delegate void CustomHandlerDetail(object sender, List<CardItem> lst);
        public event FrmLogThongKeThe.CustomHandlerDetail FillterTkTheChiTiet;
        protected virtual void OFillterTkTheChiTiet(List<CardItem> hs)
        {
            var handler = FillterTkTheChiTiet;
            if (handler != null) handler(this, hs);
        }

        public FrmLogThongKeThe(ModelItem modelItem)
        {
            ModelItem = modelItem;
            InitializeComponent();
        }

        private void FrmLogThongKeThe_Load(object sender, EventArgs e)
        {

            if (User.Right1 == 1)
            {
                var lstBuiding = _recordDa.GetBuidingItems();
                lstBuiding.Insert(0, new BuidingItem { Name = "", Code = "" });
                cboBuiding.DataSource = lstBuiding;
                cboBuiding.DisplayMember = "Name";
                cboBuiding.ValueMember = "Code";

                var lstArea = _recordDa.GetAreaItems();
                lstArea.Insert(0, new AreaItem { Desc = "", Code = "" });
                cboArea.DataSource = lstArea;
                cboArea.DisplayMember = "Desc";
                cboArea.ValueMember = "Code";

                var lstObj = _recordDa.GetObjectItems();
                lstObj.Insert(0, new ObjectItem { Name = "", Code = "" });
                cboObject.DataSource = lstObj;
                cboObject.DisplayMember = "Name";
                cboObject.ValueMember = "Code";
            }
            else
            {
                cboBuiding.Enabled = false;

                List<AreaItem> lstArea = new List<AreaItem>();
                lstArea.Insert(0, new AreaItem { Desc = User.AreaName, Code = User.AreaCode });
                cboArea.DataSource = lstArea;
                cboArea.DisplayMember = "Desc";
                cboArea.ValueMember = "Code";
                cboArea.SelectedValue = User.AreaCode;

                var area = User.AreaCode;
                var lstObj = _cardDa.GetObject(area);
                lstObj.Insert(0, new ObjectItem { Name = "", Code = "" });
                cboObject.DataSource = lstObj;
                cboObject.DisplayMember = "Name";
                cboObject.ValueMember = "Code";
            }
            LoadDefault();
        }

        public void LoadDefault()
        {
            cboObject.SelectedValue = ModelItem.ObjectCode ?? "";
            cboArea.SelectedValue = ModelItem.AreaCode ?? "";
            cboBuiding.SelectedValue = ModelItem.BuidingCode ?? "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThongKeTheDA _tkTheDa = new ThongKeTheDA();

            var buiding = "";
            if (User.Right1 == 1)
            {
                buiding = cboBuiding.SelectedValue.ToString();
            }

            var Area = cboArea.SelectedValue.ToString();
            var Object = cboObject.SelectedValue.ToString();

            var items = _tkTheDa.GetThongKeTheItems(buiding, Area, Object);
            OnFillterTkThe(items);

            var list = _cardDa.ReportDetailCard(buiding, Area, Object);
            OFillterTkTheChiTiet(list);

            ModelItem.ObjectCode = cboObject.SelectedValue.ToString();
            ModelItem.BuidingCode = buiding;
            ModelItem.AreaCode = cboArea.SelectedValue.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            cboArea.SelectedIndex = 0;
            cboBuiding.SelectedValue = "";
            cboObject.SelectedIndex = 0;
            this.Close();
        }

        private void cboBuiding_SelectedIndexChanged(object sender, EventArgs e)
        {
            var buiding = cboBuiding.SelectedValue.ToString();
            if (!String.IsNullOrEmpty(buiding))
            {
                var lstArea = _cardDa.GetArea(buiding);
                lstArea.Insert(0, new AreaItem { Desc = "", Code = "" });
                cboArea.DataSource = lstArea;
            }
            else
            {
                var lstArea = _recordDa.GetAreaItems();
                lstArea.Insert(0, new AreaItem { Desc = "", Code = "" });
                cboArea.DataSource = lstArea;
            }
            cboArea.DisplayMember = "Desc";
            cboArea.ValueMember = "Code";
        }

        private void cboArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            var area = cboArea.SelectedValue.ToString();

            if (!String.IsNullOrEmpty(area))
            {
                var lstObj = _cardDa.GetObject(area);
                lstObj.Insert(0, new ObjectItem { Name = "", Code = "" });
                cboObject.DataSource = lstObj;
            }
            else
            {
                var lstObj = _recordDa.GetObjectItems();
                lstObj.Insert(0, new ObjectItem { Name = "", Code = "" });
                cboObject.DataSource = lstObj;
            }
            cboObject.DisplayMember = "Name";
            cboObject.ValueMember = "Code";
        }
    }
}
