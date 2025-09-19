CREATE PROCEDURE [dbo].[spEmployees_Add]
	@Name nvarchar(50),
	@BasicSalary money,
	@Allowances money,
	@PFPercent decimal(5,2)
as
Begin
set nocount on
insert into Employees([Name],BasicSalary,Allowances,PFPercent)
values(@Name,@BasicSalary,@Allowances,@PFPercent)
end

