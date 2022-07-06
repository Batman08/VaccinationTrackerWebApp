using System.ComponentModel.DataAnnotations;

namespace VaccinationTrackerWebApp.Data.Models
{
    public class VaccinationCentreData
    {
        [Key]
        public int VaccinationCentreId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
