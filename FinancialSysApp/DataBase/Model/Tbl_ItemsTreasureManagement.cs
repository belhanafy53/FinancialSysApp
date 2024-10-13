namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_ItemsTreasureManagement
    {
        public int ID { get; set; }

        public int? ItemsTreasureID { get; set; }

        public int? ManagementID { get; set; }

        public virtual Tbl_TreasuryItems Tbl_TreasuryItems { get; set; }

        public virtual Tbl_Management Tbl_Management { get; set; }
    }
}
