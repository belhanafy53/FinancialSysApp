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
    public partial class UnitesFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_ItemId;
        public UnitesFrm()
        {
            InitializeComponent();
        }

        private void UnitesFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Unites' table. You can move, or remove it, as needed.
            this.tbl_UnitesTableAdapter.Fill(this.financialSysDataSet.Tbl_Unites);
            Nametxt.Text = "";
            Nametxt.Select();
            this.ActiveControl = Nametxt;
            Nametxt.Focus();

        }

        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
            var list = FsDb.Tbl_Unites.Where(x => x.Name.Contains(Nametxt.Text)).ToList();
            radTreeView1.DataSource = list;
            if (Nametxt.Text == "")
            {
                textBox1.Text = "";
                IDtxtBox.Text = "";
            }
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
                MessageBox.Show("من فضلك ادخل الوحده ");
                Nametxt.Select();
                this.ActiveControl = Nametxt;
                Nametxt.Focus();
            }
            else
            {
                int xrows = radTreeView1.SelectedNodes.Count;
                if (IDtxtBox.Text == "" && Nametxt.Text != "")


                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 45 && w.ProcdureId == 1);
                    if (validationSaveUser != null)
                    {
                        
                        
                        Tbl_Unites CatF = new Tbl_Unites
                        {
                            Name = Nametxt.Text,
                           

                        };
                        FsDb.Tbl_Unites.Add(CatF);
                        FsDb.SaveChanges();

                        //---------------خفظ ااحداث 
                        int Vint_LastRow = CatF.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة وحده",
                            TableName = "Tbl_Unites",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة الوحدات"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم الحفظ");
                        radTreeView1.DataSource = FsDb.Tbl_Unites.ToList();
                        Nametxt.Text = "";
                        IDtxtBox.Text = "";
                        textBox1.Text = "";

                        radTreeView1.ExpandAll();
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية اضافة  وحده .. برجاء مراجعة مدير المنظومه");
                    }
                }
                else if (IDtxtBox.Text == "" && textBox1.Text == "" && textBox2.Text != "")
                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 45 && w.ProcdureId == 1);
                    if (validationSaveUser != null)
                    {
                        
                         
                        Tbl_Unites CatF = new Tbl_Unites
                        {
                            Name = textBox2.Text,
                            Parent_ID = null 
                        };
                        FsDb.Tbl_Unites.Add(CatF);
                        FsDb.SaveChanges();
                        int Vint_LastRow = CatF.ID;
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة وحده",
                            TableName = "Tbl_Unites",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة الوحدات"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //************************************
                        var resultASk = MessageBox.Show("هل تريد اضافة وحدات تابعه للوحده " + " " + textBox1.Text, "تم الحفظ ", MessageBoxButtons.YesNo);
                        radTreeView1.DataSource = FsDb.Tbl_Unites.ToList();
                        if (resultASk == DialogResult.Yes)
                        {
                            Nametxt.Text = "";
                            IDtxtBox.Text = "";
                            //textBox1.Text = "";
                            textBox2.Text = "";

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

                            radTreeView1.ExpandAll();
                            Nametxt.Select();
                            this.ActiveControl = Nametxt;
                            Nametxt.Focus();
                        }
                    }
                }
                else if (IDtxtBox.Text != "" && textBox1.Text != "" && textBox2.Text != "")
                {
                    var validationSaveUser1 = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 45 && w.ProcdureId == 1);
                    if (validationSaveUser1 != null)
                    {
                        
                        Tbl_Unites CatF = new Tbl_Unites
                        {
                            Name =  textBox2.Text,
                            Parent_ID = int.Parse(IDtxtBox.Text) 

                        };
                        FsDb.Tbl_Unites.Add(CatF);
                        FsDb.SaveChanges();
                        int Vint_LastRow = CatF.ID;
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة وحده",
                            TableName = "Tbl_Unites",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة الوحدات"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //************************************
                        var resultASk = MessageBox.Show("هل تريد اضافة وحدات تابعه للوحده " + " " + textBox1.Text, "تم الحفظ ", MessageBoxButtons.YesNo);
                        radTreeView1.DataSource = FsDb.Tbl_Unites.ToList();
                        if (resultASk == DialogResult.Yes)
                        {
                            Nametxt.Text = "";
                            //IDtxtBox.Text = "";
                            //textBox1.Text = "";
                            textBox2.Text = "";

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

                            radTreeView1.ExpandAll();
                            Nametxt.Select();
                            this.ActiveControl = Nametxt;
                            Nametxt.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية اضافة  وحده .. برجاء مراجعة مدير المنظومه");
                    }
                }
                else if (IDtxtBox.Text != "" && textBox1.Text != "" && textBox2.Text == "" || Nametxt.Text == "")
                {
                    var validationSaveUser3 = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 45 && w.ProcdureId == 3);
                    if (validationSaveUser3 != null)

                    {
                       
                        Vint_ItemId = int.Parse(IDtxtBox.Text);
                        var result = FsDb.Tbl_Unites.SingleOrDefault(x => x.ID == Vint_ItemId);
                        result.Name = textBox1.Text;
                       
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل وحده",
                            TableName = "Tbl_Unites",
                            TableRecordId = result.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة الوحدات"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //************************************
                        MessageBox.Show("تم التعديل");
                        radTreeView1.DataSource = FsDb.Tbl_Unites.ToList();
                        Nametxt.Text = "";
                        IDtxtBox.Text = "";
                        textBox1.Text = "";
                        textBox2.Text = "";


                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية تعديل  وحده .. برجاء مراجعة مدير المنظومه");
                    }

                }
                else if (IDtxtBox.Text != "" && textBox1.Text != "" && textBox2.Text == "")
                {
                    var validationSaveUser2 = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 45 && w.ProcdureId == 3);
                    if (validationSaveUser2 != null)

                    {

                        Vint_ItemId = int.Parse(IDtxtBox.Text);
                        var result = FsDb.Tbl_Unites.SingleOrDefault(x => x.ID == Vint_ItemId);
                        result.Name = textBox1.Text;

                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل وحده",
                            TableName = "Tbl_Unites",
                            TableRecordId = result.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة الوحدات"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //************************************
                        MessageBox.Show("تم التعديل");
                        radTreeView1.DataSource = FsDb.Tbl_Unites.ToList();
                        Nametxt.Text = "";
                        IDtxtBox.Text = "";
                        textBox1.Text = "";
                        textBox2.Text = "";


                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية تعديل  وحده .. برجاء مراجعة مدير المنظومه");
                    }

                }
            }
        }

        private void radTreeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";

            if (radTreeView1.SelectedNodes.Count() > 0)
            {
                textBox1.Text = radTreeView1.SelectedNode.Text.ToString();
                Vint_ItemId = int.Parse(radTreeView1.SelectedNode.Value.ToString());
                var itemCatList = FsDb.Tbl_Unites.FirstOrDefault(x => x.ID == Vint_ItemId);

                
                IDtxtBox.Text = Vint_ItemId.ToString();

                var list = FsDb.Tbl_Unites.FirstOrDefault(x => x.ID == Vint_ItemId);

                Nametxt.Text = textBox1.Text;
                textBox2.Select();
                this.ActiveControl = textBox2;
                textBox2.Focus();
            }
            else
            {
                MessageBox.Show("من فضلك اختر الوحده المراد");
                radTreeView1.Select();
                this.ActiveControl = radTreeView1;
                radTreeView1.Focus();
            }
        }

        private void radTreeView1_KeyDown(object sender, KeyEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";

            if (radTreeView1.SelectedNodes.Count() > 0)
            {
                textBox1.Text = radTreeView1.SelectedNode.Text.ToString();
                Vint_ItemId = int.Parse(radTreeView1.SelectedNode.Value.ToString());
                var itemCatList = FsDb.Tbl_Unites.FirstOrDefault(x => x.ID == Vint_ItemId);


                IDtxtBox.Text = Vint_ItemId.ToString();

                var list = FsDb.Tbl_Unites.FirstOrDefault(x => x.ID == Vint_ItemId);

                Nametxt.Text = textBox1.Text;
                textBox2.Select();
                this.ActiveControl = textBox2;
                textBox2.Focus();
            }
            else
            {
                MessageBox.Show("من فضلك اختر الوحده المراد");
                radTreeView1.Select();
                this.ActiveControl = radTreeView1;
                radTreeView1.Focus();
            }
        }

        private void IDtxtBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}