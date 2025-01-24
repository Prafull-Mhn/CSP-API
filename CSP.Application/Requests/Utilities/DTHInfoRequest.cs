using CSP.Application.Responses.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Application.Requests.Utilities
{
    public class DTHInfoRequest : IRequest<DTHInfoResponse>
    {
        public long Canumber { get; set; }
        public string OP { get; set; }
    }
}
