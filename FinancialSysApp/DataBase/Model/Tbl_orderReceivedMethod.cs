namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_orderReceivedMethod
    {
        public int ID { get; set; }

        public int? RecievedMethodID { get; set; }

        public long? OrderID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReceivedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReceivedActual_Date { get; set; }

        public virtual Tbl_Order Tbl_Order { get; set; }

        public virtual Tbl_RecievedMethod Tbl_RecievedMethod { get; set; }
    }
}
