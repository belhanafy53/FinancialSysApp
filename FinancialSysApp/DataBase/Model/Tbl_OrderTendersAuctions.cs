namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_OrderTendersAuctions
    {
        public int ID { get; set; }

        public long OrderID { get; set; }

        public int TendersAuctionsID { get; set; }

        public virtual Tbl_Order Tbl_Order { get; set; }
    }
}
