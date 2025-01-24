using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Application.Interfaces
{
    public interface IThirdPartyLogRepository
    {
        Task InsertLogAsync(
           int tenantId,
           string apiName,
           string requestPayload,
           string responsePayload,
           string endpoint,
           int responseCode,
           string status,
           string createdBy);
    }
}
