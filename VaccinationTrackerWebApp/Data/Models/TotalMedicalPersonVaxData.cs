using System.ComponentModel.DataAnnotations;

namespace VaccinationTrackerWebApp.Data.Models
{
    public class TotalMedicalPersonVaxData
    {
        [Required]
        public int TotalMedicalPersonVaccinations { get; set; }
    }
}
