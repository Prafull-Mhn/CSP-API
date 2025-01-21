using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Application.Tenant.DTOs
{
    public class TenantDTO
    {
        public int TenantId { get; set; }
        public string TenantName { get; set; }
        public string TenantType { get; set; }
    }
}
