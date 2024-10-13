namespace FinancialSysApp.DataBase.ModelEvents
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_Document_Audit
    {
        [Key]
        public int ID_Change { get; set; }

        public int? ID_Document { get; set; }

        public int? DocumentCategory_ID { get; set; }

        public int? Beneficiary_ID { get; set; }

        public int? ExchangeCenter_ID { get; set; }

        public long? Order_ID { get; set; }

        public int? Handler_ID { get; set; }

        [StringLength(30)]
        public string Document_NO { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Document_Date { get; set; }

        [StringLength(30)]
        public string Audit_NO { get; set; }

        public int? Management_ID { get; set; }

        public int? responspilityID { get; set; }

        public DateTime? Updated_at { get; set; }

        [StringLength(5)]
        public string Oberation { get; set; }
    }
}
