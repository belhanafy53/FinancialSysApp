namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_LetterWExpandDates
    {
        public int ID { get; set; }

        public int LetterWarrantyID { get; set; }

        [Column(TypeName = "date")]
        public DateTime LetterWExpandDate { get; set; }
    }
}
