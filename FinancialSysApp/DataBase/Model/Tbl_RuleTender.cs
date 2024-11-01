namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_RuleTender
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string RuleName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RuleValue { get; set; }

        public int? TendersAuctionsID { get; set; }

        public int? VariableTenderID { get; set; }

        public virtual Tbl_TendersAuctions Tbl_TendersAuctions { get; set; }

        public virtual Tbl_VariabeTender Tbl_VariabeTender { get; set; }
    }
}
