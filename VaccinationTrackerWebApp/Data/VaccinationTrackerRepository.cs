using Microsoft.EntityFrameworkCore;
using VaccinationTrackerWebApp.Data.Models;

namespace VaccinationTrackerWebApp.Data
{
    public interface IVaccinationTrackerRepository
    {
        public List<LoginData> SpGetMedicalPersons();
    }

    public class VaccinationTrackerRepository: IVaccinationTrackerRepository
    {
        private VaccinationTrackerContext _VaccinationTrackerContext;
        
        public VaccinationTrackerRepository(VaccinationTrackerContext context)
        {
            _VaccinationTrackerContext = context;
        }

        public List<LoginData> SpGetMedicalPersons()
        {
            return _VaccinationTrackerContext.LoginData.FromSqlRaw("spGetMedicalPersons").ToList();
        }
    }
}
