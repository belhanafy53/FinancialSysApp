namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_BankTransferPayment
    {
        public long ID { get; set; }

        public int? BeneficiaryID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TransferDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TransferAmount { get; set; }

        public int? FromBankID { get; set; }

        public int? FromBankAccID { get; set; }

        public int? ToBankID { get; set; }

        public int? ToBankAccID { get; set; }

        public int? TransfereKindID { get; set; }

        [StringLength(150)]
        public string TransferNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BankAccDateAdd { get; set; }

        [StringLength(50)]
        public string PaperNo { get; set; }

        public virtual Tbl_Beneficiary Tbl_Beneficiary { get; set; }
    }
}
