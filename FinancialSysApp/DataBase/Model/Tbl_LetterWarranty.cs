namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_LetterWarranty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_LetterWarranty()
        {
            Tbl_ChangeValueLetterWarranty = new HashSet<Tbl_ChangeValueLetterWarranty>();
            Tbl_NotificationLetter = new HashSet<Tbl_NotificationLetter>();
            Tbl_RefundLetter = new HashSet<Tbl_RefundLetter>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string LetterWarrantyNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime LetterWarrantyDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LetterWarrantyExpireDate { get; set; }

        public int? FileNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Value { get; set; }

        public int? CurrencyID { get; set; }

        public int? SupID { get; set; }

        public string LetterWarrantyPurpose { get; set; }

        public int? ManagementID { get; set; }

        public int? LetterWarrantyKind { get; set; }

        public int? TendersAuctionsID { get; set; }

        public int? LetterProcessID { get; set; }

        public long? OrderID { get; set; }

        public int? AssayesID { get; set; }

        public int? BankID { get; set; }

        public int? ManagementExportLettrID { get; set; }

        public int? ProjectID { get; set; }

        [StringLength(50)]
        public string LetterWarrantyNoScnd { get; set; }

        [StringLength(150)]
        public string LetterWarrantyNoFull { get; set; }

        public int? FinancialMember { get; set; }

        [StringLength(50)]
        public string LetterWDateRecieved { get; set; }

        public bool? ConfLetterWarrantyExpireDate { get; set; }

        public bool? ConfValue { get; set; }

        public bool? ConfTender { get; set; }

        public int? BeneficiaryID { get; set; }

        public int? DecisionsResponspilitiesID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LetterWarrantyExpandDate { get; set; }

        public bool? ConfRecieveLetter { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_ChangeValueLetterWarranty> Tbl_ChangeValueLetterWarranty { get; set; }

        public virtual Tbl_LetterWarrantyKind Tbl_LetterWarrantyKind { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_NotificationLetter> Tbl_NotificationLetter { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_RefundLetter> Tbl_RefundLetter { get; set; }
    }
}
