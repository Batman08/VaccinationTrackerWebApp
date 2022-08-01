using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VaccinationTrackerWebApp.Data;

namespace VaccinationTrackerWebApp.Pages
{
    public class IndexModel : PageModel
    {
        //[BindProperty]
        //public LoginModel loginModel { get; set; }

        private readonly ILogger<IndexModel> _logger;

        //private IVaccinationTrackerRepository _vaccinationTrackerRepo;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            //, IVaccinationTrackerRepository productRepository
            //_vaccinationTrackerRepo = productRepository;
        }

        public void OnGet()
        {
            //loginModel = new LoginModel(_vaccinationTrackerRepo);
        }
    }
}