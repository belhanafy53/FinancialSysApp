namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Match_AccGuid_DocCategory
    {
        public int ID { get; set; }

        public int Accounting_GuidID { get; set; }

        public int ProcessingKindID { get; set; }

        public int ItemsID { get; set; }

        public int PaymentMethodID { get; set; }

        public string Note { get; set; }

        public virtual Tbl_Accounting_Guid Tbl_Accounting_Guid { get; set; }

        public virtual Tbl_Items Tbl_Items { get; set; }

        public virtual Tbl_PaymentMethod Tbl_PaymentMethod { get; set; }

        public virtual Tbl_Processing_Kind Tbl_Processing_Kind { get; set; }
    }
}
