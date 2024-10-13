namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_OrderPaymentMethod
    {
        public int ID { get; set; }

        public int PaymentMethodID { get; set; }

        public long OrderID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PaymentMethodPercent { get; set; }

        public virtual Tbl_Order Tbl_Order { get; set; }

        public virtual Tbl_PaymentMethod Tbl_PaymentMethod { get; set; }
    }
}
