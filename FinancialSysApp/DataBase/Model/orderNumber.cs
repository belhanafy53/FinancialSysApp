namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("orderNumber")]
    public partial class orderNumber
    {
        [Column(TypeName = "numeric")]
        public decimal? Restriction_NO { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Restriction_Date { get; set; }

        [StringLength(100)]
        public string Account_NO { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Debit_Value { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Credit_Value { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Order_NO { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime Order_Date { get; set; }

        public int? AccountingRestrictionKind_ID { get; set; }
    }
}
