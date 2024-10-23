using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialSysApp.Classes
{
    internal class FinancialYearDueDate
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        public int  SelectFinancialYearDueDate(DateTime Vd_chequDueDate)
        {
            Vd_chequDueDate = Convert.ToDateTime( Vd_chequDueDate.ToString("yyyy/MM/dd"));
            int  result = 0;
            //var listDates = FsDb.Tbl_Fiscalyear.Where(x => x.Open_Close == null && Vd_chequDueDate >=x.DateFrom &&  Vd_chequDueDate <= x.DateTo).ToList();
            //if (listDates.Count != 0)
            //{ result = Convert.ToInt32(listDates[0].CurrentYear); }
            

            string connectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString;





            
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                   

                    string shrinkCommand = "select ID from Tbl_Fiscalyear where @Date between DateFrom and DateTo";

                    SqlCommand command = new SqlCommand(shrinkCommand, connection);
                    command.Parameters.Add("@Date", SqlDbType.Date).Value = Vd_chequDueDate;
                    connection.Open();
                SqlDataReader red;
                red = command.ExecuteReader();
                   while(red.Read())
                {
                    result = int.Parse( red.GetValue(0).ToString());
                }

                red.Close();
                    connection.Close();

                    
                }
           
            return result;
        }
    }
}
