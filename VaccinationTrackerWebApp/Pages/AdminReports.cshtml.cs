using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VaccinationTrackerWebApp.Data;
using VaccinationTrackerWebApp.Data.Models;

namespace VaccinationTrackerWebApp.Pages
{
    public class AdminReportsModel : PageModel
    {
        [BindProperty]
        public List<CentreReportData> CentreReportData { get; set; }
        [BindProperty]
        public int TotalVaccinationData { get; set; }

        private IVaccinationTrackerRepository _vaccinationTrackerRepo;

        public AdminReportsModel(IVaccinationTrackerRepository productRepository)
        {
            _vaccinationTrackerRepo = productRepository;
        }

        public void OnGet()
        {
            TotalVaccinationData = _vaccinationTrackerRepo.spGetTotalVaccinations();
            CentreReportData = _vaccinationTrackerRepo.spGetReportVaccinationsByCentre();
        }

        public void OnPostReportThree()
        {
            if (!ModelState.IsValid)
            {
                //TotalVaccinationData = _vaccinationTrackerRepo.spGetTotalVaccinations();
                //CentreReportData = _vaccinationTrackerRepo.spGetReportVaccinationsByCentre();
            }
        }
    }
}
