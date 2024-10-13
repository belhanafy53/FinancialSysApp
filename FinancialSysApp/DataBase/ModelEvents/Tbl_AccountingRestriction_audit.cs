namespace FinancialSysApp.DataBase.ModelEvents
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_AccountingRestriction_audit
    {
        [Key]
        public long Change_ID { get; set; }

        [StringLength(10)]
        public string RestrictionID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Restriction_NO { get; set; }

        [Column(TypeName = "date")]
        public DateTime Restriction_Date { get; set; }

        public int? Document_ID { get; set; }

        public int? AccountingRestrictionKind_ID { get; set; }

        public int? AcountingRestrictionCorrRelation_ID { get; set; }

        public DateTime? Updated_at { get; set; }

        [StringLength(5)]
        public string Oberation { get; set; }
    }
}
