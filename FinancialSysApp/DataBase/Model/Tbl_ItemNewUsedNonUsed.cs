namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_ItemNewUsedNonUsed
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
