namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_Restrictions_checks
    {
        public int ID { get; set; }

        public int? AccountBankID { get; set; }

        public int? BankID { get; set; }

        public int? cheque_bookID { get; set; }

        public int? RestrictionItems_ID { get; set; }

        public int? Restriction_ID { get; set; }

        [StringLength(50)]
        public string Due_date { get; set; }

        public decimal? check_value { get; set; }

        public int? beneficiary_ID { get; set; }

        public int? Account_Guid_ID { get; set; }
    }
}
