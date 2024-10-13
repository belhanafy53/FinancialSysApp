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
using FinancialSysApp.DataBase.ModelEvents;
using FinancialSysApp.DataBase.Model;
using Microsoft.Reporting.WinForms;

namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class ExtrasFinancialYearFrm : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        public ExtrasFinancialYearFrm()
        {
            InitializeComponent();
        }
        public void getData()
        {
            List<int> checkedIDs = new List<int>();
            foreach (TreeListNode node in treeList1.GetNodeList())
            {
                if (node.CheckState == CheckState.Checked)
                {
                    int Vint_MenuPr;
                    if (int.TryParse(node.GetValue("ID").ToString(), out Vint_MenuPr))
                    {
                        checkedIDs.Add(Vint_MenuPr);
                    }
                }
            }
            DataTable dt = new DataTable();
            //cridet
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString()))
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    using (SqlCommand com = new SqlCommand(@"
                SELECT 
                    ar.Restriction_NO AS [رقم المستند],
                    ar.Restriction_Date AS [تاريخ المستند], 
                    ag.Account_NO AS [رقم الحساب], 
                   
                    ag.Name AS [اسم الحساب], 
                     
                      ari.Debit_Value AS مدين, 
                      ari.Credit_Value AS دائن, 
                    ar.FYear,

                    ag2.Account_NO AS [رقم الحساب المقابل], 
                    ag2.Name AS [اسم الحساب المقابل],
                    ari2.Debit_Value AS [مدين للحساب المقابل],
                    ari2.Credit_Value AS [دائن للحساب المقابل], 
                    dc.Name AS البيان
                FROM 
                    dbo.Tbl_AccountingRestrictions_Kind ark
                INNER JOIN
                    dbo.Tbl_AccountingRestrictionItems ari ON ark.ID = ari.AccountingRestrictionKind_ID
                INNER JOIN
                    dbo.Tbl_Accounting_Guid ag ON ari.Accounting_Guid_ID = ag.ID 
                INNER JOIN
                    dbo.Tbl_AccountingRestriction ar ON ari.AccountingRestriction_ID = ar.ID
                INNER JOIN
                    dbo.TBL_Document doc ON ar.Document_ID = doc.ID
                INNER JOIN
                    dbo.Tbl_DocumentCategory dc ON doc.DocumentCategory_ID = dc.ID
                LEFT JOIN
                    dbo.Tbl_AccountingRestrictionItems ari2 ON ar.ID = ari2.AccountingRestriction_ID AND ari2.ID <> ari.ID
                LEFT JOIN
                    dbo.Tbl_Accounting_Guid ag2 ON ari2.Accounting_Guid_ID = ag2.ID
                WHERE 
                    ar.Restriction_Date BETWEEN @Date AND @Date1
                    AND ag.Account_NO = @AccountNumber
                    AND ari2.Credit_Value > 0 AND dc.Name LIKE @Descrption 
                UNION
                SELECT 
                    ar2.Restriction_NO AS [رقم المستند],
                    ar2.Restriction_Date AS [تاريخ المستند],
                    ag1.Account_NO AS [رقم الحساب], 
                     
                    ag1.Name AS [اسم الحساب], 
                    
                      ari1.Debit_Value AS مدين, 
                     ari1.Credit_Value AS دائن, 
                    ar2.FYear,
                    ag2.Account_NO AS [رقم الحساب المقابل], 
                    ag2.Name AS [اسم الحساب المقابل],
                    ari2.Debit_Value AS [مدين للحساب المقابل],
                   ari2.Credit_Value AS [دائن للحساب المقابل],
                    dc.Name AS البيان
                FROM 
                    dbo.Tbl_AccountingRestrictionItems ari1
                INNER JOIN
                    dbo.Tbl_AccountingRestriction ar2 ON ari1.AccountingRestriction_ID = ar2.ID
                INNER JOIN
                    dbo.Tbl_Accounting_Guid ag1 ON ari1.Accounting_Guid_ID = ag1.ID
                INNER JOIN
                    dbo.Tbl_AccountingRestrictionItems ari2 ON ar2.ID = ari2.AccountingRestriction_ID AND ari1.ID <> ari2.ID
                INNER JOIN
                    dbo.Tbl_Accounting_Guid ag2 ON ari2.Accounting_Guid_ID = ag2.ID
                INNER JOIN
                    dbo.TBL_Document doc ON ar2.Document_ID = doc.ID
                INNER JOIN
                    dbo.Tbl_DocumentCategory dc ON doc.DocumentCategory_ID = dc.ID
                WHERE 
                    ar2.Restriction_Date BETWEEN @Date2 AND @Date3
                    AND ag1.Account_NO = @AccountNumber1
                    AND ari2.Credit_Value > 0 AND dc.Name LIKE @Descrption1 
                ORDER BY 
                    [تاريخ المستند], [رقم الحساب];", con))
                    {
                        com.Parameters.Clear();
                        com.Parameters.Add("@Date", SqlDbType.Date).Value = dateTimePicker1.Value.ToShortDateString();
                        com.Parameters.Add("@Date1", SqlDbType.Date).Value = dateTimePicker2.Value.ToShortDateString();
                        com.Parameters.Add("@AccountNumber", SqlDbType.NVarChar).Value = row.Cells[0].Value.ToString();
                        com.Parameters.Add("@Descrption", SqlDbType.NVarChar).Value = "%" + textEdit2.Text + "%";
                        com.Parameters.Add("@Date2", SqlDbType.Date).Value = dateTimePicker1.Value.ToShortDateString();
                        com.Parameters.Add("@Date3", SqlDbType.Date).Value = dateTimePicker2.Value.ToShortDateString();
                        com.Parameters.Add("@AccountNumber1", SqlDbType.NVarChar).Value = row.Cells[0].Value.ToString();
                        com.Parameters.Add("@Descrption1", SqlDbType.NVarChar).Value = "%" + textEdit2.Text + "%";

                        con.Open();

                        using (SqlDataAdapter da = new SqlDataAdapter(com))
                        {
                            da.Fill(dt);
                        }

                        con.Close();
                    }
                }
            }

            gridControl1.DataSource = dt;
            for (int i = 0; i < gridControl1.Rows.Count; i++)
            {

                gridControl1.Rows[i].Cells[5].Value = "0".ToString();

            }
        }

        private void RetrieveDataBetweenDates(DateTime Date, DateTime Date1, string AccountNumber, int RestrictionKind, DataTable dataTable)
        {
            string description = "%" + textEdit2.Text + "%";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
            {
                string query = @"
            SELECT        ar.Restriction_NO AS [رقم المستند], ar.Restriction_Date AS [تاريخ المستند], ag.Account_NO AS [رقم الحساب], ag.Name AS [اسم الحساب], ari.Debit_Value AS مدين, ari.Credit_Value AS دائن, ar.FYear, ag2.Account_NO AS [رقم الحساب المقابل], 
                         ag2.Name AS [اسم الحساب المقابل], ari2.Debit_Value AS [مدين للحساب المقابل], ari2.Credit_Value AS [دائن للحساب المقابل], dc.Name AS البيان
FROM            Tbl_AccountingRestrictions_Kind AS ark INNER JOIN
                         Tbl_AccountingRestrictionItems AS ari ON ark.ID = ari.AccountingRestrictionKind_ID INNER JOIN
                         Tbl_Accounting_Guid AS ag ON ari.Accounting_Guid_ID = ag.ID INNER JOIN
                         Tbl_AccountingRestriction AS ar ON ari.AccountingRestriction_ID = ar.ID INNER JOIN
                         TBL_Document AS doc ON ar.Document_ID = doc.ID INNER JOIN
                         Tbl_DocumentCategory AS dc ON doc.DocumentCategory_ID = dc.ID LEFT OUTER JOIN
                         Tbl_AccountingRestrictionItems AS ari2 ON ar.ID = ari2.AccountingRestriction_ID AND ari2.ID <> ari.ID LEFT OUTER JOIN
                         Tbl_Accounting_Guid AS ag2 ON ari2.Accounting_Guid_ID = ag2.ID
WHERE        (ar.Restriction_Date BETWEEN @Date AND @Date1) AND (ag.Account_NO = @AccountNumber) AND (dc.Name LIKE @Description) AND (ari.AccountingRestrictionKind_ID = @K) AND (ari2.Debit_Value = 0)
UNION
SELECT        ar2.Restriction_NO AS [رقم المستند], ar2.Restriction_Date AS [تاريخ المستند], ag1.Account_NO AS [رقم الحساب], ag1.Name AS [اسم الحساب], ari1.Debit_Value AS مدين, ari1.Credit_Value AS دائن, ar2.FYear, ag2.Account_NO AS [رقم الحساب المقابل], 
                         ag2.Name AS [اسم الحساب المقابل], ari2.Debit_Value AS [مدين للحساب المقابل], ari2.Credit_Value AS [دائن للحساب المقابل], dc.Name AS البيان
FROM            Tbl_AccountingRestrictionItems AS ari1 INNER JOIN
                         Tbl_AccountingRestriction AS ar2 ON ari1.AccountingRestriction_ID = ar2.ID INNER JOIN
                         Tbl_Accounting_Guid AS ag1 ON ari1.Accounting_Guid_ID = ag1.ID INNER JOIN
                         Tbl_AccountingRestrictionItems AS ari2 ON ar2.ID = ari2.AccountingRestriction_ID AND ari1.ID <> ari2.ID INNER JOIN
                         Tbl_Accounting_Guid AS ag2 ON ari2.Accounting_Guid_ID = ag2.ID INNER JOIN
                         TBL_Document AS doc ON ar2.Document_ID = doc.ID INNER JOIN
                         Tbl_DocumentCategory AS dc ON doc.DocumentCategory_ID = dc.ID
WHERE        (ar2.Restriction_Date BETWEEN @Date2 AND @Date3) AND (ag1.Account_NO = @AccountNumber1) AND (dc.Name LIKE @Description1) AND (ari1.AccountingRestrictionKind_ID = @K) AND (ari1.Credit_Value > 0) AND 
                         (ari1.Debit_Value = 0) AND (ari2.Debit_Value = 0)
ORDER BY [تاريخ المستند], [رقم الحساب];";

                using (SqlCommand com = new SqlCommand(query, con))
                {
                    com.Parameters.Add("@Date", SqlDbType.Date).Value = Date;
                    com.Parameters.Add("@Date1", SqlDbType.Date).Value = Date1;
                    com.Parameters.Add("@Date2", SqlDbType.Date).Value = Date;
                    com.Parameters.Add("@Date3", SqlDbType.Date).Value = Date1;
                    com.Parameters.Add("@AccountNumber", SqlDbType.NVarChar).Value = AccountNumber;
                    com.Parameters.Add("@AccountNumber1", SqlDbType.NVarChar).Value = AccountNumber;
                    com.Parameters.Add("@Description", SqlDbType.NVarChar).Value = description;
                    com.Parameters.Add("@Description1", SqlDbType.NVarChar).Value = description;
                    com.Parameters.Add("@K", SqlDbType.Int).Value = RestrictionKind;

                    con.Open();

                    SqlDataReader reader = com.ExecuteReader();

                    // Add retrieved data to the DataTable
                    while (reader.Read())
                    {
                        dataTable.Rows.Add(
                            reader.GetValue(0), // نوع_الحساب
                            reader.GetValue(1),  // رقم المستند
                            reader.GetValue(2),  // تاريخ المستند
                            reader.GetValue(3),  // رقم الحساب
                            reader.GetValue(4),  // اسم الحساب
                            reader.GetValue(5),  // مدين
                            reader.GetValue(6),  // دائن
                            reader.GetValue(7),  // FYear
                            reader.GetValue(8),  // رقم الحساب المقابل
                            reader.GetValue(9),  // اسم الحساب المقابل
                            reader.GetValue(10), // مدين للحساب المقابل
                            reader.GetValue(11) // دائن للحساب المقابل
                            //reader.GetValue(12)  // البيان
                        );
                    }

                    reader.Close();
                    con.Close();
                }
            }
        }

        private void RetrieveDataBetweenDatesDebit(DateTime Date, DateTime Date1, string AccountNumber, int RestrictionKind, DataTable dataTable)
        {
            string description = "%" + textEdit2.Text + "%";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
            {
                string query = @"
           SELECT        ar.Restriction_NO AS [رقم_المستند], ar.Restriction_Date AS [تاريخ_المستند], ag.Account_NO AS [رقم الحساب], ag.Name AS [اسم الحساب], ari.Debit_Value AS مدين, ari.Credit_Value AS دائن, ar.FYear, ag2.Account_NO AS [رقم الحساب المقابل], 
                         ag2.Name AS [اسم_الحساب_المقابل], ari2.Debit_Value AS [مدين_للحساب_المقابل], ari2.Credit_Value AS [دائن للحساب المقابل], dc.Name AS البيان
FROM            Tbl_AccountingRestrictions_Kind AS ark INNER JOIN
                         Tbl_AccountingRestrictionItems AS ari ON ark.ID = ari.AccountingRestrictionKind_ID INNER JOIN
                         Tbl_Accounting_Guid AS ag ON ari.Accounting_Guid_ID = ag.ID INNER JOIN
                         Tbl_AccountingRestriction AS ar ON ari.AccountingRestriction_ID = ar.ID INNER JOIN
                         TBL_Document AS doc ON ar.Document_ID = doc.ID INNER JOIN
                         Tbl_DocumentCategory AS dc ON doc.DocumentCategory_ID = dc.ID LEFT OUTER JOIN
                         Tbl_AccountingRestrictionItems AS ari2 ON ar.ID = ari2.AccountingRestriction_ID AND ari2.ID <> ari.ID LEFT OUTER JOIN
                         Tbl_Accounting_Guid AS ag2 ON ari2.Accounting_Guid_ID = ag2.ID
WHERE        (ar.Restriction_Date BETWEEN @Date AND @Date1) AND (ag.Account_NO = @AccountNumber) AND (dc.Name LIKE @Description) AND (ari.AccountingRestrictionKind_ID = @K) AND (ari2.Credit_Value = 0)
UNION
SELECT        ar2.Restriction_NO AS [رقم_المستند], ar2.Restriction_Date AS [تاريخ_المستند], ag1.Account_NO AS [رقم الحساب], ag1.Name AS [اسم الحساب], ari1.Debit_Value AS مدين, ari1.Credit_Value AS دائن, ar2.FYear, ag2.Account_NO AS [رقم الحساب المقابل], 
                         ag2.Name AS [اسم الحساب المقابل], ari2.Debit_Value AS [مدين للحساب المقابل], ari2.Credit_Value AS [دائن للحساب المقابل], dc.Name AS البيان
FROM            Tbl_AccountingRestrictionItems AS ari1 INNER JOIN
                         Tbl_AccountingRestriction AS ar2 ON ari1.AccountingRestriction_ID = ar2.ID INNER JOIN
                         Tbl_Accounting_Guid AS ag1 ON ari1.Accounting_Guid_ID = ag1.ID INNER JOIN
                         Tbl_AccountingRestrictionItems AS ari2 ON ar2.ID = ari2.AccountingRestriction_ID AND ari1.ID <> ari2.ID INNER JOIN
                         Tbl_Accounting_Guid AS ag2 ON ari2.Accounting_Guid_ID = ag2.ID INNER JOIN
                         TBL_Document AS doc ON ar2.Document_ID = doc.ID INNER JOIN
                         Tbl_DocumentCategory AS dc ON doc.DocumentCategory_ID = dc.ID
WHERE        (ar2.Restriction_Date BETWEEN @Date2 AND @Date3) AND (ag1.Account_NO = @AccountNumber1) AND (dc.Name LIKE @Description1) AND (ari1.AccountingRestrictionKind_ID = @K) AND (ari1.Debit_Value > 0) AND 
                         (ari1.Credit_Value = 0) AND (ari2.Credit_Value = 0)
ORDER BY [تاريخ_المستند], [رقم الحساب];";

                using (SqlCommand com = new SqlCommand(query, con))
                {
                    com.Parameters.Add("@Date", SqlDbType.Date).Value = Date;
                    com.Parameters.Add("@Date1", SqlDbType.Date).Value = Date1;
                    com.Parameters.Add("@Date2", SqlDbType.Date).Value = Date;
                    com.Parameters.Add("@Date3", SqlDbType.Date).Value = Date1;
                    com.Parameters.Add("@AccountNumber", SqlDbType.NVarChar).Value = AccountNumber;
                    com.Parameters.Add("@AccountNumber1", SqlDbType.NVarChar).Value = AccountNumber;
                    com.Parameters.Add("@Description", SqlDbType.NVarChar).Value = description;
                    com.Parameters.Add("@Description1", SqlDbType.NVarChar).Value = description;
                    com.Parameters.Add("@K", SqlDbType.Int).Value = RestrictionKind;

                    con.Open();
                    SqlDataReader reader = com.ExecuteReader();

                    // Add retrieved data to the DataTable
                    while (reader.Read())
                    {
                        dataTable.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5), reader.GetValue(6), reader.GetValue(7), reader.GetValue(8), reader.GetValue(9), reader.GetValue(10), reader.GetValue(11));
                    }

                    reader.Close();
                    con.Close();
                }
            }
        }

        private DataTable RetrieveDataBetweenDates111(DateTime Date, DateTime Date1, string AccountNumber, int K)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("رقم المستند", typeof(string));
            dataTable.Columns.Add("تاريخ المستند", typeof(DateTime));
            dataTable.Columns.Add("رقم الحساب", typeof(string));
            dataTable.Columns.Add("اسم الحساب", typeof(string));
            dataTable.Columns.Add("مدين", typeof(decimal));
            dataTable.Columns.Add("دائن", typeof(decimal));
            dataTable.Columns.Add("العام المالى", typeof(string));
            dataTable.Columns.Add("رقم الحساب المقابل", typeof(string));
            dataTable.Columns.Add("اسم الحساب المقابل", typeof(string));
            dataTable.Columns.Add("مدين للحساب المقابل", typeof(decimal));
            dataTable.Columns.Add("دائن للحساب المقابل", typeof(decimal));
            dataTable.Columns.Add("البيان", typeof(string));

            string description = "%" + textEdit2.Text + "%";

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
            {
                con.Open();

                using (SqlCommand com = new SqlCommand(@"
            SELECT 
                ar.Restriction_NO AS [رقم المستند],
                ar.Restriction_Date AS [تاريخ المستند], 
                ag.Account_NO AS [رقم الحساب], 
                ag.Name AS [اسم الحساب], 
                ari.Debit_Value AS مدين, 
                ari.Credit_Value AS دائن, 
                ar.FYear,
                ag2.Account_NO AS [رقم الحساب المقابل], 
                ag2.Name AS [اسم الحساب المقابل],
                ari2.Debit_Value AS [مدين للحساب المقابل],
                ari2.Credit_Value AS [دائن للحساب المقابل], 
                dc.Name AS البيان
            FROM 
                dbo.Tbl_AccountingRestrictions_Kind ark
            INNER JOIN
                dbo.Tbl_AccountingRestrictionItems ari ON ark.ID = ari.AccountingRestrictionKind_ID
            INNER JOIN
                dbo.Tbl_Accounting_Guid ag ON ari.Accounting_Guid_ID = ag.ID 
            INNER JOIN
                dbo.Tbl_AccountingRestriction ar ON ari.AccountingRestriction_ID = ar.ID
            INNER JOIN
                dbo.TBL_Document doc ON ar.Document_ID = doc.ID
            INNER JOIN
                dbo.Tbl_DocumentCategory dc ON doc.DocumentCategory_ID = dc.ID
            LEFT JOIN
                dbo.Tbl_AccountingRestrictionItems ari2 ON ar.ID = ari2.AccountingRestriction_ID AND ari2.ID <> ari.ID
            LEFT JOIN
                dbo.Tbl_Accounting_Guid ag2 ON ari2.Accounting_Guid_ID = ag2.ID
            WHERE 
                ar.Restriction_Date BETWEEN @Date AND @Date1
                AND ag.Account_NO = @AccountNumber
                AND ari2.Credit_Value = 0 
                AND dc.Name LIKE @Description 
                AND ari.AccountingRestrictionKind_ID = @K
            UNION
            SELECT 
                ar2.Restriction_NO AS [رقم المستند],
                ar2.Restriction_Date AS [تاريخ المستند],
                ag1.Account_NO AS [رقم الحساب], 
                ag1.Name AS [اسم الحساب], 
                ari1.Debit_Value AS مدين, 
                ari1.Credit_Value AS دائن, 
                ar2.FYear,
                ag2.Account_NO AS [رقم الحساب المقابل], 
                ag2.Name AS [اسم الحساب المقابل],
                ari2.Debit_Value AS [مدين للحساب المقابل],
                ari2.Credit_Value AS [دائن للحساب المقابل],
                dc.Name AS البيان
            FROM 
                dbo.Tbl_AccountingRestrictionItems ari1
            INNER JOIN
                dbo.Tbl_AccountingRestriction ar2 ON ari1.AccountingRestriction_ID = ar2.ID
            INNER JOIN
                dbo.Tbl_Accounting_Guid ag1 ON ari1.Accounting_Guid_ID = ag1.ID
            INNER JOIN
                dbo.Tbl_AccountingRestrictionItems ari2 ON ar2.ID = ari2.AccountingRestriction_ID AND ari1.ID <> ari2.ID
            INNER JOIN
                dbo.Tbl_Accounting_Guid ag2 ON ari2.Accounting_Guid_ID = ag2.ID
            INNER JOIN
                dbo.TBL_Document doc ON ar2.Document_ID = doc.ID
            INNER JOIN
                dbo.Tbl_DocumentCategory dc ON doc.DocumentCategory_ID = dc.ID
            WHERE 
                ar2.Restriction_Date BETWEEN @Date AND @Date1
                AND ag1.Account_NO = @AccountNumber
                AND ari2.Credit_Value = 0 
                AND dc.Name LIKE @Description 
                AND ari1.AccountingRestrictionKind_ID = @K
            ORDER BY 
                [تاريخ المستند], [رقم الحساب];", con))
                {
                    com.Parameters.Add("@Date", SqlDbType.Date).Value = Date;
                    com.Parameters.Add("@Date1", SqlDbType.Date).Value = Date1;
                    com.Parameters.Add("@AccountNumber", SqlDbType.NVarChar).Value = AccountNumber;
                    com.Parameters.Add("@Description", SqlDbType.NVarChar).Value = description;
                    com.Parameters.Add("@K", SqlDbType.Int).Value = K;

                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        // Add retrieved data to the DataTable
                        while (reader.Read())
                        {
                            dataTable.Rows.Add(
                                reader["رقم المستند"],
                                reader["تاريخ المستند"],
                                reader["رقم الحساب"],
                                reader["اسم الحساب"],
                                reader["مدين"],
                                reader["دائن"],
                                reader["FYear"],
                                reader["رقم الحساب المقابل"],
                                reader["اسم الحساب المقابل"],
                                reader["مدين للحساب المقابل"],
                                reader["دائن للحساب المقابل"],
                                reader["البيان"]
                            );
                        }
                    }
                }
            }

            return dataTable;
        }

        //private DataTable GetDataBetweenDatesAndGroupFilterReport(List<int> checkedIDs, DateTime Date, DateTime Date1, string AccountNumber)
        //{
        //    DataTable dataTable = new DataTable();
        //    foreach (TreeListNode node in treeList1.GetNodeList())
        //    {
        //        if (node.CheckState == CheckState.Checked)
        //        {
        //            int Vint_MenuPr;
        //            if (int.TryParse(node.GetValue("ID").ToString(), out Vint_MenuPr))
        //            {
        //                checkedIDs.Add(Vint_MenuPr);
        //            }
        //        }
        //    }


        //    foreach (int checkedID in checkedIDs)
        //    {
        //        RetrieveDataBetweenDates(Date, Date1, AccountNumber, checkedIDs[0], dataTable);


        //    }
        //    //DataTable dataTable = RetrieveDataBetweenDates(Date, Date1, AccountNumber, checkedIDs[0]); // Assuming checkedIDs contains relevant information for filtering


        //    return dataTable;

        //}

      
        private DataTable GetDataBetweenDatesAndGroupFilterReport(List<int> checkedIDs, DateTime Date, DateTime Date1, string AccountNumber)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("رقم المستند", typeof(string));
            dataTable.Columns.Add("تاريخ المستند", typeof(DateTime));
            dataTable.Columns.Add("رقم الحساب", typeof(string));
            dataTable.Columns.Add("اسم الحساب", typeof(string));
            dataTable.Columns.Add("مدين", typeof(decimal));
            dataTable.Columns.Add("دائن", typeof(decimal));
            dataTable.Columns.Add("العام المالى", typeof(string));
            dataTable.Columns.Add("رقم الحساب المقابل", typeof(string));
            dataTable.Columns.Add("اسم الحساب المقابل", typeof(string));
            dataTable.Columns.Add("مدين للحساب المقابل", typeof(decimal));
            dataTable.Columns.Add("دائن للحساب المقابل", typeof(decimal));
            dataTable.Columns.Add("البيان", typeof(string));
            foreach (int checkedID in checkedIDs)
            {
                RetrieveDataBetweenDates(Date, Date1, AccountNumber, checkedID, dataTable);
            }





            return dataTable;
        }
        private DataTable GetDataBetweenDatesAndGroupFilterReportDebit(List<int> checkedIDs, DateTime Date, DateTime Date1, string AccountNumber)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("رقم المستند", typeof(string));
            dataTable.Columns.Add("تاريخ المستند", typeof(DateTime));
            dataTable.Columns.Add("رقم الحساب", typeof(string));
            dataTable.Columns.Add("اسم الحساب", typeof(string));
            dataTable.Columns.Add("مدين", typeof(decimal));
            dataTable.Columns.Add("دائن", typeof(decimal));
            dataTable.Columns.Add("العام المالى", typeof(string));
            dataTable.Columns.Add("رقم الحساب المقابل", typeof(string));
            dataTable.Columns.Add("اسم الحساب المقابل", typeof(string));
            dataTable.Columns.Add("مدين للحساب المقابل", typeof(decimal));
            dataTable.Columns.Add("دائن للحساب المقابل", typeof(decimal));
            dataTable.Columns.Add("البيان", typeof(string));
            foreach (int checkedID in checkedIDs)
            {
                RetrieveDataBetweenDatesDebit(Date, Date1, AccountNumber, checkedID, dataTable);
            }





            return dataTable;
        }
        private void FireData()
        {

            List<int> checkedIDs = new List<int>();

            foreach (TreeListNode node in treeList1.GetNodeList())
            {
                if (node.CheckState == CheckState.Checked)
                {
                    int Vint_MenuPr;
                    if (int.TryParse(node.GetValue("ID").ToString(), out Vint_MenuPr))
                    {
                        checkedIDs.Add(Vint_MenuPr);
                    }
                }
            }

            DateTime Date = dateTimePicker1.Value;
            DateTime Date1 = dateTimePicker2.Value;

            gridControl1.DataSource = null;

            DataTable groupedDataTableReport1 = new DataTable(); // Placeholder for grouped data

            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {
                DataTable filteredData1 = GetDataBetweenDatesAndGroupFilterReport(
                    checkedIDs,
                    Date,
                    Date1,
                    dataGridView1.Rows[x].Cells[0].Value.ToString() // Assuming column 0 contains necessary data
                );

                if (filteredData1 != null)
                {
                    if (groupedDataTableReport1.Rows.Count == 0)
                    {
                        groupedDataTableReport1 = filteredData1.Copy(); // Initialize with first result
                    }
                    else
                    {
                        groupedDataTableReport1.Merge(filteredData1);
                    }
                }
            }


            gridControl1.DataSource = groupedDataTableReport1;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.ProcessingForms.ExtrasFinancialYear.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", groupedDataTableReport1));
            //ReportParameter[] parameters = new ReportParameter[1];
           
            //parameters[0] = new ReportParameter("Usr", Program.GlbV_EmpName);
            //// Convert the list of selected items to a single string separated by commas
          

            //// Set report parameters
            //this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
        private void FireDataDebit()
        {
          
            List<int> checkedIDs = new List<int>();

            foreach (TreeListNode node in treeList1.GetNodeList())
            {
                if (node.CheckState == CheckState.Checked)
                {
                    int Vint_MenuPr;
                    if (int.TryParse(node.GetValue("ID").ToString(), out Vint_MenuPr))
                    {
                        checkedIDs.Add(Vint_MenuPr);
                    }
                }
            }

            DateTime Date = dateTimePicker1.Value;
            DateTime Date1 = dateTimePicker2.Value;

            //gridControl1.DataSource = null;

            DataTable groupedDataTableReport = new DataTable(); // Placeholder for grouped data

            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {
                DataTable filteredData = GetDataBetweenDatesAndGroupFilterReportDebit(
                    checkedIDs,
                    Date,
                    Date1,
                    dataGridView1.Rows[x].Cells[0].Value.ToString() // Assuming column 0 contains necessary data
                );

                if (filteredData != null)
                {
                    if (groupedDataTableReport.Rows.Count == 0)
                    {
                        groupedDataTableReport = filteredData.Copy(); // Initialize with first result
                    }
                    else
                    {
                        groupedDataTableReport.Merge(filteredData);
                    }
                }
            }

          
            gridControl1.DataSource = groupedDataTableReport;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.ProcessingForms.ExtrasFinancialYear.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", groupedDataTableReport));

           
            this.reportViewer1.RefreshReport();

        }
        public void getDataDebit()
        {
            List<int> checkedIDs = new List<int>();

            // Assuming treeList1 is where you get your checked IDs
            foreach (TreeListNode node in treeList1.GetNodeList())
            {
                if (node.CheckState == CheckState.Checked)
                {
                    int Vint_MenuPr;
                    if (int.TryParse(node.GetValue("ID").ToString(), out Vint_MenuPr))
                    {
                        checkedIDs.Add(Vint_MenuPr);
                    }
                }
            }

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
            {
                con.Open();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    using (SqlCommand com = new SqlCommand(@"
                SELECT 
                    ar.Restriction_NO AS [رقم المستند],
                    ar.Restriction_Date AS [تاريخ المستند], 
                    ag.Account_NO AS [رقم الحساب], 
                    ag.Name AS [اسم الحساب], 
                    ari.Debit_Value AS مدين, 
                    ari.Credit_Value AS دائن, 
                    ar.FYear,
                    ag2.Account_NO AS [رقم الحساب المقابل], 
                    ag2.Name AS [اسم الحساب المقابل],
                    ari2.Debit_Value AS [مدين للحساب المقابل],
                    ari2.Credit_Value AS [دائن للحساب المقابل], 
                    dc.Name AS البيان
                FROM 
                    dbo.Tbl_AccountingRestrictions_Kind ark
                INNER JOIN
                    dbo.Tbl_AccountingRestrictionItems ari ON ark.ID = ari.AccountingRestrictionKind_ID
                INNER JOIN
                    dbo.Tbl_Accounting_Guid ag ON ari.Accounting_Guid_ID = ag.ID 
                INNER JOIN
                    dbo.Tbl_AccountingRestriction ar ON ari.AccountingRestriction_ID = ar.ID
                INNER JOIN
                    dbo.TBL_Document doc ON ar.Document_ID = doc.ID
                INNER JOIN
                    dbo.Tbl_DocumentCategory dc ON doc.DocumentCategory_ID = dc.ID
                LEFT JOIN
                    dbo.Tbl_AccountingRestrictionItems ari2 ON ar.ID = ari2.AccountingRestriction_ID AND ari2.ID <> ari.ID
                LEFT JOIN
                    dbo.Tbl_Accounting_Guid ag2 ON ari2.Accounting_Guid_ID = ag2.ID
                WHERE 
                    ar.Restriction_Date BETWEEN @Date AND @Date1
                    AND ag.Account_NO = @AccountNumber
                    AND ari2.Credit_Value = 0 
                    AND dc.Name LIKE @Description 
                    AND ari.AccountingRestrictionKind_ID = @K
                UNION
                SELECT 
                    ar2.Restriction_NO AS [رقم المستند],
                    ar2.Restriction_Date AS [تاريخ المستند],
                    ag1.Account_NO AS [رقم الحساب], 
                    ag1.Name AS [اسم الحساب], 
                    ari1.Debit_Value AS مدين, 
                    ari1.Credit_Value AS دائن, 
                    ar2.FYear,
                    ag2.Account_NO AS [رقم الحساب المقابل], 
                    ag2.Name AS [اسم الحساب المقابل],
                    ari2.Debit_Value AS [مدين للحساب المقابل],
                    ari2.Credit_Value AS [دائن للحساب المقابل],
                    dc.Name AS البيان
                FROM 
                    dbo.Tbl_AccountingRestrictionItems ari1
                INNER JOIN
                    dbo.Tbl_AccountingRestriction ar2 ON ari1.AccountingRestriction_ID = ar2.ID
                INNER JOIN
                    dbo.Tbl_Accounting_Guid ag1 ON ari1.Accounting_Guid_ID = ag1.ID
                INNER JOIN
                    dbo.Tbl_AccountingRestrictionItems ari2 ON ar2.ID = ari2.AccountingRestriction_ID AND ari1.ID <> ari2.ID
                INNER JOIN
                    dbo.Tbl_Accounting_Guid ag2 ON ari2.Accounting_Guid_ID = ag2.ID
                INNER JOIN
                    dbo.TBL_Document doc ON ar2.Document_ID = doc.ID
                INNER JOIN
                    dbo.Tbl_DocumentCategory dc ON doc.DocumentCategory_ID = dc.ID
                WHERE 
                    ar2.Restriction_Date BETWEEN @Date2 AND @Date3
                    AND ag1.Account_NO = @AccountNumber1
                    AND ari2.Credit_Value = 0 
                    AND dc.Name LIKE @Description1 
                    AND ari1.AccountingRestrictionKind_ID = @K
                ORDER BY 
                    [تاريخ المستند], [رقم الحساب];", con))
                    {
                        com.Parameters.Clear();
                        com.Parameters.Add("@Date", SqlDbType.Date).Value = dateTimePicker1.Value;
                        com.Parameters.Add("@Date1", SqlDbType.Date).Value = dateTimePicker2.Value;
                        com.Parameters.Add("@AccountNumber", SqlDbType.NVarChar).Value = row.Cells[0].Value.ToString();
                        com.Parameters.Add("@Description", SqlDbType.NVarChar).Value = "%" + textEdit2.Text + "%";
                        com.Parameters.Add("@Date2", SqlDbType.Date).Value = dateTimePicker1.Value;
                        com.Parameters.Add("@Date3", SqlDbType.Date).Value = dateTimePicker2.Value;
                        com.Parameters.Add("@AccountNumber1", SqlDbType.NVarChar).Value = row.Cells[0].Value.ToString();
                        com.Parameters.Add("@Description1", SqlDbType.NVarChar).Value = "%" + textEdit2.Text + "%";

                        // Assuming @K should be the first element in checkedIDs list
                        com.Parameters.Add("@K", SqlDbType.Int).Value = checkedIDs.Count > 0 ? checkedIDs[0] : 0;

                        using (SqlDataAdapter da = new SqlDataAdapter(com))
                        {
                            da.Fill(dt);
                        }
                    }
                }

                con.Close();
            }

            // Bind the DataTable to the grid
            gridControl1.DataSource = dt;

            // Set the value of the 5th cell in each row to "0"
            for (int i = 0; i < gridControl1.Rows.Count; i++)
            {

                gridControl1.Rows[i].Cells[5].Value = "0".ToString();

            }
        }

        private void textEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textEdit1.Text != "")
                {
                    dataGridView1.Rows.Add(textEdit1.Text);
                    textEdit1.Text = "";
                    textEdit1.Focus();
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = null;
            textBox11.Text = "0";
            if (comboBox1.Text == "مدين")
            {

                FireDataDebit();

                if (gridControl1.Rows.Count > 0)
                {

                    gridControl1.Columns[0].Width = 140; //account
                    gridControl1.Columns[1].Width = 140;          //date
                    gridControl1.Columns[2].Width = 140;                //account_name
                    gridControl1.Columns[3].Width = 300; //restrictionNumber
                    gridControl1.Columns[4].Width = 140; //debit
                    gridControl1.Columns[5].Width = 140; //cridet

                    gridControl1.Columns[6].Width = 140; //year
                    gridControl1.Columns[7].Width = 140; //  account on
                    gridControl1.Columns[8].Width = 300;  //account name on
                    gridControl1.Columns[9].Width = 140;   //debit on
                    gridControl1.Columns[10].Width = 140;  //cridet on
                    gridControl1.Columns[11].Width = 300;  //description
                    textBox11.Text = (from DataGridViewRow row in gridControl1.Rows
                                      where row.Cells[0].Value.ToString() != string.Empty
                                      select Convert.ToInt32(row.Cells[0].Value)).Distinct().Count().ToString();
                }
                else
                {
                    MessageBox.Show("لا توجد بيانات");
                    textBox11.Text = "0";
                }
            }

           
            textBox11.Text = "0";
            if (comboBox1.Text == "دائن")
            {

                FireData();

                if (gridControl1.Rows.Count > 0)
                {

                    gridControl1.Columns[0].Width = 140; //account
                    gridControl1.Columns[1].Width = 140;          //date
                    gridControl1.Columns[2].Width = 140;                //account_name
                    gridControl1.Columns[3].Width = 300; //restrictionNumber
                    gridControl1.Columns[4].Width = 140; //debit
                    gridControl1.Columns[5].Width = 140; //cridet

                    gridControl1.Columns[6].Width = 140; //year
                    gridControl1.Columns[7].Width = 140; //  account on
                    gridControl1.Columns[8].Width = 300;  //account name on
                    gridControl1.Columns[9].Width = 140;   //debit on
                    gridControl1.Columns[10].Width = 140;  //cridet on
                    gridControl1.Columns[11].Width = 300;  //description
                    textBox11.Text = (from DataGridViewRow row in gridControl1.Rows
                                      where row.Cells[0].Value.ToString() != string.Empty
                                      select Convert.ToInt32(row.Cells[0].Value)).Distinct().Count().ToString();
                }
                else
                {
                    MessageBox.Show("لا توجد بيانات");
                    textBox11.Text = "0";
                }
            }
          
        }
           
      

        private void ExtrasFinancialYearFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'extraYears.DataTable1' table. You can move, or remove it, as needed.
            //this.dataTable1TableAdapter.Fill(this.extraYears.DataTable1);
            try
            {
                this.tbl_AccountingRestrictions_KindTableAdapter.FillByKind(this.dataSet1.Tbl_AccountingRestrictions_Kind);
            }
            catch { }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            //FireData();
            //if (gridControl1.Rows.Count > 0)
            //{

            //    gridControl1.Columns[0].Width = 140; //account
            //    gridControl1.Columns[1].Width = 140;          //date
            //    gridControl1.Columns[2].Width = 140;                //account_name
            //    gridControl1.Columns[3].Width = 300; //restrictionNumber
            //    gridControl1.Columns[4].Width = 140; //debit
            //    gridControl1.Columns[5].Width = 140; //cridet
            //    gridControl1.Columns[6].Width = 140; //year
            //    gridControl1.Columns[7].Width = 140; //  account on
            //    gridControl1.Columns[8].Width = 300;  //account name on
            //    gridControl1.Columns[9].Width = 140;   //debit on
            //    gridControl1.Columns[10].Width = 140;  //cridet on
            //    gridControl1.Columns[11].Width = 300;  //description
            //    textBox11.Text = (from DataGridViewRow row in gridControl1.Rows
            //                      where row.Cells[0].Value.ToString() != string.Empty
            //                      select Convert.ToInt32(row.Cells[0].Value)).Distinct().Count().ToString();
            //}
            //else
            //{
            //    MessageBox.Show("لا توجد بيانات");
            //    textBox11.Text = "0";
            //}
        }
    }
}