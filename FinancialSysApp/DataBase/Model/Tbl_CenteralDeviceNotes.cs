namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_CenteralDeviceNotes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_CenteralDeviceNotes()
        {
            Tbl_CentralDeviceReplies = new HashSet<Tbl_CentralDeviceReplies>();
        }

        public int ID { get; set; }

        [Required]
        public string CentralDeviceNotes { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NoteDate { get; set; }

        public long AccountRestriction_ID { get; set; }

        public virtual Tbl_AccountingRestriction Tbl_AccountingRestriction { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_CentralDeviceReplies> Tbl_CentralDeviceReplies { get; set; }
    }
}
