using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using VaccinationTrackerWebApp.Data.Models;
using VaccinationTrackerWebApp.Data.Models.AdminReports.ReportOne;
using VaccinationTrackerWebApp.Data.Models.AdminReports.ReportThree;
using VaccinationTrackerWebApp.Data.Models.AdminReports.ReportTwo;

namespace VaccinationTrackerWebApp.Data
{
    public interface IVaccinationTrackerRepository
    {
        public List<LoginData> SpGetMedicalPersons();
        public MedicalPersonData SpGetMedicalPerson(int medicalPersonId);
        public List<VaccinationCentreData> SpGetVaccinationCentres();
        public List<VaccinationTypeData> SpGetVaccinationTypes();
        public int spGetTotalMedicalPersonVaccinations(int medicalPersonId);
        public List<VaccinationHistoryData> spGetVaccinationHistory(int medicalPersonId);
        public List<ReportOneData> spGetReportCovidVaccinationsByArea();
        public int spGetTotalCovidVaccinations();
        public List<ReportTwoData> spGetReportPatientsByVaccinationType();
        public int spGetTotalPatients();
        public List<ReportThreeData> spGetReportVaccinationsByCentre();
        public int spGetTotalVaccinations();
    }

    public class VaccinationTrackerRepository : IVaccinationTrackerRepository
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

        public List<ReportOneData> spGetReportCovidVaccinationsByArea()
        {
            return _vaccinationTrackerContext.ReportOneData.FromSqlRaw("spGetReportCovidVaccinationsByArea").AsEnumerable().ToList();
        }

        public int spGetTotalCovidVaccinations()
        {
            return _vaccinationTrackerContext.TotalCovidVaccinationData.FromSqlRaw("spGetTotalCovidVaccinations").AsEnumerable().First().TotalCovidVaccinations;
        }

        public List<ReportTwoData> spGetReportPatientsByVaccinationType()
        {
            return _vaccinationTrackerContext.ReportTwoData.FromSqlRaw("spGetReportPatientsByVaccinationType").AsEnumerable().ToList();
        }

        public int spGetTotalPatients()
        {
            return _vaccinationTrackerContext.TotalPatientData.FromSqlRaw("spGetTotalPatients").AsEnumerable().First().TotalPatients;
        }
        public List<ReportThreeData> spGetReportVaccinationsByCentre()
        {
            return _vaccinationTrackerContext.ReportThreeData.FromSqlRaw("spGetReportVaccinationsByCentre").ToList();
        }

        public int spGetTotalVaccinations()
        {
            return _vaccinationTrackerContext.TotalVaccinationData.FromSqlRaw("spGetTotalVaccinations").AsEnumerable().First().TotalVaccinations;
        }
    }
}
