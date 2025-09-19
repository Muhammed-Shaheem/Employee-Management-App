namespace EmployeeManagementLibrary.Models;

public class EmployeeModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal BasicSalary { get; set; }
    public decimal Allowances { get; set; }
    public decimal PFPercent { get; set; }
}
