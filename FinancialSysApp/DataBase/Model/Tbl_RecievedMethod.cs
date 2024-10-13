namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_RecievedMethod
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(50)]
        public string PeriodExtra { get; set; }

        public bool? Month { get; set; }

        public bool? Day { get; set; }

        public virtual Tbl_orderReceivedMethod Tbl_orderReceivedMethod { get; set; }
    }
}
