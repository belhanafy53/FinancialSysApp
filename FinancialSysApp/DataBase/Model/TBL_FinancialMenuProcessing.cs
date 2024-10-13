namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_FinancialMenuProcessing
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

        public int? CashPaymentDebitValue { get; set; }

        public int? CashPaymentCridedValue { get; set; }

        public int? FinancialMenuNameID { get; set; }

        public bool? Debit { get; set; }

        public bool? Credit { get; set; }

        public virtual Tbl_Accounting_Guid Tbl_Accounting_Guid { get; set; }

        public virtual Tbl_AccountingRestrictions_Kind Tbl_AccountingRestrictions_Kind { get; set; }

        public virtual Tbl_FinancialMenuName Tbl_FinancialMenuName { get; set; }

        public virtual Tbl_FinancialMenuSetting Tbl_FinancialMenuSetting { get; set; }
    }
}
