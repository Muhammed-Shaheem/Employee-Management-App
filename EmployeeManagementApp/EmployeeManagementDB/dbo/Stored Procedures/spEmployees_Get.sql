CREATE PROCEDURE [dbo].[spEmployees_Get]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, [Name], BasicSalary, Allowances, PFPercent
    FROM Employees;
END