using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Domain.Entities
{
    public class HLRCheckResponseDto
    {
        public bool Status { get; set; }
        public int ResponseCode { get; set; }
        public HLRInfo Info { get; set; }
        public string Message { get; set; }
    }

    public class HLRInfo
    {
        public string Operator { get; set; }
        public string Circle { get; set; }
    }
}
