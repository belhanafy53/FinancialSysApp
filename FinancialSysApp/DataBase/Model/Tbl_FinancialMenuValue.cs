namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_FinancialMenuValue
    {
        public int ID { get; set; }

        public int Tbl_FinancialMenuSettingID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DuePaymentValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CashPaymentValue { get; set; }

        [Column(TypeName = "date")]
        public DateTime FDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime TDate { get; set; }

        public virtual Tbl_FinancialMenuSetting Tbl_FinancialMenuSetting { get; set; }
    }
}
