using CSP.Application.Common.Interfaces;
using CSP.Application.Users.DTOs;
using CSP.Application.Users.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Application.Users.Handlers
{
    public class GetUserStatusQueryHandler : IRequestHandler<GetUserStatusQuery, UserStatus>
    {
        private readonly IUserRepository _userRepository;

        public GetUserStatusQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserStatus> Handle(GetUserStatusQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserStatus(request.useremailId, request.password);
            return new UserStatus
            {
                Status = user
            };
        }
    }
}
