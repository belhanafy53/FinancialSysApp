namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Auth_Users_Forms
    {
        public int ID { get; set; }

        public int Form_SysUnites_ID { get; set; }

        public int Procedure_ID { get; set; }

        public int User_ID { get; set; }

        public virtual Tbl_Procedures Tbl_Procedures { get; set; }

        public virtual Tbl_User Tbl_User { get; set; }
    }
}
