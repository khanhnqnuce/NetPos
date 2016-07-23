using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using FDI.Base;
using FDI.DA;
using FDI.Simple;

namespace NetPos.Frm
{
    public partial class frmLoc : Form
    {
        readonly CardDA _cardDa = new CardDA();
        readonly RecordDA _recordDa = new RecordDA();
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

        public static DateTime GetStartOfDay(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, 0);
        }
        public static DateTime GetEndOfDay(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59, 999);
        }

        private void frmLoc_Load(object sender, EventArgs e)
        {
            //datEndDate.Value = 
            //datStartDate.Value = 
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
            var StartDate = datStartDate.Value;
            var EndDate = datStartDate.Value;
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
    }
}
