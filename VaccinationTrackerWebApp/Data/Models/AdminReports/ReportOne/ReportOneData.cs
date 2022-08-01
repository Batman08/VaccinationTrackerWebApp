using System.ComponentModel.DataAnnotations;

namespace VaccinationTrackerWebApp.Data.Models.AdminReports.ReportOne
{
    public class ReportOneData
    {
        [Required]
        public string Area { get; set; }

        [Required]
        public string Vaccine { get; set; }

        [Required]
        public int NumVaxByArea { get; set; }

        [Required]
        public int TotalVax { get; set; }
    }
}
