namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Detail")]
    public partial class Detail
    {
        [StringLength(3)]
        public string JRN_CD { get; set; }

        public int? TR_NO { get; set; }

        public short? LN_NO { get; set; }

        [StringLength(15)]
        public string ACC_NO { get; set; }

        [StringLength(40)]
        public string TR_DS { get; set; }

        public double? DB_VL { get; set; }

        public double? CR_VL { get; set; }

        public DateTime? TR_DT { get; set; }

        [StringLength(30)]
        public string ACC_NM_Ar { get; set; }

        public short? ACC_TY { get; set; }

        [StringLength(15)]
        public string MANACC { get; set; }

        public int ID { get; set; }
    }
}
