namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_RefundCheqReson
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_RefundCheqReson()
        {
            Tbl_RefundCheque = new HashSet<Tbl_RefundCheque>();
        }

        public int ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public int? ProcedureKindID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_RefundCheque> Tbl_RefundCheque { get; set; }
    }
}
