namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_FinancialMenuAccountByAccountDuePaymentBlus
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

        public int? DuePayment { get; set; }

        public int? CashPayment { get; set; }

        public int? DuePaymentDebitValue1 { get; set; }

        public int? DuePaymentCridetValue1 { get; set; }

        public int? CashPaymentDebitValue { get; set; }

        public int? CashPaymentCridetValue { get; set; }

        public int? CashPaymentDebitValue1 { get; set; }

        public int? CashPaymentCridetValue1 { get; set; }

        public int? SortingItems { get; set; }

        public int? RestrictionItemsCategory_ID { get; set; }

        public int? Transfare_FinancialMenuNameID { get; set; }

        public int? Transfare_FinancialMenuSetting_ID { get; set; }

        public virtual Tbl_Accounting_Guid Tbl_Accounting_Guid { get; set; }

        public virtual Tbl_AccountingRestrictions_Kind Tbl_AccountingRestrictions_Kind { get; set; }

        public virtual Tbl_FinancialMenuName Tbl_FinancialMenuName { get; set; }

        public virtual Tbl_FinancialMenuSetting Tbl_FinancialMenuSetting { get; set; }

        public virtual Tbl_RestrictionItemsCategory Tbl_RestrictionItemsCategory { get; set; }
    }
}
