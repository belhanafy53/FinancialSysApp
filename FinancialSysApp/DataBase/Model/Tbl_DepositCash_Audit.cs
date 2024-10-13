namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_DepositCash_Audit
    {
        public long ID { get; set; }

        public long? DepositCashID { get; set; }

        public bool? IsDepositOk { get; set; }

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

        public int? UserIDData { get; set; }
    }
}
