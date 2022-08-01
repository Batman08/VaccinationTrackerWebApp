using System.ComponentModel.DataAnnotations;

namespace VaccinationTrackerWebApp.Data.Models.AdminReports.ReportOne
{
    public class TotalCovidVaccinationData
    {
        [Required]
        public int TotalCovidVaccinations { get; set; }
    }
}
