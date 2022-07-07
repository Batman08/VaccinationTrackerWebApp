using System.ComponentModel.DataAnnotations;

namespace VaccinationTrackerWebApp.Data.Models
{
    public class MedicalPersonData
    {
        [Key]
        public int MedicalPersonId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Address { get; set; }

        [Required]
        public string Postcode { get; set; }
        
        [Required]
        public string Telephone { get; set; }
        
        [Required]
        public string Profession { get; set; }
    }
}
