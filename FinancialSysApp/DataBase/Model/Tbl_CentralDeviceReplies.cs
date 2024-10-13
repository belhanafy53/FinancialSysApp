namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_CentralDeviceReplies
    {
        public int ID { get; set; }

        [Required]
        public string CentralDeviceReplies { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReplyDate { get; set; }

        public int? CentralDeviceNotes_ID { get; set; }

        public virtual Tbl_CenteralDeviceNotes Tbl_CenteralDeviceNotes { get; set; }
    }
}
