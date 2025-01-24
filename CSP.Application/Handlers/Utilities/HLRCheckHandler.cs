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
    public class HLRCheckHandler :  IRequestHandler<HLRCheckRequest, HLRCheckResponse>
    {
        private readonly IUtilitiesRepository _utilitiesRepository;

        public HLRCheckHandler(IUtilitiesRepository utilitiesRepository)
        {
            _utilitiesRepository = utilitiesRepository;
        }

        public async Task<HLRCheckResponse> Handle(HLRCheckRequest request, CancellationToken cancellationToken)
        {
            // Call the third-party API through the repository
            var response = await _utilitiesRepository.HLRCheckAsync(request.Number, request.Type, cancellationToken);

            
            // Return the result as a DTO
            return new HLRCheckResponse
            {
                Status = response.Status,
                ResponseCode = response.ResponseCode,
                Info = new HLRInfo
                {
                    Operator = response.Info?.Operator,
                    Circle = response.Info?.Circle
                },
                Message = response.Message
            };
        }
    }
}

    
