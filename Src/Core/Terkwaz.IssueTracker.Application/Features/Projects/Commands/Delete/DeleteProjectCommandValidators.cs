using FluentValidation;

namespace Terkwaz.IssueTracker.Application.Features.Projects.Commands.Delete
{
    public class DeleteProjectCommandValidators : AbstractValidator<DeleteProjectCommand>
    {
        public DeleteProjectCommandValidators()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}