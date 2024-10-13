namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mohsen1
    {
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DepositDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BankDueDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AmountCash { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? DepositBankID { get; set; }
    }
}
