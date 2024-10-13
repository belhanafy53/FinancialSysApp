namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_DecisionsResponspilities
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_DecisionsResponspilities()
        {
            Tbl_Order = new HashSet<Tbl_Order>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string DecisionNO { get; set; }

        [Column(TypeName = "date")]
        public DateTime DecisionDate { get; set; }

        [StringLength(50)]
        public string ForYear { get; set; }

        public int? ResponspilityCentersID { get; set; }

        public virtual Tbl_ResponspilityCenters Tbl_ResponspilityCenters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Order> Tbl_Order { get; set; }
    }
}
