using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FDI.DA;
using FDI.Simple;

namespace NetPos.Frm
{
    public partial class frmLocCard : Form
    {
        readonly CardDA _cardDa = new CardDA();
        readonly RecordDA _recordDa = new RecordDA();
        public delegate void CustomHandler(object sender, List<CardItem> lst);
        public event CustomHandler FillterRecord;
        protected virtual void OnFillterRecord(List<CardItem> hs)
        {
            var handler = FillterRecord;
            if (handler != null) handler(this, hs);
        }
        public frmLocCard()
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
            // load buiding
            var lstBuiding = _recordDa.GetBuidingItems();
            lstBuiding.Insert(0, new BuidingItem{ Name = "", Code = "" });
            cboBuiding.DataSource = lstBuiding;
            cboBuiding.DisplayMember = "Name";
            cboBuiding.ValueMember = "Code";

            // load area
            var lstArea = _recordDa.GetAreaItems();
            lstArea.Insert(0, new AreaItem { Desc = "", Code = "" });
            cboArea.DataSource = lstArea; 
            cboArea.DisplayMember = "Desc";
            cboArea.ValueMember = "Code";

            // load Object
            var lstObj = _recordDa.GetObjectItems();
            lstObj.Insert(0, new ObjectItem { Name = "", Code = "" });
            cboObject.DataSource = lstObj;
            cboObject.DisplayMember = "Name";
            cboObject.ValueMember = "Code";

            // load card type
            var lstCardType = _cardDa.GetTypeCard();
            lstCardType.Insert(0, new CardTypeItem { Name = "", Code = "" });
            cboTypeCard.DataSource = lstCardType;
            cboTypeCard.DisplayMember = "Name";
            cboTypeCard.ValueMember = "Code";

            List<AreaItem> lststatus = new List<AreaItem>();
            lststatus.Insert(0, new AreaItem { Desc = "", Code = "" });
            lststatus.Insert(1, new AreaItem { Desc = "Chưa phát hành", Code = "00" });
            lststatus.Insert(2, new AreaItem { Desc = "Đã phát hành", Code = "01" });
            lststatus.Insert(3, new AreaItem { Desc = "Đang bị khóa", Code = "02" });
            cboStatus.DataSource = lststatus;
            cboStatus.DisplayMember = "Desc";
            cboStatus.ValueMember = "Code";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var buiding = cboBuiding.SelectedValue.ToString();
            var area = cboArea.SelectedValue.ToString();
            var obj = cboObject.SelectedValue.ToString();
            var cardType = cboTypeCard.SelectedValue.ToString();
            var cardNumber = txtCardNumber.Text;
            var code = txtMaKH.Text;
            var name = txtTenKH.Text;
            var status = cboStatus.SelectedValue.ToString();

            var RecordItems = _cardDa.FindCardItems(buiding, area, obj, cardType, cardNumber, code, name, status);

            OnFillterRecord(RecordItems);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cboArea.SelectedValue = "";
            cboBuiding.SelectedValue = "";
            cboObject.SelectedValue = "";
            cboTypeCard.SelectedValue = "";
            txtCardNumber.Text = "";
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            cboStatus.SelectedValue = "";
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
