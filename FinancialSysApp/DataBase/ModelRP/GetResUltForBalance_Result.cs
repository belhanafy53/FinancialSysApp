//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinancialSysApp.DataBase.ModelRP
{
    using System;
    
    public partial class GetResUltForBalance_Result
    {
        public string رقم_الحساب { get; set; }
        public string اسم_الحساب { get; set; }
        public Nullable<decimal> قيد_افتتاحى_مدين { get; set; }
        public Nullable<decimal> قيد_افتتاحى_دائن { get; set; }
        public Nullable<decimal> عمليات_مدين { get; set; }
        public Nullable<decimal> عمليات_دائن { get; set; }
        public Nullable<decimal> نقدى_مدين { get; set; }
        public Nullable<decimal> نقدى_دائن { get; set; }
        public Nullable<double> الرصيد { get; set; }
    }
}
