using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using DevExpress.XtraSplashScreen;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using MahApps.Metro.Controls;

namespace FinancialSysApp.Forms.Banks
{
    public partial class RefundCheqBankFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        bool Vbl_RefundCequeCheck = false;
        int Vint_BankCheqId = 0;
        long? Vlng_TreasuryCollectionID = 0;
        //int Vint_BankDrawnOnID = 0;
        string VStr_CheqNo = "";
        //int Vint_DepositBank = 0;
        int Vint_ChequeStatusIDNew = 0;
        int Vint_BankCheqStatusID = 0;
        bool Vbl_WithDrawCheck = false;
        public RefundCheqBankFrm()
        {
            InitializeComponent();
        }

        private void RefundCheqBankFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankCheques.Dtb_Banks' table. You can move, or remove it, as needed.
            this.dtb_BanksTableAdapter.FillByBankKind(this.bankCheques.Dtb_Banks);
            // TODO: This line of code loads data into the 'bankCheques.Dtb_BankCheque' table. You can move, or remove it, as needed.
            AddColumnDtaGrd1();
            GrdBnkCheq();
            cmbBnkDeposit.Text = "";
            cmbBnkDeposit.SelectedIndex = -1;
            cmbBnkDeposit.Text = "اختر البنك المودع ";

