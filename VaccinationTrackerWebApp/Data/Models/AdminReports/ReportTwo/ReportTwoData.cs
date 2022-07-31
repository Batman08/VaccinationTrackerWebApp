using System.ComponentModel.DataAnnotations;

namespace VaccinationTrackerWebApp.Data.Models.AdminReports.ReportTwo
{
    public class ReportTwoData
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int NumberOfPatients { get; set; }

        [Required]
        public int PercentOfPatients { get; set; }
    }
}
