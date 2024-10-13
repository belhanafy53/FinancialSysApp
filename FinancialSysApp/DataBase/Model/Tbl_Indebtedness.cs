namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Indebtedness
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Indebtedness()
        {
            Tbl_IndebtednessBeneficiary = new HashSet<Tbl_IndebtednessBeneficiary>();
        }

        public int ID { get; set; }

        public int IndebtednessKind_ID { get; set; }

        public long AccountingRestrictionItems_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DebitIndebtedness { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CreditIndebtedness { get; set; }

        public virtual Tbl_AccountingRestrictionItems Tbl_AccountingRestrictionItems { get; set; }

        public virtual Tbl_IndebtednessKind Tbl_IndebtednessKind { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_IndebtednessBeneficiary> Tbl_IndebtednessBeneficiary { get; set; }
    }
}
