namespace FinancialSysApp.DataBase.ModelEvents
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_AccountingRestrictionItems_audits
    {
        [Key]
        public long Change_ID { get; set; }

        public int? AccountingRestrictionItemsID { get; set; }

        public short Row_No { get; set; }

        public long AccountingRestriction_ID { get; set; }

        public int? Accounting_Guid_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Debit_Value { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Credit_Value { get; set; }

        public int? RestrictionItemsCategory_ID { get; set; }

        public int? Activities_ID { get; set; }

        public int? CostCenters_ID { get; set; }

        public int? AccountingRestrictionKind_ID { get; set; }

        public DateTime? Updated_at { get; set; }

        [StringLength(5)]
        public string Oberation { get; set; }
    }
}
