namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("View_get all treasury collection")]
    public partial class View_get_all_treasury_collection
    {
        [StringLength(100)]
        public string TradeCollectionNo { get; set; }

        [Column("bank depositr")]
        [StringLength(50)]
        public string bank_depositr { get; set; }

        [Column("bank drawn")]
        [StringLength(50)]
        public string bank_drawn { get; set; }

        [StringLength(100)]
        public string ChequeNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ChequeDueDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AmountCheque { get; set; }

        [StringLength(100)]
        public string BrancheName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ChequeStatusDate { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        public int? ChequeReceivedKindID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CollectionDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AddRecievedDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DepositDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AddDateBank { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AddDateAccBank { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BankDueDate { get; set; }

        public int? BranchID { get; set; }

        public int? BankDepositeID { get; set; }

        public int? management_Id { get; set; }

        public int? Parent_ID { get; set; }

        public long? Expr1 { get; set; }

        [StringLength(100)]
        public string Expr3 { get; set; }

        public int? FisicalYearID { get; set; }
    }
}
