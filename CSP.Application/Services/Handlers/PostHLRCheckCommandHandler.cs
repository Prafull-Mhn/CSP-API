using CSP.Application.Common.Interfaces;
using CSP.Application.Services.Command;
using CSP.Application.Services.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Application.Services.Handlers
{
    public class PostHLRCheckCommandHandler : IRequestHandler<HLRCheckCommand, GetHLRListDTO>
    {
        private readonly IServiceRepository _serviceRepository;

        public PostHLRCheckCommandHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<GetHLRListDTO> Handle(HLRCheckCommand request, CancellationToken cancellationToken)
        {
            var hlr = await _serviceRepository.PostHLRCheckAsync(request.Number,request.type,  cancellationToken);
            
            return new GetHLRListDTO
            {
                status = hlr.status,
                response_code = hlr.response_code,
                message = hlr.message,
                info = (IEnumerable<opertaorDetail>)hlr.info,
              
            };
        }
    }
}
