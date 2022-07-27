using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using VaccinationTrackerWebApp.Data;
using VaccinationTrackerWebApp.Data.Models;

namespace VaccinationTrackerWebApp.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty] public List<LoginData> LoginData { get; set; }
        [BindProperty] public string Username { get; set; }

        private IVaccinationTrackerRepository _vaccinationTrackerRepo;

        public LoginModel(IVaccinationTrackerRepository productRepository)
        {
            _vaccinationTrackerRepo = productRepository;
        }

        public void OnGet()
        {
            LoginData = _vaccinationTrackerRepo.SpGetMedicalPersons();
        }

        public IActionResult OnPostProcessLogin()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            HttpContext.Session.SetString("Username", Username);
            
            if (Username == "DemoAdministrator")
            {
                return RedirectToPage("AdminReports");
            }
            else if (Username == "")
            {
                return Page();
            }
            else if (Username != null)
            {
                return RedirectToPage("VaccinatePatient");
            }

            LoginData = _vaccinationTrackerRepo.SpGetMedicalPersons();
            return Page();
        }
    }
}
