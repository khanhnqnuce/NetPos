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

            // load card type
            var lstCardType = _cardDa.GetTypeCard();
            lstCardType.Insert(0, new CardTypeItem { Name = "-----------------Chọn------------------", Code = "" });
            cboTypeCard.DataSource = lstCardType;
            cboTypeCard.DisplayMember = "Name";
            cboTypeCard.ValueMember = "Code";

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
            var phathanh = ckPhatHanh.Checked;
            var chuaphathanh = ckChuaPhatHanh.Checked;
            var islock = ckKhoa.Checked;

            var RecordItems = _cardDa.FindCardItems(buiding, area, obj, cardType, cardNumber, code, name, phathanh, chuaphathanh, islock);

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
            ckPhatHanh.Checked = false;
            ckChuaPhatHanh.Checked = false;
            ckKhoa.Checked = false;
            this.Hide();
        }
    }
}
