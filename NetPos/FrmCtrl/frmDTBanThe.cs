using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FDI;
using FDI.Simple;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using NetPos.Frm;

namespace NetPos.FrmCtrl
{
    public partial class frmDTBanThe : UserControl
    {
        public frmDTBanThe()
        {
            InitializeComponent();
        }


        private void dgv_DanhSach_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            var band = e.Layout.Bands[0];
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            band.Columns["ID"].Hidden = true;

            band.Columns["Name"].CellActivation = Activation.NoEdit;
            band.Columns["Value"].CellActivation = Activation.NoEdit;

            band.Columns["Name"].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["Value"].CellAppearance.TextHAlign = HAlign.Right;

            band.Columns["Name"].Header.Caption = @"Thông tin";
            band.Columns["Value"].Header.Caption = @"Số lượng";

        }

        private void frmDTBanThe_Load(object sender, EventArgs e)
        {

        }

        public void Loc()
        {
            var form = new frmLocDTBanThe();
            form.FillterRecordCard += FillterRecordCard;
            form.ShowDialog();
        }

        #region Event
        private void FillterRecordCard(object sender, List<DTBanTheItem> lst)
        {
            dgv_DanhSach.DataSource = lst.ToDataTable();
        }
        #endregion

    }
}
