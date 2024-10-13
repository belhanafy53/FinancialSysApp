namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_Temp_MatchAccounts
    {
        public int ID { get; set; }

        [StringLength(15)]
        public string ACC_NO { get; set; }

        [StringLength(30)]
        public string ACC_NM_Ar { get; set; }
    }
}
