namespace FinancialSysApp.DataBase.ModelEvents
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_DocumentBenefcairy_audit
    {
        [Key]
        public int ID_Change { get; set; }

        public int? DocBenfID { get; set; }

        public int? Document_ID { get; set; }

        public int? Beneficiary_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ChecqeValue { get; set; }

        public DateTime? Updated_at { get; set; }

        [StringLength(5)]
        public string Oberation { get; set; }
    }
}
