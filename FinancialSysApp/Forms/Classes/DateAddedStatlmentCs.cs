
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialSysApp.Classes
{
    internal class DateAddedStatlmentCs
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        public int VacationPeriodCount { get; set; }
        public int PublicvacationYear { get; set; }
        public int AddNumberOfDay { get; set; }

        int AddNoDay = 0;
        public string SelectDateAddedBank(DateTime chequDueDate, DateTime chequDepositDate, int bankDepositID, int bankDrawnOnID)
        {
            string result = null;

            DateTime Vd_BeforeCheck;
            //if (bankDepositID == 2004)
            //{ bankDepositID = 1; }

            //if (bankDepositID == 2014)
            //{ bankDepositID = 2013; }

            if (chequDepositDate >= chequDueDate && bankDepositID != bankDrawnOnID)//فى حالة تاريخ الايداع اكبر من تاريخ الاستحقاق والبنك المودع لا يساوى المسحوب عليه
            {
                AddNoDay = int.Parse(FsDb.Tbl_Check_DateAdded.Select(u => u.DifferenceBank).SingleOrDefault().ToString());
                Vd_BeforeCheck = chequDepositDate.AddDays(AddNoDay - 1);
                DateTime xx = listMultiDates9(chequDepositDate, Vd_BeforeCheck, AddNoDay);

                result = xx.ToString("yyyy-MM-dd");

            }

            else if (chequDueDate > chequDepositDate && bankDepositID != bankDrawnOnID)//فى حالة تاريخ الاستحقاق اصغر او يساوى  تاريخ الاستحقاق والبنك المودع لا يساوى المسحوب عليه
            {
                AddNoDay = int.Parse(FsDb.Tbl_Check_DateAdded.Select(u => u.DifferenceBankDue).SingleOrDefault().ToString());
                //Vd_BeforeCheck = chequDueDate.AddDays(AddNoDay);
                Vd_BeforeCheck = chequDueDate;
                DateTime xx = listMultiDates9(chequDueDate, Vd_BeforeCheck, AddNoDay);

                result = xx.ToString("yyyy-MM-dd");

            }

            else if (chequDueDate > chequDepositDate && bankDepositID == bankDrawnOnID)//تاريخ الايداع اصغر من تاريخ الشيك والبنك المودع  يساوى البنك المسحوب عليه
            {

                AddNoDay = int.Parse(FsDb.Tbl_Check_DateAdded.Select(u => u.SameBank).SingleOrDefault().ToString());
                Vd_BeforeCheck = chequDueDate.AddDays(AddNoDay);
                DateTime xx = listMultiDates9(chequDueDate, Vd_BeforeCheck, AddNoDay);
                result = xx.ToString("yyyy-MM-dd");
            }
            else if (chequDueDate <= chequDepositDate && bankDepositID == bankDrawnOnID)//تاريخ الايداع اصغر من تاريخ الشيك والبنك المودع  يساوى البنك المسحوب عليه
            {

                AddNoDay = int.Parse(FsDb.Tbl_Check_DateAdded.Select(u => u.SameBank).SingleOrDefault().ToString()) - 1;
                Vd_BeforeCheck = chequDepositDate.AddDays(AddNoDay);
                DateTime xx = listMultiDates9(chequDepositDate, Vd_BeforeCheck, AddNoDay);
                result = xx.ToString("yyyy-MM-dd");
            }
            return result;
        }
        private DateTime listMultiDates9(DateTime startDate, DateTime endDate, int AddNoOfDay)
        {
            DateTime ResultDate = Convert.ToDateTime(startDate.ToString());
            for (int i = 0; i < AddNoDay; i++)
            {
                if (i == 0)
                { ResultDate = startDate; }
                else
                { ResultDate = ResultDate.AddDays(1); }

                //*****************هل هذا التاريخ يوم جمعه
                if (ResultDate.DayOfWeek == DayOfWeek.Friday)
                {

                    ResultDate = ResultDate.AddDays(2);
                    if (CheckDatewhithinVacationPeriodTrueFalse(ResultDate, ResultDate.Year) == true)

                    {
                        ResultDate = CheckDatewhithinVacationPeriod(ResultDate, ResultDate.Year);
                        ResultDate = ResultDate.AddDays(1);
                    }
                }
                //***************** او هل هذا التاريخ يوم سبت
                else if (ResultDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    ResultDate = ResultDate.AddDays(1);
                    if (CheckDatewhithinVacationPeriodTrueFalse(ResultDate, ResultDate.Year) == true)

                    {
                        ResultDate = CheckDatewhithinVacationPeriod(ResultDate, ResultDate.Year);
                        ResultDate = ResultDate.AddDays(1);
                    }
                }
                //************************* ام هل هذا التاريخ اجازه رسميه 
                else if (CheckDatewhithinVacationPeriodTrueFalse(ResultDate, ResultDate.Year) == true)

                {
                    ResultDate = CheckDatewhithinVacationPeriod(ResultDate, ResultDate.Year);
                    ResultDate = ResultDate.AddDays(1);
                    //*****************هل هذا التاريخ يوم جمعه
                    if (ResultDate.DayOfWeek == DayOfWeek.Friday)
                    {
                        ResultDate = ResultDate.AddDays(2);
                        if (CheckDatewhithinVacationPeriodTrueFalse(ResultDate, ResultDate.Year) == true)

                        {
                            ResultDate = CheckDatewhithinVacationPeriod(ResultDate, ResultDate.Year);
                            ResultDate = ResultDate.AddDays(1);
                        }
                    }
                    //***************** او هل هذا التاريخ يوم سبت
                    else if (ResultDate.DayOfWeek == DayOfWeek.Saturday)
                    {
                        ResultDate = ResultDate.AddDays(1);
                        if (CheckDatewhithinVacationPeriodTrueFalse(ResultDate, ResultDate.Year) == true)

                        {
                            ResultDate = CheckDatewhithinVacationPeriod(ResultDate, ResultDate.Year);
                            ResultDate = ResultDate.AddDays(1);
                        }
                    }

                }


            }
            if (CheckDatewhithinVacationPeriodTrueFalse(ResultDate, ResultDate.Year) == true)

            {
                ResultDate = CheckDatewhithinVacationPeriod(ResultDate, ResultDate.Year);
                ResultDate = ResultDate.AddDays(1);
                //*****************هل هذا التاريخ يوم جمعه
                if (ResultDate.DayOfWeek == DayOfWeek.Friday)
                {
                    ResultDate = ResultDate.AddDays(2);
                    if (CheckDatewhithinVacationPeriodTrueFalse(ResultDate, ResultDate.Year) == true)

                    {
                        ResultDate = CheckDatewhithinVacationPeriod(ResultDate, ResultDate.Year);
                        ResultDate = ResultDate.AddDays(1);
                    }
                }
                //***************** او هل هذا التاريخ يوم سبت
                else if (ResultDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    ResultDate = ResultDate.AddDays(1);
                    if (CheckDatewhithinVacationPeriodTrueFalse(ResultDate, ResultDate.Year) == true)

                    {
                        ResultDate = CheckDatewhithinVacationPeriod(ResultDate, ResultDate.Year);
                        ResultDate = ResultDate.AddDays(1);
                    }
                }
            }
            return ResultDate;
        }
        private DateTime listMultiDates(DateTime startDate, DateTime endDate, int AddNoOfDay)
        {
            DateTime ResultDate = Convert.ToDateTime(startDate.ToString());

            int factor = 1;
            // Calculate the difference between the dates
            TimeSpan difference = endDate - startDate;
            // Generate a list of dates by multiplying the difference by the factor
            List<DateTime> resultList = new List<DateTime>();
            for (int i = 0; i <= difference.Days; i++)
            {
                resultList.Add(startDate.AddDays(i * factor));
            }
            // Print the result list of dates

            foreach (DateTime date in resultList)
            {
                if (AddNoOfDay != 0)
                {
                    AddNumberOfDay = AddNoOfDay;
                    //*****************هل هذا التاريخ يوم جمعه
                    if (date.DayOfWeek == DayOfWeek.Friday)
                    {

                        ResultDate = date.AddDays(1);
                        AddNumberOfDay = AddNumberOfDay - 1;
                        AddNoOfDay = AddNoOfDay - 1;
                    }
                    //*****************هل هذا التاريخ يوم سبت
                    if (date.DayOfWeek == DayOfWeek.Saturday)
                    {

                        ResultDate = date.AddDays(1);
                        AddNumberOfDay = AddNumberOfDay - 1;
                        AddNoOfDay = AddNoOfDay - 1;
                    }
                    else
                    {
                        //AddNoOfDay = AddNoOfDay;
                        var list_VacationY = FsDb.Tbl_OfficialVacation.Where(x => x.VacationYear == date.Year && (date >= x.FromDate && date <= x.ToDate)).ToList();
                        if (list_VacationY.Count == 0)
                        {


                            //ResultDate = date;
                            if (ResultDate.DayOfWeek == DayOfWeek.Friday)
                            {
                                //AddNoOfDay = AddNoOfDay;
                                ResultDate = ResultDate.AddDays(1);
                                AddNumberOfDay = AddNumberOfDay - 1;
                                AddNoOfDay = AddNoOfDay - 1;

                            }
                            //*****************هل هذا التاريخ يوم سبت
                            else if (ResultDate.DayOfWeek == DayOfWeek.Saturday)
                            {
                                //AddNoOfDay = AddNoOfDay;
                                ResultDate = ResultDate.AddDays(1);
                                AddNumberOfDay = AddNumberOfDay - 1;
                                AddNoOfDay = AddNoOfDay - 1;

                            }
                            else
                            {

                                //if (AddNoOfDay != 0)
                                //{
                                //    ResultDate = ResultDate.AddDays(1);
                                //    AddNumberOfDay = AddNoOfDay - 1;
                                //    AddNoOfDay = AddNoOfDay - 1;
                                //}
                                if (CheckDatewhithinVacationPeriodTrueFalse(ResultDate, ResultDate.Year) == true)
                                { ResultDate = CheckDatewhithinVacationPeriod(ResultDate, ResultDate.Year); }
                                //*****************هل هذا التاريخ يوم جمعه
                                if (ResultDate.DayOfWeek == DayOfWeek.Friday)
                                {
                                    //AddNoOfDay = AddNoOfDay;
                                    ResultDate = ResultDate.AddDays(1);
                                    AddNumberOfDay = AddNumberOfDay - 1;
                                    AddNoOfDay = AddNoOfDay - 1;
                                }
                                //*****************هل هذا التاريخ يوم سبت
                                else if (ResultDate.DayOfWeek == DayOfWeek.Saturday)
                                {
                                    //AddNoOfDay = AddNoOfDay;
                                    ResultDate = ResultDate.AddDays(1);
                                    AddNumberOfDay = AddNumberOfDay - 1;
                                    AddNoOfDay = AddNoOfDay - 1;
                                }
                            }

                        }
                        else
                        {
                            if (CheckDatewhithinVacationPeriodTrueFalse(date, date.Year) == true)
                            {
                                ResultDate = CheckDatewhithinVacationPeriod(date, date.Year);
                                ResultDate = ResultDate.AddDays(1);
                                AddNumberOfDay = AddNumberOfDay - 1;
                                AddNoOfDay = AddNoOfDay - 1;
                            }



                            //*****************هل هذا التاريخ يوم جمعه
                            if (ResultDate.DayOfWeek == DayOfWeek.Friday)
                            {
                                //AddNoOfDay = AddNoOfDay;
                                ResultDate = ResultDate.AddDays(1);
                                AddNumberOfDay = AddNumberOfDay - 1;
                                AddNoOfDay = AddNoOfDay - 1;
                            }
                            //*****************هل هذا التاريخ يوم سبت
                            else if (ResultDate.DayOfWeek == DayOfWeek.Saturday)
                            {
                                //AddNoOfDay = AddNoOfDay;
                                ResultDate = ResultDate.AddDays(1);
                                AddNumberOfDay = AddNumberOfDay - 1;
                                AddNoOfDay = AddNoOfDay - 1;
                            }
                            else
                            {

                                AddNumberOfDay = AddNumberOfDay - 1;
                                AddNoOfDay = AddNoOfDay - 1;
                            }

                        }
                    }

                }

            }
            //if (AddNumberOfDay != 0)
            //{
            //    //ResultDate = listMultiDates2(ResultDate, ResultDate.AddDays(AddNumberOfDay), AddNumberOfDay);
            //    ResultDate = ResultDate.AddDays(1);

            //    //*****************هل هذا التاريخ يوم جمعه
            //    if (ResultDate.DayOfWeek == DayOfWeek.Friday)
            //    {
            //        //AddNoOfDay = AddNoOfDay;
            //        ResultDate = ResultDate.AddDays(1);
            //        AddNumberOfDay = AddNumberOfDay - 1;
            //        AddNoOfDay = AddNoOfDay - 1;
            //    }
            //    //*****************هل هذا التاريخ يوم سبت
            //    else if (ResultDate.DayOfWeek == DayOfWeek.Saturday)
            //    {
            //        //AddNoOfDay = AddNoOfDay;
            //        ResultDate = ResultDate.AddDays(1);
            //        AddNumberOfDay = AddNumberOfDay - 1;
            //        AddNoOfDay = AddNoOfDay - 1;
            //    }

            //}
            return ResultDate;
        }
  
        private DateTime listMultiDates8(DateTime startDate, DateTime endDate, int AddNoOfDay)
        {
            DateTime ResultDate = Convert.ToDateTime(startDate.ToString());
            for (int i = 0; i < AddNoDay; i++)
            {
                if (i == 0)
                { ResultDate = startDate; }

                //*****************هل هذا التاريخ يوم جمعه
                if (ResultDate.DayOfWeek == DayOfWeek.Friday)
                {

                    //if (i >= 0 && i < (AddNoDay - 1))
                    //    ResultDate = ResultDate.AddDays(3);
                    //else if (i == (AddNoDay - 1))
                    //{ ResultDate = ResultDate.AddDays(2); }
                    ResultDate = ResultDate.AddDays(2);
                }
                //***************** او هل هذا التاريخ يوم سبت
                else if (ResultDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    //if (i >= 0 && i < (AddNoDay - 1))
                    //    ResultDate = ResultDate.AddDays(2);
                    //else if (i == (AddNoDay - 1))
                    //{ ResultDate = ResultDate.AddDays(1); }
                    ResultDate = ResultDate.AddDays(1);
                }
                //************************* ام هل هذا التاريخ اجازه رسميه 
                else if (CheckDatewhithinVacationPeriodTrueFalse(ResultDate, ResultDate.Year) == true)

                {
                    ResultDate = CheckDatewhithinVacationPeriod(ResultDate, ResultDate.Year);
                    //if (i >= 0 && i < (AddNoDay - 1))
                    //    ResultDate = ResultDate.AddDays(2);
                    //else if (i == (AddNoDay - 1))
                    //{ ResultDate = ResultDate.AddDays(1); }
                    ResultDate = ResultDate.AddDays(1);
                    //*****************هل هذا التاريخ يوم جمعه
                    if (ResultDate.DayOfWeek == DayOfWeek.Friday)
                    {
                        //if (i >= 0 && i < (AddNoDay - 1))
                        //    ResultDate = ResultDate.AddDays(3);
                        //else if (i == (AddNoDay - 1))
                        //{ ResultDate = ResultDate.AddDays(2); }
                        ResultDate = ResultDate.AddDays(2);
                    }
                    //***************** او هل هذا التاريخ يوم سبت
                    else if (ResultDate.DayOfWeek == DayOfWeek.Saturday)
                    {
                        //if (i >= 0 && i < (AddNoDay - 1))
                        //    ResultDate = ResultDate.AddDays(2);
                        //else if (i == (AddNoDay - 1))
                        //{ ResultDate = ResultDate.AddDays(1); }
                        ResultDate = ResultDate.AddDays(2);
                    }
                }
                else
                {
                    if (i >= 0 && i < (AddNoDay - 1))
                        ResultDate = ResultDate.AddDays(1);
                    else if (i == (AddNoDay - 1))
                    {

                        ResultDate = ResultDate;
                    }
                }
            }
            if (CheckDatewhithinVacationPeriodTrueFalse(ResultDate, ResultDate.Year) == true)

            {
                ResultDate = CheckDatewhithinVacationPeriod(ResultDate, ResultDate.Year);
                ResultDate = ResultDate.AddDays(1);
                //*****************هل هذا التاريخ يوم جمعه
                if (ResultDate.DayOfWeek == DayOfWeek.Friday)
                {

                    ResultDate = ResultDate.AddDays(2);
                }
                //***************** او هل هذا التاريخ يوم سبت
                else if (ResultDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    ResultDate = ResultDate.AddDays(1);
                }
            }
            return ResultDate;
        }
        private DateTime listMultiDates3(DateTime startDate, DateTime endDate, int AddNoOfDay)
        {
            DateTime ResultDate = Convert.ToDateTime(startDate.ToString());

            int factor = 1;
            // Calculate the difference between the dates
            TimeSpan difference = endDate - startDate;
            // Generate a list of dates by multiplying the difference by the factor
            List<DateTime> resultList = new List<DateTime>();
            for (int i = 0; i <= difference.Days; i++)
            {
                resultList.Add(startDate.AddDays(i * factor));
            }
            // Print the result list of dates

            foreach (DateTime date in resultList)
            {
                if (date >= ResultDate)
                {
                    if (AddNoOfDay != 0)
                    {
                        AddNumberOfDay = AddNoOfDay;
                        //*****************هل هذا التاريخ يوم جمعه
                        if (date.DayOfWeek == DayOfWeek.Friday)
                        {

                            ResultDate = date.AddDays(2);
                            //AddNumberOfDay = AddNumberOfDay - 1;
                        }
                        //*****************هل هذا التاريخ يوم سبت
                        else if (date.DayOfWeek == DayOfWeek.Saturday)
                        {

                            ResultDate = date.AddDays(1);
                            //AddNumberOfDay = AddNumberOfDay - 1;
                        }
                        else
                        {
                            //AddNoOfDay = AddNoOfDay;
                            var list_VacationY = FsDb.Tbl_OfficialVacation.Where(x => x.VacationYear == ResultDate.Year && (ResultDate >= x.FromDate && ResultDate <= x.ToDate)).ToList();
                            if (list_VacationY.Count == 0)
                            {


                                //ResultDate = date;
                                if (ResultDate.DayOfWeek == DayOfWeek.Friday)
                                {
                                    //AddNoOfDay = AddNoOfDay;
                                    ResultDate = ResultDate.AddDays(1);

                                }
                                //*****************هل هذا التاريخ يوم سبت
                                if (ResultDate.DayOfWeek == DayOfWeek.Saturday)
                                {
                                    //AddNoOfDay = AddNoOfDay;
                                    ResultDate = ResultDate.AddDays(1);

                                }
                                else
                                {
                                    AddNumberOfDay = AddNoOfDay - 1;
                                    AddNoOfDay = AddNoOfDay - 1;
                                    if (AddNoOfDay != 0)
                                    { ResultDate = ResultDate.AddDays(1); }
                                    if (CheckDatewhithinVacationPeriodTrueFalse(ResultDate, ResultDate.Year) == true)
                                    { ResultDate = CheckDatewhithinVacationPeriod(ResultDate, ResultDate.Year); }
                                    //*****************هل هذا التاريخ يوم جمعه
                                    if (ResultDate.DayOfWeek == DayOfWeek.Friday)
                                    {
                                        //AddNoOfDay = AddNoOfDay;
                                        ResultDate = ResultDate.AddDays(1);

                                    }
                                    //*****************هل هذا التاريخ يوم سبت
                                    if (ResultDate.DayOfWeek == DayOfWeek.Saturday)
                                    {
                                        //AddNoOfDay = AddNoOfDay;
                                        ResultDate = ResultDate.AddDays(1);

                                    }
                                }

                            }
                            else
                            {
                                if (CheckDatewhithinVacationPeriodTrueFalse(ResultDate, ResultDate.Year) == true)
                                {

                                    ResultDate = CheckDatewhithinVacationPeriod(date, date.Year);
                                    ResultDate = ResultDate.AddDays(1);
                                    AddNumberOfDay = AddNumberOfDay - 1;
                                }



                                //*****************هل هذا التاريخ يوم جمعه
                                if (ResultDate.DayOfWeek == DayOfWeek.Friday)
                                {
                                    //AddNoOfDay = AddNoOfDay;
                                    ResultDate = ResultDate.AddDays(1);

                                }
                                //*****************هل هذا التاريخ يوم سبت
                                if (ResultDate.DayOfWeek == DayOfWeek.Saturday)
                                {
                                    //AddNoOfDay = AddNoOfDay;
                                    ResultDate = ResultDate.AddDays(1);

                                }

                            }
                            //if (CheckDatewhithinVacationPeriodTrueFalse(ResultDate, ResultDate.Year) == true)
                            //{

                            //    ResultDate = CheckDatewhithinVacationPeriod(ResultDate, ResultDate.Year);
                            //    ResultDate = ResultDate.AddDays(1);
                            //    //*****************هل هذا التاريخ يوم جمعه
                            //    if (date.DayOfWeek == DayOfWeek.Friday)
                            //    {

                            //        ResultDate = ResultDate.AddDays(1);

                            //    }
                            //    //*****************هل هذا التاريخ يوم سبت
                            //    else if (date.DayOfWeek == DayOfWeek.Saturday)
                            //    {
                            //        //AddNoOfDay = AddNoOfDay;
                            //        ResultDate = ResultDate.AddDays(1);


                            //    }

                            //}

                            if (AddNumberOfDay != 0)
                            {
                                //ResultDate = listMultiDates2(ResultDate, ResultDate.AddDays(AddNumberOfDay), AddNumberOfDay);
                                ResultDate = ResultDate.AddDays(1);
                                AddNumberOfDay = AddNumberOfDay - 1;
                                //*****************هل هذا التاريخ يوم جمعه
                                if (ResultDate.DayOfWeek == DayOfWeek.Friday)
                                {
                                    //AddNoOfDay = AddNoOfDay;
                                    ResultDate = ResultDate.AddDays(2);
                                }
                                //*****************هل هذا التاريخ يوم سبت
                                else if (ResultDate.DayOfWeek == DayOfWeek.Saturday)
                                {
                                    //AddNoOfDay = AddNoOfDay;
                                    ResultDate = ResultDate.AddDays(1);
                                }
                                //AddNumberOfDay = AddNumberOfDay - 1;
                            }
                        }

                    }

                }
            }
            return ResultDate;
        }
        private DateTime listMultiDates2(DateTime startDate, DateTime endDate, int AddNoOfDay)
        {
            DateTime ResultDate = Convert.ToDateTime(DateTime.Today.ToString());

            int factor = 1;
            // Calculate the difference between the dates
            TimeSpan difference = endDate - startDate;
            // Generate a list of dates by multiplying the difference by the factor
            List<DateTime> resultList = new List<DateTime>();
            for (int i = 0; i <= difference.Days; i++)
            {
                resultList.Add(startDate.AddDays(i * factor));
            }
            // Print the result list of dates
            Console.WriteLine("Result List of Dates:");
            foreach (DateTime date in resultList)
            {

                AddNumberOfDay = AddNoOfDay;
                //*****************هل هذا التاريخ يوم جمعه
                if (date.DayOfWeek == DayOfWeek.Friday)
                {

                    ResultDate = date.AddDays(2);
                }
                //*****************هل هذا التاريخ يوم سبت
                else if (date.DayOfWeek == DayOfWeek.Saturday)
                {

                    ResultDate = date.AddDays(1);
                }
                else
                {
                    //AddNoOfDay = AddNoOfDay;
                    var list_VacationY = FsDb.Tbl_OfficialVacation.Where(x => x.VacationYear == date.Year && (date >= x.FromDate && date <= x.ToDate)).ToList();
                    if (list_VacationY.Count == 0)
                    {

                        AddNumberOfDay = AddNoOfDay - 1;
                        AddNoOfDay = AddNoOfDay - 1;
                        if (AddNumberOfDay == 0)
                        {
                            AddNumberOfDay = 1;
                        }
                        ResultDate = date.AddDays(1);
                    }
                    else
                    {
                        ResultDate = CheckDatewhithinVacationPeriod(date, date.Year);
                        //*****************هل هذا التاريخ يوم جمعه
                        if (ResultDate.DayOfWeek == DayOfWeek.Friday)
                        {
                            //AddNoOfDay = AddNoOfDay;
                            ResultDate = date.AddDays(2);
                        }
                        //*****************هل هذا التاريخ يوم سبت
                        else if (ResultDate.DayOfWeek == DayOfWeek.Saturday)
                        {
                            //AddNoOfDay = AddNoOfDay;
                            ResultDate = date.AddDays(1);
                        }
                    }
                }


            }

            return ResultDate;
        }
        private TimeSpan CalculateVacationPeriod(DateTime fromDate, DateTime toDate)
        {
            return toDate - fromDate;
        }

        private DateTime CheckDatewhithinVacationPeriod(DateTime Vdate, int Vyear)
        {
            DateTime Vdate_LastVacationDate = DateTime.Now;

            var list_VacationY = FsDb.Tbl_OfficialVacation.Where(x => x.VacationYear == Vdate.Year && (Vdate >= x.FromDate && Vdate <= x.ToDate)).ToList();
            if (list_VacationY.Count != 0)
            {
                foreach (var TT in list_VacationY)

                {
                    if (Vdate >= TT.FromDate && Vdate <= TT.ToDate)
                    {
                        Vdate_LastVacationDate = Convert.ToDateTime(TT.ToDate.ToString());

                    }

                }

            }
            return Vdate_LastVacationDate;

        }
        private Boolean CheckDatewhithinVacationPeriodTrueFalse(DateTime Vdate, int Vyear)
        {
            bool Vbl_IsVacation = false;

            var list_VacationY = FsDb.Tbl_OfficialVacation.Where(x => x.VacationYear == Vdate.Year && (Vdate >= x.FromDate && Vdate <= x.ToDate)).ToList();
            if (list_VacationY.Count != 0)
            {
                foreach (var TT in list_VacationY)

                {
                    if (Vdate >= TT.FromDate && Vdate <= TT.ToDate)
                    {
                        Vbl_IsVacation = true;

                    }

                }

            }
            return Vbl_IsVacation;

        }

        private DateTime CheckDatewhithinVacationPeriodF(DateTime Vdate, int Vyear)
        {
            Boolean xx = false;

            DateTime Vdate_LastVacationDate = DateTime.Now;
            var list_VacationY = FsDb.Tbl_OfficialVacation.Where(x => x.VacationYear == Vyear).ToList();
            foreach (var TT in list_VacationY)

            {
                if (Vdate >= TT.FromDate && Vdate <= TT.ToDate)
                {
                    Vdate_LastVacationDate = Convert.ToDateTime(TT.FromDate.ToString());
                    xx = true;
                }

            }
            if (xx == false)
            {

                int xv = 0 - AddNoDay;
                Vdate_LastVacationDate = Vdate.AddDays(xv);
                foreach (var TT in list_VacationY)

                {
                    if (Vdate_LastVacationDate >= TT.FromDate && Vdate_LastVacationDate <= TT.ToDate)
                    {
                        Vdate_LastVacationDate = Convert.ToDateTime(TT.FromDate.ToString());

                    }

                }
            }

            return Vdate_LastVacationDate;

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

        public DateTime SelectDateRightDateBank(DateTime Vd_RightDateBank, int Vint_Year)
        {
            DateTime Vd_RightDateResult = Convert.ToDateTime(DateTime.Today.ToString());
            DateTime Vd_LastOficialVacationDate = Convert.ToDateTime(DateTime.Today.ToString());
            bool Vb_IsVacation = false;
            //*****************هل هذا التاريخ اجازه رسميه
            Vb_IsVacation = CheckDatewhithinVacationPeriodTrueFalse(Vd_RightDateBank, Vint_Year);
            if (Vb_IsVacation == true)
            {
                Vd_LastOficialVacationDate = CheckDatewhithinVacationPeriod(Vd_RightDateBank, Vint_Year);
                Vd_RightDateResult = Vd_LastOficialVacationDate.AddDays(1);


                //*****************هل هذا التاريخ يوم جمعه
                if (Vd_RightDateResult.DayOfWeek == DayOfWeek.Friday)
                {
                    Vd_RightDateResult = Vd_RightDateResult.AddDays(2);

                }
                //*****************هل هذا التاريخ يوم سبت
                else if (Vd_RightDateResult.DayOfWeek == DayOfWeek.Saturday)
                {
                    Vd_RightDateResult = Vd_RightDateResult.AddDays(1);

                }

            }
            else
            {
                //*****************هل هذا التاريخ يوم جمعه
                if (Vd_RightDateBank.DayOfWeek == DayOfWeek.Friday)
                {
                    Vd_RightDateResult = Vd_RightDateBank.AddDays(2);

                }
                //*****************هل هذا التاريخ يوم سبت
                else if (Vd_RightDateBank.DayOfWeek == DayOfWeek.Saturday)
                {
                    Vd_RightDateResult = Vd_RightDateBank.AddDays(1);

                }
                else
                {
                    Vd_RightDateResult = Vd_RightDateBank;
                }
            }


            return Vd_RightDateResult;
        }

        public DateTime SelectDateRightDateBankN(DateTime Vd_RightDateBank, int Vint_Year)
        {
            DateTime Vd_RightDateResult = Convert.ToDateTime(DateTime.Today.ToString());
            DateTime Vd_LastOficialVacationDate = Convert.ToDateTime(DateTime.Today.ToString());
            bool Vb_IsVacation = false;
            
            //*****************هل هذا التاريخ اجازه رسميه
            Vb_IsVacation = CheckDatewhithinVacationPeriodTrueFalse(Vd_RightDateBank, Vint_Year);
            if (Vb_IsVacation == true)
            {
                Vd_LastOficialVacationDate = CheckDatewhithinVacationPeriod(Vd_RightDateBank, Vint_Year);
                Vd_RightDateResult = Vd_LastOficialVacationDate.AddDays(1);


                //*****************هل هذا التاريخ يوم جمعه
                if (Vd_RightDateResult.DayOfWeek == DayOfWeek.Friday)
                {
                    Vd_RightDateResult = Vd_RightDateResult.AddDays(2);

                }
                //*****************هل هذا التاريخ يوم سبت
                else if (Vd_RightDateResult.DayOfWeek == DayOfWeek.Saturday)
                {
                    Vd_RightDateResult = Vd_RightDateResult.AddDays(1);

                }

            }
            else
            {
                //*****************هل هذا التاريخ يوم جمعه
                if (Vd_RightDateBank.DayOfWeek == DayOfWeek.Friday)
                {
                    Vd_RightDateResult = Vd_RightDateBank.AddDays(2);

                }
                //*****************هل هذا التاريخ يوم سبت
                else if (Vd_RightDateBank.DayOfWeek == DayOfWeek.Saturday)
                {
                    Vd_RightDateResult = Vd_RightDateBank.AddDays(1);

                }
                else
                {
                    Vd_RightDateResult = Vd_RightDateBank;
                }
                Vb_IsVacation = CheckDatewhithinVacationPeriodTrueFalse(Vd_RightDateResult, Vint_Year);
                if (Vb_IsVacation == true)
                {
                    Vd_LastOficialVacationDate = CheckDatewhithinVacationPeriod(Vd_RightDateResult, Vint_Year);
                    Vd_RightDateResult = Vd_LastOficialVacationDate.AddDays(1);
                }
            }


            return Vd_RightDateResult;
        }
    }
}
