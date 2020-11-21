using FluentValidation;
using System.Linq;
using Terkwaz.IssueTracker.Application.Common.Interfaces;

namespace Terkwaz.IssueTracker.Application.Features.Projects.Commands.Create
{
    public class CreateProjectCommandValidators : AbstractValidator<CreateProjectCommand>
    {
        private readonly IIssueTrackerDbContext _context;

        public CreateProjectCommandValidators(IIssueTrackerDbContext context)
        {
            _context = context;

            RuleFor(x => x.Key).NotEmpty()
                .Length(3,4).WithMessage("Key must be within 3 , 4 characters.")
                .Matches("^[A-Z]*$").WithMessage("Key Must be Capital Letter.")
                .Must(UniqueKey).WithMessage("This key already exists.");
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.OwnerId).NotEmpty();
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