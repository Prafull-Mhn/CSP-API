using CSP.Application.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Infrastructure.Repositories
{
    public class ThirdPartyLogRepository : BaseRepository, IThirdPartyLogRepository
    {
        private readonly string _insertAPILogSP;

        public ThirdPartyLogRepository(IDatabaseConnection databaseConnection,
                                       IConfiguration configuration)
            : base(databaseConnection)
        {
            _insertAPILogSP = configuration["StoredProcedures:InsertAPILog"];
        }

        public async Task InsertLogAsync(
            int tenantId,
            string apiName,
            string requestPayload,
            string responsePayload,
            string endpoint,
            int responseCode,
            string status,
            string createdBy)
        {
            using var connection = CreateConnection();
            await connection.ExecuteAsync(_insertAPILogSP, new
            {
                TenantID = tenantId,
                APIName = apiName,
                Request = requestPayload,
                Response = responsePayload,
                Endpoint = endpoint,
                ResponseCode = responseCode,
                Status = status,
                CreatedBy = createdBy
            }, commandType: CommandType.StoredProcedure);
        }
    }
}
