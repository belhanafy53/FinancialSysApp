namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_BankMovement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_BankMovement()
        {
            Tbl_BnkMovementCustTypeOld = new HashSet<Tbl_BnkMovementCustTypeOld>();
            Tbl_MovementTypingAudit = new HashSet<Tbl_MovementTypingAudit>();
        }

        public long ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? MoveDat { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BankDueDate { get; set; }

        [StringLength(50)]
        public string NumberRefrBank { get; set; }

        [StringLength(500)]
        public string DescriptionNote { get; set; }

        [StringLength(10)]
        public string Currency { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TransferValue { get; set; }

        [StringLength(50)]
        public string DebitCredit { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Balance { get; set; }

        [StringLength(100)]
        public string C1 { get; set; }

        [StringLength(100)]
        public string C2 { get; set; }

        [StringLength(100)]
        public string C22 { get; set; }

        [StringLength(100)]
        public string C3 { get; set; }

        [StringLength(100)]
        public string C4 { get; set; }

        [StringLength(100)]
        public string C5 { get; set; }

        [StringLength(150)]
        public string C6 { get; set; }

        public int? BankID { get; set; }

        public int? BankAccID { get; set; }

        [StringLength(50)]
        public string MovementCode { get; set; }

        public int? FisicalYeariD { get; set; }

        public int? MoveType1 { get; set; }

        public int? MoveType2 { get; set; }

        public bool? IsSelectedType { get; set; }

        public long? BankCheqID { get; set; }

        public long? DepositCashID { get; set; }

        public long? TransferID { get; set; }

        public bool? IsCollected { get; set; }

        public int? TradeMoveType { get; set; }

        public int? BranchId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DailyDate { get; set; }

        public long? TradeCode { get; set; }

        public int? MoveType3 { get; set; }

        public int? AccountBankCode { get; set; }

        public virtual Tbl_Banks Tbl_Banks { get; set; }

        public virtual Tbl_MovementBankType Tbl_MovementBankType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_BnkMovementCustTypeOld> Tbl_BnkMovementCustTypeOld { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_MovementTypingAudit> Tbl_MovementTypingAudit { get; set; }
    }
}
