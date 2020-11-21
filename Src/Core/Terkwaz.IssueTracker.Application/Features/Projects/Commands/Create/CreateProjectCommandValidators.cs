using FluentValidation;

namespace Terkwaz.IssueTracker.Application.Features.Projects.Commands.Create
{
    public class CreateProjectCommandValidators : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidators()
        {
            RuleFor(x => x.Key).NotEmpty()
                .MaximumLength(4)
                .MinimumLength(3)
                .Matches("^[A-Z]*$").WithMessage("Key Must be Capital Letter!");
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.OwnerId).NotEmpty();
        }
    }
}