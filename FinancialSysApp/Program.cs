using FinancialSysApp.Forms;
using FinancialSysApp.Forms.BasicCodeForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialSysApp.Classes;
using FinancialSysApp.DataBase.Model;
using System.Data.SqlClient;
using System.Configuration;

namespace FinancialSysApp
{
    
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.

        /// </summary>
        [STAThread]
      
        static void Main()
        {
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
        DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.XtraEditors.WindowsFormsSettings.AllowDefaultSvgImages = DevExpress.Utils.DefaultBoolean.False;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginFrm());
            //Application.Run(new Forms.Banks.Form1());
            //Application.Run(new Forms.Banks.Reports.DueCheqBankPurposeRpt());
            //Application.Run(new Forms.CashDeposit.DepositCashQueryFrm());
            //Application.Run(new Forms.Banks.ElectronicPaymentsFrm());
            //Application.Run(new Forms.Banks.Reports.TreasureCollectionCheqAuditFrm());
            //Application.Run(new Forms.Banks.ElectronicPaymentAuditFrm());
            //Application.Run(new Forms.Orders.Reports.OrdersDetailsRpt());
            //Application.Run(new Forms.Letter_WarrantyForm.Test());

        }

        public static string GlbV_Connection = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();

        public static string GlbV_EVConnection = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysEventsConnectionString1"].ConnectionString.ToString();

        public static string GlbV_IpAddressServer = "\\30.30.30.5";

        public static List<int> SecurityFormsList = new List<int>();
        public static List<FormProcedures> SecurityProceduresList = new List<FormProcedures>();

        public static string GlbV_UserName = "";
        public static string GlbV_EmpName = "";
        public static string GlbV_SysUnite = "";
        public static string GlbV_Management = "";
        public static string GlbV_job = "";
        public static string GlbV_CPassword = "";
        public static string GlbV_UserType = "";
        public static string GlbV_DateTime = "";

        public static int GlbV_UserId = 0;
        public static int GlbV_UserTypeId = 0;
        public static int GlbV_SysUnite_ID = 0;


    }


}
