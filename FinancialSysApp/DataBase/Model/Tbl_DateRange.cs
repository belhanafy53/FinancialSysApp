namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_DateRange
    {
        [Column(TypeName = "date")]
        public DateTime? DateF { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateT { get; set; }

        public int ID { get; set; }
    }
}
