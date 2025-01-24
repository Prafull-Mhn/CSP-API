using CSP.Application.Responses.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Application.Interfaces
{
    public interface IUtilitiesRepository
    {
        /// <summary>
        /// Calls the HLR Check API.
        /// </summary>
        /// <param name="number">Mobile number to check.</param>
        /// <param name="type">Type of the number (e.g., mobile).</param>
        /// <returns>Third-party API response.</returns>
        Task<HLRCheckResponse> HLRCheckAsync(long number, string type, CancellationToken cancellationToken);

        /// <summary>
        /// Calls the DTH Info API.
        /// </summary>
        /// <param name="number">Mobile number to check.</param>
        /// <param name="type">Type of the number (e.g., mobile).</param>
        /// <returns>Third-party API response.</returns>
        Task<DTHInfoResponse> DTHInfoAsync(long cin, string op, CancellationToken cancellationToken);
    }
}
