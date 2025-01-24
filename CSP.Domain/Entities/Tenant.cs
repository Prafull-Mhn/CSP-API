using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Domain.Entities
{
    public class Tenant
    {
        public int TenantId { get; set; }
        public string TenantName { get; set; }
        public string TenantType { get; set; }
    }
}
