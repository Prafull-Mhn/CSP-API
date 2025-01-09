using CSP.Application.Common.Interfaces;
using CSP.Application.Users.Commands;
using CSP.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Application.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand,int >
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
               //UserId = Guid.NewGuid(),
                FirstName = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                CityId = request.CityId,
                TenantId = request.TenantId,
                IsActive = true,
                CreatedDate = DateTime.UtcNow,
                CreatedBy = 1 // Replace with current user context
            };

            return await _userRepository.CreateUserAsync(user);
        }
    }
}
