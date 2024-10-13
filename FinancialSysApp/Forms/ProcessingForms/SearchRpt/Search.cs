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
using DevExpress.XtraTreeList.Nodes;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinGrid.ExcelExport;
using FinancialSysApp.DataBase.ModelEvents;
using FinancialSysApp.DataBase.Model;
using System.Diagnostics;

namespace FinancialSysApp.Forms.ProcessingForms.SearchRpt
{
    public partial class Search : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        public Search()
        {
            InitializeComponent();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            ultraGrid1.DisplayLayout.Override.AllowRowFiltering =
               ultraCheckEditor1.Checked ? DefaultableBoolean.True : DefaultableBoolean.False;
            this.tbl_AccountingRestrictions_KindTableAdapter.FillByKind(this.dataSet1.Tbl_AccountingRestrictions_Kind);
            this.tbl_FiscalyearTableAdapter.FillByYear(this.dataSet1.Tbl_Fiscalyear);
            this.tbl_SystemUnitesTableAdapter.FillByunitID(this.dataSet1.Tbl_SystemUnites, Program.GlbV_SysUnite_ID);
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
            this.tbl_OrderKindTableAdapter.Fill(this.dataSet1.Tbl_OrderKind);
            radDateTimePicker1.Value = dateTimePicker1.Value;

