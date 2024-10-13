namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Receiveing_Permeation
    {
        public int ID { get; set; }

        [StringLength(10)]
        public string ReceiveingNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReceiveingDate { get; set; }

        public int? ItemID { get; set; }

        public int? ItemQuantity { get; set; }

        public decimal? ItemPrice { get; set; }

        public int? StorID { get; set; }

        public long? OrderID { get; set; }

        public virtual Tbl_Items Tbl_Items { get; set; }

        public virtual Tbl_Order Tbl_Order { get; set; }

        public virtual Tbl_Stores Tbl_Stores { get; set; }
    }
}
