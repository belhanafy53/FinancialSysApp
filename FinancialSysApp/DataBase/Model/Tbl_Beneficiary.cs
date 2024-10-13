namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Beneficiary
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Beneficiary()
        {
            Tbl_BankTransferPayment = new HashSet<Tbl_BankTransferPayment>();
            TBL_Document = new HashSet<TBL_Document>();
            Tbl_DocumentBenefcairy = new HashSet<Tbl_DocumentBenefcairy>();
            Tbl_IndebtednessBeneficiary = new HashSet<Tbl_IndebtednessBeneficiary>();
            Tbl_TransferPaymentBank = new HashSet<Tbl_TransferPaymentBank>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public int? BeneficiaryKind_ID { get; set; }

        public int? ID_Emp { get; set; }

        public int? ID_Cust { get; set; }

        public int? ID_Supp { get; set; }

        public int? ID_Mng { get; set; }

        public int? ID_Bank { get; set; }

        public int? Parent_ID { get; set; }

        public int? Relative_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_BankTransferPayment> Tbl_BankTransferPayment { get; set; }

        public virtual Tbl_BeneficiaryKind Tbl_BeneficiaryKind { get; set; }

        public virtual Tbl_Customer Tbl_Customer { get; set; }

        public virtual Tbl_Employee Tbl_Employee { get; set; }

        public virtual Tbl_RelativeRlation Tbl_RelativeRlation { get; set; }

        public virtual Tbl_Supplier Tbl_Supplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_Document> TBL_Document { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_DocumentBenefcairy> Tbl_DocumentBenefcairy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_IndebtednessBeneficiary> Tbl_IndebtednessBeneficiary { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_TransferPaymentBank> Tbl_TransferPaymentBank { get; set; }
    }
}
