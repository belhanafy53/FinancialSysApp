using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using FinancialSysApp.Classes;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using FinancialSysApp.Forms.DocumentsForms;
using Infragistics.Win.Description;

namespace FinancialSysApp.Forms.BasicCodeForms
{
    public partial class LetterWarrantyFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int? Vint_LetterWarantyID = null;
        int? Vint_LetterWarantyKind = null;
        int? Vint_LetterProcessID = null;
        int? Vint_LetterWarrantyKind = null;
        int? Vint_BankID = null;
        int? Vint_SuppID = null;
        int? Vint_MngID = null;
        decimal? Vdecm_ValueLetter = 0;
        int? Vint_currency = null;
        DateTime? Vdate_LetterStrtDate = null;
        DateTime? Vdate_LetterExptDate = null;
        int? Vint_ProjectId = null;
        int? Vint_ManagementExportLetterId = null;
        int? Vint_FileNO = null;
        long? Vlng_OrderID = 0;
        int? Vint_Tender = null;
        int? Vint_AssayesID = null;
        int? Vint_ResponsipilityDecisionID = null;
        string VDate_LetterWDateRecieved = "";
        int? Vint_FinancialMember = null;
        int? Vint_BeneficiaryID = null;
        bool? Vbl_ConfLetterWarrantyExpireDate = null;
        bool? Vbl_ConfValue = null;
        bool? Vbl_ConfTender = null;
        bool? Vbl_ConfRecieveLetter = null;

        //Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"))
        public LetterWarrantyFrm()
        {
            InitializeComponent();
        }
        private void ClearData()
        {
            txtLetterWId.Text = "";
            cmbLetterKind.SelectedIndex = -1;
            cmbLetterKind.Text = "";
            cmbLetterKind.SelectedText = "اختر نوع الحطاب";


            cmbPurchMethod.SelectedIndex = -1;
            cmbPurchMethod.Text = "";
            cmbPurchMethod.SelectedText = "اختر طريقة الشراء";

            cmbOrderKind.SelectedIndex = -1;
            cmbOrderKind.Text = "";
            cmbOrderKind.SelectedText = "اختر نوع الامر";

            cmbCurrency.SelectedIndex = -1;

            cmbCurrency.SelectedText = "اختر العمله";
            txtLetterWarrantyNo.Text = "";
            txtLetterWarrantyNoScnd.Text = "";
            txtLetterWarrantyNoFull.Text = "";

            cmbResponspility.SelectedIndex = -1;
            cmbResponspility.Text = "";
            cmbResponspility.SelectedText = "اختر اللجنه";

            txtBankID.Text = "";
            txtBank.Text = "";
            txtSuplierID.Text = "";
            txtSupliers.Text = "";
            txtManagement.Text = "";
            txtManagement.Text = "";
            txtLetterValue.Text = "";


            dtpLetterDate.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
            Vdate_LetterExptDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
            dTPExpireLetterDate.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
            txtProjectId.Text = "";
            txtProject.Text = "";
            txtletterExportManagementID.Text = "";
            txtletterExportManagement.Text = "";
            txtFileNo.Text = "";
            txtOrderID.Text = "";
            txtOrderNo.Text = "";
            dTPOrderDate.Text = "";
            dtpResponsipilityDecision.Text = "";
            txtTenderID.Text = "";
            txtAssayesId.Text = "";
            txtResponsipilityDecisionID.Text = "";
            DtpTender.Text = "";
            txtTenderNo.Text = "";
            txtTenderPurpose.Text = "";

            dTPLetterWDateRecieved.Text = "";
            txtFinancialMemberID.Text = "";
            txtFinancialMember.Text = "";
            txtBenefcieryID.Text = "";
            txtLetterWarrantyPurpose.Text = "";
            label30.Visible = false;
            txtFinancialMember.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;


        }

