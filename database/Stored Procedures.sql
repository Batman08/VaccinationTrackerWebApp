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
