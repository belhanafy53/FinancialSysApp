namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_FinancialMenuAccountsDuePaymentNegativ
    {
        public int ID { get; set; }

        public int? RestrictionKind_ID { get; set; }

        public int? Account_Guid_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateFrom { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateTo { get; set; }

        public int? FinancialMenuSetting_ID { get; set; }

        public int? DuePaymentDebitValue { get; set; }

        public int? DuePaymentCridetValue { get; set; }

        public int? FinancialMenuNameID { get; set; }
    }
}
