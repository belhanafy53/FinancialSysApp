namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Treasury
    {
        public int ID { get; set; }

        public int ProcessingKindId { get; set; }

        public int CashCheqKindID { get; set; }

        [Required]
        [StringLength(50)]
        public string CashCheqNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime CashCheqDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Value { get; set; }

        public int? Benf_ID { get; set; }

        public int? TenderID { get; set; }

        public int? BankDraweeID { get; set; }

        public int? DepositoryBankID { get; set; }

        public int? ManagementTellerEmpID { get; set; }

        [StringLength(50)]
        public string CheckReceiptNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CheckReceiptDate { get; set; }

        public int? CheckRecieveEmpID { get; set; }

        [StringLength(50)]
        public string ClipboardNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ClipbordDate { get; set; }

        public int? BankCheckStatusId { get; set; }

        [StringLength(250)]
        public string BankAccountNo { get; set; }

        public int? TreasuryItemsId { get; set; }

        public virtual Tbl_TreasuryItems Tbl_TreasuryItems { get; set; }
    }
}
