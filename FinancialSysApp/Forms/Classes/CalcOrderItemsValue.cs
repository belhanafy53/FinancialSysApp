using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialSysApp.Classes
{
    class CalcOrderItemsValue
    {
        public static Decimal Cs_CalcOrderItemsValueBefore(string Vst_Qnty, string Vst_price, string Vst_attach, decimal Vdec_tax, bool PriceInclude)
        {
            decimal Result_ValueBefore = 0;
            if (Vst_Qnty =="") { Vst_Qnty = "0"; }
            decimal Vdec_qnty = decimal.Parse(Vst_Qnty);
            if (Vst_price == "") { Vst_price = "0"; }
            decimal Vdec_price = decimal.Parse(Vst_price);
            if (Vst_attach == "") { Vst_attach = "0"; }
            decimal Vdec_Attach = decimal.Parse(Vst_attach);

            
            
            if (PriceInclude == true)
            { 
                Result_ValueBefore = Math.Round(((Vdec_qnty * Vdec_price) + Vdec_Attach),2); 
            }
            else
            {
                Vdec_tax = Math.Round(Vdec_price * ((Vdec_tax *100) / ((Vdec_tax * 100) + 100) ),2);
                Vdec_price = Vdec_price - Vdec_tax;
                Result_ValueBefore = (Vdec_qnty * Vdec_price) + Vdec_Attach;
            }

            return Result_ValueBefore;
            
        }
        public static Decimal Cs_CalcOrderItemsValueAfter(string Vst_Qnty, string Vst_price, string Vst_attach, decimal Vdec_tax, bool PriceInclude)
        {
            if (Vst_Qnty == "") { Vst_Qnty = "0"; }
            decimal Vdec_qnty = decimal.Parse(Vst_Qnty);
            if (Vst_price == "") { Vst_price = "0"; }
            decimal Vdec_price = decimal.Parse(Vst_price);
            if (Vst_attach == "") { Vst_attach = "0"; }
            decimal Vdec_Attach = decimal.Parse(Vst_attach);

            decimal Result_ValueAfter = 0;
            if (PriceInclude == true)
            {
                Result_ValueAfter = Math.Round((((Vdec_qnty * Vdec_price) + Vdec_Attach) + ((Vdec_qnty * Vdec_price) + Vdec_Attach) * Vdec_tax),2);
            }
            else
            {
                Result_ValueAfter = Math.Round((((Vdec_qnty * Vdec_price) + Vdec_Attach)),2);
            }
                return Result_ValueAfter;
        }
    }
}
