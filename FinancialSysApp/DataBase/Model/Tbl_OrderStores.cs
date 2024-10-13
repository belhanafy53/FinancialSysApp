namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_OrderStores
    {
        public int ID { get; set; }

        public int StoreID { get; set; }

        public long OrderID { get; set; }

        public virtual Tbl_Order Tbl_Order { get; set; }

        public virtual Tbl_Stores Tbl_Stores { get; set; }
    }
}
