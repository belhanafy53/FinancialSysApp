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

namespace FinancialSysApp.Forms.BasicCodeForms
{
    public partial class BanksFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int xcatid;
        int Vint_Acc_id = 0;
        public BanksFrm()
        {
            InitializeComponent();
        }

        private void BanksFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet7.Tbl_Banks' table. You can move, or remove it, as needed.
            this.tbl_BanksTableAdapter.Fill(this.financialSysDataSet7.Tbl_Banks);

            Nametxt.Text = "";
            Nametxt.Select();
            this.ActiveControl = Nametxt;
            Nametxt.Focus();
        }



        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
            var list = FsDb.Tbl_Banks.Where(x => x.Name.Contains(Nametxt.Text)).ToList();
            radTreeView1.DataSource = list;
            radTreeView1.ExpandAll();
        }



        private void Nametxt_KeyDown(object sender, KeyEventArgs e)
        {
            int xrows = radTreeView1.Nodes.Count;
            if (xrows == 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    simpleButton1.Select();
                    this.ActiveControl = simpleButton1;
                    simpleButton1.Focus();
                }
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    radTreeView1.Select();
                    this.ActiveControl = radTreeView1;
                    radTreeView1.Focus();
                }
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (Nametxt.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("من فضلك ادخل البنك ");
                Nametxt.Select();
                this.ActiveControl = Nametxt;
                Nametxt.Focus();
            }
            else
            {
                int xrows = radTreeView1.SelectedNodes.Count;
                if (IDtxtBox.Text == "" && Nametxt.Text != "")


                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 17 && w.ProcdureId == 1);
                    if (validationSaveUser != null)
                    {
                       
                        var listAccGuidID = FsDb.Tbl_Accounting_Guid.FirstOrDefault(x => x.Account_NO == textBox9.Text);
                        if (listAccGuidID != null)
                        {
                            Vint_Acc_id = listAccGuidID.ID;
                        }
                        Tbl_Banks CatF = new Tbl_Banks
                        {
                            Name = Nametxt.Text,
                            AccountBanking_NO = textBox6.Text,
                            IBanBanking_NO = textBox5.Text,
                            Accounting_GuidID = Vint_Acc_id
                        };
                        FsDb.Tbl_Banks.Add(CatF);
                        FsDb.SaveChanges();
                        Tbl_Beneficiary bnf = new Tbl_Beneficiary
                        {
                            Name = Nametxt.Text,
                            ID_Bank = CatF.ID,
                            BeneficiaryKind_ID = 7

                        };
                        FsDb.Tbl_Beneficiary.Add(bnf);
                       
                        FsDb.SaveChanges();
                        //**************اضافة مستفيد
                                                     
                                   
                                 

                           
                      
                        //---------------خفظ ااحداث 
                        int Vint_LastRow = CatF.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة بنك",
                            TableName = "Tbl_Banks",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة البنوك"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                     //***************************
                        MessageBox.Show("تم الحفظ");
                        radTreeView1.DataSource = FsDb.Tbl_Banks.ToList();
                        Nametxt.Text = "";
                        IDtxtBox.Text = "";
                        textBox1.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox9.Text = "";
                        textBox10.Text = "";
                        textBox1.Enabled = false;
                        radTreeView1.ExpandAll();
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية اضافة  بنك .. برجاء مراجعة مدير المنظومه");
                    }
                }
                else if (IDtxtBox.Text != "" && textBox1.Text != "" && textBox2.Text != "")
                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 17 && w.ProcdureId == 1);
                    if (validationSaveUser != null)
                    {
                        var listAccGuidID = FsDb.Tbl_Accounting_Guid.FirstOrDefault(x => x.Account_NO == textBox9.Text);
                        if (listAccGuidID != null)
                        {
                            Vint_Acc_id = listAccGuidID.ID;
                        }
                        Tbl_Banks CatF = new Tbl_Banks
                        {
                            Name = textBox1.Text + " " + textBox2.Text,
                            Parent_ID = int.Parse(IDtxtBox.Text),
                            AccountBanking_NO = textBox6.Text,
                            IBanBanking_NO = textBox5.Text ,
                             Accounting_GuidID = Vint_Acc_id
                        };
                        FsDb.Tbl_Banks.Add(CatF);
                        FsDb.SaveChanges();
                        Tbl_Beneficiary bnf = new Tbl_Beneficiary
                        {
                            Name = textBox1.Text + " " + textBox2.Text,
                            ID_Bank = CatF.ID,
                            BeneficiaryKind_ID = 7

                        };
                        
                       
                        FsDb.Tbl_Beneficiary.Add(bnf);
                        FsDb.SaveChanges();
                        int Vint_LastRow = CatF.ID;
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة بنك",
                            TableName = "Tbl_Banks",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة البنوك"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //************************************
                        var resultASk = MessageBox.Show("هل تريد اضافة فروع تابعه لبنك " + " " + textBox1.Text, "تم الحفظ ", MessageBoxButtons.YesNo);
                        radTreeView1.DataSource = FsDb.Tbl_Banks.ToList();
                        if (resultASk == DialogResult.Yes)
                        {
                            Nametxt.Text = "";
                            //IDtxtBox.Text = "";
                            //textBox1.Text = "";
                            textBox2.Text = "";
                            //textBox3.Text = "";
                            //textBox4.Text = "";
                            textBox5.Text = "";
                            textBox6.Text = "";
                            //textBox7.Text = "";
                            //textBox8.Text = "";
                            textBox9.Text = "";
                            textBox10.Text = "";
                            radTreeView1.ExpandAll();
                            textBox2.Select();
                            this.ActiveControl = textBox2;
                            textBox2.Focus();
                        }
                        else
                        {
                            Nametxt.Text = "";
                            IDtxtBox.Text = "";
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            textBox6.Text = "";
                            textBox7.Text = "";
                            textBox8.Text = "";
                            textBox9.Text = "";
                            textBox10.Text = "";
                            radTreeView1.ExpandAll();
                            Nametxt.Select();
                            this.ActiveControl = Nametxt;
                            Nametxt.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية اضافة  بنك .. برجاء مراجعة مدير المنظومه");
                    }
                }
                else if (IDtxtBox.Text != "" && textBox1.Text != "" && textBox2.Text == "" || Nametxt.Text == "")
                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 17 && w.ProcdureId == 3);
                    if (validationSaveUser != null)

                    {
                        var listAccGuidID = FsDb.Tbl_Accounting_Guid.FirstOrDefault(x => x.Account_NO == textBox7.Text);
                        xcatid = int.Parse(IDtxtBox.Text);
                        var result = FsDb.Tbl_Banks.SingleOrDefault(x => x.ID == xcatid);
                        
                        result.Name = textBox1.Text;
                        result.AccountBanking_NO = textBox3.Text;
                        result.IBanBanking_NO = textBox4.Text;
                        if (listAccGuidID != null)
                        {
                            result.Accounting_GuidID = listAccGuidID.ID;
                        }
                        var resultBnf = FsDb.Tbl_Beneficiary.SingleOrDefault(x => x.Name == Nametxt.Text );
                        resultBnf.Name = textBox1.Text;
                        resultBnf.ID_Bank = result.ID;
                        resultBnf.BeneficiaryKind_ID = 7;
                        resultBnf.ID_Bank = result.ID;
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل بنك",
                            TableName = "Tbl_Banks",
                            TableRecordId = result.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة البنوك"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //************************************
                        MessageBox.Show("تم التعديل");
                        radTreeView1.DataSource = FsDb.Tbl_Banks.ToList();
                        Nametxt.Text = "";
                        IDtxtBox.Text = "";
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox9.Text = "";
                        textBox10.Text = "";

                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية تعديل  بنك .. برجاء مراجعة مدير المنظومه");
                    }

                }

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 17 && w.ProcdureId == 4);
                if (validationSaveUser != null)
                {
                    int xrows = radTreeView1.Nodes.Count;
                    if (xrows != 0 && Nametxt.Text != "")
                    {
                        var result1 = MessageBox.Show("هل تريد حدف هدا البنك  ؟", "حدف بنك ", MessageBoxButtons.YesNo);

                        if (result1 == DialogResult.Yes)
                        {
                            xcatid = int.Parse(IDtxtBox.Text);

                            int Vint_parent = FsDb.Tbl_Banks.Count(x => x.Parent_ID == xcatid);
                            if (Vint_parent > 0)
                            {
                                MessageBox.Show("لايمكن حذف هذا البنك لإحتوائه على بنوك ");
                            }
                            else
                            {
                                var result = FsDb.Tbl_Banks.Find(xcatid);
                                FsDb.Tbl_Banks.Remove(result);
                                FsDb.SaveChanges();
                                //---------------خفظ ااحداث 
                                SecurityEvent sev = new SecurityEvent
                                {
                                    ActionName = "حذف بنك",
                                    TableName = "Tbl_Banks",
                                    TableRecordId = result.ID.ToString(),
                                    Description = "",
                                    ManagementName = Program.GlbV_Management,
                                    ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                    EmployeeName = Program.GlbV_EmpName,
                                    User_ID = Program.GlbV_UserId,
                                    UserName = Program.GlbV_UserName,
                                    FormName = "شاشة البنوك"


                                };
                                FsEvDb.SecurityEvents.Add(sev);
                                FsEvDb.SaveChanges();
                                //************************************
                                MessageBox.Show("  تم الحذف");
                            }
                            Nametxt.Text = "";
                            IDtxtBox.Text = "";
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            textBox6.Text = "";
                            textBox7.Text = "";
                            textBox8.Text = "";
                            textBox9.Text = "";
                            textBox10.Text = "";
                        }
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("من فضلك حدد البنك المراد حدفه");
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية حذف  بنك .. برجاء مراجعة مدير المنظومه");
                }
            }
            catch


            {
                MessageBox.Show("هذا البنك لايمكن حذفه لوجود مستندات له", "المنظومة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void radTreeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                textBox1.Text = "";
                textBox2.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox1.Enabled = true;
                if (radTreeView1.SelectedNodes.Count() > 0)
                {
                    textBox1.Text = radTreeView1.SelectedNode.Text.ToString();
                    int Vint_BankID = int.Parse(radTreeView1.SelectedNode.Value.ToString());
                    IDtxtBox.Text = Vint_BankID.ToString();

                    var list = FsDb.Tbl_Banks.FirstOrDefault(x => x.ID == Vint_BankID);
                    textBox3.Text = list.AccountBanking_NO;
                    textBox4.Text = list.IBanBanking_NO;
                    Nametxt.Text = textBox1.Text;
                    textBox2.Select();
                    this.ActiveControl = textBox2;
                    textBox2.Focus();
                }
                else
                {
                    MessageBox.Show("من فضلك اختر البنك المراد");
                    radTreeView1.Select();
                    this.ActiveControl = radTreeView1;
                    radTreeView1.Focus();
                }

            }
        }



        private void radTreeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox1.Enabled = true;

            if (radTreeView1.SelectedNodes.Count() > 0)
            {
                textBox1.Text = radTreeView1.SelectedNode.Text.ToString();
                int Vint_BankID = int.Parse(radTreeView1.SelectedNode.Value.ToString());
                IDtxtBox.Text = Vint_BankID.ToString();

                var list = FsDb.Tbl_Banks.FirstOrDefault(x => x.ID == Vint_BankID);
                var listaccguid = FsDb.Tbl_Accounting_Guid.FirstOrDefault(x => x.ID == list.Accounting_GuidID);
                textBox3.Text = list.AccountBanking_NO;
                textBox4.Text = list.IBanBanking_NO;
                if (listaccguid != null)
                {
                    textBox7.Text = listaccguid.Account_NO;
                    textBox8.Text = listaccguid.Name;
                }
                Nametxt.Text = textBox1.Text;
                textBox2.Select();
                this.ActiveControl = textBox2;
                textBox2.Focus();
            }
            else
            {
                MessageBox.Show("من فضلك اختر البنك المراد");
                radTreeView1.Select();
                this.ActiveControl = radTreeView1;
                radTreeView1.Focus();
            }

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox6.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox7.Focus();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox9.Focus();
            }
        }



        public AutoCompleteStringCollection ClientListDropDown()
        {
            AutoCompleteStringCollection asc = new AutoCompleteStringCollection();
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlDataReader dr;
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.Text;
                com.Connection = con;
                con.Open();
                string query;
                query = "select Account_NO From Tbl_Accounting_Guid ";
                com = new SqlCommand(query, con);
                dr = com.ExecuteReader();
                if ((dr != null) && (dr.HasRows))
                {
                    while (dr.Read())
                    {
                        asc.Add(dr.GetValue(0).ToString());
                    }
                    dr.Close();
                    com.Dispose();
                    con.Close();
                }
            }

            catch { }
            return asc;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if ((textBox7.Text).Length == 1)
            {
                ProcessingForms.FindAccount f = new ProcessingForms.FindAccount();
                f.ShowDialog();

                textBox7.Text = f.textBox1.Text;


                //textBox8.Text = (from Guid in FsDb.Tbl_Accounting_Guid
                    
                // where (Guid.Account_NO == textBox7.Text)
                // select new
                // {
                //     Guid.Name


                // }).ToString();
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                var listaccGuid = FsDb.Tbl_Accounting_Guid.FirstOrDefault(x => x.Account_NO == textBox7.Text);
                if (listaccGuid != null)
                {
                    textBox8.Text = listaccGuid.Name;
                }
                
                simpleButton1.Focus();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                var listaccGuid = FsDb.Tbl_Accounting_Guid.FirstOrDefault(x => x.Account_NO == textBox7.Text);
                if (listaccGuid != null)
                {
                    textBox10.Text = listaccGuid.Name;
                }

                simpleButton1.Focus();
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if ((textBox9.Text).Length == 1)
            {
                ProcessingForms.FindAccount f = new ProcessingForms.FindAccount();
                f.ShowDialog();

                textBox9.Text = f.textBox1.Text;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            BankdataGridView.DataSource = FsDb.Tbl_Banks.OrderBy(x => x.Name).ToList();
            //int? VintEmpId;
            if (BankdataGridView.RowCount > 0)
            {
                int WCount = int.Parse(BankdataGridView.RowCount.ToString());
                int? VintId = 0;
                string Vstr_BankName = "";
                for (int i = 0; i <= WCount - 1; i++)
                {
                    VintId = string.IsNullOrEmpty(BankdataGridView.Rows[i].Cells[0].Value.ToString()) ? (int?)null : int.Parse(BankdataGridView.Rows[i].Cells[0].Value.ToString());
                    Vstr_BankName = BankdataGridView.Rows[i].Cells[1].Value.ToString().Trim();

                    var listbenf = FsDb.Tbl_Beneficiary.FirstOrDefault(x => x.Name == Vstr_BankName);
                    if (listbenf == null)
                    {
                        Tbl_Beneficiary bnf = new Tbl_Beneficiary
                        {
                            Name = BankdataGridView.Rows[i].Cells[1].Value.ToString(),
                         
                            BeneficiaryKind_ID = 7

                        };
                        FsDb.Tbl_Beneficiary.Add(bnf);
                        FsDb.SaveChanges();
                    }
                    else
                    {
                        listbenf.ID_Bank = VintId;
                        listbenf.Name = BankdataGridView.Rows[i].Cells[1].Value.ToString();
                        listbenf.BeneficiaryKind_ID = 7;
                        FsDb.SaveChanges();
                    }

                }
                MessageBox.Show("تم النقل");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
