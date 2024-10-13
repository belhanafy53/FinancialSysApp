namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_AccountingRestrictions_Kind
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_AccountingRestrictions_Kind()
        {
            Tbl_AccountingRestriction = new HashSet<Tbl_AccountingRestriction>();
            Tbl_AccountingRestrictionItems = new HashSet<Tbl_AccountingRestrictionItems>();
            Tbl_FinancialMenuAccountByAccountDuePaymentBlus = new HashSet<Tbl_FinancialMenuAccountByAccountDuePaymentBlus>();
            Tbl_FinancialMenuAccountsDuePaymentBlus = new HashSet<Tbl_FinancialMenuAccountsDuePaymentBlus>();
            Tbl_FinancialMenuCategoryDuePaymentBlus = new HashSet<Tbl_FinancialMenuCategoryDuePaymentBlus>();
            TBL_FinancialMenuProcessing = new HashSet<TBL_FinancialMenuProcessing>();
            Tbl_FinanctialMenueLinkedFunction = new HashSet<Tbl_FinanctialMenueLinkedFunction>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int? ParentID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_AccountingRestriction> Tbl_AccountingRestriction { get; set; }

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
    }
}
