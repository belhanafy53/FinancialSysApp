namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Frook
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string اليومية { get; set; }

        [Key]
        [Column("رقم المستند", Order = 1, TypeName = "numeric")]
        public decimal رقم_المستند { get; set; }

        [Key]
        [Column("تاريخ المستند", Order = 2, TypeName = "date")]
        public DateTime تاريخ_المستند { get; set; }

        [Column("رقم الحساب")]
        [StringLength(100)]
        public string رقم_الحساب { get; set; }

        [Key]
        [Column("اسم الحساب", Order = 3)]
        public string اسم_الحساب { get; set; }

        [Column("مدين أدفاك")]
        public double? مدين_أدفاك { get; set; }

        [Column("دائن أدفاك")]
        public double? دائن_أدفاك { get; set; }

        [Column("مدين المنظومة", TypeName = "numeric")]
        public decimal? مدين_المنظومة { get; set; }

        [Column("دائن المنظومة", TypeName = "numeric")]
        public decimal? دائن_المنظومة { get; set; }

        public double? DF { get; set; }

        public double? CF { get; set; }
    }
}
