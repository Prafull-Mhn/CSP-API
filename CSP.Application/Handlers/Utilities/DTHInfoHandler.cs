using CSP.Application.Interfaces;
using CSP.Application.Requests.Utilities;
using CSP.Application.Responses.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Application.Handlers.Utilities
{
    public class DTHInfoHandler : IRequestHandler<DTHInfoRequest, DTHInfoResponse>
    {
        private readonly IUtilitiesRepository _utilitiesRepository;

        public DTHInfoHandler(IUtilitiesRepository utilitiesRepository)
        {
            _utilitiesRepository = utilitiesRepository;
        }

        public async Task<DTHInfoResponse> Handle(DTHInfoRequest request, CancellationToken cancellationToken)
        {
            // Call the third-party API through the repository
            var response = await _utilitiesRepository.DTHInfoAsync(request.Canumber, request.OP, cancellationToken);


            // Return the result as a DTO
            return new DTHInfoResponse
            {
                Status = response.Status,
                ResponseCode = response.ResponseCode,
                Info = response.Info?.Select(info => new DTHInfo
                {
                    Balance = info.Balance,
                    CustomerName = info.CustomerName,
                    NextRechargeDate = info.NextRechargeDate,
                    Status = info.Status,
                    PlanName = info.PlanName,
                    MonthlyRecharge = info.MonthlyRecharge
                }).ToList(),
                Message = response.Message
            };
        }
    }
}
