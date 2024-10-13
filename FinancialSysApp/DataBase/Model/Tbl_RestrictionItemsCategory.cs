namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_RestrictionItemsCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_RestrictionItemsCategory()
        {
            Tbl_AccountingRestrictionItems = new HashSet<Tbl_AccountingRestrictionItems>();
            Tbl_FinancialMenuAccountByAccountDuePaymentBlus = new HashSet<Tbl_FinancialMenuAccountByAccountDuePaymentBlus>();
            Tbl_FinancialMenuCategoryDuePaymentBlus = new HashSet<Tbl_FinancialMenuCategoryDuePaymentBlus>();
            Tbl_RestrictionItemsCategory_With_AccountNumber = new HashSet<Tbl_RestrictionItemsCategory_With_AccountNumber>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_AccountingRestrictionItems> Tbl_AccountingRestrictionItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_FinancialMenuAccountByAccountDuePaymentBlus> Tbl_FinancialMenuAccountByAccountDuePaymentBlus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_FinancialMenuCategoryDuePaymentBlus> Tbl_FinancialMenuCategoryDuePaymentBlus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_RestrictionItemsCategory_With_AccountNumber> Tbl_RestrictionItemsCategory_With_AccountNumber { get; set; }
    }
}
