namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_UserNoteToSystemUnite
    {
        public long ID { get; set; }

        public long? AccountingRestrictionID { get; set; }

        public bool? IsRestrictionNot { get; set; }

        public DateTime? NoteDate { get; set; }

        public int? SystemUnitesID { get; set; }

        public int? UserIDData { get; set; }

        [StringLength(150)]
        public string Note { get; set; }

        [StringLength(150)]
        public string Note1 { get; set; }

        public bool? IsUserUpdate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UserUpdateDate { get; set; }

        public long? OrderID { get; set; }

        public int? UserUpdateID { get; set; }

        public virtual Tbl_AccountingRestriction Tbl_AccountingRestriction { get; set; }
    }
}
