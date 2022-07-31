using Microsoft.EntityFrameworkCore;
using VaccinationTrackerWebApp.Data.Models;
using VaccinationTrackerWebApp.Data.Models.AdminReports.ReportThree;
using VaccinationTrackerWebApp.Data.Models.AdminReports.ReportTwo;

namespace VaccinationTrackerWebApp.Data
{
    public class VaccinationTrackerContext : DbContext
    {
        public VaccinationTrackerContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TotalMedicalPersonVaxData>().HasNoKey();
            modelBuilder.Entity<VaccinationHistoryData>().HasNoKey();
            modelBuilder.Entity<TotalVaccinationData>().HasNoKey();
            modelBuilder.Entity<ReportThreeData>().HasNoKey();
            modelBuilder.Entity<TotalPatientData>().HasNoKey();
            modelBuilder.Entity<ReportTwoData>().HasNoKey();
        }
        public DbSet<LoginData> LoginData { get; set; }
        public DbSet<MedicalPersonData> MedicalPersonData { get; set; }
        public DbSet<VaccinationCentreData> VaccinationCentreData { get; set; }
        public DbSet<VaccinationTypeData> VaccinationTypeData { get; set; }
        public DbSet<TotalMedicalPersonVaxData> TotalMedicalPersonVaxData { get; set; }
        public DbSet<VaccinationHistoryData> VaccinationHistoryData { get; set; }
        public DbSet<TotalVaccinationData> TotalVaccinationData { get; set; }
        public DbSet<ReportThreeData> ReportThreeData { get; set; }
        public DbSet<TotalPatientData> TotalPatientData { get; set; }
        public DbSet<ReportTwoData> ReportTwoData { get; set; }
    }
}
