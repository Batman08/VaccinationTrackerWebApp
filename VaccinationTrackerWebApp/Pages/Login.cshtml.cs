using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VaccinationTrackerWebApp.Data;
using VaccinationTrackerWebApp.Data.Models;

namespace VaccinationTrackerWebApp.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public List<LoginData> LoginData { get; set; }

        private IVaccinationTrackerRepository _vaccinationTrackerRepo;

        public LoginModel(IVaccinationTrackerRepository productRepository)
        {
            _vaccinationTrackerRepo = productRepository;
        }

        public void OnGet()
        {
            LoginData = _vaccinationTrackerRepo.SpGetMedicalPersons();
        }

        public IActionResult OnPostProcessLogin(LoginFormModel loginFormModel)
        {
            string value = "";
            if (loginFormModel.Username == "DemoAdministrator")
            {
                //return RedirectToPage("Privacy");
                value = "DemoAdministrator";
            }
            else if (loginFormModel.Username != null)
            {
                //return RedirectToPage("Index");
                value = loginFormModel.Username;
            }

            return new JsonResult(new { value });
        }
    }

    public class LoginFormModel
    {
        public string Username { get; set; }
    }
}
