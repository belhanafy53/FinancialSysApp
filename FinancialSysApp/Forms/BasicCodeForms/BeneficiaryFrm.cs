using DevExpress.XtraPrinting;
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
using UserRoles;

namespace FinancialSysApp.Forms.BasicCodeForms
{
    public partial class BeneficiaryFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        //int XBenID;
        int BenfId;
        int Vint_bnfKindID = 0;
        int? Vint_Relative;
        int? Vint_ParentID = 0;
        public BeneficiaryFrm()
        {
            InitializeComponent();

        }

        private void BeneficiaryFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_RelativeRlation' table. You can move, or remove it, as needed.
            this.tbl_RelativeRlationTableAdapter.Fill(this.financialSysDataSet.Tbl_RelativeRlation);

            //var list =     from b in FsDb.Tbl_Beneficiary
            //    join bk in FsDb.Tbl_BeneficiaryKind on b.BeneficiaryKind_ID equals bk.ID
            //    select new { Name = b.Name };
            var list = (from b in FsDb.Tbl_Beneficiary
                        join bk in FsDb.Tbl_BeneficiaryKind on b.BeneficiaryKind_ID equals bk.ID
                        select new { ID = b.ID, Name = b.Name, kindName = bk.Name }).OrderBy(x => x.Name).ToList();

            dataGridView2.DataSource = list;
            dataGridView2.Columns["Name"].HeaderText = "المستفيد";
            dataGridView2.Columns["kindName"].HeaderText = "نوع المستفيد";
            dataGridView2.Columns["Name"].Width = 220;

