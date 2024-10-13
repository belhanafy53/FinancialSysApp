namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_AccountingRestrictionItems
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_AccountingRestrictionItems()
        {
            Tbl_Indebtedness = new HashSet<Tbl_Indebtedness>();
        }

        public long ID { get; set; }

        public short? Row_No { get; set; }

        public long AccountingRestriction_ID { get; set; }

        public int? Accounting_Guid_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Debit_Value { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Credit_Value { get; set; }

        public int? RestrictionItemsCategory_ID { get; set; }

        public int? Activities_ID { get; set; }

        public int? CostCenters_ID { get; set; }

        public int? AccountingRestrictionKind_ID { get; set; }

        public bool? OutCheque { get; set; }

        public virtual Tbl_Accounting_Guid Tbl_Accounting_Guid { get; set; }

        public virtual Tbl_AccountingRestriction Tbl_AccountingRestriction { get; set; }

        public virtual Tbl_AccountingRestrictions_Kind Tbl_AccountingRestrictions_Kind { get; set; }

        public virtual Tbl_Activities Tbl_Activities { get; set; }

        public virtual Tbl_CostCenters Tbl_CostCenters { get; set; }

        public virtual Tbl_RestrictionItemsCategory Tbl_RestrictionItemsCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Indebtedness> Tbl_Indebtedness { get; set; }
    }
}
