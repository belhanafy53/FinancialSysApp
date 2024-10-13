using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
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
using UserRoles;

namespace FinancialSysApp.Forms.BasicCodeForms
{
    public partial class ExchangeCemtersFrm : DevExpress.XtraEditors.XtraForm
    {
        int xExCid = 0;
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();

        public ExchangeCemtersFrm()
        {
            InitializeComponent();
            FinancialSysApp.DataBase.Model.Model1 dbContext = new FinancialSysApp.DataBase.Model.Model1();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.Tbl_Management.LoadAsync().ContinueWith(loadTask =>
            {
                // Bind data to control when loading complete
                treeList1.DataSource = dbContext.Tbl_Management.Local.ToBindingList();

            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
            dataGridView1.DataSource = FsDb.Tbl_ExchangeCenter.ToList();
            
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Name"].HeaderText = "مركز الصرف";
            dataGridView1.Columns["Mnagement_ID"].Visible = false;
            dataGridView1.Columns["Tbl_Management"].Visible = false;
            dataGridView1.Columns["Name"].Width = 250;
            comboBox1.DataSource = FsDb.Tbl_ManagementCategory.ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            comboBox1.SelectedItem = null;
            groupBox5.Text = "مراكز الصرف " + " " ;

            textBox1.Select();
            this.ActiveControl = textBox1;
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            treeList1.DataSource = FsDb.Tbl_Management.Where(x => x.Name.Contains(textBox1.Text)).OrderBy(x => x.Parent_ID).ToList();
            treeList1.ExpandAll();
            textBox2.Text = "";
            comboBox1.SelectedItem = null;

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                treeList1.Focus();
            }
        }

        private void treeList1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {


                //textBox1.Text = treeList1.GetFocusedRowCellValue(treeList1.Columns[0]).ToString();
                textBox2.Text = treeList1.GetFocusedRowCellValue(treeList1.Columns[0]).ToString();
                textBox4.Text = treeList1.GetFocusedRowCellValue(treeList1.Columns[1]).ToString();
                //textBox8.Text = treeList1.GetFocusedRowCellValue(treeList1.Columns[0]).ToString();

                comboBox1.SelectedValue = int.Parse(treeList1.GetFocusedRowCellValue(treeList1.Columns[3]).ToString());
                int Vint_ManagementId = int.Parse(treeList1.GetFocusedRowCellValue(treeList1.Columns[1]).ToString());

                dataGridView1.DataSource = FsDb.Tbl_ExchangeCenter.Where(x => x.Mnagement_ID == Vint_ManagementId).ToList();
                //dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["Name"].HeaderText = "مركز الصرف";
                dataGridView1.Columns["Mnagement_ID"].Visible = false;
                dataGridView1.Columns["Tbl_Management"].Visible = false;
                dataGridView1.Columns["Name"].Width = 250;
                groupBox5.Text = "مراكز صرف " + " " + textBox2.Text;
                textBox3.Select();
                this.ActiveControl = textBox3;
                textBox3.Focus();

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("من فضلك قم بإختيار مركز صرف  ");
            }
            else if (textBox7.Text != "")

            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 7 && w.ProcdureId == 3);
                if (validationSaveUser != null)
                {
                    xExCid = int.Parse(textBox7.Text);
                    var result = FsDb.Tbl_ExchangeCenter.SingleOrDefault(x => x.ID == xExCid);
                    result.Name = textBox3.Text;
                    result.Mnagement_ID = int.Parse(textBox4.Text);
                    FsDb.SaveChanges();
                    //---------------خفظ ااحداث 

                    SecurityEvent sev = new SecurityEvent
                    {
                        ActionName = "تعديل مركز صرف",
                        TableName = "Tbl_ExchangeCenter",
                        TableRecordId = result.ID.ToString(),
                        Description = "",
                        ManagementName = Program.GlbV_Management,
                        ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                        EmployeeName = Program.GlbV_EmpName,
                        User_ID = Program.GlbV_UserId,
                        UserName = Program.GlbV_UserName,
                        FormName = "ExchangeCenterFrm"


                    };
                    FsEvDb.SecurityEvents.Add(sev);
                    FsEvDb.SaveChanges();
                    //***************************
                    MessageBox.Show("تم التعديل");
                    xExCid = 0;
                    dataGridView1.DataSource = FsDb.Tbl_ExchangeCenter.ToList();
                    textBox3.Text = "";
                    //textBox6.Text = "";
                    textBox7.Text = "";
                    textBox1.Text = "";
                    textBox2.Text = "";

                    textBox3.Select();
                    this.ActiveControl = textBox3;
                    textBox3.Focus();
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية تعديل  مركز صرف .. برجاء مراجعة مدير المنظومه");
                }
            }

