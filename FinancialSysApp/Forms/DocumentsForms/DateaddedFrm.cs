using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Configuration;
using FinancialSysApp.Classes;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;

namespace FinancialSysApp.Forms.DocumentsForms
{
    public partial class DateaddedFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        public DateaddedFrm()
        {
            InitializeComponent();
        }
        public static DateTime AddWeekDays(DateTime startDate, int numberOfDaysToAdd)
        {
            int daysAdded = 0;
            while (daysAdded < numberOfDaysToAdd)
            {
                startDate = startDate.AddDays(1);
                if (startDate.DayOfWeek != DayOfWeek.Friday && startDate.DayOfWeek != DayOfWeek.Saturday)
                {
                    daysAdded++;
                }
            }
            return startDate;
        }
        private void DateaddedFrm_Load(object sender, EventArgs e)
        {
            int bankDepositID = 0;
            //int bankDrawnOnID = 0;
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 78 && w.ProcdureId == 3);
            if (validationSaveUser != null)
            {
                //TODO: This line of code loads data into the 'bankCheques.Dtb_Banks' table.You can move, or remove it, as needed.
                this.dtb_BanksTableAdapter.FillByBankKind(this.bankCheques.Dtb_Banks);
                SelectData();
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية اعدادات اضافة الشيكات الى الحساب البنكي .. برجاء مراجعة مدير المنظومه");
                this.Close();
            }
            //******************اضافة السنه الماليه للحوافظ 
            //var listTrCol = FsDb.Tbl_TreasuryCollection.ToList();
            //FinancialYearDueDate f = new FinancialYearDueDate();
            //foreach (var TC in listTrCol)
            //{
            //    long Vl_TrID = long.Parse(TC.ID.ToString());
            //    var ListTc = FsDb.Tbl_TreasuryCollection.FirstOrDefault(x => x.ID == Vl_TrID);
            //    int Vin_Year = f.SelectFinancialYearDueDate(ListTc.CollectionDate.Value);

            //    ListTc.FisicalYearID = Vin_Year;
            //    FsDb.SaveChanges();
            //}
            //******************اضافة السنه الماليه للشيكات 
            //var listBnkChq = FsDb.Tbl_BankCheques.ToList();
            //foreach (var Bc in listBnkChq)
            //{
            //    long Vl_BcID = long.Parse(Bc.ID.ToString());
            //    var ListBc = FsDb.Tbl_BankCheques.FirstOrDefault(x => x.ID == Vl_BcID);
            //    int Vin_Year = f.SelectFinancialYearDueDate(ListBc.ChequeDueDate.Value);

            //    ListBc.FisicalYearID = Vin_Year;
            //    FsDb.SaveChanges();
            //}



            //************* اضافة تاريخ الايداع للحوافظ التابعه للحزينه
            //var listTrColWithParent = FsDb.Tbl_TreasuryCollection.Where(x => x.Parent_ID != null).ToList();
            //foreach (var Dt in listTrColWithParent)
            //{
            //    long Vi_ParentID = long.Parse(Dt.Parent_ID.ToString());
            //    var ListParent = FsDb.Tbl_TreasuryCollection.Where(x => x.ID == Vi_ParentID).ToList();
            //    DateTime? Vd_dateDeposit = null;
            //    Vd_dateDeposit = ListParent[0].DepositDate;
            //    Dt.DepositDate = Vd_dateDeposit;
            //    Dt.IsDepositNo = ListParent[0].IsDepositNo;


            //    FsDb.SaveChanges();

            //}
            //var ListAccRstAudit = FsDb.Tbl_TreasuryCollection.Select(x => x.ID).ToList();

            //foreach (var value in ListAccRstAudit)
            //{
            //    long V_TrID = value;
            //    var lisChecq = FsDb.Tbl_BankCheques.Where(x => x.TreasuryCollectionID == value).Select(x => x.ID).ToList();
            //    foreach (var V in lisChecq)
            //    {
            //        long V_cheq = V;
            //        var listcheq = FsDb.Tbl_ChequeBankStatusDates.Where(x => x.BankChequeID == V_cheq && x.BankChequeStatusID == 2).ToList();
            //        if (listcheq.Count > 0)
            //        {
            //            var listTrcol = FsDb.Tbl_TreasuryCollection.Where(x => x.ID == V_TrID).ToList();

