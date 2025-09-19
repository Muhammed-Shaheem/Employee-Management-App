using EmployeeManagementLibrary.Models;

namespace EmployeeManagementLibrary.Data
{
    public interface IDatabaseData
    {
        void AddEmployee(EmployeeModel employee);
        List<EmployeeModel> GetAllEmployees();
    }
}