using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Application.Users.Commands
{
    
        public record CreateUserCommand(string Name, string Email, string PhoneNumber, string Address, int CityId, int TenantId) : IRequest<int>;
    
}
