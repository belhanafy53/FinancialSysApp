namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Supplier()
        {
            Tbl_Beneficiary = new HashSet<Tbl_Beneficiary>();
            Tbl_Order = new HashSet<Tbl_Order>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Tax_Card { get; set; }

        public string Tax_FileNo { get; set; }

        public int? TaxAuthority_ID { get; set; }

        public int? SuplierKind { get; set; }

        public bool? AddRecordingSupplier { get; set; }

        [StringLength(20)]
        public string Tax_FileNo1 { get; set; }

        [StringLength(20)]
        public string Tax_FileNo2 { get; set; }

        [StringLength(20)]
        public string Tax_FileNo3 { get; set; }

        [StringLength(150)]
        public string TaxName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FromDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ToDate { get; set; }

        public bool? SuplierStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Beneficiary> Tbl_Beneficiary { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Order> Tbl_Order { get; set; }

        public virtual Tbl_SupplierKind Tbl_SupplierKind { get; set; }

        public virtual Tbl_TaxAuthority Tbl_TaxAuthority { get; set; }
    }
}