            else
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 7 && w.ProcdureId == 1);
                if (validationSaveUser != null)
                {
                    int xid = FsDb.Tbl_Management.Max(x => x.ID);
                    Tbl_ExchangeCenter exchc = new Tbl_ExchangeCenter
                    {
                        Name = textBox3.Text,
                        Mnagement_ID = int.Parse(textBox4.Text)
                };
                    FsDb.Tbl_ExchangeCenter.Add(exchc);
                    FsDb.SaveChanges();
                    //---------------خفظ ااحداث 
                    int Vint_LastRow = exchc.ID;
                    SecurityEvent sev = new SecurityEvent
                    {
                        ActionName = "اضافة مركز صرف",
                        TableName = "Tbl_ExchangeCenter",
                        TableRecordId = Vint_LastRow.ToString(),
                        Description = "",
                        ManagementName = Program.GlbV_Management,
                        ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                        EmployeeName = Program.GlbV_EmpName,
                        User_ID = Program.GlbV_UserId,
                        UserName = Program.GlbV_UserName,
                        FormName = "ExchangeCenterFrm"


                    };
                    FsEvDb.SecurityEvents.Add(sev);
                    FsEvDb.SaveChanges();
                    //***************************
                    MessageBox.Show("تم الحفظ");
                    dataGridView1.DataSource = FsDb.Tbl_ExchangeCenter.ToList();
                    xExCid = 0;
                    textBox3.Text = "";
                    //textBox6.Text = "";
                    textBox7.Text = "";
                    textBox3.Select();
                    this.ActiveControl = textBox3;
                    textBox3.Focus();
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية اضافة  مركز صرف .. برجاء مراجعة مدير المنظومه");
                }

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 7 && w.ProcdureId == 4);
                if (validationSaveUser != null)
                {
                    if (textBox7.Text != "")
                    {
                        var resultd = FsDb.Tbl_ExchangeCenter.Find(xExCid);
                        if (resultd != null)
                        {
                            var result1 = MessageBox.Show("هل تريد حدف هدا المركز  ؟", "حدف مركز ", MessageBoxButtons.YesNo);
                            if (result1 == DialogResult.Yes)
                            {
                                var resultr = FsDb.Tbl_ExchangeCenter.FirstOrDefault(x => x.Name == textBox3.Text);
                                FsDb.Tbl_ExchangeCenter.Remove(resultr);
                                FsDb.SaveChanges();
                                //---------------خفظ ااحداث 

                                SecurityEvent sev = new SecurityEvent
                                {
                                    ActionName = "حذف مركز صرف",
                                    TableName = "Tbl_ExchangeCenter",
                                    TableRecordId = resultd.ID.ToString(),
                                    Description = "",
                                    ManagementName = Program.GlbV_Management,
                                    ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                    EmployeeName = Program.GlbV_EmpName,
                                    User_ID = Program.GlbV_UserId,
                                    UserName = Program.GlbV_UserName,
                                    FormName = "ExchangeCenterFrm"


                                };
                                FsEvDb.SecurityEvents.Add(sev);
                                FsEvDb.SaveChanges();
                                //***************************
                                MessageBox.Show("  تم الحدف");

                                //textBox2.Text = "";
                                textBox3.Text = "";
                                //textBox6.Text = "";
                                dataGridView1.DataSource = FsDb.Tbl_ExchangeCenter.ToList();
                                treeList1.DataSource = FsDb.Tbl_Management.Where(x => x.Name.StartsWith(textBox1.Text)).OrderBy(x => x.Management_ID).ToList();
                                //treeList1.ExpandAll();
                                textBox3.Select();
                                this.ActiveControl = textBox3;
                                textBox3.Focus();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("حدد المركز المراد حدفه");
                        textBox3.Select();
                        this.ActiveControl = textBox3;
                        textBox3.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية حذف  مركز صرف .. برجاء مراجعة مدير المنظومه");
                }
            }
            catch


            {
                MessageBox.Show("هذا المركز  لايمكن حذفه لوجود مستندات له", "المنظومة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void ExchangeCemtersFrm_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            

            dataGridView1.DataSource = (from Exc in FsDb.Tbl_ExchangeCenter

             where (Exc.Name.Contains(textBox3.Text))

             select new
             {
                 ID = Exc.ID,
                 Name = Exc.Name,
                 Mnagement_ID = Exc.Mnagement_ID
             }).ToList();
            //dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Name"].HeaderText = "مركز الصرف";
            dataGridView1.Columns["Mnagement_ID"].Visible = false;
            //dataGridView1.Columns["Tbl_Management"].Visible = false;
            dataGridView1.Columns["Name"].Width = 250;

            if (textBox3.Text == "")
            {
                //textBox6.Text = "";
                //textBox8.Text = "";
            }
            else
            {
                //textBox6.Text = textBox3.Text;
                //textBox8.Text = "";
            }

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Text = "";
                textBox3.Text = "";
                //textBox6.Text = "";
                textBox7.Text = "";
                xExCid = int.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
                var result = FsDb.Tbl_ExchangeCenter.FirstOrDefault(x => x.ID == xExCid);
                textBox3.Text = result.Name;
                //textBox6.Text = result.Name;
                int? xmng = result.Mnagement_ID;
                var mngresult = FsDb.Tbl_Management.FirstOrDefault(x => x.Management_ID == xmng);
                if (mngresult != null)
                {
                    //textBox8.Text = mngresult.Name;
                }
                textBox7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Focus();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            textBox3.Text = "";
            
            textBox7.Text = "";
            int? Vint_Exid = 0;
            string Vstr_Name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Vint_Exid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            var result = FsDb.Tbl_ExchangeCenter.FirstOrDefault(x => x.Name == Vstr_Name);
            textBox3.Text = result.Name;
          
            int? xmng = result.Mnagement_ID;
            var mngresult = FsDb.Tbl_Management.FirstOrDefault(x => x.Management_ID == xmng);
            if (mngresult != null)
            {
                //textBox8.Text = mngresult.Name;
            }
            textBox7.Text = result.ID.ToString();
        }

        private void treeList1_MouseClick(object sender, MouseEventArgs e)
        {
            // textBox1.Text = treeList1.GetFocusedRowCellValue(treeList1.Columns[0]).ToString();
            textBox2.Text = treeList1.GetFocusedRowCellValue(treeList1.Columns[0]).ToString();
            textBox4.Text = treeList1.GetFocusedRowCellValue(treeList1.Columns[1]).ToString();
            //textBox8.Text = treeList1.GetFocusedRowCellValue(treeList1.Columns[0]).ToString();

            comboBox1.SelectedValue = int.Parse(treeList1.GetFocusedRowCellValue(treeList1.Columns[3]).ToString());
             int Vint_ManagementId = int.Parse(treeList1.GetFocusedRowCellValue(treeList1.Columns[1]).ToString());

            dataGridView1.DataSource = FsDb.Tbl_ExchangeCenter.Where (x=>x.Mnagement_ID == Vint_ManagementId).ToList();
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Name"].HeaderText = "مركز الصرف";
            dataGridView1.Columns["Mnagement_ID"].Visible = false;
            dataGridView1.Columns["Tbl_Management"].Visible = false;
            dataGridView1.Columns["Name"].Width = 250;
            groupBox5.Text = "مراكز صرف " + " " + textBox2.Text;

            textBox3.Select();
            this.ActiveControl = textBox3;
            textBox3.Focus();
        }

        private void dataGridView1_KeyDown_1(object sender, KeyEventArgs e)
        {
            textBox1.Text = "";
            textBox3.Text = "";

            textBox7.Text = "";
            int? Vint_Exid = 0;
            string Vstr_Name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Vint_Exid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            var result = FsDb.Tbl_ExchangeCenter.FirstOrDefault(x => x.Name == Vstr_Name);
            textBox3.Text = result.Name;

            int? xmng = result.Mnagement_ID;
            var mngresult = FsDb.Tbl_Management.FirstOrDefault(x => x.Management_ID == xmng);
            if (mngresult != null)
            {
                //textBox8.Text = mngresult.Name;
            }
            textBox7.Text = result.ID.ToString();
        }

        private void dataGridView1_MouseClick_1(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            textBox3.Text = "";

            textBox7.Text = "";
            int? Vint_Exid = 0;
            string Vstr_Name = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
            
            Vint_Exid = int.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());

            var result = FsDb.Tbl_ExchangeCenter.FirstOrDefault(x => x.Name == Vstr_Name);
            textBox3.Text = result.Name;

            int? xmng = result.Mnagement_ID;
            var mngresult = FsDb.Tbl_Management.FirstOrDefault(x => x.Management_ID == xmng);
            if (mngresult != null)
            {
                //textBox8.Text = mngresult.Name;
            }
            textBox7.Text = result.ID.ToString();
        }
    }
}
