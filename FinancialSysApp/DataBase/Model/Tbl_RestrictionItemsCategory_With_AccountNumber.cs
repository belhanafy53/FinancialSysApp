namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_RestrictionItemsCategory_With_AccountNumber
    {
        public int ID { get; set; }

        public int? AccountNo_ID { get; set; }

        public int? RestrictionItemsCategoryID { get; set; }

        public int? Descrption { get; set; }

        public virtual Tbl_RestrictionItemsCategory Tbl_RestrictionItemsCategory { get; set; }
    }
}
