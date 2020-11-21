using FluentValidation;

namespace Terkwaz.IssueTracker.Application.Features.Projects.Commands.Create
{
    public class CreateProjectCommandValidators : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidators()
        {
            RuleFor(x => x.Key).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.OwnerId).NotEmpty();
        }
    }
}