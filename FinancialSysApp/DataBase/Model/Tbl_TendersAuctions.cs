namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_TendersAuctions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_TendersAuctions()
        {
            Tbl_Order = new HashSet<Tbl_Order>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenderNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime TenderDate { get; set; }

        public string Note { get; set; }

        public int? PurchaseMethodeID { get; set; }

        public int? FinancialYearId { get; set; }

        public int? ElectricalEffortID { get; set; }

        public virtual Tbl_Fiscalyear Tbl_Fiscalyear { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Order> Tbl_Order { get; set; }

        public virtual Tbl_PurchaseMethods Tbl_PurchaseMethods { get; set; }
    }
}
