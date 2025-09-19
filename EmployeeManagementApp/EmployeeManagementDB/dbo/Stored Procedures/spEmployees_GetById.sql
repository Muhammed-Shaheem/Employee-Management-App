CREATE PROCEDURE [dbo].[spEmployees_GetById]
    @Id int
AS
BEGIN
    set nocount on;
    SELECT Id, [Name], BasicSalary, Allowances, PFPercent
    FROM Employees
    WHERE Id = @Id;
END