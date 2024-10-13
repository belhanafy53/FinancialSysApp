namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_3
    {
        [Key]
        [Column(Order = 0)]
        public string sector { get; set; }

        [Key]
        [Column(Order = 1)]
        public string management { get; set; }

        [StringLength(100)]
        public string BrancheName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_cash { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_cheque { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cheque_amount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cash_amount { get; set; }
    }
}
