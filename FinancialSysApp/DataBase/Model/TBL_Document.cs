namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_Document
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_Document()
        {
            Tbl_AccountingRestriction = new HashSet<Tbl_AccountingRestriction>();
            Tbl_Document_Orders = new HashSet<Tbl_Document_Orders>();
            Tbl_DocumentBenefcairy = new HashSet<Tbl_DocumentBenefcairy>();
        }

        public int ID { get; set; }

        public int? DocumentCategory_ID { get; set; }

        public int? Beneficiary_ID { get; set; }

        public int? ExchangeCenter_ID { get; set; }

        public long? Order_ID { get; set; }

        public int? Handler_ID { get; set; }

        [StringLength(30)]
        public string Document_NO { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Document_Date { get; set; }

        [StringLength(30)]
        public string Audit_NO { get; set; }

        public int? Management_ID { get; set; }

        public int? responspilityID { get; set; }

        public int? AccountingRestrictionKind_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Restriction_NO { get; set; }

        public int? Assays_ID { get; set; }

        public int? Projects_ID { get; set; }

        [StringLength(50)]
        public string Salary_NO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_AccountingRestriction> Tbl_AccountingRestriction { get; set; }

        public virtual Tbl_Beneficiary Tbl_Beneficiary { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Document_Orders> Tbl_Document_Orders { get; set; }

        public virtual Tbl_Handler Tbl_Handler { get; set; }

        public virtual Tbl_Management Tbl_Management { get; set; }

        public virtual Tbl_Order Tbl_Order { get; set; }

        public virtual Tbl_ResponspilityCenters Tbl_ResponspilityCenters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_DocumentBenefcairy> Tbl_DocumentBenefcairy { get; set; }
    }
}
