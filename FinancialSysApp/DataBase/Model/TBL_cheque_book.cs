namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_cheque_book
    {
        public int ID { get; set; }

        public int? Bank_ID { get; set; }

        [StringLength(50)]
        public string cheque_Num { get; set; }

        [StringLength(50)]
        public string BookNum { get; set; }

        public bool? cheque_Locked { get; set; }

        public int? BankAccountID { get; set; }
    }
}
