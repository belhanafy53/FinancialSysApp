using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using System.Linq;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Net;
using DevComponents.DotNetBar.Controls;
using AnalogClock.My.Resources;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Diagnostics;
using Infragistics.Win;
using Infragistics.Win.UltraWinToolbars;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using DevExpress.XtraTreeList.Nodes;

namespace FinancialSysApp.Forms.ProcessingForms.SearchRpt
{
    public partial class SearchFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        public SearchFrm()
        {
            InitializeComponent();
        }
        public DataTable getSuplyeCategory()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select * from Tbl_DocumentCategory where Parent_ID is  null Order by ID ASC");
            con.Open();
            com.ExecuteScalar();
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.SelectCommand = com;
            com.ExecuteScalar();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getDay()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select * from Tbl_AccountingRestrictions_Kind where ParentID is Not null Order by ID ASC");
            con.Open();
            com.ExecuteScalar();
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.SelectCommand = com;
            com.ExecuteScalar();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        private void SearchFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Tbl_AccountingRestrictions_Kind' table. You can move, or remove it, as needed.
            this.tbl_AccountingRestrictions_KindTableAdapter.FillByKind(this.dataSet1.Tbl_AccountingRestrictions_Kind);
            // TODO: This line of code loads data into the 'dataSet1.Tbl_Fiscalyear' table. You can move, or remove it, as needed.
            this.tbl_FiscalyearTableAdapter.FillByYear(this.dataSet1.Tbl_Fiscalyear);
            // TODO: This line of code loads data into the 'dataSet1.Tbl_AccountingRestrictionItems' table. You can move, or remove it, as needed.
            //this.tbl_AccountingRestrictionItemsTableAdapter.Fill(this.dataSet1.Tbl_AccountingRestrictionItems);
            // TODO: This line of code loads data into the 'dataSet1.Tbl_SystemUnites' table. You can move, or remove it, as needed.
            this.tbl_SystemUnitesTableAdapter.Fill(this.dataSet1.Tbl_SystemUnites);
            // TODO: This line of code loads data into the 'dataSet1.Tbl_OrderKind' table. You can move, or remove it, as needed.
            this.tbl_OrderKindTableAdapter.Fill(this.dataSet1.Tbl_OrderKind);
            radDateTimePicker1.Value= dateTimePicker1.Value  ;

