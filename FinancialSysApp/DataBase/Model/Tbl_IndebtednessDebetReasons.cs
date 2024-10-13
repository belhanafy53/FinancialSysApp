namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_IndebtednessDebetReasons
    {
        public int ID { get; set; }

        [Required]
        [StringLength(350)]
        public string Name { get; set; }

        public int? Reason_KindID { get; set; }

        public virtual Tbl_ReasonKind Tbl_ReasonKind { get; set; }
    }
}
