namespace FinancialSysApp.DataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_HummanResource
    {
        public int ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Abgady { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? InsuranceNo { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NationalID { get; set; }

        [StringLength(20)]
        public string Gender { get; set; }

        [StringLength(30)]
        public string Degree { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DegreeDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DegreeDueDate { get; set; }

        [StringLength(150)]
        public string WorkerJob { get; set; }

        [StringLength(30)]
        public string JobName { get; set; }

        [StringLength(30)]
        public string Job { get; set; }

        [StringLength(10)]
        public string JobCategory { get; set; }

        [Column(TypeName = "date")]
        public DateTime? JobDate { get; set; }

        [StringLength(250)]
        public string ManagementName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ManagementDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? WorkrNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        [StringLength(30)]
        public string Gender2 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StatusDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(150)]
        public string StatusDetail { get; set; }

        [StringLength(150)]
        public string FieldJob { get; set; }

        public string WorkerAddress { get; set; }

        [StringLength(250)]
        public string CompanyName { get; set; }

        [StringLength(150)]
        public string Sectores { get; set; }

        [StringLength(150)]
        public string Sectore { get; set; }

        [StringLength(150)]
        public string FullTimeMember { get; set; }

        [StringLength(150)]
        public string GeneralManagement { get; set; }

        [StringLength(150)]
        public string Management { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TempDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? InstallDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TotalPeriod { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SupposedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ComprehensiveRewardDate { get; set; }

        [StringLength(30)]
        public string FileNo { get; set; }

        [StringLength(150)]
        public string ComplexBuilding { get; set; }

        [StringLength(50)]
        public string Building { get; set; }

        [StringLength(50)]
        public string RoleBuilding { get; set; }

        [StringLength(50)]
        public string Room { get; set; }

        [StringLength(50)]
        public string Neighborhood { get; set; }

        [StringLength(50)]
        public string GovernorateBuilding { get; set; }

        [StringLength(250)]
        public string BuildingAddress { get; set; }

        [StringLength(50)]
        public string MobileNo { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Qualification { get; set; }

        [StringLength(100)]
        public string Appreciation { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? GraduateYear { get; set; }

        [StringLength(30)]
        public string SicialStatus { get; set; }

        [StringLength(50)]
        public string GovernorateBirth { get; set; }

        [StringLength(50)]
        public string GovernorateLiving { get; set; }
    }
}
