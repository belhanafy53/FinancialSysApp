namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_BankCheques
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_BankCheques()
        {
            Tbl_ChequeBankStatusDates = new HashSet<Tbl_ChequeBankStatusDates>();
            Tbl_RefundCheque = new HashSet<Tbl_RefundCheque>();
        }

        public long ID { get; set; }

        public long? TreasuryCollectionID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AmountCheque { get; set; }

        public int? BankDrawnOnID { get; set; }

        [StringLength(100)]
        public string ChequeNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ChequeDueDate { get; set; }

        public int? DepositedByTrRepresntvID { get; set; }

        public int? CustID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AddDateBank { get; set; }

        public int? ChequeKindID { get; set; }

        [StringLength(100)]
        public string TradeCollectionNo { get; set; }

        public bool? IsDepositNo { get; set; }

        public int? ChequeStatusID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ChequeStatusDate { get; set; }

        public bool? IsAddedAccNo { get; set; }

        public int? FisicalYearID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AddDateAccBank { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BankDueDate { get; set; }

        public virtual Tbl_ChequeKind Tbl_ChequeKind { get; set; }

        public virtual Tbl_TreasuryCollection Tbl_TreasuryCollection { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_ChequeBankStatusDates> Tbl_ChequeBankStatusDates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_RefundCheque> Tbl_RefundCheque { get; set; }
    }
}
