using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialSysApp;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;

namespace FinancialSysApp.Forms.BasicCodeForms
{
    public partial class TendersAuctionsFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_TenderId = 0;
        int Vint_PUrchasePay = 0;
        public TendersAuctionsFrm()
        {
            InitializeComponent();
        }

        private void TendersAuctionsFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Fiscalyear' table. You can move, or remove it, as needed.
            this.tbl_FiscalyearTableAdapter.Fill(this.financialSysDataSet.Tbl_Fiscalyear);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_TendersAuctions' table. You can move, or remove it, as needed.
            this.tbl_TendersAuctionsTableAdapter.Fill(this.financialSysDataSet.Tbl_TendersAuctions);
            // TODO: This line of code loads data into the 'financialSysDataSet.DTB_Tenders' table. You can move, or remove it, as needed.
            var ListTenders = (from Tnder in FsDb.Tbl_TendersAuctions
                               join PayM in FsDb.Tbl_PurchaseMethods on Tnder.PurchaseMethodeID equals PayM.ID
                                join fy in FsDb.Tbl_Fiscalyear on Tnder.FinancialYearId equals fy.ID
                               select new
                               {
                                   ID = Tnder.ID,
                                   TenderNo = Tnder.TenderNo,
                                   TenderDate = Tnder.TenderDate,
                                   Note = Tnder.Note,
                                   PayMName = PayM.Name ,
                                   FinYearName = fy.Name
                               }).OrderBy(x => x.TenderDate).ToList();
            dataGridView1.DataSource = ListTenders;
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_PurchaseMethods' table. You can move, or remove it, as needed.
            this.tbl_PurchaseMethodsTableAdapter.Fill(this.financialSysDataSet.Tbl_PurchaseMethods);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_TendersAuctions' table. You can move, or remove it, as needed.
           
