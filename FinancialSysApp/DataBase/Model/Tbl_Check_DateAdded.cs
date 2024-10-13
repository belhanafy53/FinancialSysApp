namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Check_DateAdded
    {
        public int ID { get; set; }

        public int? SameBank { get; set; }

        public int? DifferenceBank { get; set; }

        public int? DifferenceBankDue { get; set; }
    }
}
