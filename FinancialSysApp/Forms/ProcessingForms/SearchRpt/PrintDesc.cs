using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialSysApp.Forms.ProcessingForms.SearchRpt
{
    public partial class PrintDesc : Form
    {
        public PrintDesc()
        {
            InitializeComponent();
        }
        private void GetReportData()//موقف التوريد تحليلى
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();

            
            string query = @"
        SELECT        Tbl_AccountingRestriction.Restriction_NO, Tbl_AccountingRestriction.Restriction_Date, Tbl_Accounting_Guid.Name, Tbl_Accounting_Guid.Account_NO, Tbl_AccountingRestrictionItems.Debit_Value, 
                         Tbl_AccountingRestrictionItems.Credit_Value, TBL_Document.Document_NO, Tbl_DocumentCategory.Name AS DescR, Tbl_Beneficiary.Name AS Beneficiary, Tbl_BeneficiaryKind.Name AS BeneficiaryKind, 
                         Tbl_ExchangeCenter.Name AS ExCenter, Tbl_OrderKind.Name AS OrderKind, Tbl_Order.Order_NO, Tbl_Order.Order_Date, Tbl_Handler.Name AS Handler, Tbl_Management.Name AS Managament, 
                         Tbl_ResponspilityCenters.Name AS ResponspilityCenter, Tbl_RestrictionItemsCategory.Name AS ResCategory, Tbl_AccountingRestrictions_Kind.Name AS Day, Tbl_AccountingRestrictions_Kind.ID AS DayID, 
                         Tbl_DocumentCategory.Parent_ID
FROM            Tbl_Beneficiary LEFT OUTER JOIN
                         Tbl_BeneficiaryKind ON Tbl_Beneficiary.BeneficiaryKind_ID = Tbl_BeneficiaryKind.ID RIGHT OUTER JOIN
                         Tbl_Order INNER JOIN
                         Tbl_OrderKind ON Tbl_Order.OrderKind_ID = Tbl_OrderKind.ID RIGHT OUTER JOIN
                         Tbl_Handler RIGHT OUTER JOIN
                         Tbl_AccountingRestrictionItems INNER JOIN
                         Tbl_Accounting_Guid ON Tbl_Accounting_Guid.ID = Tbl_AccountingRestrictionItems.Accounting_Guid_ID INNER JOIN
                         Tbl_AccountingRestrictions_Kind ON Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID = Tbl_AccountingRestrictions_Kind.ID RIGHT OUTER JOIN
                         Tbl_Description_SupplyeAccount_Rpt ON Tbl_Accounting_Guid.Account_NO COLLATE Arabic_100_CI_AS_KS = Tbl_Description_SupplyeAccount_Rpt.AccNumber RIGHT OUTER JOIN
                         TBL_Document INNER JOIN
                         Tbl_AccountingRestriction ON TBL_Document.ID = Tbl_AccountingRestriction.Document_ID ON Tbl_AccountingRestrictions_Kind.ID = Tbl_AccountingRestriction.AccountingRestrictionKind_ID AND 
                         Tbl_AccountingRestrictionItems.AccountingRestriction_ID = Tbl_AccountingRestriction.ID LEFT OUTER JOIN
                         Tbl_RestrictionItemsCategory ON Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = Tbl_RestrictionItemsCategory.ID LEFT OUTER JOIN
                         Tbl_DocumentCategory ON TBL_Document.DocumentCategory_ID = Tbl_DocumentCategory.ID LEFT OUTER JOIN
                         Tbl_ResponspilityCenters ON TBL_Document.responspilityID = Tbl_ResponspilityCenters.ID LEFT OUTER JOIN
                         Tbl_Management ON TBL_Document.Management_ID = Tbl_Management.ID ON Tbl_Handler.ID = TBL_Document.Handler_ID ON Tbl_Order.ID = TBL_Document.Order_ID ON 
                         Tbl_Beneficiary.ID = TBL_Document.Beneficiary_ID LEFT OUTER JOIN
                         Tbl_ExchangeCenter ON Tbl_Management.ExchangeCenter_ID = Tbl_ExchangeCenter.ID AND TBL_Document.ExchangeCenter_ID = Tbl_ExchangeCenter.ID
WHERE        (Tbl_AccountingRestriction.Restriction_Date BETWEEN @P AND @P1) AND (Tbl_AccountingRestrictions_Kind.ID BETWEEN @i AND @i1) AND (Tbl_DocumentCategory.Parent_ID = 627)";

           
            DateTime startDate = DateTime.Parse(dateTimePicker1.Value.ToShortDateString());
            DateTime endDate = DateTime.Parse(dateTimePicker2.Value.ToShortDateString());
            int param1 = 1;
            int param2 = 10; 

          
            DataTable dataTable = new DataTable();

           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

              
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                   
                    command.Parameters.AddWithValue("@P", startDate);
                    command.Parameters.AddWithValue("@P1", endDate);
                    command.Parameters.AddWithValue("@i", param1);
                    command.Parameters.AddWithValue("@i1", param2);

                    
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

           
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataTable);
           
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.ProcessingForms.SearchRpt.Descrption_Supply.rdlc";

            ReportParameter[] parameters = new ReportParameter[6];
            parameters[0] = new ReportParameter("d", dateTimePicker1.Text);

            parameters[1] = new ReportParameter("d1", dateTimePicker2.Text);
            parameters[2] = new ReportParameter("Usr", Program.GlbV_EmpName);
            parameters[3] = new ReportParameter("unit", Program.GlbV_SysUnite);
            parameters[4] = new ReportParameter("man", Program.GlbV_Management);
            parameters[5] = new ReportParameter("Title", "تقرير موقف التوريد");
            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();

        }
        private void GetReportDataTotal()//موقف التوريد اجمالى
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();


            string query = @"
        SELECT        Tbl_AccountingRestriction.Restriction_NO, Tbl_AccountingRestriction.Restriction_Date, Tbl_Accounting_Guid.Name, Tbl_Accounting_Guid.Account_NO, Tbl_AccountingRestrictionItems.Debit_Value, 
                         Tbl_AccountingRestrictionItems.Credit_Value, TBL_Document.Document_NO, Tbl_DocumentCategory.Name AS DescR, Tbl_Beneficiary.Name AS Beneficiary, Tbl_BeneficiaryKind.Name AS BeneficiaryKind, 
                         Tbl_ExchangeCenter.Name AS ExCenter, Tbl_OrderKind.Name AS OrderKind, Tbl_Order.Order_NO, Tbl_Order.Order_Date, Tbl_Handler.Name AS Handler, Tbl_Management.Name AS Managament, 
                         Tbl_ResponspilityCenters.Name AS ResponspilityCenter, Tbl_RestrictionItemsCategory.Name AS ResCategory, Tbl_AccountingRestrictions_Kind.Name AS Day, Tbl_AccountingRestrictions_Kind.ID AS DayID, 
                         Tbl_DocumentCategory.Parent_ID
