
namespace EmployeeManagementLibrary.Database
{
    public interface IDatabaseDb
    {
        List<T> LoadData<T, U>(string sql, U parameters, string connectionStringName, bool isStoreProcedure);
        void SaveData<T>(string sqlStatement, T parameters, string connectionStringName, bool isStoreProcedure);
    }
}