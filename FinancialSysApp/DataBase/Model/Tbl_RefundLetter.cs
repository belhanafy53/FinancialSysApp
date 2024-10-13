namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_RefundLetter
    {
        public int ID { get; set; }

        public int? EmployeeID { get; set; }

        public int RecievedMethodeLetterID { get; set; }

        [Column(TypeName = "date")]
        public DateTime RecievedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime RefundLetterDate { get; set; }

        public int LetterWarrantyID { get; set; }

        public virtual Tbl_Employee Tbl_Employee { get; set; }

        public virtual Tbl_LetterWarranty Tbl_LetterWarranty { get; set; }
    }
}
