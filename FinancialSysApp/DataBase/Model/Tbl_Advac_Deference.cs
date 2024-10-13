namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Advac_Deference
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string NameofDay { get; set; }

        public int? JRN_CD { get; set; }

        [StringLength(50)]
        public string TR_NO { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TR_DT { get; set; }

        [StringLength(50)]
        public string ACC_NO { get; set; }

        public decimal? DB_VL { get; set; }

        public decimal? CR_VL { get; set; }

        [StringLength(50)]
        public string Restriction_NO { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Restriction_Date { get; set; }

        [StringLength(50)]
        public string Account_NO { get; set; }

        public decimal? Debit_Value { get; set; }

        public decimal? Credit_Value { get; set; }

        public decimal? DDebit_Value { get; set; }

        public decimal? DCredit_Value { get; set; }

        public decimal? ADef { get; set; }
    }
}
