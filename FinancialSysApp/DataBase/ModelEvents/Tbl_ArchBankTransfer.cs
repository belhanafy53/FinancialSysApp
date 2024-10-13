namespace FinancialSysApp.DataBase.ModelEvents
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_ArchBankTransfer
    {
        public long ID { get; set; }

        [StringLength(350)]
        public string PathFile { get; set; }

        public long? BankTransferPayID { get; set; }

        public int? DocumentHirarchyID { get; set; }
    }
}
