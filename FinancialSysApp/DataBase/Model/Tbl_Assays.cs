namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Assays
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Assays()
        {
            Tbl_OrderAssays = new HashSet<Tbl_OrderAssays>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string AssaysNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime AssaysDate { get; set; }

        public int? ManagementID { get; set; }

        public int AssaysKindId { get; set; }

        public int? CustomerId { get; set; }

        public virtual Tbl_AssaysKind Tbl_AssaysKind { get; set; }

        public virtual Tbl_Customer Tbl_Customer { get; set; }

        public virtual Tbl_Management Tbl_Management { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_OrderAssays> Tbl_OrderAssays { get; set; }
    }
}
