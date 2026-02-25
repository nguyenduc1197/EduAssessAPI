using Application.DTOs;
using MediatR;

namespace Application.Accounts.Commands
{
    public record LoginCommand(string Username, string Password) : IRequest<LoginResponse?>;
}
