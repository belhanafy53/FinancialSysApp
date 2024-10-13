using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using System.IO;
using FinancialSysApp.Forms.DocumentsForms;

namespace FinancialSysApp.Forms.Banks
{
    public partial class BanksTransferesFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int? Vint_benfecairyID = 0;
        string Image_Path = "";
        long? Vlng_TransferID = 0;
        decimal? Vdc_AmountTr = 0;
        int? Vint_BankFrom = 0;
        int? Vint_BankToId = 0;
        int? Vint_AccBankFromID = 0;
        int? Vint_AccBankToID = 0;
        DateTime Vd_TransferDate = DateTime.Now;
        DateTime Vd_AccBankate = DateTime.Now;
        string Vs_DateTransfer = DateTime.Now.ToString();
        public BanksTransferesFrm()
        {
            InitializeComponent();
        }
        private void ClearAllData()
        {
            txtBankFrom.Text = string.Empty;
            txtBankFromID.Text = string.Empty;
            cmbBnkDeposit.SelectedIndex = -1;
            cmbBnkDeposit.Text = "";
            cmbBnkDeposit.Text = "اختر البنك المودع";

            txtBenfeciary.Text = string.Empty;
            txtBenfeciaryID.Text = string.Empty;

            txtTransferAmount.Text = string.Empty;
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = string.Empty;

            comboBox2.SelectedIndex = -1;
            comboBox2.Text = string.Empty;

            txtTransferNo.Text = string.Empty;
            


        }
        private void ClearData()
        {
            txtBankFrom.Text = string.Empty;
            txtBankFromID.Text = string.Empty;
            //cmbBnkDeposit.SelectedIndex = -1;
            //cmbBnkDeposit.Text = "";
            //cmbBnkDeposit.Text = "اختر البنك المودع";

            txtBenfeciary.Text = string.Empty;
            txtBenfeciaryID.Text = string.Empty;

            txtTransferAmount.Text = string.Empty;
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = string.Empty;

            //comboBox2.SelectedIndex = -1;
            //comboBox2.Text = string.Empty;

            txtTransferNo.Text = string.Empty;

            if (radioButton1.Checked == true)
            {
                txtBankFrom.Focus();
            }
            else
            {
                txtBenfeciary.Focus();
            }

            dtpTransferDate1.Select();
            this.ActiveControl = dtpTransferDate1;
            dtpTransferDate1.Focus();
        }
        private void BanksTransferesFrm_Load(object sender, EventArgs e)
        {
            
            // TODO: This line of code loads data into the 'bankCheques.DTBTRansferPayment' table. You can move, or remove it, as needed.
            this.dTBTRansferPaymentTableAdapter.Fill(this.bankCheques.DTBTRansferPayment, Vs_DateTransfer);
            LoadSerial();

            // TODO: This line of code loads data into the 'bankCheques.Dtb_Banks' table. You can move, or remove it, as needed.
            //this.dtb_BanksTableAdapter.FillByBankKind(this.bankCheques.Dtb_Banks);

            ClearDataMaster();
            radioButton1.Checked = true;
            dtpTransferDate1.Select();
            this.ActiveControl = dtpTransferDate1;
            dtpTransferDate1.Focus();

        }
        private void ClearDataMaster()
        {
            var listBnkTo = (from BNK in FsDb.Tbl_Banks
                             join BNKACC in FsDb.Tbl_AccountsBank on BNK.ID equals BNKACC.BankID
                             where (BNKACC.KindAccountBankID == 1)
                             select new
                             {
                                 BnkID = BNK.ID,
                                 BnkName = BNK.Name,
                                 BnkParent = BNK.Parent_ID

                             }).Distinct().OrderBy(x => x.BnkName).ToList();
            cmbBnkDeposit.DataSource = listBnkTo;
            cmbBnkDeposit.DisplayMember = "BnkName";
            cmbBnkDeposit.ValueMember = "BnkID";

            cmbBnkDeposit.SelectedIndex = -1;
            cmbBnkDeposit.Text = "";
            cmbBnkDeposit.Text = "اختر البنك المودع";


            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "";
            comboBox2.Text = "اختر الحساب";

            var listBnkFrom = (from BNK in FsDb.Tbl_Banks
                               join BNKACC in FsDb.Tbl_AccountsBank on BNK.ID equals BNKACC.BankID
                               where (BNKACC.KindAccountBankID == 1)
                               select new
                               {
                                   BnkID = BNK.ID,
                                   BnkName = BNK.Name,
                                   BnkParent = BNK.Parent_ID

                               }).Distinct().OrderBy(x => x.BnkName).ToList();
            cmbBankFrom.DataSource = listBnkFrom;
            cmbBankFrom.DisplayMember = "BnkName";
            cmbBankFrom.ValueMember = "BnkID";

            cmbBankFrom.SelectedIndex = -1;
            cmbBankFrom.Text = "";
            cmbBankFrom.Text = "اختر البنك المحول منه";

            //var ListAccBankF = FsDb.Tbl_AccountsBank.OrderBy(x => x.ID).ToList();
            //comboBox1.DataSource = ListAccBankF;
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "";
            comboBox1.Text = "اختر الحساب";
            txtRowTransferID.Text = "";
            txtTransferNo.Text = "";
            txtTransferAmount.Text = "";
            dtpTransferDate1.Select();
            this.ActiveControl = dtpTransferDate1;
            dtpTransferDate1.Focus();
        }
        private void radioButton1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ClearAllData();
                cmbBnkDeposit.Focus();

            }
            else if (e.KeyCode == Keys.Space)
            {
                radioButton1.Checked = true;
            }
        }

        private void radioButton2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ClearAllData();
                cmbBnkDeposit.Focus();
            }
            else if (e.KeyCode == Keys.Space)
            {
                radioButton2.Checked = true;
            }
        }

        private void dTPTransferDate_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                Vint_BankToId = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                DateTime  Vdt_AccBankAddDate =Convert.ToDateTime(dTPAccAddBank.Value.ToString());
                //this.dTBTRansferPaymentTableAdapter.FillByAccAddDate(this.bankCheques.DTBTRansferPayment, Vdt_AccBankAddDate.ToString(), Vint_BankToId);
                LoadSerial();
                if (radioButton2.Checked == true)
                {
                     
                    txtPaperNo.Focus();
                }
            }
        }

        private void txtBenfeciary_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTransferNo.Focus();


            }
            else if (e.KeyCode == Keys.Down)
            {
                Forms.ProcessingForms.FindBeneficiaryFrm t = new Forms.ProcessingForms.FindBeneficiaryFrm();
                t.ShowDialog();

                if (t.textBox1 != null)
                {
                    if (Forms.ProcessingForms.FindBeneficiaryFrm.SelectedRow != null)
                    {
                        txtBenfeciary.Text = Forms.ProcessingForms.FindBeneficiaryFrm.SelectedRow.Cells[1].Value.ToString();
                        txtBenfeciaryID.Text = Forms.ProcessingForms.FindBeneficiaryFrm.SelectedRow.Cells[0].Value.ToString();
                    }




                }
                txtTransferNo.Focus();
            }

        }

        private void txtBankFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                txtTransferNo.Focus();

            }
            else if (e.KeyCode == Keys.Down)
            {
                Forms.BasicCodeForms.FindBankParentWithAccFrm t = new Forms.BasicCodeForms.FindBankParentWithAccFrm();
                t.ShowDialog();

                if (t.txtBankId != null)
                {
                    txtBankFrom.Text = t.txtSelected.Text;
                    txtBankFromID.Text = t.txtBankId.Text;
                    int Vint_BankFromID = int.Parse(txtBankFromID.Text);

                    if (Vint_BankFromID == 1)
                    { Vint_BankFromID = 2004; }
                    else if (Vint_BankFromID == 2013)
                    { Vint_BankFromID = 2014; }

                    this.tbl_AccountsBank1TableAdapter.FillByBankID(this.bankCheques.Tbl_AccountsBank1, Vint_BankFromID);
                    //if (comboBox1.Items.Count > 1)
                    //{
                    //    comboBox1.SelectedIndex = -1;
                    //    comboBox1.Text = "";
                    //    comboBox1.Text = "اختر رقم الحساب ";
                    //}

                }
                txtTransferNo.Focus();
            }
        }

        private void cmbBnkDeposit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (radioButton1.Checked == true)
                {
                    txtBankFrom.Focus();
                }
                else
                {
                    dTPAccAddBank.Focus();
                }


            }
            else if (e.KeyCode == Keys.Down)
            {
                Forms.BasicCodeForms.FindBankParentFrm t = new Forms.BasicCodeForms.FindBankParentFrm();
                t.ShowDialog();

                if (t.txtBankId != null)
                {
                    cmbBnkDeposit.Text = t.txtSelected.Text;

                    int Vint_BankToID = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                    if (Vint_BankToID == 1)
                    { Vint_BankToID = 2004; }
                    else if (Vint_BankToID == 2013)
                    { Vint_BankToID = 2014; }
                    this.tbl_AccountsBank11TableAdapter.FillByBankID(this.bankCheques.Tbl_AccountsBank11, Vint_BankToID);
                    if (comboBox2.Items.Count > 1)
                    {
                        comboBox2.SelectedIndex = -1;
                        comboBox2.Text = "";
                        comboBox2.Text = "اختر رقم الحساب ";
                        comboBox2.Focus();
                    }
                }

            }
        }

        private void txtTransferAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (radioButton1.Checked == true)
                {
                    simpleButton1.Focus();
                }
                else if (radioButton2.Checked == true)
                {
                    simpleButton1.Focus();
                }
            }
        }

        private void dTpRecievedOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbBnkDeposit.Focus();

            }
        }
        private void LoadSerial()
        {
            int i = 1;


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = i; i++;

            }
            TotalDg1();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            long Vlng_LastRowBankTransfer = 0;
            if (txtTransferAmount.Text == "")
            {
                MessageBox.Show("من فضلك ادخل قيمة التحويل");
                txtTransferAmount.Focus();
            }
            else if (txtRowTransferID.Text == "")
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 98 && w.ProcdureId == 1);
                if (validationSaveUser != null)
                {
                    int Vint_KindTransfere = 0;

                    if (radioButton1.Checked == true)
                    {
                        Vint_KindTransfere = 1;
                        Vint_benfecairyID = null;

                        if (comboBox2.Text != null)
                        { Vint_AccBankToID = int.Parse(comboBox2.SelectedValue.ToString()); }



                        Vdc_AmountTr = decimal.Parse(txtTransferAmount.Text);

                        Vint_BankToId = int.Parse(cmbBnkDeposit.SelectedValue.ToString());

                        Vint_BankFrom = int.Parse(cmbBankFrom.SelectedValue.ToString());

                        Vd_TransferDate = Convert.ToDateTime(dtpTransferDate1.Value.ToString("yyyy/MM/dd"));

                        Vd_AccBankate = Convert.ToDateTime(dTPAccAddBank.Value.ToString("yyyy/MM/dd"));

                        if (comboBox1.Text != "")
                        { Vint_AccBankFromID = int.Parse(comboBox1.SelectedValue.ToString()); }


                        Tbl_BankTransferPayment trb = new Tbl_BankTransferPayment()
                        {
                            TransfereKindID = Vint_KindTransfere,

                            TransferAmount = Vdc_AmountTr,
                            FromBankID = Vint_BankFrom,
                            FromBankAccID = Vint_AccBankFromID,
                            ToBankID = Vint_BankToId,
                            ToBankAccID = Vint_AccBankToID,
                            TransferDate = Vd_TransferDate,
                            TransferNo = txtTransferNo.Text ,
                            BankAccDateAdd = Vd_AccBankate ,
                            PaperNo = txtPaperNo.Text
                        };
                        FsDb.Tbl_BankTransferPayment.Add(trb);
                        FsDb.SaveChanges();
                        Vlng_LastRowBankTransfer = trb.ID;
                    }
                    else
                    {
                        Vint_KindTransfere = 2;
                        if (txtBenfeciaryID.Text == "")
                        {
                            MessageBox.Show("من فضلك اختر المستفيد");
                            txtBenfeciary.Focus();

                        }
                        else
                        {
                            Vint_benfecairyID = null;
                            Vint_benfecairyID = int.Parse(txtBenfeciaryID.Text);
                            


                            if (comboBox2.Text != null)
                            { Vint_AccBankToID = int.Parse(comboBox2.SelectedValue.ToString()); }



                            Vdc_AmountTr = decimal.Parse(txtTransferAmount.Text);

                            Vint_BankToId = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                            //if (txtBankFromID.Text != "")
                            //{ Vint_BankFrom = int.Parse(txtBankFromID.Text); }
                            txtBankFromID.Text = "";
                            

                            Vd_TransferDate = Convert.ToDateTime(dtpTransferDate1.Value.ToString("yyyy/MM/dd"));

                            Vd_AccBankate = Convert.ToDateTime(dTPAccAddBank.Value.ToString("yyyy/MM/dd"));
                            Tbl_BankTransferPayment trb = new Tbl_BankTransferPayment()
                            {
                                TransfereKindID = Vint_KindTransfere,
                                BeneficiaryID = Vint_benfecairyID,
                                TransferAmount = Vdc_AmountTr,
                                //FromBankID = Vint_BankFrom,
                                //FromBankAccID = Vint_AccBankFromID,
                                ToBankID = Vint_BankToId,
                                ToBankAccID = Vint_AccBankToID,
                                TransferDate = Vd_TransferDate,
                                TransferNo = txtTransferNo.Text  ,
                                BankAccDateAdd = Vd_AccBankate,
                                PaperNo = txtPaperNo.Text
                            };
                            FsDb.Tbl_BankTransferPayment.Add(trb);
                            FsDb.SaveChanges();
                            Vlng_LastRowBankTransfer = trb.ID;
                        }
                    }
     
                    
                    MessageBox.Show("تم الحفظ");
                    txtRowTransferID.Text = "";
                    ClearDataMaster();

                    this.dTBTRansferPaymentTableAdapter.Fill(this.bankCheques.DTBTRansferPayment, Vs_DateTransfer);
                    LoadSerial();
                    //---------------خفظ ااحداث 
                    SecurityEvent sev = new SecurityEvent
                    {
                        ActionName = "اضافة تحويل بنكي",
                        TableName = "Tbl_BankTransferPayment",
                        TableRecordId = Vlng_LastRowBankTransfer.ToString(),
                        Description = "",
                        ManagementName = Program.GlbV_Management,
                        ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                        EmployeeName = Program.GlbV_EmpName,
                        User_ID = Program.GlbV_UserId,
                        UserName = Program.GlbV_UserName,
                        FormName = "شاشة التحويل البنكي"

                    };

                    FsEvDb.SecurityEvents.Add(sev);
                    FsEvDb.SaveChanges();
                    //************************************
                    ClearData();
                   
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية اضافة تحويل بنكي .. برجاء مراجعة مدير المنظومه");
                    return;
                }
            }
            else if (txtRowTransferID.Text != "")
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 98 && w.ProcdureId == 2);
                if (validationSaveUser != null)
                {
                    Vlng_TransferID = long.Parse(txtRowTransferID.Text);
                    var ListTransfer = FsDb.Tbl_BankTransferPayment.Where(x => x.ID == Vlng_TransferID).ToList();


                    ListTransfer[0].TransferDate = dTPAccAddBank.Value;
                    if (txtBenfeciaryID.Text != "")
                    { ListTransfer[0].BeneficiaryID = int.Parse(txtBenfeciaryID.Text); }
                    if (txtBankFromID.Text != "")
                    {
                        ListTransfer[0].FromBankID = int.Parse(txtBankFromID.Text);
                   
                    ListTransfer[0].FromBankAccID = int.Parse(comboBox1.SelectedValue.ToString());
                    }
                    ListTransfer[0].ToBankID = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                    ListTransfer[0].ToBankAccID = int.Parse(comboBox2.SelectedValue.ToString());
                    ListTransfer[0].PaperNo = txtPaperNo.Text;
                    ListTransfer[0].TransferAmount = Convert.ToDecimal(txtTransferAmount.Text);

                   FsDb.SaveChanges();
                    MessageBox.Show("تم التعديل");
                    Vint_BankToId = ListTransfer[0].ToBankID;
                    this.dTBTRansferPaymentTableAdapter.Fill(this.bankCheques.DTBTRansferPayment, Vs_DateTransfer);
                    LoadSerial();
                    txtRowTransferID.Text = "";
                    //---------------خفظ ااحداث 
                    SecurityEvent sev = new SecurityEvent
                    {
                        ActionName = "تعديل تحويل بنكي",
                        TableName = "Tbl_BankTransferPayment",
                        TableRecordId = ListTransfer[0].ID.ToString(),
                        Description = "",
                        ManagementName = Program.GlbV_Management,
                        ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                        EmployeeName = Program.GlbV_EmpName,
                        User_ID = Program.GlbV_UserId,
                        UserName = Program.GlbV_UserName,
                        FormName = "شاشة التحويلات البنكيه"

                    };

                    FsEvDb.SecurityEvents.Add(sev);
                    FsEvDb.SaveChanges();
                    //************************************
                    ClearDataMaster();
                    txtRowTransferID.Text = "";
                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية تعديل  تحويل بنكي .. برجاء مراجعة مدير المنظومه");
                return;
            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (txtRowTransferID.Text != "")
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 98 && w.ProcdureId == 2);
                if (validationSaveUser != null)
                {
                    var resultMessageYesNo = MessageBox.Show("هل تريد حذف هدا التحويل  ؟", "حدف  تحويل بنكي ", MessageBoxButtons.YesNo);

                    if (resultMessageYesNo == DialogResult.Yes)
                    {
                        Vlng_TransferID = long.Parse(txtRowTransferID.Text);
                        var ListTransfer = FsDb.Tbl_BankTransferPayment.FirstOrDefault(x => x.ID == Vlng_TransferID);
                        FsDb.Tbl_BankTransferPayment.Remove(ListTransfer);
                        FsDb.SaveChanges();
                        MessageBox.Show("تم الحذف");
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "حذف تحويل بنكي",
                            TableName = "Tbl_BankTransferPayment",
                            TableRecordId = Vlng_TransferID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة تحويلات بنكيه"

                        };

                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        txtRowTransferID.Text = "";
                        //************************************
                        ClearDataMaster();
                        Vint_BankToId = ListTransfer.ToBankID;
                        this.dTBTRansferPaymentTableAdapter.Fill(this.bankCheques.DTBTRansferPayment, Vs_DateTransfer);
                        LoadSerial();
                    }
                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية حذف  تحويل بنكي .. برجاء مراجعة مدير المنظومه");
                return;
            }
        }

        private void radioButton1_Leave(object sender, EventArgs e)
        {
            ClearAllData();
        }

        private void radioButton2_Leave(object sender, EventArgs e)
        {
            ClearAllData();
        }

        private void txtBenfeciary_Leave(object sender, EventArgs e)
        {
            //if (radioButton2.Checked == true && txtBenfeciaryID.Text == "")
            //{
            //    txtBenfeciary.Focus();
            //}
        }

        private void txtBankFrom_Leave(object sender, EventArgs e)
        {
            //if (radioButton1.Checked == true && txtBankFrom.Text == "")
            //{
            //    txtBankFrom.Focus();
            //}
        }

        private void dTPTransferDate_Leave(object sender, EventArgs e)
        {
            //if (radioButton1.Checked == true)
            //{

            //    //txtBankFrom.Focus();
            dTPAccAddBank.Value = dtpTransferDate1.Value;
            //}
            //else if (radioButton2.Checked == true)
            //{
            //    txtBenfeciary.Focus();
            //}
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                dTPAccAddBank.Visible = false;
                label3.Visible = false;
                label5.Visible = false;
                label15.Visible = false;
                txtPaperNo.Visible = false;
                txtBenfeciary.Visible = false;

                label7.Visible = true;
                //txtBankFrom.Visible = true;

                radioButton2.Checked = false;
                label8.Visible = true;
                dTpRecievedOrder.Visible = true;
                comboBox1.Visible = true;
                label11.Visible = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                radioButton1.Checked = false;
                label5.Visible = true;
                txtBenfeciary.Visible = true;

                label7.Visible = false;
                //txtBankFrom.Visible = false;

                label8.Visible = false;
                dTpRecievedOrder.Visible = false;
                comboBox1.Visible = false;
                label11.Visible = false;

                dTPAccAddBank.Visible = true;
                label3.Visible = true;

                label15.Visible = true;
                txtPaperNo.Visible = true;

            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Vint_BankToId = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                string VdTrfBank = dtpTransferDate1.Value.ToString();
                int Vint_AccBankToId = int.Parse(comboBox2.SelectedValue.ToString());
                int Vint_BankFromId = int.Parse(cmbBankFrom.SelectedValue.ToString());
                int Vint_AccBankFrId = int.Parse(comboBox1.SelectedValue.ToString());
                this.dTBTRansferPaymentTableAdapter.FillByAllDataAccBankFr(this.bankCheques.DTBTRansferPayment, Vint_BankToId, Vint_AccBankToId, VdTrfBank, Vint_BankFromId, Vint_AccBankFrId);
                LoadSerial();
                txtTransferNo.Focus();

            }
        }
        private void TotalDg1 ()
        {
            txtAllValueall.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                    select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
            txtAllTrCount.Text = (from DataGridViewRow row in dataGridView1.Rows
                                            select Convert.ToDouble(row.Cells[1].Value)).Count().ToString();
        }
        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (radioButton1.Checked == true)
                {
                    Vint_BankToId = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                    string VdTrfBank = dtpTransferDate1.Value.ToString();
                    int Vint_AccBankToId  = int.Parse(comboBox2.SelectedValue.ToString());
                    this.dTBTRansferPaymentTableAdapter.FillByAccAddDate(this.bankCheques.DTBTRansferPayment, Vint_BankToId, Vint_AccBankToId, VdTrfBank);
                    LoadSerial();
                    cmbBankFrom.Focus();
                }
                else if (radioButton2.Checked == true)
                {
                    dTPAccAddBank.Focus();
                }

            }
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRowTransferID.Text != "")
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
                            string Vstr_HirarckyID = "149";
                            string Vstr_ProcessKindID = "";
                            string Vstr_YearDate = "";
                            string Vstr_MonthDate = "";
                            string Vstr_IDCheque = "";

                            Vlng_IdItem = int.Parse(txtRowTransferID.Text);
                            if (Vlng_IdItem != 0)
                            {

                                Vstr_ProcessKindID = "7";

                                DateTime Vdt_DateP = Convert.ToDateTime(dTPAccAddBank.Value.ToString());



                                Vstr_YearDate = (Vdt_DateP.Year).ToString();

                                Vstr_MonthDate = (Vdt_DateP.Month).ToString();

                                Vstr_IDCheque = txtRowTransferID.Text;

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
                                Vlng_IdItem = long.Parse(txtRowTransferID.Text);

                                var list = FsEvDb.Tbl_ArchBankTransfer.Where(x => x.BankTransferPayID == Vlng_IdItem && x.DocumentHirarchyID == 149).ToList();

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

                                    Tbl_ArchBankTransfer ArchD = new Tbl_ArchBankTransfer()
                                    {
                                        BankTransferPayID = long.Parse(txtRowTransferID.Text),
                                        DocumentHirarchyID = 136,
                                        PathFile = PathFile
                                    };
                                    FsEvDb.Tbl_ArchBankTransfer.Add(ArchD);
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
                    MessageBox.Show("من فضلك اختر التحويل البنكي المراد عرض صورته اولا");
                }

            }
            catch
            {

            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
             
            DataGridViewRow currentRow = dataGridView1.CurrentRow;
            
            txtRowTransferID.Text = currentRow.Cells[1].Value.ToString();
            Vlng_TransferID = int.Parse(txtRowTransferID.Text);
            var listTrPay =   FsDb.Tbl_BankTransferPayment.Where(x => x.ID == Vlng_TransferID).ToList();

            cmbBankFrom.SelectedValue =int.Parse( listTrPay[0].FromBankID.ToString());
           

            int Vint_accBankF = int.Parse(listTrPay[0].FromBankAccID.ToString());
            var ListAccBankF = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_accBankF).OrderBy(x => x.ID).ToList();

            comboBox1.DataSource = ListAccBankF;
            comboBox1.DisplayMember = "AccountBankNo";
            comboBox1.ValueMember = "ID";

            comboBox1.SelectedValue = Vint_accBankF;
            comboBox1.Text = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_accBankF).Select(x => x.AccountBankNo).FirstOrDefault();
                 
            cmbBnkDeposit.SelectedValue = int.Parse(listTrPay[0].ToBankID.ToString()) ;
           

            int Vint_accBankT = int.Parse(listTrPay[0].ToBankAccID.ToString());
            var ListAccBankT = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_accBankF).OrderBy(x => x.ID).ToList();

            comboBox2.DataSource = ListAccBankT;
            comboBox2.DisplayMember = "AccountBankNo";
            comboBox2.ValueMember = "ID";
            comboBox2.SelectedValue = Vint_accBankT;
            comboBox2.Text = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_accBankT).Select(x => x.AccountBankNo).FirstOrDefault();

            Vint_BankToId = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
            var listAccBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_BankToId).ToList();
            
            txtTransferAmount.Text = listTrPay[0].TransferAmount.ToString();
            txtTransferNo.Text = listTrPay[0].TransferNo.ToString();
            if (listTrPay[0].PaperNo != null)
            { txtPaperNo.Text = listTrPay[0].PaperNo.ToString(); }
             
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            if (txtRowTransferID.Text != "")
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
                    string Vstr_HirarckyID = "149";
                    string Vstr_ProcessKindID = "";
                    string Vstr_YearDate = "";
                    string Vstr_MonthDate = "";
                    string Vstr_IDCheque = "";

                    Vlng_IdItem = int.Parse(txtRowTransferID.Text);
                    if (Vlng_IdItem != 0)
                    {

                        Vstr_ProcessKindID = "7";

                        DateTime Vdt_DateP = Convert.ToDateTime(dTPAccAddBank.Value.ToString());



                        Vstr_YearDate = (Vdt_DateP.Year).ToString();

                        Vstr_MonthDate = (Vdt_DateP.Month).ToString();

                        Vstr_IDCheque = txtRowTransferID.Text;

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
                        Vlng_IdItem = long.Parse(txtRowTransferID.Text);

                        var list = FsEvDb.Tbl_ArchTrCollectioCheque.Where(x => x.ChequeBankID == Vlng_IdItem && x.DocumentHirarchyID == 149).ToList();

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


                            Tbl_ArchBankTransfer ArchD = new Tbl_ArchBankTransfer()
                            {
                                BankTransferPayID = long.Parse(txtRowTransferID.Text),
                                DocumentHirarchyID = 149,
                                PathFile = PathFile
                            };
                            FsEvDb.Tbl_ArchBankTransfer.Add(ArchD);
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
                MessageBox.Show("من فضلك اختر التحويل المراد عرض صورته اولا");
            }
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            if (txtRowTransferID.Text != "")
            {
                Forms.DocumentsForms.CheqScanFrm t = new Forms.DocumentsForms.CheqScanFrm();
                //**************بيانات الخافظه 
                //t.txtbranch.Text = this..Text;
                //t.txtCollectionNo.Text = this.txtCollectionNo.Text;
                t.dTPCollectionDate.Value = Convert.ToDateTime(this.dTPAccAddBank.Value.ToString("yyyy/MM/dd"));
                t.txtBankD.Text = this.txtBankFrom.Text;
                //*************بيانات الشيك
                t.txtRowChequeID.Text = this.txtRowTransferID.Text;
                //t.txtChequeNoScan.Text = this.txtChequeNoScan.Text;
                t.txtAmountScan.Text = this.txtTransferAmount.Text;
                t.txtBankDrawnOnScan.Text = this.cmbBnkDeposit.Text;
                //t.dTPDueDateScan.Value = Convert.ToDateTime(this.dTPDueDateScan.Value.ToString("yyyy/MM/dd"));


                //***********************
                long Vint_ID = long.Parse(this.txtRowTransferID.Text);
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
                MessageBox.Show("من فضلك اختر التحويل المراد عرض صورته اولا");
            }
        }

        private void txtPaperNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBenfeciary.Focus();

            }

        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                string Vs_TrDate =  dtpTransferDate1.Value.ToString() ;
                this.dTBTRansferPaymentTableAdapter.Fill(this.bankCheques.DTBTRansferPayment, Vs_TrDate);
                LoadSerial();
                dTpRecievedOrder.Focus();
                
                 

            }
        }

        private void txtTransferNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                txtTransferAmount.Focus();


            }
        }

        private void cmbBnkDeposit_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbBnkDeposit.SelectedIndex !=  -1)
                {
                    Vint_BankToId = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                    string VdTrfBank = dtpTransferDate1.Value.ToString();
                    this.dTBTRansferPaymentTableAdapter.FillByBankDep(this.bankCheques.DTBTRansferPayment, Vint_BankToId, VdTrfBank);
                    LoadSerial();
                    var listAccBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_BankToId).ToList();
                    comboBox2.DataSource = listAccBank;
                    comboBox2.DisplayMember = "AccountBankNo";
                    comboBox2.ValueMember = "ID";
                    int Vin_countItem = comboBox2.Items.Count;
                    if (comboBox2.Items.Count > 1)
                    {
                        comboBox2.SelectedIndex = -1;
                        comboBox2.Text = "اختر رقم الحساب";
                        comboBox2.Focus();
                    }
                    else
                    {
                        cmbBankFrom.Select();
                        this.ActiveControl = cmbBankFrom;
                        cmbBankFrom.Focus();
                    }
                }
        
                
            }
        }

        private void cmbBnkDeposit_Leave(object sender, EventArgs e)
        {

            if (cmbBnkDeposit.SelectedIndex != -1)
            {
                Vint_BankToId = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                string VdTrfBank = dtpTransferDate1.Value.ToString();
                this.dTBTRansferPaymentTableAdapter.FillByBankDep(this.bankCheques.DTBTRansferPayment, Vint_BankToId, VdTrfBank);
                LoadSerial();
                var listAccBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_BankToId).ToList();
                comboBox2.DataSource = listAccBank;
                comboBox2.DisplayMember = "AccountBankNo";
                comboBox2.ValueMember = "ID";
                int Vin_countItem = comboBox2.Items.Count;
                if (comboBox2.Items.Count > 1)
                {
                    comboBox2.SelectedIndex = -1;
                    comboBox2.Text = "اختر رقم الحساب";
                    comboBox2.Focus();
                }
                else
                {
                    cmbBankFrom.Select();
                    this.ActiveControl = cmbBankFrom;
                    cmbBankFrom.Focus();
                }
            }

        }

        private void cmbBankFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbBankFrom.SelectedIndex != -1)
                {
                    Vint_BankToId = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                    string VdTrfBank = dtpTransferDate1.Value.ToString();
                    int Vint_AccBankToId = int.Parse(comboBox2.SelectedValue.ToString());
                    int Vint_BankFromId = int.Parse(cmbBankFrom.SelectedValue.ToString()); 
                    this.dTBTRansferPaymentTableAdapter.FillByAlldataBankFr(this.bankCheques.DTBTRansferPayment, Vint_BankToId, Vint_AccBankToId, VdTrfBank, Vint_BankFromId);
                    LoadSerial();
                    var listAccBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_BankFrom).ToList();
                    comboBox1.DataSource = listAccBank;
                    comboBox1.DisplayMember = "AccountBankNo";
                    comboBox1.ValueMember = "ID";
                    
                    if (comboBox1.Items.Count > 1)
                    {
                        comboBox1.SelectedIndex = -1;
                        comboBox1.Text = "اختر رقم الحساب";
                        comboBox1.Focus();
                    }
                    else
                    {
                        txtTransferNo.Select();
                        this.ActiveControl = txtTransferNo;
                        txtTransferNo.Focus();
                    }
                }
                 

            }
        }

        private void cmbBankFrom_Leave(object sender, EventArgs e)
        {
            if (cmbBankFrom.SelectedIndex != -1)
            {
                Vint_BankFrom = int.Parse(cmbBankFrom.SelectedValue.ToString());
                //this.dTBTRansferPaymentTableAdapter.FillByBankDep(this.bankCheques.DTBTRansferPayment, Vint_BankFrom);
                //LoadSerial();
                var listAccBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_BankFrom).ToList();
                comboBox1.DataSource = listAccBank;
                comboBox1.DisplayMember = "AccountBankNo";
                comboBox1.ValueMember = "ID";

                if (comboBox1.Items.Count > 1)
                {
                    comboBox1.SelectedIndex = -1;
                    comboBox1.Text = "اختر رقم الحساب";
                    comboBox1.Focus();
                }
                else
                {
                    txtTransferNo.Select();
                    this.ActiveControl = txtTransferNo;
                    txtTransferNo.Focus();
                }
            }
        }
    }
}