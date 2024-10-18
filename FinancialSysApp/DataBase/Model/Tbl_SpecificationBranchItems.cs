namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_SpecificationBranchItems
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_SpecificationBranchItems()
        {
            Tbl_SpecificationBranchItemsSolidKind = new HashSet<Tbl_SpecificationBranchItemsSolidKind>();
        }

        public int ID { get; set; }

        public int? SpecificationItemsID { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        public int? TendersAuctionsID { get; set; }

        public int? CableNumber { get; set; }

        public virtual Tbl_SpecificationItems Tbl_SpecificationItems { get; set; }

        public virtual Tbl_TendersAuctions Tbl_TendersAuctions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_SpecificationBranchItemsSolidKind> Tbl_SpecificationBranchItemsSolidKind { get; set; }
    }
}
