namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_OrderItems
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_OrderItems()
        {
            Tbl_OrderManagementItems = new HashSet<Tbl_OrderManagementItems>();
        }

        public int ID { get; set; }

        public long OrderID { get; set; }

        public int ItemID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Quantity { get; set; }

        public int UnitID { get; set; }

        public bool VatTax { get; set; }

        public int? ValueAddedTaxId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Price { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ValueAfter { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ValueBefore { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? InstallationPrice { get; set; }

        public short? Sort_Row { get; set; }

        public bool? PriceIncludedNon { get; set; }

        public virtual Tbl_Items Tbl_Items { get; set; }

        public virtual Tbl_Order Tbl_Order { get; set; }

        public virtual Tbl_Unites Tbl_Unites { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_OrderManagementItems> Tbl_OrderManagementItems { get; set; }
    }
}
