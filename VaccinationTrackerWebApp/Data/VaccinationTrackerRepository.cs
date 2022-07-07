using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using VaccinationTrackerWebApp.Data.Models;

namespace VaccinationTrackerWebApp.Data
{
    public interface IVaccinationTrackerRepository
    {
        public List<LoginData> SpGetMedicalPersons();
        public List<MedicalPersonData >SpGetMedicalPerson(int Id);
        public List<VaccinationCentreData> SpGetVaccinationCentres();
        public List<VaccinationTypeData> SpGetVaccinationTypes();
    }

    public class VaccinationTrackerRepository: IVaccinationTrackerRepository
    {
        private VaccinationTrackerContext _vaccinationTrackerContext;
        
        public VaccinationTrackerRepository(VaccinationTrackerContext context)
        {
            _vaccinationTrackerContext = context;
        }

        public List<LoginData> SpGetMedicalPersons()
        {
            return _vaccinationTrackerContext.LoginData.FromSqlRaw("spGetMedicalPersons").ToList();
        }

        public List<MedicalPersonData> SpGetMedicalPerson(int Id)
        {
            SqlParameter p_MedicalPersonId = new SqlParameter("@p_MedicalPersonId", Id);
            return _vaccinationTrackerContext.MedicalPersonData.FromSqlRaw("spGetMedicalPerson @p_MedicalPersonId", p_MedicalPersonId).ToList();
        }

        public List<VaccinationCentreData> SpGetVaccinationCentres()
        {
            return _vaccinationTrackerContext.VaccinationCentreData.FromSqlRaw("spGetVaccinationCentres").ToList();
        }

        public List<VaccinationTypeData> SpGetVaccinationTypes()
        {
            return _vaccinationTrackerContext.VaccinationTypeData.FromSqlRaw("spGetVaccinationTypes").ToList();
        }
    }
}
