namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("view- financial 2023-2022")]
    public partial class view__financial_2023_2022
    {
        [Key]
        [Column(Order = 0)]
        public string Expr1 { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string Account_NO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Expr3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Expr4 { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string Expr2 { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}
