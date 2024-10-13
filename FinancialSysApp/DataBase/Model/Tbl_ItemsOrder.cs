namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_ItemsOrder
    {
        public int ID { get; set; }

        public long OrderID { get; set; }

        public int ItemsID { get; set; }

        public bool? SubmitVat { get; set; }

        public int? ValuAddTaxID { get; set; }

        public int? UnitID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PriceItem { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? QuantityItem { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Value { get; set; }

        public short Sort_Row { get; set; }

        public virtual Tbl_Items Tbl_Items { get; set; }

        public virtual Tbl_Order Tbl_Order { get; set; }

        public virtual Tbl_Unites Tbl_Unites { get; set; }

        public virtual Tbl_ValueAddedTax Tbl_ValueAddedTax { get; set; }
    }
}
