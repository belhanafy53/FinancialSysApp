using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FinancialSysApp.DataBase.ModelEvents
{
    public partial class ModelEvent : DbContext
    {
        public ModelEvent()
            : base("name=ModelEvent")
        {
        }

        public virtual DbSet<SecurityEvent> SecurityEvents { get; set; }
        public virtual DbSet<SecurityUserActivity> SecurityUserActivities { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tbl_AccountingRestriction_audit> Tbl_AccountingRestriction_audit { get; set; }
        public virtual DbSet<Tbl_AccountingRestrictionItems_audits> Tbl_AccountingRestrictionItems_audits { get; set; }
        public virtual DbSet<Tbl_ArchBankTransfer> Tbl_ArchBankTransfer { get; set; }
        public virtual DbSet<Tbl_ArchOrderAndLetterW> Tbl_ArchOrderAndLetterW { get; set; }
        public virtual DbSet<Tbl_ArchTrCollectioCheque> Tbl_ArchTrCollectioCheque { get; set; }
        public virtual DbSet<TBL_Document_Audit> TBL_Document_Audit { get; set; }
        public virtual DbSet<Tbl_DocumentBenefcairy_audit> Tbl_DocumentBenefcairy_audit { get; set; }
        public virtual DbSet<Tbl_DocumentHirarchy> Tbl_DocumentHirarchy { get; set; }
        public virtual DbSet<Tbl_DocumentProcess> Tbl_DocumentProcess { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbl_AccountingRestriction_audit>()
                .Property(e => e.RestrictionID)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_AccountingRestriction_audit>()
                .Property(e => e.Restriction_NO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Tbl_AccountingRestriction_audit>()
                .Property(e => e.Oberation)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_AccountingRestrictionItems_audits>()
                .Property(e => e.Debit_Value)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_AccountingRestrictionItems_audits>()
                .Property(e => e.Credit_Value)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Tbl_AccountingRestrictionItems_audits>()
                .Property(e => e.Oberation)
                .IsFixedLength();

            modelBuilder.Entity<TBL_Document_Audit>()
                .Property(e => e.Oberation)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_DocumentBenefcairy_audit>()
                .Property(e => e.Oberation)
                .IsFixedLength();
        }
    }
}
