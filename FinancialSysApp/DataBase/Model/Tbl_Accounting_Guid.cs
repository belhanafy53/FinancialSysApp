namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Accounting_Guid
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Accounting_Guid()
        {
            Tbl_AccountingRestrictionItems = new HashSet<Tbl_AccountingRestrictionItems>();
            Tbl_FinancialMenuAccountByAccountDuePaymentBlus = new HashSet<Tbl_FinancialMenuAccountByAccountDuePaymentBlus>();
            Tbl_FinancialMenuAccountsDuePaymentBlus = new HashSet<Tbl_FinancialMenuAccountsDuePaymentBlus>();
            Tbl_FinancialMenuCategoryDuePaymentBlus = new HashSet<Tbl_FinancialMenuCategoryDuePaymentBlus>();
            TBL_FinancialMenuProcessing = new HashSet<TBL_FinancialMenuProcessing>();
            Tbl_FinanctialMenueLinkedFunction = new HashSet<Tbl_FinanctialMenueLinkedFunction>();
            Tbl_Match_AccGuid_DocCategory = new HashSet<Tbl_Match_AccGuid_DocCategory>();
        }

        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Account_NO { get; set; }

        [Required]
        [StringLength(100)]
        public string Parent_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime From_Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? To_Date { get; set; }

        public int? AccountsKind_ID { get; set; }

        public int? PersonalAccount { get; set; }

        [StringLength(100)]
        public string Advac_AccountingNO { get; set; }

        public bool? ExpensesAccount { get; set; }

        public bool? HighamountsAccount { get; set; }

        public bool? BrokerAccount { get; set; }

        public bool? ExtrasFinancialYear { get; set; }

        public bool? ElectronicPayments { get; set; }

        public bool? ChequeOut { get; set; }

        public virtual Tbl_AccountsKind Tbl_AccountsKind { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_AccountingRestrictionItems> Tbl_AccountingRestrictionItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_FinancialMenuAccountByAccountDuePaymentBlus> Tbl_FinancialMenuAccountByAccountDuePaymentBlus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_FinancialMenuAccountsDuePaymentBlus> Tbl_FinancialMenuAccountsDuePaymentBlus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_FinancialMenuCategoryDuePaymentBlus> Tbl_FinancialMenuCategoryDuePaymentBlus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_FinancialMenuProcessing> TBL_FinancialMenuProcessing { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_FinanctialMenueLinkedFunction> Tbl_FinanctialMenueLinkedFunction { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Match_AccGuid_DocCategory> Tbl_Match_AccGuid_DocCategory { get; set; }
    }
}
