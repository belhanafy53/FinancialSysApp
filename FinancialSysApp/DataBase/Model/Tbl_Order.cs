namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Order()
        {
            TBL_Document = new HashSet<TBL_Document>();
            Tbl_Document_Orders = new HashSet<Tbl_Document_Orders>();
            Tbl_OrderAssays = new HashSet<Tbl_OrderAssays>();
            Tbl_OrderAudit = new HashSet<Tbl_OrderAudit>();
            Tbl_OrderHandlers = new HashSet<Tbl_OrderHandlers>();
            Tbl_OrderItems = new HashSet<Tbl_OrderItems>();
            Tbl_OrderManagementItems = new HashSet<Tbl_OrderManagementItems>();
            Tbl_OrderPaymentMethod = new HashSet<Tbl_OrderPaymentMethod>();
            Tbl_OrderProjects = new HashSet<Tbl_OrderProjects>();
            Tbl_orderReceivedMethod = new HashSet<Tbl_orderReceivedMethod>();
            Tbl_OrderStampsFees = new HashSet<Tbl_OrderStampsFees>();
            Tbl_OrderStores = new HashSet<Tbl_OrderStores>();
            Tbl_OrderTendersAuctions = new HashSet<Tbl_OrderTendersAuctions>();
            Tbl_Receiveing_Permeation = new HashSet<Tbl_Receiveing_Permeation>();
        }

        public long ID { get; set; }

        public int OrderKind_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Order_NO { get; set; }

        [Column(TypeName = "date")]
        public DateTime Order_Date { get; set; }

        public int? PurchaseMethodsID { get; set; }

        public short? ExtraOrder { get; set; }

        public long? ExtraOrderID { get; set; }

        public int? PaperNumber { get; set; }

        public int? TendersAuctionsID { get; set; }

        public int? Supp_ID { get; set; }

        public int? DecisionsResponspilitiesID { get; set; }

        public long? OrderID { get; set; }

        public int? OrderPurposeID { get; set; }

        public int? DecisionsResponspilitiesNID { get; set; }

        [StringLength(500)]
        public string ProcessName { get; set; }

        public int? OrderDircEsdarID { get; set; }

        public int? Cust_ID { get; set; }

        public short? ImplementationPeriod { get; set; }

        [StringLength(50)]
        public string ImplementationPeriodFrom { get; set; }

        [StringLength(50)]
        public string ImplementationPeriodTo { get; set; }

        public virtual Tbl_DecisionsResponspilities Tbl_DecisionsResponspilities { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_Document> TBL_Document { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Document_Orders> Tbl_Document_Orders { get; set; }

        public virtual Tbl_OrderKind Tbl_OrderKind { get; set; }

        public virtual Tbl_PurchaseMethods Tbl_PurchaseMethods { get; set; }

        public virtual Tbl_Supplier Tbl_Supplier { get; set; }

        public virtual Tbl_TendersAuctions Tbl_TendersAuctions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_OrderAssays> Tbl_OrderAssays { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_OrderAudit> Tbl_OrderAudit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_OrderHandlers> Tbl_OrderHandlers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_OrderItems> Tbl_OrderItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_OrderManagementItems> Tbl_OrderManagementItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_OrderPaymentMethod> Tbl_OrderPaymentMethod { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_OrderProjects> Tbl_OrderProjects { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_orderReceivedMethod> Tbl_orderReceivedMethod { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_OrderStampsFees> Tbl_OrderStampsFees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_OrderStores> Tbl_OrderStores { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_OrderTendersAuctions> Tbl_OrderTendersAuctions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Receiveing_Permeation> Tbl_Receiveing_Permeation { get; set; }
    }
}
