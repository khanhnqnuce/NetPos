using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FDI.DA;
using FDI.Simple;

namespace NetPos.Frm
{
    public partial class frmLocDTBanHang : Form
    {
        readonly CardDA _cardDa = new CardDA();
        readonly RecordDA _recordDa = new RecordDA();
        public ModelItem ModelItem;
        public delegate void CustomHandler(object sender, List<ThongKeItem> lst);
        public event CustomHandler FillterRecordBuyProduct;
        protected virtual void OnFillterRecordBuyProduct(List<ThongKeItem> hs)
        {
            var handler = FillterRecordBuyProduct;
            if (handler != null) handler(this, hs);
        }
        public frmLocDTBanHang(ModelItem modelItem)
        {
            ModelItem = modelItem;
            InitializeComponent();
        }

        private void frmLoc_Load(object sender, EventArgs e)
        {
            datStartDate.CustomFormat = @"dd/MM/yyyy HH:mm:ss";
            datEndDate.CustomFormat = @"dd/MM/yyyy HH:mm:ss";
            var date = DateTime.Now;
            datStartDate.Value = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
            datEndDate.Value = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
            // load buiding

            // load buiding
            var lstBuiding = _recordDa.GetBuidingItems();
            lstBuiding.Insert(0, new BuidingItem{ Name = "-----------------Chọn------------------", Code = "" });
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

            LoadDefault();

        }

        public void LoadDefault()
        {
            var date = DateTime.Now;
            cboObject.SelectedValue = ModelItem.ObjectCode ?? "";
            cboArea.SelectedValue = ModelItem.AreaCode ?? "";
            cboBuiding.SelectedValue = ModelItem.BuidingCode ?? "";
            datStartDate.Value = ModelItem.StartDate ?? new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
            datEndDate.Value = ModelItem.EndDate ?? new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var startDate = datStartDate.Value;
            var endDate = datEndDate.Value;
            var buiding = cboBuiding.SelectedValue.ToString();
            var area = cboArea.SelectedValue.ToString();
            var obj = cboObject.SelectedValue.ToString();
            var items = _cardDa.DTBanHangTongHop(startDate, endDate, buiding, area, obj);
            OnFillterRecordBuyProduct(items);

            ModelItem.ObjectCode = cboObject.SelectedValue.ToString();
            ModelItem.BuidingCode = cboBuiding.SelectedValue.ToString();
            ModelItem.AreaCode = cboArea.SelectedValue.ToString();
            ModelItem.StartDate = datStartDate.Value;
            ModelItem.EndDate = datEndDate.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cboArea.SelectedIndex = 0;
            cboBuiding.SelectedIndex = 0;
            cboObject.SelectedIndex = 0;
            this.Hide();
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
                lstObj.Insert(0, new ObjectItem { Desc = "", Code = "" });
                cboObject.DataSource = lstObj;
            }
            else
            {
                var lstObj = _recordDa.GetObjectItems();
                lstObj.Insert(0, new ObjectItem { Name = "", Code = "" });
                cboObject.DataSource = lstObj;
            }
            cboArea.DisplayMember = "Desc";
            cboArea.ValueMember = "Code";
        }
    }
}
