namespace FinancialSysApp.DataBase.ModelEvents
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_DocumentProcess
    {
        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }
    }
}
