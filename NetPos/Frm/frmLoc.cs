using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FDI.DA;
using FDI.Simple;

namespace NetPos.Frm
{
    public partial class frmLoc : Form
    {
        //readonly CardDA _cardDa = new CardDA();
        //readonly RecordDA _recordDa = new RecordDA();
        public delegate void CustomHandler(object sender, List<RecordItem> lst);
        public event CustomHandler FillterRecord;
        protected virtual void OnFillterRecord(List<RecordItem> hs)
        {
            var handler = FillterRecord;
            if (handler != null) handler(this, hs);
        }
        public frmLoc()
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
            CardDA _cardDa = new CardDA();
            RecordDA _recordDa = new RecordDA();
            datStartDate.CustomFormat = @"dd/MM/yyyy HH:mm:ss";
            datEndDate.CustomFormat = @"dd/MM/yyyy HH:mm:ss";
            var date = DateTime.Now;
            datStartDate.Value = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
            datEndDate.Value = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
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

            // load PC
            var lstPC = _recordDa.GetPCItems();
            lstPC.Insert(0, new PCItem { Name = "-----------------Chọn------------------", Code = "" });
            cboPC.DataSource = lstPC;
            cboPC.DisplayMember = "Name";
            cboPC.ValueMember = "Code";

            // load Object
            var lstObj = _recordDa.GetObjectItems();
            lstObj.Insert(0, new ObjectItem { Name = "-----------------Chọn------------------", Code = "" });
            cboObject.DataSource = lstObj;
            cboObject.DisplayMember = "Name";
            cboObject.ValueMember = "Code";

            // load Function
            var lstFunction = _recordDa.GetFunctionItems();
            lstFunction.Insert(0, new FunctionItem { Desc = "-----------------Chọn------------------", FID = "" });
            cboFunction.DataSource = lstFunction;
            cboFunction.DisplayMember = "Desc";
            cboFunction.ValueMember = "FID";

            // load event code
            var lstevent = _recordDa.GetEventCodeItems();
            lstevent.Insert(0, new EventCodeItem { Name = "-----------------Chọn------------------", Code = "" });
            cboEventCode.DataSource = lstevent;
            cboEventCode.DisplayMember = "Name";
            cboEventCode.ValueMember = "Code";

            // load card type
            var lstCardType = _cardDa.GetTypeCard();
            lstCardType.Insert(0, new CardTypeItem { Name = "-----------------Chọn------------------", Code = "" });
            cboTypeCard.DataSource = lstCardType;
            cboTypeCard.DisplayMember = "Name";
            cboTypeCard.ValueMember = "Code";

            // load card type
            var lstUser = _recordDa.GetUserItems();
            lstUser.Insert(0, new UserItem { FullName = "-----------------Chọn------------------", Code = "" });
            cboUser.DataSource = lstUser;
            cboUser.DisplayMember = "FullName";
            cboUser.ValueMember = "Code";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RecordDA _recordDa = new RecordDA();
            var StartDate = datStartDate.Value;
            var EndDate = datEndDate.Value;
            var Buiding = cboBuiding.SelectedValue.ToString();
            var Area = cboArea.SelectedValue.ToString();
            var PC = cboPC.SelectedValue.ToString();
            var Object = cboObject.SelectedValue.ToString();
            var Function = cboFunction.SelectedValue.ToString();
            var EventCode = cboEventCode.SelectedValue.ToString();
            var TypeCard = cboTypeCard.SelectedValue.ToString();
            var CardNumber = txtCardNumber.Text;
            var User = cboUser.SelectedValue.ToString();

            var RecordItems = _recordDa.FindRecordItems(StartDate, EndDate, Buiding, Area, PC, Object, Function, EventCode, TypeCard, CardNumber, User);

            OnFillterRecord(RecordItems);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var date = DateTime.Now;
            datStartDate.Value = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
            datEndDate.Value = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
            cboBuiding.SelectedValue = "";
            cboArea.SelectedValue = "";
            cboPC.SelectedValue = "";
            cboObject.SelectedValue = "";
            cboFunction.SelectedValue = "";
            cboEventCode.SelectedValue = "";
            txtCardNumber.Text = "";
            cboUser.SelectedValue = "";

            //this.Hide();
        }
    }
}
