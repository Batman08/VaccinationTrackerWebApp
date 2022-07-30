using Microsoft.EntityFrameworkCore;
using VaccinationTrackerWebApp.Data.Models;

namespace VaccinationTrackerWebApp.Data
{
    public class VaccinationTrackerContext : DbContext
    {
        public VaccinationTrackerContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TotalMedicalPersonVaxData>().HasNoKey();
            modelBuilder.Entity<VaccinationHistoryData>().HasNoKey();
        }
        public DbSet<LoginData> LoginData { get; set; }
        public DbSet<MedicalPersonData> MedicalPersonData { get; set; }
        public DbSet<VaccinationCentreData> VaccinationCentreData { get; set; }
        public DbSet<VaccinationTypeData> VaccinationTypeData { get; set; }
        public DbSet<CentreReportData> CentreReportData { get; set; }
        public DbSet<TotalMedicalPersonVaxData> TotalMedicalPersonVaxData { get; set; }
        public DbSet<VaccinationHistoryData> VaccinationHistoryData { get; set; }
    }
}