        private void LoopPaintRowLettersState()
        {
            txtTotalRef.Text = "";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {


                Vint_LetterWarantyID = int.Parse(row.Cells[0].Value.ToString());

                var Vint_ListLettrRefund = FsDb.Tbl_RefundLetter.FirstOrDefault(x => x.LetterWarrantyID == Vint_LetterWarantyID);
                if (Vint_ListLettrRefund != null)
                {

                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                    if (txtTotalRef.Text == "")
                    {
                        txtTotalRef.Text = "0";
                    }
                    txtTotalRef.Text = (Convert.ToDecimal(row.Cells[7].Value.ToString()) + Convert.ToDecimal(txtTotalRef.Text)).ToString();
                    if (txtTotal.Text != "" && txtTotalRef.Text != "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtTotalRef.Text)).ToString(); }
                    else if (txtTotal.Text != "" && txtTotalRef.Text == "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text)).ToString(); }
                }

            }
            txtLettrCount.Text = (from DataGridViewRow row in dataGridView1.Rows
                                  select Convert.ToDouble(row.Cells[7].Value)).Count().ToString();
        }
        private void FillData(int Vint_LetterID)
        {
            var ListLettersWarrenty = FsDb.Tbl_LetterWarranty.FirstOrDefault(x => x.ID == Vint_LetterID);
            if (ListLettersWarrenty != null)
            {
                cmbLetterKind.SelectedValue = ListLettersWarrenty.LetterWarrantyKind;

                if (ListLettersWarrenty.OrderID != null && ListLettersWarrenty.OrderID != 0)
                {
                    var ListOrder = FsDb.Tbl_Order.FirstOrDefault(x => x.OrderID == ListLettersWarrenty.OrderID);
                    if (ListOrder != null)
                    {
                        cmbPurchMethod.SelectedValue = ListOrder.PurchaseMethodsID;
                        cmbOrderKind.SelectedIndex = ListOrder.OrderKind_ID;
                        txtOrderID.Text = ListOrder.OrderID.ToString();
                        txtOrderNo.Text = ListOrder.Order_NO;
                    }
                }
                if (ListLettersWarrenty.CurrencyID != null)
                {
                    cmbCurrency.SelectedValue = ListLettersWarrenty.CurrencyID;
                }

                txtLetterWarrantyNo.Text = ListLettersWarrenty.LetterWarrantyNo.ToString();
                txtLetterWarrantyNoScnd.Text = ListLettersWarrenty.LetterWarrantyNoScnd.ToString();
                txtLetterWarrantyNoFull.Text = ListLettersWarrenty.LetterWarrantyNoFull.ToString();
                if (ListLettersWarrenty.ProjectID != null && ListLettersWarrenty.ProjectID != 0)
                {
                    Vint_ProjectId = int.Parse(ListLettersWarrenty.ProjectID.ToString());
                    var Lprjct = FsDb.Tbl_Projects.FirstOrDefault(x => x.ID == Vint_ProjectId);
                    txtProject.Text = Lprjct.Name;
                }

                if (ListLettersWarrenty.BankID != null && ListLettersWarrenty.BankID != 0)
                {
                    Vint_BankID = int.Parse(ListLettersWarrenty.BankID.ToString());
                    txtBankID.Text = ListLettersWarrenty.BankID.ToString();
                    var LBank = FsDb.Tbl_Banks.FirstOrDefault(x => x.ID == Vint_BankID);
                    txtBank.Text = LBank.Name;
                }
                if (ListLettersWarrenty.SupID != null && ListLettersWarrenty.SupID != 0)
                {
                    Vint_SuppID = int.Parse(ListLettersWarrenty.SupID.ToString());
                    txtSuplierID.Text = ListLettersWarrenty.SupID.ToString();
                    var Lsup = FsDb.Tbl_Supplier.FirstOrDefault(x => x.ID == Vint_SuppID);
                    if (Lsup != null)
                    { txtSupliers.Text = Lsup.Name; }
                }
                if (ListLettersWarrenty.ManagementID != null && ListLettersWarrenty.ManagementID != 0)
                {

                    Vint_ManagementExportLetterId = int.Parse(ListLettersWarrenty.ManagementID.ToString());
                    txtManagementID.Text = ListLettersWarrenty.ManagementID.ToString();
                    var LMng = FsDb.Tbl_Management.FirstOrDefault(x => x.Management_ID == Vint_ManagementExportLetterId);
                    txtManagement.Text = LMng.Name;
                }
                txtLetterValue.Text = ListLettersWarrenty.Value.ToString();
                cmbCurrency.SelectedValue = ListLettersWarrenty.CurrencyID;

                if (ListLettersWarrenty.LetterWarrantyDate != null)
                { dtpLetterDate.Value = Convert.ToDateTime(ListLettersWarrenty.LetterWarrantyDate.ToString("yyyy/MM/dd")); }
                if (ListLettersWarrenty.LetterWarrantyExpireDate != null)
                { dTPExpireLetterDate.Value = Convert.ToDateTime(ListLettersWarrenty.LetterWarrantyExpireDate.Value.ToString("yyyy/MM/dd")); }


                if (ListLettersWarrenty.ProjectID != null && ListLettersWarrenty.ProjectID != 0)
                {
                    Vint_ProjectId = int.Parse(ListLettersWarrenty.ProjectID.ToString());
                    txtProjectId.Text = ListLettersWarrenty.ProjectID.ToString();
                    var Lprj = FsDb.Tbl_Projects.FirstOrDefault(x => x.ID == Vint_ProjectId);
                    txtProject.Text = Lprj.Name;
                }



                txtFileNo.Text = ListLettersWarrenty.FileNo.ToString();
                txtFileNoSec.Text = ListLettersWarrenty.LetterWarrantyKind.ToString();
                if (ListLettersWarrenty.OrderID != null && ListLettersWarrenty.OrderID != 0)
                {
                    txtOrderID.Text = ListLettersWarrenty.OrderID.ToString();
                    Vlng_OrderID = int.Parse(txtOrderID.Text);
                    var listorder = FsDb.Tbl_Order.FirstOrDefault(x => x.ID == Vlng_OrderID);
                    txtOrderNo.Text = listorder.Order_NO.ToString();
                    cmbOrderKind.SelectedValue = int.Parse(listorder.OrderKind_ID.ToString());
                    dTPOrderDate.Text = listorder.Order_Date.ToString("yyyy/MM/dd");
                }
                if (ListLettersWarrenty.TendersAuctionsID != null && ListLettersWarrenty.TendersAuctionsID != 0)
                {
                    txtTenderID.Text = ListLettersWarrenty.TendersAuctionsID.ToString();
                    Vint_Tender = int.Parse(txtTenderID.Text);
                    var listtender = FsDb.Tbl_TendersAuctions.FirstOrDefault(x => x.ID == Vint_Tender);
                    txtTenderNo.Text = listtender.TenderNo.ToString();
                    DtpTender.Text = listtender.TenderDate.ToString("yyyy/MM/dd");
                    cmbPurchMethod.SelectedValue = int.Parse(listtender.PurchaseMethodeID.ToString());
                    txtTenderPurpose.Text = listtender.Note.ToString();
                }
                if (ListLettersWarrenty.AssayesID != null && ListLettersWarrenty.AssayesID != 0)
                {
                    txtAssayesId.Text = ListLettersWarrenty.AssayesID.ToString();
                    Vint_AssayesID = int.Parse(txtTenderID.Text);
                    var listAssayes = FsDb.Tbl_Assays.FirstOrDefault(x => x.ID == Vint_AssayesID);
                    if (listAssayes != null)
                    {
                        txtAssayesNo.Text = listAssayes.AssaysNo.ToString();
                        dTPAssayesDate.Text = listAssayes.AssaysDate.ToString();
                    }

                }
                if (ListLettersWarrenty.DecisionsResponspilitiesID != null && ListLettersWarrenty.DecisionsResponspilitiesID != 0)
                {
                    var listDec = FsDb.Tbl_DecisionsResponspilities.FirstOrDefault(x => x.ID == ListLettersWarrenty.DecisionsResponspilitiesID);
                    cmbResponspility.SelectedValue = listDec.ResponspilityCentersID;
                    txtResponsipilityDecisionID.Text = listDec.ID.ToString();
                    txtResponsipilityDecisionNo.Text = listDec.DecisionNO.ToString();
                    txtForYear.Text = listDec.ForYear.ToString();

                }

                if (ListLettersWarrenty.LetterWDateRecieved != null)
                {
                    dTPLetterWDateRecieved.Text = ListLettersWarrenty.LetterWDateRecieved.ToString();
                }
                if (ListLettersWarrenty.FinancialMember != null && ListLettersWarrenty.FinancialMember != 0)
                {
                    txtFinancialMemberID.Text = ListLettersWarrenty.FinancialMember.ToString();
                    Vint_FinancialMember = int.Parse(txtFinancialMemberID.Text);
                    var listFinancialMember = FsDb.Tbl_Employee.FirstOrDefault(x => x.ID == Vint_FinancialMember);
                    txtFinancialMember.Text = listFinancialMember.Name.ToString();
                }
                if (ListLettersWarrenty.BeneficiaryID != null && ListLettersWarrenty.BeneficiaryID != 0)
                {
                    txtBenefcieryID.Text = ListLettersWarrenty.BeneficiaryID.ToString();
                    Vint_BeneficiaryID = int.Parse(txtBenefcieryID.Text);
                    var listBenefciery = FsDb.Tbl_Beneficiary.FirstOrDefault(x => x.ID == Vint_BeneficiaryID);
                    txtSupliers.Text = listBenefciery.Name.ToString();
                }
                if (ListLettersWarrenty.ConfLetterWarrantyExpireDate != null)
                {
                    checkBox1.Checked = Convert.ToBoolean(ListLettersWarrenty.ConfLetterWarrantyExpireDate);
                }
                if (ListLettersWarrenty.ConfValue != null)
                {
                    checkBox2.Checked = Convert.ToBoolean(ListLettersWarrenty.ConfValue);
                }
                if (ListLettersWarrenty.ConfTender != null)
                {
                    checkBox3.Checked = Convert.ToBoolean(ListLettersWarrenty.ConfTender);
                }
                if (ListLettersWarrenty.LetterWarrantyPurpose != null)
                {
                    txtLetterWarrantyPurpose.Text = ListLettersWarrenty.LetterWarrantyPurpose.ToString();
                }
            }
        }


        private void LetterWarrantyFrm_Load(object sender, EventArgs e)
        {
            Vint_LetterProcessID = radioGroup1.SelectedIndex;
            // TODO: This line of code loads data into the 'letterWarranty.Dtb_WarrantyLetter' table. You can move, or remove it, as needed.
            //this.dtb_WarrantyLetterTableAdapter.Fill(this.letterWarranty.Dtb_WarrantyLetter, Vint_LetterProcessID);
            // TODO: This line of code loads data into the 'letterWarranty.Dtb_WarrantyLetter' table. You can move, or remove it, as needed.
            //this.dtb_WarrantyLetterTableAdapter.Fill(this.letterWarranty.Dtb_WarrantyLetter);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_LetterWarranty' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_LetterWarrantyKind' table. You can move, or remove it, as needed.
            this.tbl_LetterWarrantyKindTableAdapter.Fill(this.financialSysDataSet.Tbl_LetterWarrantyKind);

            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Currency' table. You can move, or remove it, as needed.
            this.tbl_CurrencyTableAdapter.Fill(this.financialSysDataSet.Tbl_Currency);
            // TODO: This line of code loads data into the 'financialSysDataSet1.Tbl_PurchaseMethods' table. You can move, or remove it, as needed.
            this.tbl_PurchaseMethodsTableAdapter.Fill(this.financialSysDataSet1.Tbl_PurchaseMethods);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_OrderKind' table. You can move, or remove it, as needed.
            this.tbl_OrderKindTableAdapter.Fill(this.financialSysDataSet.Tbl_OrderKind);

            this.tbl_ResponspilityCentersTableAdapter.Fill(this.financialSysDataSet.Tbl_ResponspilityCenters);
            //******* Min Value **************Max Value ****************
            LoopPaintRowLettersState();
            //*************************
            //radioGroup2.SelectedIndex = 0;
            ClearData();
            checkData();
            checkBox4.Checked = true;

            if (dataGridView1.RowCount > 0)
            {
                txtTotal.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                            select Convert.ToDouble(row.Cells[7].Value)).Sum(), 3).ToString();
                if (txtTotalRef.Text == "")
                {
                    txtTotalRef.Text = "0";
                }
                if (txtTotal.Text != "" && txtTotalRef.Text != "")
                { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtTotalRef.Text)).ToString(); }
                else if (txtTotal.Text != "" && txtTotalRef.Text == "")
                { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text)).ToString(); }
                txtLettrCount.Text = (from DataGridViewRow row in dataGridView1.Rows
                                      select Convert.ToDouble(row.Cells[7].Value)).Count().ToString();
                if (Vint_LetterProcessID == 1)
                {
                    //dataGridView1.Columns["BenfcName"].Visible = true;
                    //dataGridView1.Columns["SupplierName"].Visible = false;
                }
                else
                {
                    //dataGridView1.Columns["BenfcName"].Visible = false;
                    //dataGridView1.Columns["SupplierName"].Visible = true;
                }
            }
        }
        private void checkData()
        {
            if (radioGroup1.SelectedIndex == 1)
            {
                label19.Visible = false;
                cmbOrderKind.Visible = false;
                label13.Visible = false;
                cmbPurchMethod.Visible = false;
                label20.Visible = false;
                label18.Visible = false;
                txtOrderNo.Visible = false;
                dTPOrderDate.Visible = false;
                txtTenderNo.Visible = false;
                label12.Visible = false;
                label17.Visible = false;
                label28.Visible = false;
                label29.Visible = false;
                label36.Visible = false;
                txtAssayesNo.Visible = false;
                dTPAssayesDate.Visible = false;
                DtpTender.Visible = false;
                txtTenderPurpose.Visible = false;
                label33.Visible = false;
                label34.Visible = false;
                cmbResponspility.Visible = false;
                txtForYear.Visible = false;
                txtTenderPurpose.Visible = false;
                label27.Visible = false;
                label26.Visible = false;
                label38.Visible = false;
                txtResponsipilityDecisionNo.Visible = false;
                dtpResponsipilityDecision.Visible = false;
                dTPLetterWDateRecieved.Visible = false;
                txtFinancialMember.Visible = false;
                label37.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                label30.Visible = false;
                txtletterExportManagement.Visible = false;
                label11.Text = "المستفيد";
                txtManagement.Text = "الإدارة العامة لحسابات الأعمال الخارجية";
                txtManagementID.Text = "1697";
                txtBank.Text = "البنك الاهلى المتحد فرع الزمالك";
                txtBankID.Text = "2065";
                cmbCurrency.SelectedValue = 1;
                label25.Visible = false;
                decimal minValue = Convert.ToDecimal(FsDb.Tbl_LetterWarranty.Where(x => x.LetterProcessID == 1).Select(p => p.Value).DefaultIfEmpty(0).Min().ToString());
                decimal maxValue = Convert.ToDecimal(FsDb.Tbl_LetterWarranty.Where(x => x.LetterProcessID == 1).Select(p => p.Value).DefaultIfEmpty(0).Max().ToString());
                textBox3.Text = minValue.ToString();
                textBox5.Text = maxValue.ToString();
            }
            else
            {
                txtManagement.Text = "اداره العقود المحلية و التشهيلات";
                txtManagementID.Text = "5139";
                cmbCurrency.SelectedValue = 1;
                decimal minValue = Convert.ToDecimal(FsDb.Tbl_LetterWarranty.Where(x => x.LetterProcessID == 0).Select(p => p.Value).DefaultIfEmpty(0).Min().ToString());
                decimal maxValue = Convert.ToDecimal(FsDb.Tbl_LetterWarranty.Where(x => x.LetterProcessID == 0).Select(p => p.Value).DefaultIfEmpty(0).Max().ToString());
                textBox3.Text = minValue.ToString();
                textBox5.Text = maxValue.ToString();
            }
        }
        private void txtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtManagement.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (radioGroup1.SelectedIndex == 1)
                {
                    Forms.ProcessingForms.FindBeneficiaryFrm t = new Forms.ProcessingForms.FindBeneficiaryFrm();

                    t.ShowDialog();
                    if (Forms.ProcessingForms.FindBeneficiaryFrm.SelectedRow != null)
                    {
                        txtSupliers.Text = Forms.ProcessingForms.FindBeneficiaryFrm.SelectedRow.Cells[1].Value.ToString();
                        txtBenefcieryID.Text = Forms.ProcessingForms.FindBeneficiaryFrm.SelectedRow.Cells[0].Value.ToString();
                        txtSuplierID.Text = Forms.ProcessingForms.FindBeneficiaryFrm.SelectedRow.Cells[5].Value.ToString();
                    }
                }
                else

                {
                    Forms.ProcessingForms.FindSupliersFrm t = new Forms.ProcessingForms.FindSupliersFrm();

                    t.ShowDialog();
                    if (Forms.ProcessingForms.FindSupliersFrm.SelectedRow != null)
                    {
                        txtSupliers.Text = Forms.ProcessingForms.FindSupliersFrm.SelectedRow.Cells[1].Value.ToString();
                        txtSuplierID.Text = Forms.ProcessingForms.FindSupliersFrm.SelectedRow.Cells[0].Value.ToString();

                    }
                }
                txtManagement.Focus();
            }
        }

        private void txtSupliers_Enter(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 1)
            {
                TextBox TB = (TextBox)sender;
                int VisibleTime = 2000;
                ToolTip tt = new ToolTip();
                tt.Show("اضغط على زر السهم لاسفل لاختيار المستفيد", TB, 0, 0, VisibleTime);
            }
            else
            {
                TextBox TB = (TextBox)sender;
                int VisibleTime = 2000;
                ToolTip tt = new ToolTip();
                tt.Show("اضغط على زر السهم لاسفل لاختيار المورد", TB, 0, 0, VisibleTime);
            }
        }

        private void txtManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLetterValue.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                Forms.BasicCodeForms.FindManagementFrm M = new Forms.BasicCodeForms.FindManagementFrm();

                M.ShowDialog();
                if (M.txtManagementId.Text != "")
                {
                    txtManagement.Text = M.txtSelected.Text;
                    txtManagementID.Text = M.txtManagementId.Text;

                }
                txtLetterValue.Focus();
            }
        }

        private void txtManagement_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 2000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لاختيار الادارة", TB, 0, 0, VisibleTime);
        }

        private void txtTenderNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAssayesNo.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {

                Forms.ProcessingForms.FindTendersFrm t = new Forms.ProcessingForms.FindTendersFrm();
                if (cmbPurchMethod.SelectedValue != null)
                {

                    t.textEdit1.Text = this.cmbPurchMethod.SelectedValue.ToString();
                    t.comboBox1.SelectedValue = this.cmbPurchMethod.SelectedValue.ToString();
                    t.txtpurchMethodName.Text = this.cmbPurchMethod.Text;
                    t.ShowDialog();

                    if (Forms.ProcessingForms.FindTendersFrm.SelectedRow != null)
                    {
                        txtTenderID.Text = Forms.ProcessingForms.FindTendersFrm.SelectedRow.Cells[0].Value.ToString();
                        txtTenderNo.Text = Forms.ProcessingForms.FindTendersFrm.SelectedRow.Cells[1].Value.ToString();
                        DtpTender.Text = Forms.ProcessingForms.FindTendersFrm.SelectedRow.Cells[2].Value.ToString();
                        txtTenderPurpose.Text = Forms.ProcessingForms.FindTendersFrm.SelectedRow.Cells[4].Value.ToString();
                    }
                    txtAssayesNo.Focus();
                }
                else
                {
                    MessageBox.Show("من فضلك اختر طريقة الشراء اولا");
                    cmbPurchMethod.Focus();
                }



            }
        }

        private void txtTenderNo_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 2000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لاختيار المناقصه", TB, 0, 0, VisibleTime);
        }

        private void txtOrderNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbPurchMethod.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {

                Forms.BasicCodeForms.FindOrdersFrm t = new Forms.BasicCodeForms.FindOrdersFrm();
                //if ( txtSuplierID.Text != "")
                //{

                    //t.textEdit1.Text = this.cmbOrderKind.SelectedValue.ToString();
                    //int Vint_OrderKind = int.Parse(t.textEdit1.Text);
                    t.dataGridView1.DataSource = (from ord in FsDb.Tbl_Order
                                                  join purchMth in FsDb.Tbl_PurchaseMethods on ord.PurchaseMethodsID equals purchMth.ID
                                                  join Tndr in FsDb.Tbl_TendersAuctions on ord.TendersAuctionsID equals Tndr.ID
                                                  join supp in FsDb.Tbl_Supplier on ord.Supp_ID equals supp.ID
                                                  join ordK in FsDb.Tbl_OrderKind on ord.OrderKind_ID equals ordK.ID
                                                  //where (ord.OrderKind_ID == Vint_OrderKind)
                                                  select new
                                                  {
                                                      ID = ord.ID,
                                                      Order_NO = ord.Order_NO,
                                                      Order_Date = ord.Order_Date,
                                                      PurchaseMethodsID = ord.PurchaseMethodsID,
                                                      purchaseMethodName = purchMth.Name,
                                                      suppName = supp.Name,
                                                      supp_ID = ord.Supp_ID,
                                                      Tender_No = Tndr.TenderNo,
                                                      TNote = Tndr.Note,
                                                      KindOrd = ordK.Name,
                                                      kindordid = ordK.ID,
                                                  }



                                       ).OrderBy(x => x.Order_Date).ToList();
                    t.DtaGrdView();

                    //t.comboBox1.SelectedValue = this.cmbOrderKind.SelectedValue.ToString();
                    //t.txtOrderKindName.Text = this.cmbOrderKind.Text;

                    t.ShowDialog();

                    if (Forms.BasicCodeForms.FindOrdersFrm.SelectedRow != null)
                    {
                        txtOrderID.Text = Forms.BasicCodeForms.FindOrdersFrm.SelectedRow.Cells[0].Value.ToString();
                        txtOrderNo.Text = Forms.BasicCodeForms.FindOrdersFrm.SelectedRow.Cells[1].Value.ToString();
                        dTPOrderDate.Text = Forms.BasicCodeForms.FindOrdersFrm.SelectedRow.Cells[2].Value.ToString();
                    txtSupliers.Text = Forms.BasicCodeForms.FindOrdersFrm.SelectedRow.Cells[5].Value.ToString();
                    txtSuplierID.Text = Forms.BasicCodeForms.FindOrdersFrm.SelectedRow.Cells[6].Value.ToString();
                    
                    cmbOrderKind.SelectedValue = int.Parse(Forms.BasicCodeForms.FindOrdersFrm.SelectedRow.Cells[10].Value.ToString());
                    Vlng_OrderID = long.Parse(txtOrderID.Text);
                        var listorder = FsDb.Tbl_Order.FirstOrDefault(x => x.ID == Vlng_OrderID);
                        if (listorder != null)
                        {
                            if (listorder.PurchaseMethodsID != null)
                            {
                                cmbPurchMethod.SelectedValue = int.Parse(listorder.PurchaseMethodsID.ToString());
                            }
                            if (listorder.TendersAuctionsID != null)
                            {
                                txtTenderID.Text = listorder.TendersAuctionsID.ToString();
                                Vint_Tender = int.Parse(txtTenderID.Text);
                                var listTender = FsDb.Tbl_TendersAuctions.FirstOrDefault(x => x.ID == Vint_Tender);
                                if (listTender != null)
                                {
                                    txtTenderNo.Text = listTender.TenderNo.ToString();
                                    DtpTender.Text = listTender.TenderDate.ToString("yyyy/MM/dd");
                                txtTenderPurpose.Text = Forms.BasicCodeForms.FindOrdersFrm.SelectedRow.Cells[8].Value.ToString();
                            }
                            }
                            if (listorder.DecisionsResponspilitiesID != null)
                            {
                                Vint_ResponsipilityDecisionID = listorder.DecisionsResponspilitiesID;
                                var listDecion = FsDb.Tbl_DecisionsResponspilities.FirstOrDefault(x => x.ID == Vint_ResponsipilityDecisionID);
                                if (listDecion != null)
                                {
                                    cmbResponspility.SelectedValue = int.Parse(listDecion.ResponspilityCentersID.ToString());
                                    txtResponsipilityDecisionNo.Text = listDecion.DecisionNO.ToString();
                                    dtpResponsipilityDecision.Text = listDecion.DecisionDate.ToString("yyyy/MM/dd");
                                    txtForYear.Text = listDecion.ForYear.ToString();
                                }

                            }
                        }
                    }
                    cmbPurchMethod.Focus();
                //}
                //else
                //{
                //    MessageBox.Show("من فضلك اختر المورد و نوع الامر اولا");
                //    cmbOrderKind.Focus();
                //}



            }
        }

        private void txtOrderNo_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 2000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لاختيار رقم الامر وتاريخه", TB, 0, 0, VisibleTime);

        }

        private void AssayesNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbResponspility.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {

                Forms.ProcessingForms.FindAssayesFrm t = new Forms.ProcessingForms.FindAssayesFrm();


                //t.textEdit1.Text = this.cmbPurchMethod.SelectedValue.ToString();
                //t.comboBox1.SelectedValue = this.cmbPurchMethod.SelectedValue.ToString();
                //t.txtpurchMethodName.Text = this.cmbPurchMethod.Text;
                t.ShowDialog();

                if (Forms.ProcessingForms.FindAssayesFrm.SelectedRow != null)
                {
                    txtAssayesId.Text = Forms.ProcessingForms.FindAssayesFrm.SelectedRow.Cells[0].Value.ToString();
                    txtAssayesNo.Text = Forms.ProcessingForms.FindAssayesFrm.SelectedRow.Cells[1].Value.ToString();
                    dTPAssayesDate.Text = Forms.ProcessingForms.FindAssayesFrm.SelectedRow.Cells[2].Value.ToString();

                }
                cmbResponspility.Focus();




            }
        }

        private void AssayesNo_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 2000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لاختيار رقم المقايسه", TB, 0, 0, VisibleTime);
        }

        private void txtBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBank.Text != "")
                {
                    txtLetterWarrantyNo.Focus();
                }
                else
                {
                    txtletterExportManagement.Focus();
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                Forms.BasicCodeForms.FindBanksFrm M = new Forms.BasicCodeForms.FindBanksFrm();

                M.ShowDialog();
                if (M.txtBankId.Text != "")
                {
                    txtletterExportManagement.Enabled = false;
                    txtBank.Text = M.txtSelected.Text;
                    txtBankID.Text = M.txtBankId.Text;
                    Vint_BankID = int.Parse(txtBankID.Text);
                    this.dtb_WarrantyLetterTableAdapter.FillByBankID(this.letterWarranty.Dtb_WarrantyLetter, Vint_BankID, Vint_LetterProcessID);
                }
                else
                {
                    txtletterExportManagement.Enabled = true;

                }
                txtLetterWarrantyNo.Focus();
            }
        }

        private void txtBank_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 2000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لاختيار البنك", TB, 0, 0, VisibleTime);
        }

        private void txtLetterNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpLetterDate.Focus();
            }

        }

        private void dtpLetterDate_KeyDown(object sender, KeyEventArgs e)
        {
            Vint_LetterWarantyKind = int.Parse(cmbLetterKind.SelectedValue.ToString());
            if (e.KeyCode == Keys.Enter)
            {

                if (Vint_LetterWarantyKind == 1)
                {
                    dTPExpireLetterDate.Value = Convert.ToDateTime(dtpLetterDate.Value.AddMonths(3).ToString("yyyy/MM/dd"));
                    dTPExpireLetterDate.Focus();
                }
                else if (Vint_LetterWarantyKind == 2 || Vint_LetterWarantyKind == 3)
                {
                    dTPExpireLetterDate.Value = Convert.ToDateTime(dtpLetterDate.Value.AddMonths(6).ToString("yyyy/MM/dd"));
                    dTPExpireLetterDate.Focus();
                }

            }

        }

        private void dTPExpireLetterDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // if (dTPExpireLetterDate.Value == Convert.ToDateTime(dtpLetterDate.Value.AddMonths(3).ToString("yyyy/MM/dd")))
                // {

                // }
                //else if (dTPExpireLetterDate.Value <= Convert.ToDateTime((dTPExpireLetterDate.Value.AddDays(-2)).ToString("yyyy/MM/dd")))
                // {

                // }
                // else if (dTPExpireLetterDate.Value == Convert.ToDateTime((dTPExpireLetterDate.Value.AddDays(2)).ToString("yyyy/MM/dd")))
                // {

                // }
                // else
                // {

                // }
                txtSupliers.Focus();
            }

        }

        private void cmbOrderKind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOrderNo.Focus();
            }

        }

        private void txtletterExportManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLetterWarrantyNo.Focus();

            }
            else if (e.KeyCode == Keys.Down)
            {
                Forms.BasicCodeForms.FindManagementFrm M = new Forms.BasicCodeForms.FindManagementFrm();

                M.ShowDialog();
                if (M.txtManagementId.Text != "")
                {
                    txtletterExportManagement.Text = M.txtSelected.Text;
                    txtletterExportManagementID.Text = M.txtManagementId.Text;

                }
                txtLetterWarrantyNo.Focus();
            }
        }

        private void txtletterExportManagement_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 2000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لاختيار الادارة", TB, 0, 0, VisibleTime);
        }

        private void radioGroup2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }

        }

        private void txtExpandDate_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 2000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لإدخال فترة المد", TB, 0, 0, VisibleTime);
        }

        private void txtExpandDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtProject.Focus();
            }

        }

        private void txtProject_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (radioGroup1.SelectedIndex == 0)
                {
                    if (txtBankID.Text == "")
                    {
                        txtletterExportManagement.Focus();
                    }
                    else
                    {
                        txtletterExportManagement.Enabled = false;
                        txtLetterWarrantyPurpose.Focus();
                    }
                }
                else
                {
                    txtletterExportManagement.Enabled = false;
                    txtLetterWarrantyPurpose.Focus();
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                Forms.BasicCodeForms.FindProjectsFrm M = new Forms.BasicCodeForms.FindProjectsFrm();

                M.ShowDialog();
                if (M.txtProjectId.Text != "")
                {
                    txtProject.Text = M.txtSelected.Text;
                    txtProjectId.Text = M.txtProjectId.Text;

                }

            }
        }

        private void txtProject_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 2000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لإختيار المشروع", TB, 0, 0, VisibleTime);
        }

        private void cmbPurchMethod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTenderNo.Focus();
            }

        }

        private void cmbResponspility_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtResponsipilityDecisionNo.Focus();
            }

        }

        private void txtResponsipilityDecisionNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dTPLetterWDateRecieved.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {

                Forms.ProcessingForms.FindDecisionsResponspilities t = new Forms.ProcessingForms.FindDecisionsResponspilities();
                if (cmbResponspility.SelectedValue != null)
                {

                    t.textEdit1.Text = this.cmbResponspility.SelectedValue.ToString();
                    t.comboBox1.SelectedValue = this.cmbResponspility.SelectedValue.ToString();
                    t.txtRespName.Text = this.cmbResponspility.Text;
                    t.ShowDialog();

                    if (Forms.ProcessingForms.FindDecisionsResponspilities.SelectedRow != null)
                    {
                        txtResponsipilityDecisionID.Text = Forms.ProcessingForms.FindDecisionsResponspilities.SelectedRow.Cells[0].Value.ToString();
                        txtResponsipilityDecisionNo.Text = Forms.ProcessingForms.FindDecisionsResponspilities.SelectedRow.Cells[1].Value.ToString();
                        dtpResponsipilityDecision.Text = Forms.ProcessingForms.FindDecisionsResponspilities.SelectedRow.Cells[2].Value.ToString();
                        txtForYear.Text = Forms.ProcessingForms.FindDecisionsResponspilities.SelectedRow.Cells[3].Value.ToString();
                        dTPLetterWDateRecieved.Text = Forms.ProcessingForms.FindDecisionsResponspilities.SelectedRow.Cells[2].Value.ToString();
                    }
                    dTPLetterWDateRecieved.Focus();
                }
                else
                {
                    MessageBox.Show("من فضلك اختر اللجنه اولا");
                    cmbResponspility.Focus();
                }
            }


        }

        private void txtResponsipilityDecisionNo_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 2000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لإختيار الجلسه", TB, 0, 0, VisibleTime);
        }

        private void cmbLetterKind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBank.Focus();
            }

        }

        private void txtLetterWarrantyNoScnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpLetterDate.Focus();
            }
        }

        private void txtLetterWarrantyNoFull_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtLetterValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbCurrency.Focus();
            }
        }

        private void cmbCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtProject.Select();
                this.ActiveControl = txtProject;
                txtProject.Focus();
            }

        }

        private void txtLetterWarrantyNo_TextChanged(object sender, EventArgs e)
        {
            if (txtLetterWarrantyNo.Text == "")
            { txtLetterWarrantyNoFull.Text = ""; }
            else if (txtLetterWarrantyNo.Text != "")
            {
                if (txtLetterWarrantyNoScnd.Text == "")
                {
                    txtLetterWarrantyNoFull.Text = txtLetterWarrantyNo.Text;
                }
                else
                {
                    txtLetterWarrantyNoFull.Text = txtLetterWarrantyNo.Text + "/" + txtLetterWarrantyNoScnd.Text;
                }
                this.dtb_WarrantyLetterTableAdapter.FillByBankKindNo(this.letterWarranty.Dtb_WarrantyLetter, Vint_LetterWarantyKind, Vint_BankID, txtLetterWarrantyNoFull.Text, Vint_LetterProcessID);
            }
        }

        private void txtLetterWarrantyNoScnd_TextChanged(object sender, EventArgs e)
        {
            if (txtLetterWarrantyNo.Text == "")
            { txtLetterWarrantyNoFull.Text = ""; }
            else if (txtLetterWarrantyNo.Text != "" && txtLetterWarrantyNoScnd.Text == "")
            {
                txtLetterWarrantyNoFull.Text = txtLetterWarrantyNo.Text;
                this.dtb_WarrantyLetterTableAdapter.FillByBankKindNo(this.letterWarranty.Dtb_WarrantyLetter, Vint_LetterWarantyKind, Vint_BankID, txtLetterWarrantyNoFull.Text, Vint_LetterProcessID);
            }
            else if (txtLetterWarrantyNo.Text != "" && txtLetterWarrantyNoScnd.Text != "")
            {
                txtLetterWarrantyNoFull.Text = txtLetterWarrantyNoScnd.Text + "/" + txtLetterWarrantyNo.Text;
                this.dtb_WarrantyLetterTableAdapter.FillByBankKindNo(this.letterWarranty.Dtb_WarrantyLetter, Vint_LetterWarantyKind, Vint_BankID, txtLetterWarrantyNoFull.Text, Vint_LetterProcessID);
            }
        }

        private void txtFinancialMember_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 2000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لإختيار العضو المالي", TB, 0, 0, VisibleTime);
        }

        private void txtFinancialMember_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {

                Forms.BasicCodeForms.FindEmployeesFrm t = new Forms.BasicCodeForms.FindEmployeesFrm();

                t.ShowDialog();

                if (Forms.BasicCodeForms.FindEmployeesFrm.SelectedRow != null)
                {
                    txtFinancialMemberID.Text = Forms.BasicCodeForms.FindEmployeesFrm.SelectedRow.Cells[0].Value.ToString();
                    txtFinancialMember.Text = Forms.BasicCodeForms.FindEmployeesFrm.SelectedRow.Cells[1].Value.ToString();


                }
                simpleButton1.Focus();

            }
            else if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                if (txtFinancialMember.Text == "")
                {
                    txtFinancialMemberID.Text = "";
                }
            }
        }

        private void cmbResponspility_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtResponsipilityDecisionNo.Text = "";
            //dtpResponsipilityDecision.Text = DateTime.Now.ToString();
        }

        private void txtFileNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtProject.Focus();
                int Vst_FileN = int.Parse(txtFileNo.Text);
                int Vint_KindFile = int.Parse(txtFileNoSec.Text);

                var listLWCount = FsDb.Tbl_LetterWarranty.Where(x => x.FileNo == Vst_FileN && x.LetterWarrantyKind == Vint_KindFile).ToList();
                if (listLWCount.Count > 0)
                {
                    MessageBox.Show($"هذا الملف تم ادخاله من قبل {Vst_FileN.ToString()} '/' {Vint_KindFile.ToString()}");
                }
            }
        }

        private void txtFileNoSec_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    txtProject.Focus();
            //}
        }

        private void cmbLetterKind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Vint_LetterWarantyKind = int.Parse(cmbLetterKind.SelectedValue.ToString());
            ClearData();
            cmbLetterKind.SelectedValue = Vint_LetterWarantyKind;
            this.dtb_WarrantyLetterTableAdapter.FillByLetterKind(this.letterWarranty.Dtb_WarrantyLetter, Vint_LetterWarantyKind, Vint_LetterProcessID);
            //*******************
            if (dataGridView1.RowCount > 0)
            {
                txtTotal.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                            select Convert.ToDouble(row.Cells[7].Value)).Sum(), 3).ToString();
                txtLettrCount.Text = (from DataGridViewRow row in dataGridView1.Rows
                                      select Convert.ToDouble(row.Cells[7].Value)).Count().ToString();
                if (txtTotal.Text != "" && txtTotalRef.Text != "")
                { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtTotalRef.Text)).ToString(); }
                else if (txtTotal.Text != "" && txtTotalRef.Text == "")
                { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text)).ToString(); }
            }
            //*****************
            if (Vint_LetterWarantyKind == 1)
            {
                txtFileNoSec.Text = "1";
                var ListMaxFileNo = FsDb.Tbl_LetterWarranty.Where(x => x.LetterWarrantyKind == 1 && x.LetterProcessID == Vint_LetterProcessID).Max(x => x.FileNo);
                if (ListMaxFileNo == null)
                { ListMaxFileNo = 0; }
                txtFileNo.Text = (ListMaxFileNo + 1).ToString();

            }
            else if (Vint_LetterWarantyKind == 2)
            {
                txtFileNoSec.Text = "2";
                var ListMaxFileNo = FsDb.Tbl_LetterWarranty.Where(x => x.LetterWarrantyKind == 2 && x.LetterProcessID == Vint_LetterProcessID).Max(x => x.FileNo);
                if (ListMaxFileNo == null)
                { ListMaxFileNo = 0; }
                txtFileNo.Text = (ListMaxFileNo + 1).ToString();
            }
            else if (Vint_LetterWarantyKind == 3)
            {
                txtFileNoSec.Text = "3";
                var ListMaxFileNo = FsDb.Tbl_LetterWarranty.Where(x => x.LetterWarrantyKind == 3 && x.LetterProcessID == Vint_LetterProcessID).Max(x => x.FileNo);
                if (ListMaxFileNo == null)
                { ListMaxFileNo = 0; }
                txtFileNo.Text = (ListMaxFileNo + 1).ToString();
            }

            LoopPaintRowLettersState();
        }

        private void dtpLetterDate_Leave(object sender, EventArgs e)
        {
            if (cmbLetterKind.SelectedValue.ToString() != null)
            { Vint_LetterWarantyKind = int.Parse(cmbLetterKind.SelectedValue.ToString()); }


            if (Vint_LetterWarantyKind == 1)
            {
                dTPExpireLetterDate.Value = Convert.ToDateTime(dtpLetterDate.Value.AddMonths(3).ToString("yyyy/MM/dd"));
                dTPExpireLetterDate.Focus();
            }
            else if (Vint_LetterWarantyKind == 2 || Vint_LetterWarantyKind == 3)
            {
                dTPExpireLetterDate.Value = Convert.ToDateTime(dtpLetterDate.Value.AddMonths(6).ToString("yyyy/MM/dd"));
                dTPExpireLetterDate.Focus();
            }


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var validationSaveUser = (dynamic)null;
            //**************** Insert
            if (txtLetterWId.Text == "")
            {

                if (radioGroup1.SelectedIndex == 0)
                {
                    validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 64 && w.ProcdureId == 1);
                }
                else if (radioGroup1.SelectedIndex == 1)
                {
                    validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 65 && w.ProcdureId == 1);
                }

                if (radioGroup1.SelectedIndex == 1)
                {
                    Vint_LetterProcessID = 1;
                }
                else
                {
                    Vint_LetterProcessID = 0;
                }
                //********************
                if (cmbLetterKind.SelectedIndex == -1)
                {
                    MessageBox.Show("اختر نوع الخطاب");
                    cmbLetterKind.Focus();
                }
                else
                {
                    Vint_LetterWarrantyKind = int.Parse(cmbLetterKind.SelectedValue.ToString());
                }
                //************************Declare 

                if (txtBankID.Text != "") { Vint_BankID = int.Parse(txtBankID.Text); }
                if (txtSuplierID.Text != "") { Vint_SuppID = int.Parse(txtSuplierID.Text); }
                if (txtManagementID.Text != "") { Vint_MngID = int.Parse(txtManagementID.Text); }
                if (txtLetterValue.Text != "") { Vdecm_ValueLetter = decimal.Parse(txtLetterValue.Text); }
                if (cmbCurrency.SelectedValue != null) { Vint_currency = int.Parse(cmbCurrency.SelectedValue.ToString()); }
                if (dtpLetterDate.Value != null) { Vdate_LetterStrtDate = Convert.ToDateTime(dtpLetterDate.Value.ToString("yyyy/MM/dd")); }
                if (
                    dTPExpireLetterDate.Value != null)
                { Vdate_LetterExptDate = Convert.ToDateTime(dTPExpireLetterDate.Value.ToString("yyyy/MM/dd")); }

                if (txtProjectId.Text != "") { Vint_ProjectId = int.Parse(txtProjectId.Text); }
                if (txtletterExportManagementID.Text != "") { Vint_ManagementExportLetterId = int.Parse(txtletterExportManagementID.Text); }
                if (txtFileNo.Text != "") { Vint_FileNO = int.Parse(txtFileNo.Text); }
                if (txtOrderID.Text != "") { Vlng_OrderID = long.Parse(txtOrderID.Text); }
                if (txtTenderID.Text != "") { Vint_Tender = int.Parse(txtTenderID.Text); }
                if (txtAssayesId.Text != "") { Vint_AssayesID = int.Parse(txtAssayesId.Text); }
                if (txtResponsipilityDecisionID.Text != "") { Vint_ResponsipilityDecisionID = int.Parse(txtResponsipilityDecisionID.Text); }
                if (dTPLetterWDateRecieved.Text != "") { VDate_LetterWDateRecieved = dTPLetterWDateRecieved.Text; }

                if (txtFinancialMemberID.Text != "") { Vint_FinancialMember = int.Parse(txtFinancialMemberID.Text); }
                if (txtBenefcieryID.Text != "") { Vint_BeneficiaryID = int.Parse(txtBenefcieryID.Text); }
                if (checkBox1.Checked == true) { Vbl_ConfLetterWarrantyExpireDate = true; }
                else { Vbl_ConfLetterWarrantyExpireDate = false; }
                if (checkBox2.Checked == true) { Vbl_ConfValue = true; }
                else
                { Vbl_ConfValue = false; }
                if (checkBox3.Checked == true) { Vbl_ConfTender = true; }
                else
                { Vbl_ConfTender = false; }
                if (checkBox4.Checked == true) { Vbl_ConfRecieveLetter = true; } else { Vbl_ConfRecieveLetter = false; }

                //******************
                if (txtBankID.Text == "" && Vint_LetterProcessID == 1)
                {
                    MessageBox.Show("اختر البنك");
                    txtBank.Focus();

                }
                else if (txtBankID.Text == "" && Vint_LetterProcessID == 0 && txtletterExportManagement.Text == "")
                {
                    MessageBox.Show("اختر البنك او اختر الجهه الصادره للخطاب");
                    txtBank.Focus();
                }
                else
                {
                    Vint_BankID = int.Parse(txtBankID.Text);
                }
                if (txtLetterWarrantyNoFull.Text == "")
                {
                    MessageBox.Show("ادخل رقم الخطاب");
                    txtLetterWarrantyNo.Focus();
                }

                else if (txtSupliers.Text == "" && Vint_LetterProcessID == 1)
                {
                    MessageBox.Show("اختر المستفيد");
                    txtSupliers.Focus();
                }
                else if (cmbLetterKind.SelectedIndex == -1)
                {
                    MessageBox.Show("اختر نوع الخطاب");
                    cmbLetterKind.Focus();
                }
                //else if (txtSupliers.Text == "" && Vint_LetterProcessID == 0)
                //{
                //    MessageBox.Show("اختر المورد");
                //    txtSupliers.Focus();
                //}
                else if (txtManagement.Text == "")
                {
                    MessageBox.Show("اختر الجهه");
                    txtManagement.Focus();
                }

                else if (txtLetterValue.Text == "")
                {
                    MessageBox.Show("ادخل مبلغ الخطاب");
                    txtLetterValue.Focus();
                }
                else if (validationSaveUser != null)
                {



                    Tbl_LetterWarranty Lwrnty = new Tbl_LetterWarranty
                    {
                        LetterProcessID = Vint_LetterProcessID,
                        LetterWarrantyKind = Vint_LetterWarantyKind,

                        LetterWarrantyNo = txtLetterWarrantyNo.Text,
                        LetterWarrantyNoScnd = txtLetterWarrantyNoScnd.Text,
                        LetterWarrantyNoFull = txtLetterWarrantyNoFull.Text,

                        LetterWarrantyDate = (DateTime)Vdate_LetterStrtDate,
                        LetterWarrantyExpireDate = (DateTime)Vdate_LetterExptDate,
                        LetterWarrantyExpandDate = (DateTime)Vdate_LetterExptDate,
                        SupID = Vint_SuppID,
                        ManagementID = Vint_MngID,
                        Value = Vdecm_ValueLetter,
                        CurrencyID = Vint_currency,

                        ProjectID = Vint_ProjectId,
                        ManagementExportLettrID = Vint_ManagementExportLetterId,

                        FileNo = Vint_FileNO,
                        OrderID = Vlng_OrderID,
                        TendersAuctionsID = Vint_Tender,
                        AssayesID = Vint_AssayesID,
                        BankID = Vint_BankID,
                        DecisionsResponspilitiesID = Vint_ResponsipilityDecisionID,
                        LetterWDateRecieved = VDate_LetterWDateRecieved,
                        FinancialMember = Vint_FinancialMember,
                        BeneficiaryID = Vint_BeneficiaryID,
                        LetterWarrantyPurpose = txtLetterWarrantyPurpose.Text,


                        ConfLetterWarrantyExpireDate = Vbl_ConfLetterWarrantyExpireDate,
                        ConfValue = Vbl_ConfValue,
                        ConfTender = Vbl_ConfTender,
                        ConfRecieveLetter = Vbl_ConfRecieveLetter

                    };

                    FsDb.Tbl_LetterWarranty.Add(Lwrnty);
                    FsDb.SaveChanges();
                    long Vint_LastRow = Lwrnty.ID;
                    // ---------------خفظ ااحداث
                    SecurityEvent sev = new SecurityEvent
                    {
                        ActionName = "اضافة خطاب ضمان",
                        TableName = "Tbl_LetterWarranty",
                        TableRecordId = Vint_LastRow.ToString(),
                        Description = "",
                        ManagementName = Program.GlbV_Management,
                        ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                        EmployeeName = Program.GlbV_EmpName,
                        User_ID = Program.GlbV_UserId,
                        UserName = Program.GlbV_UserName,
                        FormName = "شاشة خطابات الضمان"


                    };
                    FsEvDb.SecurityEvents.Add(sev);
                    FsEvDb.SaveChanges();
                    //************************************
                    MessageBox.Show("تم الحفظ");
                    ClearData();
                    checkData();
                    this.dtb_WarrantyLetterTableAdapter.Fill(this.letterWarranty.Dtb_WarrantyLetter, Vint_LetterProcessID);
                    //*******************
                    if (dataGridView1.RowCount > 0)
                    {
                        txtTotal.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                    select Convert.ToDouble(row.Cells[7].Value)).Sum(), 3).ToString();
                        if (txtTotal.Text != "" && txtTotalRef.Text != "")
                        { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtTotalRef.Text)).ToString(); }
                        else if (txtTotal.Text != "" && txtTotalRef.Text == "")
                        { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text)).ToString(); }
                    }
                    //*****************
                    cmbLetterKind.Focus();
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية اضافة خطاب ضمان ___ برجاء مراجعة مدير المنظومه ");
                }
            }
            else
            {
                //**************** Update ***************
                Vint_LetterWarantyID = int.Parse(txtLetterWId.Text);
                var ListUpdateLetterWarranty = FsDb.Tbl_LetterWarranty.FirstOrDefault(x => x.ID == Vint_LetterWarantyID);
                var list = FsDb.Tbl_LetterWExpandDates.Where(x => x.LetterWarrantyID == Vint_LetterWarantyID).ToList();

                if (radioGroup1.SelectedIndex == 0)
                {
                    validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 64 && w.ProcdureId == 3);
                }
                else if (radioGroup1.SelectedIndex == 1)
                {
                    validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 65 && w.ProcdureId == 3);
                }
                if (validationSaveUser != null)
                {
                    if (txtLetterWarrantyNo.Text != "") { ListUpdateLetterWarranty.LetterWarrantyNo = txtLetterWarrantyNo.Text; }
                    if (txtLetterWarrantyNoScnd.Text != "") { ListUpdateLetterWarranty.LetterWarrantyNoScnd = txtLetterWarrantyNoScnd.Text; }
                    ListUpdateLetterWarranty.LetterWarrantyNoFull = txtLetterWarrantyNoFull.Text;

                    if (dtpLetterDate.Value != null) { ListUpdateLetterWarranty.LetterWarrantyDate = Convert.ToDateTime(dtpLetterDate.Value.ToString()); }
                    if (
                        dTPExpireLetterDate.Value != null)
                    {
                        ListUpdateLetterWarranty.LetterWarrantyExpireDate = Convert.ToDateTime(dTPExpireLetterDate.Value.ToString());
                        if (list.Count > 0)
                        {
                            var ListExpandDatetterWarranty = FsDb.Tbl_LetterWExpandDates.Where(x => x.LetterWarrantyID == Vint_LetterWarantyID).Select(p => p.LetterWExpandDate).Max();

                            if (ListExpandDatetterWarranty == null)
                            {
                                ListUpdateLetterWarranty.LetterWarrantyExpandDate = Convert.ToDateTime(dTPExpireLetterDate.Value.ToString());
                            }
                            else
                            {
                                DateTime? Vdate_CalcNewDate = null;
                                int Vint_KindId = 0;
                                Vint_KindId = int.Parse(ListUpdateLetterWarranty.LetterWarrantyKind.ToString());
                                if (ListUpdateLetterWarranty.LetterWarrantyExpireDate != null)
                                {

                                    Vdate_CalcNewDate = Convert.ToDateTime(ListExpandDatetterWarranty.ToString());
                                    if (Vint_KindId == 1)
                                    {

                                        ListUpdateLetterWarranty.LetterWarrantyExpandDate = Vdate_CalcNewDate.Value.AddMonths(3);
                                    }
                                    else if (Vint_KindId == 2 || Vint_KindId == 3)
                                    {
                                        ListUpdateLetterWarranty.LetterWarrantyExpandDate = Vdate_CalcNewDate.Value.AddMonths(6);
                                    }
                                }
                            }
                        }

                    }
                    if (checkBox1.Checked == true) { ListUpdateLetterWarranty.ConfLetterWarrantyExpireDate = true; } else { ListUpdateLetterWarranty.ConfLetterWarrantyExpireDate = false; }

                    if (txtLetterValue.Text != "") { ListUpdateLetterWarranty.Value = Convert.ToDecimal(txtLetterValue.Text); }
                    if (txtSuplierID.Text != "") { ListUpdateLetterWarranty.SupID = int.Parse(txtSuplierID.Text); }
                    if (txtBenefcieryID.Text != "") { ListUpdateLetterWarranty.BeneficiaryID = int.Parse(txtBenefcieryID.Text); }
                    if (txtManagementID.Text != "") { ListUpdateLetterWarranty.ManagementID = int.Parse(txtManagementID.Text); }


                    if (dtpLetterDate.Value != null) { ListUpdateLetterWarranty.LetterWarrantyDate = Convert.ToDateTime(dtpLetterDate.Value.ToString()); }
                    if (cmbCurrency.SelectedValue != null) { ListUpdateLetterWarranty.CurrencyID = int.Parse(cmbCurrency.SelectedValue.ToString()); }
                    if (checkBox2.Checked == true) { ListUpdateLetterWarranty.ConfLetterWarrantyExpireDate = true; } else { ListUpdateLetterWarranty.ConfLetterWarrantyExpireDate = false; }


                    if (txtletterExportManagementID.Text != "") { ListUpdateLetterWarranty.ManagementExportLettrID = int.Parse(txtletterExportManagementID.Text); }
                    if (txtLetterWarrantyPurpose.Text != "") { ListUpdateLetterWarranty.LetterWarrantyPurpose = txtLetterWarrantyPurpose.Text; }

                    if (txtProjectId.Text != "") { ListUpdateLetterWarranty.ProjectID = int.Parse(txtProjectId.Text); }
                    if (txtletterExportManagementID.Text != "") { ListUpdateLetterWarranty.ManagementExportLettrID = int.Parse(txtletterExportManagementID.Text); }
                    if (txtLetterWarrantyPurpose.Text != "") { ListUpdateLetterWarranty.LetterWarrantyPurpose = txtLetterWarrantyPurpose.Text; }
                    if (txtOrderID.Text != "") { ListUpdateLetterWarranty.OrderID = int.Parse(txtOrderID.Text); }

                    if (txtTenderID.Text != "") { ListUpdateLetterWarranty.TendersAuctionsID = int.Parse(txtTenderID.Text); }
                    if (txtAssayesId.Text != "") { ListUpdateLetterWarranty.AssayesID = int.Parse(txtAssayesId.Text); }
                    if (txtResponsipilityDecisionID.Text != "") { ListUpdateLetterWarranty.DecisionsResponspilitiesID = int.Parse(txtResponsipilityDecisionID.Text); } else { ListUpdateLetterWarranty.DecisionsResponspilitiesID = null; }
                    if (txtFinancialMemberID.Text != "") { ListUpdateLetterWarranty.FinancialMember = int.Parse(txtFinancialMemberID.Text); }

                    if (dTPLetterWDateRecieved.Text != "") { ListUpdateLetterWarranty.LetterWDateRecieved = dTPLetterWDateRecieved.Text; }
                    if (checkBox1.Checked == true) { ListUpdateLetterWarranty.ConfLetterWarrantyExpireDate = true; }
                    else { ListUpdateLetterWarranty.ConfLetterWarrantyExpireDate = false; }
                    if (checkBox2.Checked == true) { ListUpdateLetterWarranty.ConfValue = true; }
                    else
                    { ListUpdateLetterWarranty.ConfValue = false; }
                    if (checkBox3.Checked == true) { ListUpdateLetterWarranty.ConfTender = true; }
                    else
                    { ListUpdateLetterWarranty.ConfTender = false; }
                    if (checkBox4.Checked == true) { ListUpdateLetterWarranty.ConfRecieveLetter = true; } else { ListUpdateLetterWarranty.ConfRecieveLetter = false; }
                    if (txtFileNo.Text != "") { ListUpdateLetterWarranty.FileNo = int.Parse(txtFileNo.Text); }
                    if (txtBankID.Text != "") { ListUpdateLetterWarranty.BankID = int.Parse(txtBankID.Text); }


                    FsDb.SaveChanges();
                    //---------------خفظ ااحداث 

                    SecurityEvent sev = new SecurityEvent
                    {
                        ActionName = "تعديل خطاب ضمان ",
                        TableName = "Tbl_LetterWarranty",
                        TableRecordId = ListUpdateLetterWarranty.ID.ToString(),
                        Description = "",
                        ManagementName = Program.GlbV_Management,
                        ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                        EmployeeName = Program.GlbV_EmpName,
                        User_ID = Program.GlbV_UserId,
                        UserName = Program.GlbV_UserName,
                        FormName = "شاشة حطابات الضمان"


                    };
                    FsEvDb.SecurityEvents.Add(sev);
                    FsEvDb.SaveChanges();
                    //***************************
                    MessageBox.Show("تم التعديل");

                    this.dtb_WarrantyLetterTableAdapter.Fill(this.letterWarranty.Dtb_WarrantyLetter, Vint_LetterProcessID);
                    //*******************
                    if (dataGridView1.RowCount > 0)
                    {
                        txtTotal.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                    select Convert.ToDouble(row.Cells[7].Value)).Sum(), 3).ToString();
                        if (txtTotal.Text != "" && txtTotalRef.Text != "")
                        { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtTotalRef.Text)).ToString(); }
                        else if (txtTotal.Text != "" && txtTotalRef.Text == "")
                        { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text)).ToString(); }
                    }
                    //*****************
                    ClearData();
                    checkData();
                    cmbLetterKind.Focus();
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية تعديل خطاب ضمان ___ برجاء مراجعة مدير المنظومه ");
                }

            }
        }

        private void txtLetterWarrantyPurpose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Vint_LetterProcessID == 0)
                {
                    cmbOrderKind.Focus();
                }
                else
                {
                    simpleButton1.Focus();
                }
            }
        }

        private void txtLetterValue_TextChanged(object sender, EventArgs e)
        {
            if (txtLetterValue.Text != "")

            {
                this.dtb_WarrantyLetterTableAdapter.FillByBankValue(this.letterWarranty.Dtb_WarrantyLetter, Vint_BankID, decimal.Parse(txtLetterValue.Text), Vint_LetterWarantyKind, Vint_LetterProcessID);
                //*******************
                if (dataGridView1.RowCount > 0)
                {

                    txtTotal.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                select Convert.ToDouble(row.Cells[7].Value)).Sum(), 3).ToString();

                    txtLettrCount.Text = (from DataGridViewRow row in dataGridView1.Rows
                                          select Convert.ToDouble(row.Cells[7].Value)).Count().ToString();

                    if (txtTotal.Text != "" && txtTotalRef.Text != "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtTotalRef.Text)).ToString(); }
                    else if (txtTotal.Text != "" && txtTotalRef.Text == "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text)).ToString(); }
                }
                //*****************
            }

        }
        private void ClreaData1()
        {
            txtSuplierID.Text = "";
            txtSupliers.Text = "";
            txtTenderID.Text = "";
            txtResponsipilityDecisionID.Text = "";
            txtResponsipilityDecisionNo.Text = "";
            txtProject.Text = "";
            txtProjectId.Text = "";
            txtTenderPurpose.Text = "";
            txtTotal.Text = "";
            txtBank.Text = "";
            txtletterExportManagement.Text = "";
            txtletterExportManagementID.Text = "";
            txtLetterWarrantyNo.Text = "";
            txtLetterWarrantyNoFull.Text = "";
            txtManagement.Text = "";
            txtManagementID.Text = "";
            txtLetterValue.Text = "";

            cmbLetterKind.SelectedIndex = 1;
            cmbLetterKind.Text = "اختر نوع الخطاب";
            cmbCurrency.SelectedIndex = 1;
            cmbCurrency.Text = "اختر العمله";

            cmbOrderKind.SelectedIndex = 1;
            cmbOrderKind.Text = "اختر نوع الامر";

            cmbPurchMethod.SelectedIndex = 1;
            cmbPurchMethod.Text = "اختر نوع الامر";

            txtOrderNo.Text = "";
            txtOrderID.Text = "";
            dTPOrderDate.Text = "";
            txtTenderNo.Text = "";

            checkBox3.Checked = false;
            txtAssayesNo.Text = "";

            dTPAssayesDate.Text = "";
            DtpTender.Text = "";

            txtTenderPurpose.Text = "";

        }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            txtTotal.Text = "";
            txtLettrCount.Text = "";
            txtBalance.Text = "";
            txtTotalRef.Text = "";
            int Vint_LetterWID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            ClearData();
            txtLetterWId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            FillData(Vint_LetterWID);

            this.dtb_WarrantyLetterTableAdapter.FillByLetterID(this.letterWarranty.Dtb_WarrantyLetter, Vint_LetterProcessID, Vint_LetterWID);
            //*******************
            if (dataGridView1.RowCount > 0)
            {
                txtTotal.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                            select Convert.ToDouble(row.Cells[7].Value)).Sum(), 3).ToString();
                txtLettrCount.Text = (from DataGridViewRow row in dataGridView1.Rows
                                      select Convert.ToDouble(row.Cells[7].Value)).Count().ToString();

                if (txtTotal.Text != "" && txtTotalRef.Text != "")
                { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtTotalRef.Text)).ToString(); }
                else if (txtTotal.Text != "" && txtTotalRef.Text == "")
                { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text)).ToString(); }
                LoopPaintRowLettersState();
            }
            //*****************
            //                //****************Refrences***************
            LetterWAuditSelect(Vint_LetterWID);
            //                //***************************************
            simpleButton3.Enabled = true;
        }

        private void txtProject_TextChanged(object sender, EventArgs e)
        {
            if (txtProject.Text == "")
            {
                txtProjectId.Text = "";
            }
        }

        private void txtSupliers_TextChanged(object sender, EventArgs e)
        {
            if (txtSupliers.Text == "")
            {
                txtSuplierID.Text = "";
                txtBenefcieryID.Text = "";
            }
        }

        private void txtManagement_TextChanged(object sender, EventArgs e)
        {
            if (txtManagement.Text == "")
            {
                txtManagementID.Text = "";

            }
        }

        private void txtBank_TextChanged(object sender, EventArgs e)
        {
            if (txtBank.Text == "")
            {
                txtBankID.Text = "";

            }
        }

        private void txtOrderNo_TextChanged(object sender, EventArgs e)
        {
            if (txtOrderNo.Text == "")
            {
                txtOrderID.Text = "";

            }
        }

        private void txtTenderNo_TextChanged(object sender, EventArgs e)
        {
            if (txtTenderNo.Text == "")
            {
                txtTenderID.Text = "";

            }
        }

        private void txtAssayesNo_TextChanged(object sender, EventArgs e)
        {
            if (txtAssayesNo.Text == "")
            {
                txtAssayesId.Text = "";

            }
        }

        private void txtResponsipilityDecisionNo_TextChanged(object sender, EventArgs e)
        {
            if (txtResponsipilityDecisionNo.Text == "")
            {
                txtResponsipilityDecisionID.Text = "";
                txtForYear.Text = "";

            }

        }

        private void txtFinancialMember_TextChanged(object sender, EventArgs e)
        {
            if (txtFinancialMember.Text == "")
            {
                txtFinancialMemberID.Text = "";


            }

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (Vint_LetterProcessID == 0)
            {
                dataGridView1.Columns[11].Visible = false;

            }

            if (Vint_LetterProcessID == 1)
            {
                dataGridView1.Columns[10].Visible = false;

            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            ClearData();
            checkData();
            simpleButton3.Enabled = false;
            cmbLetterKind.Focus();
        }

        private void dTPLetterWDateRecieved_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFinancialMember.Focus();

            }
        }

        private void txtBank_Leave(object sender, EventArgs e)
        {
            if (txtBankID.Text != "")
            {
                txtletterExportManagement.Enabled = false;
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {

            if (txtLetterWId.Text == "")
            {
                MessageBox.Show("من فضلك قم بإختيار خطاب الضمان المراد مده");
            }
            else
            {
                Vint_LetterWarantyID = int.Parse(txtLetterWId.Text);
                var listRefund = FsDb.Tbl_RefundLetter.Where(x => x.LetterWarrantyID == Vint_LetterWarantyID).ToList();
                if (listRefund.Count != 0)
                {
                    MessageBox.Show("هذا الخطاب تم رده");
                }
                else
                {
                    Vint_LetterWarantyID = int.Parse(txtLetterWId.Text);
                    Forms.DocumentsForms.LetterWarrantyExpandFrm t = new Forms.DocumentsForms.LetterWarrantyExpandFrm();
                    t.txtLetterKind.Text = this.cmbLetterKind.Text.ToString();
                    t.txtBank.Text = this.txtBank.Text;
                    t.txtvalue.Text = this.txtLetterValue.Text;
                    t.txtcurrency.Text = this.cmbCurrency.SelectedText.ToString();
                    t.txtLetterFullNo.Text = this.txtLetterWarrantyNoFull.Text;
                    t.txtcurrency.Text = cmbCurrency.Text;
                    t.MskStartDate.Value = Convert.ToDateTime(this.dtpLetterDate.Value.ToString("yyyy/MM/dd"));
                    t.MskFirstExpandDate.Value = Convert.ToDateTime(this.dTPExpireLetterDate.Value.ToString("yyyy/MM/dd"));
                    t.LetterId.Text = this.txtLetterWId.Text;
                    t.txtLetterKindID.Text = this.cmbLetterKind.SelectedValue.ToString();
                    t.radioGroup1.SelectedIndex = this.radioGroup1.SelectedIndex;



                    if ((Application.OpenForms["LetterWarrantyExpandFrm"] as LetterWarrantyExpandFrm != null))
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
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                this.dtb_WarrantyLetterTableAdapter.Fill(this.letterWarranty.Dtb_WarrantyLetter, Vint_LetterProcessID);
                //*******************
                if (dataGridView1.RowCount > 0)
                {
                    txtTotal.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                select Convert.ToDouble(row.Cells[7].Value)).Sum(), 3).ToString();
                    if (txtTotal.Text != "" && txtTotalRef.Text != "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtTotalRef.Text)).ToString(); }
                    else if (txtTotal.Text != "" && txtTotalRef.Text == "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text)).ToString(); }
                    LoopPaintRowLettersState();
                }
                //*****************
            }
            else
            {
                this.dtb_WarrantyLetterTableAdapter.FillByLetterFullNo(this.letterWarranty.Dtb_WarrantyLetter, textBox1.Text, Vint_LetterProcessID);
                //*******************
                if (dataGridView1.RowCount > 0)
                {
                    txtTotal.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                select Convert.ToDouble(row.Cells[7].Value)).Sum(), 3).ToString();
                    LoopPaintRowLettersState();
                }
                //*****************
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                this.dtb_WarrantyLetterTableAdapter.Fill(this.letterWarranty.Dtb_WarrantyLetter, Vint_LetterProcessID);
                //*******************
                if (dataGridView1.RowCount > 0)
                {
                    txtTotal.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                select Convert.ToDouble(row.Cells[7].Value)).Sum(), 3).ToString();
                    if (txtTotal.Text != "" && txtTotalRef.Text != "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtTotalRef.Text)).ToString(); }
                    else if (txtTotal.Text != "" && txtTotalRef.Text == "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text)).ToString(); }
                    LoopPaintRowLettersState();
                }
                //*****************
            }
            else
            {
                int Vint_FileNo = int.Parse(textBox2.Text);

                this.dtb_WarrantyLetterTableAdapter.FillByFileNo(this.letterWarranty.Dtb_WarrantyLetter, Vint_LetterProcessID, Vint_FileNo);
                //*******************
                if (dataGridView1.RowCount > 0)
                {
                    txtTotal.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                select Convert.ToDouble(row.Cells[7].Value)).Sum(), 3).ToString();
                    if (txtTotal.Text != "" && txtTotalRef.Text != "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtTotalRef.Text)).ToString(); }
                    else if (txtTotal.Text != "" && txtTotalRef.Text == "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text)).ToString(); }
                    LoopPaintRowLettersState();
                }
                //*****************
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                this.dtb_WarrantyLetterTableAdapter.Fill(this.letterWarranty.Dtb_WarrantyLetter, Vint_LetterProcessID);
                //*******************
                if (dataGridView1.RowCount > 0)
                {
                    txtTotal.Text = (from DataGridViewRow row in dataGridView1.Rows
                                     select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();
                    if (txtTotal.Text != "" && txtTotalRef.Text != "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtTotalRef.Text)).ToString(); }
                    else if (txtTotal.Text != "" && txtTotalRef.Text == "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text)).ToString(); }
                    LoopPaintRowLettersState();
                }
                //*****************
            }
            else
            {
                decimal Vdc_FileNo = decimal.Parse(textBox3.Text);
                this.dtb_WarrantyLetterTableAdapter.FillByValueLetter(this.letterWarranty.Dtb_WarrantyLetter, Vint_LetterProcessID, Vdc_FileNo);
                //*******************
                if (dataGridView1.RowCount > 0)
                {
                    txtTotal.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                select Convert.ToDouble(row.Cells[7].Value)).Sum(), 3).ToString();
                    if (txtTotal.Text != "" && txtTotalRef.Text != "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtTotalRef.Text)).ToString(); }
                    else if (txtTotal.Text != "" && txtTotalRef.Text == "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text)).ToString(); }

                    LoopPaintRowLettersState();
                }
                //*****************
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { textBox4.Focus(); }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                this.dtb_WarrantyLetterTableAdapter.Fill(this.letterWarranty.Dtb_WarrantyLetter, Vint_LetterProcessID);
                //*******************
                if (dataGridView1.RowCount > 0)
                {
                    txtTotal.Text = (from DataGridViewRow row in dataGridView1.Rows
                                     select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();

                    if (txtTotal.Text != "" && txtTotalRef.Text != "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtTotalRef.Text)).ToString(); }
                    else if (txtTotal.Text != "" && txtTotalRef.Text == "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text)).ToString(); }
                    LoopPaintRowLettersState();
                }
                //*****************

            }
            else if (textBox2.Text != "" && textBox4.Text != "")
            {
                textBox8.Text = textBox4.Text;
                int Vint_FileNo = int.Parse(textBox2.Text);
                int Vint_lKind = int.Parse(textBox4.Text);
                this.dtb_WarrantyLetterTableAdapter.FillByFillNoKindLett(this.letterWarranty.Dtb_WarrantyLetter, Vint_LetterProcessID, Vint_FileNo, Vint_lKind);
                //*******************
                if (dataGridView1.RowCount > 0)
                {
                    txtTotal.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                select Convert.ToDouble(row.Cells[7].Value)).Sum(), 3).ToString();
                    if (txtTotal.Text != "" && txtTotalRef.Text != "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtTotalRef.Text)).ToString(); }
                    else if (txtTotal.Text != "" && txtTotalRef.Text == "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text)).ToString(); }
                    LoopPaintRowLettersState();
                }
                //*****************
            }
            else if (textBox2.Text == "" && textBox4.Text != "")
            {
                Vint_LetterWarantyKind = int.Parse(textBox4.Text);
                int Vint_lKind = int.Parse(textBox4.Text);
                this.dtb_WarrantyLetterTableAdapter.FillByLetterKind(this.letterWarranty.Dtb_WarrantyLetter, Vint_LetterWarantyKind, Vint_LetterProcessID);
                //*******************
                if (dataGridView1.RowCount > 0)
                {
                    txtTotal.Text = (from DataGridViewRow row in dataGridView1.Rows
                                     select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();

                    txtBalance.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtTotalRef.Text)).ToString();

                    LoopPaintRowLettersState();
                }
                //*****************
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox5.Text == "")
            {
                decimal Vdc_FileNo = decimal.Parse(textBox3.Text);
                this.dtb_WarrantyLetterTableAdapter.FillByValueLetter(this.letterWarranty.Dtb_WarrantyLetter, Vint_LetterProcessID, Vdc_FileNo);
                //*******************
                if (dataGridView1.RowCount > 0)
                {
                    txtTotal.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                select Convert.ToDouble(row.Cells[7].Value)).Sum(), 3).ToString();

                    if (txtTotal.Text != "" && txtTotalRef.Text != "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtTotalRef.Text)).ToString(); }
                    else if (txtTotal.Text != "" && txtTotalRef.Text == "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text)).ToString(); }
                    LoopPaintRowLettersState();
                }
                //*****************
            }
            else if (textBox3.Text != "" && textBox5.Text != "")
            {

                decimal Vdc_Value1 = decimal.Parse(textBox3.Text);

                decimal Vdc_Value2 = decimal.Parse(textBox5.Text);
                this.dtb_WarrantyLetterTableAdapter.FillByTwoValue(this.letterWarranty.Dtb_WarrantyLetter, Vint_LetterProcessID, Vdc_Value1, Vdc_Value2);
                //*******************
                if (dataGridView1.RowCount > 0)
                {
                    txtTotal.Text = (from DataGridViewRow row in dataGridView1.Rows
                                     select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();

                    if (txtTotal.Text != "" && txtTotalRef.Text != "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtTotalRef.Text)).ToString(); }
                    else if (txtTotal.Text != "" && txtTotalRef.Text == "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text)).ToString(); }

                    LoopPaintRowLettersState();
                }
                //*****************
            }
            else if (textBox3.Text == "" && textBox5.Text != "")
            {
                decimal Vdc_FileNo = decimal.Parse(textBox5.Text);
                this.dtb_WarrantyLetterTableAdapter.FillByValueLetter(this.letterWarranty.Dtb_WarrantyLetter, Vint_LetterProcessID, Vdc_FileNo);
                //*******************
                if (dataGridView1.RowCount > 0)
                {
                    txtTotal.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                select Convert.ToDouble(row.Cells[7].Value)).Sum(), 3).ToString();

                    if (txtTotal.Text != "" && txtTotalRef.Text != "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtTotalRef.Text)).ToString(); }
                    else if (txtTotal.Text != "" && txtTotalRef.Text == "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text)).ToString(); }
                    LoopPaintRowLettersState();
                }
                //*****************
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();

            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (txtLetterWId.Text == "")
            {
                MessageBox.Show("من فضلك قم بإختيار خطاب الضمان المراد رده");
            }
            else
            {
                Vint_LetterWarantyID = int.Parse(txtLetterWId.Text);
                Forms.DocumentsForms.RefundLetterFrm t = new Forms.DocumentsForms.RefundLetterFrm();
                t.txtLetterKind.Text = this.cmbLetterKind.Text.ToString();
                t.txtBank.Text = this.txtBank.Text;
                t.txtvalue.Text = this.txtLetterValue.Text;
                t.txtcurrency.Text = this.cmbCurrency.SelectedText.ToString();
                t.txtLetterFullNo.Text = this.txtLetterWarrantyNoFull.Text;
                t.txtcurrency.Text = cmbCurrency.Text;
                t.MskStartDate.Value = Convert.ToDateTime(this.dtpLetterDate.Value.ToString("yyyy/MM/dd"));
                t.MskFirstExpandDate.Value = Convert.ToDateTime(this.dTPExpireLetterDate.Value.ToString("yyyy/MM/dd"));
                t.LetterId.Text = this.txtLetterWId.Text;
                t.txtLetterKindID.Text = this.cmbLetterKind.SelectedValue.ToString();
                t.radioGroup1.SelectedIndex = this.radioGroup1.SelectedIndex;

                t.txtPurchMethode.Text = this.cmbPurchMethod.Text.ToString();
                t.txtTenderNo.Text = this.txtTenderNo.Text;
                if (this.txtTenderNo.Text != "")
                {
                    Vint_Tender = int.Parse(txtTenderID.Text);
                    var listTender = FsDb.Tbl_TendersAuctions.FirstOrDefault(x => x.ID == Vint_Tender);
                    t.txtFYear.Text = listTender.Tbl_Fiscalyear.Name.ToString();
                }

                var ListRefundLetter = FsDb.Tbl_RefundLetter.FirstOrDefault(x => x.LetterWarrantyID == Vint_LetterWarantyID);
                if (ListRefundLetter != null)
                {
                    t.txtEmpRecieve.Text = ListRefundLetter.Tbl_Employee.Name.ToString();
                    t.cmbRecieveMethode.SelectedIndex = int.Parse(ListRefundLetter.RecievedMethodeLetterID.ToString());
                    t.dTPDateRecieve.Value = Convert.ToDateTime(ListRefundLetter.RecievedDate.ToString("yyyy/MM/dd"));
                    t.dTPDateRefund.Value = Convert.ToDateTime(ListRefundLetter.RefundLetterDate.ToString("yyyy/MM/dd"));
                }

                if ((Application.OpenForms["RefundLetterFrm"] as RefundLetterFrm != null))
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
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (txtLetterWId.Text == "")
            {
                MessageBox.Show("من فضلك قم بإختيار خطاب الضمان المراد تسجيل اخطار له");
            }
            else
            {
                Vint_LetterWarantyID = int.Parse(txtLetterWId.Text);
                Forms.DocumentsForms.NotificationLetterWFrm t = new Forms.DocumentsForms.NotificationLetterWFrm();
                t.txtLetterKind.Text = this.cmbLetterKind.Text.ToString();
                t.txtBank.Text = this.txtBank.Text;
                t.txtvalue.Text = this.txtLetterValue.Text;

                t.txtLetterFullNo.Text = this.txtLetterWarrantyNoFull.Text;

                t.MskStartDate.Value = Convert.ToDateTime(this.dtpLetterDate.Value.ToString("yyyy/MM/dd"));
                t.MskFirstExpandDate.Value = Convert.ToDateTime(this.dTPExpireLetterDate.Value.ToString("yyyy/MM/dd"));
                t.LetterId.Text = this.txtLetterWId.Text;
                t.txtLetterKindID.Text = this.cmbLetterKind.SelectedValue.ToString();
                t.radioGroup1.SelectedIndex = this.radioGroup1.SelectedIndex;
                t.txtcurrency.Text = cmbCurrency.Text;
                t.txtPurchMethode.Text = this.cmbPurchMethod.Text.ToString();
                t.txtTenderNo.Text = this.txtTenderNo.Text;
                if (this.txtTenderNo.Text != "")
                {
                    Vint_Tender = int.Parse(txtTenderID.Text);
                    var listTender = FsDb.Tbl_TendersAuctions.FirstOrDefault(x => x.ID == Vint_Tender);
                    t.txtFYear.Text = listTender.Tbl_Fiscalyear.Name.ToString();
                }

                if ((Application.OpenForms["NotificationLetterWFrm"] as NotificationLetterWFrm != null))
                {
                    t.BringToFront();
                    this.SendToBack();

                }
                else
                {
                    t.Show();
                    t.BringToFront();
                    var ListNotificationRfndLetter = FsDb.Tbl_NotificationLetter.FirstOrDefault(x => x.LetterWarrantyID == Vint_LetterWarantyID);
                    if (ListNotificationRfndLetter != null)
                    {
                        int Vint_RecievedMthd = int.Parse(ListNotificationRfndLetter.RefundLetterReasonsID.ToString());
                        t.cmbRecieveMethode.SelectedValue = Vint_RecievedMthd;
                        t.dTPNotificationDate.Value = Convert.ToDateTime(ListNotificationRfndLetter.NotificationDate.ToString("yyyy/MM/dd"));

                    }
                    else
                    {
                        t.cmbRecieveMethode.SelectedIndex = -1;
                        t.cmbRecieveMethode.Text = "";
                        t.cmbRecieveMethode.SelectedText = "اختر سبب الرد";
                    }
                }
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            Vint_LetterWarantyID = int.Parse(txtLetterWId.Text);
            var listRefund = FsDb.Tbl_RefundLetter.Where(x => x.LetterWarrantyID == Vint_LetterWarantyID).ToList();
            if (txtLetterWId.Text == "")
            {
                MessageBox.Show("من فضلك قم بإختيار خطاب الضمان المراد مده");
            }
            else if (listRefund.Count != 0)
            {
                MessageBox.Show("هذا الخطاب تم رده");
            }
            else
            {
                Vint_LetterWarantyID = int.Parse(txtLetterWId.Text);
                Forms.DocumentsForms.ChangeValueLetterWarrentyFrm t = new Forms.DocumentsForms.ChangeValueLetterWarrentyFrm();
                t.txtLetterKind.Text = this.cmbLetterKind.Text.ToString();
                t.txtBank.Text = this.txtBank.Text;
                t.txtvalue.Text = this.txtLetterValue.Text;
                t.txtcurrency.Text = this.cmbCurrency.SelectedText.ToString();
                t.txtLetterFullNo.Text = this.txtLetterWarrantyNoFull.Text;
                t.txtcurrency.Text = cmbCurrency.Text;
                t.MskStartDate.Value = Convert.ToDateTime(this.dtpLetterDate.Value.ToString("yyyy/MM/dd"));
                t.MskFirstExpandDate.Value = Convert.ToDateTime(this.dTPExpireLetterDate.Value.ToString("yyyy/MM/dd"));
                t.LetterId.Text = this.txtLetterWId.Text;
                t.txtLetterKindID.Text = this.cmbLetterKind.SelectedValue.ToString();
                t.radioGroup1.SelectedIndex = this.radioGroup1.SelectedIndex;

                t.txtPurchMethode.Text = this.cmbPurchMethod.Text.ToString();
                t.txtTenderNo.Text = this.txtTenderNo.Text;
                if (this.txtTenderNo.Text != "")
                {
                    Vint_Tender = int.Parse(txtTenderID.Text);
                    var listTender = FsDb.Tbl_TendersAuctions.FirstOrDefault(x => x.ID == Vint_Tender);
                    t.txtFYear.Text = listTender.Tbl_Fiscalyear.Name.ToString();
                }

                var ListChangeValueLetter = FsDb.Tbl_ChangeValueLetterWarranty.FirstOrDefault(x => x.LetterWarrantyID == Vint_LetterWarantyID);
                if (ListChangeValueLetter != null)
                {

                    t.cmbChangeMethode.SelectedIndex = int.Parse(ListChangeValueLetter.ChangeValueKind.ToString());
                    t.txtChangeValueLetter.Text = ListChangeValueLetter.ChangeValue.ToString();
                    t.dTPDateChange.Value = Convert.ToDateTime(ListChangeValueLetter.ChangeDate.ToString());
                }

                if ((Application.OpenForms["RefundLetterFrm"] as RefundLetterFrm != null))
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
        }
        private void LetterWAuditSelect(int? Vint_LetterWIDC)
        {
            var ListLetterWAuditOrdUser = FsDb.Tbl_LetterWarrentyAudit.FirstOrDefault(x => x.LetterWarrentyID == Vint_LetterWIDC && x.UserID == Program.GlbV_UserId);
            if (ListLetterWAuditOrdUser != null)
            {
                if (ListLetterWAuditOrdUser.LetterWBasicData == true)
                { chckBxBasicData.Checked = true; }
                else
                {
                    chckBxBasicData.Checked = false;
                }
            }
            var ListLetterWAudit = (from LtrWAud in FsDb.Tbl_LetterWarrentyAudit
                                    join usr in FsDb.Tbl_User on LtrWAud.UserID equals usr.ID
                                    join emp in FsDb.Tbl_Employee on usr.Employee_id equals emp.ID
                                    where (LtrWAud.LetterWarrentyID == Vint_LetterWIDC)
                                    select new
                                    {
                                        EmpName = emp.Name
                                    }).Distinct().ToList();
            if (ListLetterWAudit.Count != 0)
            {
                string Vstr_RefrencesOrder = "";
                int WCount = int.Parse(ListLetterWAudit.Count.ToString());
                for (int i = 0; i <= WCount - 1; i++)
                {
                    Vstr_RefrencesOrder = ListLetterWAudit[i].EmpName + " / " + Vstr_RefrencesOrder;
                }
                //chckBxBasicData.Checked = true;
                textBox6.Text = Vstr_RefrencesOrder;
            }
            else
            {
                //chckBxBasicData.Checked = false;
                textBox6.Text = "";
            }
        }
        private void chckBxBasicData_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("عذرا الحدث تحت الانشاء");
            if (txtLetterWId.Text != "")
            {
                int Vint_LetterWID = int.Parse(txtLetterWId.Text);
                bool Vbl_BasicDataOrder = false;
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 71 && w.ProcdureId == 1);
                if (validationSaveUser != null)
                {


                    Vbl_BasicDataOrder = true;
                    var ListOrderAuditLetterUser = FsDb.Tbl_LetterWarrentyAudit.FirstOrDefault(x => x.LetterWarrentyID == Vint_LetterWID && x.UserID == Program.GlbV_UserId);
                    if (ListOrderAuditLetterUser == null)

                    {

                        DateTime Vdt_Today = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));


                        Tbl_LetterWarrentyAudit LttrWAdt = new Tbl_LetterWarrentyAudit
                        {

                            UserID = Program.GlbV_UserId,
                            LetterWarrentyID = Vint_LetterWID,
                            LetterWBasicData = Vbl_BasicDataOrder,
                            //LetterWExpandDate = Vbl_itemso,
                            //LetterWRefundLetter = Vbl_termso,
                            ReferenceDate = Vdt_Today
                        };
                        FsDb.Tbl_LetterWarrentyAudit.Add(LttrWAdt);
                        FsDb.SaveChanges();

                        int Vint_LastRow = LttrWAdt.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة مراجعة خطابات الضمان",
                            TableName = "Tbl_LetterWarrentyAudit",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة مراجعة خطابات الضمان"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم الحفظ");
                        //                //****************Refrences***************
                        LetterWAuditSelect(Vint_LetterWID);
                        //                //***************************************


                    }
                    else
                    {
                        if (chckBxBasicData.Checked == true)
                        {
                            Vbl_BasicDataOrder = true;
                        }
                        else
                        {
                            Vbl_BasicDataOrder = false;
                        }
                        DateTime Vdt_Today = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));

                        var ListLetterWAuditOrdUsero = FsDb.Tbl_LetterWarrentyAudit.FirstOrDefault(x => x.LetterWarrentyID == Vint_LetterWID && x.UserID == Program.GlbV_UserId);
                        ListLetterWAuditOrdUsero.LetterWBasicData = Vbl_BasicDataOrder;
                        //ListOrderAuditOrdUsero.OrderIItemDataID = Vbl_itemso;
                        //ListOrderAuditOrdUsero.OrderITermsID = Vbl_termso;
                        ListLetterWAuditOrdUsero.ReferenceDate = Vdt_Today;
                        FsDb.SaveChanges();
                        MessageBox.Show("تم التعديل");
                        //****************Refrences***************
                        LetterWAuditSelect(Vint_LetterWID);
                        //***************************************

                    }

                }

                else
                {
                    MessageBox.Show("ليس لديك صلاحية اضافة  مراجعه امر .. برجاء مراجعة مدير المنظومه");
                }
            }
            else
            {
                MessageBox.Show("اختر خطاب الضمان المراد مراجعته");
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                Forms.DocumentsForms.LetterWarrentyAuditFrm t = new Forms.DocumentsForms.LetterWarrentyAuditFrm();
                t.txtLetterKind.Text = this.cmbLetterKind.Text.ToString();
                t.txtBank.Text = this.txtBank.Text;

                t.txtLetterFullNo.Text = this.txtLetterWarrantyNoFull.Text;

                //t.MskStartDate.Value = Convert.ToDateTime(this.dtpLetterDate.Value.ToString("yyyy/MM/dd"));

                t.LetterId.Text = this.txtLetterWId.Text;
                t.txtLetterKindID.Text = this.cmbLetterKind.SelectedValue.ToString();
                t.radioGroup1.SelectedIndex = this.radioGroup1.SelectedIndex;
                if (txtLetterWId.Text != "")
                {
                    t.ShowDialog();
                }
                else
                {
                    MessageBox.Show("من فضلك اختر الخطاب المراد مراجعته اولا");
                }
                //if (Forms.DocumentsForms.OrderAuditAddFrm.SelectedRow != null)
                //{
                //    txtSupliers.Text = Forms.DocumentsForms.OrderAuditAddFrm.SelectedRow.Cells[1].Value.ToString();
                //    txtSuplierID.Text = Forms.DocumentsForms.OrderAuditAddFrm.SelectedRow.Cells[0].Value.ToString();

                //}
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {

            if (txtLetterWId.Text != "")
            {
                Forms.DocumentsForms.ScanDocuments t = new Forms.DocumentsForms.ScanDocuments();
                t.txtID.Text = this.txtLetterWId.Text;
                t.txtLetterKind.Text = this.cmbLetterKind.Text.ToString();
                t.txtBank.Text = this.txtBank.Text;
                t.txtLetterFullNo.Text = this.txtLetterWarrantyNoFull.Text;
                t.txtLetterDate.Text = this.dtpLetterDate.Value.ToString("yyyy/MM/dd");

                t.LetterId.Text = this.txtLetterWId.Text;
                t.txtLetterKindID.Text = this.cmbLetterKind.SelectedValue.ToString();
                t.txtvalue.Text = txtLetterValue.Text;
                t.txtcurrency.Text = cmbCurrency.Text;
                t.radioGroup1.SelectedIndex = this.radioGroup1.SelectedIndex;
                t.txtProcessID.Text = "2";
                if ((Application.OpenForms["ScanDocuments"] as ScanDocuments != null))
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
            else
            {
                MessageBox.Show("من فضلك اختر الخطاب المراد مسح اوراقه اولا");
            }

        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            if (txtLetterWId.Text != "")
            {
                Forms.DocumentsForms.ShowScanDocuments t = new Forms.DocumentsForms.ShowScanDocuments();
                t.txtID.Text = this.txtLetterWId.Text;
                t.txtLetterKind.Text = this.cmbLetterKind.Text.ToString();
                t.txtBank.Text = this.txtBank.Text;
                t.txtLetterFullNo.Text = this.txtLetterWarrantyNoFull.Text;
                t.txtLetterDate.Text = this.dtpLetterDate.Value.ToString("yyyy/MM/dd");

                t.LetterId.Text = this.txtLetterWId.Text;
                t.txtLetterKindID.Text = this.cmbLetterKind.SelectedValue.ToString();
                t.txtvalue.Text = txtLetterValue.Text;
                t.txtcurrency.Text = cmbCurrency.Text;
                t.radioGroup1.SelectedIndex = this.radioGroup1.SelectedIndex;
                t.txtProcessID.Text = "2";
                if ((Application.OpenForms["ShowScanDocuments"] as ShowScanDocuments != null))
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
            else
            {
                MessageBox.Show("من فضلك اختر الخطاب المراد مسح اوراقه اولا");
            }
        }

        private void txtFileNo_Leave(object sender, EventArgs e)
        {
            txtProject.Focus();
            int Vst_FileN = int.Parse(txtFileNo.Text);
            int Vint_KindFile = int.Parse(txtFileNoSec.Text);

            var listLWCount = FsDb.Tbl_LetterWarranty.Where(x => x.FileNo == Vst_FileN && x.LetterWarrantyKind == Vint_KindFile).ToList();
            if (listLWCount.Count > 0)
            {
                MessageBox.Show($"هذا الملف تم ادخاله من قبل {Vst_FileN.ToString()} '/' {Vint_KindFile.ToString()}");
                cmbLetterKind.SelectedIndex = -1;
                cmbLetterKind.Text = "اختر نوع الخطاب";


            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox7.Focus();


            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox8.Focus();

            }

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                this.dtb_WarrantyLetterTableAdapter.Fill(this.letterWarranty.Dtb_WarrantyLetter, Vint_LetterProcessID);
                //*******************
                if (dataGridView1.RowCount > 0)
                {
                    txtTotal.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                select Convert.ToDouble(row.Cells[7].Value)).Sum(), 3).ToString();
                    if (txtTotal.Text != "" && txtTotalRef.Text != "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtTotalRef.Text)).ToString(); }
                    else if (txtTotal.Text != "" && txtTotalRef.Text == "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text)).ToString(); }
                    LoopPaintRowLettersState();
                }
                //*****************
            }
            else
            {
                int Vint_FileNo = int.Parse(textBox2.Text);
                int Vint_FileNoto = int.Parse(textBox7.Text);
                this.dtb_WarrantyLetterTableAdapter.FillByFillNoToFillNo(this.letterWarranty.Dtb_WarrantyLetter, Vint_LetterProcessID, Vint_FileNo, Vint_FileNoto);
                //*******************
                if (dataGridView1.RowCount > 0)
                {
                    txtTotal.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                select Convert.ToDouble(row.Cells[7].Value)).Sum(), 3).ToString();
                    if (txtTotal.Text != "" && txtTotalRef.Text != "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtTotalRef.Text)).ToString(); }
                    else if (txtTotal.Text != "" && txtTotalRef.Text == "")
                    { txtBalance.Text = (Convert.ToDecimal(txtTotal.Text)).ToString(); }
                    LoopPaintRowLettersState();
                }
                //*****************
            }
        }
    }
}