using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VaccinationTrackerWebApp.Data;
using VaccinationTrackerWebApp.Data.Models;

namespace VaccinationTrackerWebApp.Pages
{
    public class VaccinatePatientModel : PageModel
    {
        [BindProperty]
        public List<VaccinationCentreData> VaccinationCentreData { get; set; }

        private IVaccinationTrackerRepository _vaccinationTrackerRepo;

        public VaccinatePatientModel(IVaccinationTrackerRepository productRepository)
        {
            _vaccinationTrackerRepo = productRepository;
        }
        
        public void OnGet()
        {
            VaccinationCentreData = _vaccinationTrackerRepo.SpGetVaccinationCentres();
        }
    }
}
