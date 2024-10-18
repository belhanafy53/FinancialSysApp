namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_SpecificationPrice
    {
        public int ID { get; set; }

        public int? TendersAuctionsID { get; set; }

        public int? CableNumber { get; set; }

        public int? SolidKindID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Peice { get; set; }

        public virtual Tbl_SoilKind Tbl_SoilKind { get; set; }

        public virtual Tbl_TendersAuctions Tbl_TendersAuctions { get; set; }
    }
}
