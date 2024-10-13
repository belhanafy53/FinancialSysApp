namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_BnkMovementCustTypeOld
    {
        public long ID { get; set; }

        public long BankMovID { get; set; }

        public int? TradeMoveType { get; set; }

        public int? BranchId { get; set; }

        public DateTime? DailyDate { get; set; }

        public virtual Tbl_BankMovement Tbl_BankMovement { get; set; }
    }
}
