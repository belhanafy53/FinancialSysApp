namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Fiscalyear
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Fiscalyear()
        {
            Tbl_TendersAuctions = new HashSet<Tbl_TendersAuctions>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateFrom { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateTo { get; set; }

        public bool? Open_Close { get; set; }

        [StringLength(10)]
        public string DocFrom { get; set; }

        [StringLength(10)]
        public string DocTo { get; set; }

        public bool? CurrentYear { get; set; }

        [StringLength(10)]
        public string FinancialYear { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_TendersAuctions> Tbl_TendersAuctions { get; set; }
    }
}
