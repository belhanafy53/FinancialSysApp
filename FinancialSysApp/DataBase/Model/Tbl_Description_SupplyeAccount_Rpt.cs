namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Description_SupplyeAccount_Rpt
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string AccNumber { get; set; }
    }
}
