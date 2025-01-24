using CSP.Application.Responses.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Application.Requests.Utilities
{
   
        public class HLRCheckRequest : IRequest<HLRCheckResponse>
        {
            public long Number { get; set; }
            public string Type { get; set; }
        }
    
}
