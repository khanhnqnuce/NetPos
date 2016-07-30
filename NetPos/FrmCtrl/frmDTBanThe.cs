﻿using System;
using System.Collections.Generic;
using System.Threading;
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
        readonly frmLocDTBanThe _formLoc;
        ModelItem _modelItem = new ModelItem();
        private UserItem _userItem;
        public frmDTBanThe(UserItem userItem)
        {
            _userItem = userItem;
            _formLoc = new frmLocDTBanThe(_modelItem);
            _formLoc.FillterRecordCard += FillterRecordCard;
            InitializeComponent();
        }


        private void dgv_DanhSach_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            

        }

        private void frmDTBanThe_Load(object sender, EventArgs e)
        {
        }

        public void Loc()
        {
            _formLoc.ModelItem = _modelItem;
            //_formLoc.LoadDefault();
            _formLoc.User = _userItem;
            _formLoc.ShowDialog();
            _modelItem = _formLoc.ModelItem;
        }

        #region Event
        private void FillterRecordCard(object sender, List<ThongKeItem> lst)
        {
            dgv_DanhSachChiTiet.DataSource = lst.ToDataTable();
        }
        #endregion

        private void dgv_DanhSachChiTiet_InitializeLayout(object sender, InitializeLayoutEventArgs e)
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
            band.Columns["Value"].FormatMonney();
        }

    }
}