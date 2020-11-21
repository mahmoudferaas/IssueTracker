using FluentValidation;

namespace Terkwaz.IssueTracker.Application.Features.Users.Comands.Create
{
    public class CreateUserCommandValidators : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidators()
        {
            RuleFor(x => x.FullName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}