using CSP.Application.Services.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Application.Services.Command
{
   
    public record HLRCheckCommand(Int64 Number, string type) : IRequest<GetHLRListDTO>;

}
