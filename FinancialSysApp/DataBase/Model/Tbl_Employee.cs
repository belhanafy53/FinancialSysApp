namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Employee()
        {
            Tbl_Beneficiary = new HashSet<Tbl_Beneficiary>();
            Tbl_Handler = new HashSet<Tbl_Handler>();
            Tbl_RefundLetter = new HashSet<Tbl_RefundLetter>();
            Tbl_User_SysUnites = new HashSet<Tbl_User_SysUnites>();
            Tbl_User = new HashSet<Tbl_User>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string NationalId { get; set; }

        public int Management_ID { get; set; }

        public int? GenderID { get; set; }

        [StringLength(150)]
        public string WorkerJob { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StatusDate { get; set; }

        [StringLength(150)]
        public string StatusDetail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Beneficiary> Tbl_Beneficiary { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Handler> Tbl_Handler { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_RefundLetter> Tbl_RefundLetter { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_User_SysUnites> Tbl_User_SysUnites { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_User> Tbl_User { get; set; }
    }
}
