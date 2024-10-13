namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_OrderAudit
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public long OrderId { get; set; }

        public bool? OrderIBasicDataID { get; set; }

        public bool? OrderIItemDataID { get; set; }

        public bool? OrderITermsID { get; set; }

        public DateTime? ReferenceDate { get; set; }

        public virtual Tbl_Order Tbl_Order { get; set; }

        public virtual Tbl_User Tbl_User { get; set; }
    }
}
