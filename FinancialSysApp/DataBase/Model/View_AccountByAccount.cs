namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_AccountByAccount
    {
        [Column("اسم الحساب")]
        public string اسم_الحساب { get; set; }

        [Column("رقم الحساب")]
        [StringLength(100)]
        public string رقم_الحساب { get; set; }

        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal مدين { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal دائن { get; set; }

        [Key]
        [Column("اسم الحساب المقابل", Order = 2)]
        public string اسم_الحساب_المقابل { get; set; }

        [Key]
        [Column("رقم الحساب المقابل", Order = 3)]
        [StringLength(100)]
        public string رقم_الحساب_المقابل { get; set; }

        [Column("مدين للحساب المقابل", TypeName = "numeric")]
        public decimal? مدين_للحساب_المقابل { get; set; }

        [Column("دائن للحساب المقابل", TypeName = "numeric")]
        public decimal? دائن_للحساب_المقابل { get; set; }
    }
}
