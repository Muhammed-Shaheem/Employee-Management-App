using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EmployeeManagementLibrary.Database;

public class SqlDb : IDatabaseDb
{
    private readonly IConfiguration config;

    public SqlDb(IConfiguration config)
    {
        this.config = config;
    }

    public List<T> LoadData<T, U>(string sql, U parameters, string connectionStringName, bool isStoreProcedure)
    {

        string? connectionString = config.GetConnectionString(connectionStringName);
        var cmdType = CommandType.Text;
        if (isStoreProcedure)
        {
            cmdType = CommandType.StoredProcedure;
        }

        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            var rows = connection.Query<T>(sql, parameters, commandType: cmdType).ToList();
            return rows;
        }
    }

    public void SaveData<T>(string sqlStatement, T parameters, string connectionStringName, bool isStoreProcedure)
    {
        var connectionString = config.GetConnectionString(connectionStringName);
        CommandType cmdType = CommandType.Text;

        if (isStoreProcedure == true)
        {
            cmdType = CommandType.StoredProcedure;
        }

        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(sqlStatement, parameters, commandType: cmdType);
        }
    }
}
