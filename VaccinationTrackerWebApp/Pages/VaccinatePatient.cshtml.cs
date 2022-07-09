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
        
        [BindProperty]
        public List<VaccinationTypeData> VaccinationTypeData { get; set; }

        [BindProperty]
        public List<MedicalPersonData> MedicalPersonData { get; set; }

        private IVaccinationTrackerRepository _vaccinationTrackerRepo;

        public VaccinatePatientModel(IVaccinationTrackerRepository productRepository)
        {
            _vaccinationTrackerRepo = productRepository;
        }
        
        public void OnGet()
        {
            VaccinationCentreData = _vaccinationTrackerRepo.SpGetVaccinationCentres();
            VaccinationTypeData = _vaccinationTrackerRepo.SpGetVaccinationTypes();
        }

        public JsonResult OnPostMedicalPersonId(int MedicalPersonId) {
            MedicalPersonData = _vaccinationTrackerRepo.SpGetMedicalPerson(MedicalPersonId);
            return new JsonResult(new { MedicalPersonData });
        }
    }
}
