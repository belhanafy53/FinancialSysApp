using DevExpress.XtraRichEdit.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialSysApp.Classes
{

    internal class DateAddedBankCs
    {

        public int VacationPeriodCount { get; set; }
        public int PublicvacationYear { get; set; }


        public string SelectDateAddedBank(DateTime chequDueDate, DateTime chequDepositDate, int bankDepositID, int bankDrawnOnID)
        {
            string result = null;

            int vacationYear = PublicvacationYear;
            const int addOneDayOnChequDepositDate = 1;
            const int addDaysNoChequDueDate = 3;
            const int addOneDayChequDueDate = 1;

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
            {
                try
                {
                    con.Open();

                    DateTime resultDateOFCompareChequDepositDate = AddWeekDays(chequDepositDate, addOneDayOnChequDepositDate);//اضافه يوم  لتاريخ الايداع باستثناء الجمعة والسبت
                    DateTime resultDateOFChequDueDate = AddWeekDays(chequDueDate, addDaysNoChequDueDate);//اضافه عدد 3ايام لتاريخ الاستحقاق باستثناء الجمعة والسبت
                    DateTime resultDateOFChequDueDateOneDay = AddWeekDays(chequDueDate, addOneDayChequDueDate);//اضافه يوم لتاريخ الاستحقاق باستثناء الجمعة والسبت


                    if (chequDepositDate > chequDueDate && bankDepositID != bankDrawnOnID)//فى حالة تاريخ الايداع اكبر من تاريخ الاستحقاق والبنك المودع لا يساوى المسحوب عليه
                    {
                        VacationPeriodCount = CheckVacationPeriod(resultDateOFCompareChequDepositDate, con, vacationYear);//حساب الفرق بين تاريخ الشيك (ايداع-استحقاق) وبين ايام العطلات الرسمية

                        if (VacationPeriodCount > 0)//فى حالة وجود عطلة رسمية
                        {

                            result = resultDateOFCompareChequDepositDate.AddDays(VacationPeriodCount).ToShortDateString();

                        }
                        else if (VacationPeriodCount == 0)//فى حالة عدم وجود عطلة رسمية
                        {
                            result = resultDateOFCompareChequDepositDate.ToShortDateString();
                        }

                    }
                    else if (chequDueDate <= chequDepositDate && bankDepositID != bankDrawnOnID)//فى حالة تاريخ الاستحقاق اصغر او يساوى  تاريخ الاستحقاق والبنك المودع لا يساوى المسحوب عليه
                    {
                        VacationPeriodCount = CheckVacationPeriod(resultDateOFChequDueDate, con, vacationYear);//حساب الفرق بين تاريخ الشيك (ايداع-استحقاق) وبين ايام العطلات الرسمية

                        if (VacationPeriodCount > 0)
                        {

                            result = resultDateOFChequDueDate.AddDays(VacationPeriodCount).ToShortDateString();
                        }
                        else if (VacationPeriodCount == 0)
                        {
                            result = resultDateOFChequDueDate.ToShortDateString();
                        }


                    }
                    else if (chequDueDate <= chequDepositDate && bankDepositID == bankDrawnOnID)//فى حالة تاريخ الاستحقاق اصغر من تاريخ الايداع والبنك المودع  يساوى المسحوب عليه
                    {
                        VacationPeriodCount = CheckVacationPeriod(resultDateOFChequDueDateOneDay, con, vacationYear);//حساب الفرق بين تاريخ الشيك (ايداع-استحقاق) وبين ايام العطلات الرسمية

                        if (VacationPeriodCount > 0)
                        {

                            result = resultDateOFChequDueDateOneDay.AddDays(VacationPeriodCount).ToShortDateString();
                        }
                        else if (VacationPeriodCount == 0)
                        {
                            result = resultDateOFChequDueDateOneDay.ToShortDateString();
                        }


                    }

                    else if (chequDueDate >= chequDepositDate && bankDepositID == bankDrawnOnID)//تاريخ الايداع اصغر من تاريخ الشيك والبنك المودع  يساوى البنك المسحوب عليه
                    {
                        VacationPeriodCount = CheckVacationPeriod(resultDateOFChequDueDateOneDay, con, vacationYear);//حساب الفرق بين تاريخ الشيك (ايداع-استحقاق) وبين ايام العطلات الرسمية

                        if (VacationPeriodCount > 0)
                        {

                            result = resultDateOFChequDueDateOneDay.AddDays(VacationPeriodCount).ToShortDateString();
                        }
                        else if (VacationPeriodCount == 0)
                        {
                            result = resultDateOFChequDueDateOneDay.ToShortDateString();
                        }


                    }
                    else if (chequDueDate >= chequDepositDate && bankDepositID != bankDrawnOnID)//تاريخ الايداع اصغر من تاريخ الشيك والبنك المودع لا يساوى البنك المسحوب عليه
                    {
                        VacationPeriodCount = CheckVacationPeriod(resultDateOFChequDueDate, con, vacationYear);//حساب الفرق بين تاريخ الشيك (ايداع-استحقاق) وبين ايام العطلات الرسمية

                        if (VacationPeriodCount > 0)
                        {

                            result = resultDateOFChequDueDate.AddDays(VacationPeriodCount).ToShortDateString();
                            
                        }
                        else if (VacationPeriodCount == 0)
                        {
                            result = resultDateOFChequDueDate.ToShortDateString();
                        }


                    }
                }
                catch
                {

                }
            }

            return result;
        }

        private int CheckVacationPeriod(DateTime date, SqlConnection connection, int year)
        {
            int vacationPeriodCount = 0;

            using (SqlCommand command = new SqlCommand("SELECT FromDate, ToDate FROM Tbl_OfficialVacation WHERE VacationYear = @VacationYear", connection))
            {
                command.Parameters.AddWithValue("@VacationYear", year);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DateTime fromDate = reader.GetDateTime(0);
                    DateTime toDate = reader.GetDateTime(1);

                   
                    if (date >= fromDate && date <= toDate)
                    {
                       
                        vacationPeriodCount += CalculateVacationPeriod(fromDate, toDate).Days + 1;
                    }

                }
            }

            return vacationPeriodCount;
            
        }

        private TimeSpan CalculateVacationPeriod(DateTime fromDate, DateTime toDate)
        {
            return toDate - fromDate;
        }

        public static DateTime AddWeekDays(DateTime startDate, int numberOfDaysToAdd)
        {
            int daysAdded = 0;
            while (daysAdded < numberOfDaysToAdd)
            {
                startDate = startDate.AddDays(1);
                if (startDate.DayOfWeek != DayOfWeek.Friday && startDate.DayOfWeek != DayOfWeek.Saturday)
                {
                    daysAdded++;
                }
            }
            return startDate;
        }


    }
}
    
