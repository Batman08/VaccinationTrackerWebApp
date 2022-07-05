using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VaccinationTrackerWebApp.Data;
using VaccinationTrackerWebApp.Data.Models;

namespace VaccinationTrackerWebApp.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public List<LoginData> LoginData{ get; set; }

        private IVaccinationTrackerRepository _vaccinationTrackerRepo;

        public LoginModel(IVaccinationTrackerRepository productRepository)
        {
            _vaccinationTrackerRepo = productRepository;
        }
        
        public void OnGet()
        {
            LoginData = _vaccinationTrackerRepo.SpGetMedicalPersons();
        }
    }
}
