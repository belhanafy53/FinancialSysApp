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
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraPdfViewer.Bars;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;

namespace FinancialSysApp.Forms.Banks
{
    public partial class AuditingCheqFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int? Vint_BankDepositeId = 0;
        int? Vint_AccountBank = 0;
        int? Vint_BankAccId = 0;
        int? Vint_ChequeReceivedKindID = null;
        int? Vint_BranchID = 0;
        int? Vint_RepresentiveID = null;
        int? Vint_BankDrawnOnID = 0;
        int? Vint_CustID = null;
        string Vstr_CollectionNo = null;
        string Vstr_ChequeNO;
        string Vstr_ReceiptNO;
        string Vstr_TradeCollectionNO;
        long? Vlng_LastRowTreasuryCollection = 0;
        DateTime? vdate_CollectionDate = null;
        long VLng_IDMasterRow = 0;
        decimal Vdc_AmountCheque = 0;
        DateTime? Vdate_ChequeDueDate = null;
        int? Vint_CheckRowID = null;
        int? Vint_DgCount = 0;
        Boolean? Vbl_RestrictionDataID = false;
        int? Vint_TrCollectionID = 0;
        long? vlng_bankCheqID = 0;
        string Image_Path = "";

        public AuditingCheqFrm()
        {
            InitializeComponent();
        }
        private void TotalChequeCollection()
        {



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
            txtAllValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                    select Convert.ToDouble(row.Cells[2].Value)).Sum(), 3).ToString();
            textBox5.Text = (from DataGridViewRow row in dataGridView2.Rows
                             select Convert.ToDouble(row.Cells[1].Value)).Sum().ToString();
        }
        private void GrdTRCollctionCheq()
        {
            if (Vint_ChequeReceivedKindID == 0)
            {
                dataGridView2.Columns["ID"].Visible = false;
                dataGridView2.Columns["BranchID"].Visible = false;
                dataGridView2.Columns["BankDepositeID"].Visible = false;
                dataGridView2.Columns["RepresentiveID"].Visible = false;
                //dataGridView2.Columns["BankAccName"].Visible = false;
                dataGridView2.Columns["BankAccountID"].Visible = false;
                dataGridView2.Columns["ReceiptNo"].Visible = false;
                //dataGridView2.Columns["TradeCollectionNo"].Visible = true;

                dataGridView2.Columns["Name"].Width = 250;
                dataGridView2.Columns["Name"].HeaderText = "البنك";

                dataGridView2.Columns["BranchName"].HeaderText = "الفرع / الجهه";
                dataGridView2.Columns["BranchName"].Width = 120;
                dataGridView2.Columns["TradeCollectionNo"].HeaderText = "رقم الحافظه بالتجاري";
                dataGridView2.Columns["CollectionNo"].HeaderText = "رقم الحافظه";
                dataGridView2.Columns["CollectionDate"].HeaderText = "تاريخ الحافظه";
                dataGridView2.Columns["CollectionDate"].DefaultCellStyle.Format = "yyyy/MM/dd";
                dataGridView2.Columns["CollectionNo"].Width = 150;
                dataGridView2.Columns["CountChq"].Width = 50;
                dataGridView2.Columns["TotalAmountChq"].Width = 150;
                dataGridView2.Columns["TradeCollectionNo"].Width = 60;
                //dataGridView2.Columns["RepresentiveName"].HeaderText = "مندوب الخزينه";
            }
            else if (Vint_ChequeReceivedKindID == 1)
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
                dataGridView2.Columns["CollectionDate"].DefaultCellStyle.Format = "yyyy/MM/dd";
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
        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //ClearDataMaster();
                //ClearDataDetails();
                //textBox6.Text = "";
                //textBox7.Text = "";
                dataGridView1.DataSource = null;
                vdate_CollectionDate = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy/MM/dd"));
                if (Vint_ChequeReceivedKindID == 0)
                {
                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID

                                where (TRC.ChequeReceivedKindID == Vint_ChequeReceivedKindID && TRC.CollectionDate == vdate_CollectionDate)
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
                                    Name = BNK.Name,
                                    RepresentiveID = TRC.RepresentiveID,
                                    DepositDate = TRC.DepositDate,
                                    ReceiptNo = TRC.ReceiptNo,

                                }).OrderBy(x => x.BranchID).ToList();
                    dataGridView2.DataSource = list;
                    if (list.Count > 0)
                    {
                        TotalChequeCollection();
                        LoadSerial2();
                        GrdTRCollctionCheq();

                        txtAllValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                                select Convert.ToDouble(row.Cells[2].Value)).Sum(), 3).ToString();
                        textBox5.Text = (from DataGridViewRow row in dataGridView2.Rows
                                         select Convert.ToDouble(row.Cells[1].Value)).Sum().ToString();


                    }
                }
                else if (Vint_ChequeReceivedKindID == 1)
                {
                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                where (TRC.ChequeReceivedKindID == Vint_ChequeReceivedKindID && TRC.CollectionDate == vdate_CollectionDate)
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

                                    ReceiptNo = TRC.ReceiptNo,
                                    RepresentiveID = TRC.RepresentiveID,

                                }).OrderBy(x => x.ID).Take(30).ToList();
                    dataGridView2.DataSource = list;
                    if (list.Count > 0)
                    {
                        TotalChequeCollection();
                        //LoadSerial2();
                        //GrdTRCollctionCheq();
                        txtAllValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                                select Convert.ToDouble(row.Cells[2].Value)).Sum(), 3).ToString();
                        textBox5.Text = (from DataGridViewRow row in dataGridView2.Rows
                                         select Convert.ToDouble(row.Cells[1].Value)).Sum().ToString();
                    }

                }
            }
        }

        private void AuditingCheqFrm_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Focus();
            this.ActiveControl = dateTimePicker1;
            Vint_ChequeReceivedKindID = 0;
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex==0)
            {
                Vint_ChequeReceivedKindID = 0;
            }
            else if (comboBox1.SelectedIndex==1)
            {
                Vint_ChequeReceivedKindID = 1;
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    Vint_ChequeReceivedKindID = 0;
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    Vint_ChequeReceivedKindID = 1;
                }

            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //ClearDataMaster();
                //ClearDataDetails();
                //textBox6.Text = "";
                //textBox7.Text = "";
                dataGridView1.DataSource = null;
                vdate_CollectionDate = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy/MM/dd"));
                if (Vint_ChequeReceivedKindID == 0)
                {
                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID

                                where (TRC.ChequeReceivedKindID == Vint_ChequeReceivedKindID && TRC.CollectionNo == textBox11.Text)
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
                                    Name = BNK.Name,
                                    RepresentiveID = TRC.RepresentiveID,
                                    DepositDate = TRC.DepositDate,
                                    ReceiptNo = TRC.ReceiptNo,

                                }).OrderBy(x => x.BranchID).ToList();
                    dataGridView2.DataSource = list;
                    if (list.Count > 0)
                    {
                        TotalChequeCollection();
                        LoadSerial2();
                        GrdTRCollctionCheq();

                        txtAllValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                                select Convert.ToDouble(row.Cells[2].Value)).Sum(), 3).ToString();
                        textBox5.Text = (from DataGridViewRow row in dataGridView2.Rows
                                         select Convert.ToDouble(row.Cells[1].Value)).Sum().ToString();


                    }
                }
                else if (Vint_ChequeReceivedKindID == 1)
                {
                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                where (TRC.ChequeReceivedKindID == Vint_ChequeReceivedKindID && TRC.CollectionNo == textBox11.Text)
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

                                    ReceiptNo = TRC.ReceiptNo,
                                    RepresentiveID = TRC.RepresentiveID,

                                }).OrderBy(x => x.ID).Take(30).ToList();
                    dataGridView2.DataSource = list;
                    if (list.Count > 0)
                    {
                        TotalChequeCollection();
                        LoadSerial2();
                        GrdTRCollctionCheq();
                        txtAllValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                                select Convert.ToDouble(row.Cells[2].Value)).Sum(), 3).ToString();
                        textBox5.Text = (from DataGridViewRow row in dataGridView2.Rows
                                         select Convert.ToDouble(row.Cells[1].Value)).Sum().ToString();
                    }

                }
            }
        }
        private void GrdBnkCheq()
        {


            int Vint_DgCount = dataGridView1.RowCount;
            if (Vint_DgCount != 0)
            {
                txtAllValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                     select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
                textBox3.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

            }
            dataGridView1.Columns["TreasuryCollectionID"].Visible = false;
            dataGridView1.Columns["AmountCheque"].Visible = true;
            dataGridView1.Columns["ID"].Visible = false;

            dataGridView1.Columns["BankDrawnOnID"].Visible = false;
            dataGridView1.Columns["ChequeNo"].Visible = true;

            dataGridView1.Columns["ChequeDueDate"].Visible = true;
            dataGridView1.Columns["ChequeDueDate"].DefaultCellStyle.Format = "yyyy/MM/dd";
            dataGridView1.Columns["DepositedByTrRepresntvID"].Visible = false;

            dataGridView1.Columns["CustID"].Visible = false;
            dataGridView1.Columns["AddDateBank"].Visible = false;

            dataGridView1.Columns["ChequeKindID"].Visible = false;

            //dataGridView1.Columns["CustomerName"].Visible = false;
            dataGridView1.Columns["BankName"].Visible = true;
            dataGridView1.Columns["BankName"].Width = 200;
            //dataGridView1.Columns["Tbl_ChequeKindID"].Visible = true;
            //dataGridView1.Columns["Tbl_TreasuryCollection"].Visible = true;

            dataGridView1.Columns["AmountCheque"].HeaderText = "مبلغ الشيك";
            dataGridView1.Columns["AmountCheque"].Width = 120;

            dataGridView1.Columns["ChequeDueDate"].HeaderText = "تاريخ الشيك";
            dataGridView1.Columns["ChequeNo"].HeaderText = "رقم الشيك";

            //dataGridView1.Columns["CustomerName"].HeaderText = "العميل";
            dataGridView1.Columns["BankName"].HeaderText = "البنك";



        }
        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            //ClearDataMaster();
            //txtAllValueBeforeall.Text = "";
            //textBox5.Text = "";
            //textBox4.Text = "";
            //textBox6.Text = "";
            //textBox7.Text = "";

            if (dataGridView2.CurrentRow.Cells[3].Value != null)
            {
                //txtRowID.Text = "";
                dataGridView2.Columns["ID"].Visible = true;
                DataGridViewRow currentRow = dataGridView2.CurrentRow;
                if (currentRow != null)
                {
                    // Assuming you want to get the value of the  cell 3 in the current row
                    object cellValue = currentRow.Cells[3].Value;

                    if (cellValue != null)
                    {
                        txtRowID.Text = cellValue.ToString();
                        Vlng_LastRowTreasuryCollection = long.Parse(cellValue.ToString());

                    }
                    else
                    {

                    }
                }
                dataGridView2.Columns["ID"].Visible = false;
                //************

                if (Vint_ChequeReceivedKindID == 0)
                {
                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                where (TRC.ID == Vlng_LastRowTreasuryCollection)
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
                                    AddRecievedDate = TRC.AddRecievedDate,
                                    Name = BNK.Name,
                                    RepresentiveID = TRC.RepresentiveID,
                                    DepositDate = TRC.DepositDate,
                                    ReceiptNo = TRC.ReceiptNo

                                }).OrderBy(x => x.ID).ToList();
                    dataGridView2.DataSource = list;
                    TotalChequeCollection();
                    LoadSerial2();
                   
                    Vint_BankDepositeId = int.Parse(list[0].BankDepositeID.ToString());
                   
                    int Vint_BankID = int.Parse(list[0].BankDepositeID.ToString());
                    int Vint_BankAccID = int.Parse(list[0].BankAccountID.ToString());

                    var listAcc = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_BankAccID).ToList();
                    //comboBox1.DataSource = listAcc;
                    //comboBox1.DisplayMember = "AccountBankNo";
                    //comboBox1.ValueMember = "ID";

                    //comboBox1.SelectedValue = Vint_BankAccID;
                    //comboBox1.Text = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_BankAccID).Select(x => x.AccountBankNo).FirstOrDefault();

                    //int Vint_AccBank = int.Parse(comboBox1.SelectedValue.ToString());
                    //var ListAcc = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_AccBank).ToList();
                    //int Vint_PAccBank = int.Parse(ListAcc[0].AccPurposeID.ToString());
                    //var ListPurpose = FsDb.Tbl_AccountsBankPurpose.Where(x => x.ID == Vint_PAccBank).ToList();
                 

                    //****************Refrences******User Enter Data ********عرض بيانات المستخدم الذي ادخل بيانات الخافظه وشيكات*

                    AccRstAuditSelect(Vlng_LastRowTreasuryCollection);
                    if (list[0].BranchID != 180)
                    {
                        var listCheck = FsDb.Tbl_BankCheques.FirstOrDefault(x => x.TreasuryCollectionID == Vlng_LastRowTreasuryCollection);
                        int Vint_bankCheq = int.Parse(listCheck.ID.ToString());
                        var ListAccRstAudit = FsEvDb.SecurityEvents.Where(x => x.TableRecordId == Vlng_LastRowTreasuryCollection.ToString() && x.TableName == "Tbl_TreasuryCollection").Distinct().ToList();
                    }

                   
                }
                else if (Vint_ChequeReceivedKindID == 1) //*******************شيكات المتنوع
                {
                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                    //join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                //join Rpsntv in FsDb.Tbl_Representatives on TRC.RepresentiveID equals Rpsntv.ID
                                //join BnkAcct in FsDb.Tbl_AccountsBank on TRC.BankAccounNoID equals BnkAcct.ID
                                where (TRC.ID == Vlng_LastRowTreasuryCollection)
                                select new
                                {
                                    ID = TRC.ID,
                                    BranchID = TRC.BranchID,
                                    BranchName = MNG.BrancheName,
                                    TradeCollectionNo = TRC.TradeCollectionNo,
                                    CollectionDate = TRC.CollectionDate,
                                    RepresentiveID = TRC.RepresentiveID,
                                    AddRecievedDate = TRC.AddRecievedDate,
                                    CollectionNo = TRC.CollectionNo,

                                    ReceiptNo = TRC.ReceiptNo,
                                }).OrderBy(x => x.ID).ToList();
                    dataGridView2.DataSource = list;
                    TotalChequeCollection();
                    LoadSerial2();
                    txtRowID.Text = list[0].ID.ToString();
                    

                    //****************Refrences******User Enter Data *********

                    AccRstAuditSelect(Vlng_LastRowTreasuryCollection);
                    var ListAccRstAudit = FsEvDb.SecurityEvents.Where(x => x.TableRecordId == Vlng_LastRowTreasuryCollection.ToString() && x.TableName == "Tbl_BankCheques").Distinct().ToList();

                    string Vstr_UserAddR = "";
                    int WCount = int.Parse(ListAccRstAudit.Count.ToString());
                    for (int i = 0; i <= WCount - 1; i++)
                    {
                        Vstr_UserAddR = Vstr_UserAddR + " / " + ListAccRstAudit[i].EmployeeName;
                    }
                    textBox1.Text = Vstr_UserAddR;
                    //*************
                }

                //*********************  عرض بيانات الشيكات الخاصه بالحافظه

                var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                     join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                     join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                     //join Cust in FsDb.Tbl_Customer on BnkChq.CustID equals Cust.ID
                                     where (TRC.ID == Vlng_LastRowTreasuryCollection)
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
                                         ChequeKindID = BnkChq.ChequeKindID,
                                         //CustomerName = Cust.Name,
                                         BankName = BNK.Name,
                                         ChequeStatusID = BnkChq.ChequeStatusID

                                     }).OrderBy(x => x.ID).ToList();

                if (listBnkCheque != null)
                {
                    dataGridView1.DataSource = listBnkCheque;
                    ChaeqDataBankChequeAudit();

                    
                    GrdBnkCheq();
                    //****************Refrences******User Enter Data *********

                    AccRstAuditSelect(Vlng_LastRowTreasuryCollection);
                    var ListAccRstAudit = FsEvDb.SecurityEvents.Where(x => x.TableRecordId == Vlng_LastRowTreasuryCollection.ToString() && x.TableName == "Tbl_TreasuryCollection").Select(P=>P.EmployeeName).Distinct().ToList();

                    string Vstr_UserAddR = ListAccRstAudit.FirstOrDefault();
                    //int WCount = int.Parse(ListAccRstAudit.Count.ToString());
                    //for (int i = 0; i <= WCount - 1; i++)
                    //{
                    //    //Vstr_UserAddR = Vstr_UserAddR + " / " + ListAccRstAudit[i].EmployeeName;
                    //}
                    textBox1.Text = Vstr_UserAddR;
                    //*************

                }

            }
        }
        private void ChaeqDataBankChequeAudit()
        {
            Vlng_LastRowTreasuryCollection = long.Parse(txtRowID.Text);
            var listCheqAudit = FsDb.Tbl_TreasuryCollection_Audit.Where(x => x.TreasuryCollectionID == Vlng_LastRowTreasuryCollection).ToList();


            //******************************
            if (listCheqAudit.Count != 0)
            {
                long Vlng_CheckID = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    Vlng_CheckID = long.Parse(row.Cells["ID"].Value.ToString());
                    var listCheqAuditBR = FsDb.Tbl_TreasuryCollection_Audit.Where(x => x.BankCheqeID == Vlng_CheckID).ToList();

                    if (listCheqAuditBR.Count != 0 && listCheqAuditBR.Where(x => x.Note == "" || x.Note == null).Count() == listCheqAuditBR.Count)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else if (listCheqAuditBR.Count != 0 && listCheqAuditBR.Where(x => x.Note != "" || x.Note != null).Count() > 0)

                    {
                        row.DefaultCellStyle.BackColor = Color.PaleVioletRed;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }

                }
            }
        }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                txtRowID.Text = dataGridView1.CurrentRow.Cells["TreasuryCollectionID"].Value.ToString();
                int Vint_trC = int.Parse(txtRowID.Text);
                if (Vint_ChequeReceivedKindID == 0)
                {

                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                where (TRC.ID == Vint_trC)
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
                    txtBranchID.Text = list[0].BranchID.ToString();
                    //cmbBnkDeposit.SelectedValue = int.Parse(list[0].BankDepositeID.ToString());
                    //txtBnkDepositID.Text = list[0].BankDepositeID.ToString();
                    //txtAccountBnkID.Text = list[0].BankAccountID.ToString();


                    //if (list[0].RepresentiveID != null)
                    //{ txtRepresentiveID.Text = list[0].RepresentiveID.ToString(); }

                }
                else if (Vint_ChequeReceivedKindID == 1)
                {
                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                    //join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                //join Rpsntv in FsDb.Tbl_Representatives on TRC.RepresentiveID equals Rpsntv.ID
                                //join BnkAcct in FsDb.Tbl_AccountsBank on TRC.BankAccounNoID equals BnkAcct.ID
                                where (TRC.ID == Vlng_LastRowTreasuryCollection)
                                select new
                                {
                                    ID = TRC.ID,
                                    BranchID = TRC.BranchID,
                                    BranchName = MNG.BrancheName,
                                    TradeCollectionNo = TRC.TradeCollectionNo,
                                    CollectionDate = TRC.CollectionDate,
                                    RepresentiveID = TRC.RepresentiveID,
                                    AddRecievedDate = TRC.AddRecievedDate,
                                    CollectionNo = TRC.CollectionNo,

                                    ReceiptNo = TRC.ReceiptNo,
                                }).OrderBy(x => x.ID).ToList();


                    txtBranchID.Text = list[0].BranchID.ToString();

                }
                txtRowChequeID.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();

                if (txtRowChequeID.Text != "")
                {
                    //textBox9.Text = "";
                    Vint_TrCollectionID = int.Parse(txtRowID.Text);

                    Vint_CheckRowID = int.Parse(txtRowChequeID.Text);
                    var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                         join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                         join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                         //join Cust in FsDb.Tbl_Customer on BnkChq.CustID equals Cust.ID
                                         where (BnkChq.ID == Vint_CheckRowID)
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
                                             ChequeKindID = BnkChq.ChequeKindID,
                                             //CustomerName = Cust.Name,
                                             BankName = BNK.Name

                                         }).OrderBy(x => x.ChequeDueDate).ToList();
                    //txtAmount.Text = listBnkCheque[0].AmountCheque.ToString();
                    txtAmountScan.Text = listBnkCheque[0].AmountCheque.ToString();
                    //txtBankDrawnOn.Text = listBnkCheque[0].BankName.ToString();
                    txtBankDrawnOnScan.Text = listBnkCheque[0].BankName.ToString();
                    txtBankDrawnOnID.Text = listBnkCheque[0].BankDrawnOnID.ToString();
                    //txtChequeNo.Text = listBnkCheque[0].ChequeNo.ToString();
                    txtChequeNoScan.Text = listBnkCheque[0].ChequeNo.ToString();
                    //dTPDueDate.Value = Convert.ToDateTime(listBnkCheque[0].ChequeDueDate.Value.ToString());
                    dTPDueDateScan.Value = Convert.ToDateTime(listBnkCheque[0].ChequeDueDate.Value.ToString());
                    //txtCustID.Text = listBnkCheque[0].CustID.ToString();
                    //if (txtCustID.Text != "")
                    //{
                    //    Vint_CustID = int.Parse(txtCustID.Text);
                    //    var listCustName = FsDb.Tbl_Customer.FirstOrDefault(t => t.ID == Vint_CustID);
                    //    txtCust.Text = listCustName.Name;
                    //}
                    textBox2.Text = "";
                    txtNotCheqAudit.Text = "";
                    chckBxBasicData.Checked = false;
                    //****************Refrences***************
                    AccRstAuditSelect(Vint_CheckRowID);
                    //***************************************
                    var listImageCheq = FsEvDb.Tbl_ArchTrCollectioCheque.Where(x => x.ChequeBankID == Vint_CheckRowID).Distinct().ToList();
                    if (listImageCheq.Count != 0)
                    {
                        try
                        {
                            long Vlng_ID = long.Parse(txtRowChequeID.Text);
                            var listArchCheq = FsEvDb.Tbl_ArchTrCollectioCheque.FirstOrDefault(x => x.ChequeBankID == Vlng_ID);
                            if (listArchCheq.PathFile != "")
                            {
                                if (listArchCheq.PathFile.ToLower().EndsWith(".pdf")) // Check if the file is a PDF
                                {
                                    pdfViewer1.DocumentFilePath = listArchCheq.PathFile;
                                    pdfViewer1.Visible = true;
                                    //simpleButton1.Visible = true;
                                    //simpleButton2.Visible = false;
                                    pictureBox1.Visible = false;
                                    pdfCommandBar1.Visible = true;
                                }
                                else // Assume it's an image
                                {
                                    pictureBox1.ImageLocation = listArchCheq.PathFile;
                                    pictureBox1.Visible = true;
                                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                                    //pictureBox1.MouseWheel += picturebox1_MouseWheel;
                                    //simpleButton2.Visible = true;
                                    //simpleButton1.Visible = false;
                                    pdfViewer1.Visible = false;
                                    pdfCommandBar1.Visible = false;

                                }
                            }
                        }
                        catch
                        {
                        }
                        finally
                        {
                            // Hide the PictureBox or PdfViewer if no file was loaded
                            if (pictureBox1.ImageLocation == null)
                            {
                                pictureBox1.Visible = false;
                                //simpleButton1.Visible = true;
                                //simpleButton2.Visible = false;
                            }
                            if (pdfViewer1.DocumentFilePath == null)
                            {
                                pdfViewer1.Visible = false;
                                //simpleButton2.Visible = true;
                                //simpleButton1.Visible = false;
                            }
                        }
                    }
                    else
                    {
                       
                    }

                }
            }
        }
     
        private void AccRstAuditSelect(long? Vlng_BankCheqID)
        {

            var ListAccRstAuditTreaDuryCUser = FsDb.Tbl_TreasuryCollection_Audit.OrderByDescending(e => e.ID).FirstOrDefault(x => x.BankCheqeID == Vlng_BankCheqID);
            if (ListAccRstAuditTreaDuryCUser != null)
            {
                if (ListAccRstAuditTreaDuryCUser.IsCheqBank == true && ListAccRstAuditTreaDuryCUser.Note == "")
                {
                    chckBxBasicData.Checked = true;
                    if (ListAccRstAuditTreaDuryCUser.Note != null)
                    {
                        cmbNote.Text = "";
                        cmbNote.SelectedItem = ListAccRstAuditTreaDuryCUser.Note;
                    }
                }
                else
                {
                    chckBxBasicData.Checked = false;
                    if (ListAccRstAuditTreaDuryCUser.Note != null)
                    {
                        cmbNote.Text = "";
                        cmbNote.SelectedText = ListAccRstAuditTreaDuryCUser.Note;
                    }
                }
            }
            var ListAccTrCAudit = (from TrCoA in FsDb.Tbl_TreasuryCollection_Audit
                                   join usr in FsDb.Tbl_User on TrCoA.UserID equals usr.ID
                                   join emp in FsDb.Tbl_Employee on usr.Employee_id equals emp.ID
                                   where (TrCoA.BankCheqeID == Vlng_BankCheqID)
                                   select new
                                   {
                                       EmpName = emp.Name
                                   }).Distinct().ToList();
            if (ListAccTrCAudit != null)
            {
                string Vstr_RefrencesOrder = "";
                int WCount = int.Parse(ListAccTrCAudit.Count.ToString());
                for (int i = 0; i <= WCount - 1; i++)
                {
                    Vstr_RefrencesOrder = ListAccTrCAudit[i].EmpName + " / " + Vstr_RefrencesOrder;
                }
                textBox2.Text = Vstr_RefrencesOrder;
            }
            else
            {
                textBox2.Text = "";
                txtNotCheqAudit.Text = "";
                cmbNote.SelectedText = "";
            }
        }
        private void chckBxBasicData_MouseClick(object sender, MouseEventArgs e)
        {

            if (txtRowChequeID.Text != "")
            {
                Vlng_LastRowTreasuryCollection = long.Parse(txtRowID.Text);
                vlng_bankCheqID = long.Parse(txtRowChequeID.Text);
                bool Vbl_TrcollectioCheq = false;
                bool Vbl_BankCheq = false;
                bool vbl_update = false;
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 85 && w.ProcdureId == 1003);
                if (validationSaveUser != null)
                {
                    DateTime? Vd_UpDateTime = null;
                    string Vstr_Note = "";
                    if (cmbNote.SelectedItem != null)
                    { Vstr_Note = cmbNote.SelectedItem.ToString(); }
                    else
                    { Vstr_Note = ""; }

                    Vbl_BankCheq = true;
                    Vbl_TrcollectioCheq = true;
                    var ListTrcAuditOrdUser = FsDb.Tbl_TreasuryCollection_Audit.FirstOrDefault(x => x.BankCheqeID == vlng_bankCheqID && x.UserID == Program.GlbV_UserId);
                    if (ListTrcAuditOrdUser == null)

                    {
                        if (chckBxBasicData.Checked == true && Vstr_Note == "")
                        {
                            Vbl_RestrictionDataID = true;
                            Vbl_BankCheq = true;
                             
                        }
                        else
                        {
                            Vbl_RestrictionDataID = false;
                            Vbl_BankCheq = false;
                            Vd_UpDateTime = null;
                            vbl_update = false;
                        }
                        DateTime Vdt_Today = Convert.ToDateTime(Classes.GetServerDate.Cs_GetServerDate());
                        Tbl_TreasuryCollection_Audit AccRstAud = new Tbl_TreasuryCollection_Audit
                        {
                            UserID = Program.GlbV_UserId,
                            TreasuryCollectionID = Vlng_LastRowTreasuryCollection,
                            BankCheqeID = vlng_bankCheqID,
                            IsTrcollection = Vbl_TrcollectioCheq,
                            IsCheqBank = Vbl_BankCheq,
                            ReferenceDate = Vdt_Today,
                            Note = Vstr_Note,
                            NoteAdd = Vstr_Note,
                            UpdateDate = Vd_UpDateTime,
                            IsUpdate = vbl_update
                        };
                        FsDb.Tbl_TreasuryCollection_Audit.Add(AccRstAud);
                        FsDb.SaveChanges();

                        int Vint_LastRow = AccRstAud.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة مراجعة شيكات",
                            TableName = "Tbl_TreasuryCollection_Audit",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Classes.GetServerDate.Cs_GetServerDate()),
                            //ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة مراجعة الشيكات"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم الحفظ");
                        //****************Refrences***************
                        AccRstAuditSelect(vlng_bankCheqID);

                        ChaeqDataBankChequeAudit();
                        //***************************************
                    }
                    else
                    {

                        if (chckBxBasicData.Checked == true && Vstr_Note == "")
                        {
                            Vbl_RestrictionDataID = true;
                            Vbl_BankCheq = true;
                        }
                        else
                        {
                            Vbl_RestrictionDataID = false;
                            Vbl_BankCheq = false;
                            Vd_UpDateTime = null;
                        }
                        DateTime Vdt_Today = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));

                        var ListOrderAuditOrdUsero = FsDb.Tbl_TreasuryCollection_Audit.FirstOrDefault(x => x.BankCheqeID == vlng_bankCheqID && x.UserID == Program.GlbV_UserId);
                        ListOrderAuditOrdUsero.IsTrcollection = Vbl_RestrictionDataID;
                        ListOrderAuditOrdUsero.IsCheqBank = Vbl_BankCheq;
                        if (Vstr_Note == "")
                        {
                            var ListOrderAuditOrdUseroN = FsDb.Tbl_TreasuryCollection_Audit.Where(x => x.BankCheqeID == vlng_bankCheqID).ToList();
                            foreach (var v in ListOrderAuditOrdUseroN)
                            {
                                v.Note = Vstr_Note;
                                FsDb.SaveChanges();
                            }

                        }
                        else
                        {
                            ListOrderAuditOrdUsero.Note = Vstr_Note;
                        }
                        ListOrderAuditOrdUsero.NoteAdd = Vstr_Note;
                        ListOrderAuditOrdUsero.ReferenceDate = Vdt_Today;
                        FsDb.SaveChanges();
                        MessageBox.Show("تم التعديل");
                        //****************Refrences***************
                        AccRstAuditSelect(vlng_bankCheqID);

                        ChaeqDataBankChequeAudit();
                        //***************************************

                    }

                }

                else
                {
                    MessageBox.Show("ليس لديك صلاحية  مراجعه الشيكات .. برجاء مراجعة مدير المنظومه");
                    chckBxBasicData.Checked = false;
                }
            }
            else
            {
                MessageBox.Show(" من فضلك قم بإختيار الشيك المراد مراجعته اولا");
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //ClearDataMaster();
                //ClearDataDetails();
                //textBox6.Text = "";
                //textBox7.Text = "";
                dataGridView1.DataSource = null;
                vdate_CollectionDate = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy/MM/dd"));
                if (Vint_ChequeReceivedKindID == 0)
                {
                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID

                                where (TRC.ChequeReceivedKindID == Vint_ChequeReceivedKindID && TRC.TradeCollectionNo == textBox4.Text)
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
                                    Name = BNK.Name,
                                    RepresentiveID = TRC.RepresentiveID,
                                    DepositDate = TRC.DepositDate,
                                    ReceiptNo = TRC.ReceiptNo,

                                }).OrderBy(x => x.BranchID).ToList();
                    dataGridView2.DataSource = list;
                    if (list.Count > 0)
                    {
                        TotalChequeCollection();
                        LoadSerial2();
                        GrdTRCollctionCheq();

                        txtAllValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                                select Convert.ToDouble(row.Cells[2].Value)).Sum(), 3).ToString();
                        textBox5.Text = (from DataGridViewRow row in dataGridView2.Rows
                                         select Convert.ToDouble(row.Cells[1].Value)).Sum().ToString();


                    }
                }
                else if (Vint_ChequeReceivedKindID == 1)
                {
                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                where (TRC.ChequeReceivedKindID == Vint_ChequeReceivedKindID && TRC.TradeCollectionNo == textBox4.Text)
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

                                    ReceiptNo = TRC.ReceiptNo,
                                    RepresentiveID = TRC.RepresentiveID,

                                }).OrderBy(x => x.ID).Take(30).ToList();
                    dataGridView2.DataSource = list;
                    if (list.Count > 0)
                    {
                        TotalChequeCollection();
                        LoadSerial2();
                        GrdTRCollctionCheq();
                        txtAllValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                                select Convert.ToDouble(row.Cells[2].Value)).Sum(), 3).ToString();
                        textBox5.Text = (from DataGridViewRow row in dataGridView2.Rows
                                         select Convert.ToDouble(row.Cells[1].Value)).Sum().ToString();
                    }

                }
            }
        }
    }
}
