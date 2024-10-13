namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_OrderManagementItems
    {
        public long ID { get; set; }

        public int? OrderItemsID { get; set; }

        public int? ManagementID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Quantity { get; set; }

        public long? OrderId { get; set; }

        public int? ItemID { get; set; }

        public virtual Tbl_Items Tbl_Items { get; set; }

        public virtual Tbl_Order Tbl_Order { get; set; }

        public virtual Tbl_OrderItems Tbl_OrderItems { get; set; }
    }
}
