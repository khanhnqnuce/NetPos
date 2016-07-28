using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FDI.DA;
using FDI.Simple;

namespace NetPos.Frm
{
    public partial class frmLocDTBanThe : Form
    {
        readonly CardDA _cardDa = new CardDA();
        readonly RecordDA _recordDa = new RecordDA();
        public delegate void CustomHandler(object sender, List<RecordItem> lst);
        public event CustomHandler FillterRecordCard;
        public ModelItem ModelItem;
        protected virtual void OnFillterRecordCard(List<RecordItem> hs)
        {
            var handler = FillterRecordCard;
            if (handler != null) handler(this, hs);
        }
        public frmLocDTBanThe(ModelItem modelItem)
        {
            ModelItem = modelItem;
            InitializeComponent();
        }

        public static DateTime EndOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }

        public static DateTime StartOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }

        private void frmLoc_Load(object sender, EventArgs e)
        {
            datStartDate.CustomFormat = @"dd/MM/yyyy HH:mm:ss";
            datEndDate.CustomFormat = @"dd/MM/yyyy HH:mm:ss";
            //var date = DateTime.Now;
            
            // load buiding

            // load buiding
            var lstBuiding = _recordDa.GetBuidingItems();
            lstBuiding.Insert(0, new BuidingItem{ Name = "", Code = "-1" });
            cboBuiding.DataSource = lstBuiding;
            cboBuiding.DisplayMember = "Name";
            cboBuiding.ValueMember = "Code";
            
            // load area
            var lstArea = _recordDa.GetAreaItems();
            lstArea.Insert(0, new AreaItem { Desc = "", Code = "-1" });
            cboArea.DataSource = lstArea; 
            cboArea.DisplayMember = "Desc";
            cboArea.ValueMember = "Code";
            

            // load Object
            var lstObj = _recordDa.GetObjectItems();
            lstObj.Insert(0, new ObjectItem { Name = "", Code = "-1" });
            cboObject.DataSource = lstObj;
            cboObject.DisplayMember = "Name";
            cboObject.ValueMember = "Code";
            LoadDefault();
        }

        public void LoadDefault()
        {
            cboObject.SelectedValue = ModelItem.ObjectCode;
            cboArea.SelectedValue = ModelItem.AreaCode;
            cboBuiding.SelectedValue = ModelItem.BuidingCode;
            datStartDate.Value = ModelItem.StartDate;
            datEndDate.Value = ModelItem.EndDate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var startDate = datStartDate.Value;
            var endDate = datEndDate.Value;
            var buiding = cboBuiding.SelectedValue.ToString();
            var area = cboArea.SelectedValue.ToString();
            var obj = cboObject.SelectedValue.ToString();

            var items = _cardDa.ReportRevenueCard(startDate, endDate, buiding, area, obj);

            OnFillterRecordCard(items);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cboArea.SelectedValue = "";
            cboBuiding.SelectedValue = "";
            cboObject.SelectedValue = "";
            this.Hide();
        }

        private void cboBuiding_SelectedIndexChanged(object sender, EventArgs e)
        {
            var buiding = cboBuiding.SelectedValue.ToString();
            ModelItem.BuidingCode = cboBuiding.SelectedValue.ToString();
            if (!String.IsNullOrEmpty(buiding))
            {
                var lstArea = _cardDa.GetArea(buiding);
                lstArea.Insert(0, new AreaItem { Desc = "", Code = "-1" });
                cboArea.DataSource = lstArea;
            }
            else
            {
                var lstArea = _recordDa.GetAreaItems();
                lstArea.Insert(0, new AreaItem { Desc = "", Code = "-1" });
                cboArea.DataSource = lstArea;
            }
            cboArea.DisplayMember = "Desc";
            cboArea.ValueMember = "Code";
        }

        private void cboArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            var area = cboArea.SelectedValue.ToString();
            ModelItem.AreaCode = cboArea.SelectedValue.ToString();
            if (!String.IsNullOrEmpty(area))
            {
                var lstObj = _cardDa.GetObject(area);
                lstObj.Insert(0, new ObjectItem { Desc = "", Code = "-1" });
                cboObject.DataSource = lstObj;
            }
            else
            {
                var lstObj = _recordDa.GetObjectItems();
                lstObj.Insert(0, new ObjectItem { Name = "", Code = "-1" });
                cboObject.DataSource = lstObj;
            }
            cboArea.DisplayMember = "Desc";
            cboArea.ValueMember = "Code";
        }

        private void datStartDate_ValueChanged(object sender, EventArgs e)
        {
            ModelItem.StartDate = datStartDate.Value;
        }

        private void datEndDate_ValueChanged(object sender, EventArgs e)
        {
            ModelItem.EndDate = datStartDate.Value;
        }

        private void cboObject_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModelItem.ObjectCode = cboObject.SelectedValue.ToString();
        }
    }
}
