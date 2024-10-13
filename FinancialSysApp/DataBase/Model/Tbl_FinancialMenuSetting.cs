namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_FinancialMenuSetting
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_FinancialMenuSetting()
        {
            Tbl_FinancialMenuAccountByAccountDuePaymentBlus = new HashSet<Tbl_FinancialMenuAccountByAccountDuePaymentBlus>();
            Tbl_FinancialMenuAccountsDuePaymentBlus = new HashSet<Tbl_FinancialMenuAccountsDuePaymentBlus>();
            Tbl_FinancialMenuCategoryDuePaymentBlus = new HashSet<Tbl_FinancialMenuCategoryDuePaymentBlus>();
            TBL_FinancialMenuProcessing = new HashSet<TBL_FinancialMenuProcessing>();
            Tbl_FinancialMenuValue = new HashSet<Tbl_FinancialMenuValue>();
            Tbl_FinanctialMenueLinkedFunction = new HashSet<Tbl_FinanctialMenueLinkedFunction>();
            TBL_ShowMenue_Report = new HashSet<TBL_ShowMenue_Report>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public int? Parent_ID { get; set; }

        public int? FinancialMenuNameID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fdate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TDate { get; set; }

        public string FermulaMenuSide1 { get; set; }

        public int? SortingItems { get; set; }

        public string FermulaMenuSide2 { get; set; }

        public string FermulaMenuIDSide1 { get; set; }

        public string FermulaMenuIDSide2 { get; set; }

        public int? sortRestriction { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_FinancialMenuAccountByAccountDuePaymentBlus> Tbl_FinancialMenuAccountByAccountDuePaymentBlus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_FinancialMenuAccountsDuePaymentBlus> Tbl_FinancialMenuAccountsDuePaymentBlus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_FinancialMenuCategoryDuePaymentBlus> Tbl_FinancialMenuCategoryDuePaymentBlus { get; set; }

        public virtual Tbl_FinancialMenuName Tbl_FinancialMenuName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_FinancialMenuProcessing> TBL_FinancialMenuProcessing { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_FinancialMenuValue> Tbl_FinancialMenuValue { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_FinanctialMenueLinkedFunction> Tbl_FinanctialMenueLinkedFunction { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ShowMenue_Report> TBL_ShowMenue_Report { get; set; }
    }
}
