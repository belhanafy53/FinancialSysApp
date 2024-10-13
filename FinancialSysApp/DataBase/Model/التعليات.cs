namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class التعليات
    {
        [Key]
        [Column("رقم الحساب", Order = 0)]
        [StringLength(100)]
        public string رقم_الحساب { get; set; }

        [Key]
        [Column("تاريخ المستند", Order = 1, TypeName = "date")]
        public DateTime تاريخ_المستند { get; set; }

        [Key]
        [Column("اسم الحساب", Order = 2)]
        public string اسم_الحساب { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal Restriction_NO { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "numeric")]
        public decimal مدين { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "numeric")]
        public decimal دائن { get; set; }

        [StringLength(10)]
        public string FYear { get; set; }
    }
}
