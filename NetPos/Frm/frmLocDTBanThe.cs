using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using FDI.Base;
using FDI.DA;
using FDI.Simple;
using Microsoft.VisualBasic.ApplicationServices;

namespace NetPos.Frm
{
    public partial class frmLocDTBanThe : Form
    {
        readonly CardDA _cardDa = new CardDA();
        readonly RecordDA _recordDa = new RecordDA();
        public delegate void CustomHandler(object sender, List<DTBanTheItem> lst);
        public event CustomHandler FillterRecordCard;
        protected virtual void OnFillterRecordCard(List<DTBanTheItem> hs)
        {
            var handler = FillterRecordCard;
            if (handler != null) handler(this, hs);
        }
        public frmLocDTBanThe()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

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
    }
}
