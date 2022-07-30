using System.ComponentModel.DataAnnotations;

namespace VaccinationTrackerWebApp.Data.Models
{
    public class VaccinationHistoryData
    {
        [Required]
        public string VaccinationCentre { get; set; }

        [Required]
        public string DateTime { get; set; }

        [Required]
        public string PatientName { get; set; }

        [Required]
        public string VaccinationType { get; set; }

        [Required]
        public long RowNum { get; set; }
    }
}
