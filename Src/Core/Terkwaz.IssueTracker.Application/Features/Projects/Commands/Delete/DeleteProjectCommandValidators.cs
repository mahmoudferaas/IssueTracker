using FluentValidation;
using Terkwaz.IssueTracker.Application.Common.Interfaces;

namespace Terkwaz.IssueTracker.Application.Features.Projects.Commands.Delete
{
    public class DeleteProjectCommandValidators : AbstractValidator<DeleteProjectCommand>
    {
        public DeleteProjectCommandValidators()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.OwnerId).NotEmpty().NotNull();
        }
    }
}