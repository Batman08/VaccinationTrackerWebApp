using System.ComponentModel.DataAnnotations;

namespace VaccinationTrackerWebApp.Data.Models.AdminReports.ReportThree
{
    public class ReportThreeData
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Postcode { get; set; }

        [Required]
        public string Telephone { get; set; }

        [Required]
        public int NumberOfVaccinations { get; set; }
    }
}
