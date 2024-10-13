namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_NormativeCosts
    {
        public int ID { get; set; }

        public int AccountGuid_ID { get; set; }

        public int? CostCenterActivities_ID { get; set; }

        [StringLength(10)]
        public string FlagCostsCenterActivities { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Value { get; set; }

        [Column(TypeName = "date")]
        public DateTime? From_Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? To_Date { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Percentage { get; set; }
    }
}
