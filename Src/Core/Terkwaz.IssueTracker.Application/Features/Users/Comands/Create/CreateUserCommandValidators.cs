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

            RuleFor(x => x.FullName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress().Must(UniqueEmail).WithMessage("This Email already exists."); 
            RuleFor(x => x.Password).NotEmpty();
        }

        private bool UniqueEmail(string email)
        {
            var user = _context.Users
                                .Where(x => x.Email == email)
                                .FirstOrDefault();

            if (user == null)
                return true;

            return false;
        }
    }
}