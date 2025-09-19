using EmployeeManagementLibrary.Models;

namespace EmployeeManagementLibrary.Data
{
    public interface IDatabaeData
    {
        void AddEmployee(EmployeeModel employee);
        List<EmployeeModel> GetAllEmployees();
    }
}