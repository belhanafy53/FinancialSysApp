namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_IndebtednessBeneficiary
    {
        public int ID { get; set; }

        public int Indebtedness_ID { get; set; }

        public int Beneficiary_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DebitValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CreditValue { get; set; }

        [StringLength(300)]
        public string IndebtednessReason { get; set; }

        public virtual Tbl_Beneficiary Tbl_Beneficiary { get; set; }

        public virtual Tbl_Indebtedness Tbl_Indebtedness { get; set; }
    }
}