            cmbBnkDeposit.Select();
            this.ActiveControl = cmbBnkDeposit;
            cmbBnkDeposit.Focus();
        }

        private void cmbBnkDeposit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dTpDayBank.Focus();
            }
        }

        private void radioButton1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var listRefundReseon = FsDb.Tbl_RefundCheqReson.Where(x => x.ProcedureKindID == 1).ToList();
                comboBox1.DataSource = listRefundReseon;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "ID";
                dataGridView1.DataSource = null;
                txtAmount.Text = "";
                txtChequeNo.Text = "";
                comboBox1.Text = "";
                comboBox1.SelectedIndex = -1;
                comboBox1.Text = "اختر سبب الرد ";
                txtAmount.Focus();
            }

        }

        private void radioButton2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var listRefundReseon = FsDb.Tbl_RefundCheqReson.Where(x => x.ProcedureKindID == 2).ToList();
                comboBox1.DataSource = listRefundReseon;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "ID";
                txtAmount.Text = "";
                txtChequeNo.Text = "";
                comboBox1.Text = "";
                comboBox1.SelectedIndex = -1;
                comboBox1.Text = "اختر سبب السحب ";
                txtAmount.Focus();
            }
        }
        private void DgrCheqAndAdded()
        {

            dataGridView1.SuspendLayout();
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {

                Vlng_TreasuryCollectionID = long.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString());

                //************** Declare 
                int Vint_ID = int.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString());
                int Vint_BranchID = int.Parse(dataGridView3.Rows[i].Cells[1].Value.ToString());
                var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                     join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                     join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                     join bnkD in FsDb.Tbl_Banks on TRC.BankDepositeID equals bnkD.ID
                                     join refCh in FsDb.Tbl_RefundCheque on BnkChq.ID equals refCh.BankChequesID
                                     where (BnkChq.ID == Vint_ID)
                                     select new

                                     {
                                         IsRefundCheque = refCh.IsRefundCheque,
                                         ID = BnkChq.ID,
                                         TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                         AmountCheque = BnkChq.AmountCheque,
                                         BankDrawnOnID = BnkChq.BankDrawnOnID,
                                         ChequeNo = BnkChq.ChequeNo,
                                         ChequeDueDate = BnkChq.ChequeDueDate,
                                         DepositDate = TRC.DepositDate,
                                         AddDateBank = BnkChq.AddDateBank,
                                         AddDateAccBank = BnkChq.AddDateAccBank,
                                         BankDueDate = BnkChq.BankDueDate,

                                         TradeCollectionNo = BnkChq.TradeCollectionNo,
                                         DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                         CustID = BnkChq.CustID,


                                         ChequeKind = BnkChq.ChequeKindID,
                                         //CustomerName = Cust.Name,
                                         BankName = BNK.Name,
                                         BankDeposit = bnkD.Name,
                                         ReceiptNo = TRC.ReceiptNo,
                                         IsDisposed = BnkChq.IsDepositNo,
                                         ParentID = TRC.Parent_ID,
                                         ChequeStatusID = BnkChq.ChequeStatusID



                                     }).OrderBy(x => x.ChequeDueDate).ToList();


                for (int j = 0; j < (listBnkCheque.Count); j++)
                {

                    dataGridView1.AllowUserToAddRows = true;
                    dataGridView1.Rows.Add(0, listBnkCheque[j].IsRefundCheque, listBnkCheque[j].ID, listBnkCheque[j].TreasuryCollectionID, listBnkCheque[j].AmountCheque, listBnkCheque[j].BankDrawnOnID,
                    listBnkCheque[j].ChequeNo, listBnkCheque[j].ChequeDueDate, listBnkCheque[j].DepositDate, listBnkCheque[j].AddDateBank, listBnkCheque[j].AddDateAccBank, listBnkCheque[j].BankDueDate, listBnkCheque[j].TradeCollectionNo, listBnkCheque[j].DepositedByTrRepresntvID, listBnkCheque[j].CustID, listBnkCheque[j].ChequeKind, listBnkCheque[j].BankName, listBnkCheque[j].BankDeposit,
                   listBnkCheque[j].ReceiptNo, listBnkCheque[j].IsDisposed, listBnkCheque[j].ParentID, listBnkCheque[j].ChequeStatusID, true
                  );
                    dataGridView1.AllowUserToAddRows = false;
                }
                //LoadSerial();
                //ColorSt();
            }
            dataGridView1.ResumeLayout();
            LoadSerial();
            ColorSt();

        }
        private void LoadSerial()
        {
            int i = 1;


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = i; i++;

            }
        }
        private void AddColumnDtaGrd1()
        {
            // Create a new columns datadridview1
            DataGridViewTextBoxColumn newColumnID = new DataGridViewTextBoxColumn();

            // Set the properties of the new column
            newColumnID.HeaderText = "ID"; // Header text of the column
            newColumnID.Name = "ID"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnID);

            DataGridViewTextBoxColumn newColumnName = new DataGridViewTextBoxColumn();
            newColumnName.Name = "TreasuryCollectionID"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnName);

            DataGridViewTextBoxColumn newColumnAmountCheque = new DataGridViewTextBoxColumn();
            newColumnAmountCheque.Name = "AmountCheque"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnAmountCheque);

            DataGridViewTextBoxColumn newColumnBankDrawnOnID = new DataGridViewTextBoxColumn();
            newColumnBankDrawnOnID.Name = "BankDrawnOnID"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnBankDrawnOnID);

            DataGridViewTextBoxColumn newColumnChequeNo = new DataGridViewTextBoxColumn();
            newColumnChequeNo.Name = "ChequeNo"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnChequeNo);

            DataGridViewTextBoxColumn newColumnChequeDueDate = new DataGridViewTextBoxColumn();
            newColumnChequeDueDate.Name = "ChequeDueDate"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnChequeDueDate);

            DataGridViewTextBoxColumn newColumnDepositDate = new DataGridViewTextBoxColumn();
            newColumnDepositDate.Name = "DepositDate"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnDepositDate);

            DataGridViewTextBoxColumn newColumnAddDateBank = new DataGridViewTextBoxColumn();
            newColumnAddDateBank.Name = "AddDateBank"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnAddDateBank);

            DataGridViewTextBoxColumn newColumnAddDateAccBank = new DataGridViewTextBoxColumn();
            newColumnAddDateAccBank.Name = "AddDateAccBank"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnAddDateAccBank);

            DataGridViewTextBoxColumn newColumnBankDueDate = new DataGridViewTextBoxColumn();
            newColumnBankDueDate.Name = "BankDueDate"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnBankDueDate);
            //*****************
            DataGridViewTextBoxColumn newColumnTradeCollectionNo = new DataGridViewTextBoxColumn();
            newColumnTradeCollectionNo.Name = "TradeCollectionNo"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnTradeCollectionNo);

            DataGridViewTextBoxColumn newColumnDepositedByTrRepresntvID = new DataGridViewTextBoxColumn();
            newColumnDepositedByTrRepresntvID.Name = "DepositedByTrRepresntvID"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnDepositedByTrRepresntvID);

            DataGridViewTextBoxColumn newColumnCustID = new DataGridViewTextBoxColumn();
            newColumnCustID.Name = "CustID"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnCustID);



            DataGridViewTextBoxColumn newColumnChequeKind = new DataGridViewTextBoxColumn();
            newColumnChequeKind.Name = "ChequeKind"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnChequeKind);

            DataGridViewTextBoxColumn newColumnBankName = new DataGridViewTextBoxColumn();
            newColumnBankName.Name = "BankName"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnBankName);

            DataGridViewTextBoxColumn newColumBankDeposit = new DataGridViewTextBoxColumn();
            newColumBankDeposit.Name = "BankDeposit"; // Unique name of the column
            newColumBankDeposit.Visible = true;
            dataGridView1.Columns.Add(newColumBankDeposit);


            DataGridViewTextBoxColumn newColumnReceiptNo = new DataGridViewTextBoxColumn();
            newColumnReceiptNo.Name = "ReceiptNo"; // Unique name of the column
            newColumnReceiptNo.Visible = false;
            dataGridView1.Columns.Add(newColumnReceiptNo);


            DataGridViewCheckBoxColumn newColumnChqUpdate = new DataGridViewCheckBoxColumn();
            newColumnChqUpdate.Name = "ChqBxUpd"; // Unique name of the column
            newColumnChqUpdate.Visible = false;
            dataGridView1.Columns.Add(newColumnChqUpdate);

            DataGridViewTextBoxColumn newColumnParentId = new DataGridViewTextBoxColumn();
            newColumnParentId.Name = "ParentID"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnParentId);

            DataGridViewTextBoxColumn newColumnChequeStatusID = new DataGridViewTextBoxColumn();
            newColumnChequeStatusID.Name = "ChequeStatusID"; // Unique name of the column
            newColumnChequeStatusID.Visible = false;
            dataGridView1.Columns.Add(newColumnChequeStatusID);


            DataGridViewCheckBoxColumn newColumnCheqTrue = new DataGridViewCheckBoxColumn();
            newColumnCheqTrue.Name = "CheqTrue"; // Unique name of the column
            //newColumnCheqTrue.Visible = false;
            dataGridView1.Columns.Add(newColumnCheqTrue);






        }
        private void GrdBnkCheq()
        {


            dataGridView1.Columns["TreasuryCollectionID"].Visible = false;
            dataGridView1.Columns["AmountCheque"].Visible = true;
            dataGridView1.Columns["AmountCheque"].ReadOnly = true;
            dataGridView1.Columns["ID"].Visible = false;


            dataGridView1.Columns["BankDrawnOnID"].Visible = false;
            dataGridView1.Columns["ChequeNo"].Visible = true;
            dataGridView1.Columns["ChequeNo"].ReadOnly = true;

            dataGridView1.Columns["ChequeDueDate"].Visible = true;
            dataGridView1.Columns["ChequeDueDate"].ReadOnly = true;
            dataGridView1.Columns["DepositedByTrRepresntvID"].Visible = false;

            dataGridView1.Columns["CustID"].Visible = false;
            dataGridView1.Columns["AddDateBank"].Visible = true;
            dataGridView1.Columns["AddDateBank"].ReadOnly = true;
            dataGridView1.Columns["ChequeKind"].Visible = false;
            dataGridView1.Columns["CheqTrue"].Visible = false;


            dataGridView1.Columns["ReceiptNo"].Visible = false;
            dataGridView1.Columns["BankName"].Visible = true;
            dataGridView1.Columns["BankName"].ReadOnly = true;
            dataGridView1.Columns["BankName"].Width = 200;
            //dataGridView1.Columns["Tbl_ChequeKind"].Visible = true;
            //dataGridView1.Columns["Tbl_TreasuryCollection"].Visible = true;
            dataGridView1.Columns["ChequeNo"].Width = 150;

            dataGridView1.Columns["AmountCheque"].HeaderText = "مبلغ الشيك";
            dataGridView1.Columns["AmountCheque"].Width = 120;

            dataGridView1.Columns["AddDateBank"].HeaderText = "تاريخ الاضافه";
            dataGridView1.Columns["AddDateBank"].DefaultCellStyle.Format = "yyyy/MM/dd";
            dataGridView1.Columns["ChequeDueDate"].HeaderText = "تاريخ استخقاق الشيك";
            dataGridView1.Columns["ChequeDueDate"].DefaultCellStyle.Format = "yyyy/MM/dd";

            dataGridView1.Columns["DepositDate"].HeaderText = "تاريخ الايداع";
            dataGridView1.Columns["DepositDate"].DefaultCellStyle.Format = "yyyy/MM/dd";

            dataGridView1.Columns["ChequeNo"].HeaderText = "رقم الشيك";


            dataGridView1.Columns["ParentID"].Visible = false;
            dataGridView1.Columns["ParentID"].HeaderText = "الحافظه الام";

            dataGridView1.Columns["BankName"].HeaderText = "البنك المسحوب عليه";
            dataGridView1.Columns["BankDeposit"].HeaderText = "البنك المودع";
            dataGridView1.Columns["BankDeposit"].ReadOnly = true;
            dataGridView1.Columns["BankDeposit"].Width = 200;
            dataGridView1.Columns["TradeCollectionNo"].HeaderText = "رقم الصفحه";
            dataGridView1.Columns["TradeCollectionNo"].ReadOnly = true;
            dataGridView1.Columns["TradeCollectionNo"].Visible = true;
            dataGridView1.Columns["AddDateAccBank"].HeaderText = "تاريخ يومية البنك";
            dataGridView1.Columns["AddDateAccBank"].ReadOnly = true;
            dataGridView1.Columns["AddDateAccBank"].DefaultCellStyle.Format = "yyyy/MM/dd";

            dataGridView1.Columns["BankDueDate"].HeaderText = "تاريخ حق البنك";
            dataGridView1.Columns["BankDueDate"].ReadOnly = true;
            dataGridView1.Columns["BankDueDate"].DefaultCellStyle.Format = "yyyy/MM/dd";





        }
        private void ColorSt()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //Vlng_TreasuryCollectionID = int.Parse(row.Cells["TreasuryCollectionID"].Value.ToString());

                //var listofBnk = (from TR in FsDb.Tbl_TreasuryCollection
                //                 join bnk in FsDb.Tbl_Banks on TR.BankDepositeID equals bnk.ID
                //                 where (TR.ID == Vlng_TreasuryCollectionID)
                //                 select new
                //                 {
                //                     BankDepositName = bnk.Name,
                //                 }).ToList();
                //if (listofBnk.Count != 0)

                //{
                //    row.Cells["BankDeposit"].Value = listofBnk[0].BankDepositName;
                //    row.Cells["CheqTrue"].Value = true;
                //}

            }
        }
        private void GrdTotalValue()
        {
            //try
            //{

            int Vint_DgCount = dataGridView1.RowCount;
            //if (Vint_DgCount != 0)
            //{
            //    txtAllValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
            //                                         select Convert.ToDouble(row.Cells[5].Value)).Sum(), 3).ToString();
            //    txtCheqAllCount.Text = (from DataGridViewRow row in dataGridView1.Rows
            //                            select Convert.ToDouble(row.Cells[5].Value)).Count().ToString();

            //    txtSpValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
            //                                        where (Convert.ToBoolean(row.Cells[1].Value) == true)
            //                                        select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
            //    txtCheqSpCount.Text = ((from DataGridViewRow row in dataGridView1.Rows
            //                            where (Convert.ToBoolean(row.Cells[1].Value) == true)
            //                            select Convert.ToDouble(row.Cells[4].Value)).Count().ToString());

            //}
            //}
            //catch
            //{ }
        }
        private void DgrCheqDepositAndAdded()
        {

            dataGridView1.SuspendLayout();
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {

                Vlng_TreasuryCollectionID = long.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());

                //************** Declare 
                int Vint_ID = int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                int Vint_BranchID = int.Parse(dataGridView2.Rows[i].Cells[1].Value.ToString());
                var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                     join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                     join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                     join bnkD in FsDb.Tbl_Banks on TRC.BankDepositeID equals bnkD.ID
                                     join refCh in FsDb.Tbl_RefundCheque on BnkChq.ID equals refCh.BankChequesID
                                     where (BnkChq.ID == Vint_ID)
                                     select new

                                     {
                                         IsRefundCheque = refCh.IsRefundCheque,
                                         ID = BnkChq.ID,
                                         TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                         AmountCheque = BnkChq.AmountCheque,
                                         BankDrawnOnID = BnkChq.BankDrawnOnID,
                                         ChequeNo = BnkChq.ChequeNo,
                                         ChequeDueDate = BnkChq.ChequeDueDate,
                                         DepositDate = TRC.DepositDate,
                                         AddDateBank = BnkChq.AddDateBank,
                                         AddDateAccBank = BnkChq.AddDateAccBank,
                                         BankDueDate = BnkChq.BankDueDate,

                                         TradeCollectionNo = BnkChq.TradeCollectionNo,
                                         DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                         CustID = BnkChq.CustID,


                                         ChequeKind = BnkChq.ChequeKindID,
                                         //CustomerName = Cust.Name,
                                         BankName = BNK.Name,
                                         BankDeposit = bnkD.Name,
                                         ReceiptNo = TRC.ReceiptNo,
                                         IsDisposed = BnkChq.IsDepositNo,
                                         ParentID = TRC.Parent_ID,
                                         ChequeStatusID = BnkChq.ChequeStatusID


                                     }).OrderBy(x => x.ChequeDueDate).ToList();
                if (listBnkCheque.Count > 0)
                {

                    for (int j = 0; j < (listBnkCheque.Count); j++)
                    {

                        dataGridView1.AllowUserToAddRows = true;
                        dataGridView1.Rows.Add(0, listBnkCheque[j].IsRefundCheque, listBnkCheque[j].ID, listBnkCheque[j].TreasuryCollectionID, listBnkCheque[j].AmountCheque, listBnkCheque[j].BankDrawnOnID,
                        listBnkCheque[j].ChequeNo, listBnkCheque[j].ChequeDueDate, listBnkCheque[j].DepositDate, listBnkCheque[j].AddDateBank, listBnkCheque[j].AddDateAccBank, listBnkCheque[j].BankDueDate,
                       listBnkCheque[j].TradeCollectionNo, listBnkCheque[j].DepositedByTrRepresntvID, listBnkCheque[j].CustID, listBnkCheque[j].ChequeKind, listBnkCheque[j].BankName, listBnkCheque[j].BankDeposit,
                       listBnkCheque[j].ReceiptNo, listBnkCheque[j].IsDisposed, listBnkCheque[j].ParentID, listBnkCheque[j].ChequeStatusID, true);
                        dataGridView1.AllowUserToAddRows = false;
                    }
                }
                else
                {


                    var listBnkCheque1 = (from BnkChq in FsDb.Tbl_BankCheques
                                          join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                          join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                          join bnkD in FsDb.Tbl_Banks on TRC.BankDepositeID equals bnkD.ID

                                          where (BnkChq.ID == Vint_ID)
                                          select new

                                          {
                                              IsRefundCheque = false,
                                              ID = BnkChq.ID,
                                              TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                              AmountCheque = BnkChq.AmountCheque,
                                              BankDrawnOnID = BnkChq.BankDrawnOnID,
                                              ChequeNo = BnkChq.ChequeNo,
                                              ChequeDueDate = BnkChq.ChequeDueDate,
                                              DepositDate = TRC.DepositDate,
                                              AddDateBank = BnkChq.AddDateBank,
                                              AddDateAccBank = BnkChq.AddDateAccBank,
                                              BankDueDate = BnkChq.BankDueDate,

                                              TradeCollectionNo = BnkChq.TradeCollectionNo,
                                              DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                              CustID = BnkChq.CustID,


                                              ChequeKind = BnkChq.ChequeKindID,
                                              //CustomerName = Cust.Name,
                                              BankName = BNK.Name,
                                              BankDeposit = bnkD.Name,
                                              ReceiptNo = TRC.ReceiptNo,
                                              IsDisposed = BnkChq.IsDepositNo,
                                              ParentID = TRC.Parent_ID,
                                              ChequeStatusID = BnkChq.ChequeStatusID


                                          }).OrderBy(x => x.ChequeDueDate).ToList();
                    for (int j = 0; j < (listBnkCheque1.Count); j++)
                    {
                        dataGridView1.AllowUserToAddRows = true;
                        dataGridView1.Rows.Add(0, listBnkCheque1[j].IsRefundCheque, listBnkCheque1[j].ID, listBnkCheque1[j].TreasuryCollectionID, listBnkCheque1[j].AmountCheque, listBnkCheque1[j].BankDrawnOnID,
                        listBnkCheque1[j].ChequeNo, listBnkCheque1[j].ChequeDueDate, listBnkCheque1[j].DepositDate, listBnkCheque1[j].AddDateBank, listBnkCheque1[j].AddDateAccBank, listBnkCheque1[j].BankDueDate,
                       listBnkCheque1[j].TradeCollectionNo, listBnkCheque1[j].DepositedByTrRepresntvID, listBnkCheque1[j].CustID, listBnkCheque1[j].ChequeKind, listBnkCheque1[j].BankName, listBnkCheque1[j].BankDeposit,
                       listBnkCheque1[j].ReceiptNo, listBnkCheque1[j].IsDisposed, listBnkCheque1[j].ParentID, listBnkCheque1[j].ChequeStatusID, true);
                        dataGridView1.AllowUserToAddRows = false;
                    }
                }
            }
            dataGridView1.ResumeLayout();
            //LoadSerial();
            ColorSt();

        }
        private void DgrChequesTrueDepositAmountCh(int Vint_Bank, Decimal Vd_AmountCh)
        {

            if (radioButton1.Checked == true)
            {
                Vint_ChequeStatusIDNew = 4;
            }
            else if (radioButton2.Checked == true)
            {
                Vint_ChequeStatusIDNew = 5;
            }
            else if (radioButton3.Checked == true)
            {
                Vint_ChequeStatusIDNew = 2;
            }
            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID

                                 where (TRC.BankDepositeID == Vint_Bank && BnkChq.AmountCheque == Vd_AmountCh)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositDate = TRC.DepositDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     ChequeStatusID = BnkChq.ChequeStatusID

                                 }).OrderBy(x => x.AddDateBank).ToList();

            dataGridView2.DataSource = listBnkCheque;
        }
        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbBnkDeposit.SelectedValue != null)
                {
                    if (txtAmount.Text != "" && txtAmount.Text != " ")
                    {
                        if (dataGridView1.Rows.Count != 0)
                        {
                            dataGridView1.Rows.Clear();
                            dataGridView3.DataSource = null;
                            txtChequeNo.Text = "";
                        }
                        //DgrCheqAddedAmountCh(Convert.ToDateTime(dTPAddBank.Value.ToString("yyyy/MM/dd")), int.Parse(cmbBnkDeposit.SelectedValue.ToString()),decimal.Parse( txtAmount.Text) );
                        DgrChequesTrueDepositAmountCh(int.Parse(cmbBnkDeposit.SelectedValue.ToString()), decimal.Parse(txtAmount.Text));


                        if (dataGridView2.Rows.Count != 0)
                        {

                            DgrCheqAndAdded();
                            DgrCheqDepositAndAdded();

                            //************ضبط طريقة عرض بيانات الشيكات  Datagridview1
                            GrdBnkCheq();
                            GrdTotalValue();
                            dataGridView1.Columns["Ser"].Visible = false;
                            dataGridView1.Columns["AddCancel"].Visible = true;


                            dataGridView1.Select();
                            this.ActiveControl = dataGridView1;
                            dataGridView1.Focus();

                        }
                        dataGridView1.Select();
                        this.ActiveControl = dataGridView1;
                        dataGridView1.Focus();
                    }
                    else
                    {
                        txtChequeNo.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("اختر البنك المودع ");
                    cmbBnkDeposit.Focus();
                }


            }
        }

        private void txtChequeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbBnkDeposit.SelectedValue != null)
                {
                    if (txtChequeNo.Text != "")
                    {
                        if (cBSearchG.Checked == true)
                        {
                            Vint_ChequeStatusIDNew = 5;
                        }
                        else if (cBSearchG.Checked == false)
                        {
                            Vint_ChequeStatusIDNew = 2;
                        }
                        int Vint_bankDeposit = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                        //DateTime Vd_AddedDate = Convert.ToDateTime(dTPAddBank.Value.ToString());
                        VStr_CheqNo = txtChequeNo.Text;
                        var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                             join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                             join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID

                                             where ((BnkChq.ChequeStatusID <= Vint_ChequeStatusIDNew) && TRC.BankDepositeID == Vint_bankDeposit && BnkChq.ChequeNo == VStr_CheqNo)
                                             select new

                                             {

                                                 ID = BnkChq.ID,
                                                 TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                                 AddDateBank = BnkChq.AddDateBank,
                                                 AmountCheque = BnkChq.AmountCheque,
                                                 BankDrawnOnID = BnkChq.BankDrawnOnID,
                                                 ChequeNo = BnkChq.ChequeNo,
                                                 ChequeDueDate = BnkChq.ChequeDueDate,
                                                 DepositDate = TRC.DepositDate,
                                                 DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                                 CustID = BnkChq.CustID,
                                                 ChequeKind = BnkChq.ChequeKindID,
                                                 BankName = BNK.Name,
                                                 ParentID = TRC.Parent_ID,
                                                 ChequeStatusID = BnkChq.ChequeStatusID

                                             }).OrderBy(x => x.AddDateBank).ToList();

                        dataGridView2.DataSource = listBnkCheque;
                        if (dataGridView1.Rows.Count != 0)
                        {
                            dataGridView1.Rows.Clear();
                            if (dataGridView3.Rows.Count != 0)
                            {
                                //dataGridView3.Rows.Clear();
                                dataGridView3.DataSource = null;
                            }
                        }
                        if (dataGridView2.Rows.Count != 0)
                        {

                            DgrCheqDepositAndAdded();
                            //************ضبط طريقة عرض بيانات الشيكات  Datagridview1
                            GrdBnkCheq();
                            GrdTotalValue();
                            dataGridView1.Columns["Ser"].Visible = false;
                            txtAmount.Text = "";

                        }
                    }

                }
                else
                {
                    MessageBox.Show("اختر البنك المودع ");
                    cmbBnkDeposit.Focus();
                }
                dataGridView1.Focus();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.dataGridView1.CurrentRow.Cells["ID"].Value != null)
                { txtCheqId.Text = this.dataGridView1.CurrentRow.Cells["ID"].Value.ToString(); }
                comboBox1.Focus();
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton7.Focus();
            }
        }

        private void radioButton1_Leave(object sender, EventArgs e)
        {
            var listRefundReseon = FsDb.Tbl_RefundCheqReson.Where(x => x.ProcedureKindID == 1).ToList();
            comboBox1.DataSource = listRefundReseon;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";

            comboBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "اختر سبب الرد ";
            txtAmount.Focus();
        }

        private void radioButton2_Leave(object sender, EventArgs e)
        {
            var listRefundReseon = FsDb.Tbl_RefundCheqReson.Where(x => x.ProcedureKindID == 2).ToList();
            comboBox1.DataSource = listRefundReseon;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            comboBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "اختر سبب السحب ";
            txtAmount.Focus();
        }

        private void dTpDayBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                radioButton1.Focus();
            }

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {

            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 89 && w.ProcdureId == 1);
            if (validationSaveUser != null)
            {

                if (txtCheqId.Text != "")
                {
                    Vint_BankCheqId = int.Parse(txtCheqId.Text);
                }
                else
                {

                }

                var ListRefundCheq = FsDb.Tbl_RefundCheque.FirstOrDefault(x => x.BankChequesID == Vint_BankCheqId);
                var listCheq = FsDb.Tbl_BankCheques.FirstOrDefault(x => x.ID == Vint_BankCheqId);
                //var resultMsg = MessageBox.Show("هل تريد رد هذا الشيك   " + " ؟ ", "رد شيك ", MessageBoxButtons.YesNo);
                //if (resultMsg == DialogResult.Yes)
                //{
                if (radioButton1.Checked == true)
                {
                    Vbl_RefundCequeCheck = true;
                    Vint_BankCheqStatusID = 4;
                    Vbl_WithDrawCheck = false;

                }
                else if (radioButton2.Checked == true)
                {
                    Vbl_RefundCequeCheck = false;
                    Vint_BankCheqStatusID = 5;
                    Vbl_WithDrawCheck = true;

                }
                else if (radioButton3.Checked == true)
                {
                    Vbl_RefundCequeCheck = false;
                    Vint_BankCheqStatusID = 2;
                    Vbl_WithDrawCheck = false;

                }
                if (ListRefundCheq == null)

                {

                    Tbl_RefundCheque Rch = new Tbl_RefundCheque
                    {
                        BankChequesID = Vint_BankCheqId,
                        RefundCheqResonID = int.Parse(comboBox1.SelectedValue.ToString()),
                        IsRefundCheque = Vbl_RefundCequeCheck,
                        RefundDate = Convert.ToDateTime(dTpDayBank.Value.ToString()),
                        IsWithDrawCheq = Vbl_WithDrawCheck,
                    };
                    FsDb.Tbl_RefundCheque.Add(Rch);
                    //FsDb.SaveChanges();
                    Tbl_ChequeBankStatusDates cst = new Tbl_ChequeBankStatusDates
                    {
                        ChequeBankStatusDate = Convert.ToDateTime(dTpDayBank.Value.ToString()),
                        BankChequeID = Vint_BankCheqId,
                        BankChequeStatusID = Vint_BankCheqStatusID
                    };
                    FsDb.Tbl_ChequeBankStatusDates.Add(cst);
                    //FsDb.SaveChanges();
                    var ListBankCheqs = FsDb.Tbl_BankCheques.Where(x => x.ID == Vint_BankCheqId).ToList();
                    ListBankCheqs[0].ChequeStatusID = Vint_BankCheqStatusID;
                    ListBankCheqs[0].ChequeStatusDate = Convert.ToDateTime(dTpDayBank.Value.ToString());

                    FsDb.SaveChanges();

                    int Vint_LastRow = Rch.ID;
                    SecurityEvent sev = new SecurityEvent
                    {
                        ActionName = "اضافة رد شيك",
                        TableName = "Tbl_RefundCheque",
                        TableRecordId = Vint_LastRow.ToString(),
                        Description = "",
                        ManagementName = Program.GlbV_Management,
                        ActionDate = Convert.ToDateTime(Classes.GetServerDate.Cs_GetServerDate()),
                        //ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                        EmployeeName = Program.GlbV_EmpName,
                        User_ID = Program.GlbV_UserId,
                        UserName = Program.GlbV_UserName,
                        FormName = "شاشة رد الشيكات"


                    };
                    FsEvDb.SecurityEvents.Add(sev);
                    FsEvDb.SaveChanges();
                    //***************************
                    MessageBox.Show("تم الحفظ");
                    txtAmount.Text = "";
                    txtChequeNo.Text = "";
                    comboBox1.Text = "";
                    comboBox1.SelectedIndex = -1;
                    comboBox1.Text = "اختر سبب الرد ";
                    radioButton1.Checked = true;
                    radioButton1.Enabled = true;
                    dataGridView1.Rows.Clear();
                    dTpDayBank.Focus();
                    //this.dtb_ChqStatusDatesTableAdapter.FillByCheqID(this.bankCheques.Dtb_ChqStatusDates, Vint_BankCheqId);
                    //****************Refrences***************
                }
                else
                {

                    listCheq.ChequeStatusID = Vint_BankCheqStatusID;
                    listCheq.ChequeStatusDate = Convert.ToDateTime(dTpDayBank.Value.ToString());

                    ListRefundCheq.IsRefundCheque = Vbl_RefundCequeCheck;
                    if (comboBox1.SelectedValue != null)
                    { ListRefundCheq.RefundCheqResonID = int.Parse(comboBox1.SelectedValue.ToString()); }
                    else
                    { ListRefundCheq.RefundCheqResonID = null; }
                    ListRefundCheq.IsWithDrawCheq = Vbl_WithDrawCheck;
                    ListRefundCheq.RefundDate = Convert.ToDateTime(dTpDayBank.Value.ToString());
                    FsDb.SaveChanges();

                    //***************************

                    SecurityEvent sev = new SecurityEvent
                    {
                        ActionName = "تعديل رد شيك",
                        TableName = "Tbl_RefundCheque",
                        TableRecordId = Vint_BankCheqId.ToString(),
                        Description = "",
                        ManagementName = Program.GlbV_Management,
                        ActionDate = Convert.ToDateTime(Classes.GetServerDate.Cs_GetServerDate()),
                        //ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                        EmployeeName = Program.GlbV_EmpName,
                        User_ID = Program.GlbV_UserId,
                        UserName = Program.GlbV_UserName,
                        FormName = "شاشة رد الشيكات"


                    };
                    FsEvDb.SecurityEvents.Add(sev);
                    FsEvDb.SaveChanges();
                    MessageBox.Show("تم التعديل");
                    txtAmount.Text = "";
                    txtChequeNo.Text = "";
                    comboBox1.Text = "";
                    comboBox1.SelectedIndex = -1;
                    comboBox1.Text = "اختر سبب الرد ";
                    radioButton1.Enabled = true;
                    dataGridView1.Rows.Clear();
                    dTpDayBank.Focus();
                    //this.dtb_ChqStatusDatesTableAdapter.FillByCheqID(this.bankCheques.Dtb_ChqStatusDates, Vint_BankCheqId);
                }
                //}
                //else
                //{
                //    //checkBox1.Checked = false;
                //}
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية رد شيك .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
                this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            radioButton3.Enabled = true;
            txtCheqId.Text = this.dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            int Vint_iDCheck = int.Parse(txtCheqId.Text);
            var ListRefundCheq = (from BnkChq in FsDb.Tbl_BankCheques
                                  join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                  join Rch in FsDb.Tbl_RefundCheque on BnkChq.ID equals Rch.BankChequesID
                                  join chs in FsDb.Tbl_ChequeBankStatusDates on BnkChq.ID equals chs.BankChequeID

                                  where (BnkChq.ID == Vint_iDCheck && (chs.BankChequeStatusID == 4 || chs.BankChequeStatusID == 5))
                                  select new

                                  {
                                      ChequeDueDate = BnkChq.ChequeDueDate,
                                      DepositBank = TRC.BankDepositeID,
                                      ResRefund = Rch.RefundCheqResonID,
                                      DateStatus = chs.ChequeBankStatusDate,
                                      StRef = chs.BankChequeStatusID,
                                      DteRefund = Rch.RefundDate,
                                  }).OrderBy(x => x.StRef).ToList();

            dTpDayBank.Value = Convert.ToDateTime(ListRefundCheq[0].DateStatus.ToString());
            comboBox1.SelectedValue = int.Parse(ListRefundCheq[0].ResRefund.ToString());
            dTpDayBank.Value = Convert.ToDateTime(ListRefundCheq[0].DteRefund.ToString());
            if (int.Parse(ListRefundCheq[0].StRef.ToString()) == 4)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else if (int.Parse(ListRefundCheq[0].StRef.ToString()) == 5)
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
            }





        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            txtCheqId.Text = this.dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
        }

        private void txtChequeNo_Leave(object sender, EventArgs e)
        {
            if (cmbBnkDeposit.SelectedValue != null)
            {
                if (txtChequeNo.Text != "")
                {
                    if (cBSearchG.Checked == true)
                    {
                        Vint_ChequeStatusIDNew = 5;
                    }
                    else if (cBSearchG.Checked == false)
                    {
                        Vint_ChequeStatusIDNew = 2;
                    }
                    int Vint_bankDeposit = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                    //DateTime Vd_AddedDate = Convert.ToDateTime(dTPAddBank.Value.ToString());
                    VStr_CheqNo = txtChequeNo.Text;
                    var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                         join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                         join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID

                                         where ((BnkChq.ChequeStatusID <= Vint_ChequeStatusIDNew) && TRC.BankDepositeID == Vint_bankDeposit && BnkChq.ChequeNo == VStr_CheqNo)
                                         select new

                                         {

                                             ID = BnkChq.ID,
                                             TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                             AddDateBank = BnkChq.AddDateBank,
                                             AmountCheque = BnkChq.AmountCheque,
                                             BankDrawnOnID = BnkChq.BankDrawnOnID,
                                             ChequeNo = BnkChq.ChequeNo,
                                             ChequeDueDate = BnkChq.ChequeDueDate,
                                             DepositDate = TRC.DepositDate,
                                             DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                             CustID = BnkChq.CustID,
                                             ChequeKind = BnkChq.ChequeKindID,
                                             BankName = BNK.Name,
                                             ParentID = TRC.Parent_ID,
                                             ChequeStatusID = BnkChq.ChequeStatusID

                                         }).OrderBy(x => x.AddDateBank).ToList();

                    dataGridView2.DataSource = listBnkCheque;
                    if (dataGridView1.Rows.Count != 0)
                    {
                        dataGridView1.Rows.Clear();
                        if (dataGridView3.Rows.Count != 0)
                        {
                            //dataGridView3.Rows.Clear();
                            dataGridView3.DataSource = null;
                        }
                    }
                    if (dataGridView2.Rows.Count != 0)
                    {

                        DgrCheqDepositAndAdded();
                        //************ضبط طريقة عرض بيانات الشيكات  Datagridview1
                        GrdBnkCheq();
                        GrdTotalValue();
                        dataGridView1.Columns["Ser"].Visible = false;
                        txtAmount.Text = "";

                    }
                }

            }
            else
            {
                MessageBox.Show("اختر البنك المودع ");
                cmbBnkDeposit.Focus();
            }
            dataGridView1.Focus();
        }

    }
}
