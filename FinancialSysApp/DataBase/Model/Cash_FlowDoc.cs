namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cash_FlowDoc
    {
        [Key]
        [Column(Order = 0)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string Account_NO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Expr1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Expr4 { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(250)]
        public string Expr2 { get; set; }

        public string Expr3 { get; set; }
    }
}
