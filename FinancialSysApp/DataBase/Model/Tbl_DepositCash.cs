namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_DepositCash
    {
        public long ID { get; set; }

        public int? BranchID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DepositDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BankDueDate { get; set; }

        public int? DepositBankID { get; set; }

        public int? AccBankID { get; set; }

        public int? RepresentiveID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AmountCash { get; set; }

        public int? FYear { get; set; }

        [StringLength(150)]
        public string DepositCashNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BankAddDate { get; set; }

        public int? DepositCashStatusID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DepositCashStatusDate { get; set; }

        public bool? IsAddedAccNo { get; set; }

        [StringLength(10)]
        public string BankPaperNo { get; set; }

        public virtual Tbl_Banks Tbl_Banks { get; set; }

        public virtual Tbl_Management Tbl_Management { get; set; }
    }
}
