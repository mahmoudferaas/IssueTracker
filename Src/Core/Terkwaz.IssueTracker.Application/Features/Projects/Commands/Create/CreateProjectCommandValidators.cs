using FluentValidation;
using System.Linq;
using Terkwaz.IssueTracker.Application.Common.Interfaces;

namespace Terkwaz.IssueTracker.Application.Features.Projects.Commands.Create
{
    public class CreateProjectCommandValidators : AbstractValidator<CreateProjectCommand>
    {
        private readonly IIssueTrackerDbContext _context;

        public CreateProjectCommandValidators()
        {
            RuleFor(x => x.Key).NotEmpty()
                .Length(3,4).WithMessage("Key must be within 3 , 4 characters.")
                .Matches("^[A-Z]*$").WithMessage("Key Must be Capital Letter.");
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.OwnerId).NotEmpty();
        }

        public CreateProjectCommandValidators(IIssueTrackerDbContext context)
        {
            _context = context;

            RuleFor(x => x.Key).Must(UniqueKey).WithMessage("This key already exists.");
        }

        private bool UniqueKey(string Key)
        {
            var project = _context.Projects
                                .Where(x => x.Key.ToLower() == Key.ToLower())
                                .SingleOrDefault();

            if (project == null)
                return true;

            return false;
        }
    }
}