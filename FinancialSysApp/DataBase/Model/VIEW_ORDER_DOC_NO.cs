namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VIEW ORDER-DOC NO")]
    public partial class VIEW_ORDER_DOC_NO
    {
        [Column("رقم الامر")]
        [StringLength(50)]
        public string رقم_الامر { get; set; }

        [Column("تاريخ الامر", TypeName = "date")]
        public DateTime? تاريخ_الامر { get; set; }

        [Column("نوع الامر")]
        [StringLength(50)]
        public string نوع_الامر { get; set; }

        [StringLength(150)]
        public string المورد { get; set; }

        [Column("نوع المورد")]
        [StringLength(20)]
        public string نوع_المورد { get; set; }

        [Column("رقم القيد", TypeName = "numeric")]
        public decimal? رقم_القيد { get; set; }

        [Column("تاريخ القيد", TypeName = "date")]
        public DateTime? تاريخ_القيد { get; set; }

        [StringLength(350)]
        public string الغرض { get; set; }

        [Column("نوع القيد")]
        [StringLength(50)]
        public string نوع_القيد { get; set; }

        [StringLength(150)]
        public string المستفيد { get; set; }

        public int? ID { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        public int? Expr1 { get; set; }

        public string Expr2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? مدين { get; set; }

        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal دائن { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Expr3 { get; set; }

        public string Expr4 { get; set; }
    }
}
