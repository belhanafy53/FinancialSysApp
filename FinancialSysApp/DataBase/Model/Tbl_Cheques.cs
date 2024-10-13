namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Cheques
    {
        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string ChequeNO { get; set; }

        [Column(TypeName = "date")]
        public DateTime ChequeDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ChequeValue { get; set; }

        public int Bank_ID { get; set; }

        public long? AccountingRestriction_ID { get; set; }

        public virtual Tbl_AccountingRestriction Tbl_AccountingRestriction { get; set; }
    }
}
