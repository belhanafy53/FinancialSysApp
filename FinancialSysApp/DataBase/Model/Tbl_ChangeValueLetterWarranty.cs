namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_ChangeValueLetterWarranty
    {
        public int ID { get; set; }

        public int LetterWarrantyID { get; set; }

        public int ChangeValueKind { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ChangeValue { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ChangeDate { get; set; }

        public virtual Tbl_LetterWarranty Tbl_LetterWarranty { get; set; }
    }
}
