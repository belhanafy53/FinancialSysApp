namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_AccountingRestriction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_AccountingRestriction()
        {
            Tbl_AccountingRestriction_Audit = new HashSet<Tbl_AccountingRestriction_Audit>();
            Tbl_AccountingRestrictionItems = new HashSet<Tbl_AccountingRestrictionItems>();
            Tbl_CenteralDeviceNotes = new HashSet<Tbl_CenteralDeviceNotes>();
            Tbl_Cheques = new HashSet<Tbl_Cheques>();
            Tbl_UserNoteToSystemUnite = new HashSet<Tbl_UserNoteToSystemUnite>();
        }

        public long ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Restriction_NO { get; set; }

        [Column(TypeName = "date")]
        public DateTime Restriction_Date { get; set; }

        public int? Document_ID { get; set; }

        public int? AccountingRestrictionKind_ID { get; set; }

        public int? AcountingRestrictionCorrRelation_ID { get; set; }

        [StringLength(10)]
        public string FYear { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_AccountingRestriction_Audit> Tbl_AccountingRestriction_Audit { get; set; }

        public virtual Tbl_AccountingRestrictions_Kind Tbl_AccountingRestrictions_Kind { get; set; }

        public virtual TBL_Document TBL_Document { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_AccountingRestrictionItems> Tbl_AccountingRestrictionItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_CenteralDeviceNotes> Tbl_CenteralDeviceNotes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Cheques> Tbl_Cheques { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_UserNoteToSystemUnite> Tbl_UserNoteToSystemUnite { get; set; }
    }
}
