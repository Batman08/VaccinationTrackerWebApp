using System.ComponentModel.DataAnnotations;

namespace VaccinationTrackerWebApp.Data.Models
{
    public class TotalVaccinationData
    {
        [Required]
        public int TotalVaccinations { get; set; }
    }
}
