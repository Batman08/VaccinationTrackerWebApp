using System.ComponentModel.DataAnnotations;

namespace VaccinationTrackerWebApp.Data.Models
{
    public class VaccinationTypeData
    {
        [Key]
        public int VaccinationTypeId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
