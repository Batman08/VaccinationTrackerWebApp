using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VaccinationTrackerWebApp.Data;
using VaccinationTrackerWebApp.Data.Models.AdminReports.ReportOne;
using VaccinationTrackerWebApp.Data.Models.AdminReports.ReportThree;
using VaccinationTrackerWebApp.Data.Models.AdminReports.ReportTwo;

namespace VaccinationTrackerWebApp.Pages
{
    public class AdminReportsModel : PageModel
    {
        [BindProperty]
        public List<ReportOneData> ReportOneData { get; set; }
        [BindProperty]
        public int TotalCovidVaccinations { get; set; }

        [BindProperty]
        public List<ReportTwoData> ReportTwoData { get; set; }
        [BindProperty]
        public int TotalPatients { get; set; }

        [BindProperty]
        public List<ReportThreeData> ReportThreeData { get; set; }
        [BindProperty]
        public int TotalVaccinationData { get; set; }

        private IVaccinationTrackerRepository _vaccinationTrackerRepo;

        public AdminReportsModel(IVaccinationTrackerRepository productRepository)
        {
            _vaccinationTrackerRepo = productRepository;
        }

        public void OnGet()
        {
            //Report 1
            ReportOneData = _vaccinationTrackerRepo.spGetReportCovidVaccinationsByArea();
            TotalCovidVaccinations = _vaccinationTrackerRepo.spGetTotalCovidVaccinations();

            //Report 2
            ReportTwoData = _vaccinationTrackerRepo.spGetReportPatientsByVaccinationType();
            TotalPatients = _vaccinationTrackerRepo.spGetTotalPatients();

            //Report 3
            ReportThreeData = _vaccinationTrackerRepo.spGetReportVaccinationsByCentre();
            TotalVaccinationData = _vaccinationTrackerRepo.spGetTotalVaccinations();
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
