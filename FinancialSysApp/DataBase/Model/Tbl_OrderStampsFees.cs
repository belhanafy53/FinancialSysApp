namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_OrderStampsFees
    {
        public int ID { get; set; }

        public long OrderID { get; set; }

        public int StampFeeID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Value1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Value2 { get; set; }

        public virtual Tbl_Order Tbl_Order { get; set; }

        public virtual Tbl_StampsFees Tbl_StampsFees { get; set; }
    }
}