FROM            Tbl_Beneficiary LEFT OUTER JOIN
                         Tbl_BeneficiaryKind ON Tbl_Beneficiary.BeneficiaryKind_ID = Tbl_BeneficiaryKind.ID RIGHT OUTER JOIN
                         Tbl_Order INNER JOIN
                         Tbl_OrderKind ON Tbl_Order.OrderKind_ID = Tbl_OrderKind.ID RIGHT OUTER JOIN
                         Tbl_Handler RIGHT OUTER JOIN
                         Tbl_AccountingRestrictionItems INNER JOIN
                         Tbl_Accounting_Guid ON Tbl_Accounting_Guid.ID = Tbl_AccountingRestrictionItems.Accounting_Guid_ID INNER JOIN
                         Tbl_AccountingRestrictions_Kind ON Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID = Tbl_AccountingRestrictions_Kind.ID RIGHT OUTER JOIN
                         Tbl_Description_SupplyeAccount_Rpt ON Tbl_Accounting_Guid.Account_NO COLLATE Arabic_100_CI_AS_KS = Tbl_Description_SupplyeAccount_Rpt.AccNumber RIGHT OUTER JOIN
                         TBL_Document INNER JOIN
                         Tbl_AccountingRestriction ON TBL_Document.ID = Tbl_AccountingRestriction.Document_ID ON Tbl_AccountingRestrictions_Kind.ID = Tbl_AccountingRestriction.AccountingRestrictionKind_ID AND 
                         Tbl_AccountingRestrictionItems.AccountingRestriction_ID = Tbl_AccountingRestriction.ID LEFT OUTER JOIN
                         Tbl_RestrictionItemsCategory ON Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = Tbl_RestrictionItemsCategory.ID LEFT OUTER JOIN
                         Tbl_DocumentCategory ON TBL_Document.DocumentCategory_ID = Tbl_DocumentCategory.ID LEFT OUTER JOIN
                         Tbl_ResponspilityCenters ON TBL_Document.responspilityID = Tbl_ResponspilityCenters.ID LEFT OUTER JOIN
                         Tbl_Management ON TBL_Document.Management_ID = Tbl_Management.ID ON Tbl_Handler.ID = TBL_Document.Handler_ID ON Tbl_Order.ID = TBL_Document.Order_ID ON 
                         Tbl_Beneficiary.ID = TBL_Document.Beneficiary_ID LEFT OUTER JOIN
                         Tbl_ExchangeCenter ON Tbl_Management.ExchangeCenter_ID = Tbl_ExchangeCenter.ID AND TBL_Document.ExchangeCenter_ID = Tbl_ExchangeCenter.ID