            //            listTrcol[0].DepositDate = listcheq[0].ChequeBankStatusDate;
            //            FsDb.SaveChanges();
            //        }
            //    }

            //}
            //****************استدعاء بيانات الشيكات التي تم ايداعها والمراد احتساب تاريخ الاضافه لها
            //var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
            //                     join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
            //                     join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID

            //                     where ((BnkChq.ChequeStatusID == 2) && TRC.DepositDate != null)
            //                     select new

            //                     {
            //                         ID = BnkChq.ID,
            //                         TreasuryCollectionID = BnkChq.TreasuryCollectionID,
            //                         AddDateBank = BnkChq.AddDateBank,
            //                         AmountCheque = BnkChq.AmountCheque,
            //                         BankDrawnOnID = BnkChq.BankDrawnOnID,
            //                         ChequeNo = BnkChq.ChequeNo,
            //                         ChequeDueDate = BnkChq.ChequeDueDate,
            //                         DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
            //                         CustID = BnkChq.CustID,
            //                         ChequeKind = BnkChq.ChequeKindID,
            //                         BankName = BNK.Name,
            //                         ParentID = TRC.Parent_ID,
            //                         BankdepositID = TRC.BankDepositeID,
            //                         DepositDate = TRC.DepositDate

            //                     }).OrderBy(x => x.ChequeDueDate).ToList();

            //dataGridView2.DataSource = listBnkCheque;
            //***************** احتساب تاريخ الاضافه

            //DateAddedStatlmentCs dateAddedStatlment = new DateAddedStatlmentCs();

            //int vacationYear = 2024;//سنة الاجازة
            //int Vint_CheqID = 0;
            //string result = "";
            //foreach (DataGridViewRow row in dataGridView2.Rows)
            //{
            //    Vint_CheqID = int.Parse(row.Cells["ID"].Value.ToString());

            //    DateTime chequDueDate = Convert.ToDateTime(row.Cells["ChequeDueDate"].Value.ToString());//تاريخ الاستحقاق
            //    DateTime chequDepositDate = Convert.ToDateTime(row.Cells["DepositDate"].Value.ToString());//تاريخ الايداع
            //    bankDrawnOnID = int.Parse(row.Cells["BankDrawnOnID"].Value.ToString());//البنك المسحوب عليه
            //    bankDepositID = int.Parse(row.Cells["BankdepositID"].Value.ToString());// البنك المودع

            //    if (bankDepositID == 2004)
            //    { bankDepositID = 1; }

            //    if (bankDepositID == 2014)
            //    { bankDepositID = 2013; }

            //    dateAddedStatlment.PublicvacationYear = vacationYear;
            //    result = dateAddedStatlment.SelectDateAddedBank(chequDueDate, chequDepositDate, bankDepositID, bankDrawnOnID);
            //    var listCheqSp = FsDb.Tbl_BankCheques.Where(x => x.ID == Vint_CheqID).ToList();
            //    listCheqSp[0].AddDateBank = Convert.ToDateTime(result);
            //    FsDb.SaveChanges();

