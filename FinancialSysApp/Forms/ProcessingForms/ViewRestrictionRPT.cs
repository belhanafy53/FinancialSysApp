using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Configuration;

namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class ViewRestrictionRPT : DevExpress.XtraEditors.XtraForm
    {
        int x;
        int y;
        Res_Frm r = new Res_Frm();
        public ViewRestrictionRPT()
        {
            InitializeComponent();
        }
        public DataTable ReportPrint()
        {
           

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.CommandType = CommandType.Text;
            com1.CommandType = CommandType.Text;
            //SqlDataReader red;
            com.Connection = con;
            com.CommandText = ("select Row_No as[م], Tbl_Accounting_Guid.Account_NO as [رقم الحساب],Tbl_Accounting_Guid.Name as [اسم الحساب],Debit_Value AS [مدين],Credit_Value AS [دائن],Tbl_AccountingRestrictions_Kind.Name as[اليومية],Tbl_AccountingRestrictionItems.Accounting_Guid_ID ,Tbl_Activities.Name as[النشاط] ,Tbl_Activities.ID,Tbl_RestrictionItemsCategory.Name as [التصنيف],Tbl_RestrictionItemsCategory.ID, Tbl_CostCenters.Name ,Tbl_AccountingRestrictionItems.CostCenters_ID,Tbl_AccountingRestrictionItems.ID,Tbl_AccountingRestrictionItems.ID,Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID from Tbl_AccountingRestrictionItems inner join Tbl_AccountingRestriction on Tbl_AccountingRestrictionItems.AccountingRestriction_ID =Tbl_AccountingRestriction.ID inner join Tbl_Accounting_Guid on Tbl_AccountingRestrictionItems.Accounting_Guid_ID = Tbl_Accounting_Guid.ID inner join Tbl_AccountingRestrictions_Kind on Tbl_AccountingRestriction.AccountingRestrictionKind_ID = Tbl_AccountingRestrictions_Kind.ID Left Join Tbl_Activities on Tbl_AccountingRestrictionItems.Activities_ID = Tbl_Activities.ID left join Tbl_RestrictionItemsCategory on Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = Tbl_RestrictionItemsCategory.ID left join Tbl_CostCenters on Tbl_AccountingRestrictionItems.CostCenters_ID = Tbl_CostCenters.ID where  Tbl_AccountingRestriction.Restriction_NO =  @D and Tbl_AccountingRestrictions_Kind.id = @D2  OR Tbl_AccountingRestriction.Restriction_NO = @D and Tbl_AccountingRestrictions_Kind.id = @D3  Order by Tbl_AccountingRestrictions_Kind.ID  ASc ");

            //if (Convert.ToInt32(comboBox1.SelectedValue) == 1)
            //{
            //    x = 1;
            //    y = 2;
            //}

            //if (Convert.ToInt32(comboBox1.SelectedValue) == 2)
            //{
            //    x = 1;
            //    y = 2;
            //}
            //if (Convert.ToInt32(comboBox1.SelectedValue) != 2 && Convert.ToInt32(comboBox1.SelectedValue) != 1)
            //{
            //    x = Convert.ToInt32(comboBox1.SelectedValue);
            //    y = Convert.ToInt32(comboBox1.SelectedValue);
            //}
            //if (Convert.ToInt32(comboBox1.SelectedValue) != 1 && Convert.ToInt32(comboBox1.SelectedValue) != 2)
            //{
            //    x = Convert.ToInt32(comboBox1.SelectedValue);
            //    y = Convert.ToInt32(comboBox1.SelectedValue);
            //}


            com.Parameters.Add("@D", SqlDbType.VarChar).Value = r.Restriction_NO.Text;
            //if (comboBox1.Text != "عمليات" || comboBox1.Text != "مدفوعات"  ) 
            //{
            com.Parameters.Add("@D2", SqlDbType.Int).Value = x;
            com.Parameters.Add("@D3", SqlDbType.Int).Value = y;
            //}

            //if (comboBox1.Text == "عمليات" || comboBox1.Text == "مدفوعات")
            //{
            //    com.Parameters.Add("@D2", SqlDbType.Int).Value = 1;
            //    com.Parameters.Add("@D3", SqlDbType.Int).Value = 2;
            //}
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
        private void ViewRestrictionRPT_Load(object sender, EventArgs e)
        {
            //RestRPT BRPT = new RestRPT();
            //crystalReportViewer1.ReportSource = BRPT;
            crystalReportViewer1.RefreshReport();
        }
    }
}