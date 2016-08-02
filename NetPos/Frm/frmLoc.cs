using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FDI.DA;
using FDI.Simple;

namespace NetPos.Frm
{
    public partial class frmLoc : Form
    {
        public delegate void CustomHandler(object sender, List<EventItem> lst);
        public event CustomHandler FillterRecord;
        protected virtual void OnFillterRecord(List<EventItem> hs)
        {
            var handler = FillterRecord;
            if (handler != null) handler(this, hs);
        }

        readonly CardDA _cardDa = new CardDA();
        readonly RecordDA _recordDa = new RecordDA();

        public frmLoc()
        {
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
            var recordDa = new RecordDA();
            datStartDate.CustomFormat = @"dd/MM/yyyy HH:mm:ss";
            datEndDate.CustomFormat = @"dd/MM/yyyy HH:mm:ss";
            var date = DateTime.Now;
            datStartDate.Value = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
            datEndDate.Value = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
            // load buiding
            var lstBuiding = recordDa.GetBuidingItems();
            lstBuiding.Insert(0, new BuidingItem { Name = "", Code = "" });
            cboBuiding.DataSource = lstBuiding;
            cboBuiding.DisplayMember = "Name";
            cboBuiding.ValueMember = "Code";

            // load area
            var lstArea = recordDa.GetAreaItems();
            lstArea.Insert(0, new AreaItem { Desc = "", Code = "" });
            cboArea.DataSource = lstArea;
            cboArea.DisplayMember = "Desc";
            cboArea.ValueMember = "Code";

            // load Object
            var lstObj = recordDa.GetObjectItems();
            lstObj.Insert(0, new ObjectItem { Name = "", Code = "" });
            cboObject.DataSource = lstObj;
            cboObject.DisplayMember = "Name";
            cboObject.ValueMember = "Code";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var startDate = datStartDate.Value;
            var endDate = datEndDate.Value;
            var buiding = cboBuiding.SelectedValue.ToString();
            var area = cboArea.SelectedValue.ToString();
            var Object = cboObject.SelectedValue.ToString();


            var recordItems = _recordDa.FindRecordItems(startDate, endDate, buiding, area, Object);

            OnFillterRecord(recordItems);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var date = DateTime.Now;
            datStartDate.Value = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
            datEndDate.Value = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
            cboBuiding.SelectedValue = "";
            cboArea.SelectedValue = "";
            cboObject.SelectedValue = "";
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
