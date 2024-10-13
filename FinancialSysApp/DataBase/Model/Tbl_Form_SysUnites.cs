namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Form_SysUnites
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Form_SysUnites()
        {
            Tbl_Auth_Users_Forms = new HashSet<Tbl_Auth_Users_Forms>();
        }

        public int ID { get; set; }

        public int Form_ID { get; set; }

        public int SysUnites_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Auth_Users_Forms> Tbl_Auth_Users_Forms { get; set; }

        public virtual Tbl_Forms Tbl_Forms { get; set; }

        public virtual Tbl_SystemUnites Tbl_SystemUnites { get; set; }
    }
}
