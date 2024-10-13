namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_TreasuryCollection_Audit
    {
        public int ID { get; set; }

        public long? TreasuryCollectionID { get; set; }

        public long? BankCheqeID { get; set; }

        public bool? IsTrcollection { get; set; }

        public bool? IsCheqBank { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReferenceDate { get; set; }

        public int? UserID { get; set; }

        [StringLength(250)]
        public string Note { get; set; }

        [StringLength(250)]
        public string NoteAdd { get; set; }

        public bool? IsUpdate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }

        public virtual Tbl_TreasuryCollection Tbl_TreasuryCollection { get; set; }

        public virtual Tbl_User Tbl_User { get; set; }
    }
}
