using System.ComponentModel.DataAnnotations;

namespace VaccinationTrackerWebApp.Data.Models
{
    public class LoginData
    {
        [Key]
        public int MedicalPersonId { get; set; }

        [Required]
        public string Username { get; set; }
    }
}
