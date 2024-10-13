namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Items
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Items()
        {
            Tbl_Items1 = new HashSet<Tbl_Items>();
            Tbl_Match_AccGuid_DocCategory = new HashSet<Tbl_Match_AccGuid_DocCategory>();
            Tbl_OrderItems = new HashSet<Tbl_OrderItems>();
            Tbl_OrderManagementItems = new HashSet<Tbl_OrderManagementItems>();
            Tbl_Receiveing_Permeation = new HashSet<Tbl_Receiveing_Permeation>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public int? Parent_ID { get; set; }

        public int? ItemCategoryID { get; set; }

        public int? SystemUnitesID { get; set; }

        public string Note { get; set; }

        [StringLength(250)]
        public string StoreCode { get; set; }

        public int? ItemNewUsedNonUsed { get; set; }

        public int? CableTube { get; set; }

        public bool? CableExption { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Items> Tbl_Items1 { get; set; }

        public virtual Tbl_Items Tbl_Items2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Match_AccGuid_DocCategory> Tbl_Match_AccGuid_DocCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_OrderItems> Tbl_OrderItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_OrderManagementItems> Tbl_OrderManagementItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Receiveing_Permeation> Tbl_Receiveing_Permeation { get; set; }
    }
}
