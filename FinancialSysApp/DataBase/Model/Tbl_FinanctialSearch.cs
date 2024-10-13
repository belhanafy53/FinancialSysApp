namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_FinanctialSearch
    {
        public int? Restriction_NO { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Restriction_Date { get; set; }

        [StringLength(120)]
        public string NameOfDay { get; set; }

        [StringLength(120)]
        public string Account_NO { get; set; }

        [StringLength(120)]
        public string AccountName { get; set; }

        public decimal? Debit_Value { get; set; }

        public decimal? Credit_Value { get; set; }

        [StringLength(120)]
        public string Document_NO { get; set; }

        [StringLength(120)]
        public string NameOfDescription { get; set; }

        [StringLength(120)]
        public string NameOfBenificary { get; set; }

        [StringLength(120)]
        public string NameOfKindBenificary { get; set; }

        [StringLength(120)]
        public string NameOfEx { get; set; }

        [StringLength(120)]
        public string NameOfOrder { get; set; }

        [StringLength(120)]
        public string Order_NO { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Order_Date { get; set; }

        [StringLength(120)]
        public string NameOfHandelr { get; set; }

        [StringLength(120)]
        public string NameOfManagament { get; set; }

        [StringLength(120)]
        public string NameOfRespon { get; set; }

        [StringLength(120)]
        public string NameOfCategory { get; set; }

        public int ID { get; set; }

        [StringLength(50)]
        public string UsrName { get; set; }

        public int? Fyear { get; set; }
    }
}
