using System.ComponentModel.DataAnnotations;

namespace VaccinationTrackerWebApp.Data.Models.AdminReports.ReportTwo
{
    public class TotalPatientData
    {
        [Required]
        public int TotalPatients { get; set; }
    }
}
