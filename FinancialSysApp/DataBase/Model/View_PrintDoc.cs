namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_PrintDoc
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short م { get; set; }

        [Key]
        [Column("رقم الحساب", Order = 1)]
        [StringLength(100)]
        public string رقم_الحساب { get; set; }

        [Key]
        [Column("اسم الحساب", Order = 2)]
        public string اسم_الحساب { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal مدين { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "numeric")]
        public decimal دائن { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string اليومية { get; set; }

        public int? Accounting_Guid_ID { get; set; }

        [StringLength(150)]
        public string النشاط { get; set; }

        public int? ID { get; set; }

        [StringLength(50)]
        public string التصنيف { get; set; }

        public int? Expr1 { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public int? CostCenters_ID { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Expr2 { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Expr3 { get; set; }

        public int? AccountingRestrictionKind_ID { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(100)]
        public string Parent_ID { get; set; }
    }
}
