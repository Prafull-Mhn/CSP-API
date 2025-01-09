using CSP.Application.Common.Interfaces;
using CSP.Application.Users.DTOs;
using CSP.Application.Users.Queries;
using MediatR;

namespace CSP.Application.Users.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.Id);
            return new UserDto
            {
                Id = user.UserId,
                Name = user.FirstName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                CityId = user.CityId
            };
        }
    }
}
