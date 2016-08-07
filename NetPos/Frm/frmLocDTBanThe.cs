using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FDI.DA;
using FDI.Simple;
using iTextSharp.text;

namespace NetPos.Frm
{
    public partial class frmLocDTBanThe : Form
    {
        readonly CardDA _cardDa = new CardDA();
        readonly RecordDA _recordDa = new RecordDA();
        public delegate void CustomHandler(object sender, List<ThongKeItem> lst);
        public event CustomHandler FillterRecordCard;
        public ModelItem ModelItem;
        public UserItem User;
        protected virtual void OnFillterRecordCard(List<ThongKeItem> hs)
        {
            var handler = FillterRecordCard;
            if (handler != null) handler(this, hs);
        }

        public delegate void CustomHandlerDetail(object sender, List<EventItem> lst);
        public event CustomHandlerDetail FillterRecordDetailCard;
        protected virtual void OnFillterRecordDetailCard(List<EventItem> hs)
        {
            var handler = FillterRecordDetailCard;
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
                LoadDefault();
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
            var date = DateTime.Now;
            cboBuiding.SelectedValue = ModelItem.BuidingCode ?? "";
            cboArea.SelectedValue = ModelItem.AreaCode ?? "";
            cboObject.SelectedValue = ModelItem.ObjectCode ?? "";
            datStartDate.Value = ModelItem.StartDate ?? new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
            datEndDate.Value = ModelItem.EndDate??new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var buiding = "";
            if (User.Right1 == 1)
            {
                buiding = cboBuiding.SelectedValue.ToString();
            }

            var startDate = datStartDate.Value;
            var endDate = datEndDate.Value;
            var area = cboArea.SelectedValue.ToString();
            var obj = cboObject.SelectedValue.ToString();

            var items = _cardDa.DTBanTheTongHop(startDate, endDate, buiding, area, obj);
            OnFillterRecordCard(items);

            var list = _recordDa.FindDetailRecordItems(startDate, endDate, buiding, area, obj);
            OnFillterRecordDetailCard(list);

            ModelItem.ObjectCode = cboObject.SelectedValue.ToString();
            ModelItem.BuidingCode = buiding;
            ModelItem.AreaCode = cboArea.SelectedValue.ToString();
            ModelItem.StartDate = datStartDate.Value;
            ModelItem.EndDate = datEndDate.Value;
            ModelItem.BuidingName = cboBuiding.Text;
            ModelItem.AreaName = cboArea.Text;
            ModelItem.ObjectName = cboObject.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cboArea.SelectedIndex = 0;
            cboBuiding.SelectedValue = "";
            cboObject.SelectedIndex = 0;
            Hide();
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
