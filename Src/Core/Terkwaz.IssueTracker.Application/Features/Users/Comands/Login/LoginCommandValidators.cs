using FluentValidation;

namespace Terkwaz.IssueTracker.Application.Features.Users.Comands.Login
{
    public class LoginCommandValidators : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidators()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(5);
        }
    }
}