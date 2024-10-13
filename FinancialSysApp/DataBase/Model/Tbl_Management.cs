namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Management
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Management()
        {
            Tbl_Assays = new HashSet<Tbl_Assays>();
            Tbl_DepositCash = new HashSet<Tbl_DepositCash>();
            TBL_Document = new HashSet<TBL_Document>();
            Tbl_ItemsTreasureManagement = new HashSet<Tbl_ItemsTreasureManagement>();
        }

        public int ID { get; set; }

        public int Management_ID { get; set; }

        [Required]
        public string Name { get; set; }

        public int? ExchangeCenter_ID { get; set; }

        public int? Parent_ID { get; set; }

        public int? ManagementCategory_ID { get; set; }

        [StringLength(100)]
        public string BrancheName { get; set; }

        public short? KindBranchDirect { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Assays> Tbl_Assays { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_DepositCash> Tbl_DepositCash { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_Document> TBL_Document { get; set; }

        public virtual Tbl_ExchangeCenter Tbl_ExchangeCenter { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_ItemsTreasureManagement> Tbl_ItemsTreasureManagement { get; set; }

        public virtual Tbl_ManagementCategory Tbl_ManagementCategory { get; set; }
    }
}
