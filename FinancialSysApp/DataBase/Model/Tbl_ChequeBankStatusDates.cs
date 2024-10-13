namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_ChequeBankStatusDates
    {
        public long ID { get; set; }

        public int? BankChequeStatusID { get; set; }

        public long? BankChequeID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ChequeBankStatusDate { get; set; }

        public virtual Tbl_BankCheques Tbl_BankCheques { get; set; }

        public virtual Tbl_ChequeBankStatus Tbl_ChequeBankStatus { get; set; }
    }
}
