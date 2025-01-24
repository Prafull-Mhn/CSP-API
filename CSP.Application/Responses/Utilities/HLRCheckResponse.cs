using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CSP.Application.Responses.Utilities
{
    public class HLRCheckResponse
    {
        [JsonPropertyName("status")]
        public bool Status { get; set; }
        [JsonPropertyName("response_code")]
        public int ResponseCode { get; set; }
        [JsonPropertyName("info")]
        public HLRInfo Info { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }

        public class HLRInfo
        {
        [JsonPropertyName("operator")]
        public string Operator { get; set; }
        [JsonPropertyName("circle")]
        public string Circle { get; set; }
        }
    
}
