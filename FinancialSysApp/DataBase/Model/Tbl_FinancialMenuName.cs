namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_FinancialMenuName
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_FinancialMenuName()
        {
            Tbl_FinancialMenuAccountByAccountDuePaymentBlus = new HashSet<Tbl_FinancialMenuAccountByAccountDuePaymentBlus>();
            Tbl_FinancialMenuAccountsDuePaymentBlus = new HashSet<Tbl_FinancialMenuAccountsDuePaymentBlus>();
            Tbl_FinancialMenuCategoryDuePaymentBlus = new HashSet<Tbl_FinancialMenuCategoryDuePaymentBlus>();
            TBL_FinancialMenuProcessing = new HashSet<TBL_FinancialMenuProcessing>();
            Tbl_FinancialMenuSetting = new HashSet<Tbl_FinancialMenuSetting>();
            Tbl_FinanctialMenueLinkedFunction = new HashSet<Tbl_FinanctialMenueLinkedFunction>();
            TBL_ShowMenue_Report = new HashSet<TBL_ShowMenue_Report>();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        [StringLength(50)]
        public string Side1 { get; set; }

        [StringLength(50)]
        public string Side2 { get; set; }

        [StringLength(50)]
        public string Side3 { get; set; }

        [StringLength(50)]
        public string Side4 { get; set; }

        public int? SideCount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_FinancialMenuAccountByAccountDuePaymentBlus> Tbl_FinancialMenuAccountByAccountDuePaymentBlus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_FinancialMenuAccountsDuePaymentBlus> Tbl_FinancialMenuAccountsDuePaymentBlus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_FinancialMenuCategoryDuePaymentBlus> Tbl_FinancialMenuCategoryDuePaymentBlus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_FinancialMenuProcessing> TBL_FinancialMenuProcessing { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_FinancialMenuSetting> Tbl_FinancialMenuSetting { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_FinanctialMenueLinkedFunction> Tbl_FinanctialMenueLinkedFunction { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ShowMenue_Report> TBL_ShowMenue_Report { get; set; }
    }
}
