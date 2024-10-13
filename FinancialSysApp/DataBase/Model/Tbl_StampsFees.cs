namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_StampsFees
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_StampsFees()
        {
            Tbl_OrderStampsFees = new HashSet<Tbl_OrderStampsFees>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Value1 { get; set; }

        public bool? Value_Percent1 { get; set; }

        public bool? PaperCount_AuditingNote1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueRelated1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Value2 { get; set; }

        public bool? Value_Percent2 { get; set; }

        public bool? PaperCount_AuditingNote2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueRelated2 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FromDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ToDate { get; set; }

        public bool? Active_NonActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_OrderStampsFees> Tbl_OrderStampsFees { get; set; }
    }
}
