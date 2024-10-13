namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_TreasuryCollection
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_TreasuryCollection()
        {
            Tbl_BankCheques = new HashSet<Tbl_BankCheques>();
            Tbl_TreasuryCollection_Audit = new HashSet<Tbl_TreasuryCollection_Audit>();
        }

        public long ID { get; set; }

        public int? BankDepositeID { get; set; }

        public int? BankAccounNoID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DepositDate { get; set; }

        [StringLength(100)]
        public string CollectionNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CollectionDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalAmountCheqs { get; set; }

        public int? BranchID { get; set; }

        public int? RepresentiveID { get; set; }

        public int? ChequeReceivedKindID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AddRecievedDate { get; set; }

        public int? FYear { get; set; }

        [StringLength(100)]
        public string TradeCollectionNo { get; set; }

        public bool? IsDepositNo { get; set; }

        [StringLength(100)]
        public string ReceiptNo { get; set; }

        public long? Parent_ID { get; set; }

        public int? FisicalYearID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_BankCheques> Tbl_BankCheques { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_TreasuryCollection_Audit> Tbl_TreasuryCollection_Audit { get; set; }
    }
}
