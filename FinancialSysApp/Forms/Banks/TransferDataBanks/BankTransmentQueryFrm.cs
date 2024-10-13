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
using DevExpress.XtraEditors;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;

namespace FinancialSysApp.Forms.Banks.TransferDataBanks
{
    public partial class BankTransmentQueryFrm : Form
    {
        string Vst_DepositDate1 = DateTime.Today.ToString();
        string Vst_DepositDate2 = DateTime.Today.ToString();
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        public BankTransmentQueryFrm()
        {
            InitializeComponent();
        }

        private void BankTransmentQueryFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankTransmentDS.Tbl_MovementBankType' table. You can move, or remove it, as needed.
            //this.tbl_MovementBankTypeTableAdapter.FillParentNull(this.bankTransmentDS.Tbl_MovementBankType);
            // TODO: This line of code loads data into the 'bankTransmentDS.Tbl_MovementBankType' table. You can move, or remove it, as needed.
            this.tbl_MovementBankTypeTableAdapter.FillParentNull(this.bankTransmentDS.Tbl_MovementBankType);
            int Vint_BankMType = int.Parse(comboBox3.SelectedValue.ToString());
            //this.tbl_MovementBankTypeTableAdapter1.FillByParent(this.bankTransmentDS.Tbl_MovementBankType, Vint_BankMType);
            // TODO: This line of code loads data into the 'bankCheques.Dtb_Banks' table. You can move, or remove it, as needed.
            this.dtb_BanksTableAdapter.FillByBankKind(this.bankCheques.Dtb_Banks);

            comboBox2.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "اختر البنك ";

            comboBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "اختر رقم الحساب ";

            comboBox3.Text = "";
            comboBox3.SelectedIndex = -1;
            comboBox3.Text = "اختر التصنيف الرئيسي ";

            comboBox4.Text = "";
            comboBox4.SelectedIndex = -1;
            comboBox4.Text = "اختر التصنيف الفرعي ";

            comboBox5.Text = "";
            comboBox5.SelectedIndex = -1;
            comboBox5.Text = "اختر نوع العملية ";

            comboBox7.Text = "";
            comboBox7.SelectedIndex = -1;
            comboBox7.Text = "اختر  تم / لم يتم الربط ";

            dTPDeposit.Focus();
        }

