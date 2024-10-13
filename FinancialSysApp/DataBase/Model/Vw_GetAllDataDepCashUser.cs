namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vw_GetAllDataDepCashUser
    {
        [StringLength(100)]
        public string BrancheName { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(512)]
        public string EmployeeName { get; set; }

        public int? User_ID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        public int? BranchID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DepositDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BankDueDate { get; set; }

        public int? DepositBankID { get; set; }

        public int? AccBankID { get; set; }

        public int? RepresentiveID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AmountCash { get; set; }

        public int? FYear { get; set; }

        [StringLength(150)]
        public string DepositCashNo { get; set; }
    }
}
