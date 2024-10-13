namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_LetterWarrentyAudit
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int LetterWarrentyID { get; set; }

        public bool? LetterWBasicData { get; set; }

        public bool? LetterWExpandDate { get; set; }

        public bool? LetterWRefundLetter { get; set; }

        public bool? LetterChangeValueLetter { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReferenceDate { get; set; }
    }
}
