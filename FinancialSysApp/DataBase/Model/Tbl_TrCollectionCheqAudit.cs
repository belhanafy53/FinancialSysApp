namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_TrCollectionCheqAudit
    {
        public long ID { get; set; }

        public int UserID { get; set; }

        public long TreasurCollectionId { get; set; }

        public bool? TreasurCollection { get; set; }

        public bool? BankCheque { get; set; }

        public DateTime? ReferenceDate { get; set; }
    }
}
