namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_letter
    {
        [Key]
        [Column("رقم خطاب الضمان")]
        [StringLength(50)]
        public string رقم_خطاب_الضمان { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string البنك { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? القيمة { get; set; }

        [StringLength(150)]
        public string المورد { get; set; }

        public int? LetterProcessID { get; set; }
    }
}
