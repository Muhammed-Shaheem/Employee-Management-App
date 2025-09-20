CREATE TABLE [dbo].[Employees]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [Name] NVARCHAR(50) NOT NULL, 
    [BasicSalary] MONEY NOT NULL, 
    [Allowances] MONEY NOT NULL, 
    [PFPercent] DECIMAL(5, 2) NOT NULL DEFAULT 12
)
