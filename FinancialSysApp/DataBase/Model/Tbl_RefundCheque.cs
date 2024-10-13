namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_RefundCheque
    {
        public int ID { get; set; }

        public long BankChequesID { get; set; }

        public bool? IsRefundCheque { get; set; }

        public int? RefundCheqResonID { get; set; }

        public bool? IsWithDrawCheq { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RefundDate { get; set; }

        public virtual Tbl_BankCheques Tbl_BankCheques { get; set; }

        public virtual Tbl_RefundCheqReson Tbl_RefundCheqReson { get; set; }
    }
}
