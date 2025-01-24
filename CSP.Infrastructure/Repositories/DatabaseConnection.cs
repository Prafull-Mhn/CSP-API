using CSP.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CSP.Infrastructure.Repositories
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private readonly string _connectionString;

        public DatabaseConnection(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
