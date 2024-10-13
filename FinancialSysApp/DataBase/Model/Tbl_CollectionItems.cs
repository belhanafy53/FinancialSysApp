namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_CollectionItems
    {
        public int ID { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        public int? Parent_ID { get; set; }
    }
}
