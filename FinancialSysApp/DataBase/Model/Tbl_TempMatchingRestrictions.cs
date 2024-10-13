namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_TempMatchingRestrictions
    {
        public int ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Restriction_NO { get; set; }

        [Column(TypeName = "date")]
        public DateTime Restriction_Date { get; set; }

        public int? AccountingRestrictionKind_ID { get; set; }

        public int? Accounting_Guid_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Debit_Value { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Credit_Value { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TransfeerDate { get; set; }
    }
}
