namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_1
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string اليومية { get; set; }

        [Column("رقم مستند أدفاك")]
        public int? رقم_مستند_أدفاك { get; set; }

        [Column("تاريخ المستند أدفاك")]
        public DateTime? تاريخ_المستند_أدفاك { get; set; }

        [Column("رقم حساب أدفاك")]
        [StringLength(15)]
        public string رقم_حساب_أدفاك { get; set; }

        [Column("مدين أدفاك")]
        public double? مدين_أدفاك { get; set; }

        [Column("دائن أدفاك")]
        public double? دائن_أدفاك { get; set; }

        [Key]
        [Column("رقم مستند المنظومة", Order = 1, TypeName = "numeric")]
        public decimal رقم_مستند_المنظومة { get; set; }

        [Key]
        [Column("تاريخ المستند المنظومة", Order = 2, TypeName = "date")]
        public DateTime تاريخ_المستند_المنظومة { get; set; }

        [Key]
        [Column("رقم حساب المنظومة", Order = 3)]
        [StringLength(100)]
        public string رقم_حساب_المنظومة { get; set; }

        [Key]
        [Column("مدين المنظومة", Order = 4, TypeName = "numeric")]
        public decimal مدين_المنظومة { get; set; }

        [Key]
        [Column("دائن المنظومة", Order = 5, TypeName = "numeric")]
        public decimal دائن_المنظومة { get; set; }

        public int? AccountingRestrictionKind_ID { get; set; }

        [Column("فرق المدين")]
        public double? فرق_المدين { get; set; }

        [Column("فرق الدائن")]
        public double? فرق_الدائن { get; set; }

        [Column("فرق رقم الحساب")]
        public double? فرق_رقم_الحساب { get; set; }
    }
}