WHERE        (Tbl_AccountingRestriction.Restriction_Date BETWEEN @P AND @P1) AND (Tbl_AccountingRestrictions_Kind.ID BETWEEN @i AND @i1) AND (Tbl_DocumentCategory.Parent_ID = 627)";


            DateTime startDate = DateTime.Parse(dateTimePicker1.Value.ToShortDateString());
            DateTime endDate = DateTime.Parse(dateTimePicker2.Value.ToShortDateString());
            int param1 = 1;
            int param2 = 10;


            DataTable dataTable = new DataTable();


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@P", startDate);
                    command.Parameters.AddWithValue("@P1", endDate);
                    command.Parameters.AddWithValue("@i", param1);
                    command.Parameters.AddWithValue("@i1", param2);


                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }


            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataTable);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.ProcessingForms.SearchRpt.Descrption_SupplyTotal.rdlc";

            ReportParameter[] parameters = new ReportParameter[5];
            parameters[0] = new ReportParameter("d", dateTimePicker1.Text);

            parameters[1] = new ReportParameter("d1", dateTimePicker2.Text);
            parameters[2] = new ReportParameter("Usr", Program.GlbV_EmpName);
            parameters[3] = new ReportParameter("unit", Program.GlbV_SysUnite);
            parameters[4] = new ReportParameter("man", Program.GlbV_Management);
          
            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();

        }
        private void GetReportDataPayedTota()//موقف المسدد من التوريد اجمالى
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();


            string query = @"
            SELECT Tbl_AccountingRestriction.Restriction_NO, Tbl_AccountingRestriction.Restriction_Date, Tbl_Accounting_Guid.Name, Tbl_Accounting_Guid.Account_NO, 
                   Tbl_AccountingRestrictionItems.Debit_Value, Tbl_AccountingRestrictionItems.Credit_Value, TBL_Document.Document_NO, Tbl_DocumentCategory.Name AS DescR, 
                   Tbl_Beneficiary.Name AS Beneficiary, Tbl_BeneficiaryKind.Name AS BeneficiaryKind, Tbl_ExchangeCenter.Name AS ExCenter, Tbl_OrderKind.Name AS OrderKind, 
                   Tbl_Order.Order_NO, Tbl_Order.Order_Date, Tbl_Handler.Name AS Handler, Tbl_Management.Name AS Managament, Tbl_ResponspilityCenters.Name AS ResponspilityCenter, 
                   Tbl_RestrictionItemsCategory.Name AS ResCategory, Tbl_AccountingRestrictions_Kind.Name AS Day, Tbl_AccountingRestrictions_Kind.ID AS DayID, Tbl_DocumentCategory.Parent_ID
            FROM Tbl_ExchangeCenter RIGHT OUTER JOIN Tbl_Beneficiary LEFT OUTER JOIN Tbl_BeneficiaryKind ON Tbl_Beneficiary.BeneficiaryKind_ID = Tbl_BeneficiaryKind.ID 
                 RIGHT OUTER JOIN Tbl_Order INNER JOIN Tbl_OrderKind ON Tbl_Order.OrderKind_ID = Tbl_OrderKind.ID 
                 RIGHT OUTER JOIN Tbl_AccountingRestrictionItems INNER JOIN Tbl_Accounting_Guid ON Tbl_Accounting_Guid.ID = Tbl_AccountingRestrictionItems.Accounting_Guid_ID 
                 INNER JOIN Tbl_AccountingRestrictions_Kind ON Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID = Tbl_AccountingRestrictions_Kind.ID 
                 RIGHT OUTER JOIN TBL_Document INNER JOIN Tbl_AccountingRestriction ON TBL_Document.ID = Tbl_AccountingRestriction.Document_ID 
                 ON Tbl_AccountingRestrictions_Kind.ID = Tbl_AccountingRestriction.AccountingRestrictionKind_ID AND Tbl_AccountingRestrictionItems.AccountingRestriction_ID = Tbl_AccountingRestriction.ID 
                 LEFT OUTER JOIN Tbl_RestrictionItemsCategory ON Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = Tbl_RestrictionItemsCategory.ID 
                 LEFT OUTER JOIN Tbl_DocumentCategory ON TBL_Document.DocumentCategory_ID = Tbl_DocumentCategory.ID 
                 LEFT OUTER JOIN Tbl_ResponspilityCenters ON TBL_Document.responspilityID = Tbl_ResponspilityCenters.ID 
                 LEFT OUTER JOIN Tbl_Management ON TBL_Document.Management_ID = Tbl_Management.ID 
                 LEFT OUTER JOIN Tbl_Handler ON TBL_Document.Handler_ID = Tbl_Handler.ID 
                 ON Tbl_Order.ID = TBL_Document.Order_ID ON Tbl_Beneficiary.ID = TBL_Document.Beneficiary_ID 
                 ON Tbl_ExchangeCenter.ID = Tbl_Management.ExchangeCenter_ID AND Tbl_ExchangeCenter.ID = TBL_Document.ExchangeCenter_ID
            WHERE (Tbl_AccountingRestriction.Restriction_Date BETWEEN @P AND @P1) 
                 AND (Tbl_AccountingRestrictions_Kind.ID BETWEEN @i AND @i1) 
                 AND (Tbl_Accounting_Guid.Account_NO LIKE N'1282' + N'%') 
                 AND (Tbl_DocumentCategory.Parent_ID = 627)
            ORDER BY Tbl_AccountingRestriction.Restriction_Date, Tbl_AccountingRestriction.Restriction_NO";


            DateTime startDate = DateTime.Parse(dateTimePicker1.Value.ToShortDateString());
            DateTime endDate = DateTime.Parse(dateTimePicker2.Value.ToShortDateString());
            int param1 = 1;
            int param2 = 10;


            DataTable dataTable = new DataTable();


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@P", startDate);
                    command.Parameters.AddWithValue("@P1", endDate);
                    command.Parameters.AddWithValue("@i", param1);
                    command.Parameters.AddWithValue("@i1", param2);


                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }


            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataTable);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.ProcessingForms.SearchRpt.Benef_With_Bank_Total.rdlc";

            ReportParameter[] parameters = new ReportParameter[5];
            parameters[0] = new ReportParameter("d", dateTimePicker1.Text);

            parameters[1] = new ReportParameter("d1", dateTimePicker2.Text);
            parameters[2] = new ReportParameter("Usr", Program.GlbV_EmpName);
            parameters[3] = new ReportParameter("unit", Program.GlbV_SysUnite);
            parameters[4] = new ReportParameter("man", Program.GlbV_Management);

            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();

        }
        private void PrintDesc_Load(object sender, EventArgs e)
        {
            //try
            //{
                //if (textBox1.Text == "0بيان")
                //{
                //    this.Text = "طباعة البيان";
                //    this.reportSearchTableAdapter1.FillByDescr(this.dataSet1.ReportSearchTableAdapter, Convert.ToDateTime(radDateTimePicker1.Text).ToShortDateString(), Convert.ToDateTime(radDateTimePicker2.Text).ToShortDateString(), Convert.ToInt32(d1.Text), Convert.ToInt32(d2.Text), desc.Text);
                //    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.ProcessingForms.SearchRpt.Descrption_Supply.rdlc";

                //    ReportParameter[] parameters = new ReportParameter[6];
                //    parameters[0] = new ReportParameter("d", radDateTimePicker1.Text);

                //    parameters[1] = new ReportParameter("d1", radDateTimePicker2.Text);
                //    parameters[2] = new ReportParameter("Usr", Program.GlbV_EmpName);
                //    parameters[3] = new ReportParameter("unit", Program.GlbV_SysUnite);
                //    parameters[4] = new ReportParameter("man", Program.GlbV_Management);
                //parameters[5] = new ReportParameter("Title", "تقرير عن بيان");
                //this.reportViewer1.LocalReport.SetParameters(parameters);
                //    this.reportViewer1.RefreshReport();
                //}
                //if (textBox1.Text == "بيان2")
                //{
                //    this.Text = "طباعة البيان";
                //this.reportSearchTableAdapter1.FillByDescByParentID(this.dataSet1.ReportSearchTableAdapter, Convert.ToDateTime(radDateTimePicker1.Text).ToShortDateString(), Convert.ToDateTime(radDateTimePicker2.Text).ToShortDateString(), Convert.ToInt32(d1.Text), Convert.ToInt32(d2.Text), Convert.ToInt32(desc.Text));
                //this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.ProcessingForms.SearchRpt.Descrption_Supply.rdlc";

                //    ReportParameter[] parameters = new ReportParameter[6];
                //    parameters[0] = new ReportParameter("d", radDateTimePicker1.Text);

                //    parameters[1] = new ReportParameter("d1", radDateTimePicker2.Text);
                //    parameters[2] = new ReportParameter("Usr", Program.GlbV_EmpName);
                //    parameters[3] = new ReportParameter("unit", Program.GlbV_SysUnite);
                //    parameters[4] = new ReportParameter("man", Program.GlbV_Management);
                //parameters[5] = new ReportParameter("Title", "تقرير عن ببيان");
                //this.reportViewer1.LocalReport.SetParameters(parameters);
                //    this.reportViewer1.RefreshReport();
                //}
                //if (textBox1.Text == "بيان")
                //{
                //    this.Text = "طباعة البيان";
                //this.reportSearchTableAdapter1.FillByAccont_Supp_Descr(this.dataSet1.ReportSearchTableAdapter, Convert.ToDateTime(radDateTimePicker1.Text).ToShortDateString(), Convert.ToDateTime(radDateTimePicker2.Text).ToShortDateString(), Convert.ToInt32(d1.Text), Convert.ToInt32(d2.Text));
                //this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.ProcessingForms.SearchRpt.Descrption_Supply.rdlc";

                //    ReportParameter[] parameters = new ReportParameter[6];
                //    parameters[0] = new ReportParameter("d", radDateTimePicker1.Text);

                //    parameters[1] = new ReportParameter("d1", radDateTimePicker2.Text);
                //    parameters[2] = new ReportParameter("Usr", Program.GlbV_EmpName);
                //    parameters[3] = new ReportParameter("unit", Program.GlbV_SysUnite);
                //    parameters[4] = new ReportParameter("man", Program.GlbV_Management);
                //parameters[5] = new ReportParameter("Title", "تقرير موقف التوريد");
                //this.reportViewer1.LocalReport.SetParameters(parameters);
                //    this.reportViewer1.RefreshReport();
                //}
                //if (textBox1.Text == "1بيان")
                //{
                //    this.Text = "طباعة البيان";
                //this.reportSearchTableAdapter1.FillByAccont_Supp_Descr(this.dataSet1.ReportSearchTableAdapter, Convert.ToDateTime(radDateTimePicker1.Text).ToShortDateString(), Convert.ToDateTime(radDateTimePicker2.Text).ToShortDateString(), Convert.ToInt32(d1.Text), Convert.ToInt32(d2.Text));
                //this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.ProcessingForms.SearchRpt.Descrption_SupplyTotal.rdlc";

                //    ReportParameter[] parameters = new ReportParameter[5];
                //    parameters[0] = new ReportParameter("d", radDateTimePicker1.Text);

                //    parameters[1] = new ReportParameter("d1", radDateTimePicker2.Text);
                //    parameters[2] = new ReportParameter("Usr", Program.GlbV_EmpName);
                //    parameters[3] = new ReportParameter("unit", Program.GlbV_SysUnite);
                //    parameters[4] = new ReportParameter("man", Program.GlbV_Management);
                //    this.reportViewer1.LocalReport.SetParameters(parameters);

                //    this.reportViewer1.RefreshReport();
                //}
                //if (textBox1.Text == "مستفيد")
                //{
                //    this.Text = "طباعة بيانات المستفيدين";
                //this.reportSearchTableAdapter1.FillBy1Beni_Supplyer_Description(this.dataSet1.ReportSearchTableAdapter, Convert.ToDateTime(radDateTimePicker1.Text).ToShortDateString(), Convert.ToDateTime(radDateTimePicker2.Text).ToShortDateString(), Convert.ToInt32(d1.Text), Convert.ToInt32(d2.Text));
                //this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.ProcessingForms.SearchRpt.Descrption_Supply.rdlc";

                //    ReportParameter[] parameters = new ReportParameter[5];
                //    parameters[0] = new ReportParameter("d", radDateTimePicker1.Text);

                //    parameters[1] = new ReportParameter("d1", radDateTimePicker2.Text);
                //    parameters[2] = new ReportParameter("Usr", Program.GlbV_EmpName);
                //    parameters[3] = new ReportParameter("unit", Program.GlbV_SysUnite);
                //    parameters[4] = new ReportParameter("man", Program.GlbV_Management);
                //    this.reportViewer1.LocalReport.SetParameters(parameters);
                //    this.reportViewer1.RefreshReport();
                //}
                //if (textBox1.Text == "مستفيد1")
                //{
                //    this.Text = "طباعة بيانات المستفيدين";
                //this.reportSearchTableAdapter1.FillBy1Beni_Supplyer_Description(this.dataSet1.ReportSearchTableAdapter, Convert.ToDateTime(radDateTimePicker1.Text).ToShortDateString(), Convert.ToDateTime(radDateTimePicker2.Text).ToShortDateString(), Convert.ToInt32(d1.Text), Convert.ToInt32(d2.Text));
                //this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.ProcessingForms.SearchRpt.Benef_With_Bank_Total.rdlc";

                //    ReportParameter[] parameters = new ReportParameter[5];
                //    parameters[0] = new ReportParameter("d", radDateTimePicker1.Text);

                //    parameters[1] = new ReportParameter("d1", radDateTimePicker2.Text);
                //    parameters[2] = new ReportParameter("Usr", Program.GlbV_EmpName);
                //    parameters[3] = new ReportParameter("unit", Program.GlbV_SysUnite);
                //    parameters[4] = new ReportParameter("man", Program.GlbV_Management);
                //    this.reportViewer1.LocalReport.SetParameters(parameters);
                //    this.reportViewer1.RefreshReport();
                //}

                //if (textBox1.Text == "مسؤلية")
                //{
                //    this.Text = "طباعة بيانات مراكز المسؤلية";
                //    this.reportSearchTableAdapter1.FillByDescr(this.dataSet1.ReportSearchTableAdapter, Convert.ToDateTime(radDateTimePicker1.Text).ToShortDateString(), Convert.ToDateTime(radDateTimePicker2.Text).ToShortDateString(), Convert.ToInt32(d1.Text), Convert.ToInt32(d2.Text), desc.Text);
                //    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.ProcessingForms.SearchRpt.Descrption_Supply.rdlc";

                //    ReportParameter[] parameters = new ReportParameter[5];
                //    parameters[0] = new ReportParameter("d", radDateTimePicker1.Text);

                //    parameters[1] = new ReportParameter("d1", radDateTimePicker2.Text);
                //    parameters[2] = new ReportParameter("Usr", Program.GlbV_EmpName);
                //    parameters[3] = new ReportParameter("unit", Program.GlbV_SysUnite);
                //    parameters[4] = new ReportParameter("man", Program.GlbV_Management);
                //    this.reportViewer1.LocalReport.SetParameters(parameters);
                //    this.reportViewer1.RefreshReport();
                //}
                //if (textBox1.Text == "تصنيف")
                //{
                //    this.Text = "طباعة بيانات تصنيف بنود القيد";
                //    this.reportSearchTableAdapter1.FillByDescr(this.dataSet1.ReportSearchTableAdapter, Convert.ToDateTime(radDateTimePicker1.Text).ToShortDateString(), Convert.ToDateTime(radDateTimePicker2.Text).ToShortDateString(), Convert.ToInt32(d1.Text), Convert.ToInt32(d2.Text), desc.Text);
                //    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.ProcessingForms.SearchRpt.Descrption_Supply.rdlc";

                //    ReportParameter[] parameters = new ReportParameter[5];
                //    parameters[0] = new ReportParameter("d", radDateTimePicker1.Text);

                //    parameters[1] = new ReportParameter("d1", radDateTimePicker2.Text);
                //    parameters[2] = new ReportParameter("Usr", Program.GlbV_EmpName);
                //    parameters[3] = new ReportParameter("unit", Program.GlbV_SysUnite);
                //    parameters[4] = new ReportParameter("man", Program.GlbV_Management);
                //    this.reportViewer1.LocalReport.SetParameters(parameters);
                //    this.reportViewer1.RefreshReport();
                //}
                //if (textBox1.Text == "ادارة")
                //{
                //    this.Text = "طباعة بيانات الإدارات";
                //    this.reportSearchTableAdapter1.FillByDescr(this.dataSet1.ReportSearchTableAdapter, Convert.ToDateTime(radDateTimePicker1.Text).ToShortDateString(), Convert.ToDateTime(radDateTimePicker2.Text).ToShortDateString(), Convert.ToInt32(d1.Text), Convert.ToInt32(d2.Text), desc.Text);
                //    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.ProcessingForms.SearchRpt.Descrption_Supply.rdlc";

                //    ReportParameter[] parameters = new ReportParameter[5];
                //    parameters[0] = new ReportParameter("d", radDateTimePicker1.Text);

                //    parameters[1] = new ReportParameter("d1", radDateTimePicker2.Text);
                //    parameters[2] = new ReportParameter("Usr", Program.GlbV_EmpName);
                //    parameters[3] = new ReportParameter("unit", Program.GlbV_SysUnite);
                //    parameters[4] = new ReportParameter("man", Program.GlbV_Management);
                //    this.reportViewer1.LocalReport.SetParameters(parameters);
                //    this.reportViewer1.RefreshReport();
                //}
                //if (textBox1.Text == "صرف")
                //{
                //    this.Text = "طباعة بيانات مراكز الصرف";
                //    this.reportSearchTableAdapter1.FillByDescr(this.dataSet1.ReportSearchTableAdapter, Convert.ToDateTime(radDateTimePicker1.Text).ToShortDateString(), Convert.ToDateTime(radDateTimePicker2.Text).ToShortDateString(), Convert.ToInt32(d1.Text), Convert.ToInt32(d2.Text), desc.Text);
                //    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.ProcessingForms.SearchRpt.Descrption_Supply.rdlc";

                //    ReportParameter[] parameters = new ReportParameter[5];
                //    parameters[0] = new ReportParameter("d", radDateTimePicker1.Text);

                //    parameters[1] = new ReportParameter("d1", radDateTimePicker2.Text);
                //    parameters[2] = new ReportParameter("Usr", Program.GlbV_EmpName);
                //    parameters[3] = new ReportParameter("unit", Program.GlbV_SysUnite);
                //    parameters[4] = new ReportParameter("man", Program.GlbV_Management);
                //    this.reportViewer1.LocalReport.SetParameters(parameters);
                //    this.reportViewer1.RefreshReport();
                //}
                //if (textBox1.Text == "امر")
                //{
                //    this.Text = "طباعة بيانات الأوامر";
                //    this.reportSearchTableAdapter1.FillByDescr(this.dataSet1.ReportSearchTableAdapter, Convert.ToDateTime(radDateTimePicker1.Text).ToShortDateString(), Convert.ToDateTime(radDateTimePicker2.Text).ToShortDateString(), Convert.ToInt32(d1.Text), Convert.ToInt32(d2.Text), desc.Text);
                //    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.ProcessingForms.SearchRpt.Descrption_Supply.rdlc";

                //    ReportParameter[] parameters = new ReportParameter[5];
                //    parameters[0] = new ReportParameter("d", radDateTimePicker1.Text);

                //    parameters[1] = new ReportParameter("d1", radDateTimePicker2.Text);
                //    parameters[2] = new ReportParameter("Usr", Program.GlbV_EmpName);
                //    parameters[3] = new ReportParameter("unit", Program.GlbV_SysUnite);
                //    parameters[4] = new ReportParameter("man", Program.GlbV_Management);
                //    this.reportViewer1.LocalReport.SetParameters(parameters);
                //    this.reportViewer1.RefreshReport();
                //}
                //if (textBox1.Text == "حساب")
                //{
                //    this.Text = "طباعة بيانات الحسابات";
                //    this.reportSearchTableAdapter1.FillByDescr(this.dataSet1.ReportSearchTableAdapter, Convert.ToDateTime(radDateTimePicker1.Text).ToShortDateString(), Convert.ToDateTime(radDateTimePicker2.Text).ToShortDateString(), Convert.ToInt32(d1.Text), Convert.ToInt32(d2.Text), desc.Text);
                //    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.ProcessingForms.SearchRpt.Descrption_Supply.rdlc";

                //    ReportParameter[] parameters = new ReportParameter[5];
                //    parameters[0] = new ReportParameter("d", radDateTimePicker1.Text);

                //    parameters[1] = new ReportParameter("d1", radDateTimePicker2.Text);
                //    parameters[2] = new ReportParameter("Usr", Program.GlbV_EmpName);
                //    parameters[3] = new ReportParameter("unit", Program.GlbV_SysUnite);
                //    parameters[4] = new ReportParameter("man", Program.GlbV_Management);
                //    this.reportViewer1.LocalReport.SetParameters(parameters);
                //    this.reportViewer1.RefreshReport();
                //}
            }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true )
            {
                GetReportData();
            }
            if (checkBox2.Checked == true)
            {
                GetReportDataTotal();
            }
            if (checkBox3.Checked == true)
            {
                GetReportDataPayedTota();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox1.Checked = false;
            }
        }
        //catch { }
        //finally
        //{




        //this.reportSearchTableAdapter.FillByDescr(this.financialSysDataSet.ReportSearch, Convert.ToDateTime(radDateTimePicker1.Text).ToShortDateString(), Convert.ToDateTime(radDateTimePicker2.Text).ToShortDateString(), Convert.ToInt32 (d1.Text), Convert.ToInt32(d2.Text), desc.Text);
        //ReportParameter[] parameters = new ReportParameter[2];
        //parameters[0] = new ReportParameter("d", radDateTimePicker1.Text);

        //parameters[1] = new ReportParameter("d1", radDateTimePicker2.Text );
        //this.reportViewer1.LocalReport.SetParameters(parameters);
        //this.reportViewer1.RefreshReport();



        //}

        //this.reportViewer1.RefreshReport();
    }
    }
//}
