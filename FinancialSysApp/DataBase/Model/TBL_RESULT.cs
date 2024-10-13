namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_RESULT
    {
        [StringLength(50)]
        public string ACC_NO { get; set; }

        public string ACC_NM_Ar { get; set; }

        public decimal? OPDB { get; set; }

        public decimal? OPCR { get; set; }

        public decimal? PRDB { get; set; }

        public decimal? PRCR { get; set; }

        public decimal? MDB { get; set; }

        public decimal? MCR { get; set; }

        public double? TOT { get; set; }

        public DateTime? DateF { get; set; }

        public DateTime? DateT { get; set; }

        [StringLength(10)]
        public string YMonth { get; set; }

        [StringLength(10)]
        public string YYear { get; set; }

        [StringLength(10)]
        public string YMonth1 { get; set; }

        [StringLength(10)]
        public string YYear1 { get; set; }

        public int ID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }
    }
}
