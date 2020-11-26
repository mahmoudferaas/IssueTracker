using FluentValidation;
using System.Linq;
using Terkwaz.IssueTracker.Application.Common.Interfaces;

namespace Terkwaz.IssueTracker.Application.Features.Users.Comands.Create
{
    public class CreateUserCommandValidators : AbstractValidator<CreateUserCommand>
    {
        private readonly IIssueTrackerDbContext _context;

        public CreateUserCommandValidators(IIssueTrackerDbContext context)
        {
            _context = context;
            RuleFor(x => x.Email).Must(UniqueEmail).WithMessage("This Email already exists.");
        }

        public CreateUserCommandValidators()
        {
            RuleFor(x => x.FullName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(5);
        }

        private bool UniqueEmail(string email)
        {
            var user = _context.Users
                                .Where(x => x.Email == email)
                                .FirstOrDefault();

            return user == null;
        }
    }
}