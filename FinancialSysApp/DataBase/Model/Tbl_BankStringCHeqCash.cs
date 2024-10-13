namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_BankStringCHeqCash
    {
        public int ID { get; set; }

        public int BankID { get; set; }

        [StringLength(50)]
        public string CheqString { get; set; }

        [StringLength(50)]
        public string CheqString1 { get; set; }

        public int? MoveType { get; set; }

        public int? MoveType1 { get; set; }

        [StringLength(50)]
        public string DebitCredit { get; set; }

        public virtual Tbl_Banks Tbl_Banks { get; set; }
    }
}
