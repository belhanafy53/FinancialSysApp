namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_TransferPaymentBank
    {
        public long ID { get; set; }

        public int KindTransfereID { get; set; }

        public int BenfeficiaryID { get; set; }

        [Required]
        [StringLength(100)]
        public string TransfereNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TransfereValue { get; set; }

        [Column(TypeName = "date")]
        public DateTime TransfereDate { get; set; }

        public int TransfereBankID { get; set; }

        public int TransfereBankAccID { get; set; }

        public virtual Tbl_Banks Tbl_Banks { get; set; }

        public virtual Tbl_Beneficiary Tbl_Beneficiary { get; set; }
    }
}
