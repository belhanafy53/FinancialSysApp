namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class relation_restriction
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal Restriction_NO { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime Restriction_Date { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Expr1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Expr2 { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal مستند_الربط { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime تاريخ_مستند_الربط { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? مدين_الربط { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? دائن_الربط { get; set; }

        public int? AcountingRestrictionCorrRelation_ID { get; set; }

        public int? Expr3 { get; set; }

        public bool? BrokerAccount { get; set; }
    }
}
