namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_AccountByAccountSetting
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string AccountNumber { get; set; }

        [StringLength(250)]
        public string AccountName { get; set; }

        public int? Account_Guid_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateFrom { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateTo { get; set; }

        [StringLength(10)]
        public string RestrictionItems_ID { get; set; }

        [StringLength(120)]
        public string Restriction_no { get; set; }

        public int? RestrictionKind_ID { get; set; }

        public decimal? Debit { get; set; }

        public decimal? Credit { get; set; }
    }
}
