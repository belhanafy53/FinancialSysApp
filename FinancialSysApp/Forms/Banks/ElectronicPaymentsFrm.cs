using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;

namespace FinancialSysApp.Forms.Banks
{
    public partial class ElectronicPaymentsFrm : DevExpress.XtraEditors.XtraForm
    {
        string Vst_DepositDate1 = DateTime.Today.ToString();
        string Vst_DepositDate2 = DateTime.Today.ToString();
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        public ElectronicPaymentsFrm()
        {
            InitializeComponent();
        }


        private void TotalDg1()
        {
            txtAllValue.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                           select Convert.ToDouble(row.Cells[10].Value)).Sum(), 3).ToString();
            txtAllCount.Text = (from DataGridViewRow row in dataGridView1.Rows
                                select Convert.ToDouble(row.Cells[1].Value)).Count().ToString();


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

        private void LoopPaintRowDueSateNotFYear()
        {


            //int Vint_RowID = 0;
            int Vint_branchID = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (row.Cells[26].Value.ToString() != "")
                {
                    Vint_branchID = int.Parse(row.Cells[26].Value.ToString());

                    if (Vint_branchID > 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.Green;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.Black;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
        }
        private void ElectronicPaymentsFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankCheques.Tbl_BankMovingType3' table. You can move, or remove it, as needed.
            this.tbl_BankMovingType3TableAdapter.Fill(this.bankCheques.Tbl_BankMovingType3);
            // TODO: This line of code loads data into the 'bankTransmentDS.Tbl_CustmersType' table. You can move, or remove it, as needed.
            this.tbl_CustmersTypeTableAdapter.FillByElectronicPayment(this.bankTransmentDS.Tbl_CustmersType);
            this.dataTable1TableAdapter.FillByElectronicPayment(this.bankTransmentDS.DataTable1);
            var listCustType = FsDb.Tbl_CustmersType.Where(x => x.IsElectronicPaymentNo == true).OrderBy(x => x.Parent_ID).ToList();
            comboBox1.DataSource = listCustType;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            comboBox1.SelectedIndex = 0;
            comboBox1.Text = "اختر تصنيف العملاء";

            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "";
           comboBox2.Text = "اختر تصنيف ";
            LoadSerial();
            TotalDg1();
            LoopPaintRowDueSateNotFYear();
            ClearData();
            txtAmountSrch.Select();
            this.ActiveControl = txtAmountSrch;
            txtAmountSrch.Focus();

        }

        private void txtCodeSrch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCodeSrch.Text != "")
                {
                    textBox1.Text = "";
                    txtAmountSrch.Text = "";
                    textBox3.Text = "";
                    if (checkBox1.Checked != true)
                    {
                        long Vd_TradeCode = long.Parse(txtCodeSrch.Text);
                        this.dataTable1TableAdapter.FillByTradeCode(this.bankTransmentDS.DataTable1, Vd_TradeCode);
                        LoopPaintRowDueSateNotFYear();
                        LoadSerial();
                        TotalDg1();
                        textBox2.Focus();
                    }
                    else
                    {
                        textBox1.Text = "";
                        txtAmountSrch.Text = "";
                        textBox3.Text = "";
                        long Vd_TradeCode = long.Parse(txtCodeSrch.Text);
                        this.dataTable1TableAdapter.FillByAllTradeCode(this.bankTransmentDS.DataTable1, Vd_TradeCode);
                        LoopPaintRowDueSateNotFYear();
                        LoadSerial();
                        TotalDg1();
                    }
                }
                dataGridView1.Focus();

            }
        }

        private void txtAmountSrch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCodeSrch.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox1.Focus();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dtp_MoveDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtp_DueDate.Focus();
            }
        }

        private void dtp_DueDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDescription.Focus();
            }
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtvalue.Focus();
            }
        }

        private void txtvalue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbType.Focus();
            }
        }

        private void cmbType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBranch.Focus();
            }
        }

        private void txtBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                dateTimePicker1.Focus();

            }
            else if (e.KeyCode == Keys.Down)
            {
                if (Program.GlbV_SysUnite_ID == 11)
                {
                    Forms.BasicCodeForms.FindBranchFrm t = new Forms.BasicCodeForms.FindBranchFrm();

                    t.ShowDialog();
                    if (Forms.BasicCodeForms.FindBranchFrm.SelectedRow != null)
                    {
                        txtBranch.Text = Forms.BasicCodeForms.FindBranchFrm.SelectedRow.Cells[1].Value.ToString();
                        txtBranchId.Text = Forms.BasicCodeForms.FindBranchFrm.SelectedRow.Cells[0].Value.ToString();
                    }
                }
                else if (Program.GlbV_SysUnite_ID == 12)
                {
                    Forms.BasicCodeForms.FindDirectionFrm t = new Forms.BasicCodeForms.FindDirectionFrm();

                    t.ShowDialog();
                    if (Forms.BasicCodeForms.FindDirectionFrm.SelectedRow != null)
                    {
                        txtBranch.Text = Forms.BasicCodeForms.FindDirectionFrm.SelectedRow.Cells[1].Value.ToString();
                        txtBranchId.Text = Forms.BasicCodeForms.FindDirectionFrm.SelectedRow.Cells[0].Value.ToString();
                    }
                }

            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                simpleButton1.Focus();

            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dataGridView1.RowCount > 0)
            {
                ClearData();

                txtRowId.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                long Vlng_IDmv = long.Parse(txtRowId.Text);

                var listbnkmov = FsDb.Tbl_BankMovement.Where(x => x.ID == Vlng_IDmv).ToList();
                 
                dtp_MoveDate.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[6].Value.ToString());

                dtp_DueDate.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[7].Value.ToString());

                txtDescription.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();

                txtvalue.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();



                txtBank.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();

                txtBankAcc.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();

                txtBankPurposeAcc.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();



                cmbType.SelectedValue = int.Parse(dataGridView1.CurrentRow.Cells[28].Value.ToString());

                txtBranchId.Text = dataGridView1.CurrentRow.Cells[25].Value.ToString();

                int Vint_BranchId = int.Parse(txtBranchId.Text);

                txtBranch.Text = FsDb.Tbl_Management.Where(x => x.ID == Vint_BranchId).Select(x => x.BrancheName).ToString();

                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
                if (listbnkmov[0].MoveType3 > 0)
                {
                    comboBox2.SelectedValue = int.Parse(listbnkmov[0].MoveType3.ToString());
                }

                cmbType.Select();

                cmbType.Focus();

                this.ActiveControl = cmbType;
            }
        }
        private void ClearData()
        {
            txtRowId.Text = "";
            dtp_MoveDate.Value = Convert.ToDateTime(DateTime.Today.ToString());

            dtp_DueDate.Value = Convert.ToDateTime(DateTime.Today.ToString());

            //dateTimePicker1.Value = Convert.ToDateTime(DateTime.Today.ToString());

            txtDescription.Text = "";

            txtvalue.Text = "";

            txtBank.Text = "";

            txtBankAcc.Text = "";

            txtBankPurposeAcc.Text = "";

            cmbType.SelectedIndex = 0;

            cmbType.Text = "اختر تصنيف العملاء";

            textBox4.Text = "";

            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;

            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "";
            comboBox2.Text = "اختر تصنيف ";
            //txtBranch.Text = string.Empty;
            //txtBranchId.Text = string.Empty;
            txtRowId.Text = string.Empty;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 122 && w.ProcdureId == 3);
            if (validationSaveUser != null)
            {
                int? vint_branchID = null;
                int vint_RowID = int.Parse(txtRowId.Text);
                int Vint_CustType = int.Parse(cmbType.SelectedValue.ToString());
                if (txtBranchId.Text != "")
                { vint_branchID = int.Parse(txtBranchId.Text); }
                DateTime Vd_DayDate = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd"));

                var ListBnkMov = FsDb.Tbl_BankMovement.Where(x => x.ID == vint_RowID).ToList();
                ListBnkMov[0].TradeMoveType = Vint_CustType;
                ListBnkMov[0].BranchId = vint_branchID;
                ListBnkMov[0].DailyDate = Vd_DayDate;
                if (comboBox2.SelectedValue != null)
                { ListBnkMov[0].MoveType3 = int.Parse(comboBox2.SelectedValue.ToString()); }
                if (checkBox5.Checked == true)
                {
                    if (textBox4.Text != "")
                    { ListBnkMov[0].TradeCode = long.Parse(textBox4.Text); }
                }
                var ListElctPayAudit = FsDb.Tbl_MovementTypingAudit.Where(x => x.BankMovementID == vint_RowID).ToList();
                if (ListElctPayAudit.Count > 0)
                {
                    ListElctPayAudit[0].IsUpdate = true;
                    ListElctPayAudit[0].UpdateDate = Convert.ToDateTime(DateTime.Today.ToShortDateString());
                    ListElctPayAudit[0].UserIDData = int.Parse(Program.GlbV_UserId.ToString());

                }
                FsDb.SaveChanges();
                MessageBox.Show("تم الحفظ");
                //---------------خفظ ااحداث 
                SecurityEvent sev = new SecurityEvent
                {
                    ActionName = "اضافة تصنيف دفع اليكتروني",
                    TableName = "Tbl_BankMovement",
                    TableRecordId = vint_RowID.ToString(),
                    Description = "",
                    ManagementName = Program.GlbV_Management,
                    ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                    EmployeeName = Program.GlbV_EmpName,
                    User_ID = Program.GlbV_UserId,
                    UserName = Program.GlbV_UserName,
                    FormName = "شاشة الدفع الاليكتروني"

                };

                FsEvDb.SecurityEvents.Add(sev);
                FsEvDb.SaveChanges();
                //************************************
                this.tbl_CustmersTypeTableAdapter.Fill(this.bankTransmentDS.Tbl_CustmersType);
                this.dataTable1TableAdapter.FillByElectronicPayment(this.bankTransmentDS.DataTable1);
                LoopPaintRowDueSateNotFYear();
                LoadSerial();
                TotalDg1();
                checkBox5.Checked = false;
                ClearData();
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية اضافة تصنيف دفع اليكتروني ... برجاء مراجعة مدير المنظومه");
            }
        }

        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtAmountSrch.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (checkBox1.Checked != true)
                {
                    txtCodeSrch.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";

                    Decimal Vd_AmountSearch = 0;
                    if (txtAmountSrch.Text == "")
                    {
                        Vd_AmountSearch = Convert.ToDecimal(textBox1.Text);
                    }
                    else
                    {
                        Vd_AmountSearch = Convert.ToDecimal(txtAmountSrch.Text);
                    }
                    Decimal Vd_AmountSearch1 = Convert.ToDecimal(textBox1.Text);

                    this.dataTable1TableAdapter.FillByMvAmountType(this.bankTransmentDS.DataTable1, Vd_AmountSearch, 5, 15, Vd_AmountSearch1);
                    LoopPaintRowDueSateNotFYear();
                    LoadSerial();
                    TotalDg1();

                }
                else
                {
                    txtCodeSrch.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    Decimal Vd_AmountSearch = Convert.ToDecimal(textBox1.Text);
                    Decimal Vd_AmountSearch1 = Convert.ToDecimal(textBox1.Text);
                    this.dataTable1TableAdapter.FillByAllMvAmount(this.bankTransmentDS.DataTable1, Vd_AmountSearch, 5, 15, Vd_AmountSearch1);
                    LoopPaintRowDueSateNotFYear();
                    LoadSerial();
                    TotalDg1();
                }
                txtCodeSrch.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox2.Text != "")
                {
                    txtCodeSrch.Text = "";
                    textBox1.Text = "";
                    textBox3.Text = "";
                    txtAmountSrch.Text = "";
                    if (checkBox1.Checked != true)
                    {
                        string mvmcode = textBox2.Text;
                        this.dataTable1TableAdapter.FillByMovCode(this.bankTransmentDS.DataTable1, mvmcode);
                        LoopPaintRowDueSateNotFYear();
                        LoadSerial();
                        TotalDg1();
                    }
                    else
                    {
                        string mvmcode = textBox2.Text;
                        this.dataTable1TableAdapter.FillByAllMvCode(this.bankTransmentDS.DataTable1, mvmcode);
                        LoopPaintRowDueSateNotFYear();
                        LoadSerial();
                        TotalDg1();
                    }
                }
                dataGridView1.Focus();

            }
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker3.Focus();
            }
        }

        private void dateTimePicker3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (checkBox1.Checked != true)
                {
                    string ms_date1 = dateTimePicker2.Value.ToString();
                    string ms_date2 = dateTimePicker3.Value.ToString();
                    this.dataTable1TableAdapter.FillByMovDate(this.bankTransmentDS.DataTable1, 5, 15, ms_date1, ms_date2);
                    LoopPaintRowDueSateNotFYear();
                    LoadSerial();
                    TotalDg1();
                    checkBox2.Checked = true;
                    checkBox3.Checked = false;

                }
                else if (checkBox1.Checked == true)
                {
                    string ms_date1 = dateTimePicker2.Value.ToString();
                    string ms_date2 = dateTimePicker3.Value.ToString();
                    this.dataTable1TableAdapter.FillByAllMoveDate(this.bankTransmentDS.DataTable1, 5, 15, ms_date1, ms_date2);
                    LoopPaintRowDueSateNotFYear();
                    LoadSerial();
                    TotalDg1();
                    checkBox2.Checked = true;
                    checkBox3.Checked = false;
                }

                dataGridView1.Focus();

            }
        }

        private void dateTimePicker5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker4.Focus();

            }
        }

        private void dateTimePicker4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (checkBox1.Checked != true && checkBox4.Checked == false)
                {
                    DateTime ms_date1 = Convert.ToDateTime(dateTimePicker5.Value.ToShortDateString());
                    DateTime ms_date2 = Convert.ToDateTime(dateTimePicker4.Value.ToShortDateString());
                    this.dataTable1TableAdapter.FillByDailyDate(this.bankTransmentDS.DataTable1, 5, 15, ms_date1, ms_date2);
                    LoopPaintRowDueSateNotFYear();
                    LoadSerial();
                    TotalDg1();

                    checkBox2.Checked = false;
                    if (checkBox4.Checked != true)
                    { checkBox3.Checked = true; }
                    else
                    { checkBox3.Checked = false; }
                }
                else if (checkBox1.Checked == true && checkBox4.Checked == false)
                {
                    dataGridView1.Refresh();
                    DateTime ms_date1 = Convert.ToDateTime(dateTimePicker5.Value.ToShortDateString());
                    DateTime ms_date2 = Convert.ToDateTime(dateTimePicker4.Value.ToShortDateString());
                    this.dataTable1TableAdapter.FillByAllDailyMove(this.bankTransmentDS.DataTable1, 5, 15, dateTimePicker5.Value.ToString("yyyy-MM-dd"), dateTimePicker4.Value.ToString("yyyy-MM-dd"));
                    LoopPaintRowDueSateNotFYear();
                    LoadSerial();
                    TotalDg1();
                    checkBox2.Checked = false;
                    if (checkBox4.Checked != true)
                    { checkBox3.Checked = true; }
                    else
                    { checkBox3.Checked = false; }
                    //dataGridView1.Refresh();
                    //dateTimePicker4.KeyDown += dateTimePicker4_KeyDown;
                }
                else if (checkBox1.Checked == true && checkBox4.Checked == true)
                {
                    dataGridView1.Refresh();
                    string ms_date1 = dateTimePicker5.Value.ToShortDateString();
                    string ms_date2 = dateTimePicker4.Value.ToShortDateString();

                    ms_date1 = dateTimePicker2.Value.ToString();
                    ms_date2 = dateTimePicker3.Value.ToString();

                    this.dataTable1TableAdapter.FillByAllDailyWithMoveDate(this.bankTransmentDS.DataTable1, 5, 15, dateTimePicker5.Value.ToString("yyyy-MM-dd"), dateTimePicker4.Value.ToString("yyyy-MM-dd"), ms_date1, ms_date2);
                    LoopPaintRowDueSateNotFYear();
                    LoadSerial();
                    TotalDg1();
                    checkBox2.Checked = false;
                    if (checkBox4.Checked != true)
                    { checkBox3.Checked = true; }
                    else
                    { checkBox3.Checked = false; }
                    //dataGridView1.Refresh();
                    //dateTimePicker4.KeyDown += dateTimePicker4_KeyDown;
                }

                dataGridView1.Focus();

            }
        }

        private void txtBranch1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                dataGridView1.Focus();

            }
            else if (e.KeyCode == Keys.Down)
            {
                if (checkBox7.Checked == true)
                {
                    Forms.BasicCodeForms.FindBranchFrm t = new Forms.BasicCodeForms.FindBranchFrm();

                    t.ShowDialog();
                    if (Forms.BasicCodeForms.FindBranchFrm.SelectedRow != null)
                    {
                        if (checkBox1.Checked == true)
                        {
                            txtBranch1.Text = Forms.BasicCodeForms.FindBranchFrm.SelectedRow.Cells[1].Value.ToString();
                            txtBranchId1.Text = Forms.BasicCodeForms.FindBranchFrm.SelectedRow.Cells[0].Value.ToString();
                            int Vint_BranchID = int.Parse(txtBranchId1.Text);
                            if (checkBox2.Checked == true)
                            {
                                string ms_date1 = dateTimePicker2.Value.ToString();
                                string ms_date2 = dateTimePicker3.Value.ToString();
                                this.dataTable1TableAdapter.FillByBranchesWithMoveDate(this.bankTransmentDS.DataTable1, 5, 15, Vint_BranchID, ms_date1, ms_date2);
                                LoopPaintRowDueSateNotFYear();
                                LoadSerial();
                                TotalDg1();
                            }
                            else if (checkBox3.Checked == true)
                            {
                                DateTime ms_date1 = Convert.ToDateTime(dateTimePicker5.Value.ToString("yyyy-MM-dd"));
                                DateTime ms_date2 = Convert.ToDateTime(dateTimePicker4.Value.ToString("yyyy-MM-dd"));
                                this.dataTable1TableAdapter.FillByBranchWithDailyDate(this.bankTransmentDS.DataTable1, 5, 15, Vint_BranchID, ms_date1, ms_date2);
                                LoopPaintRowDueSateNotFYear();
                                LoadSerial();
                                TotalDg1();

                            }
                            else if (checkBox4.Checked == true)
                            {
                                string ms_date1 = dateTimePicker5.Value.ToShortDateString();
                                string ms_date2 = dateTimePicker4.Value.ToShortDateString();

                                ms_date1 = dateTimePicker2.Value.ToString();
                                ms_date2 = dateTimePicker3.Value.ToString();

                                this.dataTable1TableAdapter.FillByDailyWithMoveBranch(this.bankTransmentDS.DataTable1, 5, 15, dateTimePicker5.Value.ToString("yyyy-MM-dd"), dateTimePicker4.Value.ToString("yyyy-MM-dd"), ms_date1, ms_date2, Vint_BranchID);

                                LoopPaintRowDueSateNotFYear();
                                LoadSerial();
                                TotalDg1();

                            }
                            else
                            {
                                MessageBox.Show("من فضلك اختر الفتره المراد البحث طبقا لها ");
                            }
                        }
                        else
                        {
                            MessageBox.Show("هذا البحث متوفر من خلال البحث العام فقط");
                        }
                    }
                }
                else if (checkBox6.Checked == true)
                {
                    Forms.BasicCodeForms.FindDirectionFrm t = new Forms.BasicCodeForms.FindDirectionFrm();
                    t.ShowDialog();
                    if (Forms.BasicCodeForms.FindBranchFrm.SelectedRow != null)
                    {
                        if (checkBox1.Checked == true)
                        {
                            txtBranch1.Text = Forms.BasicCodeForms.FindBranchFrm.SelectedRow.Cells[1].Value.ToString();
                            txtBranchId1.Text = Forms.BasicCodeForms.FindBranchFrm.SelectedRow.Cells[0].Value.ToString();
                            int Vint_BranchID = int.Parse(txtBranchId1.Text);
                            if (checkBox2.Checked == true)
                            {
                                string ms_date1 = dateTimePicker2.Value.ToString();
                                string ms_date2 = dateTimePicker3.Value.ToString();
                                this.dataTable1TableAdapter.FillByBranchesWithMoveDate(this.bankTransmentDS.DataTable1, 5, 15, Vint_BranchID, ms_date1, ms_date2);
                                LoopPaintRowDueSateNotFYear();
                                LoadSerial();
                                TotalDg1();
                            }
                            else if (checkBox3.Checked == true)
                            {
                                DateTime ms_date1 = Convert.ToDateTime(dateTimePicker5.Value.ToString("yyyy-MM-dd"));
                                DateTime ms_date2 = Convert.ToDateTime(dateTimePicker4.Value.ToString("yyyy-MM-dd"));
                                this.dataTable1TableAdapter.FillByBranchWithDailyDate(this.bankTransmentDS.DataTable1, 5, 15, Vint_BranchID, ms_date1, ms_date2);
                                LoopPaintRowDueSateNotFYear();
                                LoadSerial();
                                TotalDg1();

                            }
                            else if (checkBox4.Checked == true)
                            {
                                string ms_date1 = dateTimePicker5.Value.ToShortDateString();
                                string ms_date2 = dateTimePicker4.Value.ToShortDateString();

                                ms_date1 = dateTimePicker2.Value.ToString();
                                ms_date2 = dateTimePicker3.Value.ToString();

                                this.dataTable1TableAdapter.FillByDailyWithMoveBranch(this.bankTransmentDS.DataTable1, 5, 15, dateTimePicker5.Value.ToString("yyyy-MM-dd"), dateTimePicker4.Value.ToString("yyyy-MM-dd"), ms_date1, ms_date2, Vint_BranchID);

                                LoopPaintRowDueSateNotFYear();
                                LoadSerial();
                                TotalDg1();

                            }
                            else
                            {
                                MessageBox.Show("من فضلك اختر الفتره المراد البحث طبقا لها ");
                            }
                        }
                        else
                        {
                            MessageBox.Show("هذا البحث متوفر من خلال البحث العام فقط");
                        }
                    }
                }
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (checkBox1.Checked == true)
                {
                    int Vint_MoveCustomerTypeID = int.Parse(comboBox1.SelectedValue.ToString());
                    if (checkBox2.Checked == true)
                    {
                        string ms_date1 = dateTimePicker2.Value.ToString();
                        string ms_date2 = dateTimePicker3.Value.ToString();
                        this.dataTable1TableAdapter.FillByCustomerTypeWithMoveDate(this.bankTransmentDS.DataTable1, 5, 15, Vint_MoveCustomerTypeID, ms_date1, ms_date2);
                        LoopPaintRowDueSateNotFYear();
                        LoadSerial();
                        TotalDg1();
                    }
                    else if (checkBox3.Checked == true)
                    {
                        DateTime ms_date1 = Convert.ToDateTime(dateTimePicker5.Value.ToString("yyyy-MM-dd"));
                        DateTime ms_date2 = Convert.ToDateTime(dateTimePicker4.Value.ToString("yyyy-MM-dd"));
                        this.dataTable1TableAdapter.FillByCustomerTypewithDailyDate(this.bankTransmentDS.DataTable1, 5, 15, ms_date1, ms_date2, Vint_MoveCustomerTypeID);
                        LoopPaintRowDueSateNotFYear();
                        LoadSerial();
                        TotalDg1();

                    }
                    else if (checkBox4.Checked == true)
                    {
                        string ms_date1 = dateTimePicker5.Value.ToShortDateString();
                        string ms_date2 = dateTimePicker4.Value.ToShortDateString();

                        ms_date1 = dateTimePicker2.Value.ToString();
                        ms_date2 = dateTimePicker3.Value.ToString();

                        this.dataTable1TableAdapter.FillByDailyWithDatesTyping(this.bankTransmentDS.DataTable1, 5, 15, dateTimePicker5.Value.ToString("yyyy-MM-dd"), dateTimePicker4.Value.ToString("yyyy-MM-dd"), ms_date1, ms_date2, Vint_MoveCustomerTypeID);

                        LoopPaintRowDueSateNotFYear();
                        LoadSerial();
                        TotalDg1();

                    }
                    else
                    {
                        MessageBox.Show("من فضلك اختر الفتره المراد البحث طبقا لها ");
                    }


                }
                else
                {
                    MessageBox.Show("هذا البحث متوفر من خلال البحث العام فقط");
                }
            }
        }

        private void checkBox3_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox2.Checked = false;
            checkBox4.Checked = false;

        }

        private void checkBox2_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox3.Checked = false;
            checkBox4.Checked = false;
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            txtCodeSrch.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";
            txtAmountSrch.Text = "";
            string mvDesrNote = textBox3.Text;
            this.dataTable1TableAdapter.FillByDescriptionNote(this.bankTransmentDS.DataTable1, mvDesrNote);
            LoopPaintRowDueSateNotFYear();
            LoadSerial();
            TotalDg1();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //this.tbl_CustmersTypeTableAdapter.Fill(this.bankTransmentDS.Tbl_CustmersType);
            ClearData();
            if (dataGridView1.RowCount > 0)
            {
                txtRowId.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                long Vlng_IDmv = long.Parse(txtRowId.Text);

                var listbnkmov = FsDb.Tbl_BankMovement.Where(x => x.ID == Vlng_IDmv).ToList();

                dtp_MoveDate.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[6].Value.ToString());

                dtp_DueDate.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[7].Value.ToString());

                txtDescription.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();

                txtvalue.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();



                txtBank.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();

                txtBankAcc.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();

                txtBankPurposeAcc.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();

                if (dataGridView1.CurrentRow.Cells[26].Value.ToString() != "")
                {
                    txtBranchId.Text = dataGridView1.CurrentRow.Cells[26].Value.ToString();

                    int Vint_BranchId = int.Parse(txtBranchId.Text);
                    var list = FsDb.Tbl_Management.FirstOrDefault(x => x.ID == Vint_BranchId);
                    txtBranch.Text = list.BrancheName;
                }
                //}
                if (listbnkmov[0].MoveType3 > 0)
                {
                    comboBox2.SelectedIndex = -1;
                    comboBox2.SelectedValue = int.Parse(listbnkmov[0].MoveType3.ToString());
                }


                if (dataGridView1.CurrentRow.Cells[27].Value.ToString() != "")
                {
                    cmbType.SelectedValue = int.Parse(dataGridView1.CurrentRow.Cells[27].Value.ToString());
                }

                if (dataGridView1.CurrentRow.Cells[28].Value.ToString() != "")
                {
                    dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[28].Value.ToString());
                }

                if (dataGridView1.CurrentRow.Cells[31].Value.ToString() != "")
                {
                    textBox4.Text = dataGridView1.CurrentRow.Cells[31].Value.ToString();
                }

                cmbType.Select();

                cmbType.Focus();

                this.ActiveControl = cmbType;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 122 && w.ProcdureId == 4);
            if (validationSaveUser != null)
            {
                int? vint_RowID = int.Parse(txtRowId.Text);
                int? Vint_CustType = null;
                int? vint_branchID = null;
                DateTime? Vd_DayDate = null;

                var ListBnkMov = FsDb.Tbl_BankMovement.Where(x => x.ID == vint_RowID).ToList();
                ListBnkMov[0].TradeMoveType = Vint_CustType;
                ListBnkMov[0].BranchId = vint_branchID;
                ListBnkMov[0].DailyDate = Vd_DayDate;
                FsDb.SaveChanges();
                MessageBox.Show("تم حذف التصنيف ");
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية حذف تصنيف دفع اليكتروني ... برجاء مراجعة مدير المنظومه");
            }
        }

        private void dateTimePicker5_Leave(object sender, EventArgs e)
        {
            dateTimePicker4.Value = dateTimePicker5.Value;
        }

        private void checkBox4_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }

        private void checkBox5_MouseClick(object sender, MouseEventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 122 && w.ProcdureId == 1008);
            if (validationSaveUser != null)
            {
                checkBox5.Checked = true;
            }
            else
            {
                checkBox5.Checked = false;
                MessageBox.Show("ليس لديك صلاحية تعديل الكود القديم ... برجاء مراجعة مدير المنظومه");
            }
        }

        private void checkBox7_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox6.Checked = false;
            txtBranch1.Focus();
        }

        private void checkBox6_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox7.Checked = false;
            txtBranch1.Focus();
        }
    }
}
