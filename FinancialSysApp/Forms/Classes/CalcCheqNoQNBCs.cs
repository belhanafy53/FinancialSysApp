using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;

namespace FinancialSysApp.Classes
{
   
    internal class CalcCheqNoQNBCs
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        public static string CheqNoBank(string CheckNoBank)
        {
            string result = null;
            int Vint_Lngth = 0;
            int Vint_MultiblyLength = 0;
            Vint_Lngth = CheckNoBank.Length;
            Vint_MultiblyLength = 14 - CheckNoBank.Length;
            for (int i = 0; i < Vint_MultiblyLength; i++)
            {
                result = "0" + CheckNoBank ;
                CheckNoBank = result;
            }
            return result;
        }

    }
}
