namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Classify")]
    public partial class Classify
    {
        [Column(TypeName = "numeric")]
        public decimal? مدين { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? دائن { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Restriction_NO { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Restriction_Date { get; set; }

        public string Expr1 { get; set; }

        [Key]
        [StringLength(100)]
        public string Account_NO { get; set; }

        [StringLength(50)]
        public string Expr2 { get; set; }

        [StringLength(10)]
        public string FYear { get; set; }

        public int? ID { get; set; }
    }
}
