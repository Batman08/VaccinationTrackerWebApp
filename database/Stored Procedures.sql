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


-- [spGetTotalPatients]
-- This will get total number of patients
-- --------------------------------------

CREATE   PROC [dbo].[spGetTotalPatients]
AS
BEGIN
    SET NOCOUNT ON;

	SELECT COUNT(*) AS TotalPatients FROM Patients;
END;
GO


-- [spGetReportCovidVaccinationsByArea]
-- This will get the total number of covid vaccinations then will brake down the 4 different types of covid vaccines and number of those given
-- -------------------------------------------------------------------------------------------------------------------------------------------

CREATE   PROC [dbo].[spGetReportCovidVaccinationsByArea]
AS
BEGIN
    SET NOCOUNT ON;

	SELECT SUBSTRING(p.Address, LEN(p.Address) - CHARINDEX(' ,',REVERSE(p.Address))+1, LEN(p.Address)) AS Area,  vt.name AS Vaccine, COUNT(*) AS NumVaxByArea, 0 AS TotalVax
	INTO #Temp_AreaVaxDetails 
	FROM Patients p
		INNER JOIN PatientVaccinations pv ON p.PatientId = pv.PatientId
		INNER JOIN vaccinationtypes vt ON pv.VaccinationTypeId = vt.VaccinationTypeId
	WHERE vt.name LIKE 'COVID-19%'
	GROUP BY SUBSTRING(p.Address, LEN(p.Address) - CHARINDEX(' ,',REVERSE(p.Address))+1, LEN(p.Address)), vt.VaccinationTypeId, vt.Name;

	SELECT Area, SUM(NumVaxByArea) AS Qty 
	INTO #Temp_AreaVaxQty
	FROM #Temp_AreaVaxDetails 
	GROUP BY Area;

	CREATE NONCLUSTERED	INDEX area_index ON #Temp_AreaVaxQty (Area, Qty);

	UPDATE t1
	SET t1.TotalVax = t2.Qty
	FROM #Temp_AreaVaxDetails t1
		INNER JOIN #Temp_AreaVaxQty t2 ON t1.Area = t2.Area

	SELECT * FROM #Temp_AreaVaxDetails ORDER BY TotalVax DESC, Area, NumVaxByArea DESC, Vaccine;

	DROP TABLE #Temp_AreaVaxDetails;
	DROP TABLE #Temp_AreaVaxQty;
END;
GO


-- [spGetTotalCovidVaccinations]
-- This will get total number of covid vaccinations
-- ------------------------------------------------

CREATE   PROC [dbo].[spGetTotalCovidVaccinations]
AS
BEGIN
    SET NOCOUNT ON;

	SELECT COUNT(*) AS TotalCovidVaccinations
	FROM PatientVaccinations pv
		INNER JOIN VaccinationTypes vt on pv.VaccinationTypeId = vt.VaccinationTypeId
	WHERE vt.name LIKE 'COVID-19%';
END;
GO