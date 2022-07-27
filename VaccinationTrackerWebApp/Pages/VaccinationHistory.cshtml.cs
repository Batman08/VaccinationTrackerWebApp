using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VaccinationTrackerWebApp.Data;
using VaccinationTrackerWebApp.Data.Models;

namespace VaccinationTrackerWebApp.Pages
{
    public class VaccinationHistoryModel : PageModel
    {
        [BindProperty] public MedicalPersonData MedicalPersonData { get; set; }
        [BindProperty] public int TotalMedicalPersonVaxData { get; set; }
        [BindProperty] public List<VaccinationHistoryData> VaccinationHistoryData { get; set; }

        private IVaccinationTrackerRepository _vaccinationTrackerRepo;

        public VaccinationHistoryModel(IVaccinationTrackerRepository productRepository)
        {
            _vaccinationTrackerRepo = productRepository;
        }

        public void OnGet()
        {
            int medicalPersonId = int.Parse(HttpContext.Session.GetString("Username"));
            MedicalPersonData = _vaccinationTrackerRepo.SpGetMedicalPerson(medicalPersonId);
            TotalMedicalPersonVaxData = _vaccinationTrackerRepo.spGetTotalMedicalPersonVaccinations(medicalPersonId);
            //VaccinationHistoryData = _vaccinationTrackerRepo.spGetVaccinationHistory(MedicalPersonId);
        }
    }
}
