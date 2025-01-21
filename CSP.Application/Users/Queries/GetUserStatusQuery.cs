using CSP.Application.Users.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Application.Users.Queries
{
  
        public record GetUserStatusQuery(string useremailId, string password) : IRequest<UserStatus>;
    
}
