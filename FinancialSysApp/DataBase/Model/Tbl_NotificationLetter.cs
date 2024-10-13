namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_NotificationLetter
    {
        public int ID { get; set; }

        public int LetterWarrantyID { get; set; }

        [Column(TypeName = "date")]
        public DateTime NotificationDate { get; set; }

        public int RefundLetterReasonsID { get; set; }

        public virtual Tbl_LetterWarranty Tbl_LetterWarranty { get; set; }

        public virtual Tbl_RefundLettersReasons Tbl_RefundLettersReasons { get; set; }
    }
}
