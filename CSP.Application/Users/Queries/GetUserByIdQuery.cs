using CSP.Application.Users.DTOs;
using MediatR;

namespace CSP.Application.Users.Queries
{
    public record GetUserByIdQuery(int Id) : IRequest<UserDto>;
}
