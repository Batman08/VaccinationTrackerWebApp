using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using VaccinationTrackerWebApp.Data.Models;

namespace VaccinationTrackerWebApp.Data
{
    public interface IVaccinationTrackerRepository
    {
        public List<LoginData> SpGetMedicalPersons();
        public MedicalPersonData SpGetMedicalPerson(int medicalPersonId);
        public List<VaccinationCentreData> SpGetVaccinationCentres();
        public List<VaccinationTypeData> SpGetVaccinationTypes();
        public List<CentreReportData> spGetReportVaccinationsByCentre();
        public int spGetTotalMedicalPersonVaccinations(int medicalPersonId);
        public List<VaccinationHistoryData> spGetVaccinationHistory(int medicalPersonId);
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

        public MedicalPersonData SpGetMedicalPerson(int medicalPersonId)
        {
            SqlParameter p_MedicalPersonId = new SqlParameter("@p_MedicalPersonId", medicalPersonId);
            return _vaccinationTrackerContext.MedicalPersonData.FromSqlRaw("spGetMedicalPerson @p_MedicalPersonId", p_MedicalPersonId).AsEnumerable().First();
        }

        public List<VaccinationCentreData> SpGetVaccinationCentres()
        {
            return _vaccinationTrackerContext.VaccinationCentreData.FromSqlRaw("spGetVaccinationCentres").ToList();
        }

        public List<VaccinationTypeData> SpGetVaccinationTypes()
        {
            return _vaccinationTrackerContext.VaccinationTypeData.FromSqlRaw("spGetVaccinationTypes").ToList();
        }

        public List<CentreReportData> spGetReportVaccinationsByCentre()
        {
            return _vaccinationTrackerContext.CentreReportData.FromSqlRaw("spGetReportVaccinationsByCentre").ToList();
        }

        public int spGetTotalMedicalPersonVaccinations(int medicalPersonId)
        {
            SqlParameter p_MedicalPersonId = new SqlParameter("@p_MedicalPersonId", medicalPersonId);
            return _vaccinationTrackerContext.TotalMedicalPersonVaxData.FromSqlRaw("spGetTotalMedicalPersonVaccinations @p_MedicalPersonId", p_MedicalPersonId).AsEnumerable().First().TotalMedicalPersonVaccinations;
        }

        public List<VaccinationHistoryData> spGetVaccinationHistory(int medicalPersonId)
        {
            SqlParameter p_MedicalPersonId = new SqlParameter("@p_MedicalPersonId", medicalPersonId);
            return _vaccinationTrackerContext.VaccinationHistoryData.FromSqlRaw("spGetVaccinationHistory @p_MedicalPersonId", p_MedicalPersonId).ToList();
        }
    }
}
