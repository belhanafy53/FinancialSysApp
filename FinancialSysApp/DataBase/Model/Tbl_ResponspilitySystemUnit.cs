namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_ResponspilitySystemUnit
    {
        public int ID { get; set; }

        public int ResponspilityCenterID { get; set; }

        public int SystemUnitID { get; set; }
    }
}