            Order.SelectedIndex = -1;
            radDateTimePicker1.Select();
            this.ActiveControl = radDateTimePicker1;
            radDateTimePicker1.Focus();
        }
        public void GetSearchDate()  //Date Only
        {

          
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            SqlCommand com1 = new SqlCommand();
            com1.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandText = "delete from Tbl_FinanctialSearch where UsrName=@Usr ";
            com1.Parameters.Add("@usr", SqlDbType.NVarChar).Value = Program.GlbV_UserName;

            con.Open();
            com1.ExecuteNonQuery();
            con.Close();
            ultraGrid1.Rows.Refresh(Infragistics.Win.UltraWinGrid.RefreshRow.RefreshDisplay);
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
                    com.CommandText = @"INSERT INTO dbo.Tbl_FinanctialSearch (Restriction_NO, Restriction_Date, NameOfDay, Account_NO, AccountName, Debit_Value, Credit_Value, Document_NO, NameOfDescription,  NameOfEx, NameOfOrder, Order_NO, Order_Date,  NameOfManagament, NameOfRespon, NameOfCategory, UsrName,NameOfBenificary) 
                  SELECT   dbo.Tbl_AccountingRestriction.Restriction_NO AS [رقم المستند], dbo.Tbl_AccountingRestriction.Restriction_Date AS [تاريخ المستند], dbo.Tbl_AccountingRestrictions_Kind.Name AS اليومية, 
                         dbo.Tbl_Accounting_Guid.Account_NO AS [رقم الحساب], dbo.Tbl_Accounting_Guid.Name AS [اسم الحساب], dbo.Tbl_AccountingRestrictionItems.Debit_Value AS مدين, dbo.Tbl_AccountingRestrictionItems.Credit_Value AS دائن, 
                         dbo.TBL_Document.Document_NO AS [رقم المراجعة], dbo.Tbl_DocumentCategory.Name AS البيان, dbo.Tbl_ExchangeCenter.Name AS [مركز الصرف], dbo.Tbl_OrderKind.Name AS [نوع الأمر], dbo.Tbl_Order.Order_NO AS [رقم الأمر], 
                         dbo.Tbl_Order.Order_Date AS [تاريخ الأمر], dbo.Tbl_Management.Name AS الإدارة, dbo.Tbl_ResponspilityCenters.Name AS [مركز المسؤلية], dbo.Tbl_RestrictionItemsCategory.Name AS التصنيف, @UsrName AS UsrName, 
                         dbo.Tbl_Beneficiary.Name
                         FROM  dbo.Tbl_ResponspilityCenters FULL OUTER JOIN
                         dbo.Tbl_AccountingRestrictionItems INNER JOIN
                         dbo.Tbl_Accounting_Guid ON dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID LEFT OUTER JOIN
                         dbo.Tbl_AccountingRestriction ON dbo.Tbl_AccountingRestrictionItems.AccountingRestriction_ID = dbo.Tbl_AccountingRestriction.ID LEFT OUTER JOIN
                         dbo.Tbl_Order INNER JOIN
                         dbo.Tbl_OrderKind ON dbo.Tbl_Order.OrderKind_ID = dbo.Tbl_OrderKind.ID RIGHT OUTER JOIN
                         dbo.Tbl_DocumentCategory INNER JOIN
                         dbo.TBL_Document ON dbo.Tbl_DocumentCategory.ID = dbo.TBL_Document.DocumentCategory_ID LEFT OUTER JOIN
                         dbo.Tbl_Beneficiary ON dbo.TBL_Document.Beneficiary_ID = dbo.Tbl_Beneficiary.ID ON dbo.Tbl_Order.ID = dbo.TBL_Document.Order_ID ON 
                         dbo.Tbl_AccountingRestriction.Document_ID = dbo.TBL_Document.ID LEFT OUTER JOIN
                         dbo.Tbl_AccountingRestrictions_Kind ON dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID = dbo.Tbl_AccountingRestrictions_Kind.ID LEFT OUTER JOIN
                         dbo.Tbl_RestrictionItemsCategory ON dbo.Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = dbo.Tbl_RestrictionItemsCategory.ID ON 
                         dbo.Tbl_ResponspilityCenters.ID = dbo.TBL_Document.responspilityID FULL OUTER JOIN
                         dbo.Tbl_Management FULL OUTER JOIN
                         dbo.Tbl_ExchangeCenter ON dbo.Tbl_Management.ExchangeCenter_ID = dbo.Tbl_ExchangeCenter.ID ON dbo.TBL_Document.ExchangeCenter_ID = dbo.Tbl_ExchangeCenter.ID AND 
                         dbo.TBL_Document.Management_ID = dbo.Tbl_Management.ID



                    WHERE (dbo.Tbl_AccountingRestriction.Restriction_Date BETWEEN @P AND @P1) 
                    AND (dbo.Tbl_AccountingRestrictions_Kind.ID = @i)
                   ";

                    com.Parameters.Add("@UsrName", SqlDbType.NVarChar).Value = Program.GlbV_UserName;
                    com.Parameters.Add("@P", SqlDbType.Date).Value = radDateTimePicker1.Value;
                    com.Parameters.Add("@P1", SqlDbType.Date).Value = radDateTimePicker2.Value;
                    com.Parameters.Add("@i", SqlDbType.Int).Value = Vint_MenuPr;
                    

                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }

            }



        }
        public void GetSearchDateRestrictionNumber()  //Date and RestrictionNumber
        {


            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            SqlCommand com1 = new SqlCommand();
            com1.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandText = "delete from Tbl_FinanctialSearch where UsrName=@Usr ";
            com1.Parameters.Add("@usr", SqlDbType.NVarChar).Value = Program.GlbV_UserName;

            con.Open();
            com1.ExecuteNonQuery();
            con.Close();
            ultraGrid1.Rows.Refresh(Infragistics.Win.UltraWinGrid.RefreshRow.RefreshDisplay);
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
                    com.CommandText = @"INSERT INTO dbo.Tbl_FinanctialSearch (Restriction_NO, Restriction_Date, NameOfDay, Account_NO, AccountName, Debit_Value, Credit_Value, Document_NO, NameOfDescription,  NameOfEx, NameOfOrder, Order_NO, Order_Date,  NameOfManagament, NameOfRespon, NameOfCategory, UsrName,NameOfBenificary) 
                 SELECT        dbo.Tbl_AccountingRestriction.Restriction_NO AS [رقم المستند], dbo.Tbl_AccountingRestriction.Restriction_Date AS [تاريخ المستند], dbo.Tbl_AccountingRestrictions_Kind.Name AS اليومية, 
                         dbo.Tbl_Accounting_Guid.Account_NO AS [رقم الحساب], dbo.Tbl_Accounting_Guid.Name AS [اسم الحساب], dbo.Tbl_AccountingRestrictionItems.Debit_Value AS مدين, dbo.Tbl_AccountingRestrictionItems.Credit_Value AS دائن, 
                         dbo.TBL_Document.Document_NO AS [رقم المراجعة], dbo.Tbl_DocumentCategory.Name AS البيان, dbo.Tbl_ExchangeCenter.Name AS [مركز الصرف], dbo.Tbl_OrderKind.Name AS [نوع الأمر], dbo.Tbl_Order.Order_NO AS [رقم الأمر], 
                         dbo.Tbl_Order.Order_Date AS [تاريخ الأمر], dbo.Tbl_Management.Name AS الإدارة, dbo.Tbl_ResponspilityCenters.Name AS [مركز المسؤلية], dbo.Tbl_RestrictionItemsCategory.Name AS التصنيف, @UsrName AS UsrName, 
                         dbo.Tbl_Beneficiary.Name
FROM            dbo.Tbl_ResponspilityCenters FULL OUTER JOIN
                         dbo.Tbl_AccountingRestrictionItems INNER JOIN
                         dbo.Tbl_Accounting_Guid ON dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID LEFT OUTER JOIN
                         dbo.Tbl_AccountingRestriction ON dbo.Tbl_AccountingRestrictionItems.AccountingRestriction_ID = dbo.Tbl_AccountingRestriction.ID LEFT OUTER JOIN
                         dbo.Tbl_Order INNER JOIN
                         dbo.Tbl_OrderKind ON dbo.Tbl_Order.OrderKind_ID = dbo.Tbl_OrderKind.ID RIGHT OUTER JOIN
                         dbo.Tbl_DocumentCategory INNER JOIN
                         dbo.TBL_Document ON dbo.Tbl_DocumentCategory.ID = dbo.TBL_Document.DocumentCategory_ID LEFT OUTER JOIN
                         dbo.Tbl_Beneficiary ON dbo.TBL_Document.Beneficiary_ID = dbo.Tbl_Beneficiary.ID ON dbo.Tbl_Order.ID = dbo.TBL_Document.Order_ID ON 
                         dbo.Tbl_AccountingRestriction.Document_ID = dbo.TBL_Document.ID LEFT OUTER JOIN
                         dbo.Tbl_AccountingRestrictions_Kind ON dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID = dbo.Tbl_AccountingRestrictions_Kind.ID LEFT OUTER JOIN
                         dbo.Tbl_RestrictionItemsCategory ON dbo.Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = dbo.Tbl_RestrictionItemsCategory.ID ON 
                         dbo.Tbl_ResponspilityCenters.ID = dbo.TBL_Document.responspilityID FULL OUTER JOIN
                         dbo.Tbl_Management FULL OUTER JOIN
                         dbo.Tbl_ExchangeCenter ON dbo.Tbl_Management.ExchangeCenter_ID = dbo.Tbl_ExchangeCenter.ID ON dbo.TBL_Document.ExchangeCenter_ID = dbo.Tbl_ExchangeCenter.ID AND 
                         dbo.TBL_Document.Management_ID = dbo.Tbl_Management.ID
WHERE        (dbo.Tbl_AccountingRestriction.Restriction_Date BETWEEN @P AND @P1) AND (dbo.Tbl_AccountingRestrictions_Kind.ID = @i) AND (dbo.Tbl_AccountingRestriction.Restriction_NO BETWEEN @ResNum AND @ResNum1)
                   ";

                    com.Parameters.Add("@UsrName", SqlDbType.NVarChar).Value = Program.GlbV_UserName;
                    com.Parameters.Add("@P", SqlDbType.Date).Value = radDateTimePicker1.Value;
                    com.Parameters.Add("@P1", SqlDbType.Date).Value = radDateTimePicker2.Value;
                    com.Parameters.Add("@i", SqlDbType.Int).Value = Vint_MenuPr;
                    com.Parameters.Add("@ResNum", SqlDbType.NVarChar).Value = textBox1.Text;
                    com.Parameters.Add("@ResNum1", SqlDbType.NVarChar).Value = textBox2.Text;

                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }

            }



        }
        public void GetSearchDateRestrictionNumberWithAccountNumber()  //Date and RestrictionNumber With Account Number
        {


            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            SqlCommand com1 = new SqlCommand();
            com1.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandText = "delete from Tbl_FinanctialSearch where UsrName=@Usr ";
            com1.Parameters.Add("@usr", SqlDbType.NVarChar).Value = Program.GlbV_UserName;

            con.Open();
            com1.ExecuteNonQuery();
            con.Close();
            ultraGrid1.Rows.Refresh(Infragistics.Win.UltraWinGrid.RefreshRow.RefreshDisplay);
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
                    com.CommandText = @"INSERT INTO dbo.Tbl_FinanctialSearch (Restriction_NO, Restriction_Date, NameOfDay, Account_NO, AccountName, Debit_Value, Credit_Value, Document_NO, NameOfDescription,  NameOfEx, NameOfOrder, Order_NO, Order_Date,  NameOfManagament, NameOfRespon, NameOfCategory, UsrName,NameOfBenificary) 
                 SELECT        dbo.Tbl_AccountingRestriction.Restriction_NO AS [رقم المستند], dbo.Tbl_AccountingRestriction.Restriction_Date AS [تاريخ المستند], dbo.Tbl_AccountingRestrictions_Kind.Name AS اليومية, 
                         dbo.Tbl_Accounting_Guid.Account_NO AS [رقم الحساب], dbo.Tbl_Accounting_Guid.Name AS [اسم الحساب], dbo.Tbl_AccountingRestrictionItems.Debit_Value AS مدين, dbo.Tbl_AccountingRestrictionItems.Credit_Value AS دائن, 
                         dbo.TBL_Document.Document_NO AS [رقم المراجعة], dbo.Tbl_DocumentCategory.Name AS البيان, dbo.Tbl_ExchangeCenter.Name AS [مركز الصرف], dbo.Tbl_OrderKind.Name AS [نوع الأمر], dbo.Tbl_Order.Order_NO AS [رقم الأمر], 
                         dbo.Tbl_Order.Order_Date AS [تاريخ الأمر], dbo.Tbl_Management.Name AS الإدارة, dbo.Tbl_ResponspilityCenters.Name AS [مركز المسؤلية], dbo.Tbl_RestrictionItemsCategory.Name AS التصنيف, @UsrName AS UsrName, 
                         dbo.Tbl_Beneficiary.Name
FROM            dbo.Tbl_ResponspilityCenters FULL OUTER JOIN
                         dbo.Tbl_AccountingRestrictionItems INNER JOIN
                         dbo.Tbl_Accounting_Guid ON dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID LEFT OUTER JOIN
                         dbo.Tbl_AccountingRestriction ON dbo.Tbl_AccountingRestrictionItems.AccountingRestriction_ID = dbo.Tbl_AccountingRestriction.ID LEFT OUTER JOIN
                         dbo.Tbl_Order INNER JOIN
                         dbo.Tbl_OrderKind ON dbo.Tbl_Order.OrderKind_ID = dbo.Tbl_OrderKind.ID RIGHT OUTER JOIN
                         dbo.Tbl_DocumentCategory INNER JOIN
                         dbo.TBL_Document ON dbo.Tbl_DocumentCategory.ID = dbo.TBL_Document.DocumentCategory_ID LEFT OUTER JOIN
                         dbo.Tbl_Beneficiary ON dbo.TBL_Document.Beneficiary_ID = dbo.Tbl_Beneficiary.ID ON dbo.Tbl_Order.ID = dbo.TBL_Document.Order_ID ON 
                         dbo.Tbl_AccountingRestriction.Document_ID = dbo.TBL_Document.ID LEFT OUTER JOIN
                         dbo.Tbl_AccountingRestrictions_Kind ON dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID = dbo.Tbl_AccountingRestrictions_Kind.ID LEFT OUTER JOIN
                         dbo.Tbl_RestrictionItemsCategory ON dbo.Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = dbo.Tbl_RestrictionItemsCategory.ID ON 
                         dbo.Tbl_ResponspilityCenters.ID = dbo.TBL_Document.responspilityID FULL OUTER JOIN
                         dbo.Tbl_Management FULL OUTER JOIN
                         dbo.Tbl_ExchangeCenter ON dbo.Tbl_Management.ExchangeCenter_ID = dbo.Tbl_ExchangeCenter.ID ON dbo.TBL_Document.ExchangeCenter_ID = dbo.Tbl_ExchangeCenter.ID AND 
                         dbo.TBL_Document.Management_ID = dbo.Tbl_Management.ID
WHERE        (dbo.Tbl_AccountingRestriction.Restriction_Date BETWEEN @P AND @P1) AND (dbo.Tbl_AccountingRestrictions_Kind.ID = @i) AND (dbo.Tbl_AccountingRestriction.Restriction_NO BETWEEN @ResNum AND @ResNum1) AND 
                         (dbo.Tbl_Accounting_Guid.Account_NO = @Account)";

                    com.Parameters.Add("@UsrName", SqlDbType.NVarChar).Value = Program.GlbV_UserName;
                    com.Parameters.Add("@P", SqlDbType.Date).Value = radDateTimePicker1.Value;
                    com.Parameters.Add("@P1", SqlDbType.Date).Value = radDateTimePicker2.Value;
                    com.Parameters.Add("@i", SqlDbType.Int).Value = Vint_MenuPr;
                    com.Parameters.Add("@ResNum", SqlDbType.NVarChar).Value = textBox1.Text;
                    com.Parameters.Add("@ResNum1", SqlDbType.NVarChar).Value = textBox2.Text;
                    com.Parameters.Add("@Account", SqlDbType.NVarChar).Value = textBox7.Text;
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }

            }



        }
        public void GetSearchDateRestrictionNumberWithAccountNumberDebit()  //Date and RestrictionNumber With Account Number  and Debit
        {


            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            SqlCommand com1 = new SqlCommand();
            com1.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandText = "delete from Tbl_FinanctialSearch where UsrName=@Usr ";
            com1.Parameters.Add("@usr", SqlDbType.NVarChar).Value = Program.GlbV_UserName;

            con.Open();
            com1.ExecuteNonQuery();
            con.Close();
            ultraGrid1.Rows.Refresh(Infragistics.Win.UltraWinGrid.RefreshRow.RefreshDisplay);
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
                    com.CommandText = @"INSERT INTO dbo.Tbl_FinanctialSearch (Restriction_NO, Restriction_Date, NameOfDay, Account_NO, AccountName, Debit_Value, Credit_Value, Document_NO, NameOfDescription,  NameOfEx, NameOfOrder, Order_NO, Order_Date,  NameOfManagament, NameOfRespon, NameOfCategory, UsrName,NameOfBenificary) 
                 SELECT        dbo.Tbl_AccountingRestriction.Restriction_NO AS [رقم المستند], dbo.Tbl_AccountingRestriction.Restriction_Date AS [تاريخ المستند], dbo.Tbl_AccountingRestrictions_Kind.Name AS اليومية, 
                         dbo.Tbl_Accounting_Guid.Account_NO AS [رقم الحساب], dbo.Tbl_Accounting_Guid.Name AS [اسم الحساب], dbo.Tbl_AccountingRestrictionItems.Debit_Value AS مدين, dbo.Tbl_AccountingRestrictionItems.Credit_Value AS دائن, 
                         dbo.TBL_Document.Document_NO AS [رقم المراجعة], dbo.Tbl_DocumentCategory.Name AS البيان, dbo.Tbl_ExchangeCenter.Name AS [مركز الصرف], dbo.Tbl_OrderKind.Name AS [نوع الأمر], dbo.Tbl_Order.Order_NO AS [رقم الأمر], 
                         dbo.Tbl_Order.Order_Date AS [تاريخ الأمر], dbo.Tbl_Management.Name AS الإدارة, dbo.Tbl_ResponspilityCenters.Name AS [مركز المسؤلية], dbo.Tbl_RestrictionItemsCategory.Name AS التصنيف, @UsrName AS UsrName, 
                         dbo.Tbl_Beneficiary.Name
FROM            dbo.Tbl_ResponspilityCenters FULL OUTER JOIN
                         dbo.Tbl_AccountingRestrictionItems INNER JOIN
                         dbo.Tbl_Accounting_Guid ON dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID LEFT OUTER JOIN
                         dbo.Tbl_AccountingRestriction ON dbo.Tbl_AccountingRestrictionItems.AccountingRestriction_ID = dbo.Tbl_AccountingRestriction.ID LEFT OUTER JOIN
                         dbo.Tbl_Order INNER JOIN
                         dbo.Tbl_OrderKind ON dbo.Tbl_Order.OrderKind_ID = dbo.Tbl_OrderKind.ID RIGHT OUTER JOIN
                         dbo.Tbl_DocumentCategory INNER JOIN
                         dbo.TBL_Document ON dbo.Tbl_DocumentCategory.ID = dbo.TBL_Document.DocumentCategory_ID LEFT OUTER JOIN
                         dbo.Tbl_Beneficiary ON dbo.TBL_Document.Beneficiary_ID = dbo.Tbl_Beneficiary.ID ON dbo.Tbl_Order.ID = dbo.TBL_Document.Order_ID ON 
                         dbo.Tbl_AccountingRestriction.Document_ID = dbo.TBL_Document.ID LEFT OUTER JOIN
                         dbo.Tbl_AccountingRestrictions_Kind ON dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID = dbo.Tbl_AccountingRestrictions_Kind.ID LEFT OUTER JOIN
                         dbo.Tbl_RestrictionItemsCategory ON dbo.Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = dbo.Tbl_RestrictionItemsCategory.ID ON 
                         dbo.Tbl_ResponspilityCenters.ID = dbo.TBL_Document.responspilityID FULL OUTER JOIN
                         dbo.Tbl_Management FULL OUTER JOIN
                         dbo.Tbl_ExchangeCenter ON dbo.Tbl_Management.ExchangeCenter_ID = dbo.Tbl_ExchangeCenter.ID ON dbo.TBL_Document.ExchangeCenter_ID = dbo.Tbl_ExchangeCenter.ID AND 
                         dbo.TBL_Document.Management_ID = dbo.Tbl_Management.ID
WHERE        (dbo.Tbl_AccountingRestriction.Restriction_Date BETWEEN @P AND @P1) AND (dbo.Tbl_AccountingRestrictions_Kind.ID = @i) AND (dbo.Tbl_AccountingRestriction.Restriction_NO BETWEEN @ResNum AND @ResNum1) AND 
                         (dbo.Tbl_Accounting_Guid.Account_NO = @Account) AND (dbo.Tbl_AccountingRestrictionItems.Debit_Value BETWEEN @Debit AND @Debit1)";

                    com.Parameters.Add("@UsrName", SqlDbType.NVarChar).Value = Program.GlbV_UserName;
                    com.Parameters.Add("@P", SqlDbType.Date).Value = radDateTimePicker1.Value;
                    com.Parameters.Add("@P1", SqlDbType.Date).Value = radDateTimePicker2.Value;
                    com.Parameters.Add("@i", SqlDbType.Int).Value = Vint_MenuPr;
                    com.Parameters.Add("@ResNum", SqlDbType.NVarChar).Value = textBox1.Text;
                    com.Parameters.Add("@ResNum1", SqlDbType.NVarChar).Value = textBox2.Text;
                    com.Parameters.Add("@Account", SqlDbType.NVarChar).Value = textBox7.Text;
                    com.Parameters.Add("@Debit", SqlDbType.Decimal).Value =decimal.Parse( textBox6.Text);
                    com.Parameters.Add("@Debit1", SqlDbType.Decimal).Value = decimal.Parse(textBox5.Text);
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }

            }



        }
        public void GetSearchDateRestrictionNumberWithAccountNumberCridet()  //Date and RestrictionNumber With Account Number  and Cridet
        {


            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            SqlCommand com1 = new SqlCommand();
            com1.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandText = "delete from Tbl_FinanctialSearch where UsrName=@Usr ";
            com1.Parameters.Add("@usr", SqlDbType.NVarChar).Value = Program.GlbV_UserName;

            con.Open();
            com1.ExecuteNonQuery();
            con.Close();
            ultraGrid1.Rows.Refresh(Infragistics.Win.UltraWinGrid.RefreshRow.RefreshDisplay);
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
                    com.CommandText = @"INSERT INTO dbo.Tbl_FinanctialSearch (Restriction_NO, Restriction_Date, NameOfDay, Account_NO, AccountName, Debit_Value, Credit_Value, Document_NO, NameOfDescription,  NameOfEx, NameOfOrder, Order_NO, Order_Date,  NameOfManagament, NameOfRespon, NameOfCategory, UsrName,NameOfBenificary) 
                 SELECT        dbo.Tbl_AccountingRestriction.Restriction_NO AS [رقم المستند], dbo.Tbl_AccountingRestriction.Restriction_Date AS [تاريخ المستند], dbo.Tbl_AccountingRestrictions_Kind.Name AS اليومية, 
                         dbo.Tbl_Accounting_Guid.Account_NO AS [رقم الحساب], dbo.Tbl_Accounting_Guid.Name AS [اسم الحساب], dbo.Tbl_AccountingRestrictionItems.Debit_Value AS مدين, dbo.Tbl_AccountingRestrictionItems.Credit_Value AS دائن, 
                         dbo.TBL_Document.Document_NO AS [رقم المراجعة], dbo.Tbl_DocumentCategory.Name AS البيان, dbo.Tbl_ExchangeCenter.Name AS [مركز الصرف], dbo.Tbl_OrderKind.Name AS [نوع الأمر], dbo.Tbl_Order.Order_NO AS [رقم الأمر], 
                         dbo.Tbl_Order.Order_Date AS [تاريخ الأمر], dbo.Tbl_Management.Name AS الإدارة, dbo.Tbl_ResponspilityCenters.Name AS [مركز المسؤلية], dbo.Tbl_RestrictionItemsCategory.Name AS التصنيف, @UsrName AS UsrName, 
                         dbo.Tbl_Beneficiary.Name
FROM            dbo.Tbl_ResponspilityCenters FULL OUTER JOIN
                         dbo.Tbl_AccountingRestrictionItems INNER JOIN
                         dbo.Tbl_Accounting_Guid ON dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID LEFT OUTER JOIN
                         dbo.Tbl_AccountingRestriction ON dbo.Tbl_AccountingRestrictionItems.AccountingRestriction_ID = dbo.Tbl_AccountingRestriction.ID LEFT OUTER JOIN
                         dbo.Tbl_Order INNER JOIN
                         dbo.Tbl_OrderKind ON dbo.Tbl_Order.OrderKind_ID = dbo.Tbl_OrderKind.ID RIGHT OUTER JOIN
                         dbo.Tbl_DocumentCategory INNER JOIN
                         dbo.TBL_Document ON dbo.Tbl_DocumentCategory.ID = dbo.TBL_Document.DocumentCategory_ID LEFT OUTER JOIN
                         dbo.Tbl_Beneficiary ON dbo.TBL_Document.Beneficiary_ID = dbo.Tbl_Beneficiary.ID ON dbo.Tbl_Order.ID = dbo.TBL_Document.Order_ID ON 
                         dbo.Tbl_AccountingRestriction.Document_ID = dbo.TBL_Document.ID LEFT OUTER JOIN
                         dbo.Tbl_AccountingRestrictions_Kind ON dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID = dbo.Tbl_AccountingRestrictions_Kind.ID LEFT OUTER JOIN
                         dbo.Tbl_RestrictionItemsCategory ON dbo.Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = dbo.Tbl_RestrictionItemsCategory.ID ON 
                         dbo.Tbl_ResponspilityCenters.ID = dbo.TBL_Document.responspilityID FULL OUTER JOIN
                         dbo.Tbl_Management FULL OUTER JOIN
                         dbo.Tbl_ExchangeCenter ON dbo.Tbl_Management.ExchangeCenter_ID = dbo.Tbl_ExchangeCenter.ID ON dbo.TBL_Document.ExchangeCenter_ID = dbo.Tbl_ExchangeCenter.ID AND 
                         dbo.TBL_Document.Management_ID = dbo.Tbl_Management.ID
WHERE        (dbo.Tbl_AccountingRestriction.Restriction_Date BETWEEN @P AND @P1) AND (dbo.Tbl_AccountingRestrictions_Kind.ID = @i) AND (dbo.Tbl_AccountingRestriction.Restriction_NO BETWEEN @ResNum AND @ResNum1) AND 
                         (dbo.Tbl_Accounting_Guid.Account_NO = @Account) AND (dbo.Tbl_AccountingRestrictionItems.Credit_Value BETWEEN @Cridet AND @Cridet1)";

                    com.Parameters.Add("@UsrName", SqlDbType.NVarChar).Value = Program.GlbV_UserName;
                    com.Parameters.Add("@P", SqlDbType.Date).Value = radDateTimePicker1.Value;
                    com.Parameters.Add("@P1", SqlDbType.Date).Value = radDateTimePicker2.Value;
                    com.Parameters.Add("@i", SqlDbType.Int).Value = Vint_MenuPr;
                    com.Parameters.Add("@ResNum", SqlDbType.NVarChar).Value = textBox1.Text;
                    com.Parameters.Add("@ResNum1", SqlDbType.NVarChar).Value = textBox2.Text;
                    com.Parameters.Add("@Account", SqlDbType.NVarChar).Value = textBox7.Text;
                    com.Parameters.Add("@Cridet", SqlDbType.Decimal).Value = decimal.Parse(textBox9.Text);
                    com.Parameters.Add("@Cridet1", SqlDbType.Decimal).Value = decimal.Parse(textBox8.Text);
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }

            }



        }
        public void GetSearchDateRestrictionNumberWithCridet()  //Date and RestrictionNumber With Account Number  and Cridet
        {


            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            SqlCommand com1 = new SqlCommand();
            com1.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandText = "delete from Tbl_FinanctialSearch where UsrName=@Usr ";
            com1.Parameters.Add("@usr", SqlDbType.NVarChar).Value = Program.GlbV_UserName;

            con.Open();
            com1.ExecuteNonQuery();
            con.Close();
            ultraGrid1.Rows.Refresh(Infragistics.Win.UltraWinGrid.RefreshRow.RefreshDisplay);
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
                    com.CommandText = @"INSERT INTO dbo.Tbl_FinanctialSearch (Restriction_NO, Restriction_Date, NameOfDay, Account_NO, AccountName, Debit_Value, Credit_Value, Document_NO, NameOfDescription,  NameOfEx, NameOfOrder, Order_NO, Order_Date,  NameOfManagament, NameOfRespon, NameOfCategory, UsrName,NameOfBenificary) 
                 SELECT        dbo.Tbl_AccountingRestriction.Restriction_NO AS [رقم المستند], dbo.Tbl_AccountingRestriction.Restriction_Date AS [تاريخ المستند], dbo.Tbl_AccountingRestrictions_Kind.Name AS اليومية, 
                         dbo.Tbl_Accounting_Guid.Account_NO AS [رقم الحساب], dbo.Tbl_Accounting_Guid.Name AS [اسم الحساب], dbo.Tbl_AccountingRestrictionItems.Debit_Value AS مدين, dbo.Tbl_AccountingRestrictionItems.Credit_Value AS دائن, 
                         dbo.TBL_Document.Document_NO AS [رقم المراجعة], dbo.Tbl_DocumentCategory.Name AS البيان, dbo.Tbl_ExchangeCenter.Name AS [مركز الصرف], dbo.Tbl_OrderKind.Name AS [نوع الأمر], dbo.Tbl_Order.Order_NO AS [رقم الأمر], 
                         dbo.Tbl_Order.Order_Date AS [تاريخ الأمر], dbo.Tbl_Management.Name AS الإدارة, dbo.Tbl_ResponspilityCenters.Name AS [مركز المسؤلية], dbo.Tbl_RestrictionItemsCategory.Name AS التصنيف, @UsrName AS UsrName, 
                         dbo.Tbl_Beneficiary.Name
FROM            dbo.Tbl_ResponspilityCenters FULL OUTER JOIN
                         dbo.Tbl_AccountingRestrictionItems INNER JOIN
                         dbo.Tbl_Accounting_Guid ON dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID LEFT OUTER JOIN
                         dbo.Tbl_AccountingRestriction ON dbo.Tbl_AccountingRestrictionItems.AccountingRestriction_ID = dbo.Tbl_AccountingRestriction.ID LEFT OUTER JOIN
                         dbo.Tbl_Order INNER JOIN
                         dbo.Tbl_OrderKind ON dbo.Tbl_Order.OrderKind_ID = dbo.Tbl_OrderKind.ID RIGHT OUTER JOIN
                         dbo.Tbl_DocumentCategory INNER JOIN
                         dbo.TBL_Document ON dbo.Tbl_DocumentCategory.ID = dbo.TBL_Document.DocumentCategory_ID LEFT OUTER JOIN
                         dbo.Tbl_Beneficiary ON dbo.TBL_Document.Beneficiary_ID = dbo.Tbl_Beneficiary.ID ON dbo.Tbl_Order.ID = dbo.TBL_Document.Order_ID ON 
                         dbo.Tbl_AccountingRestriction.Document_ID = dbo.TBL_Document.ID LEFT OUTER JOIN
                         dbo.Tbl_AccountingRestrictions_Kind ON dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID = dbo.Tbl_AccountingRestrictions_Kind.ID LEFT OUTER JOIN
                         dbo.Tbl_RestrictionItemsCategory ON dbo.Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = dbo.Tbl_RestrictionItemsCategory.ID ON 
                         dbo.Tbl_ResponspilityCenters.ID = dbo.TBL_Document.responspilityID FULL OUTER JOIN
                         dbo.Tbl_Management FULL OUTER JOIN
                         dbo.Tbl_ExchangeCenter ON dbo.Tbl_Management.ExchangeCenter_ID = dbo.Tbl_ExchangeCenter.ID ON dbo.TBL_Document.ExchangeCenter_ID = dbo.Tbl_ExchangeCenter.ID AND 
                         dbo.TBL_Document.Management_ID = dbo.Tbl_Management.ID
WHERE        (dbo.Tbl_AccountingRestriction.Restriction_Date BETWEEN @P AND @P1) AND (dbo.Tbl_AccountingRestrictions_Kind.ID = @i) AND (dbo.Tbl_AccountingRestriction.Restriction_NO BETWEEN @ResNum AND @ResNum1) AND 
                         (dbo.Tbl_Accounting_Guid.Account_NO = @Account) AND (dbo.Tbl_AccountingRestrictionItems.Credit_Value BETWEEN @Cridet AND @Cridet1)";

                    com.Parameters.Add("@UsrName", SqlDbType.NVarChar).Value = Program.GlbV_UserName;
                    com.Parameters.Add("@P", SqlDbType.Date).Value = radDateTimePicker1.Value;
                    com.Parameters.Add("@P1", SqlDbType.Date).Value = radDateTimePicker2.Value;
                    com.Parameters.Add("@i", SqlDbType.Int).Value = Vint_MenuPr;
                    com.Parameters.Add("@ResNum", SqlDbType.NVarChar).Value = textBox1.Text;
                    com.Parameters.Add("@ResNum1", SqlDbType.NVarChar).Value = textBox2.Text;
                    com.Parameters.Add("@Account", SqlDbType.NVarChar).Value = textBox7.Text;
                    com.Parameters.Add("@Cridet", SqlDbType.Decimal).Value = decimal.Parse(textBox9.Text);
                    com.Parameters.Add("@Cridet1", SqlDbType.Decimal).Value = decimal.Parse(textBox8.Text);
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }

            }



        }
        //public void GetSearchDateRestrictionAll()  //And with Or
        //{


        //    SqlConnection con = new SqlConnection();
        //    con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
        //    SqlCommand com = new SqlCommand();
        //    com.CommandType = CommandType.Text;
        //    com.Connection = con;
        //    SqlCommand com1 = new SqlCommand();
        //    com1.CommandType = CommandType.Text;
        //    com1.Connection = con;
        //    com1.CommandText = "delete from Tbl_FinanctialSearch where UsrName=@Usr ";
        //    com1.Parameters.Add("@usr", SqlDbType.NVarChar).Value = Program.GlbV_UserName;

        //    con.Open();
        //    com1.ExecuteNonQuery();
        //    con.Close();
        //    ultraGrid1.Rows.Refresh(Infragistics.Win.UltraWinGrid.RefreshRow.RefreshDisplay);
        //    SqlDataAdapter da = new SqlDataAdapter(com);
        //    DataTable dt = new DataTable();
        //    int Vint_TreelistCount = treeList1.Nodes.Count();
        //    List<TreeListNode> nodes = treeList1.GetNodeList();


        //    foreach (TreeListNode item in nodes)
        //    {
        //        if (item.CheckState == CheckState.Checked)
        //        {


        //            string VStr_MenuPr = item.GetValue("Name").ToString();
        //            com.Parameters.Clear();
        //            com.CommandText = @"INSERT INTO dbo.Tbl_FinanctialSearch 
        //                        (Restriction_NO, Restriction_Date, NameOfDay, Account_NO, AccountName, Debit_Value, Credit_Value, Document_NO, NameOfDescription,  NameOfEx, NameOfOrder, Order_NO, Order_Date,  NameOfManagament, NameOfRespon, NameOfCategory, UsrName, NameOfBenificary) 
        //                        SELECT 
        //                            dbo.Tbl_AccountingRestriction.Restriction_NO AS [رقم المستند], 
        //                            dbo.Tbl_AccountingRestriction.Restriction_Date AS [تاريخ المستند], 
        //                            dbo.Tbl_AccountingRestrictions_Kind.Name AS اليومية, 
        //                            dbo.Tbl_Accounting_Guid.Account_NO AS [رقم الحساب], 
        //                            dbo.Tbl_Accounting_Guid.Name AS [اسم الحساب], 
        //                            dbo.Tbl_AccountingRestrictionItems.Debit_Value AS مدين, 
        //                            dbo.Tbl_AccountingRestrictionItems.Credit_Value AS دائن, 
        //                            dbo.TBL_Document.Document_NO AS [رقم المراجعة], 
        //                            dbo.Tbl_DocumentCategory.Name AS البيان, 
        //                            dbo.Tbl_ExchangeCenter.Name AS [مركز الصرف], 
        //                            dbo.Tbl_OrderKind.Name AS [نوع الأمر], 
        //                            dbo.Tbl_Order.Order_NO AS [رقم الأمر], 
        //                            dbo.Tbl_Order.Order_Date AS [تاريخ الأمر], 
        //                            dbo.Tbl_Management.Name AS الإدارة, 
        //                            dbo.Tbl_ResponspilityCenters.Name AS [مركز المسؤلية], 
        //                            dbo.Tbl_RestrictionItemsCategory.Name AS التصنيف, 
        //                            @UsrName AS UsrName, 
        //                            dbo.Tbl_Beneficiary.Name AS اسم_المستفيد
        //                        FROM dbo.Tbl_ResponspilityCenters 
        //                        FULL OUTER JOIN dbo.Tbl_AccountingRestrictionItems 
        //                        INNER JOIN dbo.Tbl_Accounting_Guid 
        //                        ON dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID 
        //                        LEFT OUTER JOIN dbo.Tbl_AccountingRestriction 
        //                        ON dbo.Tbl_AccountingRestrictionItems.AccountingRestriction_ID = dbo.Tbl_AccountingRestriction.ID 
        //                        LEFT OUTER JOIN dbo.Tbl_Order 
        //                        INNER JOIN dbo.Tbl_OrderKind 
        //                        ON dbo.Tbl_Order.OrderKind_ID = dbo.Tbl_OrderKind.ID 
        //                        RIGHT OUTER JOIN dbo.Tbl_DocumentCategory 
        //                        INNER JOIN dbo.TBL_Document 
        //                        ON dbo.Tbl_DocumentCategory.ID = dbo.TBL_Document.DocumentCategory_ID 
        //                        LEFT OUTER JOIN dbo.Tbl_Beneficiary 
        //                        ON dbo.TBL_Document.Beneficiary_ID = dbo.Tbl_Beneficiary.ID 
        //                        ON dbo.Tbl_Order.ID = dbo.TBL_Document.Order_ID 
        //                        ON dbo.Tbl_AccountingRestriction.Document_ID = dbo.TBL_Document.ID 
        //                        LEFT OUTER JOIN dbo.Tbl_AccountingRestrictions_Kind 
        //                        ON dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID = dbo.Tbl_AccountingRestrictions_Kind.ID 
        //                        LEFT OUTER JOIN dbo.Tbl_RestrictionItemsCategory 
        //                        ON dbo.Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = dbo.Tbl_RestrictionItemsCategory.ID 
        //                        ON dbo.Tbl_ResponspilityCenters.ID = dbo.TBL_Document.responspilityID 
        //                        FULL OUTER JOIN dbo.Tbl_Management 
        //                        FULL OUTER JOIN dbo.Tbl_ExchangeCenter 
        //                        ON dbo.Tbl_Management.ExchangeCenter_ID = dbo.Tbl_ExchangeCenter.ID 
        //                        ON dbo.TBL_Document.ExchangeCenter_ID = dbo.Tbl_ExchangeCenter.ID 
        //                        AND dbo.TBL_Document.Management_ID = dbo.Tbl_Management.ID
        //                        WHERE 
        //                            (dbo.Tbl_AccountingRestriction.Restriction_Date BETWEEN @P AND @P1) 
        //                            AND (dbo.Tbl_AccountingRestrictions_Kind.ID = @i) 
        //                            AND (dbo.Tbl_AccountingRestriction.Restriction_NO BETWEEN @ResNum AND @ResNum1) 
        //                            AND (dbo.Tbl_Accounting_Guid.Account_NO = @Account) 
        //                            AND (
        //                                dbo.Tbl_AccountingRestrictionItems.Credit_Value BETWEEN @Cridet AND @Cridet1 
        //                                OR dbo.Tbl_AccountingRestrictionItems.Debit_Value BETWEEN @Debit AND @Debit1 
        //                                OR dbo.Tbl_AccountingRestrictionItems.Debit_Value BETWEEN @Debit AND @Debit1 
        //                                OR dbo.Tbl_AccountingRestrictionItems.Credit_Value BETWEEN @Cridet AND @Cridet1
        //                            ) 
        //                            OR (
        //                                dbo.Tbl_AccountingRestriction.Restriction_Date BETWEEN @P AND @P1 
        //                                AND dbo.Tbl_AccountingRestrictions_Kind.ID = @i 
        //                                AND dbo.Tbl_AccountingRestrictionItems.Debit_Value BETWEEN @Debit AND @Debit1
        //                            ) 
        //                            OR (
        //                                dbo.Tbl_AccountingRestriction.Restriction_Date BETWEEN @P AND @P1 
        //                                AND dbo.Tbl_AccountingRestrictions_Kind.ID = @i 
        //                                AND dbo.Tbl_AccountingRestrictionItems.Credit_Value BETWEEN @Cridet AND @Cridet1
        //                            ) 
        //                            OR (
        //                                dbo.Tbl_AccountingRestriction.Restriction_Date BETWEEN @P AND @P1 
        //                                AND dbo.Tbl_AccountingRestrictions_Kind.ID = @i 
        //                                AND dbo.Tbl_DocumentCategory.Name = @Description
        //                            ) 
        //                            OR (
        //                                dbo.Tbl_AccountingRestriction.Restriction_Date BETWEEN @P AND @P1 
        //                                AND dbo.Tbl_AccountingRestrictions_Kind.ID = @i 
        //                                AND dbo.Tbl_AccountingRestriction.Restriction_NO BETWEEN @ResNum AND @ResNum1 
        //                                AND dbo.Tbl_DocumentCategory.Name = @Description
        //                            ) 
        //                            OR (
        //                                dbo.Tbl_AccountingRestriction.Restriction_Date BETWEEN @P AND @P1 
        //                                AND dbo.Tbl_AccountingRestrictions_Kind.ID = @i 
        //                                AND dbo.Tbl_Beneficiary.Name = @Usful
        //                            ) 
        //                            OR (
        //                                dbo.Tbl_AccountingRestriction.Restriction_Date BETWEEN @P AND @P1 
        //                                AND dbo.Tbl_AccountingRestrictions_Kind.ID = @i 
        //                                AND dbo.Tbl_Order.Order_NO = @Order
        //                            ) 
        //                            OR (
        //                                dbo.Tbl_AccountingRestriction.Restriction_Date BETWEEN @P AND @P1 
        //                                AND dbo.Tbl_AccountingRestrictions_Kind.ID = @i 
        //                                AND dbo.Tbl_OrderKind.Name = @OrderKind
        //                            )";
        //    };
        //        int Vint_MenuPr = int.Parse(item.GetValue("ID").ToString());
        //        com.Parameters.Clear();
        //        com.Parameters.Add("@UsrName", SqlDbType.NVarChar).Value = Program.GlbV_UserName;
        //        com.Parameters.Add("@P", SqlDbType.Date).Value = radDateTimePicker1.Value;
        //        com.Parameters.Add("@P1", SqlDbType.Date).Value = radDateTimePicker2.Value;
        //        com.Parameters.Add("@i", SqlDbType.Int).Value = Vint_MenuPr;
        //        com.Parameters.Add("@ResNum", SqlDbType.NVarChar).Value = int.Parse(textBox1.Text);
        //        com.Parameters.Add("@ResNum1", SqlDbType.NVarChar).Value = int.Parse(textBox2.Text);
        //        com.Parameters.Add("@Account", SqlDbType.NVarChar).Value = textBox7.Text;
        //        com.Parameters.Add("@Cridet", SqlDbType.Decimal).Value = decimal.Parse(textBox9.Text);
        //        com.Parameters.Add("@Cridet1", SqlDbType.Decimal).Value = decimal.Parse(textBox8.Text);
        //        com.Parameters.Add("@Debit", SqlDbType.Decimal).Value = decimal.Parse(textBox6.Text);
        //        com.Parameters.Add("@Debit1", SqlDbType.Decimal).Value = decimal.Parse(textBox5.Text);
        //        com.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Descp.Text;
        //        com.Parameters.Add("@Order", SqlDbType.Int ).Value =int.Parse( textEdit1.Text);
        //        com.Parameters.Add("@OrderKind", SqlDbType.NVarChar).Value = Order.Text;
        //        com.Parameters.Add("@Usful", SqlDbType.NVarChar).Value = UsFul.Text;

        //        //try
        //        //{
        //            con.Open();
        //            com.ExecuteNonQuery();
        //        //}
        //        //catch 
        //        //{

        //        //}
        //        //finally
        //        //{
        //            con.Close();
        //        //}
        //    }

        //    }

        public void GetSearchDateRestrictionAll()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString;

            // First, delete any existing records for the current user
            using (SqlConnection conDelete = new SqlConnection(connectionString))
            {
                SqlCommand comDelete = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    Connection = conDelete,
                    CommandText = "DELETE FROM Tbl_FinanctialSearch WHERE UsrName = @Usr"
                };
                comDelete.Parameters.Add("@Usr", SqlDbType.NVarChar).Value = Program.GlbV_UserName;

                conDelete.Open();
                comDelete.ExecuteNonQuery();
                conDelete.Close();
            }

            ultraGrid1.Rows.Refresh(Infragistics.Win.UltraWinGrid.RefreshRow.RefreshDisplay);

            List<TreeListNode> nodes = treeList1.GetNodeList();

            foreach (TreeListNode item in nodes)
            {
                if (item.CheckState == CheckState.Checked)
                {
                    int Vint_MenuPr = int.Parse(item.GetValue("ID").ToString());
                    string VStr_MenuPr = item.GetValue("Name").ToString();

                    using (SqlConnection conInsert = new SqlConnection(connectionString))
                    {
                        SqlCommand comInsert = new SqlCommand()
                        {
                            CommandType = CommandType.Text,
                            Connection = conInsert,
                            CommandText = @"
                        INSERT INTO dbo.Tbl_FinanctialSearch 
                        (Restriction_NO, Restriction_Date, NameOfDay, Account_NO, AccountName, Debit_Value, Credit_Value, Document_NO, NameOfDescription, NameOfEx, NameOfOrder, Order_NO, Order_Date, NameOfManagament, NameOfRespon, NameOfCategory, UsrName, NameOfBenificary,Fyear) 
                        SELECT 
                            dbo.Tbl_AccountingRestriction.Restriction_NO AS [رقم المستند], 
                            dbo.Tbl_AccountingRestriction.Restriction_Date AS [تاريخ المستند], 
                            dbo.Tbl_AccountingRestrictions_Kind.Name AS اليومية, 
                            dbo.Tbl_Accounting_Guid.Account_NO AS [رقم الحساب], 
                            dbo.Tbl_Accounting_Guid.Name AS [اسم الحساب], 
                            dbo.Tbl_AccountingRestrictionItems.Debit_Value AS مدين, 
                            dbo.Tbl_AccountingRestrictionItems.Credit_Value AS دائن, 
                            dbo.TBL_Document.Document_NO AS [رقم المراجعة], 
                            dbo.Tbl_DocumentCategory.Name AS البيان, 
                            dbo.Tbl_ExchangeCenter.Name AS [مركز الصرف], 
                            dbo.Tbl_OrderKind.Name AS [نوع الأمر], 
                            dbo.Tbl_Order.Order_NO AS [رقم الأمر], 
                            dbo.Tbl_Order.Order_Date AS [تاريخ الأمر], 
                            dbo.Tbl_Management.Name AS الإدارة, 
                            dbo.Tbl_ResponspilityCenters.Name AS [مركز المسؤلية], 
                            dbo.Tbl_RestrictionItemsCategory.Name AS التصنيف, 
                            @UsrName AS UsrName, 
                            dbo.Tbl_Beneficiary.Name AS اسم_المستفيد
,dbo.Tbl_AccountingRestriction.FYear 
                        FROM dbo.Tbl_ResponspilityCenters 
                        FULL OUTER JOIN dbo.Tbl_AccountingRestrictionItems 
                            INNER JOIN dbo.Tbl_Accounting_Guid 
                                ON dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID 
                            LEFT OUTER JOIN dbo.Tbl_AccountingRestriction 
                                ON dbo.Tbl_AccountingRestrictionItems.AccountingRestriction_ID = dbo.Tbl_AccountingRestriction.ID 
                            LEFT OUTER JOIN dbo.Tbl_Order 
                                INNER JOIN dbo.Tbl_OrderKind 
                                    ON dbo.Tbl_Order.OrderKind_ID = dbo.Tbl_OrderKind.ID 
                                RIGHT OUTER JOIN dbo.Tbl_DocumentCategory 
                                    INNER JOIN dbo.TBL_Document 
                                        ON dbo.Tbl_DocumentCategory.ID = dbo.TBL_Document.DocumentCategory_ID 
                                    LEFT OUTER JOIN dbo.Tbl_Beneficiary 
                                        ON dbo.TBL_Document.Beneficiary_ID = dbo.Tbl_Beneficiary.ID 
                                        ON dbo.Tbl_Order.ID = dbo.TBL_Document.Order_ID 
                                        ON dbo.Tbl_AccountingRestriction.Document_ID = dbo.TBL_Document.ID 
                            LEFT OUTER JOIN dbo.Tbl_AccountingRestrictions_Kind 
                                ON dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID = dbo.Tbl_AccountingRestrictions_Kind.ID 
                            LEFT OUTER JOIN dbo.Tbl_RestrictionItemsCategory 
                                ON dbo.Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = dbo.Tbl_RestrictionItemsCategory.ID 
                                    ON dbo.Tbl_ResponspilityCenters.ID = dbo.TBL_Document.responspilityID 
                        FULL OUTER JOIN dbo.Tbl_Management 
                            FULL OUTER JOIN dbo.Tbl_ExchangeCenter 
                                ON dbo.Tbl_Management.ExchangeCenter_ID = dbo.Tbl_ExchangeCenter.ID 
                                ON dbo.TBL_Document.ExchangeCenter_ID = dbo.Tbl_ExchangeCenter.ID 
                                AND dbo.TBL_Document.Management_ID = dbo.Tbl_Management.ID
                        WHERE 
                            (dbo.Tbl_AccountingRestriction.Restriction_Date BETWEEN @P AND @P1) AND (dbo.Tbl_AccountingRestrictions_Kind.ID = @i)"
                        };

                        // تحقق من وجود القيم قبل إضافتها إلى الاستعلام
                        if (!string.IsNullOrEmpty(textBox1.Text))
                        {
                            comInsert.CommandText += "AND (dbo.Tbl_AccountingRestriction.Restriction_NO BETWEEN @ResNum AND @ResNum1) ";
                            comInsert.Parameters.Add("@ResNum", SqlDbType.NVarChar).Value = int.Parse(textBox1.Text);
                            comInsert.Parameters.Add("@ResNum1", SqlDbType.NVarChar).Value = int.Parse(textBox2.Text);
                        }

                        if (!string.IsNullOrEmpty(textBox7.Text))
                        {
                            if(checkBox1.Checked==true )
                            {
                                comInsert.CommandText += "AND (dbo.Tbl_Accounting_Guid.Account_NO Like @Account) ";
                                comInsert.Parameters.Add("@Account", SqlDbType.NVarChar).Value = textBox7.Text + "%";
                            }
                            if (checkBox1.Checked == false )
                            {
                                comInsert.CommandText += "AND (dbo.Tbl_Accounting_Guid.Account_NO = @Account) ";
                                comInsert.Parameters.Add("@Account", SqlDbType.NVarChar).Value = textBox7.Text;
                            }
                        }

                        if (!string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrEmpty(textBox8.Text) )
                        {
                            comInsert.CommandText += "AND (dbo.Tbl_AccountingRestrictionItems.Credit_Value BETWEEN @Cridet AND @Cridet1)  ";
                            comInsert.Parameters.Add("@Cridet", SqlDbType.Decimal).Value = decimal.Parse(textBox9.Text);
                            comInsert.Parameters.Add("@Cridet1", SqlDbType.Decimal).Value = decimal.Parse(textBox8.Text);
                            
                        }

                        if ( !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrEmpty(textBox5.Text))
                        {
                            comInsert.CommandText += "AND (dbo.Tbl_AccountingRestrictionItems.Debit_Value BETWEEN @Debit AND @Debit1) ";
                            
                            comInsert.Parameters.Add("@Debit", SqlDbType.Decimal).Value = decimal.Parse(textBox6.Text);
                            comInsert.Parameters.Add("@Debit1", SqlDbType.Decimal).Value = decimal.Parse(textBox5.Text);
                        }
                        if (!string.IsNullOrEmpty(Descp.Text))
                        {
                            comInsert.CommandText += "AND (dbo.Tbl_DocumentCategory.Name = @Description) ";
                            comInsert.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Descp.Text;
                        }

                        if (!string.IsNullOrEmpty(UsFul.Text))
                        {
                            comInsert.CommandText += "AND (dbo.Tbl_Beneficiary.Name = @Usful) ";
                            comInsert.Parameters.Add("@Usful", SqlDbType.NVarChar).Value = UsFul.Text;
                        }

                        if (!string.IsNullOrEmpty(textEdit1.Text))
                        {
                            comInsert.CommandText += "AND (dbo.Tbl_Order.Order_NO = @Order) ";
                            comInsert.Parameters.Add("@Order", SqlDbType.NVarChar).Value = textEdit1.Text;
                        }

                        if (!string.IsNullOrEmpty(Order.Text))
                        {
                            comInsert.CommandText += "AND (dbo.Tbl_OrderKind.Name = @OrderKind) ";
                            comInsert.Parameters.Add("@OrderKind", SqlDbType.NVarChar).Value = Order.Text;
                        }

                        comInsert.CommandText += ";"; // إنهاء الاستعلام

                        comInsert.Parameters.Add("@UsrName", SqlDbType.NVarChar).Value = (object)Program.GlbV_UserName ?? DBNull.Value;
                        comInsert.Parameters.Add("@P", SqlDbType.Date).Value = (object)radDateTimePicker1.Value ?? DBNull.Value;
                        comInsert.Parameters.Add("@P1", SqlDbType.Date).Value = (object)radDateTimePicker2.Value ?? DBNull.Value;
                        comInsert.Parameters.Add("@i", SqlDbType.Int).Value = Vint_MenuPr;

                        // تأكد من تعيين جميع القيم المطلوبة قبل تنفيذ الاستعلام
                        if (comInsert.Parameters["@P"].Value != DBNull.Value &&
                            comInsert.Parameters["@P1"].Value != DBNull.Value &&
                            comInsert.Parameters["@i"].Value != DBNull.Value)
                        {
                            conInsert.Open();
                            comInsert.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show("اختر نوع اليومية");
                        }

                        conInsert.Close();
                    }
                }
            }
        }





        private void ultraButton1_Click(object sender, EventArgs e)
        {
            ultraGrid1.Visible = true;
            ultraGrid2.Visible = true;
            dataGridView3.Visible = false;
            TCount.Visible = false;

            BindingSource bs = new BindingSource();
            bs.DataSource = ultraGrid1.DataSource;
            bs.Filter = "البيان like '" + null + "%'";
            ultraGrid1.DataSource = bs;
            GetSearchDate();
           
            this.tbl_FinanctialSearchTableAdapter.Fill(this.finaSearch.Tbl_FinanctialSearch, Program.GlbV_UserName.ToString());


            textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[6].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
            textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[7].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();
            try
            {
                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[1].Value.ToString() != string.Empty
                                  select Convert.ToInt32(row.Cells[1].Value)).Distinct().Count().ToString();
            }
            catch { }
            textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[0].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[5].Value)).Sum().ToString();
            textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[0].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();

            textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                              where row.Cells[0].Value.ToString() != string.Empty
                              select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
            decimal x, y, z;
            x = Convert.ToDecimal(textBox3.Text);
            y = Convert.ToDecimal(textBox4.Text);
            z = Math.Round(x - y);
            textBox10.Text = Convert.ToString(z);



        }

        private void btnTemplateOk_Click(object sender, EventArgs e)
        {
          

        }

        private void btnTemplateCancel_Click(object sender, EventArgs e)
        {
          

        }

        private void ultraCheckEditor1_CheckedChanged(object sender, EventArgs e)
        {
            ultraGrid1.DisplayLayout.Override.AllowRowFiltering =
                ultraCheckEditor1.Checked ? DefaultableBoolean.True : DefaultableBoolean.False;

        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = ultraGrid1.DataSource;
            bs.Filter = "البيان like '" + Descp.Text + "%'";
            ultraGrid1.DataSource = bs;
            textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[6].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
            textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[7].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();

            textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                              where row.Cells[0].Value.ToString() != string.Empty
                              select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
            decimal x, y, z;
            x = Convert.ToDecimal(textBox3.Text);
            y = Convert.ToDecimal(textBox4.Text);
            z = x - y;
            textBox10.Text = Convert.ToString(z);
        }

        private void ultraButton3_Click(object sender, EventArgs e)
        {
            if (ultraCheckEditor3.Checked == true)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = ultraGrid1.DataSource;
                bs.Filter = "[رقم الحساب] like  '" + textBox7.Text + "%'" + " AND [البيان] Like  '" + Descp.Text + "%' ";
                ultraGrid1.DataSource = bs;
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[6].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[7].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();

                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[0].Value.ToString() != string.Empty
                                  select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
                decimal x, y, z;
                x = Convert.ToDecimal(textBox3.Text);
                y = Convert.ToDecimal(textBox4.Text);
                z = x - y;
                textBox10.Text = Convert.ToString(z);
            }
            else
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = ultraGrid1.DataSource;
                bs.Filter = "[رقم الحساب] like '" + textBox7.Text + "%'";
                //bs.Filter = "[رقم الحساب] like  '" + textBox7.Text + "%'" + " AND [البيان] Like  '" + Descp.Text + "%' ";
                //bs.Filter = "[رقم الحساب] like  '" + textBox7.Text + "%'" + " AND [البيان] =  '" + Descp.Text + "' ";
                ultraGrid1.DataSource = bs;
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[6].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[7].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();

                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[0].Value.ToString() != string.Empty
                                  select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
                decimal x, y, z;
                x = Convert.ToDecimal(textBox3.Text);
                y = Convert.ToDecimal(textBox4.Text);
                z = x - y;
                textBox10.Text = Convert.ToString(z);
            }
        }

        private void ultraButton4_Click(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = ultraGrid1.DataSource;
            //bs.Filter = "[رقم الحساب] like '" + textBox7.Text + "%'"+ "البيان like '" + Descp.Text + "%'";
            bs.Filter = "[رقم المستند] >=  '" + Convert.ToInt32(textBox1.Text) + "'" + "AND [رقم المستند] <=  '" + Convert.ToInt32(textBox2.Text) + "' ";
            //bs.Filter = "[رقم الحساب] like  '" + textBox7.Text + "%'" + " AND [البيان] =  '" + Descp.Text + "' ";
            ultraGrid1.DataSource = bs;
            textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[6].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
            textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[7].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();

            textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                              where row.Cells[0].Value.ToString() != string.Empty
                              select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
            decimal x, y, z;
            x = Convert.ToDecimal(textBox3.Text);
            y = Convert.ToDecimal(textBox4.Text);
            z = x - y;
            textBox10.Text = Convert.ToString(z);
        }

        private void ultraLabel2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ultraGrid1.Visible = true;
            ultraGrid2.Visible = true;
            dataGridView3.Visible = false;
            TCount.Visible = false;
            BindingSource bs = new BindingSource();
            bs.DataSource = ultraGrid1.DataSource;
            bs.Filter = "البيان like '" + Descp.Text + "%'";
            ultraGrid1.DataSource = bs;
            textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[6].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
            textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[7].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();
            try
            {
                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[1].Value.ToString() != string.Empty
                                  select Convert.ToInt32(row.Cells[1].Value)).Distinct().Count().ToString();
            }
            catch { }
            textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[0].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[5].Value)).Sum().ToString();
            textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[0].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();

            textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                              where row.Cells[0].Value.ToString() != string.Empty
                              select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
            decimal x, y, z;
            x = Convert.ToDecimal(textBox3.Text);
            y = Convert.ToDecimal(textBox4.Text);
            z = Math.Round(x - y);
            textBox10.Text = Convert.ToString(z);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            ultraGrid1.Visible = true;
            ultraGrid2.Visible = true;
            dataGridView3.Visible = false;
            TCount.Visible = false;
            if (ultraCheckEditor3.Checked == true)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = ultraGrid1.DataSource;
                //bs.Filter = "[رقم الحساب] like '" + textBox7.Text + "%'"+ "البيان like '" + Descp.Text + "%'";
                bs.Filter = "[رقم الحساب] like  '" + textBox7.Text + "%'" + " AND [البيان] Like  '" + Descp.Text + "%' ";
                //bs.Filter = "[رقم الحساب] like  '" + textBox7.Text + "%'" + " AND [البيان] =  '" + Descp.Text + "' ";
                ultraGrid1.DataSource = bs;
               

                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();

                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[0].Value.ToString() != string.Empty
                                  select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
                decimal x, y, z;
                x = Convert.ToDecimal(textBox3.Text);
                y = Convert.ToDecimal(textBox4.Text);
                z = Math.Round(x - y);
                textBox10.Text = Convert.ToString(z);
                try
                {
                    textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                      where row.Cells[1].Value.ToString() != string.Empty
                                      select Convert.ToInt32(row.Cells[1].Value)).Distinct().Count().ToString();
                }
                catch { }
            }
            else
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = ultraGrid1.DataSource;
                bs.Filter = "[رقم الحساب] like '" + textBox7.Text + "%'";
                //bs.Filter = "[رقم الحساب] like  '" + textBox7.Text + "%'" + " AND [البيان] Like  '" + Descp.Text + "%' ";
                //bs.Filter = "[رقم الحساب] like  '" + textBox7.Text + "%'" + " AND [البيان] =  '" + Descp.Text + "' ";
                ultraGrid1.DataSource = bs;
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();

                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[0].Value.ToString() != string.Empty
                                  select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
                decimal x, y, z;
                x = Convert.ToDecimal(textBox3.Text);
                y = Convert.ToDecimal(textBox4.Text);
                z = Math.Round(x - y);
                textBox10.Text = Convert.ToString(z);
                try
                {
                    textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                      where row.Cells[1].Value.ToString() != string.Empty
                                      select Convert.ToInt32(row.Cells[1].Value)).Distinct().Count().ToString();
                }
                catch { }
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (ultraCheckEditor4.Checked == true && ultraCheckEditor10.Checked == true)//رقم المستند مع حساب محدد
            {
                ultraGrid1.Visible = true;
                ultraGrid2.Visible = true;
                dataGridView3.Visible = false;
                TCount.Visible = false;
                BindingSource bs = new BindingSource();
                bs.DataSource = ultraGrid1.DataSource;
                //bs.Filter = "[رقم الحساب] like '" + textBox7.Text + "%'"+ "البيان like '" + Descp.Text + "%'";
                bs.Filter = "[رقم المستند] >=  '" + Convert.ToInt32(textBox1.Text) + "'" + "AND [رقم المستند] <=  '" + Convert.ToInt32(textBox2.Text) + "'"+ " AND [رقم الحساب] like  '" + textBox7.Text + "%'" ;
                //bs.Filter = "[رقم الحساب] like  '" + textBox7.Text + "%'" + " AND [البيان] =  '" + Descp.Text + "' ";
                ultraGrid1.DataSource = bs;
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[6].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[7].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();
                try
                {
                    textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                      where row.Cells[1].Value.ToString() != string.Empty
                                      select Convert.ToInt32(row.Cells[1].Value)).Distinct().Count().ToString();
                }
                catch { }
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();

                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[0].Value.ToString() != string.Empty
                                  select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
                decimal x, y, z;
                x = Convert.ToDecimal(textBox3.Text);
                y = Convert.ToDecimal(textBox4.Text);
                z = Math.Round(x - y);
                textBox10.Text = Convert.ToString(z);
            }
            else if (ultraCheckEditor3.Checked == true && ultraCheckEditor10.Checked == true)//رقم المستند مع البيان
            {
                ultraGrid1.Visible = true;
                ultraGrid2.Visible = true;
                dataGridView3.Visible = false;
                TCount.Visible = false;
                BindingSource bs = new BindingSource();
                bs.DataSource = ultraGrid1.DataSource;
               
                bs.Filter = "[رقم المستند] >=  '" + Convert.ToInt32(textBox1.Text) + "'" + "AND [رقم المستند] <=  '" + Convert.ToInt32(textBox2.Text) + "'" + " AND [البيان] =  '" + textBox7.Text + "'";
               
                ultraGrid1.DataSource = bs;
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[6].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[7].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();
                try
                {
                    textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                      where row.Cells[1].Value.ToString() != string.Empty
                                      select Convert.ToInt32(row.Cells[1].Value)).Distinct().Count().ToString();
                }
                catch { }
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();

                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[0].Value.ToString() != string.Empty
                                  select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
                decimal x, y, z;
                x = Convert.ToDecimal(textBox3.Text);
                y = Convert.ToDecimal(textBox4.Text);
                z = Math.Round(x - y);
                textBox10.Text = Convert.ToString(z);
            }
            else if (ultraCheckEditor5.Checked == true && ultraCheckEditor10.Checked == true)//رقم المستند مع المستفيد
            {
                ultraGrid1.Visible = true;
                ultraGrid2.Visible = true;
                dataGridView3.Visible = false;
                TCount.Visible = false;
                BindingSource bs = new BindingSource();
                bs.DataSource = ultraGrid1.DataSource;

                bs.Filter = "[رقم المستند] >=  '" + Convert.ToInt32(textBox1.Text) + "'" + "AND [رقم المستند] <=  '" + Convert.ToInt32(textBox2.Text) + "'" + " AND [اسم المستفيد] =  '" + UsFul.Text + "'";

                ultraGrid1.DataSource = bs;
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[6].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[7].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();
                try
                {
                    textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                      where row.Cells[1].Value.ToString() != string.Empty
                                      select Convert.ToInt32(row.Cells[1].Value)).Distinct().Count().ToString();
                }
                catch { }
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();

                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[0].Value.ToString() != string.Empty
                                  select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
                decimal x, y, z;
                x = Convert.ToDecimal(textBox3.Text);
                y = Convert.ToDecimal(textBox4.Text);
                z = Math.Round(x - y);
                textBox10.Text = Convert.ToString(z);
            }
           else  if (ultraCheckEditor9.Checked == true && ultraCheckEditor10.Checked == true)//رقم المستند مع المدين
            {
                ultraGrid1.Visible = true;
                ultraGrid2.Visible = true;
                dataGridView3.Visible = false;
                TCount.Visible = false;
                BindingSource bs = new BindingSource();
                bs.DataSource = ultraGrid1.DataSource;

                bs.Filter = "[رقم المستند] >=  '" + Convert.ToInt32(textBox1.Text) + "'" + "AND [رقم المستند] <=  '" + Convert.ToInt32(textBox2.Text) + "'" + " AND [مدين] >= '" + Convert.ToDecimal(textBox6.Text) + "'" + "AND[مدين] <= '" + Convert.ToDecimal(textBox5.Text) + "' ";

                ultraGrid1.DataSource = bs;
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[6].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[7].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();
                try
                {
                    textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                      where row.Cells[1].Value.ToString() != string.Empty
                                      select Convert.ToInt32(row.Cells[1].Value)).Distinct().Count().ToString();
                }
                catch { }
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();

                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[0].Value.ToString() != string.Empty
                                  select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
                decimal x, y, z;
                x = Convert.ToDecimal(textBox3.Text);
                y = Convert.ToDecimal(textBox4.Text);
                z = Math.Round(x - y);
                textBox10.Text = Convert.ToString(z);
            }
            else if (ultraCheckEditor11.Checked == true && ultraCheckEditor10.Checked == true)//رقم المستند مع الدائن
            {
                ultraGrid1.Visible = true;
                ultraGrid2.Visible = true;
                dataGridView3.Visible = false;
                TCount.Visible = false;
                BindingSource bs = new BindingSource();
                bs.DataSource = ultraGrid1.DataSource;

                bs.Filter = "[رقم المستند] >=  '" + Convert.ToInt32(textBox1.Text) + "'" + "AND [رقم المستند] <=  '" + Convert.ToInt32(textBox2.Text) + "'" + " AND [دائن] >= '" + Convert.ToDecimal(textBox9.Text) + "'" + "AND[دائن] <= '" + Convert.ToDecimal(textBox8.Text) + "' ";

                ultraGrid1.DataSource = bs;
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[6].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[7].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();
                try
                {
                    textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                      where row.Cells[1].Value.ToString() != string.Empty
                                      select Convert.ToInt32(row.Cells[1].Value)).Distinct().Count().ToString();
                }
                catch { }
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();

                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[0].Value.ToString() != string.Empty
                                  select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
                decimal x, y, z;
                x = Convert.ToDecimal(textBox3.Text);
                y = Convert.ToDecimal(textBox4.Text);
                z = Math.Round(x - y);
                textBox10.Text = Convert.ToString(z);
            }
            else//رقم المستند فقط
            {
                ultraGrid1.Visible = true;
                ultraGrid2.Visible = true;
                dataGridView3.Visible = false;
                TCount.Visible = false;
                BindingSource bs = new BindingSource();
                bs.DataSource = ultraGrid1.DataSource;
                //bs.Filter = "[رقم الحساب] like '" + textBox7.Text + "%'"+ "البيان like '" + Descp.Text + "%'";
                bs.Filter = "[رقم المستند] >=  '" + Convert.ToInt32(textBox1.Text) + "'" + "AND [رقم المستند] <=  '" + Convert.ToInt32(textBox2.Text) + "' ";
                //bs.Filter = "[رقم الحساب] like  '" + textBox7.Text + "%'" + " AND [البيان] =  '" + Descp.Text + "' ";
                ultraGrid1.DataSource = bs;
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[6].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[7].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();
                try
                {
                    textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                      where row.Cells[1].Value.ToString() != string.Empty
                                      select Convert.ToInt32(row.Cells[1].Value)).Distinct().Count().ToString();
                }
                catch { }
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();

                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[0].Value.ToString() != string.Empty
                                  select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
                decimal x, y, z;
                x = Convert.ToDecimal(textBox3.Text);
                y = Convert.ToDecimal(textBox4.Text);
                z = Math.Round(x - y);
                textBox10.Text = Convert.ToString(z);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            try
            {
                ultraGrid1.Visible = true;
                ultraGrid2.Visible = true;
                dataGridView3.Visible = false;
                TCount.Visible = false;
                BindingSource bs = new BindingSource();
                bs.DataSource = ultraGrid1.DataSource;
                //bs.Filter = "[رقم الحساب] like '" + textBox7.Text + "%'"+ "البيان like '" + Descp.Text + "%'";
                bs.Filter = "[دائن] >=  '" + Convert.ToDecimal(textBox9.Text) + "'" + "AND [دائن] <=  '" + Convert.ToDecimal(textBox8.Text) + "' ";
                //bs.Filter = "[رقم الحساب] like  '" + textBox7.Text + "%'" + " AND [البيان] =  '" + Descp.Text + "' ";
                ultraGrid1.DataSource = bs;
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[6].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[7].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();
                try
                {
                    textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                      where row.Cells[1].Value.ToString() != string.Empty
                                      select Convert.ToInt32(row.Cells[1].Value)).Distinct().Count().ToString();
                }
                catch { }
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();

                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[0].Value.ToString() != string.Empty
                                  select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
                decimal x, y, z;
                x = Convert.ToDecimal(textBox3.Text);
                y = Convert.ToDecimal(textBox4.Text);
                z = Math.Round(x - y);
                textBox10.Text = Convert.ToString(z);
            }
            catch { }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            ultraGrid1.Visible = true;
            ultraGrid2.Visible = true;
            dataGridView3.Visible = false;
            TCount.Visible = false;
            BindingSource bs = new BindingSource();
            bs.DataSource = ultraGrid1.DataSource;
            //bs.Filter = "[رقم الحساب] like '" + textBox7.Text + "%'"+ "البيان like '" + Descp.Text + "%'";
            bs.Filter = "[مدين] >=  '" + Convert.ToDecimal(textBox6.Text) + "'" + "AND [مدين] <=  '" + Convert.ToDecimal(textBox5.Text) + "' ";
            //bs.Filter = "[رقم الحساب] like  '" + textBox7.Text + "%'" + " AND [البيان] =  '" + Descp.Text + "' ";
            ultraGrid1.DataSource = bs;
            textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[6].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
            textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[7].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();
            try
            {
                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[1].Value.ToString() != string.Empty
                                  select Convert.ToInt32(row.Cells[1].Value)).Distinct().Count().ToString();
            }
            catch { }
            textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[0].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[5].Value)).Sum().ToString();
            textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[0].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();

            textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                              where row.Cells[0].Value.ToString() != string.Empty
                              select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
            decimal x, y, z;
            x = Convert.ToDecimal(textBox3.Text);
            y = Convert.ToDecimal(textBox4.Text);
            z = Math.Round(x - y);
            textBox10.Text = Convert.ToString(z);
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            ultraGrid1.Visible = true;
            ultraGrid2.Visible = true;
            dataGridView3.Visible = false;
            TCount.Visible = false;
            BindingSource bs = new BindingSource();
            bs.DataSource = ultraGrid1.DataSource;
            bs.Filter = " [الأمر] like '" + Order.Text + "%'";
            ultraGrid1.DataSource = bs;
            textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[6].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
            textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[7].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();
            try
            {
                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[1].Value.ToString() != string.Empty
                                  select Convert.ToInt32(row.Cells[1].Value)).Distinct().Count().ToString();
            }
            catch { }
            textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[0].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[5].Value)).Sum().ToString();
            textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[0].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();

            textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                              where row.Cells[0].Value.ToString() != string.Empty
                              select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
            decimal x, y, z;
            x = Convert.ToDecimal(textBox3.Text);
            y = Convert.ToDecimal(textBox4.Text);
            z = Math.Round(x - y);
            textBox10.Text = Convert.ToString(z);
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            ultraGrid1.Visible = true;
            ultraGrid2.Visible = true;
            dataGridView3.Visible = false;
            TCount.Visible = false;
            BindingSource bs = new BindingSource();
            bs.DataSource = ultraGrid1.DataSource;
            bs.Filter = "[رقم الأمر] like '" + textEdit1.Text + "%'";
            ultraGrid1.DataSource = bs;
            textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[6].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
            textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[7].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();
            try
            {
                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[1].Value.ToString() != string.Empty
                                  select Convert.ToInt32(row.Cells[1].Value)).Distinct().Count().ToString();
            }
            catch { }
            textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[0].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[5].Value)).Sum().ToString();
            textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[0].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();

            textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                              where row.Cells[0].Value.ToString() != string.Empty
                              select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
            decimal x, y, z;
            x = Convert.ToDecimal(textBox3.Text);
            y = Convert.ToDecimal(textBox4.Text);
            z = Math.Round(x - y);
            textBox10.Text = Convert.ToString(z);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            ultraGrid1.Visible = true;
            ultraGrid2.Visible = true;
            dataGridView3.Visible = false;
            TCount.Visible = false;
            if (ultraCheckEditor3.Checked == true)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = ultraGrid1.DataSource;
                //bs.Filter = "[رقم الحساب] like '" + textBox7.Text + "%'"+ "البيان like '" + Descp.Text + "%'";
                bs.Filter = "[اسم المستفيد] like  '" + UsFul.Text + "%'" + " AND [البيان] Like  '" + Descp.Text + "%' ";

                ultraGrid1.DataSource = bs;
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[6].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[7].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();
                try
                {
                    textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                      where row.Cells[1].Value.ToString() != string.Empty
                                      select Convert.ToInt32(row.Cells[1].Value)).Distinct().Count().ToString();
                }
                catch { }
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();

                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[0].Value.ToString() != string.Empty
                                  select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
                decimal x, y, z;
                x = Convert.ToDecimal(textBox3.Text);
                y = Convert.ToDecimal(textBox4.Text);
                z = Math.Round(x - y);
                textBox10.Text = Convert.ToString(z);
            }
            if (ultraCheckEditor3.Checked == true && ultraCheckEditor4.Checked == true)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = ultraGrid1.DataSource;
                //bs.Filter = "[رقم الحساب] like '" + textBox7.Text + "%'"+ "البيان like '" + Descp.Text + "%'";
                bs.Filter = "[اسم المستفيد] like  '" + UsFul.Text + "%'" + " AND [البيان] Like  '" + Descp.Text + "%' " + " AND [رقم الحساب] Like  '" + textBox7.Text + "%' ";
                //bs.Filter = "[رقم الحساب] like  '" + textBox7.Text + "%'" + " AND [البيان] =  '" + Descp.Text + "' ";
                ultraGrid1.DataSource = bs;
                if (bs == null)
                {
                    MessageBox.Show("لا توجد بيانات متطابقة");
                }
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[6].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[7].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();
                try
                {
                    textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                      where row.Cells[1].Value.ToString() != string.Empty
                                      select Convert.ToInt32(row.Cells[1].Value)).Distinct().Count().ToString();
                }
                catch { }
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();

                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[0].Value.ToString() != string.Empty
                                  select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
                decimal x, y, z;
                x = Convert.ToDecimal(textBox3.Text);
                y = Convert.ToDecimal(textBox4.Text);
                z = Math.Round(x - y);
                textBox10.Text = Convert.ToString(z);
            }
            if (ultraCheckEditor4.Checked == true)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = ultraGrid1.DataSource;
                //bs.Filter = "[رقم الحساب] like '" + textBox7.Text + "%'"+ "البيان like '" + Descp.Text + "%'";
                bs.Filter = "[اسم المستفيد] like  '" + UsFul.Text + "%'" + " AND [رقم الحساب] Like  '" + textBox7.Text + "%' ";
                //bs.Filter = "[رقم الحساب] like  '" + textBox7.Text + "%'" + " AND [البيان] =  '" + Descp.Text + "' ";
                ultraGrid1.DataSource = bs;
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[6].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[7].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();
                try
                {
                    textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                      where row.Cells[1].Value.ToString() != string.Empty
                                      select Convert.ToInt32(row.Cells[1].Value)).Distinct().Count().ToString();
                }
                catch { }
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();

                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[0].Value.ToString() != string.Empty
                                  select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
                decimal x, y, z;
                x = Convert.ToDecimal(textBox3.Text);
                y = Convert.ToDecimal(textBox4.Text);
                z = Math.Round(x - y);
                textBox10.Text = Convert.ToString(z);
            }
            else
            {
                BindingSource bs = new BindingSource();


                bs.DataSource = ultraGrid1.DataSource;
                bs.Filter = "[اسم المستفيد] like '" + UsFul.Text + "%'";
                ultraGrid1.DataSource = bs;
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[6].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[7].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();
                try
                {
                    textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                      where row.Cells[1].Value.ToString() != string.Empty
                                      select Convert.ToInt32(row.Cells[1].Value)).Distinct().Count().ToString();
                }
                catch { }
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();

                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[0].Value.ToString() != string.Empty
                                  select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
                decimal x, y, z;
                x = Convert.ToDecimal(textBox3.Text);
                y = Convert.ToDecimal(textBox4.Text);
                z = Math.Round(x - y);
                textBox10.Text = Convert.ToString(z);
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            ultraGrid1.Visible = true;
            ultraGrid2.Visible = true;
            dataGridView3.Visible = false;
            TCount.Visible = false;
            if (ultraCheckEditor3.Checked == true)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = ultraGrid1.DataSource;
                //bs.Filter = "[رقم الحساب] like '" + textBox7.Text + "%'"+ "البيان like '" + Descp.Text + "%'";
                bs.Filter = "[التصنيف] like  '" + comboBox2.Text + "%'" + " AND [البيان] Like  '" + Descp.Text + "%' ";

                ultraGrid1.DataSource = bs;
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[6].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[7].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();
                try
                {
                    textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                      where row.Cells[1].Value.ToString() != string.Empty
                                      select Convert.ToInt32(row.Cells[1].Value)).Distinct().Count().ToString();
                }
                catch { }
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();

                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[0].Value.ToString() != string.Empty
                                  select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
                decimal x, y, z;
                x = Convert.ToDecimal(textBox3.Text);
                y = Convert.ToDecimal(textBox4.Text);
                z = Math.Round(x - y);
                textBox10.Text = Convert.ToString(z);
            }
            if (ultraCheckEditor3.Checked == true && ultraCheckEditor4.Checked == true && ultraCheckEditor5.Checked == true)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = ultraGrid1.DataSource;
                //bs.Filter = "[رقم الحساب] like '" + textBox7.Text + "%'"+ "البيان like '" + Descp.Text + "%'";
                bs.Filter = "[اسم المستفيد] like  '" + UsFul.Text + "%'" + " AND [البيان] Like  '" + Descp.Text + "%' " + " AND [رقم الحساب] Like  '" + textBox7.Text + "%' " + " AND [التصنيف] like '" + comboBox2.Text + "%'";
                //bs.Filter = "[رقم الحساب] like  '" + textBox7.Text + "%'" + " AND [البيان] =  '" + Descp.Text + "' ";
                ultraGrid1.DataSource = bs;
                if (bs == null)
                {
                    MessageBox.Show("لا توجد بيانات متطابقة");
                }
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[6].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[7].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();
                try
                {
                    textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                      where row.Cells[1].Value.ToString() != string.Empty
                                      select Convert.ToInt32(row.Cells[1].Value)).Distinct().Count().ToString();
                }
                catch { }
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();

                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[0].Value.ToString() != string.Empty
                                  select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
                decimal x, y, z;
                x = Convert.ToDecimal(textBox3.Text);
                y = Convert.ToDecimal(textBox4.Text);
                z = Math.Round(x - y);
                textBox10.Text = Convert.ToString(z);
            }
            if (ultraCheckEditor3.Checked == true && ultraCheckEditor4.Checked == true)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = ultraGrid1.DataSource;
                //bs.Filter = "[رقم الحساب] like '" + textBox7.Text + "%'"+ "البيان like '" + Descp.Text + "%'";
                bs.Filter = "[البيان] like  '" + Descp.Text + "%'" + " AND [رقم الحساب] Like  '" + textBox7.Text + "%' " + " AND [التصنيف] like '" + comboBox2.Text + "%'";
                //bs.Filter = "[رقم الحساب] like  '" + textBox7.Text + "%'" + " AND [البيان] =  '" + Descp.Text + "' ";
                ultraGrid1.DataSource = bs;
                if (bs == null)
                {
                    MessageBox.Show("لا توجد بيانات متطابقة");
                }
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[6].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[7].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();
                try
                {
                    textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                      where row.Cells[1].Value.ToString() != string.Empty
                                      select Convert.ToInt32(row.Cells[1].Value)).Distinct().Count().ToString();
                }
                catch { }
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();

                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[0].Value.ToString() != string.Empty
                                  select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
                decimal x, y, z;
                x = Convert.ToDecimal(textBox3.Text);
                y = Convert.ToDecimal(textBox4.Text);
                z = Math.Round(x - y);
                textBox10.Text = Convert.ToString(z);
            }
            if (ultraCheckEditor4.Checked == true)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = ultraGrid1.DataSource;
                //bs.Filter = "[رقم الحساب] like '" + textBox7.Text + "%'"+ "البيان like '" + Descp.Text + "%'";
                bs.Filter = "[رقم الحساب] like  '" + textBox7.Text + "%'" + " AND [التصنيف] like '" + comboBox2.Text + "%'";
                //bs.Filter = "[رقم الحساب] like  '" + textBox7.Text + "%'" + " AND [البيان] =  '" + Descp.Text + "' ";
                ultraGrid1.DataSource = bs;
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[6].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[7].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();
                try
                {
                    textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                      where row.Cells[1].Value.ToString() != string.Empty
                                      select Convert.ToInt32(row.Cells[1].Value)).Distinct().Count().ToString();
                }
                catch { }
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();

                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[0].Value.ToString() != string.Empty
                                  select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
                decimal x, y, z;
                x = Convert.ToDecimal(textBox3.Text);
                y = Convert.ToDecimal(textBox4.Text);
                z = Math.Round(x - y);
                textBox10.Text = Convert.ToString(z);
            }
            else
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = ultraGrid1.DataSource;
                bs.Filter = "[التصنيف] like '" + comboBox2.Text + "%'";
                ultraGrid1.DataSource = bs;
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[6].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[7].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();
                try
                {
                    textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                      where row.Cells[1].Value.ToString() != string.Empty
                                      select Convert.ToInt32(row.Cells[1].Value)).Distinct().Count().ToString();
                }
                catch { }
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[5].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[0].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();

                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[0].Value.ToString() != string.Empty
                                  select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
                decimal x, y, z;
                x = Convert.ToDecimal(textBox3.Text);
                y = Convert.ToDecimal(textBox4.Text);
                z = Math.Round(x - y);
                textBox10.Text = Convert.ToString(z);
            }

        }

        private void ultraGrid1_MouseClick(object sender, MouseEventArgs e)
        {

            if (ultraGrid1.ActiveRow != null)
            {
                UltraGridRow currentRow = ultraGrid1.ActiveRow;
                string DateValue = currentRow.Cells[1].Value.ToString();
                decimal RestrictionNumberValue = Convert.ToDecimal(currentRow.Cells[0].Value.ToString());
                this.benifaryTableAdapter.Fill(this.finaSearch.Benifary, DateValue.ToString(), RestrictionNumberValue);
            }
            else
            {
                ultraGrid2.Rows.Refresh(Infragistics.Win.UltraWinGrid.RefreshRow.RefreshDisplay);
            }
        }

        private void ultraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            ultraGrid1.Visible = false;
            ultraGrid2.Visible = false;
            dataGridView3.Visible = true;
            TCount.Visible = true;

            this.totalAccRestrByUserTableAdapter.Fill(this.dataSet1.TotalAccRestrByUser, DateTime.Parse(radDateTimePicker1.Value.ToShortDateString()), DateTime.Parse(radDateTimePicker2.Value.ToShortDateString()), int.Parse(comboBox6.SelectedValue.ToString()), 1, 9);
            //this.totalAccRestrByUserTableAdapter.Fill(this.dataSet1.TotalAccRestrByUser, DateTime.Parse(radDateTimePicker1.Value.ToShortDateString()), DateTime.Parse(radDateTimePicker2.Value.ToShortDateString()), 2092, 1, 9);

            TCount.Text = dataGridView3.Rows.Count.ToString() + " " + " " + "مستند";
            textBox2.Text = "0";
            textBox3.Text = "0";
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            ultraGrid1.Visible = true;
            ultraGrid2.Visible = true;
            dataGridView3.Visible = false;
            TCount.Visible = false;
            BindingSource bs = new BindingSource();
            bs.DataSource = ultraGrid1.DataSource;
            bs.Filter = "[مركز الصرف] like '" + exCenter.Text + "%'";
            ultraGrid1.DataSource = bs;
            textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[6].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
            textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[7].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();
            try
            {
                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[1].Value.ToString() != string.Empty
                                  select Convert.ToInt32(row.Cells[1].Value)).Distinct().Count().ToString();
            }
            catch { }
            textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[0].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[5].Value)).Sum().ToString();
            textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[0].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();

            textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                              where row.Cells[0].Value.ToString() != string.Empty
                              select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
            decimal x, y, z;
            x = Convert.ToDecimal(textBox3.Text);
            y = Convert.ToDecimal(textBox4.Text);
            z = Math.Round(x - y);
            textBox10.Text = Convert.ToString(z);
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            ultraGrid1.Visible = true;
            ultraGrid2.Visible = true;
            dataGridView3.Visible = false;
            TCount.Visible = false;
            BindingSource bs = new BindingSource();
            bs.DataSource = ultraGrid1.DataSource;
            bs.Filter = "[مركز المسؤلية] like '" + Respo.Text + "%'";
            ultraGrid1.DataSource = bs;
            textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[6].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
            textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[7].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();
            try
            {
                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[1].Value.ToString() != string.Empty
                                  select Convert.ToInt32(row.Cells[1].Value)).Distinct().Count().ToString();
            }
            catch { }
            textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[0].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[5].Value)).Sum().ToString();
            textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[0].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();

            textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                              where row.Cells[0].Value.ToString() != string.Empty
                              select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
            decimal x, y, z;
            x = Convert.ToDecimal(textBox3.Text);
            y = Convert.ToDecimal(textBox4.Text);
            z = Math.Round(x - y);
            textBox10.Text = Convert.ToString(z);
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

        private void Order_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                try
                {
                    FindOrder f = new FindOrder();
                    f.ShowDialog();
                    Order.Text = FindOrder.SelectedRow.Cells[1].Value.ToString();
                    //textBox7.Text = FindOrder.SelectedRow.Cells[0].Value.ToString();
                    textEdit1.Text = FindOrder.SelectedRow.Cells[2].Value.ToString();
                    //dateTimePicker2.Text = FindOrder.SelectedRow.Cells[3].Value.ToString();
                    
                }
                catch { }
            }
            if (e.KeyCode == Keys.Enter)
            {
                textEdit1.SelectAll();
                textEdit1.Focus();
            }
        }

        private void ultraGrid1_FilterRow(object sender, FilterRowEventArgs e)
        {
            //textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
            //                 where row.Cells[6].Value.ToString() != string.Empty
            //                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
            //textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
            //                 where row.Cells[7].Value.ToString() != string.Empty
            //                 select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();
            //try
            //{
            //    textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
            //                      where row.Cells[1].Value.ToString() != string.Empty
            //                      select Convert.ToInt32(row.Cells[1].Value)).Distinct().Count().ToString();
            //}
            //catch { }
            //textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
            //                 where row.Cells[0].Value.ToString() != string.Empty
            //                 select Convert.ToDouble(row.Cells[5].Value)).Sum().ToString();
            //textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
            //                 where row.Cells[0].Value.ToString() != string.Empty
            //                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();

            //textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
            //                  where row.Cells[0].Value.ToString() != string.Empty
            //                  select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
            //decimal x, y, z;
            //x = Convert.ToDecimal(textBox3.Text);
            //y = Convert.ToDecimal(textBox4.Text);
            //z = Math.Round(x - y);
            //textBox10.Text = Convert.ToString(z);
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                FindAccount f = new FindAccount();


                f.ShowDialog();


                textBox7.Text = FindAccount.SelectedRow.Cells
          [0].Value.ToString();
           
                

            }
            if (e.KeyCode == Keys.Enter)
            {
                Descp.SelectAll();
                Descp.Focus();
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
                    Descp.Text = FindCatregory.SelectedRow.Cells[1].Value?.ToString() ?? DBNull.Value.ToString();
                  
                }
                catch { }
            }
            if (e.KeyCode == Keys.Enter)
            {
                exCenter.SelectAll();
                exCenter.Focus();
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
                   
                    if (FindUsefl.SelectedRow != null)
                    {
                        UsFul.Text = FindUsefl.SelectedRow.Cells[1].Value.ToString();
                      
                    }
                   
                }
                catch { }

            }
            if (e.KeyCode == Keys.Enter)
            {
                textBox9.SelectAll();
                textBox9.Focus();
            }
        }

        private void Respo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down )
            {
                try
                {
                    FindRespo f = new FindRespo();
                    f.ShowDialog();
                    Respo.Text = FindRespo.SelectedRow.Cells[1].Value.ToString();
                   
                    if (FindRespo.SelectedRow.Cells[1].Value == null)
                    {
                        Respo.Text = DBNull.Value.ToString();
                      
                    }
                  
                }
                catch { }
            }
            if (e.KeyCode == Keys.Enter)
            {
                textBox9.SelectAll();
                textBox9.Focus();
            }
        }

        private void ultraCheckEditor3_CheckedChanged(object sender, EventArgs e)
        {
            if(ultraCheckEditor3.Checked==true )
            {
                ultraCheckEditor3.BackColor = Color.Yellow;
            }
            else
            {
                ultraCheckEditor3.BackColor = Color.Transparent;
            }
        }

        private void ultraCheckEditor4_CheckedChanged(object sender, EventArgs e)
        {
            if (ultraCheckEditor4.Checked == true)
            {
                ultraCheckEditor4.BackColor = Color.Yellow;
            }
            else
            {
                ultraCheckEditor4.BackColor = Color.Transparent;
            }
        }

        private void ultraCheckEditor5_CheckedChanged(object sender, EventArgs e)
        {
            if (ultraCheckEditor5.Checked == true)
            {
                ultraCheckEditor5.BackColor = Color.Yellow;
            }
            else
            {
                ultraCheckEditor5.BackColor = Color.Transparent;
            }
        }

        private void ultraCheckEditor7_CheckedChanged(object sender, EventArgs e)
        {
            if (ultraCheckEditor7.Checked == true)
            {
                ultraCheckEditor7.BackColor = Color.Yellow;
            }
            else
            {
                ultraCheckEditor7.BackColor = Color.Transparent;
            }
        }

        private void ultraCheckEditor8_CheckedChanged(object sender, EventArgs e)
        {
            if (ultraCheckEditor8.Checked == true)
            {
                ultraCheckEditor8.BackColor = Color.Yellow;
            }
            else
            {
                ultraCheckEditor8.BackColor = Color.Transparent;
            }
        }

        private void ultraCheckEditor9_CheckedChanged(object sender, EventArgs e)
        {
            if (ultraCheckEditor9.Checked == true)
            {
                ultraCheckEditor9.BackColor = Color.Yellow;
            }
            else
            {
                ultraCheckEditor9.BackColor = Color.Transparent;
            }
        }

        private void ultraCheckEditor11_CheckedChanged(object sender, EventArgs e)
        {
            if (ultraCheckEditor11.Checked == true)
            {
                ultraCheckEditor11.BackColor = Color.Yellow;
            }
            else
            {
                ultraCheckEditor11.BackColor = Color.Transparent;
            }
        }

        private void ultraCheckEditor10_CheckedChanged(object sender, EventArgs e)
        {
            if (ultraCheckEditor10.Checked == true)
            {
                ultraCheckEditor10.BackColor = Color.Yellow;
            }
            else
            {
                ultraCheckEditor10.BackColor = Color.Transparent;
            }
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            string loc = "\\Search.xlsx";
           
            ultraGridExcelExporter1.Export(this.ultraGrid1, "\\Search.xlsx");
            Process.Start(loc);

        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            GetSearchDateRestrictionAll();
            this.tbl_FinanctialSearchTableAdapter.Fill(this.finaSearch.Tbl_FinanctialSearch, Program.GlbV_UserName.ToString());
           
            try
            {
                textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[6].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();
                textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                 where row.Cells[7].Value.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[7].Value)).Sum().ToString();
                textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                                  where row.Cells[1].Value.ToString() != string.Empty
                                  select Convert.ToInt32(row.Cells[1].Value)).Distinct().Count().ToString();
            }
            catch { }
            textBox3.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[0].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[5].Value)).Sum().ToString();
            textBox4.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                             where row.Cells[0].Value.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[6].Value)).Sum().ToString();

            textBox11.Text = (from Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows
                              where row.Cells[0].Value.ToString() != string.Empty
                              select Convert.ToDouble(row.Cells[0].Value)).Distinct().Count().ToString();
            decimal x, y, z;
            x = Convert.ToDecimal(textBox3.Text);
            y = Convert.ToDecimal(textBox4.Text);
            z = Math.Round(x - y);
            textBox10.Text = Convert.ToString(z);
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter )
            {
                textBox8.SelectAll();
                textBox8.Focus();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.SelectAll();
                textBox5.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.SelectAll();
                textBox2.Focus();
            }
        }

        private void radDateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                radDateTimePicker2.Focus();
            }
        }

        private void radDateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox7.SelectAll();
                textBox7.Focus();
            }
        }

        private void exCenter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UsFul.SelectAll();
                UsFul.Focus();
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UsFul.SelectAll();
                UsFul.Focus();
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            
if (e.KeyCode == Keys.Enter)
            {
                textBox6.SelectAll();
                textBox6.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.SelectAll();
                textBox1.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Order.SelectAll();
                Order.Focus();
            }
        }

        private void textEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                simpleButton15.Focus();
            }
        }

        private void ultraGrid1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            Forms.ProcessingForms.Res_Frm f = new Res_Frm();
            //try
            //{
            f.comboBox3.SelectedValue = ultraGrid1.ActiveRow.Cells[20].Value.ToString();
            f.Restriction_NO.Text = ultraGrid1.ActiveRow.Cells[0].Value.ToString();
                f.textBox21.Text = "X";
                f.checkBox15.Checked = true;
                switch (ultraGrid1.ActiveRow.Cells[2].Value.ToString())
                {
                    case "عمليات":
                        f.comboBox1.Text = "عمليات";
                        f.label49.Text = f.comboBox1.Text;
                        f.comboBox5.Text = f.label49.Text;
                        break;
                    case "مدفوعات":
                        f.comboBox1.Text = "مدفوعات";
                        f.label49.Text = f.comboBox1.Text;
                        f.comboBox5.Text = f.label49.Text;
                        break;
                    case "تسويات - عمليات":
                        f.comboBox1.Text = "تسويات";
                        f.label49.Text = f.comboBox1.Text;
                        f.comboBox5.Text = f.label49.Text;
                        break;
                    case "مقبوضات - نقدي":
                        f.comboBox1.Text = "مقبوضات";
                        f.label49.Text = f.comboBox1.Text;
                        f.comboBox5.Text = f.label49.Text;
                        break;
                    case "قيد افتتاحي  - ميزانية":
                        f.comboBox1.Text = "قيد افتتاحي";
                        f.label49.Text = f.comboBox1.Text;
                        f.comboBox5.Text = f.label49.Text;
                        break;
                    case "عمليات 30 -6 - استحقاق ":
                        f.comboBox1.Text = "عمليات 30-6";
                        f.label49.Text = f.comboBox1.Text;
                        f.comboBox5.Text = f.label49.Text;
                        break;
                    case "ملحق 1 - استحقاق ":
                        f.comboBox1.Text = "ملحق1";
                        f.label49.Text = f.comboBox1.Text;
                        f.comboBox5.Text = f.label49.Text;
                        break;
                    case "ملحق 2 - استحقاق ":
                        f.comboBox1.Text = "ملحق 2";
                        f.label49.Text = f.comboBox1.Text;
                        f.comboBox5.Text = f.label49.Text;
                        break;
                    case "ملحق 3 - استحقاق":
                        f.comboBox1.Text = "ملحق 3";
                        f.label49.Text = f.comboBox1.Text;
                        f.comboBox5.Text = f.label49.Text;
                        break;
                    default:
                       
                        break;

                }
                f.label49.Text = f.comboBox1.Text;
                f.comboBox5.Text = f.label49.Text;
            splashScreenManager1.CloseWaitForm();
            f.ShowDialog();
            //}
            //catch (Exception ex)
            //{
            //    splashScreenManager1.CloseWaitForm();
            //    // التعامل مع الخطأ، عرض رسالة للمستخدم أو تسجيل الخطأ
            //    MessageBox.Show($"حدث خطأ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}
