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