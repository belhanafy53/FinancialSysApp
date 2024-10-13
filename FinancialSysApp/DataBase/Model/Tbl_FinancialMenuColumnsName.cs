namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_FinancialMenuColumnsName
    {
        public int ID { get; set; }

        public int? MenuNameID { get; set; }

        [StringLength(100)]
        public string MenuColumnName { get; set; }

        public int? MenuColumnNumber { get; set; }

        [StringLength(120)]
        public string MenuTotalTitle { get; set; }
    }
}
