USE [Vaccinations]
GO

-- [spGetMedicalPersons]
-- This will get the list if medical persons that can login
-----------------------------------------------------------

CREATE   PROC [dbo].[spGetMedicalPersons]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MedicalPersonId, FirstName + ' ' + LastName + ' (' + Profession + ')' AS Username FROM MedicalPersons ORDER BY FirstName, LastName;
END;
GO


-- [spGetMedicalPerson]
-- This will get the selected medical persons after login
-- ------------------------------------------------------

CREATE   PROC [dbo].[spGetMedicalPerson] @p_MedicalPersonId INT
AS
BEGIN
    SET NOCOUNT ON;

	SELECT * FROM MedicalPersons mp WHERE mp.MedicalPersonId = @p_MedicalPersonId;
END;
GO


-- [spGetVaccinationCentres]
-- This will get a list of vaccination centres after login
-----------------------------------------------------------

CREATE   PROC [dbo].[spGetVaccinationCentres]
AS
BEGIN
    SET NOCOUNT ON;

	SELECT VaccinationCentreId, Name FROM VaccinationCentres ORDER BY Name;
END;
GO


-- [spGetVaccinationTypes]
-- This will get a list of vaccination types after login
-- -------------------------------------------------------

CREATE   PROC [dbo].[spGetVaccinationTypes]
AS
BEGIN
    SET NOCOUNT ON;

	SELECT VaccinationTypeId, Name FROM VaccinationTypes ORDER BY Name;
END;
GO


-- [spGetTotalMedicalPersonVaccinations]
-- This will get total number of vaccinations for each medical person
-- ------------------------------------------------------------------

CREATE   PROC [dbo].[spGetTotalMedicalPersonVaccinations] @p_MedicalPersonId INT
AS
BEGIN
    SET NOCOUNT ON;

	SELECT COUNT(*) AS TotalMedicalPersonVaccinations
	FROM medicalpersons mp 
		INNER JOIN patientvaccinations pv ON mp.MedicalPersonId = pv.MedicalPersonId		
	WHERE mp.MedicalPersonId = @p_MedicalPersonId;
END;
GO


-- [spGetVaccinationHistory]
-- This will get a list of vaccinators history
-- -------------------------------------------

CREATE   PROC [dbo].[spGetVaccinationHistory] @p_MedicalPersonId INT	
AS
BEGIN
    SET NOCOUNT ON;

	SELECT CONVERT(varchar, pv.DateTime, 106) AS DateTime, pv.PatientVaccinationId, vc.Name AS VaccinationCentre, CONCAT(p.FirstName , ' ' , p.LastName) AS PatientName, vt.Name AS VaccinationType
	INTO #Temp_VaxHistory 
	FROM medicalpersons mp 
		INNER JOIN patientvaccinations pv ON mp.MedicalPersonId = pv.MedicalPersonId
		INNER JOIN vaccinationcentres vc ON pv.VaccinationCentreId = vc.VaccinationCentreId
		INNER JOIN patients p ON pv.PatientId = p.PatientId
		INNER JOIN vaccinationtypes vt ON pv.VaccinationTypeId = vt.VaccinationTypeId
	WHERE mp.MedicalPersonId = @p_MedicalPersonId
	ORDER BY pv.DateTime DESC;

	SELECT VaccinationCentre, PatientName, VaccinationType, ROW_NUMBER() OVER (ORDER BY PatientVaccinationId) AS RowNum
	FROM #Temp_VaxHistory;


	--DROP TABLE #Temp_VaxHistory;
END;
GO


-- [spGetReportVaccinationsByCentre]
-- This will get a list of vaccinations carried out by each centre
-- ---------------------------------------------------------------

CREATE   PROC [dbo].[spGetReportVaccinationsByCentre]
AS
BEGIN
    SET NOCOUNT ON;

	SELECT vc.Name, vc.Address, vc.Postcode, vc.Telephone, COUNT(pv.VaccinationCentreId) AS NumberOfVaccinations
	FROM PatientVaccinations pv
		INNER JOIN VaccinationCentres vc ON pv.VaccinationCentreId = vc.VaccinationCentreId
	GROUP BY vc.VaccinationCentreId, vc.Name, vc.Address, vc.Postcode, vc.Telephone
	ORDER BY NumberOfVaccinations DESC;
END;
GO


-- [spGetTotalVaccinations]
-- This will get total number of vaccinations
-- ------------------------------------------

CREATE   PROC [dbo].[spGetTotalVaccinations]
AS
BEGIN
    SET NOCOUNT ON;

	SELECT COUNT(*) AS TotalVaccinations FROM PatientVaccinations;
END;
GO


-- [spGetReportPatientsByVaccinationType]
-- This will get a list of vaccinations by type
-- --------------------------------------------

CREATE   PROC [dbo].[spGetReportPatientsByVaccinationType]
AS
BEGIN
    SET NOCOUNT ON;

	declare @TotalPatients int = (SELECT COUNT(*)  FROM Patients);

	SELECT vt.Name, COUNT(pv.VaccinationTypeId) AS NumberOfPatients, COUNT(pv.VaccinationTypeId) * 100 / @TotalPatients AS PercentOfPatients
	FROM PatientVaccinations pv
		INNER JOIN VaccinationTypes vt ON pv.VaccinationTypeId = vt.VaccinationTypeId
	GROUP BY vt.VaccinationTypeId, vt.Name
	ORDER BY NumberOfPatients DESC;
END;
GO