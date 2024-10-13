namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vw_UsersEvents
    {
        [StringLength(512)]
        public string EmployeeName { get; set; }

        public int? User_ID { get; set; }

        [StringLength(50)]
        public string ActionName { get; set; }

        [StringLength(250)]
        public string TableName { get; set; }

        [StringLength(256)]
        public string TableRecordId { get; set; }

        public DateTime? ActionDate { get; set; }

        [StringLength(512)]
        public string FormName { get; set; }

        [Key]
        [StringLength(250)]
        public string Name { get; set; }
    }
}
