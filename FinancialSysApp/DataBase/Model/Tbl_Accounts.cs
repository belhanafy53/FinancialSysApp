namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Accounts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short AccID { get; set; }

        public long AccCode { get; set; }

        [Required]
        [StringLength(80)]
        public string AccName { get; set; }

        public byte? AccType { get; set; }

        public decimal? AccParent { get; set; }

        public byte? AccDmType { get; set; }

        public byte? AccFinal { get; set; }

        [StringLength(15)]
        public string AccPhone { get; set; }

        [StringLength(15)]
        public string AccPhone2 { get; set; }

        [StringLength(80)]
        public string AccMail { get; set; }

        public string AccAddress { get; set; }

        public string AccNote { get; set; }

        public int? AccMaxLimt { get; set; }

        public short? AccMaxDuration { get; set; }

        public byte? AccBranch { get; set; }

        public byte? AddUser { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AddDate { get; set; }

        public byte? EditUser { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EditDate { get; set; }

        public byte? NumOFEdit { get; set; }

        public bool? AccStopped { get; set; }
    }
}
