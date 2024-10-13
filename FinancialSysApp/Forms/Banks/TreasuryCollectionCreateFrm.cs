using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.DataProcessing;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using DevExpress.XtraEditors;
using DevComponents.DotNetBar.Controls;
using FinancialSysApp.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using FinancialSysApp.Forms.DocumentsForms;
using System;
using DevExpress.Charts.Native;
using DevExpress.Utils;
using System.Web.Services.Description;
using DevExpress.XtraLayout.Helpers;
using Infragistics.Win.UltraWinGrid;
using DevExpress.XtraEditors.Filtering.Templates;
using DevExpress.Utils.Extensions;
using DevExpress.CodeParser;

namespace FinancialSysApp.Forms.Banks
{
    public partial class TreasuryCollectionCreateFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();

        int? Vint_ChequeReceivedKindID = null;

        long? Vlng_LastRowTreasuryCollection = 0;
        DateTime? Vdt_DepositDate = null;

        long Vlng_TreasuryCollectionID = 0;

       
        public TreasuryCollectionCreateFrm()
        {
            InitializeComponent();
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
        }

        private void TreasuryCollectionCreateFrm_Load(object sender, EventArgs e)
        {
            this.dtb_BanksTableAdapter.FillByBankKind(this.bankCheques1.Dtb_Banks);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Fiscalyear' table. You can move, or remove it, as needed.
            this.tbl_FiscalyearTableAdapter1.FillByYear(this.financialSysDataSet.Tbl_Fiscalyear);

            Vint_ChequeReceivedKindID = 1;

            ClearData();
            txtRepresentive.SelectionLength = 0;

            cmbBnkDeposit.SelectedIndex = -1;
            cmbBnkDeposit.Text = "";
            cmbBnkDeposit.SelectedText = "اختر البنك المودع ";

            checkData();
            Grd3TrCollectionDrDep(Convert.ToDateTime(Classes.GetServerDate.Cs_GetServerDate()), 1);
            //***********استدعاء الحوافظ التي لم يتم دمجها بحافظه
            Grd3TrCollectionDrFalseDep();
            Grd4TRCollctionCheq();
            //****************
            if (dataGridView2.Rows.Count == 0)
            { AddColumnDtaGrd2(); }
            //****************  عرض الحوافظ التي لم يتم دمجها بحافظ 

            DgrTrCollectionFalseDeposit();
            TotalChequeCollection();
            //************** مايتم عرضه من بيانات الحوافظ 
            GrdTRCollctionCheq();

            dTPCollection.Select();
            this.ActiveControl = dTPCollection;
            dTPCollection.Focus();
        }
        private void dTPCollection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dataGridView1.Rows.Count != 0)
                { dataGridView1.Rows.Clear(); }
                if (dataGridView2.Rows.Count != 0)
                {
                    dataGridView2.Rows.Clear();
                }
                ClearData();
                //***********استدعاء الحوافظ التي لم يتم ايداعها
                Grd3TrCollectionBrFalseDep();

                //************retrieve data saved Deposit at this Day 

                if (Vint_ChequeReceivedKindID == 0)
                {
                    //Grd3TrCollectionBrDep(Convert.ToDateTime(dTPDeposit.Value.ToString("yyyy/MM/dd")), 0);

                    //***********الحوافظ التي تم ايداعها في تاريح 
                    if (dataGridView4.Rows.Count != 0)
                    {
                        DgrTrCollectionDeposit();
                    }
                    //***********الحوافظ التي لم تم ايداعها في تاريح 
                    if (dataGridView3.Rows.Count != 0)
                    {
                        DgrTrCollectionFalseDeposit();
                    }
                    //***********
                    if (dataGridView4.Rows.Count != 0 || dataGridView3.Rows.Count != 0)
                    {
                        TotalChequeCollection();
                        //************ضبط طريقة عرض بيانات الحوافظ Datagridview2 
                        GrdTRCollctionCheq();
                        //************ضبط طريقة عرض بيانات الشيكات  Datagridview1
                        GrdBnkCheq();
                    }


                }
                else if (Vint_ChequeReceivedKindID == 1)
                {
                    //Grd3TrCollectionDrDep(Convert.ToDateTime(dTPDeposit.Value.ToString("yyyy/MM/dd")), 1);
                    DgrTrCollectionFalseDeposit();
                    DgrTrCollectionDeposit();
                    GrdTRCollctionCheq();

                }
                //if (dataGridView1.Rows.Count == 0)
                //{ AddColumnDtaGrd1(); }



                dataGridView2.Focus();
            }
        }
        private void DgrTrCollectionDeposit()
        {
            int? Vint_RepresentiveID = 0;
            string Vst_ReceiptNo = "";
            //**************** Retrieve Data Not Deposit Untill Now 

            for (int i = 0; i < dataGridView4.Rows.Count; i++)
            {
                dataGridView4.Rows[i].Cells[1].Value = true;
                Vlng_TreasuryCollectionID = long.Parse(dataGridView4.Rows[i].Cells[0].Value.ToString());

                //************** Declare 
                int Vint_ID = int.Parse(dataGridView4.Rows[i].Cells[0].Value.ToString());
                int Vint_BranchID = int.Parse(dataGridView4.Rows[i].Cells[1].Value.ToString());

                string Vst_BranchName = dataGridView4.Rows[i].Cells[2].Value.ToString();
                string Vst_TradeCollectionNo = dataGridView4.Rows[i].Cells[3].Value.ToString();

                string Vst_CollectionNo = dataGridView4.Rows[i].Cells[4].Value.ToString();
                DateTime Vdt_CollectionDate = Convert.ToDateTime(dataGridView4.Rows[i].Cells[5].Value.ToString());

                int Vint_BankDepositeID = int.Parse(dataGridView4.Rows[i].Cells[6].Value.ToString());
                int Vint_BankAccountID = int.Parse(dataGridView4.Rows[i].Cells[7].Value.ToString());
                var listAccName = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_BankAccountID).ToList();
                string Vst_BNameAcc = dataGridView4.Rows[i].Cells[8].Value.ToString();
                string Vst_Name = dataGridView4.Rows[i].Cells[9].Value.ToString();

                if (dataGridView4.Rows[i].Cells[10].Value != null)
                { Vint_RepresentiveID = int.Parse(dataGridView4.Rows[i].Cells[9].Value.ToString()); }
                else { Vint_RepresentiveID = null; }
                var listRepresentiveName = FsDb.Tbl_Representatives.Where(x => x.ID == Vint_RepresentiveID).ToList();
                if (dataGridView4.Rows[i].Cells[11].Value != "")
                { Vst_ReceiptNo = dataGridView4.Rows[i].Cells[10].Value.ToString(); }
                else { Vst_ReceiptNo = ""; }
                //**********************
                if (Vint_ChequeReceivedKindID == 1)
                {
                    txtBranch.Text = Vst_BranchName;
                    txtBranchID.Text = Vint_BranchID.ToString();
                    dTPCollection.Value = Vdt_CollectionDate;
                    txtCollectionNo.Text = Vst_CollectionNo;
                    //cmbBnkDeposit.SelectedValue = Vint_BankDepositeID;
                    txtAccountBnk.Text = listAccName[0].AccountBankNo;
                    txtRepresentive.Text = listRepresentiveName[0].Name;

                }
                dataGridView2.AllowUserToAddRows = true;
                dataGridView2.Rows.Add(0, true, 0, 0, Vint_ID, Vint_BranchID, Vst_BranchName, Vst_TradeCollectionNo, Vst_CollectionNo
                , Vdt_CollectionDate, Vint_BankDepositeID, Vint_BankAccountID, Vst_BNameAcc, Vst_Name, Vint_RepresentiveID, Vst_ReceiptNo);
                dataGridView2.AllowUserToAddRows = false;
                TotalChequeCollection();
                var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                     join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                     join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                     //join Cust in FsDb.Tbl_Customer on BnkChq.CustID equals Cust.ID
                                     where (TRC.ChequeReceivedKindID == Vint_ChequeReceivedKindID && BnkChq.TreasuryCollectionID == Vlng_TreasuryCollectionID)
                                     select new

                                     {
                                         ID = BnkChq.ID,
                                         TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                         AmountCheque = BnkChq.AmountCheque,
                                         BankDrawnOnID = BnkChq.BankDrawnOnID,
                                         ChequeNo = BnkChq.ChequeNo,
                                         ChequeDueDate = BnkChq.ChequeDueDate,
                                         DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                         CustID = BnkChq.CustID,
                                         AddDateBank = BnkChq.AddDateBank,
                                         ChequeKind = BnkChq.ChequeKindID,
                                         //CustomerName = Cust.Name,
                                         BankName = BNK.Name,
                                         ReceiptNo = TRC.ReceiptNo,
                                         IsDisposed = BnkChq.IsDepositNo

                                     }).OrderBy(x => x.ChequeDueDate).ToList();
                //if (dataGridView1.Rows.Count == 0)
                //{
                //    AddColumnDtaGrd1();
                //}
                for (int j = 0; j < (listBnkCheque.Count); j++)
                {

                    dataGridView1.AllowUserToAddRows = true;


                    dataGridView1.Rows.Add(0, listBnkCheque[j].IsDisposed, listBnkCheque[j].ID, listBnkCheque[j].TreasuryCollectionID, listBnkCheque[j].AmountCheque, listBnkCheque[j].BankDrawnOnID,
                    listBnkCheque[j].ChequeNo, listBnkCheque[j].ChequeDueDate, listBnkCheque[j].DepositedByTrRepresntvID, listBnkCheque[j].CustID, listBnkCheque[j].AddDateBank, listBnkCheque[j].ChequeKind, listBnkCheque[j].BankName, true);
                    dataGridView1.AllowUserToAddRows = false;
                    LoadSerial();
                    //GrdBnkCheq();
                }
                LoadSerial2();
            }

            //*******************
            //if (dataGridView2.RowCount > 0)
            //{
            //    txtAllValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
            //                                            select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
            //    txtAllTrCollectionCount.Text = (from DataGridViewRow row in dataGridView2.Rows
            //                                    select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();
            //    //********
            //    txtSpValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
            //                                        where (Convert.ToBoolean(row.Cells[1].Value) == true)
            //                                        select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
            //    txtCheqSpCount.Text = ((from DataGridViewRow row in dataGridView1.Rows
            //                            where (Convert.ToBoolean(row.Cells[1].Value) == true)
            //                            select Convert.ToDouble(row.Cells[3].Value)).Count().ToString());

            //    //************
            //    //********
            //    txtSpValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
            //                                           where (Convert.ToBoolean(row.Cells[1].Value) == true)
            //                                           select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
            //    txtSpTrCollection.Text = (from DataGridViewRow row in dataGridView2.Rows
            //                              where (Convert.ToBoolean(row.Cells[1].Value) == true)
            //                              select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

            //    //************
            //}
        }
        private void DgrTrCollectionFalseDeposit()
        {
            int? Vint_RepresentiveID = 0;
            string Vst_ReceiptNo = "";
            //**************** Retrieve Data Not Deposit Untill Now 

            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                dataGridView3.Rows[i].Cells[1].Value = true;
                Vlng_TreasuryCollectionID = long.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString());
                int Vint_ID = 0;
                int Vint_BranchID = 0;
                string Vst_BranchName = "";
                string Vst_TradeCollectionNo = "";
                string Vst_CollectionNo = "";
                DateTime? Vdt_CollectionDate = null;
                int Vint_BankDepositeID = 0;
                int Vint_BankAccountID = 0;
                string Vst_BNameAcc = "";
                string Vst_Name = "";



                //************** Declare 
                if (Vint_ChequeReceivedKindID == 0)
                {
                    Vint_ID = int.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString());
                    Vint_BranchID = int.Parse(dataGridView3.Rows[i].Cells[1].Value.ToString());

                    Vst_BranchName = dataGridView3.Rows[i].Cells[2].Value.ToString();
                    Vst_TradeCollectionNo = dataGridView3.Rows[i].Cells[3].Value.ToString();

                    Vst_CollectionNo = dataGridView3.Rows[i].Cells[4].Value.ToString();
                    Vdt_CollectionDate = Convert.ToDateTime(dataGridView3.Rows[i].Cells[5].Value.ToString());

                    Vint_BankDepositeID = int.Parse(dataGridView3.Rows[i].Cells[6].Value.ToString());
                    Vint_BankAccountID = int.Parse(dataGridView3.Rows[i].Cells[7].Value.ToString());
                    Vst_BNameAcc = dataGridView3.Rows[i].Cells[8].Value.ToString();
                    Vst_Name = dataGridView3.Rows[i].Cells[9].Value.ToString();


                    if (dataGridView3.Rows[i].Cells[10].Value != null)
                    { Vint_RepresentiveID = int.Parse(dataGridView3.Rows[i].Cells[9].Value.ToString()); }
                    else { Vint_RepresentiveID = null; }
                    if (dataGridView3.Rows[i].Cells[11].Value != "")
                    { Vst_ReceiptNo = dataGridView3.Rows[i].Cells[10].Value.ToString(); }
                    else { Vst_ReceiptNo = ""; }
                    //**********************
                }
                else if (Vint_ChequeReceivedKindID == 1)
                {
                    Vint_ID = int.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString());
                    Vint_BranchID = int.Parse(dataGridView3.Rows[i].Cells[1].Value.ToString());

                    Vst_BranchName = dataGridView3.Rows[i].Cells[2].Value.ToString();
                    if (dataGridView3.Rows[i].Cells[3].Value != null)
                    { Vst_TradeCollectionNo = dataGridView3.Rows[i].Cells[3].Value.ToString(); }

                    Vst_CollectionNo = dataGridView3.Rows[i].Cells[4].Value.ToString();
                    Vdt_CollectionDate = Convert.ToDateTime(dataGridView3.Rows[i].Cells[5].Value.ToString());

                    Vint_BankDepositeID = int.Parse(dataGridView3.Rows[i].Cells[6].Value.ToString());
                    Vint_BankAccountID = int.Parse(dataGridView3.Rows[i].Cells[7].Value.ToString());
                    //Vst_BNameAcc = dataGridView3.Rows[i].Cells[8].Value.ToString();
                    //Vst_Name = dataGridView3.Rows[i].Cells[9].Value.ToString();


                    if (dataGridView3.Rows[i].Cells[8].Value != null)
                    { Vint_RepresentiveID = int.Parse(dataGridView3.Rows[i].Cells[9].Value.ToString()); }
                    else { Vint_RepresentiveID = null; }
                    if (dataGridView3.Rows[i].Cells[9].Value != null && dataGridView3.Rows[i].Cells[9].Value != "")
                    { Vst_ReceiptNo = dataGridView3.Rows[i].Cells[10].Value.ToString(); }
                    else { Vst_ReceiptNo = ""; }
                }
                //if (dataGridView2.Rows.Count == 0)
                //{ AddColumnDtaGrd2(); }
                dataGridView2.AllowUserToAddRows = true;
                dataGridView2.Rows.Add(0, false, 0, 0, Vint_ID, Vint_BranchID, Vst_BranchName, Vst_TradeCollectionNo, Vst_CollectionNo
                , Vdt_CollectionDate, Vint_BankDepositeID, Vint_BankAccountID, Vst_BNameAcc, Vst_Name, Vint_RepresentiveID, Vst_ReceiptNo);
                dataGridView2.AllowUserToAddRows = false;
                //TotalChequeCollection();

                LoadSerial2();
            }

            //*******************
            if (dataGridView2.RowCount > 0)
            {
                txtAllValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                        select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
                txtAllTrCollectionCount.Text = (from DataGridViewRow row in dataGridView2.Rows
                                                select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();
                //********
                //txtSpValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                //                                    where (Convert.ToBoolean(row.Cells[1].Value) == true)
                //                                    select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
                //txtCheqSpCount.Text = ((from DataGridViewRow row in dataGridView1.Rows
                //                        where (Convert.ToBoolean(row.Cells[1].Value) == true)
                //                        select Convert.ToDouble(row.Cells[3].Value)).Count().ToString());

                ////************
                ////********
                //txtSpValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                //                                       where (Convert.ToBoolean(row.Cells[1].Value) == true)
                //                                       select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
                //txtSpTrCollection.Text = (from DataGridViewRow row in dataGridView2.Rows
                //                          where (Convert.ToBoolean(row.Cells[1].Value) == true)
                //                          select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

                ////************
            }
        }
        private void DgrTrCollectionRetr5()
        {
            int? Vint_RepresentiveID = 0;
            string Vst_ReceiptNo = "";
            //**************** Retrieve Data Not Deposit Untill Now 

            for (int i = 0; i < dataGridView5.Rows.Count; i++)
            {
                dataGridView5.Rows[i].Cells[1].Value = true;
                Vlng_TreasuryCollectionID = long.Parse(dataGridView5.Rows[i].Cells[0].Value.ToString());
                int Vint_ID = 0;
                int Vint_BranchID = 0;
                string Vst_BranchName = "";
                string Vst_TradeCollectionNo = "";
                string Vst_CollectionNo = "";
                DateTime? Vdt_CollectionDate = null;
                int Vint_BankDepositeID = 0;
                int Vint_BankAccountID = 0;
                string Vst_BNameAcc = "";
                string Vst_Name = "";



                //************** Declare 
                if (Vint_ChequeReceivedKindID == 0)
                {
                    Vint_ID = int.Parse(dataGridView5.Rows[i].Cells[0].Value.ToString());
                    Vint_BranchID = int.Parse(dataGridView5.Rows[i].Cells[1].Value.ToString());

                    Vst_BranchName = dataGridView5.Rows[i].Cells[2].Value.ToString();
                    Vst_TradeCollectionNo = dataGridView5.Rows[i].Cells[3].Value.ToString();

                    Vst_CollectionNo = dataGridView5.Rows[i].Cells[4].Value.ToString();
                    Vdt_CollectionDate = Convert.ToDateTime(dataGridView5.Rows[i].Cells[5].Value.ToString());

                    Vint_BankDepositeID = int.Parse(dataGridView5.Rows[i].Cells[6].Value.ToString());
                    Vint_BankAccountID = int.Parse(dataGridView5.Rows[i].Cells[7].Value.ToString());
                    Vst_BNameAcc = dataGridView5.Rows[i].Cells[8].Value.ToString();
                    Vst_Name = dataGridView5.Rows[i].Cells[9].Value.ToString();


                    if (dataGridView5.Rows[i].Cells[10].Value != null)
                    { Vint_RepresentiveID = int.Parse(dataGridView5.Rows[i].Cells[9].Value.ToString()); }
                    else { Vint_RepresentiveID = null; }
                    if (dataGridView5.Rows[i].Cells[11].Value != null)
                    { Vst_ReceiptNo = dataGridView5.Rows[i].Cells[10].Value.ToString(); }
                    else { Vst_ReceiptNo = ""; }
                    //**********************
                }
                else if (Vint_ChequeReceivedKindID == 1)
                {
                    Vint_ID = int.Parse(dataGridView5.Rows[i].Cells[0].Value.ToString());
                    Vint_BranchID = int.Parse(dataGridView5.Rows[i].Cells[1].Value.ToString());

                    Vst_BranchName = dataGridView5.Rows[i].Cells[2].Value.ToString();
                    if (dataGridView5.Rows[i].Cells[3].Value != null)
                    { Vst_TradeCollectionNo = dataGridView5.Rows[i].Cells[3].Value.ToString(); }

                    Vst_CollectionNo = dataGridView5.Rows[i].Cells[4].Value.ToString();
                    Vdt_CollectionDate = Convert.ToDateTime(dataGridView5.Rows[i].Cells[5].Value.ToString());

                    Vint_BankDepositeID = int.Parse(dataGridView5.Rows[i].Cells[6].Value.ToString());
                    Vint_BankAccountID = int.Parse(dataGridView5.Rows[i].Cells[7].Value.ToString());
                    //Vst_BNameAcc = dataGridView5.Rows[i].Cells[8].Value.ToString();
                    //Vst_Name = dataGridView5.Rows[i].Cells[9].Value.ToString();


                    if (dataGridView5.Rows[i].Cells[10].Value != null)
                    { Vint_RepresentiveID = int.Parse(dataGridView5.Rows[i].Cells[10].Value.ToString()); }
                    else { Vint_RepresentiveID = null; }
                    if (dataGridView5.Rows[i].Cells[11].Value != null)
                    { Vst_ReceiptNo = dataGridView5.Rows[i].Cells[11].Value.ToString(); }
                    else { Vst_ReceiptNo = ""; }
                }
                //if (dataGridView2.Rows.Count == 0)
                //{ AddColumnDtaGrd2(); }
                dataGridView2.AllowUserToAddRows = true;
                dataGridView2.Rows.Add(0, true, 0, 0, Vint_ID, Vint_BranchID, Vst_BranchName, Vst_TradeCollectionNo, Vst_CollectionNo
                , Vdt_CollectionDate, Vint_BankDepositeID, Vint_BankAccountID, Vst_BNameAcc, Vst_Name, Vint_RepresentiveID, Vst_ReceiptNo);
                dataGridView2.AllowUserToAddRows = false;
                //TotalChequeCollection();

                LoadSerial2();
            }

            //*******************
            if (dataGridView2.RowCount > 0)
            {
                txtAllValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                        select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
                txtAllTrCollectionCount.Text = (from DataGridViewRow row in dataGridView2.Rows
                                                select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();
                //********
                //txtSpValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                //                                    where (Convert.ToBoolean(row.Cells[1].Value) == true)
                //                                    select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
                //txtCheqSpCount.Text = ((from DataGridViewRow row in dataGridView1.Rows
                //                        where (Convert.ToBoolean(row.Cells[1].Value) == true)
                //                        select Convert.ToDouble(row.Cells[3].Value)).Count().ToString());

                ////************
                ////********
                //txtSpValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                //                                       where (Convert.ToBoolean(row.Cells[1].Value) == true)
                //                                       select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
                //txtSpTrCollection.Text = (from DataGridViewRow row in dataGridView2.Rows
                //                          where (Convert.ToBoolean(row.Cells[1].Value) == true)
                //                          select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

                ////************
            }
        }
        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DepositeCollectionFrm_Load(object sender, EventArgs e)
        {
            this.dtb_BanksTableAdapter.FillByBankKind(this.bankCheques1.Dtb_Banks);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Fiscalyear' table. You can move, or remove it, as needed.
            this.tbl_FiscalyearTableAdapter1.FillByYear(this.financialSysDataSet.Tbl_Fiscalyear);
            //radioGroup1.SelectedIndex = 0;
            //comboBox1.SelectedIndex = 0;
            Vint_ChequeReceivedKindID = 0;
            //Vint_ChequeReceivedKindID = 0;
            ClearData();
            txtRepresentive.SelectionLength = 0;

            cmbBnkDeposit.SelectedIndex = -1;
            cmbBnkDeposit.Text = "";
            cmbBnkDeposit.SelectedText = "اختر البنك المودع ";

            checkData();
            //***********استدعاء الجهات التي لم يتم عمل حوافظ لها 
            Grd3TrCollectionBrFalseDep();

            if (dataGridView2.Rows.Count == 0)
            { AddColumnDtaGrd2(); }
            //****************  عرض الجهات التي لم يتم عمل حوافظ لها 

            DgrTrCollectionFalseDeposit();
            TotalChequeCollection();
            //************** مايتم عرضه من بيانات الحوافظ 


            GrdTRCollctionCheq();

            dTPCollection.Select();
            this.ActiveControl = dTPCollection;
            dTPCollection.Focus();
        }
        private void AddColumnDtaGrd2()
        {
            // Create a new columns datadridview2
            DataGridViewTextBoxColumn newColumnID = new DataGridViewTextBoxColumn();

            // Set the properties of the new column
            newColumnID.HeaderText = "ID"; // Header text of the column
            newColumnID.Name = "ID"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnID);

            DataGridViewTextBoxColumn newColumnBranchID = new DataGridViewTextBoxColumn();
            newColumnBranchID.Name = "BranchID"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnBranchID);

            DataGridViewTextBoxColumn newColumnBranchName = new DataGridViewTextBoxColumn();
            newColumnBranchName.Name = "BranchName"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnBranchName);

            DataGridViewTextBoxColumn newColumnTradeCollectionNo = new DataGridViewTextBoxColumn();
            newColumnTradeCollectionNo.Name = "TradeCollectionNo"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnTradeCollectionNo);

            DataGridViewTextBoxColumn newColumnCollectionNo = new DataGridViewTextBoxColumn();
            newColumnCollectionNo.Name = "CollectionNo"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnCollectionNo);

            DataGridViewTextBoxColumn newColumnCollectionDate = new DataGridViewTextBoxColumn();
            newColumnCollectionDate.Name = "CollectionDate"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnCollectionDate);

            DataGridViewTextBoxColumn newColumnBankDepositeID = new DataGridViewTextBoxColumn();
            newColumnBankDepositeID.Name = "BankDepositeID"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnBankDepositeID);

            //*****************

            DataGridViewTextBoxColumn newColumnBankAccountID = new DataGridViewTextBoxColumn();
            newColumnBankAccountID.Name = "BankAccountID"; // Unique name of the column
            newColumnBankAccountID.Visible = false;
            dataGridView2.Columns.Add(newColumnBankAccountID);

            DataGridViewTextBoxColumn newColumnBankAccName = new DataGridViewTextBoxColumn();
            newColumnBankAccName.Name = "BankAccName"; // Unique name of the column
            newColumnBankAccName.Visible = false;
            dataGridView2.Columns.Add(newColumnBankAccName);

            DataGridViewTextBoxColumn newColumnName = new DataGridViewTextBoxColumn();
            newColumnName.Name = "Name"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnName);

            DataGridViewTextBoxColumn newColumnRepresentiveID = new DataGridViewTextBoxColumn();
            newColumnRepresentiveID.Name = "RepresentiveID"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnRepresentiveID);

            DataGridViewTextBoxColumn newColumnReceiptNo = new DataGridViewTextBoxColumn();
            newColumnReceiptNo.Name = "ReceiptNo"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnReceiptNo);







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

            //*****************

            DataGridViewTextBoxColumn newColumnDepositedByTrRepresntvID = new DataGridViewTextBoxColumn();
            newColumnDepositedByTrRepresntvID.Name = "DepositedByTrRepresntvID"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnDepositedByTrRepresntvID);

            DataGridViewTextBoxColumn newColumnCustID = new DataGridViewTextBoxColumn();
            newColumnCustID.Name = "CustID"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnCustID);

            DataGridViewTextBoxColumn newColumnAddDateBank = new DataGridViewTextBoxColumn();
            newColumnAddDateBank.Name = "AddDateBank"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnAddDateBank);

            DataGridViewTextBoxColumn newColumnChequeKind = new DataGridViewTextBoxColumn();
            newColumnChequeKind.Name = "ChequeKind"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnChequeKind);

            DataGridViewTextBoxColumn newColumnBankName = new DataGridViewTextBoxColumn();
            newColumnBankName.Name = "BankName"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnBankName);

            DataGridViewCheckBoxColumn newColumnChqUpdate = new DataGridViewCheckBoxColumn();
            newColumnChqUpdate.Name = "ChqBxUpd"; // Unique name of the column
            newColumnChqUpdate.Visible = false;
            dataGridView1.Columns.Add(newColumnChqUpdate);
        }
        private void GrdBankCheqData()
        {
            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                 //join Cust in FsDb.Tbl_Customer on BnkChq.CustID equals Cust.ID
                                 where (TRC.ChequeReceivedKindID == Vint_ChequeReceivedKindID)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     //CustomerName = Cust.Name,
                                     BankName = BNK.Name

                                 }).OrderBy(x => x.ChequeDueDate).ToList();

            dataGridView1.DataSource = listBnkCheque;
            LoadSerial();
            GrdBnkCheq();
        }
        private void LoadSerial()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = i; i++;
            }
        }
        private void LoadSerial2()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.Cells[0].Value = i; i++;
            }
        }

        private void TotalChequeCollection()
        {

            int i = 1;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                Vlng_LastRowTreasuryCollection = int.Parse(row.Cells["ID"].Value.ToString());
                int VCheck_Khaz = int.Parse(row.Cells["BranchID"].Value.ToString());
                //******************

                if (VCheck_Khaz != 180)
                {
                    var query = (from ChBnk in FsDb.Tbl_BankCheques
                                 where ChBnk.TreasuryCollectionID == Vlng_LastRowTreasuryCollection
                                 group ChBnk by 1 into grp
                                 select new
                                 {
                                     rowCount = grp.Count(),
                                     rowSum = grp.Sum(x => x.AmountCheque)
                                 }).ToList();
                    if (query.Count != 0)

                    {
                        row.Cells["CountChq"].Value = query[0].rowCount;
                        row.Cells["TotalAmountChq"].Value = query[0].rowSum;
                    }
                }
                else
                {
                    //var list = FsDb.Tbl_TreasuryCollection.Where(x => x.ID == Vlng_LastRowTreasuryCollection).ToList();
                    var query = (from ChBnk in FsDb.Tbl_BankCheques
                                 join Trc in FsDb.Tbl_TreasuryCollection on ChBnk.TreasuryCollectionID equals Trc.ID
                                 where Trc.Parent_ID == Vlng_LastRowTreasuryCollection
                                 group ChBnk by 1 into grp
                                 select new
                                 {
                                     rowCount = grp.Count(),
                                     rowSum = grp.Sum(x => x.AmountCheque)
                                 }).ToList();
                    if (query.Count != 0)

                    {
                        row.Cells["CountChq"].Value = query[0].rowCount;
                        row.Cells["TotalAmountChq"].Value = query[0].rowSum;
                    }

                }
                //***************

            }
            //*******************
            if (dataGridView2.RowCount > 0)
            {
                txtAllValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                        select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
                txtAllTrCollectionCount.Text = (from DataGridViewRow row in dataGridView2.Rows
                                                select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();
                //********
                txtSpValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                    where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                    select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
                txtCheqSpCount.Text = ((from DataGridViewRow row in dataGridView1.Rows
                                        where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                        select Convert.ToDouble(row.Cells[3].Value)).Count().ToString());

                //************
                //********
                txtSpValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                       where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                       select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
                txtSpTrCollection.Text = (from DataGridViewRow row in dataGridView2.Rows
                                          where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                          select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();
            }
            //************
        }
        private void GrdCheqData()
        {
            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        join Rpsntv in FsDb.Tbl_Representatives on TRC.RepresentiveID equals Rpsntv.ID
                        join BnkAcct in FsDb.Tbl_AccountsBank on TRC.BankAccounNoID equals BnkAcct.ID
                        where (TRC.ID == Vlng_LastRowTreasuryCollection)
                        select new
                        {
                            ID = TRC.ID,
                            BranchID = TRC.BranchID,
                            //IsDepositNo = TRC.IsDepositNo,
                            BranchName = MNG.BrancheName,
                            CollectionNo = TRC.CollectionNo,
                            CollectionDate = TRC.CollectionDate,
                            BankDepositeID = TRC.BankDepositeID,
                            BankAccountID = TRC.BankAccounNoID,
                            BankAccName = BnkAcct.AccountBankNo,
                            BanKName = BNK.Name,
                            RepresentiveID = TRC.RepresentiveID,

                            ReceiptNo = TRC.ReceiptNo,
                            RepresentiveName = Rpsntv.Name,
                        }).OrderBy(x => x.ID).ToList();
            dataGridView1.DataSource = list;
            LoadSerial();
            GrdBnkCheq();

        }
        private void Grd3TrCollectionBrFalseDep()
        {
            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        where (TRC.ChequeReceivedKindID == 0 && TRC.Parent_ID == null)
                        select new
                        {
                            ID = TRC.ID,
                            BranchID = TRC.BranchID,
                            //IsDepositNo = TRC.IsDepositNo,
                            BranchName = MNG.BrancheName,
                            TradeCollectionNo = TRC.TradeCollectionNo,
                            CollectionNo = TRC.CollectionNo,
                            CollectionDate = TRC.CollectionDate,
                            BankDepositeID = TRC.BankDepositeID,
                            BankAccountID = TRC.BankAccounNoID,
                            BankAccountName = BNK.Name,
                            Name = BNK.Name,
                            RepresentiveID = TRC.RepresentiveID,
                            ReceiptNo = TRC.ReceiptNo,

                        }).OrderBy(x => x.ID).Take(30).ToList();
            dataGridView3.DataSource = list;


        }
        private void Grd3TrCollectionDrFalseDep()
        {
            var list = (from TRC in FsDb.Tbl_TreasuryCollection

                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        where (TRC.ChequeReceivedKindID == 1 && TRC.Parent_ID == null)
                        select new
                        {
                            ID = TRC.ID,
                            BranchID = TRC.BranchID,
                            //IsDepositNo = TRC.IsDepositNo,
                            BranchName = MNG.BrancheName,
                            TradeCollectionNo = TRC.TradeCollectionNo,
                            CollectionNo = TRC.CollectionNo,
                            CollectionDate = TRC.CollectionDate,
                            BankDepositeID = TRC.BankDepositeID,
                            BankAccountID = TRC.BankAccounNoID,

                            RepresentiveID = TRC.RepresentiveID,
                            ReceiptNo = TRC.ReceiptNo,

                        }).OrderBy(x => x.ID).Take(30).ToList();
            dataGridView3.DataSource = list;


        }
        private void Grd3TrCollectionBrDep(DateTime Vdt_DepositDate, int Vint_ReceivedKindID)
        {

            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        where (TRC.ChequeReceivedKindID == Vint_ChequeReceivedKindID && TRC.IsDepositNo == true && TRC.DepositDate == Vdt_DepositDate)
                        select new
                        {
                            ID = TRC.ID,
                            BranchID = TRC.BranchID,
                            //IsDepositNo = TRC.IsDepositNo,
                            BranchName = MNG.BrancheName,
                            TradeCollectionNo = TRC.TradeCollectionNo,
                            CollectionNo = TRC.CollectionNo,
                            CollectionDate = TRC.CollectionDate,
                            BankDepositeID = TRC.BankDepositeID,
                            BankAccountID = TRC.BankAccounNoID,
                            BankAccountName = BNK.Name,
                            Name = BNK.Name,
                            RepresentiveID = TRC.RepresentiveID,
                            ReceiptNo = TRC.ReceiptNo,

                        }).OrderBy(x => x.ID).Take(30).ToList();
            dataGridView4.DataSource = list;


        }
        private void Grd3TrCollectionDrDep(DateTime Vdt_DepositDate, int Vint_ReceivedKindID)
        {
            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        where (TRC.ChequeReceivedKindID == 0 && TRC.CollectionDate == Vdt_DepositDate && TRC.BranchID == 180)
                        select new
                        {
                            ID = TRC.ID,
                            BranchID = TRC.BranchID,
                            //IsDepositNo = TRC.IsDepositNo,
                            BranchName = MNG.BrancheName,
                            TradeCollectionNo = TRC.TradeCollectionNo,
                            CollectionNo = TRC.CollectionNo,
                            CollectionDate = TRC.CollectionDate,
                            BankDepositeID = TRC.BankDepositeID,
                            BankAccountID = TRC.BankAccounNoID,
                            BankAccountName = BNK.Name,
                            Name = BNK.Name,
                            RepresentiveID = TRC.RepresentiveID,
                            ReceiptNo = TRC.ReceiptNo,

                        }).OrderBy(x => x.ID).Take(30).ToList();
            dataGridView4.DataSource = list;
            if (list != null)
            {

            }


        }
        private void Grd4TrCollectionDrMain(long Vlng_TrCollectionID)
        {
            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        where (TRC.ChequeReceivedKindID == 1 && TRC.Parent_ID == Vlng_TrCollectionID)
                        select new
                        {
                            ID = TRC.ID,
                            BranchID = TRC.BranchID,
                            //IsDepositNo = TRC.IsDepositNo,
                            BranchName = MNG.BrancheName,
                            TradeCollectionNo = TRC.TradeCollectionNo,
                            CollectionNo = TRC.CollectionNo,
                            CollectionDate = TRC.CollectionDate,
                            BankDepositeID = TRC.BankDepositeID,
                            BankAccountID = TRC.BankAccounNoID,
                            BankAccountName = BNK.Name,
                            Name = BNK.Name,
                            RepresentiveID = TRC.RepresentiveID,
                            ReceiptNo = TRC.ReceiptNo,

                        }).OrderBy(x => x.ID).Take(30).ToList();
            dataGridView5.DataSource = list;

        }
        private void GrdTrCollectionBr()
        {
            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        where (TRC.ChequeReceivedKindID == Vint_ChequeReceivedKindID && TRC.IsDepositNo == false)
                        select new
                        {
                            ID = TRC.ID,
                            BranchID = TRC.BranchID,
                            //IsDepositNo = TRC.IsDepositNo,
                            BranchName = MNG.BrancheName,
                            TradeCollectionNo = TRC.TradeCollectionNo,
                            CollectionNo = TRC.CollectionNo,
                            CollectionDate = TRC.CollectionDate,
                            BankDepositeID = TRC.BankDepositeID,
                            BankAccountID = TRC.BankAccounNoID,
                            Name = BNK.Name,
                            RepresentiveID = TRC.RepresentiveID,
                            ReceiptNo = TRC.ReceiptNo,

                        }).OrderBy(x => x.ID).Take(30).ToList();
            dataGridView2.DataSource = list;
            if (list.Count > 0)
            {
                TotalChequeCollection();
                LoadSerial2();
                GrdTRCollctionCheq();
            }

        }

        private void GrdTrCollectionDateBr(DateTime Vdt_DepositTrcollection)
        {
            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        where (TRC.ChequeReceivedKindID == Vint_ChequeReceivedKindID && TRC.DepositDate == Vdt_DepositTrcollection)
                        select new
                        {
                            ID = TRC.ID,
                            BranchID = TRC.BranchID,
                            //IsDepositNo = TRC.IsDepositNo,
                            BranchName = MNG.BrancheName,
                            TradeCollectionNo = TRC.TradeCollectionNo,
                            CollectionNo = TRC.CollectionNo,
                            CollectionDate = TRC.CollectionDate,
                            BankDepositeID = TRC.BankDepositeID,
                            BankAccountID = TRC.BankAccounNoID,
                            Name = BNK.Name,
                            RepresentiveID = TRC.RepresentiveID,
                            ReceiptNo = TRC.ReceiptNo,

                        }).OrderBy(x => x.ID).Take(30).ToList();
            //if (dataGridView2.Rows.Count == 0)
            //{ AddColumnDtaGrd2(); }

            DgrTrCollectionFalseDeposit();
            GrdTRCollctionCheq();
            //TotalChequeCollection();
        }
        private void GrdTrCollectionDr()
        {
            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                            //join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        //join BnkAcct in FsDb.Tbl_AccountsBank on TRC.BankAccounNoID equals BnkAcct.ID
                        where (TRC.ChequeReceivedKindID == Vint_ChequeReceivedKindID)
                        select new
                        {
                            ID = TRC.ID,
                            BranchID = TRC.BranchID,
                            BranchName = MNG.BrancheName,
                            TradeCollectionNo = TRC.TradeCollectionNo,
                            CollectionNo = TRC.CollectionNo,
                            CollectionDate = TRC.CollectionDate,
                            BankDepositeID = TRC.BankDepositeID,
                            BankAccountID = TRC.BankAccounNoID,

                            RepresentiveID = TRC.RepresentiveID,
                            ReceiptNo = TRC.ReceiptNo

                        }).OrderBy(x => x.ID).Take(30).ToList();
            dataGridView2.DataSource = list;
            if (list.Count > 0)
            {
                TotalChequeCollection();
                LoadSerial2();
                GrdTRCollctionCheq();
            }
        }

        private void GrdTRCollctionCheq()
        {

            dataGridView2.Columns["ID"].Visible = false;
            dataGridView2.Columns["BranchID"].Visible = false;
            dataGridView2.Columns["BankDepositeID"].Visible = false;
            dataGridView2.Columns["RepresentiveID"].Visible = false;

            dataGridView2.Columns["BankAccountID"].Visible = false;
            dataGridView2.Columns["ReceiptNo"].Visible = false;
            dataGridView2.Columns["TradeCollectionNo"].Visible = false;
            dataGridView2.Columns["BranchName"].HeaderText = " الجهه";
            dataGridView2.Columns["BranchName"].Width = 120;
            dataGridView2.Columns["CollectionNo"].HeaderText = "رقم  المستند";
            dataGridView2.Columns["CollectionDate"].HeaderText = "تاريخ المستند";



        }
        private void Grd4TRCollctionCheq()
        {

            dataGridView4.Columns["ID"].Visible = false;
            dataGridView4.Columns["BranchID"].Visible = false;
            dataGridView4.Columns["BankDepositeID"].Visible = false;
            dataGridView4.Columns["RepresentiveID"].Visible = false;

            dataGridView4.Columns["BankAccountID"].Visible = false;
            dataGridView4.Columns["ReceiptNo"].Visible = false;
            dataGridView4.Columns["TradeCollectionNo"].Visible = false;
            dataGridView4.Columns["BranchName"].HeaderText = " الجهه";
            dataGridView4.Columns["BranchName"].Width = 120;
            dataGridView4.Columns["CollectionNo"].Width = 140;
            dataGridView4.Columns["CollectionNo"].HeaderText = "رقم  الحافظه";
            dataGridView4.Columns["CollectionDate"].HeaderText = "تاريخ الحافظه";
            dataGridView4.Columns["CollectionDate"].DefaultCellStyle.Format = "yyyy/MM/dd";
            dataGridView4.Columns["Name"].HeaderText = "البنك المودع";
            dataGridView4.Columns["BankAccountName"].Visible = false;
            dataGridView4.Columns["BranchName"].Visible = false;
            dataGridView4.Columns["Name"].Visible = true;
            dataGridView4.Columns["Name"].Width = 200;



        }
        private void GrdBnkCheq()
        {
            try
            {

                int Vint_DgCount = dataGridView1.RowCount;
                if (Vint_DgCount != 0)
                {
                    txtAllValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                         select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
                    txtCheqAllCount.Text = (from DataGridViewRow row in dataGridView1.Rows
                                            select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

                }
            }
            catch
            { }

            dataGridView1.Columns["TreasuryCollectionID"].Visible = false;
            dataGridView1.Columns["AmountCheque"].Visible = true;
            dataGridView1.Columns["ID"].Visible = false;

            dataGridView1.Columns["BankDrawnOnID"].Visible = false;
            dataGridView1.Columns["ChequeNo"].Visible = true;

            dataGridView1.Columns["ChequeDueDate"].Visible = true;
            dataGridView1.Columns["DepositedByTrRepresntvID"].Visible = false;

            dataGridView1.Columns["CustID"].Visible = false;
            dataGridView1.Columns["AddDateBank"].Visible = false;

            dataGridView1.Columns["ChequeKind"].Visible = false;

            //dataGridView1.Columns["CustomerName"].Visible = false;
            dataGridView1.Columns["BankName"].Visible = true;
            dataGridView1.Columns["BankName"].Width = 200;
            //dataGridView1.Columns["Tbl_ChequeKind"].Visible = true;
            //dataGridView1.Columns["Tbl_TreasuryCollection"].Visible = true;

            dataGridView1.Columns["AmountCheque"].HeaderText = "مبلغ الشيك";
            dataGridView1.Columns["AmountCheque"].Width = 120;

            dataGridView1.Columns["ChequeDueDate"].HeaderText = "تاريخ الشيك";
            dataGridView1.Columns["ChequeNo"].HeaderText = "رقم الشيك";

            //dataGridView1.Columns["CustomerName"].HeaderText = "العميل";
            dataGridView1.Columns["BankName"].HeaderText = "البنك";



        }
        private void checkData()
        {
            if (Vint_ChequeReceivedKindID == 0)
            {

                //groupControl1.Text = "بيانات الحافظه";
                //groupControl3.Text = "بيانات الحوافظ";
                //groupControl4.Text = "بيانات شيكات الحوافظ";
                label11.Text = "الفرع";
                //label2.Text = "رقم الحافظه";
                groupControl1.Visible = false;
                //label1.Visible = false;
                label2.Visible = false;
                label2.Visible = false;

                txtCollectionNo.Visible = false;
                //dTPCollection.Visible = true;
                label4.Visible = false;
                //txtBnkDeposit.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                //cmbAccountBank.Visible = false;
                txtAccountBnk.Visible = false;
                label10.Visible = false;
                txtRepresentive.Visible = false;


            }
            else if (Vint_ChequeReceivedKindID == 1)
            {
                //groupControl1.Text = "بيانات الجهه";
                //groupControl3.Text = "بيانات مستندات الجهات";
                //groupControl4.Text = "بيانات شيكات الجهات";
                //label11.Text = "الخزينه الرئيسيه";
                //label2.Text = "رقم الحافظه";
                //label2.Visible = true;
                //label3.Visible = true;
                groupControl1.Visible = true;
                txtBranch.Text = "الخزينه الرئيسيه";
                txtBranchID.Text = "180";

                txtCollectionNo.Visible = true;
                label4.Visible = true;
                //txtBranch.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                dTPCollection.Visible = true;
                label10.Visible = true;
                txtRepresentive.Visible = true;
                txtAccountBnk.Visible = false;
                cmbBnkDeposit.Visible = true;
                txtCollectionNo.Visible = true;



                txtAccountBnk.Visible = true;
                txtRepresentive.Visible = true;
                //GrdTrCollectionDr();
            }
        }
        private void checkDataNoData()
        {
            if (Vint_ChequeReceivedKindID == 0)
            {
                groupControl1.Text = "بيانات الحافظه";
                groupControl3.Text = "بيانات الحوافظ";
                groupControl4.Text = "بيانات شيكات الحوافظ";
                label11.Text = "الفرع";
                //label2.Text = "رقم الحافظه";

                label2.Visible = true;

                txtCollectionNo.Visible = true;
                //dTPCollection.Visible = true;
                label4.Visible = true;
                //txtBnkDeposit.Visible = false;
                label5.Visible = true;
                //cmbAccountBank.Visible = false;
                txtAccountBnk.Visible = true;
                label10.Visible = true;
                txtRepresentive.Visible = true;

                //label17.Visible = true;
                //txtTradeCollectionNO.Visible = true;

                //lblReceiptNo.Visible = true;
                //txtReceiptNo.Visible = true;


            }
            else if (Vint_ChequeReceivedKindID == 1)
            {
                groupControl1.Text = "بيانات الجهه";
                groupControl3.Text = "بيانات مستندات الجهات";
                groupControl4.Text = "بيانات شيكات الجهات";
                label11.Text = "الجهه";
                label2.Text = "رقم المستند";
                label2.Visible = true;

                txtCollectionNo.Visible = true;
                //dTPCollection.Visible = true;
                label4.Visible = false;
                cmbBnkDeposit.Visible = false;
                //txtBnkDeposit.Visible = false;
                label5.Visible = false;
                //cmbAccountBank.Visible = false;
                label10.Visible = false;
                txtRepresentive.Visible = false;
                txtAccountBnk.Visible = false;
                //label17.Visible = false;
                //txtTradeCollectionNO.Visible = false;



                //lblReceiptNo.Visible = false;
                //txtReceiptNo.Visible = false;

            }
        }
        private void ClearDataMaster()
        {
            txtRowID.Text = "";
            txtNewRowID.Text = "";
            txtBnkDepositID.Text = "";
            txtBnkDeposit.Text = "";

            txtAccountBnkID.Text = "";
            //cmbAccountBank.Text = "";
            txtAccountBnk.Text = "";

            txtCollectionNo.Text = "";
            dTPCollection.Value = Convert.ToDateTime(DateTime.Now.ToString());

            //txtBranchID.Text = "";
            //txtBranch.Text = "";

            txtRepresentiveID.Text = "";
            txtRepresentive.Text = "";

            //txtTradeCollectionNO.Text = "";
            //txtReceiptNo.Text = "";

            cmbBnkDeposit.SelectedIndex = -1;
            cmbBnkDeposit.Text = "";
            cmbBnkDeposit.SelectedText = "اختر البنك المودع ";
            //chckBxBasicData.Checked = false;
        }
        private void ClearDataDetails()
        {
            //txtAmount.Text = "";
            //txtRowChequeID.Text = "";

            //txtBankDrawnOn.Text = "";
            //txtBankDrawnOnID.Text = "";

            //txtCust.Text = "";
            //txtCustID.Text = "";

            //txtAllValueBefore.Text = "";
            //txtChequeNo.Text = "";

            //dTPDueDate.Value = Convert.ToDateTime(DateTime.Now.ToString());


        }
        public class DataGridViewCheckboxCellFilter : DataGridViewCheckBoxCell
        {
            public DataGridViewCheckboxCellFilter() : base()
            {
                this.FalseValue = 0;
                this.TrueValue = 1;
                this.Value = TrueValue;
            }
        }
        private void GetDataChequeBank5()
        {

            for (int t = 0; t < (dataGridView2.Rows.Count); t++)
            {

                if (Convert.ToBoolean(dataGridView2.Rows[t].Cells[1].Value) == true)
                {

                    Vlng_TreasuryCollectionID = long.Parse(dataGridView2.Rows[t].Cells[4].Value.ToString());
                    //***************

                    txtAllValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                            select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
                    txtAllTrCollectionCount.Text = (from DataGridViewRow row in dataGridView2.Rows
                                                    select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();
                    //********
                    txtSpValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                           where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                           select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
                    txtSpTrCollection.Text = (from DataGridViewRow row in dataGridView2.Rows
                                              where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                              select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

                    //************
                    var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                         join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                         join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                         where (TRC.ChequeReceivedKindID == Vint_ChequeReceivedKindID && TRC.ID == Vlng_TreasuryCollectionID)
                                         select new

                                         {
                                             ID = BnkChq.ID,
                                             TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                             AmountCheque = BnkChq.AmountCheque,
                                             BankDrawnOnID = BnkChq.BankDrawnOnID,
                                             ChequeNo = BnkChq.ChequeNo,
                                             ChequeDueDate = BnkChq.ChequeDueDate,
                                             DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                             CustID = BnkChq.CustID,
                                             AddDateBank = BnkChq.AddDateBank,
                                             ChequeKind = BnkChq.ChequeKindID,
                                             BankName = BNK.Name

                                         }).OrderBy(x => x.ChequeDueDate).ToList();
                    //*******************


                    string Vstr_Count = (from DataGridViewRow row in dataGridView1.Rows
                                         where (row.Cells[3].Value.ToString() == Vlng_TreasuryCollectionID.ToString())
                                         select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

                    if (Vstr_Count != listBnkCheque.Count.ToString())
                    {
                        if (dataGridView1.Rows.Count == 0)
                        {
                            AddColumnDtaGrd1();
                        }
                        for (int i = 0; i < (listBnkCheque.Count); i++)
                        {

                            dataGridView1.AllowUserToAddRows = true;
                            dataGridView1.Rows.Add(0, true, listBnkCheque[i].ID, listBnkCheque[i].TreasuryCollectionID, listBnkCheque[i].AmountCheque, listBnkCheque[i].BankDrawnOnID,
                            listBnkCheque[i].ChequeNo, listBnkCheque[i].ChequeDueDate, listBnkCheque[i].DepositedByTrRepresntvID, listBnkCheque[i].CustID, listBnkCheque[i].AddDateBank, listBnkCheque[i].ChequeKind, listBnkCheque[i].BankName, true);
                            dataGridView1.AllowUserToAddRows = false;
                            LoadSerial();
                            GrdBnkCheq();



                        }
                    }
                    else if (Vstr_Count == listBnkCheque.Count.ToString())
                    {
                        try
                        {
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                long Vlng_Trcoll = long.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                                if (Vlng_Trcoll == Vlng_TreasuryCollectionID)
                                {
                                    dataGridView1.Rows[i].Cells[1].Value = true;
                                    dataGridView1.Rows[i].Cells[13].Value = true;
                                }
                            }
                        }
                        catch
                        { }
                    }


                    //*************

                    txtSpValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                        where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                        select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
                    txtCheqSpCount.Text = ((from DataGridViewRow row in dataGridView1.Rows
                                            where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                            select Convert.ToDouble(row.Cells[3].Value)).Count().ToString());
                    //************
                }
                else if (Convert.ToBoolean(dataGridView2.CurrentRow.Cells[1].Value) == false)
                {
                    //******************
                    txtSpValueBeforeall.Text = "";
                    txtSpTrCollection.Text = "";
                    //***************
                    //********
                    txtSpValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                           where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                           select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
                    txtSpTrCollection.Text = (from DataGridViewRow row in dataGridView2.Rows
                                              where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                              select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

                    //************
                    Vlng_TreasuryCollectionID = long.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());
                    var V_CountChq = FsDb.Tbl_BankCheques.Where(x => x.TreasuryCollectionID == Vlng_TreasuryCollectionID).ToList();
                    if (V_CountChq.Count() != 0 && dataGridView1.RowCount > 0)
                    {
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            long VintTrCollectionCheq = long.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                            long Vlng_BnkChqID = long.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                            if (VintTrCollectionCheq == Vlng_TreasuryCollectionID)
                            {
                                dataGridView1.Rows[i].Cells[1].Value = false;

                            }

                        }

                    }

                }
            }
        }
        //*********************************************
        private void GetDataChequeBank()
        {



            if (Convert.ToBoolean(dataGridView2.CurrentRow.Cells[1].Value) == true)
            {

                Vlng_TreasuryCollectionID = long.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());
                //***************

                txtAllValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                        select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
                txtAllTrCollectionCount.Text = (from DataGridViewRow row in dataGridView2.Rows
                                                select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();
                //********
                txtSpValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                       where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                       select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
                txtSpTrCollection.Text = (from DataGridViewRow row in dataGridView2.Rows
                                          where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                          select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

                //************
                var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                     join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                     join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                     where (TRC.ChequeReceivedKindID == Vint_ChequeReceivedKindID && TRC.ID == Vlng_TreasuryCollectionID)
                                     select new

                                     {
                                         ID = BnkChq.ID,
                                         TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                         AmountCheque = BnkChq.AmountCheque,
                                         BankDrawnOnID = BnkChq.BankDrawnOnID,
                                         ChequeNo = BnkChq.ChequeNo,
                                         ChequeDueDate = BnkChq.ChequeDueDate,
                                         DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                         CustID = BnkChq.CustID,
                                         AddDateBank = BnkChq.AddDateBank,
                                         ChequeKind = BnkChq.ChequeKindID,
                                         BankName = BNK.Name

                                     }).OrderBy(x => x.ChequeDueDate).ToList();
                //*******************


                string Vstr_Count = (from DataGridViewRow row in dataGridView1.Rows
                                     where (row.Cells[3].Value.ToString() == Vlng_TreasuryCollectionID.ToString())
                                     select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

                if (Vstr_Count != listBnkCheque.Count.ToString())
                {
                    if (dataGridView1.Rows.Count == 0)
                    {
                        AddColumnDtaGrd1();
                    }
                    for (int i = 0; i < (listBnkCheque.Count); i++)
                    {

                        dataGridView1.AllowUserToAddRows = true;
                        dataGridView1.Rows.Add(0, true, listBnkCheque[i].ID, listBnkCheque[i].TreasuryCollectionID, listBnkCheque[i].AmountCheque, listBnkCheque[i].BankDrawnOnID,
                        listBnkCheque[i].ChequeNo, listBnkCheque[i].ChequeDueDate, listBnkCheque[i].DepositedByTrRepresntvID, listBnkCheque[i].CustID, listBnkCheque[i].AddDateBank, listBnkCheque[i].ChequeKind, listBnkCheque[i].BankName, true);
                        dataGridView1.AllowUserToAddRows = false;
                        LoadSerial();
                        GrdBnkCheq();



                    }
                }
                else if (Vstr_Count == listBnkCheque.Count.ToString())
                {
                    try
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            long Vlng_Trcoll = long.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                            if (Vlng_Trcoll == Vlng_TreasuryCollectionID)
                            {
                                dataGridView1.Rows[i].Cells[1].Value = true;
                                dataGridView1.Rows[i].Cells[13].Value = true;
                            }
                        }
                    }
                    catch
                    { }
                }


                //*************

                txtSpValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                    where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                    select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
                txtCheqSpCount.Text = ((from DataGridViewRow row in dataGridView1.Rows
                                        where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                        select Convert.ToDouble(row.Cells[3].Value)).Count().ToString());
                //************
            }
            else if (Convert.ToBoolean(dataGridView2.CurrentRow.Cells[1].Value) == false)
            {
                //******************
                txtSpValueBeforeall.Text = "";
                txtSpTrCollection.Text = "";
                //***************
                //********
                txtSpValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                       where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                       select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
                txtSpTrCollection.Text = (from DataGridViewRow row in dataGridView2.Rows
                                          where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                          select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

                //************
                Vlng_TreasuryCollectionID = long.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());
                var V_CountChq = FsDb.Tbl_BankCheques.Where(x => x.TreasuryCollectionID == Vlng_TreasuryCollectionID).ToList();
                if (V_CountChq.Count() != 0 && dataGridView1.RowCount > 0)
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        long VintTrCollectionCheq = long.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                        long Vlng_BnkChqID = long.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                        if (VintTrCollectionCheq == Vlng_TreasuryCollectionID)
                        {
                            dataGridView1.Rows[i].Cells[1].Value = false;

                        }

                    }

                }

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
                this.dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
            GetDataChequeBank5();
            GrdBnkCheq();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        bool isSelected = Convert.ToBoolean(row.Cells["Column1"].Value);
                        row.Cells["Column1"].Value = 1;

                    }
                }
                catch { }
            }
            else if (checkBox1.Checked == false)
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        bool isSelected = Convert.ToBoolean(row.Cells["Column1"].Value);
                        row.Cells["Column1"].Value = 0;

                    }
                }
                catch { }
            }
        }
        private void ClearData()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

        }
        private void simpleButton7_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 78 && w.ProcdureId == 1);
            if (validationSaveUser != null)
            {
                if (Vint_ChequeReceivedKindID == 1)
                {

                    int? Vint_BankDepositeId = 0;

                    int? Vint_BankAccId = 0;
                    int? Vint_ChequeReceivedKindID = null;
                    int? Vint_BranchID = 0;
                    int? Vint_RepresentiveID = null;
                    long? Vlng_LastIdTrCollection = 0;

                    string Vstr_CollectionNo = null;
                    ///**

                    DateTime? vdate_CollectionDate = null;
                    int Vint_FYear = int.Parse(comboBox3.SelectedValue.ToString());
                    DateTime Vdt_TodaySrv = Convert.ToDateTime(GetServerDate.Cs_GetServerDate());
                    var list = FsDb.Tbl_TreasuryCollection.Where(x => x.BranchID == 180 && x.FYear == Vint_FYear).ToList();

                    if (cmbBnkDeposit.SelectedValue == null || comboBox1.SelectedValue == null)
                    {
                        MessageBox.Show("من فضلك قم باختيار البنك المودع   ");

                        cmbBnkDeposit.Focus();
                    }
                    else if  (comboBox1.SelectedIndex == -1 )
                        { MessageBox.Show("من فضلك قم باختيار رقم الحساب الخاص بالبنك المودع"); comboBox1.Focus(); }

                    else
                    {
                        if (txtBranchID.Text != "")
                        { Vint_BranchID = int.Parse(txtBranchID.Text); }
                        if (cmbBnkDeposit.SelectedValue != null)
                        { Vint_BankDepositeId = int.Parse(cmbBnkDeposit.SelectedValue.ToString()); }
                        if (txtCollectionNo.Text != "")
                        { Vstr_CollectionNo = txtCollectionNo.Text; }
                        if (comboBox1.SelectedValue != null)
                        { Vint_BankAccId = int.Parse(comboBox1.SelectedValue.ToString()); }
                        if (txtRepresentiveID.Text != "") { Vint_RepresentiveID = int.Parse(txtRepresentiveID.Text); }
                        if (txtRowID.Text == "")
                        {
                            Tbl_TreasuryCollection tc = new Tbl_TreasuryCollection
                            {
                                BankDepositeID = Vint_BankDepositeId,
                                BankAccounNoID = Vint_BankAccId,
                                CollectionNo = Vstr_CollectionNo,
                                CollectionDate = Convert.ToDateTime(dTPCollection.Value.ToString()),
                                BranchID = Vint_BranchID,
                                RepresentiveID = Vint_RepresentiveID,
                                ChequeReceivedKindID = 0,
                                FYear = int.Parse(comboBox3.SelectedValue.ToString()),
                                IsDepositNo = false


                            };
                            FsDb.Tbl_TreasuryCollection.Add(tc);
                            FsDb.SaveChanges();
                            if (tc.ID.ToString() != null)
                            {
                                Vlng_LastIdTrCollection = long.Parse(tc.ID.ToString());
                                txtNewRowID.Text = tc.ID.ToString();
                            }
                            else
                            {
                                Vlng_LastIdTrCollection = null;
                            }
                        }
                        else if (txtRowID.Text != "")
                        {
                            Vlng_LastRowTreasuryCollection = long.Parse(txtRowID.Text);
                            var listTrCollection = FsDb.Tbl_TreasuryCollection.Where(x => x.ID == Vlng_LastRowTreasuryCollection && x.ChequeReceivedKindID == 0).ToList();
                            listTrCollection[0].BranchID = int.Parse(txtBranchID.Text);
                            listTrCollection[0].BankDepositeID = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                            listTrCollection[0].BankAccounNoID = int.Parse(comboBox1.SelectedValue.ToString());
                            listTrCollection[0].DepositDate = null;
                            listTrCollection[0].CollectionNo = txtCollectionNo.Text;
                            listTrCollection[0].CollectionDate = Convert.ToDateTime(dTPCollection.Value.ToString());
                            listTrCollection[0].BranchID = 180;
                            if (txtRepresentiveID.Text != "")
                            { listTrCollection[0].RepresentiveID = int.Parse(txtRepresentiveID.Text); }
                            listTrCollection[0].ChequeReceivedKindID = 0;
                            //listTrCollection[0].Parent_ID = Vlng_LastRowTreasuryCollection;
                            //FsDb.SaveChanges();
                        }
                        if (dataGridView1.Rows.Count > 0)
                        {
                            if (txtNewRowID.Text != "")
                            { Vlng_LastRowTreasuryCollection = long.Parse(txtNewRowID.Text); }
                            for (int i = 0; i < dataGridView2.Rows.Count; i++)
                            {
                                Vlng_TreasuryCollectionID = long.Parse(dataGridView2.Rows[i].Cells[4].Value.ToString());
                                var listTrCollection = FsDb.Tbl_TreasuryCollection.Where(x => x.ID == Vlng_TreasuryCollectionID && x.ChequeReceivedKindID == 1).ToList();
                                if (Convert.ToBoolean(dataGridView2.Rows[i].Cells[1].Value) == true)
                                {

                                    listTrCollection[0].BankDepositeID = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                                    listTrCollection[0].Parent_ID = Vlng_LastRowTreasuryCollection;
                                    FsDb.SaveChanges();
                                    long? Vlng_ChqBnkID = 0;
                                    long? Vlng_trCollBnkCheq = 0;

                                    for (int j = 0; j < dataGridView1.Rows.Count; j++)
                                    {

                                        Vlng_ChqBnkID = long.Parse(dataGridView1.Rows[j].Cells[2].Value.ToString());
                                        Vlng_trCollBnkCheq = long.Parse(dataGridView1.Rows[j].Cells[3].Value.ToString());

                                        var listBankCheq = FsDb.Tbl_BankCheques.Where(x => x.ID == Vlng_ChqBnkID).ToList();

                                        if (listBankCheq[0].TreasuryCollectionID == Vlng_trCollBnkCheq)
                                        {
                                            if (Convert.ToBoolean(dataGridView1.Rows[j].Cells[1].Value) == true && Convert.ToBoolean(dataGridView1.Rows[j].Cells[13].Value) == true)
                                            {

                                                listBankCheq[0].IsDepositNo = true;
                                                FsDb.SaveChanges();
                                            }
                                            if (Convert.ToBoolean(dataGridView1.Rows[j].Cells[1].Value) == false)
                                            {
                                                listBankCheq[0].IsDepositNo = false;
                                                FsDb.SaveChanges();
                                            }
                                        }
                                    }
                                }

                            }

                            MessageBox.Show($"تم حفظ  حافظة الخزينه الرئيسيه وشيكات الجهات يوم {dTPCollection.Value.ToString("dd/MM/yyyy")}");
                            for (int i = 0; i < dataGridView1.RowCount; i++)
                            {


                                dataGridView1.Rows[i].Cells[13].Value = false;


                                //dataGridView1.Refresh();
                            }
                            DateTime Vdt_Collection = Convert.ToDateTime(dTPCollection.Value.ToString());
                            ClearData();
                            ClearDataMaster();
                            dTPCollection.Value = Convert.ToDateTime(Vdt_Collection.ToString());
                            dTPCollection.Focus();

                        }
                        else
                        {
                            MessageBox.Show("من فضلك قم بتحديد الشيكات المراد ضمها ضمن حافظة الحزينه ");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية اضافة  حافظه خزينه .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[1].Value) == true)
            {
                txtSpValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                    where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                    select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
                txtCheqSpCount.Text = ((from DataGridViewRow row in dataGridView1.Rows
                                        where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                        select Convert.ToDouble(row.Cells[3].Value)).Count().ToString());

            }
            else if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[1].Value) == false)
            {
                txtSpValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                    where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                    select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
                txtCheqSpCount.Text = ((from DataGridViewRow row in dataGridView1.Rows
                                        where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                        select Convert.ToDouble(row.Cells[3].Value)).Count().ToString());

            }
        }

        private void cmbBnkDeposit_Leave(object sender, EventArgs e)
        {
            int? Vint_BankDepositeId = 0;
            if (cmbBnkDeposit.SelectedValue != null)
            {
                Vint_BankDepositeId = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                var listAccountBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_BankDepositeId && x.KindAccountBankID == 1).ToList();
                if (listAccountBank != null)

                {

                    if (listAccountBank.Count != 0)
                    {
                        txtAccountBnk.Text = listAccountBank[0].AccountBankNo;
                        if (listAccountBank.Count == 1)
                        {
                            txtAccountBnkID.Text = listAccountBank[0].ID.ToString();
                        }
                        else
                        {
                            txtAccountBnkID.Text = "";
                        }
                    }
                }
            }
        }

        private void dTPCollection_Leave(object sender, EventArgs e)
        {
            int? Vint_BranchID = 0;
            DateTime? vdate_CollectionDate = null;
            int Vint_FYear = int.Parse(comboBox3.SelectedValue.ToString());
            DateTime Vdt_TodaySrv = Convert.ToDateTime(GetServerDate.Cs_GetServerDate());
            var list = FsDb.Tbl_TreasuryCollection.Where(x => x.BranchID == 180 && x.FYear == Vint_FYear).ToList();
            if (list.Count != 0)
            {
                Vint_BranchID = 180;
                vdate_CollectionDate = Convert.ToDateTime(dTPCollection.Value.ToString());

                int Vint_CountBrunch = FsDb.Tbl_TreasuryCollection.Distinct().Where(x => x.FYear == Vint_FYear && x.BranchID == 180).Count();
                txtCollectionNo.Text = comboBox3.SelectedText + "/" + "180" + "/" + (Vint_CountBrunch + 1);
            }
            else
            {
                txtCollectionNo.Text = comboBox3.SelectedText + "/" + "180" + "/" + "1";
            }


            //***********استدعاء الحوافظ التي تم دمجها بحافظه الحزينه في هذا اليوم
            Grd3TrCollectionDrDep(Convert.ToDateTime(dTPCollection.Value.ToString("yyyy/MM/dd")), 1);
            groupBox1.Text = $"حوافظ الحزينه التي تم تحريرها في تاريخ  {dTPCollection.Value.ToString("yyyy/MM/dd")}";

            Grd3TrCollectionDrFalseDep();
            Grd4TRCollctionCheq();
            //****************
        }

        private void dTPCollection_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbBnkDeposit.Focus();
            }
        }

        private void cmbBnkDeposit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRepresentive.Focus();
            }
        }

        private void cmbBnkDeposit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbBnkDeposit.SelectedValue != null)
            {
                int? Vint_BankDepositeId = 0;
                Vint_BankDepositeId = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                var listAccountBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_BankDepositeId && x.KindAccountBankID == 1).ToList();
                if (listAccountBank != null)

                {
                    txtAccountBnkID.Text = "";

                    if (listAccountBank.Count != 0)
                    {
                        txtAccountBnk.Text = listAccountBank[0].AccountBankNo;
                        if (listAccountBank.Count == 1)
                        {
                            txtAccountBnkID.Text = listAccountBank[0].ID.ToString();
                        }
                        else
                        {
                            txtAccountBnkID.Text = "";
                        }
                    }
                }
            }
        }

        private void dataGridView4_MouseClick(object sender, MouseEventArgs e)
        {
            Vlng_TreasuryCollectionID = long.Parse(dataGridView4.CurrentRow.Cells[0].Value.ToString());
            var listTrcollection = (from TRC in FsDb.Tbl_TreasuryCollection
                                    join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                    join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                    where (TRC.ID == Vlng_TreasuryCollectionID)
                                    select new
                                    {
                                        ID = TRC.ID,
                                        BranchID = TRC.BranchID,
                                        BranchName = MNG.BrancheName,
                                        TradeCollectionNo = TRC.TradeCollectionNo,
                                        CollectionNo = TRC.CollectionNo,
                                        CollectionDate = TRC.CollectionDate,
                                        BankDepositeID = TRC.BankDepositeID,
                                        BankAccountID = TRC.BankAccounNoID,
                                        //BankAccName = BnkAcct.AccountBankNo,
                                        Name = BNK.Name,
                                        RepresentiveID = TRC.RepresentiveID,

                                        ReceiptNo = TRC.ReceiptNo

                                    }).OrderBy(x => x.ID).ToList();
            txtRowID.Text = listTrcollection[0].ID.ToString();
            txtBranchID.Text = listTrcollection[0].BranchID.ToString();
            txtCollectionNo.Text = listTrcollection[0].CollectionNo.ToString();
            dTPCollection.Value = Convert.ToDateTime(listTrcollection[0].CollectionDate.ToString());
            txtBnkDepositID.Text = listTrcollection[0].BankDepositeID.ToString();
            if (listTrcollection[0].RepresentiveID != null)
            {
                int vint_RepresentiveID = int.Parse(listTrcollection[0].RepresentiveID.ToString());
                txtRepresentiveID.Text = listTrcollection[0].RepresentiveID.ToString();
                var list = (from Reprs in FsDb.Tbl_Representatives
                            where (Reprs.ID == vint_RepresentiveID)
                            select new
                            { Reprs.Name }).ToList();
                txtRepresentive.Text = list[0].Name.ToString();
            }

            cmbBnkDeposit.SelectedValue = listTrcollection[0].BankDepositeID.ToString();
            txtBnkDeposit.Text = listTrcollection[0].Name;
            if (listTrcollection[0].BankAccountID != null)
            {
                int vint_bankAccountid = int.Parse(listTrcollection[0].BankAccountID.ToString());
                txtAccountBnkID.Text = listTrcollection[0].BankAccountID.ToString();
                var list = (from AccNo in FsDb.Tbl_AccountsBank
                            where (AccNo.ID == vint_bankAccountid)
                            select new
                            { AccNo.AccountBankNo }).ToList();
                txtAccountBnk.Text = list[0].AccountBankNo.ToString();

                var listAcc = FsDb.Tbl_AccountsBank.Where(x => x.ID == vint_bankAccountid).ToList();
                comboBox1.DataSource = listAcc;
                comboBox1.DisplayMember = "AccountBankNo";
                comboBox1.ValueMember = "ID";

                int Vint_AccBank = int.Parse(comboBox1.SelectedValue.ToString());
                var ListAcc = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_AccBank).ToList();
                int Vint_PAccBank = int.Parse(ListAcc[0].AccPurposeID.ToString());
                var ListPurpose = FsDb.Tbl_AccountsBankPurpose.Where(x => x.ID == Vint_PAccBank).ToList();
                comboBox2.DataSource = ListPurpose;
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "ID";
            }
            //***********استدعاء الحوافظ التي تم دمجها بحافظه الحزينه في هذا اليوم
            Grd4TrCollectionDrMain(Vlng_TreasuryCollectionID);
            ClearData();
            DgrTrCollectionRetr5();
            TotalChequeCollection();

            //****************
            //****************  عرض الحوافظ التي لم يتم دمجها بحافظ 

            DgrTrCollectionFalseDeposit();
            TotalChequeCollection();
            //************** مايتم عرضه من بيانات الحوافظ 

            GetDataChequeBank5();
            GrdTRCollctionCheq();
            //**********************
            

           
        }

        private void cmbBnkDeposit_Leave_1(object sender, EventArgs e)
        {
            if (cmbBnkDeposit.SelectedValue != null)
            {
                int? Vint_BankDepositeId = 0;
                Vint_BankDepositeId = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                var listAccountBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_BankDepositeId && x.KindAccountBankID == 1).ToList();
                if (listAccountBank != null)

                {
                    if (cmbBnkDeposit.SelectedValue != null)
                    {
                        Vint_BankDepositeId = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                        //*************ارقام الحسابات



                        var listAccBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_BankDepositeId).ToList();
                        comboBox1.DataSource = listAccBank;
                        comboBox1.DisplayMember = "AccountBankNo";
                        comboBox1.ValueMember = "ID";
                        int Vin_countItem = comboBox1.Items.Count;
                        if (comboBox1.Items.Count > 1)
                        {
                            comboBox1.SelectedIndex = -1;
                            comboBox1.Text = "اختر رقم الحساب";
                            comboBox1.Select();
                            this.ActiveControl = comboBox1;
                            comboBox1.Focus();
                        }
                        
                        //****************
                    }
                }
            }
        }

        private void cmbBnkDeposit_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
              int  Vint_BankDepositeId = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                //*************ارقام الحسابات



                var listAccBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_BankDepositeId).ToList();
                comboBox1.DataSource = listAccBank;
                comboBox1.DisplayMember = "AccountBankNo";
                comboBox1.ValueMember = "ID";
                int Vint_AccBank = int.Parse(listAccBank[0].AccPurposeID.ToString());
                var ListPurpose = FsDb.Tbl_AccountsBankPurpose.Where(x => x.ID == Vint_AccBank).ToList();
                comboBox2.DataSource = ListPurpose;
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "ID";

                int Vin_countItem = comboBox1.Items.Count;
                if (comboBox1.Items.Count > 1)
                {
                    comboBox1.SelectedIndex = -1;
                    comboBox1.Text = "اختر رقم الحساب";
                    comboBox1.Select();
                    this.ActiveControl = comboBox1;
                    comboBox1.Focus();
                }
                else
                {
                    txtRepresentive.Select();
                    this.ActiveControl = txtRepresentive;
                    txtRepresentive.Focus();
                }


                //****************
                
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            ClearDataMaster();

            dataGridView2.Rows.Clear();
            dataGridView1.Rows.Clear();
            checkData();
            Grd3TrCollectionDrDep(Convert.ToDateTime(Classes.GetServerDate.Cs_GetServerDate()), 1);
            //***********استدعاء الحوافظ التي لم يتم دمجها بحافظه
            Grd3TrCollectionDrFalseDep();
            Grd4TRCollctionCheq();
            //****************
            if (dataGridView2.Rows.Count == 0)
            { AddColumnDtaGrd2(); }
            //****************  عرض الحوافظ التي لم يتم دمجها بحافظ 

            DgrTrCollectionFalseDeposit();
            TotalChequeCollection();
            //************** مايتم عرضه من بيانات الحوافظ 
            GrdTRCollctionCheq();

            dTPCollection.Select();
            this.ActiveControl = dTPCollection;
            dTPCollection.Focus();
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                int Vint_AccBank = int.Parse(comboBox1.SelectedValue.ToString());
                var ListAcc = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_AccBank).ToList();
                int Vint_PAccBank = int.Parse(ListAcc[0].AccPurposeID.ToString());
                var ListPurpose = FsDb.Tbl_AccountsBankPurpose.Where(x => x.ID == Vint_PAccBank).ToList();
                comboBox2.DataSource = ListPurpose;
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "ID";
            }
        }

        private void comboBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRepresentive.Focus();
            }
        }
    }
}