            dataGridView2.Columns["ID"].Visible = false;
            //dataGridView1.DataSource = list;
            //dataGridView1.Columns["ID"].Visible = false;
            comboBox1.DataSource = FsDb.Tbl_BeneficiaryKind.OrderBy(x => x.ID).ToList();

            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = -1;
                comboBox1.SelectedText = " اختر نوع المستفيد";
                textBox1.Visible = false;
            }
            comboBox1.SelectedValue = -1;
            groupBox3.Text = "البحث عن مسنفيد";

            RelativeBenKindCmb.SelectedIndex = -1;
            RelativeBenKindCmb.SelectedText = "اختر صلة القرابه";
            comboBox1.Select();
            this.ActiveControl = comboBox1;
            comboBox1.Focus();


        }


        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
            }
            else if (e.KeyCode == Keys.Tab)
            {
                //SendKeys.Send("{TAB}");
                textBox1.Focus();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                if (textBox1.Text == "")
                {
                    RelatedBoxSrch.Text = "";

                }
                int BenfId = int.Parse(comboBox1.SelectedValue.ToString());

                if (BenfId == 1)
                {
                    RelativeBenKindCmb.Visible = true;
                    groupBox7.Visible = true;

                    var list = (from Emp in FsDb.Tbl_Employee
                                where (Emp.Name.Contains(textBox1.Text))
                                select new
                                {
                                    ID = Emp.ID,
                                    Name = Emp.Name,
                                    NationalId = Emp.NationalId,
                                }).Take(30).OrderBy(t => t.Name).ToList();
                    dataGridView2.Visible = true;
                    dataGridView1.DataSource = list;
                    var list2 = (from b in FsDb.Tbl_Beneficiary
                                 join bk in FsDb.Tbl_BeneficiaryKind on b.BeneficiaryKind_ID equals bk.ID
                                 where (b.Name.Contains(textBox1.Text) && b.BeneficiaryKind_ID == 1 && b.Parent_ID == null)
                                 select new { ID = b.ID, Name = b.Name, kindName = bk.Name }).Distinct().ToList();



                    dataGridView2.DataSource = list2;
                    dataGridView2.Columns["ID"].Visible = false;
                    dataGridView1.DataSource = list;
                    dataGridView1.Columns["ID"].Visible = false;
                    //dataGridView1.Columns["Tbl_Handler"].Visible = false;
                }
                else if (BenfId == 2)
                {
                    RelativeBenKindCmb.Visible = false;
                    groupBox7.Visible = false;
                    var list = (from Sup in FsDb.Tbl_Supplier
                                where (Sup.Name.Contains(textBox1.Text))
                                select new
                                {
                                    ID = Sup.ID,
                                    Name = Sup.Name,
                                    Address = Sup.Address
                                }).Take(30).OrderBy(t => t.Name).ToList();

                    dataGridView1.DataSource = list;
                    var list2 = (from b in FsDb.Tbl_Beneficiary
                                 where (b.Name.Contains(textBox1.Text) && b.BeneficiaryKind_ID == 2 && b.Parent_ID == null)
                                 join bk in FsDb.Tbl_BeneficiaryKind on b.BeneficiaryKind_ID equals bk.ID
                                 select new { ID = b.ID, Name = b.Name, kindName = bk.Name }).ToList();
                    //dataGridView2.DataSource = list2;
                    dataGridView2.Visible = true;
                    dataGridView2.DataSource = list2;
                    dataGridView2.Columns["ID"].Visible = false;
                    dataGridView1.DataSource = list;
                    dataGridView1.Columns["ID"].Visible = false;
                    //dataGridView1.Columns["Tbl_Handler"].Visible = false;
                }
                else if (BenfId == 3)
                {
                    RelativeBenKindCmb.Visible = false;
                    groupBox7.Visible = false;
                    var list = (from Cust in FsDb.Tbl_Customer
                                where (Cust.Name.Contains(textBox1.Text))
                                select new
                                {
                                    ID = Cust.ID,
                                    Name = Cust.Name,
                                    Address = Cust.Address
                                }).Take(30).OrderBy(t => t.Name).ToList();
                    dataGridView2.Visible = true;
                    var list2 = (from b in FsDb.Tbl_Beneficiary
                                 where (b.Name.Contains(textBox1.Text) && b.BeneficiaryKind_ID == 3 && b.Parent_ID == null)
                                 join bk in FsDb.Tbl_BeneficiaryKind on b.BeneficiaryKind_ID equals bk.ID
                                 select new { ID = b.ID, Name = b.Name, kindName = bk.Name }).ToList();
                    dataGridView2.DataSource = list2;
                    dataGridView2.Columns["ID"].Visible = false;
                    dataGridView1.DataSource = list;
                    dataGridView1.Columns["ID"].Visible = false;
                    //dataGridView1.Columns["Tbl_Handler"].Visible = false;
                }
                else if (BenfId == 4)
                {
                    RelativeBenKindCmb.Visible = false;
                    groupBox7.Visible = false;
                    var list = (from MNG in FsDb.Tbl_Management
                                where (MNG.Name.Contains(textBox1.Text) && (MNG.Parent_ID == null || MNG.Parent_ID == 1 || MNG.Parent_ID == 2 || MNG.Parent_ID == 100054 || MNG.Parent_ID == 3055 && MNG.Management_ID != 18))
                                select new
                                {
                                    ID = MNG.ID,
                                    Name = MNG.Name

                                }).Take(30).OrderBy(t => t.Name).ToList();
                    dataGridView2.Visible = true;
                    var list2 = (from b in FsDb.Tbl_Beneficiary
                                 where (b.Name.Contains(textBox1.Text) && b.BeneficiaryKind_ID == 4 && b.Parent_ID == null)
                                 join bk in FsDb.Tbl_BeneficiaryKind on b.BeneficiaryKind_ID equals bk.ID
                                 select new { ID = b.ID, Name = b.Name, kindName = bk.Name }).ToList();
                    dataGridView2.DataSource = list2;
                    dataGridView2.Columns["ID"].Visible = false;
                    dataGridView1.DataSource = list;
                    dataGridView1.Columns["ID"].Visible = false;
                    //dataGridView1.Columns["Tbl_Handler"].Visible = false;
                }
                else if (BenfId == 5)
                {
                    RelativeBenKindCmb.Visible = false;
                    groupBox7.Visible = false;
                    var list = (from bnf in FsDb.Tbl_Beneficiary
                                where (bnf.Name.Contains(textBox1.Text) && bnf.BeneficiaryKind_ID == 5)
                                select new
                                {
                                    ID = bnf.ID,
                                    Name = bnf.Name

                                }).Take(30).OrderBy(t => t.Name).ToList();
                    dataGridView2.Visible = true;
                    var list2 = (from b in FsDb.Tbl_Beneficiary
                                 where (b.Name.Contains(textBox1.Text) && b.BeneficiaryKind_ID == 5 && b.Parent_ID == null)
                                 join bk in FsDb.Tbl_BeneficiaryKind on b.BeneficiaryKind_ID equals bk.ID
                                 select new { ID = b.ID, Name = b.Name, kindName = bk.Name }).ToList();
                    dataGridView2.DataSource = list2;
                    dataGridView2.Columns["ID"].Visible = false;
                    dataGridView1.DataSource = list;
                    dataGridView1.Columns["ID"].Visible = false;
                    //dataGridView1.Columns["Tbl_Handler"].Visible = false;
                }
                else if (BenfId == 7)
                {
                    RelativeBenKindCmb.Visible = false;
                    groupBox7.Visible = false;
                    var list = (from bnk in FsDb.Tbl_Banks
                                where (bnk.Name.Contains(textBox1.Text))
                                select new
                                {
                                    ID = bnk.ID,
                                    Name = bnk.Name

                                }).Take(30).OrderBy(t => t.Name).ToList();
                    dataGridView2.Visible = true;
                    var list2 = (from b in FsDb.Tbl_Beneficiary
                                 where (b.Name.Contains(textBox1.Text) && b.BeneficiaryKind_ID == 7 && b.Parent_ID == null)
                                 join bk in FsDb.Tbl_BeneficiaryKind on b.BeneficiaryKind_ID equals bk.ID
                                 select new { ID = b.ID, Name = b.Name, kindName = bk.Name }).ToList();
                    dataGridView2.DataSource = list2;
                    dataGridView2.Columns["ID"].Visible = false;
                    dataGridView1.DataSource = list;
                    dataGridView1.Columns["ID"].Visible = false;
                    //dataGridView1.Columns["Tbl_Handler"].Visible = false;
                }
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBox1.SelectedValue != null)
                {
                    int BenfId = int.Parse(comboBox1.SelectedValue.ToString());
                    if (BenfId == 1)

                    {
                        txtEmp.Text = "";
                        txtSup.Text = "";
                        txtCust.Text = "";
                        TxtMng.Text = "";
                        TxtBnk.Text = "";

                        int Xid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        txtEmp.Text = Xid.ToString();
                        var resultEmp = FsDb.Tbl_Employee.SingleOrDefault(x => x.ID == Xid);
                        textBox1.Text = resultEmp.Name;

                        var resultBenf = FsDb.Tbl_Beneficiary.SingleOrDefault(x => x.ID_Emp == Xid);
                        if (resultBenf == null)
                        {
                            textBox2.Text = "";

                        }
                        else
                        {
                            textBox2.Text = resultBenf.ID.ToString();
                        }

                    }
                    else if (BenfId == 2)
                    {

                        txtEmp.Text = "";
                        txtSup.Text = "";
                        txtCust.Text = "";
                        TxtMng.Text = "";
                        TxtBnk.Text = "";
                        int Xid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        txtSup.Text = Xid.ToString();
                        var resultSup = FsDb.Tbl_Supplier.FirstOrDefault(x => x.ID == Xid);
                        textBox1.Text = resultSup.Name;


                        var resultBenf = FsDb.Tbl_Beneficiary.FirstOrDefault(x => x.ID_Supp == Xid);
                        if (resultBenf == null)
                        {
                            textBox2.Text = "";

                        }
                        else
                        {
                            textBox2.Text = resultBenf.ID.ToString();
                        }

                    }
                    else if (BenfId == 3)
                    {

                        txtEmp.Text = "";
                        txtSup.Text = "";
                        txtCust.Text = "";
                        TxtMng.Text = "";
                        TxtBnk.Text = "";

                        int Xid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        txtCust.Text = Xid.ToString();
                        var resultCust = FsDb.Tbl_Customer.SingleOrDefault(x => x.ID == Xid);
                        textBox1.Text = resultCust.Name;

                        var resultBenf = FsDb.Tbl_Beneficiary.SingleOrDefault(x => x.ID_Cust == Xid);
                        if (resultBenf == null)
                        {
                            textBox2.Text = "";

                        }
                        else
                        {
                            textBox2.Text = resultBenf.ID.ToString();
                        }

                    }
                    else if (BenfId == 4)
                    {

                        txtEmp.Text = "";
                        txtSup.Text = "";
                        txtCust.Text = "";
                        TxtMng.Text = "";
                        TxtBnk.Text = "";

                        int Xid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        TxtMng.Text = Xid.ToString();
                        var resultCust = FsDb.Tbl_Management.SingleOrDefault(x => x.ID == Xid);
                        textBox1.Text = resultCust.Name;

                        var resultBenf = FsDb.Tbl_Beneficiary.SingleOrDefault(x => x.ID_Cust == Xid);
                        if (resultBenf == null)
                        {
                            textBox2.Text = "";

                        }
                        else
                        {
                            textBox2.Text = resultBenf.ID.ToString();
                        }

                    }
                    else if (BenfId == 5)
                    {

                        txtEmp.Text = "";
                        txtSup.Text = "";
                        txtCust.Text = "";
                        TxtMng.Text = "";
                        TxtBnk.Text = "";

                        int Xid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        //txtCust.Text = Xid.ToString();
                        var resultBenf = FsDb.Tbl_Beneficiary.SingleOrDefault(x => x.ID == Xid);
                        textBox1.Text = resultBenf.Name;


                        if (resultBenf == null)
                        {
                            textBox2.Text = "";

                        }
                        else
                        {
                            textBox2.Text = resultBenf.ID.ToString();
                        }
                    }
                    else if (BenfId == 7)
                    {

                        txtEmp.Text = "";
                        txtSup.Text = "";
                        txtCust.Text = "";
                        TxtMng.Text = "";
                        TxtBnk.Text = "";

                        int XidBnk = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        TxtBnk.Text = XidBnk.ToString();
                        var resultBenf = FsDb.Tbl_Banks.SingleOrDefault(x => x.ID == XidBnk);
                        textBox1.Text = resultBenf.Name;


                        if (resultBenf == null)
                        {
                            textBox2.Text = "";

                        }
                        else
                        {
                            textBox2.Text = resultBenf.ID.ToString();
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Tab)
            {
                textBox1.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Focus();
            }
            else if (e.KeyCode == Keys.Tab)
            {
                dataGridView1.Focus();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                int BenfId = int.Parse(comboBox1.SelectedValue.ToString());
                if (BenfId == 1)

                {
                    txtEmp.Text = "";
                    txtSup.Text = "";
                    txtCust.Text = "";
                    TxtMng.Text = "";
                    TxtBnk.Text = "";

                    int Xid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    txtEmp.Text = Xid.ToString();
                    var resultEmp = FsDb.Tbl_Employee.SingleOrDefault(x => x.ID == Xid);
                    textBox1.Text = resultEmp.Name;

                    var resultBenf = FsDb.Tbl_Beneficiary.SingleOrDefault(x => x.ID_Emp == Xid);
                    if (resultBenf == null)
                    {
                        textBox2.Text = "";

                    }
                    else
                    {
                        textBox2.Text = resultBenf.ID.ToString();
                    }

                }
                else if (BenfId == 2)
                {

                    txtEmp.Text = "";
                    txtSup.Text = "";
                    txtCust.Text = "";
                    TxtMng.Text = "";
                    TxtBnk.Text = "";
                    int Xid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    txtSup.Text = Xid.ToString();
                    var resultSup = FsDb.Tbl_Supplier.FirstOrDefault(x => x.ID == Xid);
                    textBox1.Text = resultSup.Name;


                    var resultBenf = FsDb.Tbl_Beneficiary.FirstOrDefault(x => x.ID_Supp == Xid);
                    if (resultBenf == null)
                    {
                        textBox2.Text = "";

                    }
                    else
                    {
                        textBox2.Text = resultBenf.ID.ToString();
                    }

                }
                else if (BenfId == 3)
                {

                    txtEmp.Text = "";
                    txtSup.Text = "";
                    txtCust.Text = "";
                    TxtMng.Text = "";
                    TxtBnk.Text = "";

                    int Xid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    txtCust.Text = Xid.ToString();
                    var resultCust = FsDb.Tbl_Customer.SingleOrDefault(x => x.ID == Xid);
                    textBox1.Text = resultCust.Name;

                    var resultBenf = FsDb.Tbl_Beneficiary.SingleOrDefault(x => x.ID_Cust == Xid);
                    if (resultBenf == null)
                    {
                        textBox2.Text = "";

                    }
                    else
                    {
                        textBox2.Text = resultBenf.ID.ToString();
                    }

                }
                else if (BenfId == 4)
                {

                    txtEmp.Text = "";
                    txtSup.Text = "";
                    txtCust.Text = "";
                    TxtMng.Text = "";
                    TxtBnk.Text = "";

                    int Xid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    TxtMng.Text = Xid.ToString();
                    var resultCust = FsDb.Tbl_Management.SingleOrDefault(x => x.ID == Xid);
                    textBox1.Text = resultCust.Name;

                    var resultBenf = FsDb.Tbl_Beneficiary.SingleOrDefault(x => x.ID_Cust == Xid);
                    if (resultBenf == null)
                    {
                        textBox2.Text = "";

                    }
                    else
                    {
                        textBox2.Text = resultBenf.ID.ToString();
                    }

                }
                else if (BenfId == 5)
                {

                    txtEmp.Text = "";
                    txtSup.Text = "";
                    txtCust.Text = "";
                    TxtMng.Text = "";
                    TxtBnk.Text = "";

                    int Xid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    //txtCust.Text = Xid.ToString();
                    var resultBenf = FsDb.Tbl_Beneficiary.SingleOrDefault(x => x.ID == Xid);
                    textBox1.Text = resultBenf.Name;


                    if (resultBenf == null)
                    {
                        textBox2.Text = "";

                    }
                    else
                    {
                        textBox2.Text = resultBenf.ID.ToString();
                    }
                }
                else if (BenfId == 7)
                {

                    txtEmp.Text = "";
                    txtSup.Text = "";
                    txtCust.Text = "";
                    TxtMng.Text = "";
                    TxtBnk.Text = "";

                    int XidBnk = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    TxtBnk.Text = XidBnk.ToString();
                    var resultBenf = FsDb.Tbl_Banks.SingleOrDefault(x => x.ID == XidBnk);
                    textBox1.Text = resultBenf.Name;


                    if (resultBenf == null)
                    {
                        textBox2.Text = "";

                    }
                    else
                    {
                        textBox2.Text = resultBenf.ID.ToString();
                    }
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                BenfId = int.Parse(comboBox1.SelectedValue.ToString());
                if (textBox1.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل اسم المستفيد او قم بإختياره من القائمه ");
                }
                else
                {


                    if (textBox2.Text == "" && IdBRelatedParentTxtBox.Text == "")
                    {
                        var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 4 && w.ProcdureId == 1);
                        if (validationSaveUser != null)
                        {
                            Vint_bnfKindID = int.Parse(comboBox1.SelectedValue.ToString());
                            if (Vint_bnfKindID == 5)
                            {
                                int? XID_Emp = string.IsNullOrEmpty(txtEmp.Text) ? (int?)null : int.Parse(txtEmp.Text);
                                int? XID_Cust = string.IsNullOrEmpty(txtCust.Text) ? (int?)null : int.Parse(txtCust.Text);
                                int? XID_Supp = string.IsNullOrEmpty(txtSup.Text) ? (int?)null : int.Parse(txtSup.Text);
                                int? XID_Mng = string.IsNullOrEmpty(TxtMng.Text) ? (int?)null : int.Parse(TxtMng.Text);
                                int? XID_Bnk = string.IsNullOrEmpty(TxtBnk.Text) ? (int?)null : int.Parse(TxtBnk.Text);

                                if (RelativeBenKindCmb.SelectedValue != null)
                                {
                                    Vint_Relative = int.Parse(RelativeBenKindCmb.SelectedValue.ToString());
                                }
                                Tbl_Beneficiary Benf = new Tbl_Beneficiary
                                {
                                    Name = textBox1.Text,
                                    BeneficiaryKind_ID = BenfId,
                                    ID_Emp = XID_Emp,
                                    ID_Cust = XID_Cust,
                                    ID_Supp = XID_Supp,
                                    ID_Mng = XID_Mng,
                                    ID_Bank = XID_Bnk,
                                    Relative_ID = Vint_Relative

                                };

                                FsDb.Tbl_Beneficiary.Add(Benf);
                                FsDb.SaveChanges();
                                int Vint_LastRow = Benf.ID;
                                //---------------خفظ ااحداث 
                                SecurityEvent sev = new SecurityEvent
                                {
                                    ActionName = "اضافة مستفيد",
                                    TableName = "Tbl_Beneficiary",
                                    TableRecordId = Vint_LastRow.ToString(),
                                    Description = "",
                                    ManagementName = Program.GlbV_Management,
                                    ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                    EmployeeName = Program.GlbV_EmpName,
                                    User_ID = Program.GlbV_UserId,
                                    UserName = Program.GlbV_UserName,
                                    FormName = "شاشة المستفيدين"


                                };
                                FsEvDb.SecurityEvents.Add(sev);
                                FsEvDb.SaveChanges();
                                //************************************
                                MessageBox.Show("تم الحفظ");

                                textBox1.Text = "";
                                textBox2.Text = "";
                                txtEmp.Text = "";
                                txtSup.Text = "";
                                txtCust.Text = "";
                                TxtMng.Text = "";
                                TxtBnk.Text = "";
                                RelativeBenKindCmb.SelectedIndex = -1;
                                RelativeBenKindCmb.SelectedText = "اختر صلة القرابه";
                                textBox1.Select();
                                this.ActiveControl = textBox1;
                                dataGridView2.Visible = true;
                                var list = (from b in FsDb.Tbl_Beneficiary
                                            join bk in FsDb.Tbl_BeneficiaryKind on b.BeneficiaryKind_ID equals bk.ID
                                            select new { ID = b.ID, Name = b.Name, kindName = bk.Name }).ToList();

                                dataGridView2.DataSource = list;
                                dataGridView2.Columns["Name"].HeaderText = "المستفيد";
                                dataGridView2.Columns["kindName"].HeaderText = "نوع المستفيد";
                                dataGridView2.Columns["ID"].Visible = false;
                                dataGridView2.Columns["Name"].Width = 220;
                                textBox1.Focus();
                            }
                            else if (Vint_bnfKindID == 1)
                            {
                                MessageBox.Show("برجاء ادخال البيانات من خلال شاشة الموظفين");
                            }
                            else if (Vint_bnfKindID == 2)
                            {
                                MessageBox.Show("برجاء ادخال البيانات من خلال شاشة الموردين");
                            }
                            else if (Vint_bnfKindID == 3)
                            {
                                MessageBox.Show("برجاء ادخال البيانات من خلال شاشة عميل");
                            }
                            else if (Vint_bnfKindID == 4)
                            {
                                MessageBox.Show("برجاء ادخال البيانات من خلال شاشة الادارات");
                            }
                            else if (Vint_bnfKindID == 7)
                            {
                                MessageBox.Show("برجاء ادخال البيانات من خلال شاشة البنوك");
                            }
                        }
                        else
                        {
                            MessageBox.Show("ليس لديك صلاحية اضافة  مستفيد .. برجاء مراجعة مدير المنظومه");
                        }

                    }
                    else if (textBox2.Text != "" && IdBRelatedParentTxtBox.Text == "")
                    {
                        var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 4 && w.ProcdureId == 3);
                        if (validationSaveUser != null)
                        {
                            Vint_bnfKindID = int.Parse(comboBox1.SelectedValue.ToString());
                            if (Vint_bnfKindID == 5)
                            {
                                int xbenfid = int.Parse(textBox2.Text);
                                var result = FsDb.Tbl_Beneficiary.SingleOrDefault(x => x.ID == xbenfid);
                                result.Name = textBox1.Text;
                                int? XID_Emp = string.IsNullOrEmpty(txtEmp.Text) ? (int?)null : int.Parse(txtEmp.Text);
                                int? XID_Cust = string.IsNullOrEmpty(txtCust.Text) ? (int?)null : int.Parse(txtCust.Text);
                                int? XID_Supp = string.IsNullOrEmpty(txtSup.Text) ? (int?)null : int.Parse(txtSup.Text);
                                int? XID_Mng = string.IsNullOrEmpty(TxtMng.Text) ? (int?)null : int.Parse(TxtMng.Text);
                                int? XID_Bnk = string.IsNullOrEmpty(TxtBnk.Text) ? (int?)null : int.Parse(TxtBnk.Text);
                                result.ID_Emp = XID_Emp;
                                result.ID_Supp = XID_Supp;
                                result.ID_Cust = XID_Cust;
                                result.ID_Mng = XID_Mng;
                                result.ID_Bank = XID_Bnk;
                                if (RelativeBenKindCmb.SelectedValue != null)
                                {
                                    Vint_Relative = int.Parse(RelativeBenKindCmb.SelectedValue.ToString());
                                }
                                result.Relative_ID = Vint_Relative;
                                FsDb.SaveChanges();
                                //---------------خفظ ااحداث 
                                SecurityEvent sev = new SecurityEvent
                                {
                                    ActionName = "تعديل مستفيد",
                                    TableName = "Tbl_Beneficiary",
                                    TableRecordId = result.ID.ToString(),
                                    Description = "",
                                    ManagementName = Program.GlbV_Management,
                                    ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                    EmployeeName = Program.GlbV_EmpName,
                                    User_ID = Program.GlbV_UserId,
                                    UserName = Program.GlbV_UserName,
                                    FormName = "شاشة المستفيدين"


                                };
                                FsEvDb.SecurityEvents.Add(sev);
                                FsEvDb.SaveChanges();
                                //************************************
                                MessageBox.Show("تم التعديل");
                                //dataGridView1.DataSource = FsDb.Tbl_BeneficiaryKind.ToList();
                                textBox1.Text = "";
                                textBox2.Text = "";
                                txtEmp.Text = "";
                                txtSup.Text = "";
                                txtCust.Text = "";
                                TxtMng.Text = "";
                                TxtBnk.Text = "";
                                RelativeBenKindCmb.SelectedIndex = -1;
                                RelativeBenKindCmb.SelectedText = "اختر صلة القرابه";
                                textBox1.Select();
                                this.ActiveControl = textBox1;
                                dataGridView2.Visible = true;
                                var list = (from b in FsDb.Tbl_Beneficiary
                                            join bk in FsDb.Tbl_BeneficiaryKind on b.BeneficiaryKind_ID equals bk.ID
                                            select new { iD = b.ID, Name = b.Name, kindName = bk.Name }).ToList();

                                dataGridView2.DataSource = list;
                                dataGridView2.Columns["Name"].HeaderText = "المستفيد";
                                dataGridView2.Columns["kindName"].HeaderText = "نوع المستفيد";
                                dataGridView2.Columns["ID"].Visible = false;
                                dataGridView2.Columns["Name"].Width = 220;
                                textBox1.Focus();
                            }
                            else if (Vint_bnfKindID == 1)
                            {
                                MessageBox.Show("برجاء ادخال البيانات من خلال شاشة الموظفين");
                            }
                            else if (Vint_bnfKindID == 2)
                            {
                                MessageBox.Show("برجاء ادخال البيانات من خلال شاشة الموردين");
                            }
                            else if (Vint_bnfKindID == 3)
                            {
                                MessageBox.Show("برجاء ادخال البيانات من خلال شاشة عميل");
                            }
                            else if (Vint_bnfKindID == 4)
                            {
                                MessageBox.Show("برجاء ادخال البيانات من خلال شاشة الادارات");
                            }
                            else if (Vint_bnfKindID == 7)
                            {
                                MessageBox.Show("برجاء ادخال البيانات من خلال شاشة البنوك");
                            }
                        }
                        else
                        {
                            MessageBox.Show("ليس لديك صلاحية تعديل  مستفيد .. برجاء مراجعة مدير المنظومه");
                        }

                    }
                    else if (IdBRelatedParentTxtBox.Text != "" && RelatedBoxSrch.Text != "" && IdBRelatedChildTxtBox.Text == "")
                    {
                        var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 4 && w.ProcdureId == 1);
                        if (validationSaveUser != null)
                        {

                            int? XID_Emp = string.IsNullOrEmpty(txtEmp.Text) ? (int?)null : int.Parse(txtEmp.Text);
                            int? XID_Cust = string.IsNullOrEmpty(txtCust.Text) ? (int?)null : int.Parse(txtCust.Text);
                            int? XID_Supp = string.IsNullOrEmpty(txtSup.Text) ? (int?)null : int.Parse(txtSup.Text);
                            int? XID_Mng = string.IsNullOrEmpty(TxtMng.Text) ? (int?)null : int.Parse(TxtMng.Text);
                            int? XID_Bnk = string.IsNullOrEmpty(TxtBnk.Text) ? (int?)null : int.Parse(TxtBnk.Text);
                            if (RelativeBenKindCmb.SelectedValue != null)
                            {
                                Vint_Relative = int.Parse(RelativeBenKindCmb.SelectedValue.ToString());
                            }
                            Tbl_Beneficiary Benf = new Tbl_Beneficiary
                            {
                                Name = RelatedBoxSrch.Text,
                                BeneficiaryKind_ID = BenfId,
                                ID_Emp = XID_Emp,
                                ID_Cust = XID_Cust,
                                ID_Supp = XID_Supp,
                                ID_Mng = XID_Mng,
                                ID_Bank = XID_Bnk,
                                Parent_ID = int.Parse(IdBRelatedParentTxtBox.Text),
                                Relative_ID = Vint_Relative

                            };

                            FsDb.Tbl_Beneficiary.Add(Benf);
                            FsDb.SaveChanges();
                            int Vint_LastRow = Benf.ID;
                            //---------------خفظ ااحداث 
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "اضافة تابع لمستفيد",
                                TableName = "Tbl_Beneficiary",
                                TableRecordId = Vint_LastRow.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "شاشة المستفيدين"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            //************************************
                            MessageBox.Show("تم الحفظ");

                            //textBox1.Text = "";
                            textBox2.Text = "";
                            txtEmp.Text = "";
                            txtSup.Text = "";
                            txtCust.Text = "";
                            TxtMng.Text = "";
                            TxtBnk.Text = "";
                            RelativeBenKindCmb.SelectedIndex = -1;
                            RelativeBenKindCmb.SelectedText = "اختر صلة القرابه";
                            //IdBRelatedParentTxtBox.Text = "";
                            IdBRelatedChildTxtBox.Text = "";
                            RelatedBoxSrch.Text = "";
                            textBox1.Select();
                            this.ActiveControl = textBox1;
                            dataGridView2.Visible = true;
                            var list = (from b in FsDb.Tbl_Beneficiary
                                        join bk in FsDb.Tbl_BeneficiaryKind on b.BeneficiaryKind_ID equals bk.ID
                                        select new { ID = b.ID, Name = b.Name, kindName = bk.Name }).ToList();
                            int Vint_ParentID = int.Parse(IdBRelatedParentTxtBox.Text);
                            dataGridView2.DataSource = list;
                            var list3 = (from b in FsDb.Tbl_Beneficiary
                                         where (b.Parent_ID == Vint_ParentID)

                                         select new { b.ID, b.Name, b.Relative_ID }).ToList();

                            dataGridView3.DataSource = list3;
                            dataGridView2.Columns["Name"].HeaderText = "المستفيد";
                            dataGridView2.Columns["kindName"].HeaderText = "نوع المستفيد";
                            dataGridView2.Columns["Name"].Width = 220;
                            dataGridView2.Columns["ID"].Visible = false;
                            textBox1.Focus();
                        }
                        else
                        {
                            MessageBox.Show("ليس لديك صلاحية اضافة  مستفيد .. برجاء مراجعة مدير المنظومه");
                        }
                    }

                    else if (IdBRelatedParentTxtBox.Text != "" && IdBRelatedChildTxtBox.Text != "" && RelatedBoxSrch.Text != "")
                    {
                        var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 4 && w.ProcdureId == 3);
                        if (validationSaveUser != null)
                        {
                            int xbenfid = int.Parse(IdBRelatedChildTxtBox.Text);

                            var result = FsDb.Tbl_Beneficiary.SingleOrDefault(x => x.ID == xbenfid);
                            result.Name = RelatedBoxSrch.Text;

                            int? XID_Emp = string.IsNullOrEmpty(txtEmp.Text) ? (int?)null : int.Parse(txtEmp.Text);
                            int? XID_Cust = string.IsNullOrEmpty(txtCust.Text) ? (int?)null : int.Parse(txtCust.Text);
                            int? XID_Supp = string.IsNullOrEmpty(txtSup.Text) ? (int?)null : int.Parse(txtSup.Text);
                            int? XID_Mng = string.IsNullOrEmpty(TxtMng.Text) ? (int?)null : int.Parse(TxtMng.Text);
                            int? XID_Bnk = string.IsNullOrEmpty(TxtBnk.Text) ? (int?)null : int.Parse(TxtBnk.Text);
                            if (RelativeBenKindCmb.SelectedValue != null)
                            {
                                Vint_Relative = int.Parse(RelativeBenKindCmb.SelectedValue.ToString());
                            }
                            result.ID_Emp = XID_Emp;
                            result.ID_Supp = XID_Supp;
                            result.ID_Cust = XID_Cust;
                            result.ID_Mng = XID_Mng;
                            result.ID_Bank = XID_Bnk;
                            result.Relative_ID = Vint_Relative;
                            FsDb.SaveChanges();
                            //---------------خفظ ااحداث 
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "تعديل تابع",
                                TableName = "Tbl_Beneficiary",
                                TableRecordId = result.ID.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "شاشة المستفيدين"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            //************************************
                            MessageBox.Show("تم التعديل");
                            //dataGridView1.DataSource = FsDb.Tbl_BeneficiaryKind.ToList();

                            dataGridView2.Visible = true;
                            int Vint_ParentID = int.Parse(IdBRelatedParentTxtBox.Text);
                            var list31 = (from b in FsDb.Tbl_Beneficiary
                                          where (b.Parent_ID == Vint_ParentID)

                                          select new { b.ID, b.Name, b.Relative_ID }).ToList();

                            dataGridView3.DataSource = list31;
                            dataGridView3.Columns["ID"].Visible = false;
                            dataGridView3.Columns["Relative_ID"].Visible = false;
                            dataGridView3.Columns["Name"].Width = 600;
                            dataGridView3.Columns["Name"].HeaderText = "اسماء التابعين";
                            //textBox1.Text = "";
                            textBox2.Text = "";
                            txtEmp.Text = "";
                            txtSup.Text = "";
                            txtCust.Text = "";
                            TxtMng.Text = "";
                            TxtBnk.Text = "";
                            RelativeBenKindCmb.SelectedIndex = -1;
                            RelativeBenKindCmb.SelectedText = "اختر صلة القرابه";
                            //IdBRelatedParentTxtBox.Text = "";
                            IdBRelatedChildTxtBox.Text = "";
                            RelatedBoxSrch.Text = "";
                            textBox1.Select();
                            this.ActiveControl = textBox1;
                            textBox1.Focus();
                        }
                        else
                        {
                            MessageBox.Show("ليس لديك صلاحية تعديل  تابع .. برجاء مراجعة مدير المنظومه");
                        }


                    }
                }
            }
            else
            {
                MessageBox.Show("من فضلك اختر نوع المستفيد");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 4 && w.ProcdureId == 4);
                if (validationSaveUser != null)
                {
                    int xrows = dataGridView2.RowCount;
                    BenfId = 0;
                    if (xrows != 0 && textBox2.Text != "" && IdBRelatedParentTxtBox.Text == "" && IdBRelatedChildTxtBox.Text == "")
                    {
                        var result1 = MessageBox.Show("هل تريد حدف هدا المستفيد  ؟", "حدف مستفيد ", MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.Yes)
                        {

                            BenfId = int.Parse(textBox2.Text);
                            var listrelative = FsDb.Tbl_Beneficiary.Where(x => x.Parent_ID == BenfId).ToList();
                            var listrDocBenf = FsDb.Tbl_DocumentBenefcairy.Where(x => x.Beneficiary_ID == BenfId).ToList();
                            if (listrelative.Count != 0)
                            {
                                MessageBox.Show("لايمكن حذف هذا المستفيد لوجود تابعين له ");
                            }
                            else if (listrDocBenf.Count != 0)
                            {
                                MessageBox.Show("لايمكن حذف هذا المستفيد لوجود مستندات له ");
                            }
                            else
                            {
                                var result = FsDb.Tbl_Beneficiary.Find(BenfId);
                                FsDb.Tbl_Beneficiary.Remove(result);
                                FsDb.SaveChanges();
                                //---------------خفظ ااحداث 
                                SecurityEvent sev = new SecurityEvent
                                {
                                    ActionName = "حذف مستفيد",
                                    TableName = "Tbl_Beneficiary",
                                    TableRecordId = result.ID.ToString(),
                                    Description = "",
                                    ManagementName = Program.GlbV_Management,
                                    ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                    EmployeeName = Program.GlbV_EmpName,
                                    User_ID = Program.GlbV_UserId,
                                    UserName = Program.GlbV_UserName,
                                    FormName = "شاشة المستفيدين"


                                };
                                FsEvDb.SecurityEvents.Add(sev);
                                FsEvDb.SaveChanges();
                                //************************************
                                MessageBox.Show("  تم الحدف");
                            }
                        }

                        dataGridView2.Visible = true;
                        dataGridView2.DataSource = FsDb.Tbl_Beneficiary.ToList();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        txtEmp.Text = "";
                        txtSup.Text = "";
                        txtCust.Text = "";
                        TxtMng.Text = "";
                        TxtBnk.Text = "";
                        RelativeBenKindCmb.SelectedIndex = -1;
                        groupBox5.Text = "التابعين ";
                        RelativeBenKindCmb.SelectedText = "اختر صلة القرابه";
                        IdBRelatedParentTxtBox.Text = "";
                        IdBRelatedChildTxtBox.Text = "";
                        RelatedBoxSrch.Text = "";
                        BenfId = 0;
                        textBox1.Select();
                        this.ActiveControl = textBox1;
                        textBox1.Focus();
                    }
                    else if (xrows != 0 && textBox2.Text != "" && IdBRelatedParentTxtBox.Text != "" && IdBRelatedChildTxtBox.Text == "")
                    {
                        var result1 = MessageBox.Show("هل تريد حدف هدا المستفيد  ؟", "حدف مستفيد ", MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.Yes)
                        {
                            BenfId = int.Parse(textBox2.Text);
                            var listrelative = FsDb.Tbl_Beneficiary.Where(x => x.Parent_ID == BenfId).ToList();
                            var listrDocBenf = FsDb.Tbl_DocumentBenefcairy.Where(x => x.Beneficiary_ID == BenfId).ToList();
                            if (listrelative.Count != 0)
                            {
                                MessageBox.Show("لايمكن حذف هذا المستفيد لوجود تابعين له ");
                            }
                            else if (listrDocBenf.Count != 0)
                            {
                                MessageBox.Show("لايمكن حذف هذا المستفيد لوجود مستندات له ");
                            }
                            else
                            {
                                var result = FsDb.Tbl_Beneficiary.Find(BenfId);
                                FsDb.Tbl_Beneficiary.Remove(result);
                                FsDb.SaveChanges();
                                //---------------خفظ ااحداث 
                                SecurityEvent sev = new SecurityEvent
                                {
                                    ActionName = "حذف مستفيد",
                                    TableName = "Tbl_Beneficiary",
                                    TableRecordId = result.ID.ToString(),
                                    Description = "",
                                    ManagementName = Program.GlbV_Management,
                                    ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                    EmployeeName = Program.GlbV_EmpName,
                                    User_ID = Program.GlbV_UserId,
                                    UserName = Program.GlbV_UserName,
                                    FormName = "شاشة المستفيدين"


                                };
                                FsEvDb.SecurityEvents.Add(sev);
                                FsEvDb.SaveChanges();
                                //************************************
                                MessageBox.Show("  تم الحدف");
                            }
                        }

                        dataGridView2.Visible = true;
                        dataGridView2.DataSource = FsDb.Tbl_Beneficiary.ToList();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        txtEmp.Text = "";
                        txtSup.Text = "";
                        txtCust.Text = "";
                        TxtMng.Text = "";
                        TxtBnk.Text = "";
                        RelativeBenKindCmb.SelectedIndex = -1;
                        groupBox5.Text = "التابعين ";
                        RelativeBenKindCmb.SelectedText = "اختر صلة القرابه";
                        IdBRelatedParentTxtBox.Text = "";
                        IdBRelatedChildTxtBox.Text = "";
                        RelatedBoxSrch.Text = "";
                        BenfId = 0;
                        textBox1.Select();
                        this.ActiveControl = textBox1;
                        textBox1.Focus();
                    }
                    else if (IdBRelatedParentTxtBox.Text != "" && IdBRelatedChildTxtBox.Text != "")
                    {
                        var result1 = MessageBox.Show("هل تريد حدف هدا التابع  ؟", "حدف تابع ", MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.Yes)
                        {
                            int benfReltv = 0;
                            benfReltv = int.Parse(IdBRelatedChildTxtBox.Text);
                            var listrDocBenfreltv = FsDb.Tbl_DocumentBenefcairy.Where(x => x.Beneficiary_ID == benfReltv).ToList();
                            if (listrDocBenfreltv.Count != 0)
                            {
                                MessageBox.Show("لايمكن حذف هذا التابع لوجود مستندات له ");
                            }
                            else
                            {
                                var result = FsDb.Tbl_Beneficiary.Find(benfReltv);
                                FsDb.Tbl_Beneficiary.Remove(result);
                                FsDb.SaveChanges();
                                //---------------خفظ ااحداث 
                                SecurityEvent sev = new SecurityEvent
                                {
                                    ActionName = "حذف تابع",
                                    TableName = "Tbl_Beneficiary",
                                    TableRecordId = result.ID.ToString(),
                                    Description = "",
                                    ManagementName = Program.GlbV_Management,
                                    ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                    EmployeeName = Program.GlbV_EmpName,
                                    User_ID = Program.GlbV_UserId,
                                    UserName = Program.GlbV_UserName,
                                    FormName = "شاشة المستفيدين"


                                };
                                FsEvDb.SecurityEvents.Add(sev);
                                FsEvDb.SaveChanges();
                                //************************************
                                MessageBox.Show("  تم الحدف");
                            }
                        }

                        dataGridView2.Visible = true;
                        dataGridView2.DataSource = FsDb.Tbl_Beneficiary.ToList();
                        dataGridView3.DataSource = FsDb.Tbl_Beneficiary.Where(x => x.Parent_ID != null).ToList();
                        textBox1.Focus();
                    }
                    else
                    {
                        MessageBox.Show("من فضلك حدد المستفيد او التابع المراد حدفه");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        txtEmp.Text = "";
                        txtSup.Text = "";
                        txtCust.Text = "";
                        TxtMng.Text = "";
                        TxtBnk.Text = "";
                        IdBRelatedParentTxtBox.Text = "";
                        IdBRelatedChildTxtBox.Text = "";
                        RelatedBoxSrch.Text = "";
                        RelatedBoxSrch.Text = "";
                        BenfId = 0;
                        textBox1.Select();
                        this.ActiveControl = textBox1;
                        textBox1.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية حذف  مستفيد .. برجاء مراجعة مدير المنظومه");
                }
            }
            catch


            {
                MessageBox.Show("هذا المستفيد لايمكن حذفه لوجود مستندات له", "المنظومة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            groupBox3.Text = "البحث عن مسنفيد";
            textBox1.Text = "";
            textBox2.Text = "";
            txtEmp.Text = "";
            IdBRelatedParentTxtBox.Text = "";
            IdBRelatedChildTxtBox.Text = "";
            RelatedBoxSrch.Text = "";
            RelatedBoxSrch.Text = "";

            int BenfId = int.Parse(comboBox1.SelectedValue.ToString());
            if (BenfId == 1)
            {
                RelativeBenKindCmb.Visible = true;
                groupBox7.Visible = true;
                RelativeBenKindCmb.SelectedIndex = -1;
                RelativeBenKindCmb.Text = "";
                RelativeBenKindCmb.SelectedText = "اختر صلة القرابه";
                var list2 = (from b in FsDb.Tbl_Beneficiary
                             where (b.BeneficiaryKind_ID == 1 && b.Parent_ID == null)
                             join bk in FsDb.Tbl_BeneficiaryKind on b.BeneficiaryKind_ID equals bk.ID
                             select new { ID = b.ID, Name = b.Name, kindName = bk.Name }).ToList();
                dataGridView2.DataSource = list2;
                dataGridView2.Visible = true;
                dataGridView1.DataSource = FsDb.Tbl_Employee.Take(50).OrderBy(x => x.Name).ToList();
                groupBox2.Text = "الموظفين";
                dataGridView1.Columns["Name"].HeaderText = "الموظف";
                dataGridView1.Columns["Workerjob"].HeaderText = "الوظيفه";
                dataGridView1.Columns["NationalId"].Visible = false;
                dataGridView1.Columns["Management_ID"].Visible = false;
                dataGridView1.Columns["GenderID"].Visible = false;
                dataGridView1.Columns["Tbl_User"].Visible = false;
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["Tbl_Beneficiary"].Visible = false;
                dataGridView1.Columns["ID"].Visible = false;
                //dataGridView1.Columns["Tbl_OrderHandler"].Visible = false;
                dataGridView1.Columns["Tbl_User_SysUnites"].Visible = false;
                dataGridView1.Columns["Tbl_Handler"].Visible = false;
                dataGridView1.Columns["Name"].Width = 400;
                textBox1.Visible = true;
            }
            else if (BenfId == 2)
            {
                RelativeBenKindCmb.Visible = false;
                groupBox7.Visible = false;
                var list2 = (from b in FsDb.Tbl_Beneficiary
                             where (b.BeneficiaryKind_ID == 2)
                             join bk in FsDb.Tbl_BeneficiaryKind on b.BeneficiaryKind_ID equals bk.ID
                             select new { ID = b.ID, Name = b.Name, kindName = bk.Name }).ToList();
                dataGridView2.DataSource = list2;
                dataGridView2.Visible = true;
                dataGridView1.DataSource = FsDb.Tbl_Supplier.OrderBy(x => x.Name).ToList();
                groupBox2.Text = "الموردين";
                dataGridView1.Columns["Name"].HeaderText = "المورد";
                dataGridView1.Columns["Email"].Visible = false;
                dataGridView1.Columns["Address"].HeaderText = "العنوان";
                dataGridView1.Columns["SuplierKind"].Visible = false;
                //dataGridView1.Columns["Tbl_Handler"].Visible = false;
                dataGridView1.Columns["Phone"].Visible = false;
                dataGridView1.Columns["Tax_Card"].Visible = false;
                dataGridView1.Columns["Tax_FileNo"].Visible = false;
                dataGridView1.Columns["TaxAuthority_ID"].Visible = false;
                dataGridView1.Columns["Tbl_Beneficiary"].Visible = false;
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["Tbl_TaxAuthority"].Visible = false;
                dataGridView1.Columns["Name"].Width = 250;
                dataGridView1.Columns["Address"].Width = 300;
                textBox1.Visible = true;
                dataGridView2.Visible = true;
            }
            else if (BenfId == 3)
            {
                RelativeBenKindCmb.Visible = false;
                groupBox7.Visible = false;
                var list2 = (from b in FsDb.Tbl_Beneficiary
                             where (b.BeneficiaryKind_ID == 3)
                             join bk in FsDb.Tbl_BeneficiaryKind on b.BeneficiaryKind_ID equals bk.ID
                             select new { ID = b.ID, Name = b.Name, kindName = bk.Name }).ToList();
                dataGridView2.DataSource = list2;
                dataGridView1.DataSource = FsDb.Tbl_Customer.OrderBy(x => x.Name).ToList();
                groupBox2.Text = "العملاء";
                dataGridView1.Columns["Email"].Visible = false;
                dataGridView1.Columns["Name"].HeaderText = "العميل";
                dataGridView1.Columns["Address"].HeaderText = "العنوان";
                dataGridView1.Columns["Phone"].Visible = false;
                dataGridView1.Columns["Tax_Card"].Visible = false;
                dataGridView1.Columns["Trade_Record"].Visible = false;
                //dataGridView1.Columns["TaxAuthority_ID"].Visible = false;
                dataGridView1.Columns["Tbl_Beneficiary"].Visible = false;
                dataGridView1.Columns["ID"].Visible = false;
                //dataGridView1.Columns["Tbl_TaxAuthority"].Visible = false;
                dataGridView1.Columns["Name"].Width = 250;
                dataGridView1.Columns["Address"].Width = 300;
                textBox1.Visible = true;
                dataGridView2.Visible = true;
            }
            else if (BenfId == 4)
            {
                RelativeBenKindCmb.Visible = false;
                groupBox7.Visible = false;
                var list2 = (from b in FsDb.Tbl_Beneficiary
                             where (b.BeneficiaryKind_ID == 4)
                             join bk in FsDb.Tbl_BeneficiaryKind on b.BeneficiaryKind_ID equals bk.ID
                             select new { ID = b.ID, Name = b.Name, kindName = bk.Name }).ToList();
                dataGridView2.DataSource = list2;
                dataGridView1.DataSource = FsDb.Tbl_Management.Where(x => x.Parent_ID == null || x.Parent_ID == 1 || x.Parent_ID == 2 || x.Parent_ID == 100054 || x.Parent_ID == 3055 && x.Management_ID != 18).OrderBy(x => x.Name).ToList();
                groupBox2.Text = "الادارات";
                textBox2.Text = "";
                dataGridView1.Columns["Name"].HeaderText = "الادارة";

                dataGridView1.Columns["Management_ID"].Visible = false;
                dataGridView1.Columns["ExchangeCenter_ID"].Visible = false;
                dataGridView1.Columns["Parent_ID"].Visible = false;
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["Tbl_ManagementCategory"].Visible = false;
                dataGridView1.Columns["ManagementCategory_ID"].Visible = false;
                dataGridView1.Columns["Tbl_ManagementCategory"].Visible = false;
                dataGridView1.Columns["Tbl_ExchangeCenter"].Visible = false;
                dataGridView1.Columns["TBL_Document"].Visible = false;
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["Name"].Width = 250;
                //dataGridView1.Columns["Address"].Width = 300;
                textBox1.Visible = true;
                dataGridView2.Visible = true;
            }
            else if (BenfId == 5)
            {
                RelativeBenKindCmb.Visible = false;
                groupBox7.Visible = false;
                var list2 = (from b in FsDb.Tbl_Beneficiary
                             where (b.BeneficiaryKind_ID == 5)
                             join bk in FsDb.Tbl_BeneficiaryKind on b.BeneficiaryKind_ID equals bk.ID
                             select new { ID = b.ID, Name = b.Name, kindName = bk.Name }).ToList();
                dataGridView2.DataSource = list2;
                dataGridView1.DataSource = FsDb.Tbl_Beneficiary.Where(d => d.BeneficiaryKind_ID == 5).OrderBy(x => x.Name).ToList(); ;
                dataGridView2.Visible = false;
                textBox2.Text = "";
                groupBox2.Text = "اخرى";
                dataGridView1.Columns["Name"].HeaderText = "المستفيد";
                dataGridView1.Columns["BeneficiaryKind_ID"].Visible = false;
                dataGridView1.Columns["ID_Emp"].Visible = false;
                dataGridView1.Columns["ID_Cust"].Visible = false;
                dataGridView1.Columns["ID_Supp"].Visible = false;
                dataGridView1.Columns["ID_Mng"].Visible = false;
                dataGridView1.Columns["ID_Bank"].Visible = false;

                dataGridView1.Columns["Tbl_IndebtednessBeneficiary"].Visible = false;
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["TBL_Document"].Visible = false;

                dataGridView1.Columns["Parent_ID"].Visible = false;
                dataGridView1.Columns["Tbl_employee"].Visible = false;
                dataGridView1.Columns["Tbl_BeneficiaryKind"].Visible = false;
                dataGridView1.Columns["Tbl_Customer"].Visible = false;
                dataGridView1.Columns["Tbl_Supplier"].Visible = false;
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["Name"].Width = 400;
                textBox1.Visible = true;
                dataGridView2.Visible = true;
            }
            else if (BenfId == 7)
            {
                RelativeBenKindCmb.Visible = false;
                groupBox7.Visible = false;
                var list2 = (from b in FsDb.Tbl_Beneficiary
                             where (b.BeneficiaryKind_ID == 7)
                             join bk in FsDb.Tbl_BeneficiaryKind on b.BeneficiaryKind_ID equals bk.ID
                             select new { ID = b.ID, Name = b.Name, kindName = bk.Name }).ToList();
                dataGridView2.DataSource = list2;
                dataGridView1.DataSource = FsDb.Tbl_Banks.OrderBy(x => x.Name).ToList();
                dataGridView2.Visible = false;
                textBox2.Text = "";
                groupBox2.Text = "بنك";
                dataGridView1.Columns["Name"].HeaderText = "البنك";
                dataGridView1.Columns["Parent_ID"].Visible = false;
                dataGridView1.Columns["AccountBanking_NO"].Visible = false;
                dataGridView1.Columns["IBanBanking_NO"].Visible = false;
                dataGridView1.Columns["Accounting_GuidID"].Visible = false;
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["Name"].Width = 400;
                textBox1.Visible = true;
                dataGridView2.Visible = true;
            }

        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            IdBRelatedChildTxtBox.Text = "";
            IdBRelatedParentTxtBox.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            groupBox5.Text = " التابعون لــ " + "  " + dataGridView2.CurrentRow.Cells[2].Value.ToString() + " " + dataGridView2.CurrentRow.Cells[1].Value.ToString();
            Vint_ParentID = int.Parse(IdBRelatedParentTxtBox.Text);
            textBox1.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = IdBRelatedParentTxtBox.Text;
            var list3 = (from b in FsDb.Tbl_Beneficiary
                         where (b.Parent_ID == Vint_ParentID)

                         select new { b.ID, b.Name, b.Relative_ID }).ToList();

            dataGridView3.DataSource = list3;
            dataGridView3.Columns["ID"].Visible = false;
            dataGridView3.Columns["Relative_ID"].Visible = false;
            dataGridView3.Columns["Name"].Width = 600;
            dataGridView3.Columns["Name"].HeaderText = "اسماء التابعين";
            RelatedBoxSrch.Focus();
        }

        private void dataGridView3_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView3.RowCount != 0)
            {
                IdBRelatedChildTxtBox.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                RelatedBoxSrch.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                IdBRelatedParentTxtBox.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
                if (dataGridView3.CurrentRow.Cells[3].Value != null)
                {
                    Vint_Relative = int.Parse(dataGridView3.CurrentRow.Cells[3].Value.ToString());
                    RelativeBenKindCmb.SelectedValue = Vint_Relative;
                }
                int Vint_parentId = int.Parse(IdBRelatedParentTxtBox.Text);
                var list2 = (from b in FsDb.Tbl_Beneficiary
                             where (b.ID == Vint_parentId)
                             join bk in FsDb.Tbl_BeneficiaryKind on b.BeneficiaryKind_ID equals bk.ID
                             select new { ID = b.ID, Name = b.Name, kindName = bk.Name, b.BeneficiaryKind_ID }).ToList();
                dataGridView2.DataSource = list2;
                var listb = FsDb.Tbl_Beneficiary.FirstOrDefault(x => x.ID == Vint_parentId);
                comboBox1.SelectedValue = listb.BeneficiaryKind_ID;

                textBox1.Text = listb.Name;
            }
        }

        private void RelatedBoxSrch_TextChanged(object sender, EventArgs e)
        {
            if (RelatedBoxSrch.Text == "")
            {
                IdBRelatedChildTxtBox.Text = "";
                var list3 = (from b in FsDb.Tbl_Beneficiary
                             where (b.Parent_ID != null)
                             select new { b.ID, b.Name, b.Parent_ID, b.Relative_ID }).ToList();

                //dataGridView3.DataSource = list3;
                //dataGridView3.Columns["ID"].Visible = false;
                //dataGridView3.Columns["Relative_ID"].Visible = false;
                //dataGridView3.Columns["Parent_ID"].Visible = false;
                //dataGridView3.Columns["Name"].Width = 600;
                //dataGridView3.Columns["Name"].HeaderText = "اسماء التابعين";
            }
            else
            {
                var list3 = (from b in FsDb.Tbl_Beneficiary
                             where (b.Name.Contains(RelatedBoxSrch.Text) && b.Parent_ID != null)
                             select new { b.ID, b.Name, b.Parent_ID, b.Relative_ID }).ToList();

                dataGridView3.DataSource = list3;
                dataGridView3.Columns["ID"].Visible = false;
                dataGridView3.Columns["Relative_ID"].Visible = false;
                dataGridView3.Columns["Parent_ID"].Visible = false;
                dataGridView3.Columns["Name"].Width = 600;
                dataGridView3.Columns["Name"].HeaderText = "اسماء التابعين";
            }
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                IdBRelatedChildTxtBox.Text = "";
                IdBRelatedParentTxtBox.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                groupBox5.Text = " التابعون لــ " + "  " + dataGridView2.CurrentRow.Cells[2].Value.ToString() + " " + dataGridView2.CurrentRow.Cells[1].Value.ToString();
                int Vint_ParentID = int.Parse(IdBRelatedParentTxtBox.Text);
                textBox1.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = IdBRelatedParentTxtBox.Text;
                var list3 = (from b in FsDb.Tbl_Beneficiary
                             where (b.Parent_ID == Vint_ParentID)

                             select new { b.ID, b.Name, b.Relative_ID }).ToList();

                dataGridView3.DataSource = list3;
                dataGridView3.Columns["ID"].Visible = false;
                dataGridView3.Columns["Relative_ID"].Visible = false;
                dataGridView3.Columns["Name"].Width = 600;
                dataGridView3.Columns["Name"].HeaderText = "اسماء التابعين";
                RelatedBoxSrch.Focus();
            }
        }

        private void RelatedBoxSrch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RelativeBenKindCmb.Focus();
            }
        }

        private void RelativeBenKindCmb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
        }

        private void RelativeBenKindCmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Vint_ParentID = int.Parse(IdBRelatedParentTxtBox.Text);
            var listEmp = (from bnf in FsDb.Tbl_Beneficiary
                           join emp in FsDb.Tbl_Employee on bnf.ID_Emp equals emp.ID
                           where (bnf.ID == Vint_ParentID)
                           select new
                           {
                               GndrBnf = emp.GenderID
                           }).Distinct().ToList();
            if ((int.Parse(RelativeBenKindCmb.SelectedValue.ToString()) == 1 || int.Parse(RelativeBenKindCmb.SelectedValue.ToString()) == 2) && listEmp[0].GndrBnf == 1)
            {
                RelatedBoxSrch.Text = RelatedBoxSrch.Text;
                RelatedBoxSrch.Text = RelatedBoxSrch.Text + " " + textBox1.Text;
            }
            else if (int.Parse(RelativeBenKindCmb.SelectedValue.ToString()) == 4)
            {
                RelatedBoxSrch.Text = RelatedBoxSrch.Text;
                var Vstr_Parent = (textBox1.Text).Split(new char[] { ' ' });
                int index_to = (textBox1.Text).LastIndexOf(' ');
                int index_of = (textBox1.Text).IndexOf(' ');

                RelatedBoxSrch.Text = (textBox1.Text).Substring(index_of);
            }
            else if (int.Parse(RelativeBenKindCmb.SelectedValue.ToString()) == 6 || int.Parse(RelativeBenKindCmb.SelectedValue.ToString()) == 7)
            {

                var Vstr_Parent = (textBox1.Text).Split(new char[] { ' ' });
                int index_to = (textBox1.Text).LastIndexOf(' ');
                int index_of = (textBox1.Text).IndexOf(' ');

                RelatedBoxSrch.Text = RelatedBoxSrch.Text + " " + (textBox1.Text).Substring(index_of);

            }
        }
    }
}