            //}
            txtBankDrawnOn.Focus();
        }


        private void Save()
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 87 && w.ProcdureId == 1);
            if (validationSaveUser != null)
            {
                if (Convert.ToInt32(textBox2.Text) > 0 || Convert.ToInt32(textBox3.Text) > 0)
                {
                    if (dataGridView1.Rows.Count == 0)
                    {
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                        SqlCommand com = new SqlCommand();
                        com.Connection = con;
                        com.CommandType = CommandType.Text;
                        com.CommandText = ("Insert Into Tbl_Check_DateAdded(SameBank,DifferenceBank,DifferenceBankDue) values(@SameBank,@DifferenceBank,@DifferenceBankDue)");

                        com.Parameters.Add("@SameBank", SqlDbType.Int).Value = Convert.ToInt32(textBox2.Text);
                        com.Parameters.Add("@DifferenceBank", SqlDbType.Int).Value = Convert.ToInt32(textBox3.Text);
                        com.Parameters.Add("@DifferenceBankDue", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);




                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("تم الحفظ");
                    }
                    else
                    {
                        MessageBox.Show("توجد بيانات محفوظة بالفعل يمكنك إجراء عملية تعديل");
                    }
                }
                else
                {
                    MessageBox.Show("قم بإدخال البيانات أولا");
                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية اضافة اعدادات اضافة الشيكات البنكيه .. برجاء مراجعة مدير المنظومه");
            }

        }
        private void UpdateData()
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 87 && w.ProcdureId == 3);
            if (validationSaveUser != null)
            {
                if (Convert.ToInt32(textBox2.Text) > 0 || Convert.ToInt32(textBox3.Text) > 0)
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = "UPDATE Tbl_Check_DateAdded SET SameBank = @SameBank, DifferenceBank = @DifferenceBank , DifferenceBankDue = @DifferenceBankDue";

                    com.Parameters.Add("@SameBank", SqlDbType.Int).Value = Convert.ToInt32(textBox2.Text);
                    com.Parameters.Add("@DifferenceBank", SqlDbType.Int).Value = Convert.ToInt32(textBox3.Text);
                    com.Parameters.Add("@DifferenceBankDue", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);

                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم التعديل");
                }
                else
                {
                    MessageBox.Show("قم بتحديد البيانات أولا");
                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية تعديل اعدادات اضافة الشيكات البنكيه .. برجاء مراجعة مدير المنظومه");
            }

        }
        private void DeleteData()
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 87 && w.ProcdureId == 4);
            if (validationSaveUser != null)
            {
                if (Convert.ToInt32(textBox2.Text) > 0 || Convert.ToInt32(textBox3.Text) > 0)
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = "DELETE FROM Tbl_Check_DateAdded";

                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم الحذف");
                }
                else
                {
                    MessageBox.Show("قم بتحديد البيانات أولا");
                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية حذف اعدادات اضافة الشيكات البنكيه .. برجاء مراجعة مدير المنظومه");
            }

        }
        private void SelectData()
        {
            dataGridView1.Rows.Clear();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString);

            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "SELECT * FROM Tbl_Check_DateAdded";

            con.Open();

            SqlDataReader reader = com.ExecuteReader();


            while (reader.Read())
            {

                dataGridView1.Rows.Add(reader.GetValue(1), reader.GetValue(2), reader.GetValue(3));

            }

            reader.Close();
            con.Close();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Save();
            SelectData();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            UpdateData();
            SelectData();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DeleteData();
            SelectData();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
            catch { }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            int bankDepositID = 0;
            int bankDrawnOnID = 0;
            if (txtBankDrawnOnID.Text == "")
            {
                MessageBox.Show("من فضلك اختر البنك المسحوب عليه");
                txtBankDrawnOn.Focus();
            }
            else
            {
                DateAddedStatlmentCs dateAddedStatlment = new DateAddedStatlmentCs();
                if (int.Parse(cmbBnkDeposit.SelectedValue.ToString()) == 1)
                { bankDepositID = 2004; }
                bankDepositID = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                //if (int.Parse(cmbBnkDeposit.SelectedValue.ToString()) == 2)
                //{ bankDepositID = 2; }


                DateTime chequDueDate = Convert.ToDateTime(dateTimePicker2.Value.ToString("yyyy/MM/dd"));//تاريخ الاستحقاق
                DateTime chequDepositDate = Convert.ToDateTime(dateTimePicker3.Value.ToString("yyyy/MM/dd"));//تاريخ الايداع

               

                if (txtBankDrawnOnID.Text != "")
                {
                    bankDrawnOnID = int.Parse(txtBankDrawnOnID.Text);
                    if (int.Parse(txtBankDrawnOnID.Text) == 2013)
                    { bankDrawnOnID = 2014; }
                    if (int.Parse(txtBankDrawnOnID.Text) == 1)
                    { bankDrawnOnID = 2004; }
                } //كود البنك المسحوب علية
                else
                { MessageBox.Show("من فضلك اختر البنك المسحوب عليه"); }
                int vacationYear = 2024;//سنة الاجازة
                dateAddedStatlment.PublicvacationYear = vacationYear;
                string result = dateAddedStatlment.SelectDateAddedBank(chequDueDate, chequDepositDate, bankDepositID, bankDrawnOnID);


                textBox4.Text = result;// تاريخ الاضافة
                MessageBox.Show("تم");
                textBox4.Text = "";
            }
        }

        private void txtBankDrawnOn_KeyDown(object sender, KeyEventArgs e)
        {
            int Vint_BankDrawnOnID = 0;
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBankDrawnOnID.Text != "")

                { Vint_BankDrawnOnID = int.Parse(txtBankDrawnOnID.Text); }


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
                simpleButton4.Focus();
            }
        }
    }
}
