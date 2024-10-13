namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_AccountsBank
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string AccountBankNo { get; set; }

        public int? BankID { get; set; }

        public int? KindAccountBankID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FromDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ToDate { get; set; }

        public int? BankAccStatusID { get; set; }

        public int? AccPurposeID { get; set; }

        public int? Accounting_GuidID { get; set; }

        public virtual Tbl_AccoiuntBankKind Tbl_AccoiuntBankKind { get; set; }

        public virtual Tbl_Banks Tbl_Banks { get; set; }
    }
}
