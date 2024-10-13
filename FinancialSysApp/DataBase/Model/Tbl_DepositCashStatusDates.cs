namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_DepositCashStatusDates
    {
        public long ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StatusDate { get; set; }

        public int? DepositCashStatusID { get; set; }

        public long? DepositCashID { get; set; }
    }
}
