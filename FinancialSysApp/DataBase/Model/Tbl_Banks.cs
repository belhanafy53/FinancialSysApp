namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Banks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Banks()
        {
            Tbl_AccountsBank = new HashSet<Tbl_AccountsBank>();
            Tbl_BankMovement = new HashSet<Tbl_BankMovement>();
            Tbl_BankStringCHeqCash = new HashSet<Tbl_BankStringCHeqCash>();
            Tbl_DepositCash = new HashSet<Tbl_DepositCash>();
            Tbl_TransferPaymentBank = new HashSet<Tbl_TransferPaymentBank>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? Parent_ID { get; set; }

        [StringLength(100)]
        public string AccountBanking_NO { get; set; }

        [StringLength(100)]
        public string IBanBanking_NO { get; set; }

        public int? Accounting_GuidID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_AccountsBank> Tbl_AccountsBank { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_BankMovement> Tbl_BankMovement { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_BankStringCHeqCash> Tbl_BankStringCHeqCash { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_DepositCash> Tbl_DepositCash { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_TransferPaymentBank> Tbl_TransferPaymentBank { get; set; }
    }
}
