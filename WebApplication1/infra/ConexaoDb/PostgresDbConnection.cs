using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Infrastructure.ConexaoDB;

public class PostgresDbConnection
{
    private readonly string _connectionString;

    public PostgresDbConnection(IConfiguration connectionString)
    {
        _connectionString = connectionString.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(_connectionString))
        {
            throw new InvalidOperationException("Connection string 'DefaultConnection' is not defined.");
        }
    }

    public NpgsqlConnection CreateConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}
