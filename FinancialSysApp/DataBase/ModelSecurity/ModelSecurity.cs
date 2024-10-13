namespace FinancialSysApp.DataBase.ModelSecurity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelSecurity : DbContext
    {
        public ModelSecurity()
            : base("name=ModelSecurity")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tbl_Forms> Tbl_Forms { get; set; }
        public virtual DbSet<Tbl_FormsUserTypeUser> Tbl_FormsUserTypeUser { get; set; }
        public virtual DbSet<Tbl_MenuProgramUnites> Tbl_MenuProgramUnites { get; set; }
        public virtual DbSet<Tbl_MenuProgUnit_SysUnites> Tbl_MenuProgUnit_SysUnites { get; set; }
        public virtual DbSet<Tbl_ProceduresForms> Tbl_ProceduresForms { get; set; }
        public virtual DbSet<Tbl_SystemUnites> Tbl_SystemUnites { get; set; }
        public virtual DbSet<Tbl_User> Tbl_User { get; set; }
        public virtual DbSet<Tbl_UserAuthForms> Tbl_UserAuthForms { get; set; }
        public virtual DbSet<Tbl_UsersProcedureForm> Tbl_UsersProcedureForm { get; set; }
        public virtual DbSet<Tbl_UserType> Tbl_UserType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbl_Forms>()
                .Property(e => e.Name_English)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_Forms>()
                .HasMany(e => e.Tbl_ProceduresForms)
                .WithRequired(e => e.Tbl_Forms)
                .HasForeignKey(e => e.Form_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_MenuProgramUnites>()
                .HasMany(e => e.Tbl_UserAuthForms)
                .WithRequired(e => e.Tbl_MenuProgramUnites)
                .HasForeignKey(e => e.MenuProgUnit_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_ProceduresForms>()
                .HasMany(e => e.Tbl_UsersProcedureForm)
                .WithRequired(e => e.Tbl_ProceduresForms)
                .HasForeignKey(e => e.ProceduresForms_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_SystemUnites>()
                .HasMany(e => e.Tbl_MenuProgUnit_SysUnites)
                .WithRequired(e => e.Tbl_SystemUnites)
                .HasForeignKey(e => e.SysUnites_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_SystemUnites>()
                .HasMany(e => e.Tbl_MenuProgUnit_SysUnites1)
                .WithRequired(e => e.Tbl_SystemUnites1)
                .HasForeignKey(e => e.SysUnites_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_User>()
                .HasMany(e => e.Tbl_UserAuthForms)
                .WithRequired(e => e.Tbl_User)
                .HasForeignKey(e => e.User_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_User>()
                .HasMany(e => e.Tbl_UsersProcedureForm)
                .WithRequired(e => e.Tbl_User)
                .HasForeignKey(e => e.User_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_UserType>()
                .HasMany(e => e.Tbl_FormsUserTypeUser)
                .WithRequired(e => e.Tbl_UserType)
                .HasForeignKey(e => e.UserType_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_UserType>()
                .HasMany(e => e.Tbl_User)
                .WithOptional(e => e.Tbl_UserType)
                .HasForeignKey(e => e.UserType_ID);

            modelBuilder.Entity<Tbl_UserType>()
                .HasMany(e => e.Tbl_UserAuthForms)
                .WithRequired(e => e.Tbl_UserType)
                .HasForeignKey(e => e.UserType_ID)
                .WillCascadeOnDelete(false);
        }
    }
}
