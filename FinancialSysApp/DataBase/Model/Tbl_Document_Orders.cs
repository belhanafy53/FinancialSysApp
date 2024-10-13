namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Document_Orders
    {
        public int ID { get; set; }

        public int Document_ID { get; set; }

        public long Order_ID { get; set; }

        public virtual TBL_Document TBL_Document { get; set; }

        public virtual Tbl_Order Tbl_Order { get; set; }
    }
}
