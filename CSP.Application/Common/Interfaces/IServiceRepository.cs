using CSP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Application.Common.Interfaces
{
    public interface IServiceRepository
    {
        Task<HLRList> PostHLRCheckAsync(Int64 number, string type, CancellationToken cancellationToken);
    }
}
