using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CSP.Application.Responses.Utilities
{
    public class DTHInfoResponse
    {
        [JsonPropertyName("status")]
        public bool Status { get; set; }
        [JsonPropertyName("response_code")]
        public int ResponseCode { get; set; }
        [JsonPropertyName("info")]
        public List<DTHInfo> Info { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }

    public class DTHInfo
    {
        public double Balance { get; set; }
        [JsonPropertyName("customerName")]
        public string CustomerName { get; set; }
        public string NextRechargeDate { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("planname")]
        public string PlanName { get; set; }
        public double MonthlyRecharge { get; set; }
    }
}
