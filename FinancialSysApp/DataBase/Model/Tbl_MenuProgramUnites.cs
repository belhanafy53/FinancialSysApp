namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_MenuProgramUnites
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_MenuProgramUnites()
        {
            Tbl_MenuProgUnit_SysUnites = new HashSet<Tbl_MenuProgUnit_SysUnites>();
        }

        public int ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public int? Parent_ID { get; set; }

        public int? Forms_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_MenuProgUnit_SysUnites> Tbl_MenuProgUnit_SysUnites { get; set; }
    }
}