            cmbPurchMethod.SelectedIndex = -1;
            cmbPurchMethod.Text = "";
            cmbPurchMethod.SelectedText = "اختر طريقة الشراء";

            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "";
            comboBox1.SelectedText = "اختر العام المالي";


            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "";
            comboBox2.SelectedText = "اختر الجهد";
            cmbPurchMethod.Select();
            this.ActiveControl = cmbPurchMethod;
            cmbPurchMethod.Focus();
            

        }

        

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 60 && w.ProcdureId == 1);
            if (validationSaveUser != null)
            {
                DateTime Vdt_ATendersDate = Convert.ToDateTime(dtpTendersDate.Value.ToString("dddd , MMM dd yyyy"));
                int? Vint_ElectricalEffort = null;

                var listCHeckAssays = FsDb.Tbl_TendersAuctions.FirstOrDefault(x => x.TenderNo == txtTendersNo.Text && x.TenderDate == Vdt_ATendersDate);
                if (txtTendertId.Text == "")
                {
                    if (cmbPurchMethod.SelectedIndex == -1)
                    {
                        MessageBox.Show("من فضلك ادخل طريقة الشراء ");
                        cmbPurchMethod.Focus();
                    }
                    else if (txtTendersNo.Text == "")
                    {
                        MessageBox.Show("من فضلك ادخل رقم ");
                        txtTendersNo.Focus();
                    }
                    else if (dtpTendersDate.Value == null)
                    {
                        MessageBox.Show("من فضلك ادخل تاريخ ");
                        dtpTendersDate.Focus();
                    }
                    else if (comboBox1.SelectedIndex ==-1)
                    {
                        MessageBox.Show("من فضلك ادخل العام المالي ");
                        comboBox1.Focus();

                    }
                    else
                    {
                        
                        if (comboBox2.SelectedIndex > 0)
                        {
                            Vint_ElectricalEffort = int.Parse(comboBox2.SelectedIndex.ToString());
                        }
                        Tbl_TendersAuctions Tnd = new Tbl_TendersAuctions
                        {

                            TenderNo = txtTendersNo.Text,
                            TenderDate = Convert.ToDateTime(dtpTendersDate.Value.ToString())   ,
                            PurchaseMethodeID = int.Parse(cmbPurchMethod.SelectedValue.ToString())  ,
                            Note = textBox1.Text,
                            FinancialYearId = int.Parse(comboBox1.SelectedValue.ToString()),
                            ElectricalEffortID = Vint_ElectricalEffort
                        };
                        FsDb.Tbl_TendersAuctions.Add(Tnd);
                        FsDb.SaveChanges();

                        long Vint_LastRow = Tnd.ID;
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة المناقصه - الرسم ---",
                            TableName = "Tbl_TendersAuctions",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة المناقصات - الرسوم"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //************************************
                        MessageBox.Show("تم الحفظ");

                        this.dTB_TendersTableAdapter.FillAllTenders(this.financialSysDataSet.DTB_Tenders);
                        cmbPurchMethod.SelectedIndex = -1;
                        cmbPurchMethod.Text = "";
                        cmbPurchMethod.SelectedText = "اختر طريقة الشراء";

                        comboBox1.SelectedIndex = -1;
                        comboBox1.Text = "";
                        comboBox1.SelectedText = "اختر العام المالي";

                        comboBox2.SelectedIndex = -1;
                        comboBox2.Text = "";
                        comboBox2.SelectedText = "اختر الجهد";

                        txtTendersNo.Text = "";
                        dtpTendersDate.Value = Convert.ToDateTime(DateTime.Now.Date);
                        textBox1.Text = "";
                        txtTendertId.Text = "";

                        cmbPurchMethod.Select();
                        this.ActiveControl = cmbPurchMethod;
                        cmbPurchMethod.Focus();
                      }
                }
                else
                {
                    //MessageBox.Show("هذه المناقصه / المزايده/ تم ادخالها من قبل");
                    var resultMsg = MessageBox.Show(" " + "هل تريد تعديل هده المناقصه / المزايده   " + " ؟ ", "حدف تعديل ", MessageBoxButtons.YesNo);
                    if (resultMsg == DialogResult.Yes)
                    {
                        Vint_TenderId = int.Parse(txtTendertId.Text);
                        var listUpdAssays = FsDb.Tbl_TendersAuctions.FirstOrDefault(x => x.ID == Vint_TenderId);
                        listUpdAssays.TenderNo = txtTendersNo.Text;
                        listUpdAssays.TenderDate = Convert.ToDateTime(dtpTendersDate.Value.ToString("dddd , MMM dd yyyy"));
                        listUpdAssays.PurchaseMethodeID = int.Parse(cmbPurchMethod.SelectedValue.ToString());
                        listUpdAssays.Note = textBox1.Text;
                        listUpdAssays.FinancialYearId = int.Parse(comboBox1.SelectedValue.ToString());
                        if (comboBox2.SelectedIndex > 0)
                        {
                            Vint_ElectricalEffort = int.Parse(comboBox2.SelectedIndex.ToString());
                            listUpdAssays.ElectricalEffortID = Vint_ElectricalEffort;
                        }
                       
                        FsDb.SaveChanges();

                        //---------------خفظ ااحداث 

                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل المناقصه / المزايده ",
                            TableName = "Tbl_TendersAuctions",
                            TableRecordId = listUpdAssays.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة المناقصات / المزايدات"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************

                        MessageBox.Show("تم التعديل");
                        var ListTenders = (from Tnder in FsDb.Tbl_TendersAuctions
                                           join PayM in FsDb.Tbl_PurchaseMethods on Tnder.PurchaseMethodeID equals PayM.ID
                                           join fy in FsDb.Tbl_Fiscalyear on Tnder.FinancialYearId equals fy.ID
                                           select new
                                           {
                                               ID = Tnder.ID,
                                               TenderNo = Tnder.TenderNo,
                                               TenderDate = Tnder.TenderDate,
                                               Note = Tnder.Note,
                                               PayMName = PayM.Name,
                                               FinYearName = fy.Name
                                           }).OrderBy(x => x.TenderDate).ToList();
                        dataGridView1.DataSource = ListTenders;
                        

                        cmbPurchMethod.SelectedIndex = -1;
                        cmbPurchMethod.Text = "";
                        cmbPurchMethod.SelectedText = "اختر طريقة الشراء";

                        comboBox1.SelectedIndex = -1;
                        comboBox1.Text = "";
                        comboBox1.SelectedText = "اختر العام المالي";
                        txtTendersNo.Text = "";
                        dtpTendersDate.Value = Convert.ToDateTime(DateTime.Now.Date);
                        textBox1.Text = "";
                        txtTendertId.Text = "";

                        cmbPurchMethod.Select();
                        this.ActiveControl = cmbPurchMethod;
                        cmbPurchMethod.Focus();

                    }

                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية حذف  المناقصه / المزايده .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 60 && w.ProcdureId == 4);
            if (validationSaveUser != null)
            {
                var result = FsDb.Tbl_TendersAuctions.Find(Vint_TenderId);
                if (result != null)
                {
                    var resultMsg = MessageBox.Show(" " + "هل تريد حدف هده المناقصه / المزايده   " + " ؟ ", "حدف المناقصه / المزايده ", MessageBoxButtons.YesNo);
                    if (resultMsg == DialogResult.Yes)
                    {
                        var listdassays = FsDb.Tbl_Order.FirstOrDefault(x => x.TendersAuctionsID == Vint_TenderId);
                        if (listdassays != null)
                        {
                            MessageBox.Show(" لايمكن حدف هده المناقصه / المزايده لانها مسجله على  اوامر ");
                        }
                        else
                        {
                            FsDb.Tbl_TendersAuctions.Remove(result);
                            FsDb.SaveChanges();
                            //---------------خفظ ااحداث 
                            //int Vint_LastRow = sup.ID;
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "حذف مناقصه - مزايده",
                                TableName = "Tbl_TendersAuctions",
                                TableRecordId = result.ID.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "شاشة المناقصات - المزايدات"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            //***************************

                            MessageBox.Show("تم الحدف");
                            
                            txtTendersNo.Text = "";
                            dtpTendersDate.Value = Convert.ToDateTime(DateTime.Now.Date);
                            txtTendertId.Text = "";
                            textBox1.Text = "";
                            comboBox2.SelectedIndex = -1;
                            comboBox2.Text = "";
                            comboBox2.SelectedText = "اختر الجهد";

                            cmbPurchMethod.Select();
                            this.ActiveControl = cmbPurchMethod;
                            cmbPurchMethod.Focus();

                        }
                    }
                    var ListTenders = (from Tnder in FsDb.Tbl_TendersAuctions
                                       join PayM in FsDb.Tbl_PurchaseMethods on Tnder.PurchaseMethodeID equals PayM.ID
                                       join fy in FsDb.Tbl_Fiscalyear on Tnder.FinancialYearId equals fy.ID
                                       select new
                                       {
                                           ID = Tnder.ID,
                                           TenderNo = Tnder.TenderNo,
                                           TenderDate = Tnder.TenderDate,
                                           Note = Tnder.Note,
                                           PayMName = PayM.Name,
                                           FinYearName = fy.Name
                                       }).OrderBy(x => x.TenderDate).ToList();
                    dataGridView1.DataSource = ListTenders;
                    cmbPurchMethod.Select();
                    this.ActiveControl = cmbPurchMethod;
                    cmbPurchMethod.Focus();

                }
                else
                {
                    MessageBox.Show("حدد المناقصه - المزايده المراد حدفها");
                    cmbPurchMethod.Select();
                    this.ActiveControl = cmbPurchMethod;
                    cmbPurchMethod.Focus();
                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية حذف  المناقصه / المزايده - المزايده .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void txtTendersNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpTendersDate.Focus();

            }
        }

        private void dtpTendersDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();

            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "";
            comboBox2.Text = "اختر الجهد";

            dtpTendersDate.Value = Convert.ToDateTime(DateTime.Now.Date);
            Vint_TenderId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            txtTendertId.Text = Vint_TenderId.ToString();

          var result = FsDb.Tbl_TendersAuctions.FirstOrDefault(x => x.ID == Vint_TenderId);
            cmbPurchMethod.SelectedValue = result.PurchaseMethodeID;
            txtTendertId.Text = result.ID.ToString();
            txtTendersNo.Text = result.TenderNo;
            dtpTendersDate.Value = Convert.ToDateTime(result.TenderDate);
            textBox1.Text = result.Note;
            comboBox1.SelectedValue = int.Parse(result.FinancialYearId.ToString());
            if (result.ElectricalEffortID > 0)
            { comboBox2.SelectedIndex = int.Parse(result.ElectricalEffortID.ToString()); }
            cmbPurchMethod.Select();
            this.ActiveControl = cmbPurchMethod;
            cmbPurchMethod.Focus();

        }

        private void cmbPurchMethod_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtTendersNo.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        private void cmbPurchMethod_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Vint_PUrchasePay = int.Parse(cmbPurchMethod.SelectedValue.ToString());
            var ListTenders = (from Tnder in FsDb.Tbl_TendersAuctions
                               join PayM in FsDb.Tbl_PurchaseMethods on Tnder.PurchaseMethodeID equals PayM.ID
                               join fy in FsDb.Tbl_Fiscalyear on Tnder.FinancialYearId equals fy.ID
                               where (Tnder.PurchaseMethodeID == Vint_PUrchasePay)
                               select new
                               {
                                   ID = Tnder.ID,
                                   TenderNo = Tnder.TenderNo,
                                   TenderDate = Tnder.TenderDate,
                                   Note = Tnder.Note,
                                   PayMName = PayM.Name,
                                   FinYearName = fy.Name
                               }).OrderBy(x => x.TenderDate).ToList();
           
            dataGridView1.DataSource = ListTenders;
            txtTendersNo.Text = "";
            dtpTendersDate.Value = Convert.ToDateTime(DateTime.Now.Date);
            textBox1.Text = "";

        }

        private void txtTendersNo_TextChanged(object sender, EventArgs e)
        {
            if (txtTendersNo.Text == "")
            {
                //cmbPurchMethod.SelectedIndex = -1;
                //cmbPurchMethod.Text = "";
                //cmbPurchMethod.SelectedText = "اختر طريقة الشراء";

                //comboBox1.SelectedIndex = -1;
                //comboBox1.Text = "";
                //comboBox1.SelectedText = "اختر العام المالي";
                //dtpTendersDate.Value = Convert.ToDateTime(DateTime.Now.Date);
                //textBox1.Text = "";
                //var ListTenders = (from Tnder in FsDb.Tbl_TendersAuctions
                //                   join PayM in FsDb.Tbl_PurchaseMethods on Tnder.PurchaseMethodeID equals PayM.ID
                //                   join fy in FsDb.Tbl_Fiscalyear on Tnder.FinancialYearId equals fy.ID
                                  
                //                   select new
                //                   {
                //                       ID = Tnder.ID,
                //                       TenderNo = Tnder.TenderNo,
                //                       TenderDate = Tnder.TenderDate,
                //                       Note = Tnder.Note,
                //                       PayMName = PayM.Name,
                //                       FinYearName = fy.Name
                //                   }).OrderBy(x => x.TenderDate).ToList();

                //dataGridView1.DataSource = ListTenders;

            }
            else
            {    if (cmbPurchMethod.SelectedValue != null)
                {
                    Vint_PUrchasePay = int.Parse(cmbPurchMethod.SelectedValue.ToString());
                }
                
                FsDb.Tbl_TendersAuctions.Where(x => x.TenderNo == txtTendersNo.Text  && x.PurchaseMethodeID == Vint_PUrchasePay).ToList();
                var ListTenders = (from Tnder in FsDb.Tbl_TendersAuctions
                                   join PayM in FsDb.Tbl_PurchaseMethods on Tnder.PurchaseMethodeID equals PayM.ID
                                   join fy in FsDb.Tbl_Fiscalyear on Tnder.FinancialYearId equals fy.ID
                                   where (Tnder.TenderNo == txtTendersNo.Text && Tnder.PurchaseMethodeID == Vint_PUrchasePay)
                                   select new
                                   {
                                       ID = Tnder.ID,
                                       TenderNo = Tnder.TenderNo,
                                       TenderDate = Tnder.TenderDate,
                                       Note = Tnder.Note,
                                       PayMName = PayM.Name,
                                       FinYearName = fy.Name
                                   }).OrderBy(x => x.TenderDate).ToList();

                dataGridView1.DataSource = ListTenders;
                
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
        }

        private void dtpTendersDate_Leave(object sender, EventArgs e)
        {
            DateTime Vdt_tenderTime = Convert.ToDateTime(dtpTendersDate.Value.ToString());
            if (dtpTendersDate.Value != null)

            {
                FsDb.Tbl_TendersAuctions.Where(x => x.TenderNo == txtTendersNo.Text && x.PurchaseMethodeID == Vint_PUrchasePay && x.TenderDate == Vdt_tenderTime).ToList();
                var ListTenders = (from Tnder in FsDb.Tbl_TendersAuctions
                                   join PayM in FsDb.Tbl_PurchaseMethods on Tnder.PurchaseMethodeID equals PayM.ID
                                   join fy in FsDb.Tbl_Fiscalyear on Tnder.FinancialYearId equals fy.ID
                                   where (Tnder.TenderNo == txtTendersNo.Text && Tnder.PurchaseMethodeID == Vint_PUrchasePay)
                                   select new
                                   {
                                       ID = Tnder.ID,
                                       TenderNo = Tnder.TenderNo,
                                       TenderDate = Tnder.TenderDate,
                                       Note = Tnder.Note,
                                       PayMName = PayM.Name,
                                       FinYearName = fy.Name
                                   }).OrderBy(x => x.TenderDate).ToList();

                dataGridView1.DataSource = ListTenders;
                if (ListTenders.Count != 0)
                { MessageBox.Show($"هذه المناقصه تم ادخالها من قبل "); }
            }
        }
    }
}