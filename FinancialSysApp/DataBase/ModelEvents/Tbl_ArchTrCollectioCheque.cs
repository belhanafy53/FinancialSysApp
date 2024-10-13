namespace FinancialSysApp.DataBase.ModelEvents
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_ArchTrCollectioCheque
    {
        public long ID { get; set; }

        [StringLength(350)]
        public string PathFile { get; set; }

        public long? TrCollectionID { get; set; }

        public long? ChequeBankID { get; set; }

        public int? DocumentHirarchyID { get; set; }
    }
}
