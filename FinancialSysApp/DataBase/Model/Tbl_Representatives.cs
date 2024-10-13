namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Representatives
    {
        public int ID { get; set; }

        [StringLength(350)]
        public string Name { get; set; }

        public int? Emp_ID { get; set; }

        public int? RepresentativeKInd { get; set; }

        public int? BranchID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fromDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ToDate { get; set; }

        public short? RepStatus { get; set; }

        public virtual Tbl_RepresentativeKind Tbl_RepresentativeKind { get; set; }
    }
}
