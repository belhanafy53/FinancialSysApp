namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_GetRestrictionCategoryInMenue
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? RestrictionKind_ID { get; set; }

        public int? FinancialMenuSetting_ID { get; set; }

        public int? FinancialMenuNameID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(250)]
        public string Name { get; set; }

        public string MenuName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalDue_Blus { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalDue_Min { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalCash_Blus { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalCash_Min { get; set; }

        public int? SortingItems { get; set; }

        public int? Parent_ID { get; set; }

        public int? sortRestriction { get; set; }

        public int? RestrictionItemsCategory_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Expr1 { get; set; }

        public int? Account_Guid_ID { get; set; }
    }
}