        private void dTPDeposit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dTPDeposit2.Focus();
            }
        }
        private void LoadSerial()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.Cells[0].Value = i; i++;

            }
            TotalDg1();
        }
        private void TotalDg1()
        {
            txtAllValue.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                           select Convert.ToDouble(row.Cells[11].Value)).Sum(), 3).ToString();
            txtAllCount.Text = (from DataGridViewRow row in dataGridView2.Rows
                                select Convert.ToDouble(row.Cells[1].Value)).Count().ToString();

            txtCheqSpvallue.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                               where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                               select Convert.ToDouble(row.Cells[11].Value)).Sum(), 3).ToString();
            txtCheqSpCount.Text = ((from DataGridViewRow row in dataGridView2.Rows
                                    where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                    select Convert.ToDouble(row.Cells[4].Value)).Count().ToString());
        }
        private void dTPDeposit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox2.Focus();
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView2.Visible = true;
                dataGridView1.Visible = false;
                Vst_DepositDate1 = dTPDeposit.Value.ToString("yyyy/MM/dd");
                Vst_DepositDate2 = dTPDeposit2.Value.ToString("yyyy/MM/dd");
                DateTime d1 = Convert.ToDateTime(Vst_DepositDate1);
                DateTime d2 = Convert.ToDateTime(Vst_DepositDate2);


                comboBox1.Text = "";
                comboBox1.SelectedIndex = -1;
                comboBox1.Text = "اختر رقم الحساب ";

                comboBox3.Text = "";
                comboBox3.SelectedIndex = -1;
                comboBox3.Text = "اختر التصنيف الرئيسي ";

                comboBox4.Text = "";
                comboBox4.SelectedIndex = -1;
                comboBox4.Text = "اختر التصنيف الفرعي ";

                comboBox5.Text = "";
                comboBox5.SelectedIndex = -1;
                comboBox5.Text = "اختر نوع العملية ";
                if (comboBox2.SelectedValue != null)
                {


                    int Vint_bankid = int.Parse(comboBox2.SelectedValue.ToString());
                    this.dataTable1TableAdapter.FillByMoveDate(this.bankTransmentDS.DataTable1, Vst_DepositDate1, Vst_DepositDate2, Vint_bankid);
                    LoadSerial();
                    comboBox1.Focus();
                }
                comboBox6.Text = "";
                comboBox6.SelectedIndex = -1;
                comboBox6.Text = "اختر هل تم التصنيف ام لا ";
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView2.Visible = true;
                dataGridView1.Visible = false;
                Vst_DepositDate1 = dTPDeposit.Value.ToString("yyyy/MM/dd");
                Vst_DepositDate2 = dTPDeposit2.Value.ToString("yyyy/MM/dd");
                DateTime d1 = Convert.ToDateTime(Vst_DepositDate1);
                DateTime d2 = Convert.ToDateTime(Vst_DepositDate2);
                int Vint_bankid = int.Parse(comboBox2.SelectedValue.ToString());
                int Vint_bankAccid = int.Parse(comboBox1.SelectedValue.ToString());
                this.dataTable1TableAdapter.FillByDatesAccBankAll(this.bankTransmentDS.DataTable1, Vst_DepositDate1, Vst_DepositDate2, Vint_bankid, Vint_bankAccid);
                LoadSerial();
                textBox1.Text = "";
                comboBox6.Focus();
            }

        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int Vint_BankFromID = int.Parse(comboBox2.SelectedValue.ToString());
            this.tbl_AccountsBank1TableAdapter.FillByBankID(this.bankCheques.Tbl_AccountsBank1, Vint_BankFromID);
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "اختر رقم الحساب";

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                Vst_DepositDate1 = dTPDeposit.Value.ToString("yyyy/MM/dd");
                Vst_DepositDate2 = dTPDeposit2.Value.ToString("yyyy/MM/dd");
                DateTime d1 = Convert.ToDateTime(Vst_DepositDate1);
                DateTime d2 = Convert.ToDateTime(Vst_DepositDate2);
                int Vint_bankid = int.Parse(comboBox2.SelectedValue.ToString());
                int Vint_bankAccid = int.Parse(comboBox1.SelectedValue.ToString());
                string Vst_KindPrcs = comboBox5.Text.ToString();
                if (textBox1.Text != "")
                {
                    decimal Vd_TrValue = decimal.Parse(textBox1.Text);
                    this.dataTable1TableAdapter.FillByBankAccValue(this.bankTransmentDS.DataTable1, Vst_DepositDate1, Vst_DepositDate2, Vint_bankid, Vint_bankAccid, Vd_TrValue, Vst_KindPrcs);
                    LoadSerial();
                }
                comboBox3.Focus();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedValue != null)
            {

                int vint_MovBankId = 0;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    vint_MovBankId = int.Parse(row.Cells[2].Value.ToString());
                    bool Vbl_Checked = Convert.ToBoolean(row.Cells[1].Value.ToString());
                    var listMoveBank = FsDb.Tbl_BankMovement.Where(x => x.ID == vint_MovBankId).ToList();
                    if (Vbl_Checked == true)
                    {
                        listMoveBank[0].MoveType1 = int.Parse(comboBox3.SelectedValue.ToString());
                        if (comboBox4.SelectedValue != null)
                        { listMoveBank[0].MoveType2 = int.Parse(comboBox4.SelectedValue.ToString()); }
                        listMoveBank[0].IsSelectedType = true;
                        FsDb.SaveChanges();
                    }
                    else if (Vbl_Checked == false)
                    {
                        listMoveBank[0].MoveType1 = null;
                        listMoveBank[0].MoveType2 = null;
                        listMoveBank[0].IsSelectedType = false;
                        FsDb.SaveChanges();
                    }
                }
                MessageBox.Show("تم الحفظ");
                //simpleButton2.Enabled = false;

            }
            else
            {
                MessageBox.Show("من فضلك اختر التصنيف الرئيسي ");
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Vst_DepositDate1 = dTPDeposit.Value.ToString("yyyy/MM/dd");
                Vst_DepositDate2 = dTPDeposit2.Value.ToString("yyyy/MM/dd");
                DateTime d1 = Convert.ToDateTime(Vst_DepositDate1);
                DateTime d2 = Convert.ToDateTime(Vst_DepositDate2);
                int Vint_bankid = int.Parse(comboBox2.SelectedValue.ToString());
                int Vint_bankAccid = int.Parse(comboBox1.SelectedValue.ToString());
                string Vst_SearhNote = txtSearch.Text;
                string Vs_KindProcess = comboBox5.SelectedText.ToString();
                this.dataTable1TableAdapter.FillByBankAccBankSearchNote(this.bankTransmentDS.DataTable1, Vst_DepositDate1, Vst_DepositDate2, Vint_bankid, Vst_SearhNote, Vint_bankAccid, Vs_KindProcess);
                textBox1.Focus();
            }

        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView2.Visible = true;
                dataGridView1.Visible = false;
                //int Vint_type1 = int.Parse(comboBox3.SelectedValue.ToString());
                //var listType = FsDb.Tbl_MovementBankType.Where(x => x.ID == Vint_type1).ToList();
                //if (listType.Count > 0)
                //{
                //    comboBox4.DataSource = listType;
                //    comboBox4.Text = "";
                //    comboBox4.SelectedIndex = -1;
                //    comboBox4.Text = "اختر التصنيف الفرعي";
                //}
                comboBox4.Focus();
            }
        }

        private void radGroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string Vst_ProcessKind = comboBox5.Text;
                Vst_DepositDate1 = dTPDeposit.Value.ToString("yyyy/MM/dd");
                Vst_DepositDate2 = dTPDeposit2.Value.ToString("yyyy/MM/dd");
                DateTime d1 = Convert.ToDateTime(Vst_DepositDate1);
                DateTime d2 = Convert.ToDateTime(Vst_DepositDate2);
                int Vint_bankid = int.Parse(comboBox2.SelectedValue.ToString());
                int Vint_bankAccid = int.Parse(comboBox1.SelectedValue.ToString());
                string Vst_SearhNote = txtSearch.Text;
                int Vint_Type = int.Parse(comboBox6.SelectedIndex.ToString());
                if (Vint_Type == 0)
                {
                    this.dataTable1TableAdapter.FillByProcessKindTypeOK(this.bankTransmentDS.DataTable1, Vst_DepositDate1, Vst_DepositDate2, Vint_bankid, Vst_ProcessKind, Vint_bankAccid);
                    radGroupBox1.Visible = true;
                    label9.Visible = true;
                    label8.Visible = true;
                    comboBox3.Visible = true;
                    comboBox4.Visible = true;

                }
                else
                {
                    this.dataTable1TableAdapter.FillByProcessKindTypeNotOk(this.bankTransmentDS.DataTable1, Vst_DepositDate1, Vst_DepositDate2, Vint_bankid, Vst_ProcessKind, Vint_bankAccid);
                    radGroupBox1.Visible = false;
                    label9.Visible = false;
                    label8.Visible = false;
                    comboBox3.Visible = false;
                    comboBox4.Visible = false;
                }
                LoadSerial();

                textBox1.Focus();
            }

        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int Vint_type1 = int.Parse(comboBox3.SelectedValue.ToString());
            var listType = FsDb.Tbl_MovementBankType.Where(x => x.MoveType == Vint_type1).ToList();
            if (listType.Count > 0)
            {

                comboBox4.DataSource = listType;
                comboBox4.DisplayMember = "Name";
                comboBox4.ValueMember = "ID";
                comboBox4.Text = "";
                comboBox4.SelectedIndex = -1;
                comboBox4.Text = "اختر التصنيف الفرعي";
            }
            else
            {
                comboBox4.DataSource = null;
            }
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                comboBox3.Focus();

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
                this.dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);

        }

        private void comboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dataGridView2.Visible = true;
                    dataGridView1.Visible = false;
                    string Vst_ProcessKind = comboBox5.Text;
                    Vst_DepositDate1 = dTPDeposit.Value.ToString("yyyy/MM/dd");
                    Vst_DepositDate2 = dTPDeposit2.Value.ToString("yyyy/MM/dd");
                    DateTime d1 = Convert.ToDateTime(Vst_DepositDate1);
                    DateTime d2 = Convert.ToDateTime(Vst_DepositDate2);
                    int Vint_bankid = int.Parse(comboBox2.SelectedValue.ToString());
                    int Vint_bankAccid = int.Parse(comboBox1.SelectedValue.ToString());
                    string Vst_SearhNote = txtSearch.Text;
                    int Vint_MovType = 0;
                    int Vint_MovType1 = 0;
                    if (comboBox3.SelectedValue != null)
                    {   Vint_MovType = int.Parse(comboBox3.SelectedValue.ToString()); }
                    if (comboBox4.SelectedValue != null)
                    {  Vint_MovType1 = int.Parse(comboBox4.SelectedValue.ToString()); }
                    var ListBankSetting = FsDb.Tbl_BankStringCHeqCash.Where(x => x.BankID == Vint_bankid && x.MoveType == Vint_MovType && x.MoveType1 == Vint_MovType1).ToList();
                    if (ListBankSetting.Count != 0)
                    {

                        string Vst_BankSettingSt1 = ListBankSetting[0].CheqString.ToString();

                        this.dataTable1TableAdapter.FillByDatesbankAccTypesSearchnote(this.bankTransmentDS.DataTable1, Vst_DepositDate1, Vst_DepositDate2, Vint_bankid, Vst_BankSettingSt1, Vint_bankAccid, Vint_MovType, Vint_MovType1);
                        LoadSerial();
                    }
                    comboBox7.Focus();
                }



            }
        }

        private void dTPDeposit2_Leave(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "اختر البنك ";

            comboBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "اختر رقم الحساب ";

            comboBox3.Text = "";
            comboBox3.SelectedIndex = -1;
            comboBox3.Text = "اختر التصنيف الرئيسي ";

            comboBox4.Text = "";
            comboBox4.SelectedIndex = -1;
            comboBox4.Text = "اختر التصنيف الفرعي ";

            comboBox5.Text = "";
            comboBox5.SelectedIndex = -1;
            comboBox5.Text = "اختر نوع العملية ";

            comboBox6.Text = "";
            comboBox6.SelectedIndex = -1;
            comboBox6.Text = "اختر هل تم التصنيف ام لا ";
        }

        private void comboBox5_Leave(object sender, EventArgs e)
        {


            comboBox3.Text = "";
            comboBox3.SelectedIndex = -1;
            comboBox3.Text = "اختر التصنيف الرئيسي ";

            comboBox4.Text = "";
            comboBox4.SelectedIndex = -1;
            comboBox4.Text = "اختر التصنيف الفرعي ";


        }

        private void comboBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Vst_DepositDate1 = dTPDeposit.Value.ToString("yyyy/MM/dd");
                Vst_DepositDate2 = dTPDeposit2.Value.ToString("yyyy/MM/dd");
                DateTime d1 = Convert.ToDateTime(Vst_DepositDate1);
                DateTime d2 = Convert.ToDateTime(Vst_DepositDate2);
                int Vint_bankid = int.Parse(comboBox2.SelectedValue.ToString());
                int Vint_bankAccid = int.Parse(comboBox1.SelectedValue.ToString());
                int Vint_Type = int.Parse(comboBox6.SelectedIndex.ToString());
                if (Vint_Type == 0)
                {
                    this.dataTable1TableAdapter.FillByDatesBankAccTypeOk(this.bankTransmentDS.DataTable1, Vst_DepositDate1, Vst_DepositDate2, Vint_bankid, Vint_bankAccid);
                    radGroupBox1.Visible = true;
                    label9.Visible = true;
                    label8.Visible = true;
                    comboBox3.Visible = true;
                    comboBox4.Visible = true;

                }
                else
                {
                    this.dataTable1TableAdapter.FillByDatesBankAccTypNotOK(this.bankTransmentDS.DataTable1, Vst_DepositDate1, Vst_DepositDate2, Vint_bankid, Vint_bankAccid);
                    radGroupBox1.Visible = false;
                    label9.Visible = false;
                    label8.Visible = false;
                    comboBox3.Visible = false;
                    comboBox4.Visible = false;
                }
                LoadSerial();
                textBox1.Text = "";

                comboBox5.Focus();
            }
        }
        private void TotalDg2()
        {
            txtAllValue.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                           select Convert.ToDouble(row.Cells[21].Value)).Sum(), 3).ToString();
            txtAllCount.Text = (from DataGridViewRow row in dataGridView1.Rows
                                select Convert.ToDouble(row.Cells[1].Value)).Count().ToString();

            txtCheqSpvallue.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                               where (Convert.ToBoolean(row.Cells[9].Value) == true)
                                               select Convert.ToDouble(row.Cells[21].Value)).Sum(), 3).ToString();
            txtCheqSpCount.Text = ((from DataGridViewRow row in dataGridView1.Rows
                                    where (Convert.ToBoolean(row.Cells[9].Value) == true)
                                    select Convert.ToDouble(row.Cells[4].Value)).Count().ToString());
        }
        private void comboBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView2.Visible = false;
                dataGridView1.Visible = true;
                string Vst_ProcessKind = comboBox5.Text;
                Vst_DepositDate1 = dTPDeposit.Value.ToString("yyyy/MM/dd");
                Vst_DepositDate2 = dTPDeposit2.Value.ToString("yyyy/MM/dd");
                DateTime d1 = Convert.ToDateTime(Vst_DepositDate1);
                DateTime d2 = Convert.ToDateTime(Vst_DepositDate2);
                int Vint_bankid = int.Parse(comboBox2.SelectedValue.ToString());
                int Vint_bankAccid = int.Parse(comboBox1.SelectedValue.ToString());
                string Vst_SearhNote = txtSearch.Text;
                //int Vint_MovType = int.Parse(comboBox3.SelectedValue.ToString());
                //int Vint_MovType1 = int.Parse(comboBox4.SelectedValue.ToString());
                int Vint_collected = int.Parse(comboBox7.SelectedIndex.ToString());
                //var ListBankSetting = FsDb.Tbl_BankStringCHeqCash.Where(x => x.BankID == Vint_bankid && x.MoveType == Vint_MovType && x.MoveType1 == Vint_MovType1).ToList();
                //if (ListBankSetting.Count != 0)
                //{

                //string Vst_BankSettingSt1 = ListBankSetting[0].CheqString.ToString();
                if (Vint_collected == 0)
                {
                    this.tbl_BankMovementTableAdapter.FillByCollectedNonCollected(this.bankTransmentDS.Tbl_BankMovement, Vst_DepositDate1, Vst_DepositDate2, Vint_bankid, Vint_bankAccid, false);
                }
                else if (Vint_collected == 1)
                {
                    this.tbl_BankMovementTableAdapter.FillByCollectedNonCollected(this.bankTransmentDS.Tbl_BankMovement, Vst_DepositDate1, Vst_DepositDate2, Vint_bankid, Vint_bankAccid, true);
                }
                LoadSerial();
                TotalDg2();

            }

            comboBox7.Focus();
        }

    }

}
