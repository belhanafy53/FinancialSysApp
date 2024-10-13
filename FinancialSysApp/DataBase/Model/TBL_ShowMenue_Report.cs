namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_ShowMenue_Report
    {
        public int ID { get; set; }

        public int? RestrictionKind_ID { get; set; }

        public int? FinancialMenuSetting_ID { get; set; }

        public int? FinancialMenuNameID { get; set; }

        [StringLength(250)]
        public string MenuName { get; set; }

        public decimal? TotalDue_Blus { get; set; }

        public decimal? TotalDue_Min { get; set; }

        public decimal? TotalCash_Blus { get; set; }

        public decimal? TotalCash_Min { get; set; }

        [StringLength(10)]
        public string SortingItems { get; set; }

        public int? Parent_ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public int? sortRestriction { get; set; }

        public int? RestrictionItemsCategory_ID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        public decimal? TotalDue_Blus3 { get; set; }

        public decimal? TotalDue_Min3 { get; set; }

        public decimal? TotalDue_Blus4 { get; set; }

        public decimal? TotalDue_Min4 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Restriction_Date { get; set; }

        [StringLength(50)]
        public string FYear { get; set; }

        public virtual Tbl_FinancialMenuName Tbl_FinancialMenuName { get; set; }

        public virtual Tbl_FinancialMenuSetting Tbl_FinancialMenuSetting { get; set; }
    }
}
