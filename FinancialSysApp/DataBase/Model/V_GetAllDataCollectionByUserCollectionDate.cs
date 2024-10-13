namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class V_GetAllDataCollectionByUserCollectionDate
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        public int? BranchID { get; set; }

        public bool? IsDepositNo { get; set; }

        [StringLength(100)]
        public string BrancheName { get; set; }

        [StringLength(100)]
        public string TradeCollectionNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CollectionDate { get; set; }

        public int? BankDepositeID { get; set; }

        public int? BankAccounNoID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? RepresentiveID { get; set; }

        [StringLength(100)]
        public string ReceiptNo { get; set; }

        public long? Parent_ID { get; set; }

        public int? ChequeReceivedKindID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(512)]
        public string EmployeeName { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int User_ID { get; set; }

        [StringLength(100)]
        public string CollectionNo { get; set; }
    }
}
