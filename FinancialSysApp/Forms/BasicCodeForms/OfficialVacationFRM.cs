using FinancialSysApp.Forms.BasicCodeForms;
using Microsoft.Win32;
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
using FinancialSysApp.Forms.SecuritySystem;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using DevExpress.XtraBars;
using DevComponents.DotNetBar.Controls;

namespace FinancialSysApp.Forms.BasicCodeForms
{
   
    public partial class OfficialVacationFRM : DevExpress.XtraEditors.XtraForm

    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int bankDepositID = 0;
        int bankDrawnOnID = 0;
        public OfficialVacationFRM()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (TextVacation.Text == "")
            {
                MessageBox.Show("من فضلك ادخل اسم الاجازه");
                TextVacation.Focus();
            }
            else if(txtVacationID.Text == "")
            {
                Tbl_OfficialVacation ACrkF = new Tbl_OfficialVacation
                {
                    Name = TextVacation.Text,
                    FromDate = DateFrom.Value,
                    ToDate = DateTo.Value,
                    VacationYear = Convert.ToInt16(TYear.Text),

                };
                FsDb.Tbl_OfficialVacation.Add(ACrkF);
                FsDb.SaveChanges();
                int Vint_LastRowId = ACrkF.ID;
                MessageBox.Show("تم الحفظ");
                TextVacation.Text = "";
                txtVacationID.Text = "";
                DateFrom.Value = Convert.ToDateTime(DateTime.Today.ToString());
                DateTo.Value = Convert.ToDateTime(DateTime.Today.ToString());
            }
            else if (txtVacationID.Text !="")
            {
                int Vin_Vid = 0;
                  Vin_Vid = int.Parse(txtVacationID.Text);
              var listV =  FsDb.Tbl_OfficialVacation.Where(x => x.ID == Vin_Vid).ToList();
                listV[0].Name = TextVacation.Text;
                listV[0].FromDate = DateFrom.Value;
                listV[0].ToDate = DateTo.Value;
                FsDb.SaveChanges();
                MessageBox.Show("تم التعديل");
                TextVacation.Text = "";
                txtVacationID.Text = "";
                DateFrom.Value = Convert.ToDateTime(DateTime.Today.ToString());
                DateTo.Value = Convert.ToDateTime(DateTime.Today.ToString());
            }
        }
        private void GrdVacations()
        {
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Name"].Visible = true;
            dataGridView1.Columns["FromDate"].Visible = true;
            dataGridView1.Columns["ToDate"].Visible = true;
            dataGridView1.Columns["Name"].Width = 200;
            dataGridView1.Columns["VacationYear"].Visible = false;

            dataGridView1.Columns["Name"].HeaderText = "الاجازه";
            dataGridView1.Columns["FromDate"].HeaderText = "من تاريخ";
            dataGridView1.Columns["FromDate"].DefaultCellStyle.Format = "yyyy/MM/dd";
            dataGridView1.Columns["ToDate"].HeaderText = "الى تاريخ";
            dataGridView1.Columns["ToDate"].DefaultCellStyle.Format = "yyyy/MM/dd";
            dataGridView1.Columns["FromDate"].Width = 120;
            dataGridView1.Columns["ToDate"].Width = 120;
        }
            private void OfficialVacationFRM_Load(object sender, EventArgs e)
        {
            short Vsh_VYear = 0;
            TYear.Text = DateTime.Now.Year.ToString();
            Vsh_VYear = short.Parse(TYear.Text);
            dataGridView1.DataSource = FsDb.Tbl_OfficialVacation.Where(x=>x.VacationYear == Vsh_VYear).OrderBy(x=>x.FromDate).ToList();
            GrdVacations();
            TextVacation.Focus();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            int xcatid;
            xcatid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            txtVacationID.Text = xcatid.ToString();
            var result = FsDb.Tbl_OfficialVacation.SingleOrDefault(x => x.ID == xcatid);
            TextVacation.Text =result.Name;
            DateFrom.Value =Convert.ToDateTime( result.FromDate.ToString());
            DateTo.Value = Convert.ToDateTime(result.FromDate.ToString())  ;
              TYear.Text =Convert.ToUInt16(result.VacationYear).ToString();
        }

        private void TextVacation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DateFrom.Focus();
            }
        }

        private void DateFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DateTo.Focus();
            }
        }

        private void DateTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
        }
        private DateTime MRightDateBankNew(DateTime Vd_ResultRightDateBank)
        {
            DateTime result = Convert.ToDateTime(DateTime.Today.ToString());
            DateTime Vd_RightDateBank = Convert.ToDateTime(DateTime.Today.ToString());
            DateTime Vd_AddDateBank = Convert.ToDateTime(DateTime.Today.ToString());
            int Vint_year = 0;
            DateAddedStatlmentCs dateAddedStatlment = new DateAddedStatlmentCs();
            Vd_AddDateBank = Vd_ResultRightDateBank;
            Vint_year = Vd_RightDateBank.Year;
            Vd_RightDateBank = dateAddedStatlment.SelectDateRightDateBank(Vd_AddDateBank, Vint_year);
            result = Vd_RightDateBank;
            return result;
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //****************استدعاء بيانات الشيكات التي تم ايداعها والمراد احتساب تاريخ الاضافه لها
            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID

                                 where ((BnkChq.ChequeStatusID != 1 && BnkChq.ChequeStatusID != 4 && BnkChq.ChequeStatusID != 5) )
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     BankdepositID = TRC.BankDepositeID,
                                     DepositDate = TRC.DepositDate

                                 }).OrderBy(x => x.ChequeDueDate).ToList();

            dataGridView2.DataSource = listBnkCheque;
            //**************progress bar
            progressBar1.Minimum = 0;
            progressBar1.Maximum = dataGridView2.Rows.Count;
            progressBar1.Value = 0; // Start with 0 progress
            //***************** احتساب تاريخ الاضافه

            DateAddedStatlmentCs dateAddedStatlment = new DateAddedStatlmentCs();

            int vacationYear = 2024;//سنة الاجازة
            int Vint_CheqID = 0;
            string result = "";
            int i = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                //*****************Progress Bar 
                   i= i + 1;
                if (i < dataGridView2.Rows.Count)
                {
                    progressBar1.Value = i + 1;
                    progressBar1.Refresh();
                    var progress = (int)((double)progressBar1.Value / progressBar1.Maximum * 100);
                    label17.Text = ($"Progress: {progress}%");
                    using (Graphics gr = progressBar1.CreateGraphics())
                    {
                        gr.DrawString(null, SystemFonts.DefaultFont, Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
                    }
                    int progressPercentage = ((int)i / dataGridView2.Rows.Count) * 100;
                    progressBar1.CreateGraphics().DrawString(progressPercentage.ToString() + "%", new Font("Arial", (float)2.1, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));


                    Application.DoEvents();
                }
                Vint_CheqID = int.Parse(row.Cells["ID"].Value.ToString());

                DateTime chequDueDate = Convert.ToDateTime(row.Cells["ChequeDueDate"].Value.ToString());//تاريخ الاستحقاق
                DateTime chequDepositDate = Convert.ToDateTime(row.Cells["DepositDate"].Value.ToString());//تاريخ الايداع
                bankDrawnOnID = int.Parse(row.Cells["BankDrawnOnID"].Value.ToString());//البنك المسحوب عليه
                bankDepositID = int.Parse(row.Cells["BankdepositID"].Value.ToString());// البنك المودع

                if (bankDepositID == 1)
                { bankDepositID = 2004; }

                if (bankDepositID == 2013)
                { bankDepositID = 2014; }

                if (bankDrawnOnID == 1)
                { bankDrawnOnID = 2004; }

                if (bankDrawnOnID == 2013)
                { bankDrawnOnID = 2014; }

                dateAddedStatlment.PublicvacationYear = vacationYear;
                result = dateAddedStatlment.SelectDateAddedBank(chequDueDate, chequDepositDate, bankDepositID, bankDrawnOnID);
                //************************احتساب تاريخ حق البنك 
                DateTime Vd_RightDateBnk = MRightDateBankNew(Convert.ToDateTime(result).AddDays(1));
                //*****************
                var listCheqSp = FsDb.Tbl_BankCheques.Where(x => x.ID == Vint_CheqID).ToList();
                listCheqSp[0].AddDateBank = Convert.ToDateTime(result);
                listCheqSp[0].BankDueDate = Vd_RightDateBnk;
                FsDb.SaveChanges();

            }
            MessageBox.Show("تم");

        }
    }
}