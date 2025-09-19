using EmployeeManagementLibrary.Database;
using EmployeeManagementLibrary.Models;

namespace EmployeeManagementLibrary.Data;

public class SqlData : IDatabaeData
{
    private const string connectionStringName = "SqlDb";
    private readonly IDatabaseDb db;

    public SqlData(IDatabaseDb db)
    {
        this.db = db;
    }

    public void AddEmployee(EmployeeModel employee)
    {
        db.SaveData("spEmployees_Add",
            new { Name = employee.Name, BasicSalary = employee.BasicSalary, Allowances = employee.Allowances, PFPercent = employee.PFPercent },
            connectionStringName,
            true);
    }

    public List<EmployeeModel> GetAllEmployees()
    {
        return db.LoadData<EmployeeModel, dynamic>("spEmployees_Get", new { }, connectionStringName, true);
    }
}
