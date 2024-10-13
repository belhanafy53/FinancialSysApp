namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class V_AcountByAcount1
    {
        [Column(TypeName = "numeric")]
        public decimal? Expr1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Expr2 { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AccountingRestriction_ID { get; set; }
    }
}
