using System;
using System.Windows.Forms;
using FDI;
using FDI.DA;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace NetPos.FrmCtrl
{
    public partial class frmEventAlarm : UserControl
    {
        readonly EventAlarmDA _da = new EventAlarmDA();
        public frmEventAlarm()
        {
            InitializeComponent();
        }

        private void frmEventAlarm_Load(object sender, EventArgs e)
        {
            var lst = _da.GetAdminAllSimple();
            dgv_DanhSach.DataSource = lst.ToDataTable();
        }

        private void dgv_DanhSach_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            var band = e.Layout.Bands[0];
            band.Columns["ID"].Hidden = true;

            band.Columns["Date"].CellActivation = Activation.NoEdit;
            band.Columns["BuidingCode"].CellActivation = Activation.NoEdit;
            band.Columns["Object"].CellActivation = Activation.NoEdit;
            band.Columns["EventCode"].CellActivation = Activation.NoEdit;

            band.Columns["Date"].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["BuidingCode"].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["Object"].CellAppearance.TextHAlign = HAlign.Left;
            band.Columns["EventCode"].CellAppearance.TextHAlign = HAlign.Center;

            #region Caption
            //band.Columns["Date"].Header.Caption = @"Thời gian";
            //band.Columns["MemoryID"].Header.Caption = @"MemoryID";
            //band.Columns["CardNumber"].Header.Caption = @"Mã thẻ";

            #endregion
            band.Override.HeaderClickAction = HeaderClickAction.SortSingle;
        }
    }
}