            comboBox7.DataSource = getSuplyeCategory();
            comboBox7.DisplayMember = "Name";
            comboBox7.ValueMember = "ID";
            comboBox7.SelectedValue = -1;
            comboBox1.DataSource = getDay();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            comboBox1.SelectedValue = -1;
            comboBox4.DataSource = getDay();
            comboBox4.DisplayMember = "Name";
            comboBox4.ValueMember = "ID";
            comboBox4.SelectedValue = -1;
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_AccountingRestrictionItems' table. You can move, or remove it, as needed.
            Order.SelectedIndex = -1;
            //string hostName = Dns.GetHostName();
            comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = -1;
            }
            radDateTimePicker1.Select();
            this.ActiveControl = radDateTimePicker1;
            radDateTimePicker1.Focus();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                int? ComID = int.Parse(comboBox5.SelectedValue.ToString());
                var list = (from usr in FsDb.Tbl_User
                            join emp in FsDb.Tbl_Employee on usr.Employee_id equals emp.ID
                            join us in FsDb.Tbl_User_SysUnites on usr.Employee_id equals us.Emp_ID

                            where (us.SysUnites_ID == ComID && us.SysUnite_StatusID == 1)
                            select new
                            {
                                ID = usr.ID,
                                Name = usr.Tbl_Employee.Name,
                                //UserType_ID = usr.UserType_ID,
                                //EmployeeName = usr.Tbl_Employee.Name,
                                //Employee_id = usr.Tbl_Employee.ID,
                                //UserSysUnit = us.Tbl_SystemUnites.Name,
                                //UserSysunitID = us.Tbl_SystemUnites.ID,
                                //UserType = usr.Tbl_UserType.Name,
                                //UserImage = usr.ImagePath,
                                //UserFDate = us.From_Date,
                                //UserTDate = us.To_Date,
                                //UserStatus_ID = usr.UserStatus_ID

                            }).ToList();

                comboBox6.DataSource = list;
                comboBox6.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
                comboBox6.AutoCompleteSource = AutoCompleteSource.ListItems;

                comboBox6.DisplayMember = "Name";
                comboBox6.ValueMember = "ID";
                if (comboBox6.Items.Count > 0)
                {
                    comboBox6.SelectedIndex = -1;
                }
            }
            catch
            {

            }
        }

        private void Descp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down )
            {
                try
                {
                    FindCatregory f = new FindCatregory();
                    f.ShowDialog();
                    Descp.Text = FindCatregory.SelectedRow.Cells[1].Value.ToString();

                }
                catch { }
            }
        }

        private void comboBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                try
                {
                    FindUsefl f = new FindUsefl();
                    f.ShowDialog();
                    f.label1.Text = "R";
                    comboBox8.Text = FindUsefl.SelectedRow.Cells[1].Value.ToString();
                    textBox1.Text = FindUsefl.SelectedRow.Cells[0].Value.ToString();

                }
                catch { }
                

            }
        }

        private void UsFul_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down )
            {
                try
                {
                    FindUsefl f = new FindUsefl();
                    f.ShowDialog();
                    f.label1.Text = "R";
                    UsFul.Text = FindUsefl.SelectedRow.Cells[1].Value.ToString();
                    textBox1.Text = FindUsefl.SelectedRow.Cells[0].Value.ToString();
                    this.tbl_BeneficiaryTableAdapter.FillParenID(this.dataSet1.Tbl_Beneficiary, Convert.ToInt32(textBox1.Text));
                }
                catch { }

            }
        }
        public DataTable GetSearchDate()
        {
            
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            int Vint_TreelistCount = treeList1.Nodes.Count();
            List<TreeListNode> nodes = treeList1.GetNodeList();

            foreach (TreeListNode item in nodes)
            {
                if (item.CheckState == CheckState.Checked)
                {
                    int Vint_MenuPr = int.Parse(item.GetValue("ID").ToString());
                    string VStr_MenuPr = item.GetValue("Name").ToString();
                    com.Parameters.Clear();
                    com.CommandText = ("Insert Into Tbl_FinanctialSearch(Restriction_NO,Restriction_Date,NameOfDay,Account_NO,AccountName,Debit_Value,Credit_Value,Document_NO,NameOfDescription,NameOfBenificary,NameOfKindBenificary,NameOfEx,NameOfOrder,Order_NO,Order_Date,NameOfHandelr,NameOfManagament,NameOfRespon,NameOfCategory)  SELECT      dbo.Tbl_AccountingRestriction.Restriction_NO AS [رقم المستند], dbo.Tbl_AccountingRestriction.Restriction_Date AS [تاريخ المستند], dbo.Tbl_AccountingRestrictions_Kind.Name AS اليومية,   dbo.Tbl_Accounting_Guid.Account_NO AS[رقم الحساب], dbo.Tbl_Accounting_Guid.Name AS الحساب, SUM(DISTINCT dbo.Tbl_AccountingRestrictionItems.Debit_Value) AS مدين,SUM(DISTINCT dbo.Tbl_AccountingRestrictionItems.Credit_Value) AS دائن,   dbo.TBL_Document.Document_NO AS[رقم المراجعة], dbo.Tbl_DocumentCategory.Name AS البيان, dbo.Tbl_Beneficiary.Name AS[اسم المستفيد], dbo.Tbl_BeneficiaryKind.Name AS[نوع المستفيد],  dbo.Tbl_ExchangeCenter.Name AS[مركز الصرف], dbo.Tbl_OrderKind.Name AS[نوع الأمر], dbo.Tbl_Order.Order_NO AS[رقم الأمر], dbo.Tbl_Order.Order_Date AS[تاريخ الأمر], dbo.Tbl_Handler.Name AS المناول,   dbo.Tbl_Management.Name AS الإدارة, dbo.Tbl_ResponspilityCenters.Name AS[مركز المسؤلية], dbo.Tbl_RestrictionItemsCategory.Name AS   التصنيف FROM    dbo.Tbl_BeneficiaryKind RIGHT OUTER JOIN dbo.Tbl_Order INNER JOIN dbo.Tbl_OrderKind ON dbo.Tbl_Order.OrderKind_ID = dbo.Tbl_OrderKind.ID RIGHT OUTER JOIN dbo.Tbl_Handler RIGHT OUTER JOIN dbo.Tbl_Beneficiary INNER JOIN dbo.Tbl_DocumentBenefcairy ON dbo.Tbl_Beneficiary.ID = dbo.Tbl_DocumentBenefcairy.Beneficiary_ID RIGHT OUTER JOIN dbo.TBL_Document INNER JOIN dbo.Tbl_AccountingRestriction ON dbo.TBL_Document.ID = dbo.Tbl_AccountingRestriction.Document_ID ON dbo.Tbl_DocumentBenefcairy.Document_ID = dbo.TBL_Document.ID LEFT OUTER JOIN dbo.Tbl_AccountingRestrictionItems INNER JOIN dbo.Tbl_Accounting_Guid ON dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID INNER JOIN  dbo.Tbl_AccountingRestrictions_Kind ON dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID = dbo.Tbl_AccountingRestrictions_Kind.ID ON  dbo.Tbl_AccountingRestriction.ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestriction_ID LEFT OUTER JOIN  dbo.Tbl_RestrictionItemsCategory ON dbo.Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = dbo.Tbl_RestrictionItemsCategory.ID LEFT OUTER JOIN dbo.Tbl_DocumentCategory ON dbo.TBL_Document.DocumentCategory_ID = dbo.Tbl_DocumentCategory.ID LEFT OUTER JOIN  dbo.Tbl_ResponspilityCenters ON dbo.TBL_Document.responspilityID = dbo.Tbl_ResponspilityCenters.ID LEFT OUTER JOIN dbo.Tbl_Management ON dbo.TBL_Document.Management_ID = dbo.Tbl_Management.ID ON dbo.Tbl_Handler.ID = dbo.TBL_Document.Handler_ID ON dbo.Tbl_Order.ID = dbo.TBL_Document.Order_ID ON dbo.Tbl_BeneficiaryKind.ID = dbo.Tbl_Beneficiary.BeneficiaryKind_ID LEFT OUTER JOIN dbo.Tbl_ExchangeCenter ON dbo.Tbl_Management.ExchangeCenter_ID = dbo.Tbl_ExchangeCenter.ID AND dbo.TBL_Document.ExchangeCenter_ID = dbo.Tbl_ExchangeCenter.ID WHERE(dbo.Tbl_AccountingRestriction.Restriction_Date BETWEEN @P AND @P1) AND(dbo.Tbl_AccountingRestrictions_Kind.ID = @i) And (dbo.Tbl_AccountingRestriction.FYear=@F)GROUP BY dbo.Tbl_AccountingRestriction.Restriction_NO, dbo.Tbl_AccountingRestriction.Restriction_Date, dbo.Tbl_AccountingRestrictions_Kind.Name, dbo.Tbl_Accounting_Guid.Account_NO, dbo.Tbl_Accounting_Guid.Name,   dbo.TBL_Document.Document_NO, dbo.Tbl_DocumentCategory.Name, dbo.Tbl_Beneficiary.Name, dbo.Tbl_BeneficiaryKind.Name, dbo.Tbl_ExchangeCenter.Name, dbo.Tbl_OrderKind.Name, dbo.Tbl_Order.Order_NO,  dbo.Tbl_Order.Order_Date, dbo.Tbl_Handler.Name, dbo.Tbl_Management.Name, dbo.Tbl_ResponspilityCenters.Name, dbo.Tbl_RestrictionItemsCategory.Name ORDER BY[تاريخ المستند], [رقم المستند] ");
                    com.Parameters.Add("@P", SqlDbType.Date).Value = radDateTimePicker1.Value;
                    com.Parameters.Add("@P1", SqlDbType.Date).Value = radDateTimePicker2.Value;
                    com.Parameters.Add("@i", SqlDbType.NVarChar).Value = Vint_MenuPr;
                    com.Parameters.Add("@F", SqlDbType.NVarChar).Value = comboBox9.SelectedValue; ;
                    con.Open();
                    da.SelectCommand = com;
                    com.ExecuteScalar();
                    da.Fill(dt);
                   
                   
                    //com.ExecuteScalar();
                    con.Close();
                }
            }
           
            return dt;

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //try
            //{

            if(Descp.Text !=string.Empty )
            {
                comboBox7.Text = string.Empty;
            }

                if (comboBox7.Text == string.Empty)
                {
                dataGridView1.Visible = true;
                dataGridView3.Visible = false;
                TCount.Visible = false;
                //this.tbl_AccountingRestrictionItemsTableAdapter.FillByDescR(this.dataSet1.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), Descp.Text);
                //foreach(var itemCheck in checkedListBoxControl1.CheckedItems)
                //{
                //    var row = (itemCheck as DataRowView);
                dataGridView1.DataSource = GetSearchDate();

                //this.tbl_AccountingRestrictionItemsTableAdapter.FillByDescR(this.dataSet1.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), Convert.ToInt32(checkedListBoxControl1.CheckedItems), Descp.Text);
                //    continue;
                //}
                //int Vint_TreelistCount = treeList1.Nodes.Count();
                //List<TreeListNode> nodes = treeList1.GetNodeList();

                //    foreach (TreeListNode item in nodes)
                //{
                //    if (item.CheckState == CheckState.Checked )
                //    {
                //        int Vint_MenuPr = int.Parse(item.GetValue("ID").ToString());
                //        string VStr_MenuPr = item.GetValue("Name").ToString();
                //        this.tbl_AccountingRestrictionItemsTableAdapter.FillByDescR(this.dataSet1.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), Vint_MenuPr, Descp.Text);
                //    }
                //}
                //    for (int x = 0; x < checkedListBoxControl1.CheckedItems.Count; x++)
                //{
                //    this.tbl_AccountingRestrictionItemsTableAdapter.FillByDescR(this.dataSet1.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), Convert.ToInt32(checkedListBoxControl1.CheckedItems[x]), Descp.Text);
                //}
                textBox2.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[5].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum().ToString();
                textBox3.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[6].FormattedValue.ToString() != string.Empty
                           select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
            }
                if (comboBox7.Text != string.Empty)
                {
                dataGridView1.Visible = true;
                dataGridView3.Visible = false;
                TCount.Visible = false;
                this.tbl_AccountingRestrictionItemsTableAdapter.FillBydESC_pARINT_iD(this.dataSet1.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), Convert.ToInt32(comboBox7.SelectedValue));
                textBox2.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[5].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum().ToString();
                textBox3.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[6].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
            }

            //}
            //catch
            //{


            //    MessageBox.Show("الرجاء تأكد من إختيار اليومية و مجموعة البيان بشكل صحيح");
            //}


            //finally
            //{
            //    if (comboBox7.Text == string.Empty)
            //    {
            //        this.tbl_AccountingRestrictionItemsTableAdapter.FillByDescR(this.dataSet1.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), Descp.Text);
            //    }
            //    if (comboBox7.Text != string.Empty)
            //    {
            //        this.tbl_AccountingRestrictionItemsTableAdapter.FillBydESC_pARINT_iD(this.dataSet1.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), Convert.ToInt32(comboBox7.SelectedValue));
            //    }
            //}
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                SearchRpt.PrintDesc p = new SearchRpt.PrintDesc();
                p.textBox1.Text = "0بيان";
                p.radDateTimePicker1.Text = this.radDateTimePicker1.Value.ToString();
                p.radDateTimePicker2.Text = this.radDateTimePicker2.Value.ToString();
                p.d1.Text = this.comboBox1.SelectedValue.ToString();
                p.d2.Text = this.comboBox4.SelectedValue.ToString();
                p.desc.Text = this.Descp.Text;
                //for (int x = 0; x < checkedListBox1.Items.Count; x++)
                //{
                //    if (checkedListBox1.Items[x].CheckState == CheckState.Checked)
                //        p.checkedListBox1.SetItemChecked(x, true);
                //}
                p.ShowDialog();
            }
            catch
            {
                MessageBox.Show("الرجاء تأكد من إختيار اليومية  بشكل صحيح");
            }
        }

        private void radMenuItem2_Click(object sender, EventArgs e)
        {
            //try
            //{
                SearchRpt.PrintDesc p = new SearchRpt.PrintDesc();
                p.textBox1.Text = "بيان2";
                p.radDateTimePicker1.Text = this.radDateTimePicker1.Value.ToString();
                p.radDateTimePicker2.Text = this.radDateTimePicker2.Value.ToString();
                p.d1.Text = this.comboBox1.SelectedValue.ToString();
                p.d2.Text = this.comboBox4.SelectedValue.ToString();
                p.desc.Text = comboBox7.SelectedValue.ToString();
               
                p.ShowDialog();
            //}
            //catch
            //{
            //    MessageBox.Show("الرجاء تأكد من إختيار اليومية و مجموعة البيان بشكل صحيح");
            //}
        }

        private void radMenuItem3_Click(object sender, EventArgs e)
        {
            //try
            //{
                SearchRpt.PrintDesc p = new SearchRpt.PrintDesc();
                p.textBox1.Text = "بيان";
                p.radDateTimePicker1.Text = this.radDateTimePicker1.Value.ToString();
                p.radDateTimePicker2.Text = this.radDateTimePicker2.Value.ToString();
                p.d1.Text = this.comboBox1.SelectedValue.ToString();
                p.d2.Text = this.comboBox4.SelectedValue.ToString();
                p.desc.Text = this.Descp.Text;
               
                p.ShowDialog();
            //}
            //catch
            //{
            //    MessageBox.Show("الرجاء تأكد من إختيار اليومية  بشكل صحيح");
            //}
        }

        private void radMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                SearchRpt.PrintDesc p = new SearchRpt.PrintDesc();
                p.textBox1.Text = "1بيان";
                p.radDateTimePicker1.Text = this.radDateTimePicker1.Value.ToString();
                p.radDateTimePicker2.Text = this.radDateTimePicker2.Value.ToString();
                p.d1.Text = this.comboBox1.SelectedValue.ToString();
                p.d2.Text = this.comboBox4.SelectedValue.ToString();
                p.desc.Text = this.Descp.Text;
               
                p.ShowDialog();
            }
            catch
            {
                MessageBox.Show("الرجاء تأكد من إختيار اليومية  بشكل صحيح");
            }
        }
       
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Forms.ProcessingForms.Res_Frm f = new Res_Frm();
            if(dataGridView1.CurrentRow.Cells[2].Value.ToString() == "عمليات")
            {
                
                f.comboBox1.Text  = "عمليات";
                f.Restriction_NO.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                f.textBox21.Text = "X";
                f.ShowDialog();
            }
            if (dataGridView1.CurrentRow.Cells[2].Value.ToString() == "مدفوعات")
            {
               
                f.comboBox1.Text = "مدفوعات";
                f.Restriction_NO.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                f.textBox21.Text = "X";
                f.ShowDialog();
            }
            if (dataGridView1.CurrentRow.Cells[2].Value.ToString() == "تسويات - عمليات")
            {

                f.comboBox1.Text = "تسويات - عمليات";
                f.Restriction_NO.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                f.textBox21.Text = "X";
                f.ShowDialog();
            }
            if (dataGridView1.CurrentRow.Cells[2].Value.ToString() == "مقبوضات - نقدي")
            {
                f.comboBox1.Text = "مقبوضات - نقدي";
                
               
                f.Restriction_NO.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                f.textBox21.Text = "X";
                f.ShowDialog();
            }
            if (dataGridView1.CurrentRow.Cells[2].Value.ToString() == "قيد افتتاحي  - ميزانية")
            {
                f.comboBox1.Text = "قيد افتتاحي  - ميزانية";
               
              
                f.Restriction_NO.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                f.textBox21.Text = "X";
                f.ShowDialog();
            }
            if (dataGridView1.CurrentRow.Cells[2].Value.ToString() == "عمليات 30 -6 - استحقاق")
            {
                f.comboBox1.Text = "عمليات 30 -6 - استحقاق";
               
                
               
                f.Restriction_NO.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                f.textBox21.Text = "X";
                f.ShowDialog();
            }
            if (dataGridView1.CurrentRow.Cells[2].Value.ToString() == "ملحق 1 - استحقاق")
            {
                f.comboBox1.Text = "ملحق 1 - استحقاق";
               
               
                f.Restriction_NO.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                f.textBox21.Text = "X";
                f.ShowDialog();
            }
            if (dataGridView1.CurrentRow.Cells[2].Value.ToString() == "ملحق 2 - استحقاق")
            {
                f.comboBox1.Text = "ملحق 2 - استحقاق";
               
               
                f.Restriction_NO.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                f.textBox21.Text = "X";
                f.ShowDialog();
            }
            if (dataGridView1.CurrentRow.Cells[2].Value.ToString() == "ملحق 3 - استحقاق")
            {
                f.comboBox1.Text = "ملحق 3 - استحقاق";
               
               
                f.Restriction_NO.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                f.textBox21.Text = "X";
                f.ShowDialog();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if(comboBox8.Text !=string.Empty )
            {
                dataGridView1.Visible = true;
                dataGridView3.Visible = false;
                TCount.Visible = false;
                this.tbl_AccountingRestrictionItemsTableAdapter.FillByBanaeficaryChild (this.dataSet1.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), comboBox8.Text);
                textBox2.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[5].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum().ToString();
                textBox3.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[6].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
            }
            if (UsFul.Text != string.Empty)
            {
                dataGridView1.Visible = true;
                dataGridView3.Visible = false;
                TCount.Visible = false;
                this.tbl_AccountingRestrictionItemsTableAdapter.FillByBeneficiary(this.dataSet1.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), UsFul.Text, int.Parse(textBox1.Text));
                textBox2.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[5].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum().ToString();
                textBox3.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[6].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
            }
        }

        private void radialMenu1_ItemClick(object sender, EventArgs e)
        {
            
        }

        private void radialMenu1_Click(object sender, EventArgs e)
        {

        }

        private void radMenuItem8_Click(object sender, EventArgs e)
        {
            try
            {
                SearchRpt.PrintDesc p = new SearchRpt.PrintDesc();
                p.textBox1.Text = "مستفيد1";
                p.radDateTimePicker1.Text = this.radDateTimePicker1.Value.ToString();
                p.radDateTimePicker2.Text = this.radDateTimePicker2.Value.ToString();
                p.d1.Text = this.comboBox1.SelectedValue.ToString();
                p.d2.Text = this.comboBox4.SelectedValue.ToString();
                p.desc.Text = this.Descp.Text;
                
                p.ShowDialog();
            }
            catch
            {
                MessageBox.Show("الرجاء تأكد من إختيار اليومية  بشكل صحيح");
            }
        }

        private void radMenuItem7_Click(object sender, EventArgs e)
        {
            try
            {
                SearchRpt.PrintDesc p = new SearchRpt.PrintDesc();
                p.textBox1.Text = "مستفيد";
                p.radDateTimePicker1.Text = this.radDateTimePicker1.Value.ToString();
                p.radDateTimePicker2.Text = this.radDateTimePicker2.Value.ToString();
                p.d1.Text = this.comboBox1.SelectedValue.ToString();
                p.d2.Text = this.comboBox4.SelectedValue.ToString();
                p.desc.Text = this.Descp.Text;

                p.ShowDialog();
            }
            catch
            {
                MessageBox.Show("الرجاء تأكد من إختيار اليومية  بشكل صحيح");
            }
        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            Forms.ProcessingForms.Setaccount_SupplyRpt f = new Setaccount_SupplyRpt();
            f.ShowDialog();
        }

        private void ultraTabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView3.Visible = false;
            TCount.Visible = false;
            this.tbl_AccountingRestrictionItemsTableAdapter.FillByResponspilityCenter(this.dataSet1.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), Respo.Text);
            textBox2.Text = (from DataGridViewRow row in dataGridView1.Rows
                             where row.Cells[5].FormattedValue.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum().ToString();
            textBox3.Text = (from DataGridViewRow row in dataGridView1.Rows
                             where row.Cells[6].FormattedValue.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();

        }

        private void Respo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && Respo.Focus() == true)
            {
                try
                {
                    FindRespo f = new FindRespo();
                    f.ShowDialog();
                    Respo.Text = FindRespo.SelectedRow.Cells[1].Value.ToString();

                }
                catch { }
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && comboBox2.Focus() == true)
            {
                try
                {
                    FindKind f = new FindKind();
                    f.ShowDialog();


                    comboBox2.Text = FindKind.SelectedRow.Cells[1].Value.ToString();
                }
                catch { }

            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView3.Visible = false;
            TCount.Visible = false;
            this.tbl_AccountingRestrictionItemsTableAdapter.FillByResCategory(this.dataSet1.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), comboBox2.Text);
            textBox2.Text = (from DataGridViewRow row in dataGridView1.Rows
                             where row.Cells[5].FormattedValue.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum().ToString();
            textBox3.Text = (from DataGridViewRow row in dataGridView1.Rows
                             where row.Cells[6].FormattedValue.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();

        }

        private void Manag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && Manag.Focus() == true)
            {
                try
                {
                    FindDepart f = new FindDepart();
                    f.ShowDialog();
                    Manag.Text = FindDepart.SelectedRow.Cells[1].Value.ToString();

                }
                catch { }
            }
        }

        private void exCenter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && exCenter.Focus() == true)
            {
                try
                {
                    FindEx f = new FindEx();
                    f.ShowDialog();
                    exCenter.Text = FindEx.SelectedRow.Cells[1].Value.ToString();

                }
                catch { }
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (exCenter.Text != string.Empty)
            {
                dataGridView1.Visible = true;
                dataGridView3.Visible = false;
                TCount.Visible = false;
                this.tbl_AccountingRestrictionItemsTableAdapter.FillByExCenter(this.dataSet1.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), exCenter.Text);
                textBox2.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[5].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum().ToString();
                textBox3.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[6].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
            }
            if (Manag.Text != string.Empty)
            {
                dataGridView1.Visible = true;
                dataGridView3.Visible = false;
                TCount.Visible = false;
                this.tbl_AccountingRestrictionItemsTableAdapter.FillByManagament(this.dataSet1.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), Manag.Text);
                textBox2.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[5].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum().ToString();
                textBox3.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[6].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
            }

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (Order.Text != string.Empty)
            {
                dataGridView1.Visible = true;
                dataGridView3.Visible = false;
                TCount.Visible = false;
                this.tbl_AccountingRestrictionItemsTableAdapter.FillByOrderKind(this.dataSet1.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), Order.Text);
                textBox2.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[5].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum().ToString();
                textBox3.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[6].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
            }
            if (textEdit1.Text != "0")
            {
                dataGridView1.Visible = true;
                dataGridView3.Visible = false;
                TCount.Visible = false;
                this.tbl_AccountingRestrictionItemsTableAdapter.FillByOrderNumber(this.dataSet1.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), textEdit1.Text);
                textBox2.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[5].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum().ToString();
                textBox3.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[6].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
            }
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && comboBox3.Focus() == true)
            {
                try
                {
                    FindAccount f = new FindAccount();
                    f.ShowDialog();
                    comboBox3.Text = FindAccount.SelectedRow.Cells[0].Value.ToString();

                }
                catch { }
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true ;
            dataGridView3.Visible = false ;
            TCount.Visible = false;
            this.tbl_AccountingRestrictionItemsTableAdapter.FillByAccountNumber(this.dataSet1.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), comboBox3.Text);
            textBox2.Text = (from DataGridViewRow row in dataGridView1.Rows
                             where row.Cells[5].FormattedValue.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum().ToString();
            textBox3.Text = (from DataGridViewRow row in dataGridView1.Rows
                             where row.Cells[6].FormattedValue.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();

        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView3.Visible = true ;
            TCount.Visible = true;
            
                this.totalAccRestrByUserTableAdapter.Fill(this.dataSet1.TotalAccRestrByUser, DateTime.Parse(radDateTimePicker1.Value.ToShortDateString()), DateTime.Parse(radDateTimePicker2.Value.ToShortDateString()), int.Parse(comboBox6.SelectedValue.ToString()), 1, 9);
                TCount.Text = dataGridView3.Rows.Count.ToString() + " " + " " + "مستند";
                textBox2.Text = "0";
                textBox3.Text = "0";
            
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ////BindingSource bs = new BindingSource();
                ////bs.DataSource = dataGridView1.DataSource;
                ////bs.Filter = dataGridView1.Columns["البيان"].HeaderText.ToString() + " LIKE '%" + textBox4.Text + "%'";
                ////dataGridView1.DataSource = bs;
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridView1.DataSource;
                bs.Filter = "البيان like '%" + textBox4.Text + "%'";
                dataGridView1.DataSource = bs;
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void treeList1_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            
        }

        private void treeList1_RowClick(object sender, DevExpress.XtraTreeList.RowClickEventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView3.Visible = false;
            dataGridView1.DataSource = GetSearchDate();
            textBox2.Text = (from DataGridViewRow row in dataGridView1.Rows
                             where row.Cells[5].FormattedValue.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum().ToString();
            textBox3.Text = (from DataGridViewRow row in dataGridView1.Rows
                             where row.Cells[6].FormattedValue.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
        }
        public DataTable GetSearchBalance()
        {

            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            int Vint_TreelistCount = treeList1.Nodes.Count();
            List<TreeListNode> nodes = treeList1.GetNodeList();
            
            
            foreach (TreeListNode item in nodes)
            {
                if (item.CheckState == CheckState.Checked)
                {
                    int Vint_MenuPr = int.Parse(item.GetValue("ID").ToString());
                    string VStr_MenuPr = item.GetValue("Name").ToString();
                    com.Parameters.Clear();
                    com.CommandText = ("SELECT        MIN(DISTINCT dbo.Tbl_Accounting_Guid.Account_NO) AS [رقم الحساب], dbo.Tbl_Accounting_Guid.Name AS الحساب, SUM(dbo.Tbl_AccountingRestrictionItems.Debit_Value) AS مدين, SUM(dbo.Tbl_AccountingRestrictionItems.Credit_Value)   AS دائن FROM dbo.Tbl_BeneficiaryKind RIGHT OUTER JOIN dbo.Tbl_Order INNER JOIN dbo.Tbl_OrderKind ON dbo.Tbl_Order.OrderKind_ID = dbo.Tbl_OrderKind.ID RIGHT OUTER JOIN  dbo.Tbl_Handler RIGHT OUTER JOIN  dbo.Tbl_Beneficiary INNER JOIN dbo.Tbl_DocumentBenefcairy ON dbo.Tbl_Beneficiary.ID = dbo.Tbl_DocumentBenefcairy.Beneficiary_ID RIGHT OUTER JOIN dbo.TBL_Document INNER JOIN  dbo.Tbl_AccountingRestriction ON dbo.TBL_Document.ID = dbo.Tbl_AccountingRestriction.Document_ID ON dbo.Tbl_DocumentBenefcairy.Document_ID = dbo.TBL_Document.ID LEFT OUTER JOIN  dbo.Tbl_AccountingRestrictionItems INNER JOIN dbo.Tbl_Accounting_Guid ON dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID INNER JOIN dbo.Tbl_AccountingRestrictions_Kind ON dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID = dbo.Tbl_AccountingRestrictions_Kind.ID ON dbo.Tbl_AccountingRestriction.ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestriction_ID LEFT OUTER JOIN dbo.Tbl_RestrictionItemsCategory ON dbo.Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = dbo.Tbl_RestrictionItemsCategory.ID LEFT OUTER JOIN  dbo.Tbl_DocumentCategory ON dbo.TBL_Document.DocumentCategory_ID = dbo.Tbl_DocumentCategory.ID LEFT OUTER JOIN dbo.Tbl_ResponspilityCenters ON dbo.TBL_Document.responspilityID = dbo.Tbl_ResponspilityCenters.ID LEFT OUTER JOIN dbo.Tbl_Management ON dbo.TBL_Document.Management_ID = dbo.Tbl_Management.ID ON dbo.Tbl_Handler.ID = dbo.TBL_Document.Handler_ID ON dbo.Tbl_Order.ID = dbo.TBL_Document.Order_ID ON dbo.Tbl_BeneficiaryKind.ID = dbo.Tbl_Beneficiary.BeneficiaryKind_ID LEFT OUTER JOIN dbo.Tbl_ExchangeCenter ON dbo.Tbl_Management.ExchangeCenter_ID = dbo.Tbl_ExchangeCenter.ID AND dbo.TBL_Document.ExchangeCenter_ID = dbo.Tbl_ExchangeCenter.ID WHERE(dbo.Tbl_AccountingRestriction.Restriction_Date BETWEEN @P AND @P1) AND(dbo.Tbl_AccountingRestrictions_Kind.ID = @i) And (dbo.Tbl_AccountingRestriction.FYear=@F) GROUP BY dbo.Tbl_Accounting_Guid.Account_NO, dbo.Tbl_Accounting_Guid.Name HAVING        (dbo.Tbl_Accounting_Guid.Account_NO >= @A) AND(dbo.Tbl_Accounting_Guid.Account_NO <= @A1) ");
                    com.Parameters.Add("@P", SqlDbType.Date).Value = radDateTimePicker1.Value;
                    com.Parameters.Add("@P1", SqlDbType.Date).Value = radDateTimePicker2.Value;
                    com.Parameters.Add("@i", SqlDbType.NVarChar).Value = Vint_MenuPr;
                    com.Parameters.Add("@A", SqlDbType.NVarChar).Value =Convert.ToInt32( textBox5.Text) +"%" ;
                    com.Parameters.Add("@A1", SqlDbType.NVarChar).Value = Convert.ToInt32(textBox6.Text) + 1 + "%";
                    com.Parameters.Add("@F", SqlDbType.NVarChar).Value = comboBox9.SelectedValue ;
                    con.Open();
                    da.SelectCommand = com;
                    com.ExecuteScalar();
                    da.Fill(dt);


                    //com.ExecuteScalar();
                    con.Close();
                }
            }

            return dt;

        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter )
            {
                dataGridView1.Visible = true;
                dataGridView3.Visible = false;
                dataGridView1.DataSource = GetSearchBalance();
                textBox2.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[2].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[2].FormattedValue)).Sum().ToString();
                textBox3.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[3].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Visible = true;
                dataGridView3.Visible = false;
                if ( dataGridView1.DataSource != GetSearchDate())
                {
                    dataGridView1.DataSource = GetSearchDate();
                }
            
                if(textBox7.Text == string.Empty )
                {
                    dataGridView1.DataSource = GetSearchDate();
                }
                textBox2.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[5].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum().ToString();
                textBox3.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[6].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
            }
            catch { }
        }

        private void Descp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Visible = true;
                dataGridView3.Visible = false;
                if (dataGridView1.DataSource != GetSearchDate())
                {
                    dataGridView1.DataSource = GetSearchDate();
                }
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridView1.DataSource;
                bs.Filter = "البيان like '" + Descp.Text + "%'";
                dataGridView1.DataSource = bs;
                if (Descp.Text == string.Empty)
                {
                    dataGridView1.DataSource = GetSearchDate();
                }
                textBox2.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[5].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum().ToString();
                textBox3.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[6].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
            }
            catch { }
        }

        private void UsFul_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Visible = true;
                dataGridView3.Visible = false;
                if (dataGridView1.DataSource != GetSearchDate())
                {
                    dataGridView1.DataSource = GetSearchDate();
                }
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridView1.DataSource;
                bs.Filter = "[اسم المستفيد] like '" + UsFul.Text + "%'";
                dataGridView1.DataSource = bs;
                if (UsFul.Text == string.Empty)
                {
                    dataGridView1.DataSource = GetSearchDate();
                }
                textBox2.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[5].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum().ToString();
                textBox3.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[6].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
            }
            catch { }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Visible = true;
                dataGridView3.Visible = false;
                if (dataGridView1.DataSource != GetSearchDate())
                {
                    dataGridView1.DataSource = GetSearchDate();
                }
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridView1.DataSource;
                bs.Filter = "التصنيف like '" + comboBox2.Text + "%'";
                dataGridView1.DataSource = bs;
                if (comboBox2.Text == string.Empty)
                {
                    dataGridView1.DataSource = GetSearchDate();
                }
                textBox2.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[5].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum().ToString();
                textBox3.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[6].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
            }
            catch { }
        }

        private void Respo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Visible = true;
                dataGridView3.Visible = false;
                if (dataGridView1.DataSource != GetSearchDate())
                {
                    dataGridView1.DataSource = GetSearchDate();
                }
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridView1.DataSource;
                bs.Filter = "[مركز المسؤلية] like '" + Respo.Text + "%'";
                dataGridView1.DataSource = bs;
                if (Respo.Text == string.Empty)
                {
                    dataGridView1.DataSource = GetSearchDate();
                }
                textBox2.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[5].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum().ToString();
                textBox3.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[6].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
            }
            catch { }
        }

        private void Order_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Visible = true;
                dataGridView3.Visible = false;
                if (dataGridView1.DataSource != GetSearchDate())
                {
                    dataGridView1.DataSource = GetSearchDate();
                }
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridView1.DataSource;
                bs.Filter = "[نوع الأمر] like '" + Order.Text + "%'";
                dataGridView1.DataSource = bs;
                if (Order.Text == string.Empty)
                {
                    dataGridView1.DataSource = GetSearchDate();
                }
                textBox2.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[5].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum().ToString();
                textBox3.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[6].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
            }
            catch { }
        }

        private void textEdit1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void exCenter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Visible = true;
                dataGridView3.Visible = false;
                if (dataGridView1.DataSource != GetSearchDate())
                {
                    dataGridView1.DataSource = GetSearchDate();
                }
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridView1.DataSource;
                bs.Filter = "[مركز الصرف] like '" + exCenter.Text + "%'";
                dataGridView1.DataSource = bs;
                if (exCenter.Text == string.Empty)
                {
                    dataGridView1.DataSource = GetSearchDate();
                }
                textBox2.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[5].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum().ToString();
                textBox3.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[6].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
            }
            catch { }
        }

        private void Manag_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Visible = true ;
                dataGridView3.Visible = false ;
                if (dataGridView1.DataSource != GetSearchDate())
                {
                    dataGridView1.DataSource = GetSearchDate();
                }
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridView1.DataSource;
                bs.Filter = "الإدارة like '" + Manag.Text + "%'";
                dataGridView1.DataSource = bs;
                if (Manag.Text == string.Empty)
                {
                    dataGridView1.DataSource = GetSearchDate();
                }
                textBox2.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[5].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum().ToString();
                textBox3.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[6].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
            }
            catch { }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter )
            {
                //try
                //{
                dataGridView1.Visible = true;
                dataGridView3.Visible = false;
                if (dataGridView1.DataSource != GetSearchDate())
                {
                    dataGridView1.DataSource = GetSearchDate();
                }
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridView1.DataSource;
                bs.Filter = "مدين = '" + Convert.ToDecimal(textBox8.Text) + "'";
                dataGridView1.DataSource = bs;
                if (textBox8.Text == string.Empty)
                {
                    dataGridView1.DataSource = GetSearchDate();
                }
                textBox2.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[5].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum().ToString();
                textBox3.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[6].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
                //}
                //catch { }
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter )
            {
                try
                {
                    dataGridView1.Visible = true;
                    dataGridView3.Visible = false;
                    if (dataGridView1.DataSource != GetSearchDate())
                    {
                        dataGridView1.DataSource = GetSearchDate();
                    }
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dataGridView1.DataSource;
                    bs.Filter = "دائن = '" + textBox9.Text + "'";
                    dataGridView1.DataSource = bs;
                    if (textBox9.Text == string.Empty)
                    {
                        dataGridView1.DataSource = GetSearchDate();
                    }
                    textBox2.Text = (from DataGridViewRow row in dataGridView1.Rows
                                     where row.Cells[5].FormattedValue.ToString() != string.Empty
                                     select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum().ToString();
                    textBox3.Text = (from DataGridViewRow row in dataGridView1.Rows
                                     where row.Cells[6].FormattedValue.ToString() != string.Empty
                                     select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
                }
                catch { }
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter )
            {
                textBox6.Focus();
                textBox6.SelectAll();
            }
        }

        private void comboBox8_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Visible = true;
                dataGridView3.Visible = false;
                if (dataGridView1.DataSource != GetSearchDate())
                {
                    dataGridView1.DataSource = GetSearchDate();
                }
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridView1.DataSource;
                bs.Filter = "[اسم المستفيد] like '" + UsFul.Text + "%'";
                dataGridView1.DataSource = bs;
                if (UsFul.Text == string.Empty)
                {
                    dataGridView1.DataSource = GetSearchDate();
                }
                textBox2.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[5].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum().ToString();
                textBox3.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[6].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
            }
            catch { }
        }

        private void textEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter )
            {
                try
                {
                    dataGridView1.Visible = true;
                    dataGridView3.Visible = false;
                    if (dataGridView1.DataSource != GetSearchDate())
                    {
                        dataGridView1.DataSource = GetSearchDate();
                    }
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dataGridView1.DataSource;
                    bs.Filter = "[رقم الأمر] like '" + textEdit1.Text + "%'";
                    dataGridView1.DataSource = bs;
                    if (textEdit1.Text == string.Empty)
                    {
                        dataGridView1.DataSource = GetSearchDate();
                    }
                    textBox2.Text = (from DataGridViewRow row in dataGridView1.Rows
                                     where row.Cells[5].FormattedValue.ToString() != string.Empty
                                     select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum().ToString();
                    textBox3.Text = (from DataGridViewRow row in dataGridView1.Rows
                                     where row.Cells[6].FormattedValue.ToString() != string.Empty
                                     select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
                }
                catch { }
            }
        }

        private void UsFul_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {

        }
    }
}
