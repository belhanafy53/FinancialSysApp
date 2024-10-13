namespace FinancialSysApp.DataBase.ModelEvents
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_DocumentHirarchy
    {
        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public int? Parent_ID { get; set; }

        [StringLength(350)]
        public string Note { get; set; }

        public int? DocumentProcessID { get; set; }
    }
}
