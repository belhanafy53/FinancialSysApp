namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_OrderPreimations
    {
        public int ID { get; set; }

        public int? OrderID { get; set; }

        public int? OrderStoresID { get; set; }

        public int? OrderProjectsID { get; set; }

        public int? OrderAssaysID { get; set; }

        public int? OrderReceivedMethodID { get; set; }
    }
}
