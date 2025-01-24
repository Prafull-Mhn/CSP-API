using CSP.Domain.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Infrastructure.Persistence
{
    public class TenantRepository
    {
        private readonly SqlConnection _connection;

        public TenantRepository(IConfiguration configuration)
        {
            _connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<Tenant> GetUserByIdAsync(int id)
        {
            var query = "SELECT * FROM TenantDetails WHERE TenantId = @Id";
            return await _connection.QueryFirstOrDefaultAsync<Tenant>(query, new { Id = id });
        }

    }
}
