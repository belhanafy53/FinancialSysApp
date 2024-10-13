namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_4
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal Restriction_NO { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime Restriction_Date { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Debit_Value { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Credit_Value { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        public int? Document_ID { get; set; }

        public int? Accounting_Guid_ID { get; set; }

        [StringLength(10)]
        public string FYear { get; set; }

        public int? AccountingRestrictionKind_ID { get; set; }

        public long? AccountingRestriction_ID { get; set; }

        public long? Expr1 { get; set; }
    }
}
