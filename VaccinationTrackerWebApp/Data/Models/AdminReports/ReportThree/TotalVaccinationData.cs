using System.ComponentModel.DataAnnotations;

namespace VaccinationTrackerWebApp.Data.Models.AdminReports.ReportThree
{
    public class TotalVaccinationData
    {
        [Required]
        public int TotalVaccinations { get; set; }
    }
}
