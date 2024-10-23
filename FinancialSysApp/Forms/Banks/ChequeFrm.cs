using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WIA;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using FinancialSysApp.Forms.DocumentsForms;
using DevExpress.PivotGrid.PivotTable;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.CodeParser;
using System.Runtime.InteropServices;

using System.IO;
using DevExpress.Office.Drawing;
//using Tulpep.NotificationWindow;

namespace FinancialSysApp.Forms.Banks
{
    public partial class ChequeFrm : DevExpress.XtraEditors.XtraForm
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
        public ChequeFrm()
        {
            InitializeComponent();
            notifyIcon1.Icon = SystemIcons.Information; // Set icon for the notification
            notifyIcon1.Visible = true; // Make the notification icon visible
        }
        private void ShowNotification(string title, string message)
        {
            notifyIcon1.BalloonTipTitle = title;
            notifyIcon1.BalloonTipText = message;
            notifyIcon1.ShowBalloonTip(3000); // Display the notification for 3 seconds (3000 milliseconds)
        }
        private void LoadSerial()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = i; i++;
            }
        }
        private void LoadSerial3()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                row.Cells[0].Value = i; i++;
                LoopPaintRowDueSateNotFYear();
            }
        }
        private void LoopPaintRowDueSateNotFYear()
        {
            FinancialYearDueDate FinancialYearDueDate = new FinancialYearDueDate();
            DateTime Vd_DueDateCheq = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
            DateTime Vd_Today = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
            int Vint_ResultFYear = 0;
            int Vint_ResultToday = 0;
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {

                Vd_DueDateCheq = Convert.ToDateTime(row.Cells["ChequeDueDate"].Value.ToString());

                Vint_ResultFYear = FinancialYearDueDate.SelectFinancialYearDueDate(Vd_DueDateCheq);
                Vint_ResultToday = FinancialYearDueDate.SelectFinancialYearDueDate(Vd_Today);
                int Vint_ChequeStatusID = int.Parse(row.Cells["ChequeStatusID"].Value.ToString());
                if (Vint_ChequeStatusID == 4)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                if (Vint_ResultFYear > Vint_ResultToday)
                {
                    row.DefaultCellStyle.BackColor = Color.Black;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
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
        //*********************************
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
        //************************************
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
                            BranchName = MNG.BrancheName,
                            CollectionNo = TRC.CollectionNo,
                            CollectionDate = TRC.CollectionDate,
                            BankDepositeID = TRC.BankDepositeID,
                            BankAccountID = TRC.BankAccounNoID,
                            BankAccName = BnkAcct.AccountBankNo,
                            BanKName = BNK.Name,
                            RepresentiveID = TRC.RepresentiveID,
                            RepresentiveName = Rpsntv.Name
                        }).OrderBy(x => x.ID).ToList();
            dataGridView1.DataSource = list;
            LoadSerial();
            GrdBnkCheq();

        }

        private void GrdTrCollectionBr()
        {
            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        where (TRC.ChequeReceivedKindID == Vint_ChequeReceivedKindID && TRC.BranchID != 180)
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

                            ReceiptNo = TRC.ReceiptNo,
                            RepresentiveID = TRC.RepresentiveID,

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
        private void GrdBnkCheq3()
        {



            dataGridView3.Columns["TreasuryCollectionID"].Visible = false;
            dataGridView3.Columns["AmountCheque"].Visible = true;
            dataGridView3.Columns["ID"].Visible = false;

            dataGridView3.Columns["BankDrawnOnID"].Visible = false;
            dataGridView3.Columns["ChequeNo"].Visible = true;

            dataGridView3.Columns["ChequeDueDate"].Visible = true;
            dataGridView3.Columns["DepositedByTrRepresntvID"].Visible = false;

            dataGridView3.Columns["CustID"].Visible = false;
            dataGridView3.Columns["AddDateBank"].Visible = false;

            dataGridView3.Columns["ChequeKindID"].Visible = false;

            //dataGridView3.Columns["CustomerName"].Visible = false;
            dataGridView3.Columns["BankName"].Visible = true;
            dataGridView3.Columns["BankName"].Width = 200;
            //dataGridView3.Columns["Tbl_ChequeKindID"].Visible = true;
            //dataGridView3.Columns["Tbl_TreasuryCollection"].Visible = true;

            dataGridView3.Columns["AmountCheque"].HeaderText = "مبلغ الشيك";
            dataGridView3.Columns["AmountCheque"].Width = 120;

            dataGridView3.Columns["ChequeDueDate"].HeaderText = "تاريخ الشيك";
            dataGridView3.Columns["ChequeDueDate"].DefaultCellStyle.Format = "yyyy/MM/dd";
            dataGridView3.Columns["ChequeNo"].HeaderText = "رقم الشيك";

            //dataGridView3.Columns["CustomerName"].HeaderText = "العميل";
            dataGridView3.Columns["BankName"].HeaderText = "البنك";



        }
        private void checkData()
        {
            if (Vint_ChequeReceivedKindID == 0)
            {
                groupControl1.Text = "بيانات الحافظه";
                groupControl3.Text = "بيانات الحوافظ";
                groupControl4.Text = "بيانات شيكات الحوافظ";
                label11.Text = "الفرع";
                label30.Text = "بحث بالفرع";
                label2.Text = "رقم الحافظه";
                label3.Text = "تاريخ الحافظه";
                label2.Visible = true;
                label3.Visible = true;
                txtCollectionNo.Visible = true;
                dTPCollection.Visible = true;
                label4.Visible = true;
                txtBnkDeposit.Visible = false;
                comboBox1.Visible = true;
                label5.Visible = true;
                cmbAccountBank.Visible = false;
                simpleButton10.Visible = false;
                txtAccountBnk.Visible = true;
                label10.Visible = true;
                txtRepresentive.Visible = true;
                comboBox2.Visible = true;
                label17.Visible = true;
                txtTradeCollectionNO.Visible = true;

                lblReceiptNo.Visible = true;
                txtReceiptNo.Visible = true;

                //GrdTrCollectionBr();
            }
            else if (Vint_ChequeReceivedKindID == 1)
            {
                groupControl1.Text = "بيانات الجهه";
                groupControl3.Text = "بيانات مستندات الجهات";
                groupControl4.Text = "بيانات شيكات الجهات";
                label11.Text = "الجهه";
                label30.Text = " بحث بالجهه";
                label2.Text = "رقم المستند";
                label2.Visible = true;
                label3.Visible = true;
                label3.Text = "تاريخ المستند";
                simpleButton4.Text = "اضافة حافظه جديده";
                txtCollectionNo.Visible = true;
                dTPCollection.Visible = true;
                simpleButton10.Visible = true;
                label4.Visible = false;
                cmbBnkDeposit.Visible = false;
                comboBox1.Visible = false;
                txtBnkDeposit.Visible = false;
                label5.Visible = false;
                cmbAccountBank.Visible = false;
                label10.Visible = false;
                txtRepresentive.Visible = false;
                txtAccountBnk.Visible = false;
                label17.Visible = false;
                txtTradeCollectionNO.Visible = false;
                comboBox2.Visible = false;
                label20.Visible = false;

                lblReceiptNo.Visible = false;
                txtReceiptNo.Visible = false;
                //GrdTrCollectionDr();
            }
        }
        private void ClearDataMaster()
        {
            txtRowID.Text = "";
            txtBnkDepositID.Text = "";
            txtBnkDeposit.Text = "";
            chckBxBasicData.Checked = false;
            checkBox2.Checked = false;
            txtAccountBnkID.Text = "";
            cmbAccountBank.Text = "";
            txtAccountBnk.Text = "";
            comboBox1.Text = "";

            txtCollectionNo.Text = "";
            //dTPCollection.Value = Convert.ToDateTime(DateTime.Now.ToString());

            txtBranchID.Text = "";
            txtBranch.Text = "";

            txtRepresentiveID.Text = "";
            txtRepresentive.Text = "";

            txtTradeCollectionNO.Text = "";
            txtReceiptNo.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            txtNotCheqAudit.Text = "";
            cmbBnkDeposit.SelectedIndex = -1;
            cmbBnkDeposit.Text = "";
            maskedTextBox1.Text = "";
            textBox10.Text = "";
            simpleButton4.Text = "اضافة جهه جديده";
            cmbBnkDeposit.SelectedText = "اختر البنك المودع ";

            comboBox1.SelectedText = "اختر رقم الحساب";
            chckBxBasicData.Checked = false;
        }
        private void ClearDataDetails()
        {
            txtAmount.Text = "";
            txtRowChequeID.Text = "";

            txtBankDrawnOn.Text = "";
            txtBankDrawnOnID.Text = "";

            txtCust.Text = "";
            txtCustID.Text = "";

            txtAllValueBefore.Text = "";
            txtChequeNo.Text = "";

            textBox9.Text = "";

            dTPDueDate.Value = Convert.ToDateTime(DateTime.Now.ToString());
            dataGridView3.DataSource = null;

        }
        private void ChequeFrm_Load(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
            //*************معرفة الماسح المتاح 
            try
            {
                var deviceManager = new DeviceManager();

                for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++) // Loop Through the get List Of Devices.
                {
                    if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType) // Skip device If it is not a scanner
                    {
                        continue;
                    }
                    lstListOfScanner.Items.Add(deviceManager.DeviceInfos[i].Properties["Name"].get_Value());
                }
                if (lstListOfScanner.Items.Count != 0)
                {
                    btnScan.Enabled = true;
                    btnMultiScan.Enabled = true;
                }

            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
            }
            // TODO: This line of code loads data into the 'bankCheques1.Dtb_Banks' table. You can move, or remove it, as needed.
            this.dtb_BanksTableAdapter.FillByBanksWithAccount(this.bankCheques1.Dtb_Banks);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Fiscalyear' table. You can move, or remove it, as needed.
            this.tbl_FiscalyearTableAdapter1.FillByYear(this.financialSysDataSet.Tbl_Fiscalyear);
            // TODO: This line of code loads data into the 'dataSet1.Tbl_Fiscalyear' table. You can move, or remove it, as needed.
            //this.tbl_FiscalyearTableAdapter.Fill(this.dataSet1.Tbl_Fiscalyear);

            Vint_ChequeReceivedKindID = radioGroup1.SelectedIndex;
            checkData();
            txtRepresentive.SelectionLength = 0;

            cmbBnkDeposit.SelectedIndex = -1;
            cmbBnkDeposit.Text = "";
            cmbBnkDeposit.SelectedText = "اختر البنك المودع ";

            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "";
            comboBox1.Text = "اختر الحساب";


            textBox1.Text = "";
            textBox2.Text = "";
            txtNotCheqAudit.Text = "";
            chckBxBasicData.Checked = false;
            txtBranch.Select();
            this.ActiveControl = txtBranch;
            //ShowNotification("اخطاء", "توجد اخطاء بشيكات يوم.");
            //PopupNotifier popup = new PopupNotifier();
            //popup.Image = Properties.Resources.info;
            //popup.TitleText = "انتبه";
            //popup.ContentText = "توجد شيكات تم مراجعتها وتحتاج الى تعديلات !";
            //popup.Popup();//Show

            txtBranch.Focus();
        }

        private void txtBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                dTPCollection.Focus();

            }
            else if (e.KeyCode == Keys.Down)
            {
                if (Vint_ChequeReceivedKindID == 0)
                {
                    Forms.BasicCodeForms.FindBranchFrm t = new Forms.BasicCodeForms.FindBranchFrm();

                    t.ShowDialog();
                    if (Forms.BasicCodeForms.FindBranchFrm.SelectedRow != null)
                    {
                        txtBranch.Text = Forms.BasicCodeForms.FindBranchFrm.SelectedRow.Cells[1].Value.ToString();
                        txtBranchID.Text = Forms.BasicCodeForms.FindBranchFrm.SelectedRow.Cells[0].Value.ToString();
                        groupControl4.Text = $"حوافظ فرع {txtBranch.Text} ";

                        Vint_BranchID = int.Parse(txtBranchID.Text);
                        var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                    join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                    join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                    //join Rpsntv in FsDb.Tbl_Representatives on TRC.RepresentiveID equals Rpsntv.ID
                                    //join BnkAcct in FsDb.Tbl_AccountsBank on TRC.BankAccounNoID equals BnkAcct.ID
                                    where (TRC.BranchID == Vint_BranchID && TRC.ChequeReceivedKindID == 0)
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
                                        Name = BNK.Name,
                                        RepresentiveID = TRC.RepresentiveID,
                                        //RepresentiveName = Rpsntv.Name
                                    }).OrderByDescending(x => x.CollectionDate).ToList();
                        //*********************
                        dataGridView2.DataSource = list;

                        TotalChequeCollection();

                        LoadSerial2();
                        GrdTRCollctionCheq();
                    }
                    if (txtBranchID.Text != "")
                    {
                        dTPCollection.Select();
                        this.ActiveControl = dTPCollection;
                        dTPCollection.Focus();
                    }
                    else
                    {
                        txtBranch.Select();
                        this.ActiveControl = txtBranch;
                        txtBranch.Focus();
                    }
                }
                if (Vint_ChequeReceivedKindID == 1)
                {
                    Forms.BasicCodeForms.FindDirectionFrm t = new Forms.BasicCodeForms.FindDirectionFrm();

                    t.ShowDialog();
                    if (Forms.BasicCodeForms.FindDirectionFrm.SelectedRow != null)
                    {
                        txtBranch.Text = Forms.BasicCodeForms.FindDirectionFrm.SelectedRow.Cells[1].Value.ToString();
                        txtBranchID.Text = Forms.BasicCodeForms.FindDirectionFrm.SelectedRow.Cells[0].Value.ToString();
                        Vint_BranchID = int.Parse(txtBranchID.Text);
                        var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                    join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                    join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                    //join Rpsntv in FsDb.Tbl_Representatives on TRC.RepresentiveID equals Rpsntv.ID
                                    //join BnkAcct in FsDb.Tbl_AccountsBank on TRC.BankAccounNoID equals BnkAcct.ID
                                    where (TRC.BranchID == Vint_BranchID && TRC.ChequeReceivedKindID == 1)
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
                                        Name = BNK.Name,
                                        RepresentiveID = TRC.RepresentiveID,
                                        //RepresentiveName = Rpsntv.Name
                                    }).OrderBy(x => x.ID).ToList();
                        //*********************
                        dataGridView2.DataSource = list;
                        TotalChequeCollection();
                        LoadSerial2();
                        GrdTRCollctionCheq();

                        groupControl4.Text = $"مستندات  {txtBranch.Text} ";
                        dTPCollection.Select();
                        this.ActiveControl = dTPCollection;
                        dTPCollection.Focus();
                    }
                    if (txtBranchID.Text != "")
                    {
                        dTPCollection.Select();
                        this.ActiveControl = dTPCollection;
                        dTPCollection.Focus();
                    }
                    else
                    {
                        txtBranch.Select();
                        this.ActiveControl = txtBranch;
                        txtBranch.Focus();
                    }
                }
            }
        }

        private void dTPCollection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                vdate_CollectionDate = Convert.ToDateTime(dTPCollection.Value.ToString("yyyy/MM/dd"));
                if (Vint_ChequeReceivedKindID == 0)
                {
                    if (txtBranchID.Text != "")
                    {
                        Vint_BranchID = int.Parse(txtBranchID.Text);
                        var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                    join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                    join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                    //join Rpsntv in FsDb.Tbl_Representatives on TRC.RepresentiveID equals Rpsntv.ID
                                    //join BnkAcct in FsDb.Tbl_AccountsBank on TRC.BankAccounNoID equals BnkAcct.ID
                                    where (TRC.BranchID == Vint_BranchID && TRC.CollectionDate == vdate_CollectionDate && TRC.ChequeReceivedKindID == 0)
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

                                        ReceiptNo = TRC.ReceiptNo,
                                    }).OrderBy(x => x.ID).ToList();
                        //*********************
                        dataGridView2.DataSource = list;
                        TotalChequeCollection();
                        LoadSerial2();
                        GrdTRCollctionCheq();

                        groupControl4.Text = $"حوافظ فرع {txtBranch.Text} بتاريخ {dTPCollection.Value.ToString("yyyy/MM/dd")}";
                        dTPAddRecievedDate.Focus();
                    }
                }
                else if (Vint_ChequeReceivedKindID == 1)
                {
                    if (txtBranchID.Text != "")
                    {
                        Vint_BranchID = int.Parse(txtBranchID.Text);
                        var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                        //join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                    join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                    //join Rpsntv in FsDb.Tbl_Representatives on TRC.RepresentiveID equals Rpsntv.ID
                                    //join BnkAcct in FsDb.Tbl_AccountsBank on TRC.BankAccounNoID equals BnkAcct.ID
                                    where (TRC.BranchID == Vint_BranchID && TRC.CollectionDate == vdate_CollectionDate && TRC.ChequeReceivedKindID == 1)
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
                                        //Name = BNK.Name,
                                        RepresentiveID = TRC.RepresentiveID,

                                        ReceiptNo = TRC.ReceiptNo,
                                    }).OrderBy(x => x.ID).ToList();
                        //*********************
                        dataGridView2.DataSource = list;
                        TotalChequeCollection();
                        LoadSerial2();
                        GrdTRCollctionCheq();
                        groupControl4.Text = $"مستندات  {txtBranch.Text} بتاريخ {dTPCollection.Value.ToString("yyyy/MM/dd")}";
                        dTPAddRecievedDate.Focus();
                    }
                }
            }
        }

        private void txtCollectionNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                txtBnkDeposit.Focus();
            }
        }
        private void txtBnkDeposit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                txtRepresentive.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                Forms.BasicCodeForms.FindBanksFrm t = new Forms.BasicCodeForms.FindBanksFrm();
                t.ShowDialog();

                if (t.txtBankId != null)
                {
                    //txtBnkDeposit.Text = t.txtSelected.Text;
                    //txtBnkDepositID.Text = t.txtBankId.Text;
                    Vint_BankDepositeId = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                    if (Vint_ChequeReceivedKindID == 0)
                    {

                        var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                             join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                             join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                             //join Cust in FsDb.Tbl_Customer on BnkChq.CustID equals Cust.ID
                                             where (TRC.BranchID == Vint_BranchID && TRC.CollectionDate == vdate_CollectionDate && TRC.ChequeReceivedKindID == 0 && TRC.CollectionNo == txtCollectionNo.Text && TRC.BankDepositeID == Vint_BankDepositeId)
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

                                             }).OrderBy(x => x.ChequeDueDate).ToList();

                        dataGridView1.DataSource = listBnkCheque;
                        dataGridView3.DataSource = listBnkCheque;
                        LoadSerial();
                        LoadSerial3();
                        GrdBnkCheq();
                        GrdBnkCheq3();
                        var list = FsDb.Tbl_TreasuryCollection.FirstOrDefault(x => x.BranchID == Vint_BranchID && x.CollectionDate == vdate_CollectionDate && x.ChequeReceivedKindID == 0 && x.CollectionNo.Contains(txtCollectionNo.Text) && x.BankDepositeID == Vint_BankDepositeId);
                        if (list != null)
                        {
                            txtRowID.Text = list.ID.ToString();
                            if (list.RepresentiveID != null)
                            {
                                Vint_RepresentiveID = int.Parse(list.RepresentiveID.ToString());
                                txtRepresentiveID.Text = Vint_RepresentiveID.ToString();
                                var listRpsntv = FsDb.Tbl_Representatives.FirstOrDefault(x => x.ID == Vint_RepresentiveID);
                                txtRepresentive.Text = listRpsntv.Name.ToString();
                            }

                            VLng_IDMasterRow = list.ID;

                            groupControl3.Text = $"الشيكات الوارده من فرع {txtBranch.Text}  بتاريخ {dTPCollection.Value.ToString("yyyy/MM/dd")}برقم حافظه {txtCollectionNo.Text}البنك المودع {txtBnkDeposit.Text}";
                        }
                        groupControl4.Text = $"حوافظ فرع {txtBranch.Text} بتاريخ {dTPCollection.Value.ToString("yyyy/MM/dd")}برقم حافظه {txtCollectionNo.Text}البنك المودع {txtBnkDeposit.Text}";

                    }
                    else if (Vint_ChequeReceivedKindID == 1)
                    {
                        var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                             join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                             join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                             //join Cust in FsDb.Tbl_Customer on BnkChq.CustID equals Cust.ID
                                             where (TRC.BranchID == Vint_BranchID && TRC.CollectionDate == vdate_CollectionDate && TRC.ChequeReceivedKindID == 1 && TRC.CollectionNo == txtCollectionNo.Text && TRC.BankDepositeID == Vint_BankDepositeId)
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

                                             }).OrderBy(x => x.ChequeDueDate).ToList();

                        dataGridView1.DataSource = listBnkCheque;
                        dataGridView3.DataSource = listBnkCheque;
                        LoadSerial();
                        LoadSerial3();
                        GrdBnkCheq();
                        GrdBnkCheq3();
                        groupControl4.Text = $"مستندات  {txtBranch.Text} بتاريخ {dTPCollection.Value.ToString("yyyy/MM/dd")} برقم مستند {txtCollectionNo.Text} البنك المودع {txtBnkDeposit.Text}";
                        var list = FsDb.Tbl_TreasuryCollection.FirstOrDefault(x => x.BranchID == Vint_BranchID && x.CollectionDate == vdate_CollectionDate && x.ChequeReceivedKindID == 1 && x.CollectionNo.Contains(txtCollectionNo.Text) && x.BankDepositeID == Vint_BankDepositeId);
                        if (list != null)
                        {
                            txtRowID.Text = list.ID.ToString();
                            if (list.RepresentiveID != null)
                            {
                                Vint_RepresentiveID = int.Parse(list.RepresentiveID.ToString());
                                txtRepresentiveID.Text = Vint_RepresentiveID.ToString();
                                var listRpsntv = FsDb.Tbl_Representatives.FirstOrDefault(x => x.ID == Vint_RepresentiveID);
                                txtRepresentive.Text = listRpsntv.Name.ToString();
                            }
                            VLng_IDMasterRow = list.ID;
                            dataGridView1.DataSource = FsDb.Tbl_BankCheques.Where(x => x.TreasuryCollectionID == VLng_IDMasterRow).ToList();
                            LoadSerial();
                            GrdBnkCheq();
                            groupControl3.Text = $"الشيكات الوارده من  {txtBranch.Text}  بتاريخ {dTPCollection.Value.ToString("yyyy/MM/dd")}برقم حافظه {txtCollectionNo.Text}البنك المودع {txtBnkDeposit.Text}";
                        }

                    }

                    Vint_BankDepositeId = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                    var listAccountBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_BankDepositeId && x.KindAccountBankID == 1).ToList();
                    if (listAccountBank != null)

                    {
                        this.tbl_AccountsBankTableAdapter.Fill(this.bankCheques.Tbl_AccountsBank);
                        cmbAccountBank.DataSource = listAccountBank;
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
                txtRepresentive.Focus();
            }

        }

        private void txtAccountBnk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRepresentive.Focus();
            }

        }

        private void txtRepresentive_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTradeCollectionNO.Select();
                this.ActiveControl = txtTradeCollectionNO;
                txtTradeCollectionNO.Focus();

            }
            else if (e.KeyCode == Keys.Down)
            {

                Forms.BasicCodeForms.FindRepresentativesFrm t = new Forms.BasicCodeForms.FindRepresentativesFrm();
                t.txtBrunchID.Text = Vint_BranchID.ToString();
                t.ShowDialog();

                //t.dataGridView1.DataSource = FsDb.Tbl_Representatives.Where(x => x.BranchID == Vint_BranchID);
                if (Forms.BasicCodeForms.FindRepresentativesFrm.SelectedRow != null)
                {
                    txtRepresentive.Text = Forms.BasicCodeForms.FindRepresentativesFrm.SelectedRow.Cells[1].Value.ToString();
                    txtRepresentiveID.Text = Forms.BasicCodeForms.FindRepresentativesFrm.SelectedRow.Cells[0].Value.ToString();
                    txtRepresentive.SelectionLength = 0;

                    txtTradeCollectionNO.Select();
                    this.ActiveControl = txtTradeCollectionNO;
                    txtTradeCollectionNO.Focus();


                }


            }
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtAmount.Text != "")
                { Vdc_AmountCheque = Convert.ToDecimal(txtAmount.Text); }
                var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                     join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                     join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                     //join Cust in FsDb.Tbl_Customer on BnkChq.CustID equals Cust.ID
                                     where (BnkChq.AmountCheque == Vdc_AmountCheque && TRC.ID == Vlng_LastRowTreasuryCollection)
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
                if (listBnkCheque != null)
                {
                    dataGridView1.DataSource = listBnkCheque;
                    GrdBnkCheq();
                }
                txtBankDrawnOn.Focus();
            }
        }

        private void txtBankDrawnOn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBankDrawnOnID.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل مبلغ الشيك");
                    txtAmount.Focus();
                }
                else if (txtBankDrawnOnID.Text != "")

                { Vint_BankDrawnOnID = int.Parse(txtBankDrawnOnID.Text); }
                if (txtAmount.Text != "")
                { Vdc_AmountCheque = Convert.ToDecimal(txtAmount.Text); }
                var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                     join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                     join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                     //join Cust in FsDb.Tbl_Customer on BnkChq.CustID equals Cust.ID
                                     where (BnkChq.AmountCheque == Vdc_AmountCheque && BnkChq.BankDrawnOnID == Vint_BankDrawnOnID && TRC.ID == Vlng_LastRowTreasuryCollection)
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
                if (listBnkCheque != null)
                {
                    dataGridView1.DataSource = listBnkCheque;
                    GrdBnkCheq();
                }
                txtChequeNo.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                Forms.BasicCodeForms.FindBankParentFrm t = new Forms.BasicCodeForms.FindBankParentFrm();
                t.ShowDialog();

                if (t.txtBankId != null)
                {
                    txtBankDrawnOn.Text = t.txtSelected.Text;
                    txtBankDrawnOnID.Text = t.txtBankId.Text;


                }
                txtChequeNo.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBankDrawnOnID.Text == "")
                {
                    MessageBox.Show("من فضلك اختر البنك المسحوب عليه");
                    txtBankDrawnOn.Focus();

                }
                else if (txtChequeNo.Text != "")
                {
                    Vstr_ChequeNO = txtChequeNo.Text;
                    if (txtBankDrawnOnID.Text != "")
                    {
                        Vint_BankDrawnOnID = int.Parse(txtBankDrawnOnID.Text);
                    }
                    if (txtAmount.Text != "")
                    {
                        Vdc_AmountCheque = Convert.ToDecimal(txtAmount.Text);
                    }
                    var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                         join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                         join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                         //join Cust in FsDb.Tbl_Customer on BnkChq.CustID equals Cust.ID
                                         where (BnkChq.AmountCheque == Vdc_AmountCheque && BnkChq.BankDrawnOnID == Vint_BankDrawnOnID && TRC.ID == Vlng_LastRowTreasuryCollection && BnkChq.ChequeNo == Vstr_ChequeNO)
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
                    if (listBnkCheque != null)
                    {
                        dataGridView1.DataSource = listBnkCheque;
                        GrdBnkCheq();
                        dTPDueDate.Focus();
                    }
                    dTPDueDate.Focus();
                }
            }

        }

        private void txtCust_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dTPDueDate.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                Forms.ProcessingForms.FindCustomersFrm t = new Forms.ProcessingForms.FindCustomersFrm();

                t.ShowDialog();
                if (Forms.ProcessingForms.FindCustomersFrm.SelectedRow != null)
                {
                    txtCust.Text = Forms.ProcessingForms.FindCustomersFrm.SelectedRow.Cells[1].Value.ToString();
                    txtCustID.Text = Forms.ProcessingForms.FindCustomersFrm.SelectedRow.Cells[0].Value.ToString();

                }
                dTPDueDate.Focus();
            }
        }

        private void dTPDueDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 78 && w.ProcdureId == 1);
                if (validationSaveUser != null)
                {
                    int Vin_Year = 0;
                    FinancialYearDueDate f = new FinancialYearDueDate();
                    if (txtRowID.Text == "" && txtRowChequeID.Text == "")
                    {
                        if (txtBranchID.Text == "" && Vint_ChequeReceivedKindID == 0)
                        { MessageBox.Show("من فضلك ادخل الفرع"); txtBranch.Focus(); }
                        else if (cmbBnkDeposit.SelectedIndex == -1 && Vint_ChequeReceivedKindID == 0)
                        { MessageBox.Show("من فضلك قم باختيار البنك المودع"); txtBnkDeposit.Focus(); }

                        else if (comboBox1.SelectedIndex == -1 && Vint_ChequeReceivedKindID == 0)
                        { MessageBox.Show("من فضلك قم باختيار رقم الحساب الخاص بالبنك المودع"); comboBox1.Focus(); }

                        else if (txtCollectionNo.Text == "" && Vint_ChequeReceivedKindID == 0)
                        { MessageBox.Show("من فضلك ادخل رقم الحافظه"); txtCollectionNo.Focus(); }
                        //else if (txtRepresentiveID.Text == "" && Vint_ChequeReceivedKindID == 0)
                        //{ MessageBox.Show("من فضلك اختر مندوب الخزينه"); txtRepresentive.Focus(); }

                        else if (txtBranchID.Text == "" && Vint_ChequeReceivedKindID == 1)
                        { MessageBox.Show("من فضلك ادخل الجهه"); txtBranch.Focus(); }

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
                            if (txtTradeCollectionNO.Text != "") { Vstr_TradeCollectionNO = txtTradeCollectionNO.Text; }

                            if (txtReceiptNo.Text != "") { Vstr_ReceiptNO = txtReceiptNo.Text; }
                            else { Vstr_ReceiptNO = null; }

                            Vin_Year = f.SelectFinancialYearDueDate(Convert.ToDateTime(dTPCollection.Value.ToString()));
                            Tbl_TreasuryCollection tc = new Tbl_TreasuryCollection
                            {
                                BankDepositeID = Vint_BankDepositeId,
                                BankAccounNoID = Vint_BankAccId,
                                CollectionNo = Vstr_CollectionNo,
                                CollectionDate = Convert.ToDateTime(dTPCollection.Value.ToString()),
                                BranchID = Vint_BranchID,
                                RepresentiveID = Vint_RepresentiveID,
                                ChequeReceivedKindID = Vint_ChequeReceivedKindID,
                                AddRecievedDate = Convert.ToDateTime(dTPAddRecievedDate.Value.ToString()),
                                FYear = int.Parse(comboBox3.SelectedValue.ToString()),
                                TradeCollectionNo = txtTradeCollectionNO.Text,
                                ReceiptNo = Vstr_ReceiptNO,
                                IsDepositNo = false,
                                FisicalYearID = Vin_Year

                            };
                            FsDb.Tbl_TreasuryCollection.Add(tc);
                            FsDb.SaveChanges();
                            txtRowID.Text = tc.ID.ToString();
                            Vlng_LastRowTreasuryCollection = long.Parse(txtRowID.Text);
                        }
                    }
                    else if (txtRowID.Text != "" && txtRowChequeID.Text == "")
                    {
                        Vlng_LastRowTreasuryCollection = long.Parse(txtRowID.Text);
                        var ListTrCollection = FsDb.Tbl_TreasuryCollection.FirstOrDefault(x => x.ID == Vlng_LastRowTreasuryCollection);
                        if (cmbBnkDeposit.SelectedValue != null)
                        {
                            ListTrCollection.BankDepositeID = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                            ListTrCollection.BankAccounNoID = int.Parse(comboBox1.SelectedValue.ToString());
                        }
                        if (txtCollectionNo.Text != "")
                        { ListTrCollection.CollectionNo = txtCollectionNo.Text; }

                        ListTrCollection.CollectionDate = Convert.ToDateTime(dTPCollection.Value.ToString());
                        ListTrCollection.FisicalYearID = f.SelectFinancialYearDueDate(Convert.ToDateTime(dTPCollection.Value.ToString()));
                        ListTrCollection.BranchID = int.Parse(txtBranchID.Text);
                        if (txtRepresentiveID.Text != "")
                        { ListTrCollection.RepresentiveID = int.Parse(txtRepresentiveID.Text); }

                        if (txtTradeCollectionNO.Text != "")
                        { ListTrCollection.TradeCollectionNo = txtTradeCollectionNO.Text; }

                        if (txtReceiptNo.Text != "")
                        { ListTrCollection.ReceiptNo = txtReceiptNo.Text; }
                        FsDb.SaveChanges();


                        //************************************
                        if (txtAmount.Text == "")
                        { MessageBox.Show("من فضلك ادخل قيمة الشيك"); txtAmount.Focus(); }

                        else if (txtBankDrawnOn.Text == "")
                        { MessageBox.Show("من فضلك ادخل البنك المسحوب عليه"); txtBankDrawnOn.Focus(); }
                        else if (txtChequeNo.Text == "")
                        { MessageBox.Show("من فضلك ادخل رقم الشيك"); txtChequeNo.Focus(); }
                        else
                        {
                            //*********************************
                            Vdate_ChequeDueDate = Convert.ToDateTime(dTPDueDate.Value.ToString("yyyy/MM/dd"));
                            Vstr_ChequeNO = txtChequeNo.Text;
                            Vint_BankDrawnOnID = int.Parse(txtBankDrawnOnID.Text);
                            Vdc_AmountCheque = Convert.ToDecimal(txtAmount.Text);
                            var listBnkChequeR = (from BnkChq in FsDb.Tbl_BankCheques
                                                  join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                                  join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                                  //join Cust in FsDb.Tbl_Customer on BnkChq.CustID equals Cust.ID
                                                  where (BnkChq.AmountCheque == Vdc_AmountCheque && BnkChq.BankDrawnOnID == Vint_BankDrawnOnID && BnkChq.ChequeNo == Vstr_ChequeNO && BnkChq.ChequeDueDate == Vdate_ChequeDueDate)
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
                                                      ChequeKindID = BnkChq.ChequeKindID,

                                                      BankName = BNK.Name,

                                                  }).OrderBy(x => x.ID).ToList();


                            Vint_DgCount = dataGridView1.RowCount;
                            if (Vint_DgCount != 0)
                            {
                                txtAllValueBefore.Text = (from DataGridViewRow row in dataGridView1.Rows
                                                          select Convert.ToDouble(row.Cells[2].Value)).Sum().ToString();
                            }
                            if (listBnkChequeR.Count > 0)
                            {
                                MessageBox.Show($"هذا الشيك تم ادخاله من قبل برقم {txtChequeNo.Text} بتاريخ {dTPDueDate.Value.ToString()} البنك المسحوب عليه {txtBankDrawnOn.Text} بمبلغ {txtAmount.Text} ");
                                txtAmount.Focus();

                            }
                            else if (txtRowChequeID.Text == "")
                            {

                                //********************************
                                if (txtCustID.Text == "") { Vint_CustID = null; }
                                Vin_Year = f.SelectFinancialYearDueDate(Convert.ToDateTime(dTPDueDate.Value.ToString()));
                                Tbl_BankCheques ChBnk = new Tbl_BankCheques
                                {
                                    TreasuryCollectionID = Vlng_LastRowTreasuryCollection,
                                    AmountCheque = Convert.ToDecimal(txtAmount.Text),
                                    BankDrawnOnID = int.Parse(txtBankDrawnOnID.Text),
                                    ChequeNo = txtChequeNo.Text,
                                    ChequeDueDate = Convert.ToDateTime(dTPDueDate.Value.ToString()),
                                    CustID = Vint_CustID,
                                    AddDateBank = null,
                                    ChequeKindID = 1,
                                    IsDepositNo = false,
                                    ChequeStatusID = 1,
                                    ChequeStatusDate = Convert.ToDateTime(dTPAddRecievedDate.Value.ToString("yyyy/MM/dd")),
                                    FisicalYearID = Vin_Year

                                };
                                FsDb.Tbl_BankCheques.Add(ChBnk);
                                FsDb.SaveChanges();
                                Tbl_ChequeBankStatusDates ChStDate = new Tbl_ChequeBankStatusDates
                                {
                                    BankChequeStatusID = 1,
                                    BankChequeID = ChBnk.ID,
                                    ChequeBankStatusDate = Convert.ToDateTime(dTPAddRecievedDate.Value.ToString("yyyy/MM/dd"))
                                };

                                FsDb.Tbl_ChequeBankStatusDates.Add(ChStDate);
                                FsDb.SaveChanges();
                                long Vlng_LastRowBankCheques = ChBnk.ID;
                                txtLastIdTrCollection.Text = Vlng_LastRowTreasuryCollection.ToString();
                                //---------------خفظ ااحداث 
                                SecurityEvent sev = new SecurityEvent
                                {
                                    ActionName = "اضافة حافظه / مستند",
                                    TableName = "Tbl_TreasuryCollection",
                                    TableRecordId = Vlng_LastRowTreasuryCollection.ToString(),
                                    Description = "",
                                    ManagementName = Program.GlbV_Management,
                                    ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                    EmployeeName = Program.GlbV_EmpName,
                                    User_ID = Program.GlbV_UserId,
                                    UserName = Program.GlbV_UserName,
                                    FormName = "شاشة الشيكات الوارده للخزينه"

                                };

                                FsEvDb.SecurityEvents.Add(sev);
                                FsEvDb.SaveChanges();
                                //************************************
                                MessageBox.Show("تم الحفظ ");

                                //if (resultMessageYesNo == DialogResult.Yes)
                                //{
                                if (Vint_ChequeReceivedKindID == 0)
                                { GrdTrCollectionBr(); }
                                else
                                { GrdTrCollectionDr(); }

                                ClearDataDetails();
                                //****************


                                Vlng_LastRowTreasuryCollection = long.Parse(txtLastIdTrCollection.Text);
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
                                    dataGridView3.DataSource = listBnkCheque;
                                    LoadSerial();
                                    LoadSerial3();
                                    GrdBnkCheq();
                                    GrdBnkCheq3();
                                }
                                txtAmount.Focus();
                                //}
                                //else
                                //{
                                //    ClearDataMaster();
                                //    ClearDataDetails();
                                //    txtBranch.Focus();
                                //}
                            }


                        }
                    }
                    else
                    {
                        MessageBox.Show("انت بصدد تعديل بيانات شيك وليست اضافه اضغط على زر تعديل");
                    }

                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية اضافة  حافظه وارده الى الخزينه .. برجاء مراجعة مدير المنظومه");
                }
            }
        }




        private void txtBranch_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 2000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لإختيار الفرع / الجهه", TB, 0, 0, VisibleTime);
        }

        private void cmbAccountBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRepresentive.Focus();

            }
        }

        private void txtBnkDeposit_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 1000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لإختيار البنك المودع", TB, 0, 0, VisibleTime);
        }

        private void txtRepresentive_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            TB.SelectionLength = 0;
            int VisibleTime = 1000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لإختيار مندوب الخزينه", TB, 0, 0, VisibleTime);

        }

        private void txtBankDrawnOn_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 1000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لإختيار البنك المسحوب عليه", TB, 0, 0, VisibleTime);
        }

        private void cmbAccountBank_SelectionChangeCommitted(object sender, EventArgs e)
        {

            Vint_AccountBank = int.Parse(cmbAccountBank.SelectedValue.ToString());
            txtAccountBnkID.Text = Vint_AccountBank.ToString();


        }

        private void txtCollectionNo_TextChanged(object sender, EventArgs e)
        {
            //if (Vint_ChequeReceivedKindID == 0)
            //{

            //    dataGridView2.DataSource = FsDb.Tbl_TreasuryCollection.Where(x => x.BranchID == Vint_BranchID && x.CollectionDate == vdate_CollectionDate && x.ChequeReceivedKindID == 0 && x.CollectionNo.Contains(txtCollectionNo.Text)).ToList();
            //    groupControl4.Text = $"حوافظ فرع {txtBranch.Text} بتاريخ {dTPCollection.Value.ToString("yyyy/MM/dd")}برقم حافظه {txtCollectionNo.Text}";

            //}
            //else if (Vint_ChequeReceivedKindID == 1)
            //{
            //    dataGridView2.DataSource = FsDb.Tbl_TreasuryCollection.Where(x => x.BranchID == Vint_BranchID && x.CollectionDate == vdate_CollectionDate && x.ChequeReceivedKindID == 1 && x.CollectionNo.Contains(txtCollectionNo.Text)).ToList();
            //    groupControl4.Text = $"مستندات فرع {txtBranch.Text} بتاريخ {dTPCollection.Value.ToString("yyyy/MM/dd")} برقم مستند {txtCollectionNo.Text}";

            //}
        }

        private void dTPAddRecievedDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Vint_ChequeReceivedKindID == 0)
                {
                    cmbBnkDeposit.Focus();
                }
                else if (Vint_ChequeReceivedKindID == 1)
                {
                    txtAmount.Focus();
                }
            }
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            ClearDataMaster();
            txtAllValueBeforeall.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";

            if (dataGridView2.CurrentRow.Cells[3].Value != null)
            {
                txtRowID.Text = "";
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
                    //*************ملى البيانات الخاصه بالحافظه المختاره
                    txtRowID.Text = list[0].ID.ToString();
                    txtBranch.Text = list[0].BranchName.ToString();
                    txtBranchID.Text = list[0].BranchID.ToString();
                    cmbBnkDeposit.SelectedValue = list[0].BankDepositeID.ToString();
                    Vint_BankDepositeId = int.Parse(list[0].BankDepositeID.ToString());
                    txtCollectionNo.Text = list[0].CollectionNo.ToString();
                    //var list1 = FsDb.Tbl_TreasuryCollection.FirstOrDefault(x => x.ID == Vlng_LastRowTreasuryCollection);
                    if (list[0].TradeCollectionNo != null)
                    { txtTradeCollectionNO.Text = list[0].TradeCollectionNo.ToString(); }
                    if (list[0].ReceiptNo != null)
                    { txtReceiptNo.Text = list[0].ReceiptNo.ToString(); }
                    dTPCollection.Value = Convert.ToDateTime(list[0].CollectionDate.ToString());
                    if (list[0].AddRecievedDate != null)
                    {
                        dTPAddRecievedDate.Value = Convert.ToDateTime(list[0].AddRecievedDate.ToString());
                    }

                    //cmbBnkDeposit.SelectedValue = int.Parse(list[0].BankDepositeID.ToString());
                    int Vint_BankID = int.Parse(list[0].BankDepositeID.ToString());
                    int Vint_BankAccID = int.Parse(list[0].BankAccountID.ToString());

                    var listAcc = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_BankAccID).ToList();
                    comboBox1.DataSource = listAcc;
                    comboBox1.DisplayMember = "AccountBankNo";
                    comboBox1.ValueMember = "ID";

                    comboBox1.SelectedValue = Vint_BankAccID;
                    comboBox1.Text = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_BankAccID).Select(x => x.AccountBankNo).FirstOrDefault();

                    cmbAccountBank.DisplayMember = "AccountBankNo";
                    cmbAccountBank.ValueMember = "ID";

                    int Vint_AccBank = int.Parse(comboBox1.SelectedValue.ToString());
                    var ListAcc = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_AccBank).ToList();
                    int Vint_PAccBank = int.Parse(ListAcc[0].AccPurposeID.ToString());
                    var ListPurpose = FsDb.Tbl_AccountsBankPurpose.Where(x => x.ID == Vint_PAccBank).ToList();
                    comboBox2.DataSource = ListPurpose;
                    comboBox2.DisplayMember = "Name";
                    comboBox2.ValueMember = "ID";


                    if (list[0].RepresentiveID != null)
                    {
                        txtRepresentiveID.Text = list[0].RepresentiveID.ToString();
                        int vint_RepresentiveID = int.Parse(list[0].RepresentiveID.ToString());
                        txtRepresentiveID.Text = list[0].RepresentiveID.ToString();
                        var listN = (from Reprs in FsDb.Tbl_Representatives
                                     where (Reprs.ID == vint_RepresentiveID)
                                     select new
                                     { Reprs.Name }).ToList();
                        txtRepresentive.Text = listN[0].Name.ToString();
                    }
                    if (list[0].DepositDate != null)
                    {
                        //DateTime Vd_DepDate  = Convert.ToDateTime( list[0].DepositDate.Value.ToString("yyyy/MM/dd"));
                        textBox10.Text = list[0].DepositDate.Value.ToString("yyyy/MM/dd");
                    }

                    //****************Refrences******User Enter Data ********عرض بيانات المستخدم الذي ادخل بيانات الخافظه وشيكات*
                    //****************Refrences******User Enter Data *********

                    //AccRstAuditSelect(Vlng_LastRowTreasuryCollection);
                    var ListAccRstAudit = FsEvDb.SecurityEvents.Where(x => x.TableRecordId == Vlng_LastRowTreasuryCollection.ToString() && x.TableName == "Tbl_TreasuryCollection").Distinct().ToList();

                    string Vstr_UserAddR = "";
                    int WCount = int.Parse(ListAccRstAudit.Count.ToString());
                    for (int i = 0; i <= WCount - 1; i++)
                    {
                        Vstr_UserAddR = Vstr_UserAddR + " / " + ListAccRstAudit[i].EmployeeName;
                    }
                    textBox1.Text = Vstr_UserAddR;
                    //*************
                    //AccRstAuditSelect(Vlng_LastRowTreasuryCollection);

                    //var listCheck = FsDb.Tbl_BankCheques.FirstOrDefault(x => x.TreasuryCollectionID == Vlng_LastRowTreasuryCollection);
                    //int   Vint_bankCheq =int.Parse( listCheck.ID.ToString());
                    //var ListAccRstAudit = FsEvDb.SecurityEvents.Where(x => x.TableRecordId == Vlng_LastRowTreasuryCollection.ToString() && x.TableName == "Tbl_TreasuryCollection").Distinct().ToList() ;


                    //*************
                    //var listAccountBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_BankDepositeId && x.BankAccStatusID == 1).ToList();
                    //if (listAccountBank != null)

                    //{
                    //    this.tbl_AccountsBankTableAdapter.Fill(this.bankCheques.Tbl_AccountsBank);
                    //    cmbAccountBank.DataSource = listAccountBank;
                    //    comboBox1.DataSource = listAccountBank;
                    //    if (listAccountBank.Count != 0)
                    //    {
                    //        txtAccountBnk.Text = listAccountBank[0].AccountBankNo;
                    //        if (listAccountBank.Count == 1)
                    //        {
                    //            txtAccountBnkID.Text = listAccountBank[0].ID.ToString();
                    //        }
                    //        else
                    //        {
                    //            txtAccountBnkID.Text = "";
                    //        }
                    //    }
                    //}
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
                    txtBranch.Text = list[0].BranchName.ToString();
                    txtBranchID.Text = list[0].BranchID.ToString();
                    dTPCollection.Value = Convert.ToDateTime(list[0].CollectionDate.ToString());
                    if (list[0].AddRecievedDate != null)

                    { dTPAddRecievedDate.Value = Convert.ToDateTime(list[0].AddRecievedDate.ToString()); }
                    txtCollectionNo.Text = list[0].CollectionNo.ToString();

                    //****************Refrences******User Enter Data *********

                    //AccRstAuditSelect(Vlng_LastRowTreasuryCollection);
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

                    dataGridView3.DataSource = listBnkCheque;
                    LoadSerial();
                    LoadSerial3();
                    GrdBnkCheq();
                    GrdBnkCheq3();
                    if (Vint_ChequeReceivedKindID == 0)
                    {
                        groupControl3.Text = "";
                        groupControl3.Text = $"الشيكات الوارده من فرع {txtBranch.Text}  بتاريخ {dTPCollection.Value.ToString("yyyy/MM/dd")}برقم حافظه {txtCollectionNo.Text}البنك المودع {txtBnkDeposit.Text}";
                    }
                    else if (Vint_ChequeReceivedKindID == 1)
                    {
                        groupControl3.Text = "";
                        groupControl3.Text = $"مستندات  {txtBranch.Text} بتاريخ {dTPCollection.Value.ToString("yyyy/MM/dd")}";

                    }
                }
                txtAmount.Select();
                this.ActiveControl = txtAmount;
                txtAmount.Focus();
            }
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {

            //if (txtAmount.Text == "" && txtRowID.Text == "")
            //{
            //    MessageBox.Show("يجب ادخال قيمة الشيك");
            //    txtAmount.Text = "0";
            //    txtAmount.Focus();
            //}

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
                    cmbBnkDeposit.SelectedValue = int.Parse(list[0].BankDepositeID.ToString());
                    //txtBnkDepositID.Text = list[0].BankDepositeID.ToString();
                    txtAccountBnkID.Text = list[0].BankAccountID.ToString();


                    if (list[0].RepresentiveID != null)
                    { txtRepresentiveID.Text = list[0].RepresentiveID.ToString(); }

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
                txtRowChequeID.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                if (txtRowChequeID.Text != "")
                {
                    textBox9.Text = "";
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
                    txtAmount.Text = listBnkCheque[0].AmountCheque.ToString();
                    txtAmountScan.Text = listBnkCheque[0].AmountCheque.ToString();
                    txtBankDrawnOn.Text = listBnkCheque[0].BankName.ToString();
                    txtBankDrawnOnScan.Text = listBnkCheque[0].BankName.ToString();
                    txtBankDrawnOnID.Text = listBnkCheque[0].BankDrawnOnID.ToString();
                    txtChequeNo.Text = listBnkCheque[0].ChequeNo.ToString();
                    txtChequeNoScan.Text = listBnkCheque[0].ChequeNo.ToString();
                    dTPDueDate.Value = Convert.ToDateTime(listBnkCheque[0].ChequeDueDate.Value.ToString());
                    dTPDueDateScan.Value = Convert.ToDateTime(listBnkCheque[0].ChequeDueDate.Value.ToString());
                    txtCustID.Text = listBnkCheque[0].CustID.ToString();
                    if (txtCustID.Text != "")
                    {
                        Vint_CustID = int.Parse(txtCustID.Text);
                        var listCustName = FsDb.Tbl_Customer.FirstOrDefault(t => t.ID == Vint_CustID);
                        txtCust.Text = listCustName.Name;
                    }
                    textBox2.Text = "";
                    txtNotCheqAudit.Text = "";
                    chckBxBasicData.Checked = false;
                    //****************Refrences***************
                    AccRstAuditSelect(Vint_CheckRowID);
                    //***************************************
                    var listImageCheq = FsEvDb.Tbl_ArchTrCollectioCheque.Where(x => x.ChequeBankID == Vint_CheckRowID).Distinct().ToList();
                    if (listImageCheq.Count != 0)
                    {
                        dataGridView4.DataSource = listImageCheq;
                        textBox9.Text = "يوجد صوره";
                    }
                    else
                    {
                        textBox9.Text = "لا يوجد صوره";
                    }

                }
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            ClearDataMaster();
            ClearDataDetails();
            if (Vint_ChequeReceivedKindID == 0)
            { GrdTrCollectionBr(); }
            else
            { GrdTrCollectionDr(); }
            //dTPAddRecievedDate.Value = Convert.ToDateTime(DateTime.Today.ToString());
            dataGridView1.DataSource = null;
            txtBranch.Focus();
            groupControl3.Text = "";
            groupControl4.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            txtNotCheqAudit.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            txtAllValueBeforeall.Text = "";
            textBox5.Text = "";
        }

        private void dTPCollection_Leave(object sender, EventArgs e)
        {
            if (txtBranchID.Text != "" && dTPCollection.Value != null)
            {
                if (Vint_ChequeReceivedKindID == 0)
                {
                    if (txtBranchID.Text != "")
                    {
                        Vint_BranchID = int.Parse(txtBranchID.Text);
                        vdate_CollectionDate = Convert.ToDateTime(dTPCollection.Value.ToString());
                        int Vint_FYear = int.Parse(comboBox3.SelectedValue.ToString());
                        int Vint_CountBrunch = FsDb.Tbl_TreasuryCollection.Where(x => x.BranchID == Vint_BranchID && x.FYear == Vint_FYear).Count();
                        if (Vint_CountBrunch == 0)
                        {
                            txtCollectionNo.Text = comboBox3.SelectedText + "/" + txtBranchID.Text + "/" + "1";
                        }
                        else
                        {
                            txtCollectionNo.Text = comboBox3.SelectedText + "/" + txtBranchID.Text + "/" + (Vint_CountBrunch + 1);
                        }
                    }
                }
                else if (Vint_ChequeReceivedKindID == 1)
                {

                    DateTime Vdt_TodaySrv = Convert.ToDateTime(GetServerDate.Cs_GetServerDate());
                    var list = FsDb.Tbl_TreasuryCollection.Where(x => x.ChequeReceivedKindID == 1 && x.BranchID == Vint_BranchID).ToList();
                    if (list.Count != 0)
                    {
                        Vint_BranchID = 180;
                        vdate_CollectionDate = Convert.ToDateTime(dTPCollection.Value.ToString());
                        int Vint_FYear = int.Parse(comboBox3.SelectedValue.ToString());
                        int Vint_CountBrunch = FsDb.Tbl_TreasuryCollection.Distinct().Where(x => x.FYear == Vint_FYear && x.ChequeReceivedKindID == 1).Count();
                        txtCollectionNo.Text = comboBox3.SelectedText + "/" + txtBranchID.Text + "/" + (Vint_CountBrunch + 1);
                    }
                    else
                    {
                        txtCollectionNo.Text = comboBox3.SelectedText + "/" + txtBranchID.Text + "/" + "1";
                    }
                }
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 78 && w.ProcdureId == 3);
            if (validationSaveUser != null)
            {
                int Vint_bankdrawnonid = 0;
                if (txtRowChequeID.Text != "")
                {
                    Vlng_LastRowTreasuryCollection = int.Parse(txtRowID.Text);
                    var listToUpdtTrC = FsDb.Tbl_TreasuryCollection.FirstOrDefault(x => x.ID == Vlng_LastRowTreasuryCollection);
                    if (Vint_ChequeReceivedKindID == 0)
                    {
                        listToUpdtTrC.BankDepositeID = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                        listToUpdtTrC.BankAccounNoID = int.Parse(txtAccountBnkID.Text);
                        if (txtRepresentiveID.Text != "")
                        { listToUpdtTrC.RepresentiveID = int.Parse(txtRepresentiveID.Text); }
                    }

                    listToUpdtTrC.CollectionNo = txtCollectionNo.Text;
                    listToUpdtTrC.CollectionDate = Convert.ToDateTime(dTPCollection.Value.ToString());
                    listToUpdtTrC.BranchID = int.Parse(txtBranchID.Text);


                    listToUpdtTrC.AddRecievedDate = Convert.ToDateTime(dTPAddRecievedDate.Value.ToString());
                    if (txtTradeCollectionNO.Text != "")
                    {
                        listToUpdtTrC.TradeCollectionNo = txtTradeCollectionNO.Text;
                    }
                    if (txtReceiptNo.Text != "")
                    {
                        listToUpdtTrC.ReceiptNo = txtReceiptNo.Text;
                    }
                    FsDb.SaveChanges();
                    Vint_CheckRowID = int.Parse(txtRowChequeID.Text);
                    var listToUpdtChck = FsDb.Tbl_BankCheques.FirstOrDefault(x => x.ID == Vint_CheckRowID);

                    listToUpdtChck.AmountCheque = Convert.ToDecimal(txtAmount.Text);
                    listToUpdtChck.BankDrawnOnID = int.Parse(txtBankDrawnOnID.Text);

                    if (txtCustID.Text != "")

                    { listToUpdtChck.CustID = int.Parse(txtCustID.Text); }
                    listToUpdtChck.ChequeNo = txtChequeNo.Text;
                    listToUpdtChck.ChequeDueDate = Convert.ToDateTime(dTPDueDate.Value.ToString());
                    //**************************البنك المودع  وتاريح الايداع
                    int Vint_bankDepositID = 0;

                    var listDateDeposit = FsDb.Tbl_TreasuryCollection.Where(x => x.ID == Vlng_LastRowTreasuryCollection).ToList();
                    if (listDateDeposit != null)
                    {
                        Vint_bankDepositID = int.Parse(listDateDeposit[0].BankDepositeID.ToString());
                        if (Vint_bankDepositID == 2004)
                        { Vint_bankDepositID = 1; }
                        else if (Vint_bankDepositID == 2014)
                        { Vint_bankDepositID = 2013; }

                    }
                    //******************************حساب تاريخ اضافة الشيك للحساب البنكي
                    if (listToUpdtChck.ChequeStatusID == 2)
                    {
                        DateAddedStatlmentCs dateAddedStatlment = new DateAddedStatlmentCs();
                        DateTime Vd_chequDueDate = Convert.ToDateTime(dTPDueDate.Value.ToString());
                        Vint_bankdrawnonid = int.Parse(txtBankDrawnOnID.Text);


                        int vacationYear = 2024;//سنة الاجازة

                        DateTime Vdt_DepositDate = Convert.ToDateTime(listDateDeposit[0].DepositDate.Value.ToString());
                        dateAddedStatlment.PublicvacationYear = vacationYear;
                        string result = dateAddedStatlment.SelectDateAddedBank(Vd_chequDueDate, Vdt_DepositDate, Vint_bankDepositID, Vint_bankdrawnonid);
                        listToUpdtChck.AddDateAccBank = Convert.ToDateTime(result);
                    }
                    //********************اثبات التعديل بعد اكتشاف خطا من المراجعين
                    var ListCheqAudit = FsDb.Tbl_TreasuryCollection_Audit.Where(x => x.Note != "" && x.BankCheqeID == Vint_CheckRowID && x.IsUpdate == null).Distinct().ToList();
                    if (ListCheqAudit.Count != 0)
                    {
                        ListCheqAudit[0].IsUpdate = true;
                        ListCheqAudit[0].UpdateDate = Convert.ToDateTime(DateTime.Today.ToString());
                    }
                    //************************
                    FsDb.SaveChanges();
                    //---------------خفظ ااحداث 
                    SecurityEvent sev = new SecurityEvent
                    {
                        ActionName = "تعديل شيك",
                        TableName = "Tbl_BankCheques",
                        TableRecordId = Vlng_LastRowTreasuryCollection.ToString(),
                        Description = "",
                        ManagementName = Program.GlbV_Management,
                        ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                        EmployeeName = Program.GlbV_EmpName,
                        User_ID = Program.GlbV_UserId,
                        UserName = Program.GlbV_UserName,
                        FormName = "شاشة الشيكات الوارده للخزينه"

                    };

                    FsEvDb.SecurityEvents.Add(sev);
                    FsEvDb.SaveChanges();
                    //************************************
                    MessageBox.Show("تم التعديل ");
                    ClearDataDetails();
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
                        dataGridView3.DataSource = listBnkCheque;
                        LoadSerial();
                        LoadSerial3();
                        GrdBnkCheq();
                        GrdBnkCheq3();
                        if (Vint_ChequeReceivedKindID == 0)
                        {
                            groupControl3.Text = $"الشيكات الوارده من فرع {txtBranch.Text}  بتاريخ {dTPCollection.Value.ToString("yyyy/MM/dd")}برقم حافظه {txtCollectionNo.Text}البنك المودع {txtBnkDeposit.Text}";
                        }
                        else if (Vint_ChequeReceivedKindID == 1)
                        {

                            groupControl3.Text = $"مستندات  {txtBranch.Text} بتاريخ {dTPCollection.Value.ToString("yyyy/MM/dd")}";

                        }
                    }
                    txtAmount.Focus();

                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية تعديل  شيك .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void cmbBnkDeposit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbBnkDeposit.SelectedValue != null)
                {
                    Vint_BankDepositeId = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
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
                        txtTradeCollectionNO.Select();
                        this.ActiveControl = txtTradeCollectionNO;
                        txtTradeCollectionNO.Focus();
                    }


                    //****************

                    var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                         join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                         join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                         //join Cust in FsDb.Tbl_Customer on BnkChq.CustID equals Cust.ID
                                         where (TRC.BranchID == Vint_BranchID && TRC.CollectionDate == vdate_CollectionDate && TRC.ChequeReceivedKindID == 0 && TRC.CollectionNo == txtCollectionNo.Text && TRC.BankDepositeID == Vint_BankDepositeId)
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

                                         }).OrderBy(x => x.ChequeDueDate).ToList();

                    dataGridView1.DataSource = listBnkCheque;
                    dataGridView3.DataSource = listBnkCheque;
                    LoadSerial();
                    LoadSerial3();
                    GrdBnkCheq();
                    GrdBnkCheq3();
                    //txtRepresentive.Focus();
                }
            }
        }

        private void cmbBnkDeposit_Leave(object sender, EventArgs e)
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
                else
                {
                    txtTradeCollectionNO.Select();
                    this.ActiveControl = txtTradeCollectionNO;
                    txtTradeCollectionNO.Focus();
                }


                //****************
            }

        }

        private void txtTradeCollectionNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtReceiptNo.Select();
                this.ActiveControl = txtReceiptNo;
                txtReceiptNo.Focus();

            }
        }

        private void txtBankDrawnOn_Leave(object sender, EventArgs e)
        {
            //if (txtBankDrawnOn.Text == "")
            //{
            //    MessageBox.Show("يجب ادخال البنك المسحوب عليه");

            //    txtBankDrawnOn.Focus();
            //}
        }

        private void txtChequeNo_Leave(object sender, EventArgs e)
        {
            //if (txtChequeNo.Text == "")
            //{
            //    MessageBox.Show("يجب ادخال رقم الشيك");

            //    txtChequeNo.Focus();
            //}
        }

        private void txtReceiptNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAmount.Select();
                this.ActiveControl = txtAmount;
                txtAmount.Focus();

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
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 85 && w.ProcdureId == 1003);
                if (validationSaveUser != null)
                {
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
                            NoteAdd = Vstr_Note
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

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            long Vlng_IdItem = 0;
            string Vstr_HirarckyID = "136";
            if (txtRowChequeID.Text != "")
            {
                MessageBox.Show("برجاء قم بإختيار الشيك المراد عمل مسح ضوئي لصورته");
            }
            else
            {


                //**********************Old********************************

                var deviceManager = new DeviceManager();

                DeviceInfo AvailableScanner = null;

                for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++) // Loop Through the get List Of Devices.
                {
                    if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType) // Skip device If it is not a scanner
                    {
                        continue;
                    }

                    AvailableScanner = deviceManager.DeviceInfos[i];

                    break;
                }
                var device = AvailableScanner.Connect(); //Connect to the available scanner.

                var ScanerItem = device.Items[1]; // select the scanner.

                var imgFile = (ImageFile)ScanerItem.Transfer(FormatID.wiaFormatJPEG); //Retrive an image in Jpg format and store it into a variable.

                //****************************
                //**************Create Stracture Of Scan *************
                string Vstr_ProcessKindID = "6";

                string Vstr_YearDate = Convert.ToDateTime(dTPDueDateScan.Value.ToString()).Year.ToString();

                string Vstr_MonthDate = Convert.ToDateTime(dTPDueDateScan.Value.ToString()).Month.ToString();

                string Vstr_IDCheque = txtRowChequeID.Text;
                //string root = Program.GlbV_IpAddressServer + "\\E:\\" + Vstr_ProcessKindID + "\\" + Vstr_YearDate + "\\" + Vstr_MonthDate + "\\" + Vstr_ID;
                ////string root =Program.GlbV_IpAddressServer +"\\"+ @"E:\\" + Vstr_ProcessKindID + "\\" + Vstr_YearDate + "\\" + Vstr_MonthDate + "\\" +  Vstr_ID ;
                //if (Directory.Exists(root))
                //{
                //    Directory.CreateDirectory(root);
                //}
                //*******************

                //var Path = @"E:\ScanImg.jpg"; // save the image in some path with filename.


                //**************Create Directories Of Scan *************
                Vstr_ProcessKindID = "6";

                DateTime Vdt_DateP = Convert.ToDateTime(dTPDueDateScan.Value.ToString());



                Vstr_YearDate = (Vdt_DateP.Year).ToString();

                Vstr_MonthDate = (Vdt_DateP.Month).ToString();

                Vstr_IDCheque = txtRowChequeID.Text;

                string PathDirectory = @"\\30.30.30.5\FinancialScan\" + Vstr_ProcessKindID + textBox8.Text + Vstr_YearDate + textBox8.Text + Vstr_MonthDate + textBox8.Text + Vstr_IDCheque + textBox8.Text + Vstr_HirarckyID;



                if (!Directory.Exists(PathDirectory))
                {
                    try
                    {
                        Directory.CreateDirectory(PathDirectory);
                    }
                    catch (Exception ex)  // CS0168
                    {
                        MessageBox.Show(ex.Message);

                    }

                }
                //**************Create Files Of Scan *************
                Vlng_IdItem = long.Parse(txtRowChequeID.Text);

                var list = FsEvDb.Tbl_ArchTrCollectioCheque.Where(x => x.ChequeBankID == Vlng_IdItem && x.DocumentHirarchyID == 136).ToList();

                if (list.Count != 0)
                {
                    int Vint_count = (list.Count) + 1;
                    string PathFile = PathDirectory + textBox3.Text + (Vint_count.ToString() + ".jpg");
                    if (File.Exists(PathFile))
                    {
                        File.Delete(PathFile);
                    }

                    imgFile.SaveFile(PathFile);

                    //pictureBox1.ImageLocation = PathFile;
                    Tbl_ArchTrCollectioCheque ArchD = new Tbl_ArchTrCollectioCheque()
                    {
                        TrCollectionID = long.Parse(txtRowID.Text),
                        ChequeBankID = Vlng_IdItem,
                        DocumentHirarchyID = 136,
                        PathFile = PathFile
                    };
                    FsEvDb.Tbl_ArchTrCollectioCheque.Add(ArchD);
                    FsEvDb.SaveChanges();
                }
                else
                {
                    string PathFile = PathDirectory + textBox3.Text + "1.jpg";
                    if (File.Exists(PathFile))
                    {
                        File.Delete(PathFile);
                    }

                    imgFile.SaveFile(PathFile);


                    Tbl_ArchTrCollectioCheque ArchD = new Tbl_ArchTrCollectioCheque()
                    {
                        TrCollectionID = long.Parse(txtRowID.Text),
                        ChequeBankID = Vlng_IdItem,
                        DocumentHirarchyID = 136,
                        PathFile = PathFile
                    };
                    FsEvDb.Tbl_ArchTrCollectioCheque.Add(ArchD);
                    FsEvDb.SaveChanges();
                    MessageBox.Show($"تم عمل {"scan"} لصورة الشيك");
                }

            }
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {

            if (txtRowChequeID.Text != "")
            {
                Forms.DocumentsForms.CheqScanFrm t = new Forms.DocumentsForms.CheqScanFrm();
                //**************بيانات الخافظه 
                t.txtbranch.Text = this.txtBranch.Text;
                t.txtCollectionNo.Text = this.txtCollectionNo.Text;
                t.dTPCollectionDate.Value = Convert.ToDateTime(this.dTPCollection.Value.ToString("yyyy/MM/dd"));
                Vint_TrCollectionID = int.Parse(txtRowID.Text);
                //var ListTrColl =  FsDb.Tbl_TreasuryCollection.Where (x=>x.ID == Vint_TrCollectionID).ToList();
                var ListTrColl = (from Tr in FsDb.Tbl_TreasuryCollection
                                  join bnk in FsDb.Tbl_Banks on Tr.BankDepositeID equals bnk.ID
                                  join bnkAcc in FsDb.Tbl_AccountsBank on Tr.BankAccounNoID equals bnkAcc.ID
                                  join bnkAccType in FsDb.Tbl_AccountsBankPurpose on bnkAcc.AccPurposeID equals bnkAccType.ID
                                  where (Tr.ID == Vint_TrCollectionID)
                                  select new
                                  {
                                      Id = Tr.ID,
                                      BankName = bnk.Name,
                                      BankAcc = bnkAcc.AccountBankNo,
                                      bnkAccTypeName = bnkAccType.Name,
                                      TrCollectionDate = Tr.CollectionDate

                                  }).ToList();

                t.txtBankD.Text = this.cmbBnkDeposit.Text.ToString();
                if (ListTrColl.Count > 0)
                {
                    t.txtBankD.Text = ListTrColl[0].BankName;
                    t.dTPCollectionDate.Value = Convert.ToDateTime(ListTrColl[0].TrCollectionDate.ToString());
                    t.txtBankAcc.Text = ListTrColl[0].BankAcc;
                    //t.txtpurpose.Text = this.comboBox2.Text.ToString();
                    t.txtpurpose.Text = ListTrColl[0].bnkAccTypeName;
                }
                //*************بيانات الشيك
                t.txtRowChequeID.Text = this.txtRowChequeID.Text;
                t.txtChequeNoScan.Text = this.txtChequeNoScan.Text;
                t.txtAmountScan.Text = this.txtAmountScan.Text;
                t.txtBankDrawnOnScan.Text = this.txtBankDrawnOnScan.Text;
                t.dTPDueDateScan.Value = Convert.ToDateTime(this.dTPDueDateScan.Value.ToString("yyyy/MM/dd"));


                //***********************
                long Vint_ID = long.Parse(this.txtRowChequeID.Text);
                int Vint_IdItem = 136;

                //int Vint_Parent_ID = 6;

                var listItem = FsEvDb.Tbl_DocumentHirarchy.FirstOrDefault(x => x.ID == Vint_IdItem);

                //string Vstr_Name = "الوارده";

                //*********************عرض صورة الشيك
                t.pictureBox1.ImageLocation = null;
                //try
                //{
                t.pictureBox1.ImageLocation = null;
                try
                {

                    var listArchCheq = FsEvDb.Tbl_ArchTrCollectioCheque.FirstOrDefault(x => x.ChequeBankID == Vint_ID);
                    if (listArchCheq != null && !string.IsNullOrEmpty(listArchCheq.PathFile))
                    {
                        t.pictureBox1.ImageLocation = listArchCheq.PathFile;
                        t.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        // Handle case where image file path is empty or image does not exist
                        //MessageBox.Show("Image file path is empty or image does not exist.");
                        t.pdfViewer1.DocumentFilePath = listArchCheq.PathFile;
                    }


                    //var listArchCheq = FsEvDb.Tbl_ArchTrCollectioCheque.FirstOrDefault(x => x.ChequeBankID == Vint_ID);
                    //int Vint_IDArch = int.Parse(listArchCheq.ID.ToString());

                    //var list = FsEvDb.Tbl_ArchTrCollectioCheque.FirstOrDefault(x => x.ID == Vint_IDArch);


                    //if (list.PathFile != "")

                    //{
                    //t.pictureBox1.Dispose();
                    //t.pdfViewer1.DocumentFilePath = listArchCheq.PathFile;
                    //try
                    //{
                    //    Image originalImage = Image.FromFile(list.PathFile.ToString());
                    //    Image.FromFile(list.PathFile.ToString());
                    //    t.pictureBox1.Image = originalImage;
                    //    t.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    //}
                    //catch { }






                    //}
                }
                catch { }
                //**************************
                if ((Application.OpenForms["ShowScanDocuments"] as ShowScanDocuments != null))
                {
                    t.BringToFront();
                    //*********************
                    this.SendToBack();
                }
                else
                {
                    t.Show();
                    t.BringToFront();
                }

            }
            else
            {
                MessageBox.Show("من فضلك اختر الشيك المراد عرض صورته اولا");
            }

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 78 && w.ProcdureId == 4);
            if (validationSaveUser != null)
            {
                if (txtRowChequeID.Text != "")
                {
                    Vint_CheckRowID = int.Parse(txtRowChequeID.Text);
                    var listToDeleteCheq = FsDb.Tbl_BankCheques.FirstOrDefault(x => x.ID == Vint_CheckRowID);
                    var listToDeleteStCheq = FsDb.Tbl_ChequeBankStatusDates.FirstOrDefault(x => x.BankChequeID == Vint_CheckRowID);
                    var listToDeleteImgCheq = FsEvDb.Tbl_ArchTrCollectioCheque.FirstOrDefault(x => x.ChequeBankID == Vint_CheckRowID);
                    var listToDeleteRef = FsDb.Tbl_RefundCheque.FirstOrDefault(x => x.BankChequesID == Vint_CheckRowID);
                    var resultMessageYesNo = MessageBox.Show("هل تريد حدف هدا الشيك  ؟", "حدف  شيك ", MessageBoxButtons.YesNo);

                    if (resultMessageYesNo == DialogResult.Yes)
                    {
                        //if (listToDeleteStCheq != null)
                        //{
                        //    FsDb.Tbl_ChequeBankStatusDates.Remove(listToDeleteStCheq);
                        //}
                        if (listToDeleteImgCheq != null)
                        {
                            FsEvDb.Tbl_ArchTrCollectioCheque.Remove(listToDeleteImgCheq);
                        }

                        //if (listToDeleteRef != null)
                        //{
                        //    FsDb.Tbl_RefundCheque.Remove(listToDeleteRef);
                        //}
                        //if (listToDeleteCheq != null)
                        //{
                        //    FsDb.Tbl_BankCheques.Remove(listToDeleteCheq);
                        //}
                        var listToDelete = FsDb.Tbl_BankCheques.Where(x => x.ID == Vint_CheckRowID).Include(T => T.Tbl_ChequeBankStatusDates).Include(r => r.Tbl_RefundCheque).ToList();
                        FsDb.Tbl_BankCheques.RemoveRange(listToDelete);

                        FsDb.SaveChanges();

                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "حذف شيك",
                            TableName = "Tbl_BankCheques",
                            TableRecordId = Vint_CheckRowID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة الشيكات الوارده للخزينه"

                        };

                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //************************************
                        MessageBox.Show("تم الحذف");
                        ClearDataDetails();
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
                        dataGridView1.DataSource = listBnkCheque;
                        dataGridView3.DataSource = listBnkCheque;
                        LoadSerial();
                        LoadSerial3();
                        GrdBnkCheq();
                        GrdBnkCheq3();
                        txtAmount.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية حذف  شيك .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 78 && w.ProcdureId == 3);
            if (validationSaveUser != null)
            {
                if (txtRowID.Text != "")
                {
                    Vlng_LastRowTreasuryCollection = long.Parse(txtRowID.Text);
                    var ListTrCollection = FsDb.Tbl_TreasuryCollection.FirstOrDefault(x => x.ID == Vlng_LastRowTreasuryCollection);
                    if (cmbBnkDeposit.SelectedValue != null)
                    {
                        ListTrCollection.BankDepositeID = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                        ListTrCollection.BankAccounNoID = int.Parse(comboBox1.SelectedValue.ToString());
                    }
                    if (txtCollectionNo.Text != "")
                    { ListTrCollection.CollectionNo = txtCollectionNo.Text; }

                    ListTrCollection.CollectionDate = Convert.ToDateTime(dTPCollection.Value.ToString());
                    ListTrCollection.AddRecievedDate = Convert.ToDateTime(dTPAddRecievedDate.Value.ToString());

                    ListTrCollection.BranchID = int.Parse(txtBranchID.Text);
                    if (txtRepresentiveID.Text != "")
                    { ListTrCollection.RepresentiveID = int.Parse(txtRepresentiveID.Text); }

                    if (txtTradeCollectionNO.Text != "")
                    { ListTrCollection.TradeCollectionNo = txtTradeCollectionNO.Text; }

                    if (txtReceiptNo.Text != "")
                    { ListTrCollection.ReceiptNo = txtReceiptNo.Text; }
                    if (ListTrCollection.AddRecievedDate != dTPAddRecievedDate.Value)
                    {
                        var listStatus = FsDb.Tbl_ChequeBankStatusDates.Include(z => z.Tbl_BankCheques).FirstOrDefault(x => x.Tbl_BankCheques.TreasuryCollectionID == Vlng_LastRowTreasuryCollection);
                        if (listStatus != null)
                        { listStatus.ChequeBankStatusDate = Convert.ToDateTime(dTPAddRecievedDate.Value.ToString()); }
                    }
                    FsDb.SaveChanges();
                    //**************************البنك المودع  وتاريح الايداع
                    int Vint_bankDepositID = 0;

                    var listDateDeposit = FsDb.Tbl_TreasuryCollection.Where(x => x.ID == Vlng_LastRowTreasuryCollection).ToList();
                    if (listDateDeposit != null)
                    {
                        Vint_bankDepositID = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                        if (Vint_bankDepositID == 2004)
                        { Vint_bankDepositID = 1; }
                        else if (Vint_bankDepositID == 2014)
                        { Vint_bankDepositID = 2013; }

                    }
                    //******************************حساب تاريخ اضافة الشيك للحساب البنكي
                    int Vint_bankdrawnonid = 0;
                    var listCheqTrColl = FsDb.Tbl_BankCheques.Where(x => x.TreasuryCollectionID == Vlng_LastRowTreasuryCollection).ToList();
                    foreach (var value in listCheqTrColl)
                    {
                        if (value.ChequeStatusID == 2)
                        {
                            DateAddedStatlmentCs dateAddedStatlment = new DateAddedStatlmentCs();
                            DateTime Vd_chequDueDate = Convert.ToDateTime(value.ChequeDueDate.Value.ToString());
                            Vint_bankdrawnonid = int.Parse(value.BankDrawnOnID.ToString());

                            DateTime Vdt_DepositDate = Convert.ToDateTime(listDateDeposit[0].DepositDate.Value.ToString());
                            string result = dateAddedStatlment.SelectDateAddedBank(Vd_chequDueDate, Vdt_DepositDate, Vint_bankDepositID, Vint_bankdrawnonid);
                            value.AddDateAccBank = Convert.ToDateTime(result);
                            FsDb.SaveChanges();
                        }
                    }
                    //************************
                    FsDb.SaveChanges();
                    MessageBox.Show("تم التعديل");
                    txtAmount.Focus();
                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية تعديل  حافظه .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 78 && w.ProcdureId == 4);
            if (validationSaveUser != null)
            {
                if (txtRowID.Text != "")
                {
                    Vlng_LastRowTreasuryCollection = int.Parse(txtRowID.Text);
                    var listToDeleteCheq = FsDb.Tbl_TreasuryCollection.FirstOrDefault(x => x.ID == Vlng_LastRowTreasuryCollection);
                    var resultMessageYesNo = MessageBox.Show("هل تريد حذف هده الحافظه  ؟", "حدف  حافظه ", MessageBoxButtons.YesNo);

                    if (resultMessageYesNo == DialogResult.Yes)
                    {
                        var listDeletechuqes = FsDb.Tbl_BankCheques.Where(x => x.TreasuryCollectionID == Vlng_LastRowTreasuryCollection).ToList();
                        for (int i = 0; i < listDeletechuqes.Count; i++)
                        {
                            long VLnt_Cheq_1d = 0;
                            VLnt_Cheq_1d = long.Parse(listDeletechuqes[i].ID.ToString());
                            var listDeleteStatusCheq = FsDb.Tbl_ChequeBankStatusDates.Where(x => x.BankChequeID == VLnt_Cheq_1d).ToList();
                            FsDb.Tbl_ChequeBankStatusDates.RemoveRange(listDeleteStatusCheq);
                            FsDb.SaveChanges();
                        }
                        FsDb.Tbl_BankCheques.RemoveRange(listDeletechuqes);
                        FsDb.Tbl_TreasuryCollection.Remove(listToDeleteCheq);
                        FsDb.SaveChanges();

                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "حذف حافظه / شيكات",
                            TableName = "Tbl_TreasuryCollection",
                            TableRecordId = Vint_CheckRowID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة الشيكات الوارده للخزينه"

                        };

                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //************************************
                        MessageBox.Show("تم الحذف");

                        ClearDataMaster();
                        ClearDataDetails();
                        if (Vint_ChequeReceivedKindID == 0)
                        { GrdTrCollectionBr(); }
                        else
                        { GrdTrCollectionDr(); }
                        dataGridView1.DataSource = null;
                        txtBranch.Focus();
                        groupControl3.Text = "";
                        groupControl4.Text = "";
                        textBox1.Text = "";
                        textBox2.Text = "";
                        txtNotCheqAudit.Text = "";

                        txtAmount.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية حذف  حافظه .. برجاء مراجعة مدير المنظومه");
            }
        }



        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ClearDataMaster();
                ClearDataDetails();
                textBox6.Text = "";
                textBox7.Text = "";
                dataGridView1.DataSource = null;
                vdate_CollectionDate = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy/MM/dd"));
                if (Vint_ChequeReceivedKindID == 0 && checkBox2.Checked == false)
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
                else if (Vint_ChequeReceivedKindID == 1 && checkBox2.Checked == false)
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

        private void ChequeFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                //simpleButton4_Click(sender,e);
                ClearDataMaster();
                ClearDataDetails();
                if (Vint_ChequeReceivedKindID == 0)
                { GrdTrCollectionBr(); }
                else
                { GrdTrCollectionDr(); }
                dataGridView1.DataSource = null;
                txtBranch.Focus();
                groupControl3.Text = "";
                groupControl4.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                txtNotCheqAudit.Text = "";
                txtAllValueBeforeall.Text = "";
                textBox5.Text = "";
            }

        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            Forms.Banks.TreasuryCollectionCreateFrm t = new Forms.Banks.TreasuryCollectionCreateFrm();

            if ((Application.OpenForms["TreasuryCollectionCreateFrm"] as ShowScanDocuments != null))
            {
                t.BringToFront();
                this.SendToBack();
            }
            else
            {
                t.Show();
                t.BringToFront();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ClearDataMaster();
                ClearDataDetails();
                textBox6.Text = "";
                textBox7.Text = "";
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

        private void textBox4_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 1000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر (Enter) بعد ادخال الرقم التجاري للحافظه", TB, 0, 0, VisibleTime);
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (Vint_ChequeReceivedKindID == 0)
                {
                    Forms.BasicCodeForms.FindBranchFrm t = new Forms.BasicCodeForms.FindBranchFrm();

                    t.ShowDialog();
                    if (Forms.BasicCodeForms.FindBranchFrm.SelectedRow != null)
                    {
                        textBox6.Text = Forms.BasicCodeForms.FindBranchFrm.SelectedRow.Cells[1].Value.ToString();
                        textBox7.Text = Forms.BasicCodeForms.FindBranchFrm.SelectedRow.Cells[0].Value.ToString();
                        vdate_CollectionDate = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy/MM/dd"));
                        groupControl4.Text = $"حوافظ فرع {textBox6.Text} ";

                        Vint_BranchID = int.Parse(textBox7.Text);
                        var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                    join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                    join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                    //join Rpsntv in FsDb.Tbl_Representatives on TRC.RepresentiveID equals Rpsntv.ID
                                    //join BnkAcct in FsDb.Tbl_AccountsBank on TRC.BankAccounNoID equals BnkAcct.ID
                                    where (TRC.BranchID == Vint_BranchID && TRC.ChequeReceivedKindID == 0 && TRC.CollectionDate == vdate_CollectionDate)
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
                                        DepositDate = TRC.DepositDate,
                                        Name = BNK.Name,
                                        RepresentiveID = TRC.RepresentiveID,
                                        //RepresentiveName = Rpsntv.Name
                                    }).OrderBy(x => x.ID).ToList();
                        //*********************
                        dataGridView2.DataSource = list;

                        TotalChequeCollection();

                        LoadSerial2();
                        GrdTRCollctionCheq();
                        //**********
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
                        dataGridView2.Focus();
                    }

                }
                if (Vint_ChequeReceivedKindID == 1)
                {
                    Forms.BasicCodeForms.FindDirectionFrm t = new Forms.BasicCodeForms.FindDirectionFrm();

                    t.ShowDialog();
                    if (Forms.BasicCodeForms.FindDirectionFrm.SelectedRow != null)
                    {
                        textBox6.Text = Forms.BasicCodeForms.FindDirectionFrm.SelectedRow.Cells[1].Value.ToString();
                        textBox7.Text = Forms.BasicCodeForms.FindDirectionFrm.SelectedRow.Cells[0].Value.ToString();
                        vdate_CollectionDate = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy/MM/dd"));
                        Vint_BranchID = int.Parse(textBox7.Text);
                        var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                    join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                    join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                    //join Rpsntv in FsDb.Tbl_Representatives on TRC.RepresentiveID equals Rpsntv.ID
                                    //join BnkAcct in FsDb.Tbl_AccountsBank on TRC.BankAccounNoID equals BnkAcct.ID
                                    where (TRC.BranchID == Vint_BranchID && TRC.ChequeReceivedKindID == 1 && TRC.CollectionDate == vdate_CollectionDate)
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
                                        Name = BNK.Name,
                                        RepresentiveID = TRC.RepresentiveID,
                                        //RepresentiveName = Rpsntv.Name
                                    }).OrderBy(x => x.ID).ToList();
                        //*********************
                        dataGridView2.DataSource = list;
                        TotalChequeCollection();
                        LoadSerial2();
                        GrdTRCollctionCheq();
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
                        groupControl4.Text = $"مستندات  {textBox6.Text} ";
                        dTPCollection.Select();
                        this.ActiveControl = dTPCollection;
                        dTPCollection.Focus();
                    }
                    dataGridView2.Focus();
                }
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 2000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لإختيار الفرع / الجهه", TB, 0, 0, VisibleTime);
        }

        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtRowID.Text != "")
            {
                Vlng_LastRowTreasuryCollection = long.Parse(txtRowID.Text);
                bool Vbl_TrcollectioCheq = false;
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 85 && w.ProcdureId == 1003);
                if (validationSaveUser != null)
                {

                    Vbl_TrcollectioCheq = true;
                    var ListTrcAuditOrdUser = FsDb.Tbl_TreasuryCollection_Audit.FirstOrDefault(x => x.TreasuryCollectionID == Vlng_LastRowTreasuryCollection && x.UserID == Program.GlbV_UserId);
                    if (ListTrcAuditOrdUser == null)

                    {
                        DateTime Vdt_Today = Convert.ToDateTime(Classes.GetServerDate.Cs_GetServerDate());
                        Tbl_TreasuryCollection_Audit AccRstAud = new Tbl_TreasuryCollection_Audit
                        {
                            UserID = Program.GlbV_UserId,
                            TreasuryCollectionID = Vlng_LastRowTreasuryCollection,
                            IsCheqBank = Vbl_TrcollectioCheq,
                            ReferenceDate = Vdt_Today
                        };
                        FsDb.Tbl_TreasuryCollection_Audit.Add(AccRstAud);
                        FsDb.SaveChanges();

                        int Vint_LastRow = AccRstAud.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة مراجعة شيكات حوافظ ",
                            TableName = "Tbl_AccountingRestriction_Audit",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Classes.GetServerDate.Cs_GetServerDate()),
                            //ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة مراجعة حوافظ الشيكات"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم الحفظ");
                        //****************Refrences***************
                        AccRstAuditSelect(Vlng_LastRowTreasuryCollection);
                        //***************************************
                    }
                    else
                    {
                        if (checkBox1.Checked == true)
                        {
                            Vbl_RestrictionDataID = true;
                        }
                        else
                        {
                            Vbl_RestrictionDataID = false;
                        }
                        DateTime Vdt_Today = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));

                        var ListOrderAuditOrdUsero = FsDb.Tbl_TreasuryCollection_Audit.FirstOrDefault(x => x.TreasuryCollectionID == Vlng_LastRowTreasuryCollection && x.UserID == Program.GlbV_UserId);
                        ListOrderAuditOrdUsero.IsCheqBank = Vbl_RestrictionDataID;
                        //ListOrderAuditOrdUsero.OrderIItemDataID = Vbl_itemso;
                        //ListOrderAuditOrdUsero.OrderITermsID = Vbl_termso;
                        ListOrderAuditOrdUsero.ReferenceDate = Vdt_Today;
                        FsDb.SaveChanges();
                        MessageBox.Show("تم التعديل");
                        //****************Refrences***************
                        AccRstAuditSelect(Vlng_LastRowTreasuryCollection);
                        //***************************************

                    }

                }

                else
                {
                    MessageBox.Show("ليس لديك صلاحية  مراجعه شيكات الحوافظ .. برجاء مراجعة مدير المنظومه");
                    checkBox1.Checked = false;
                }
            }
            else
            {
                MessageBox.Show(" من فضلك قم بإختيار الحافظه المراد مراجعتة شيكاتها اولا");
            }
        }

        private void txtNotCheqAudit_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            TB.SelectionLength = 0;
            int VisibleTime = 1000;
            ToolTip tt = new ToolTip();
            tt.Show("من فضلك سجل ملاحظات المراجعه على هذا الشيك ", TB, 0, 0, VisibleTime);
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            if (txtRowChequeID.Text != "")
            {



                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "JPEG Files (*.jpg)|*.jpg|All Files (*.*)|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    PicturePath.ImageLocation = dialog.FileName;
                    Image_Path = dialog.FileName;
                }
                if (Image_Path != "")
                {
                    long Vlng_IdItem = 0;
                    string Vstr_HirarckyID = "136";
                    string Vstr_ProcessKindID = "";
                    string Vstr_YearDate = "";
                    string Vstr_MonthDate = "";
                    string Vstr_IDCheque = "";

                    Vlng_IdItem = int.Parse(txtRowChequeID.Text);
                    if (Vlng_IdItem != 0)
                    {

                        Vstr_ProcessKindID = "6";

                        DateTime Vdt_DateP = Convert.ToDateTime(dTPDueDateScan.Value.ToString());



                        Vstr_YearDate = (Vdt_DateP.Year).ToString();

                        Vstr_MonthDate = (Vdt_DateP.Month).ToString();

                        Vstr_IDCheque = txtRowChequeID.Text;

                        string PathDirectory = @"\\30.30.30.5\FinancialScan\" + Vstr_ProcessKindID + textBox8.Text + Vstr_YearDate + textBox8.Text + Vstr_MonthDate + textBox8.Text + Vstr_IDCheque + textBox8.Text + Vstr_HirarckyID;

                        // string PathDirectory = @"I:\" + Vstr_ProcessKindID + textBox8.Text + Vstr_YearDate + textBox8.Text + Vstr_MonthDate + textBox8.Text + Vstr_IDCheque + textBox8.Text + Vstr_HirarckyID;


                        if (!Directory.Exists(PathDirectory))
                        {
                            try
                            {
                                Directory.CreateDirectory(PathDirectory);
                            }
                            catch (Exception ex)  // CS0168
                            {
                                MessageBox.Show(ex.Message);

                            }

                        }
                        //**************Create Files Of Scan *************
                        Vlng_IdItem = long.Parse(txtRowChequeID.Text);

                        var list = FsEvDb.Tbl_ArchTrCollectioCheque.Where(x => x.ChequeBankID == Vlng_IdItem && x.DocumentHirarchyID == 136).ToList();

                        if (list.Count == 0)
                        {
                            int Vint_count = 1;
                            string PathFile = PathDirectory + textBox8.Text + (Vint_count.ToString() + ".jpg");
                            string PathFile1 = PathDirectory + textBox8.Text + (Vint_count.ToString() + ".Pdf");

                            if (File.Exists(PathFile) || File.Exists(PathFile1))
                            {
                                File.Delete(PathFile);
                                File.Delete(PathFile1);
                            }


                            File.Copy(Image_Path, PathFile);


                            Tbl_ArchTrCollectioCheque ArchD = new Tbl_ArchTrCollectioCheque()
                            {
                                TrCollectionID = long.Parse(txtRowID.Text),
                                ChequeBankID = Vlng_IdItem,
                                DocumentHirarchyID = 136,
                                PathFile = PathFile
                            };
                            FsEvDb.Tbl_ArchTrCollectioCheque.Add(ArchD);
                            FsEvDb.SaveChanges();
                            MessageBox.Show($"تم حفظ الصوره");
                            Image_Path = "";
                        }
                        else
                        {
                            int Vint_count = 1;
                            string PathFile = PathDirectory + textBox8.Text + (Vint_count.ToString() + ".jpg");
                            string PathFile1 = PathDirectory + textBox8.Text + (Vint_count.ToString() + ".Pdf");


                            if (File.Exists(PathFile) || File.Exists(PathFile1))
                            {
                                File.Delete(PathFile);
                                File.Delete(PathFile1);
                            }


                            File.Copy(Image_Path, PathFile);


                            list[0].PathFile = PathFile;
                            FsEvDb.SaveChanges();
                            MessageBox.Show($"تم تعديل الصوره");
                            Image_Path = "";
                        }
                    }
                }


            }
            else
            {
                MessageBox.Show("من فضلك اختر الشيك المراد عرض صورته اولا");
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {

                Forms.DocumentsForms.CheqeesAuditFrm t = new Forms.DocumentsForms.CheqeesAuditFrm();
                t.txtCheqId.Text = this.txtRowChequeID.Text;
                t.txtCheqNo.Text = this.txtChequeNo.Text;

                t.dateTimePicker1.Value = this.dateTimePicker1.Value;
                if (txtRowChequeID.Text != "")
                {
                    t.ShowDialog();
                }
                else
                {
                    MessageBox.Show("من فضلك اختر الشيك المراد مراجعته اولا");
                }

            }
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRowChequeID.Text != "")
                {
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    openFileDialog1.Filter = "PDF Files|*.pdf";
                    openFileDialog1.Title = "Select a PDF File";

                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog1.FileName;


                        if (Path.GetExtension(filePath).ToLower() == ".pdf")
                        {

                            pdfViewer1.DocumentFilePath = filePath;
                            long Vlng_IdItem = 0;
                            string Vstr_HirarckyID = "136";
                            string Vstr_ProcessKindID = "";
                            string Vstr_YearDate = "";
                            string Vstr_MonthDate = "";
                            string Vstr_IDCheque = "";

                            Vlng_IdItem = int.Parse(txtRowChequeID.Text);
                            if (Vlng_IdItem != 0)
                            {

                                Vstr_ProcessKindID = "6";

                                DateTime Vdt_DateP = Convert.ToDateTime(dTPDueDateScan.Value.ToString());



                                Vstr_YearDate = (Vdt_DateP.Year).ToString();

                                Vstr_MonthDate = (Vdt_DateP.Month).ToString();

                                Vstr_IDCheque = txtRowChequeID.Text;

                                string PathDirectory = @"\\30.30.30.5\FinancialScan\" + Vstr_ProcessKindID + textBox8.Text + Vstr_YearDate + textBox8.Text + Vstr_MonthDate + textBox8.Text + Vstr_IDCheque + textBox8.Text + Vstr_HirarckyID;

                                //string PathDirectory = @"I:\" + Vstr_ProcessKindID + textBox8.Text + Vstr_YearDate + textBox8.Text + Vstr_MonthDate + textBox8.Text + Vstr_IDCheque + textBox8.Text + Vstr_HirarckyID;

                                if (!Directory.Exists(PathDirectory))
                                {
                                    try
                                    {
                                        Directory.CreateDirectory(PathDirectory);
                                    }
                                    catch (Exception ex)  // CS0168
                                    {
                                        MessageBox.Show(ex.Message);

                                    }

                                }
                                //**************Create Files Of Scan *************
                                Vlng_IdItem = long.Parse(txtRowChequeID.Text);

                                var list = FsEvDb.Tbl_ArchTrCollectioCheque.Where(x => x.ChequeBankID == Vlng_IdItem && x.DocumentHirarchyID == 136).ToList();

                                if (list.Count == 0)
                                {
                                    int Vint_count = 1;
                                    string PathFile = PathDirectory + textBox8.Text + (Vint_count.ToString() + ".Pdf");
                                    string PathFile1 = PathDirectory + textBox8.Text + (Vint_count.ToString() + ".jpg");
                                    while (File.Exists(PathFile) || File.Exists(PathFile1))
                                    {
                                        Vint_count++;
                                        PathFile = PathDirectory + textBox8.Text + (Vint_count.ToString() + ".Pdf");
                                        PathFile = PathDirectory + textBox8.Text + (Vint_count.ToString() + ".jpg");
                                    }

                                    if (File.Exists(PathFile) || File.Exists(PathFile1))
                                    {
                                        pdfViewer1.DocumentFilePath = null;
                                        File.Delete(PathFile);
                                        File.Delete(PathFile1);
                                    }

                                    File.Copy(filePath, PathFile);

                                    Tbl_ArchTrCollectioCheque ArchD = new Tbl_ArchTrCollectioCheque()
                                    {
                                        TrCollectionID = long.Parse(txtRowID.Text),
                                        ChequeBankID = Vlng_IdItem,
                                        DocumentHirarchyID = 136,
                                        PathFile = PathFile
                                    };
                                    FsEvDb.Tbl_ArchTrCollectioCheque.Add(ArchD);
                                    FsEvDb.SaveChanges();
                                    MessageBox.Show($"تم حفظ الملف");
                                    PathFile = "";
                                }
                                else
                                {
                                    int Vint_count = 1;
                                    string PathFile = PathDirectory + textBox8.Text + (Vint_count.ToString() + ".Pdf");
                                    string PathFile1 = PathDirectory + textBox8.Text + (Vint_count.ToString() + ".jpg");
                                    list[0].PathFile = PathFile;


                                    if (File.Exists(PathFile) || File.Exists(PathFile1))
                                    {
                                        pdfViewer1.DocumentFilePath = null;
                                        File.Delete(PathFile);
                                        File.Delete(PathFile1);
                                    }

                                    File.Copy(filePath, PathFile);

                                    FsEvDb.SaveChanges();
                                    MessageBox.Show($"تم تعديل الملف");
                                    PathFile = "";
                                }


                            }

                        }
                        else
                        {
                            MessageBox.Show("الرجاء اختيار ملف بصيغة PDF.");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("من فضلك اختر الشيك المراد عرض صورته اولا");
                }

            }
            catch
            {

            }
        }

        private void groupControl4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupControl5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTradeCollectionNO.Focus();
            }
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

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
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

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ClearDataMaster();
                ClearDataDetails();
                textBox6.Text = "";
                textBox7.Text = "";
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

        private void checkBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (Vint_ChequeReceivedKindID == 0 && checkBox2.Checked == true)
            {
                if (textBox4.Text != "")
                {
                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID

                                where (TRC.ChequeReceivedKindID == Vint_ChequeReceivedKindID && TRC.CollectionDate == vdate_CollectionDate && TRC.TradeCollectionNo == textBox4.Text)
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
                else
                {
                    MessageBox.Show("من فضلك ادخل رقم الحافظه التجاري");

                    textBox4.Focus();
                    checkBox2.Checked = false;
                }
            }
        }
    }
}
