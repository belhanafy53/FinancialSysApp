namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vie_Balance
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal Debit_Value { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal Credit_Value { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime Restriction_Date { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(100)]
        public string Account_NO { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Expr1 { get; set; }

        public int? Accounting_Guid_ID { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Expr2 { get; set; }

        public int? AccountingRestrictionKind_ID { get; set; }

        [StringLength(10)]
        public string FYear { get; set; }
    }
}
