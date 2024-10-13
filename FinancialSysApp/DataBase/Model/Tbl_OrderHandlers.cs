namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_OrderHandlers
    {
        public int ID { get; set; }

        public long Order_ID { get; set; }

        public int Handler_ID { get; set; }

        public virtual Tbl_Handler Tbl_Handler { get; set; }

        public virtual Tbl_Order Tbl_Order { get; set; }
    }
}
