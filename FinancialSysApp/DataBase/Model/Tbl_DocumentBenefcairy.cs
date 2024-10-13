namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_DocumentBenefcairy
    {
        public int ID { get; set; }

        public int? Document_ID { get; set; }

        public int? Beneficiary_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ChecqeValue { get; set; }

        public virtual Tbl_Beneficiary Tbl_Beneficiary { get; set; }

        public virtual TBL_Document TBL_Document { get; set; }
    }
}
