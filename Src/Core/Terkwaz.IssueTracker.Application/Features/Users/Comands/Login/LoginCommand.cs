using MediatR;
using Terkwaz.IssueTracker.Application.Features.Users.Comands.Dtos;

namespace Terkwaz.IssueTracker.Application.Features.Users.Comands.Login
{
    public class LoginCommand : IRequest<LoginOutput>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}