namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_AccountingRestriction_Audit
    {
        public int ID { get; set; }

        public long? AccountingRestrictionID { get; set; }

        public bool? RestrictionDataID { get; set; }

        public DateTime? ReferenceDate { get; set; }

        public int? UserID { get; set; }

        [StringLength(500)]
        public string Note { get; set; }

        [StringLength(500)]
        public string Note1 { get; set; }

        public int? UserIDData { get; set; }

        public bool? IsUserUpdate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UserUpdateDate { get; set; }

        public int? ManagamentID { get; set; }

        public virtual Tbl_AccountingRestriction Tbl_AccountingRestriction { get; set; }

        public virtual Tbl_User Tbl_User { get; set; }
    }
}
