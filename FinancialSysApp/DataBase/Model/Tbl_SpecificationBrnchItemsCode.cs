namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_SpecificationBrnchItemsCode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_SpecificationBrnchItemsCode()
        {
            Tbl_SpecificationBranchItems = new HashSet<Tbl_SpecificationBranchItems>();
            Tbl_SpecificationBranchItemsSolidKind = new HashSet<Tbl_SpecificationBranchItemsSolidKind>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_SpecificationBranchItems> Tbl_SpecificationBranchItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_SpecificationBranchItemsSolidKind> Tbl_SpecificationBranchItemsSolidKind { get; set; }
    }
}
