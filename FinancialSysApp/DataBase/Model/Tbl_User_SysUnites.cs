namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_User_SysUnites
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_User_SysUnites()
        {
            Tbl_UserAuthForms = new HashSet<Tbl_UserAuthForms>();
        }

        public int ID { get; set; }

        public int Emp_ID { get; set; }

        public int SysUnites_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? From_Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? To_Date { get; set; }

        public short? SysUnite_StatusID { get; set; }

        public int? User_ID { get; set; }

        public virtual Tbl_Employee Tbl_Employee { get; set; }

        public virtual Tbl_SystemUnites Tbl_SystemUnites { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_UserAuthForms> Tbl_UserAuthForms { get; set; }
    }
}
