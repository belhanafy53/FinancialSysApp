﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using UserRoles;

namespace FinancialSysApp.Forms.BasicCodeForms
{
    public partial class ManagementFrm : DevExpress.XtraEditors.XtraForm
    {
        int xID;
        //Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        //int xcheckb;
        int VintManagId = 0;
        public ManagementFrm()
        {
            InitializeComponent();


            comboBox1.DataSource = FsDb.Tbl_ManagementCategory.ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            comboBox1.SelectedItem = null;

            comboBox2.DataSource = FsDb.Tbl_ManagementCategory.ToList();
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "ID";
            comboBox2.SelectedItem = null;

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = -1;
            }
            comboBox2.SelectedValue = -1;
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = -1;
            }
            comboBox2.SelectedValue = -1;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            textBox1.Select();
            this.ActiveControl = textBox1;
            textBox1.Focus();







            // This line of code is generated by Data Source Configuration Wizard
            // Instantiate a new DBContext
            FinancialSysApp.DataBase.Model.Model1 dbContext = new FinancialSysApp.DataBase.Model.Model1();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.Tbl_Management.LoadAsync().ContinueWith(loadTask =>
            {
                // Bind data to control when loading complete
                tbl_ManagementBindingSource.DataSource = dbContext.Tbl_Management.Local.ToBindingList();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            treeList1.DataSource = FsDb.Tbl_Management.Where(x => x.Name.Contains(textBox1.Text)).OrderBy(x => x.Management_ID).ToList();
            treeList1.ExpandAll();
            textBox2.Text = "";
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
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
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                txtBranch.Text = "";
                textBox2.Text = treeList1.GetFocusedRowCellValue(treeList1.Columns[0]).ToString();
                textBox4.Text = treeList1.GetFocusedRowCellValue(treeList1.Columns[1]).ToString();
                xID = int.Parse(textBox4.Text);
                var list = FsDb.Tbl_Management.FirstOrDefault(x => x.Management_ID == xID);
                if (list.Parent_ID != null)
                {
                    textBox5.Text = treeList1.GetFocusedRowCellValue(treeList1.Columns[2]).ToString();
                }
                if (list.ManagementCategory_ID != null)
                {
                    comboBox1.SelectedValue = int.Parse(treeList1.GetFocusedRowCellValue(treeList1.Columns[3]).ToString());
                }
                if (list.BrancheName != null)
                {
                    txtBranch.Text = list.BrancheName;
                }

                textBox3.Select();
                this.ActiveControl = textBox3;
                textBox3.Focus();

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("من فضلك قم بإختيار الادارة من الهيكل الاداري ");
            }
            else if (textBox3.Text == "")

            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 5 && w.ProcdureId == 3);
                if (validationSaveUser != null)
                {
                    int vint_mngid = int.Parse(textBox4.Text);
                    var result = FsDb.Tbl_Management.FirstOrDefault(x => x.Management_ID == vint_mngid);
                    if (result != null)
                    {
                        if (textBox2.Text != "")
                        { result.Name = textBox2.Text; }
                        if (txtBranch.Text != "")
                        {
                            result.BrancheName = txtBranch.Text;
                        }
                        if (comboBox3.SelectedIndex == 0)
                        {
                            result.KindBranchDirect = 1;   
                        }
                        if (comboBox3.SelectedIndex == 0)
                        {
                            result.KindBranchDirect = 1;
                        }
                        else if (comboBox3.SelectedIndex == 1)
                        {
                            result.KindBranchDirect = 2;
                        }
                    }
                    result.ManagementCategory_ID = int.Parse(comboBox1.SelectedValue.ToString());
                    FsDb.SaveChanges();
                    var listbenf = FsDb.Tbl_Beneficiary.SingleOrDefault(x => x.ID_Supp == result.Management_ID);
                    if (listbenf != null)
                    {
                        listbenf.Name = textBox2.Text;
                        
                    }
                    FsDb.SaveChanges();
                    //---------------خفظ ااحداث 
                    //int Vint_LastRow = mngTbl.ID;
                    SecurityEvent sev = new SecurityEvent
                    {
                        ActionName = "تعديل ادارة",
                        TableName = "Tbl_Management",
                        TableRecordId = result.ID.ToString(),
                        Description = "",
                        ManagementName = Program.GlbV_Management,
                        ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                        EmployeeName = Program.GlbV_EmpName,
                        User_ID = Program.GlbV_UserId,
                        UserName = Program.GlbV_UserName,
                        FormName = "ManagementFrm"


                    };
                    FsEvDb.SecurityEvents.Add(sev);
                    FsEvDb.SaveChanges();
                    //***************************

                    MessageBox.Show("تم التعديل");
                    treeList1.DataSource = FsDb.Tbl_Management.ToList();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    txtBranch.Text = "";
                    if (comboBox1.Items.Count > 0)
                    {
                        comboBox1.SelectedIndex = -1;
                    }
                    comboBox2.SelectedValue = -1;
                    if (comboBox2.Items.Count > 0)
                    {
                        comboBox2.SelectedIndex = -1;
                    }
                    comboBox2.SelectedValue = -1;

                    textBox1.Select();
                    this.ActiveControl = textBox1;
                    textBox1.Focus();
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية تعديل  ادارة .. برجاء مراجعة مدير المنظومه");
                }
            }

            else
            {
                
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 5 && w.ProcdureId == 1);
                if (validationSaveUser != null)
                {
                    int xid = FsDb.Tbl_Management.Max(x => x.ID);
                    short Vint_KindBranch = 0;
                    string Vstr_Branch = "";
                    if (txtBranch.Text != "")
                    {
                        Vstr_Branch = txtBranchAdd.Text;
                    }
                    if (comboBox4.SelectedIndex == 0)
                    {
                        Vint_KindBranch = 1;
                    }
                    else if (comboBox4.SelectedIndex == 1)
                    {
                        Vint_KindBranch = 2;
                    }
                    Tbl_Management mngTbl = new Tbl_Management
                    {
                        Name = textBox3.Text,
                        Parent_ID = int.Parse(textBox4.Text),
                        Management_ID = xid + 1,
                        ManagementCategory_ID = int.Parse(comboBox2.SelectedValue.ToString()),
                        BrancheName = Vstr_Branch,
                        KindBranchDirect = Vint_KindBranch
                    };
                    FsDb.Tbl_Management.Add(mngTbl);
                    FsDb.SaveChanges();
                    VintManagId = mngTbl.Management_ID;


                    var listbenf = FsDb.Tbl_Beneficiary.SingleOrDefault(x => x.ID_Supp == VintManagId);
                    if (listbenf == null)
                    {
                        Tbl_Beneficiary bnf = new Tbl_Beneficiary
                        {
                            ID_Mng = VintManagId,
                            Name = textBox3.Text,
                            BeneficiaryKind_ID = 4

                        };
                        FsDb.Tbl_Beneficiary.Add(bnf);
                        FsDb.SaveChanges();
                    }
                    //---------------خفظ ااحداث 
                    int Vint_LastRow = mngTbl.ID;
                    SecurityEvent sev = new SecurityEvent
                    {
                        ActionName = "اضافة ادارة",
                        TableName = "Tbl_Management",
                        TableRecordId = Vint_LastRow.ToString(),
                        Description = "",
                        ManagementName = Program.GlbV_Management,
                        ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                        EmployeeName = Program.GlbV_EmpName,
                        User_ID = Program.GlbV_UserId,
                        UserName = Program.GlbV_UserName,
                        FormName = "ManagementFrm"


                    };
                    FsEvDb.SecurityEvents.Add(sev);
                    FsEvDb.SaveChanges();
                    //***************************
                    MessageBox.Show("تم الحفظ");
                    treeList1.DataSource = FsDb.Tbl_Management.ToList();
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox1.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    txtBranch.Text = "";
                    if (comboBox1.Items.Count > 0)
                    {
                        comboBox1.SelectedIndex = -1;
                    }
                    comboBox2.SelectedValue = -1;
                    if (comboBox2.Items.Count > 0)
                    {
                        comboBox2.SelectedIndex = -1;
                    }
                    comboBox2.SelectedValue = -1;

                    textBox1.Select();
                    this.ActiveControl = textBox1;
                    textBox1.Focus();
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية اضافة  ادارة .. برجاء مراجعة مدير المنظومه");
                }
            }



        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 5 && w.ProcdureId == 4);
                if (validationSaveUser != null)
                {
                    int vint_mngid = int.Parse(textBox4.Text);

                    int result = FsDb.Tbl_Management.Count(x => x.Parent_ID == vint_mngid);
                    if (result != 0)
                    {
                        MessageBox.Show("  لا يمكن حدف هده الادارة لإشتمالها على ادارات تابعه ");
                    }
                    else
                    {
                        var resultd = FsDb.Tbl_Management.Where (x=>x.Management_ID == vint_mngid);
                        if (resultd != null)
                        {
                            var result1 = MessageBox.Show("هل تريد حدف هده الادارة  ؟", "حدف ادارة ", MessageBoxButtons.YesNo);
                            if (result1 == DialogResult.Yes)
                            {
                                var resultr = FsDb.Tbl_Management.FirstOrDefault(x => x.Management_ID == vint_mngid);
                                FsDb.Tbl_Management.Remove(resultr);
                                FsDb.SaveChanges();
                                //---------------خفظ ااحداث 
                                //int Vint_LastRow = mngTbl.ID;
                                SecurityEvent sev = new SecurityEvent
                                {
                                    ActionName = "حذف ادارة",
                                    TableName = "Tbl_Management",
                                    TableRecordId = resultr.ID.ToString(),
                                    Description = "",
                                    ManagementName = Program.GlbV_Management,
                                    ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                    EmployeeName = Program.GlbV_EmpName,
                                    User_ID = Program.GlbV_UserId,
                                    UserName = Program.GlbV_UserName,
                                    FormName = "ManagementFrm"


                                };
                                FsEvDb.SecurityEvents.Add(sev);
                                FsEvDb.SaveChanges();
                                //***************************

                                MessageBox.Show("  تم الحدف");

                                textBox2.Text = "";
                                textBox3.Text = "";
                                textBox1.Text = "";

                                textBox4.Text = "";
                                textBox5.Text = "";

                                if (comboBox1.Items.Count > 0)
                                {
                                    comboBox1.SelectedIndex = -1;
                                }
                                comboBox2.SelectedValue = -1;
                                if (comboBox2.Items.Count > 0)
                                {
                                    comboBox2.SelectedIndex = -1;
                                }
                                comboBox2.SelectedValue = -1;

                                treeList1.DataSource = FsDb.Tbl_Management.Where(x => x.Name.StartsWith(textBox1.Text)).OrderBy(x => x.Management_ID).ToList();
                                treeList1.ExpandAll();
                                textBox1.Select();
                                this.ActiveControl = textBox1;
                                textBox1.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("حدد الادارة المراد حدفها");
                            textBox1.Select();
                            this.ActiveControl = textBox1;
                            textBox1.Focus();
                        }

                    }
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية حذف  ادارة .. برجاء مراجعة مدير المنظومه");
                }
            }
            catch


            {
                MessageBox.Show("هذا الاداره لايمكن حذفه لوجود ادارات تابعه لها او يوجد مستندات لها", "المنظومة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void treeList1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            txtBranch.Text = "";
            textBox2.Text = treeList1.GetFocusedRowCellValue(treeList1.Columns[0]).ToString();
            textBox4.Text = treeList1.GetFocusedRowCellValue(treeList1.Columns[1]).ToString();
            xID = int.Parse(textBox4.Text);
            var list = FsDb.Tbl_Management.FirstOrDefault(x => x.Management_ID == xID);
            if (list.Parent_ID != null)
            {
                textBox5.Text = treeList1.GetFocusedRowCellValue(treeList1.Columns[2]).ToString();
            }
            if (list.ManagementCategory_ID != null)
            {
                comboBox1.SelectedValue = int.Parse(treeList1.GetFocusedRowCellValue(treeList1.Columns[3]).ToString());
            }
            if (list.BrancheName != null)
            {
                txtBranch.Text = list.BrancheName;
            }
            if (list.KindBranchDirect != null)
            {
                if (list.KindBranchDirect == 1)
                {
                    comboBox3.SelectedIndex = 0;
                }
                else if (list.KindBranchDirect == 2)
                {
                    comboBox3.SelectedIndex = 1;
                }

            }

            textBox3.Select();
            this.ActiveControl = textBox3;
            textBox3.Focus();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
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
                simpleButton1.Focus();
            }
        }

        private void ManagementFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
