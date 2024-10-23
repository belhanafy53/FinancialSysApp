namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_SpecificationBranchItemsSolidKind
    {
        public int ID { get; set; }

        public int? SpecificationBranchItems { get; set; }

        public int? SpecificationBrnchitemsCode { get; set; }

        public virtual Tbl_SpecificationBranchItems Tbl_SpecificationBranchItems { get; set; }

        public virtual Tbl_SpecificationBrnchItemsCode Tbl_SpecificationBrnchItemsCode { get; set; }
    }
}
