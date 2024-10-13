namespace FinancialSysApp.DataBase.ModelEvents
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_ArchOrderAndLetterW
    {
        public int ID { get; set; }

        [Required]
        [StringLength(350)]
        public string PathFile { get; set; }

        public int? LetterWID { get; set; }

        public long? OrderID { get; set; }

        public int? DocumentHirarchyID { get; set; }

        public long? BankCheqID { get; set; }
    }
}
