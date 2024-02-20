

using System.Data;
using System.Data.SqlClient;

namespace Shop.Infrastructure.Persistent.Dapper;

    public class DapperContext
    {
    private readonly string _connectionString;
    public DapperContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    
        => new SqlConnection(_connectionString);
    public  string Inventories => "[seller].Inventories";
}

