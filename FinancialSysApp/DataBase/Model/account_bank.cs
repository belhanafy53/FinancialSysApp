namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("account-bank")]
    public partial class account_bank
    {
        [Column(TypeName = "date")]
        public DateTime? MoveDat { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TransferValue { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Column("branch calissfy")]
        [StringLength(150)]
        public string branch_calissfy { get; set; }

        [StringLength(50)]
        public string DebitCredit { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Expr1 { get; set; }

        [Column("main calissfy")]
        [StringLength(150)]
        public string main_calissfy { get; set; }

        public int? FisicalYeariD { get; set; }

        [StringLength(50)]
        public string bank { get; set; }

        [Key]
        [Column("acc pupose", Order = 2)]
        [StringLength(50)]
        public string acc_pupose { get; set; }
    }
}
