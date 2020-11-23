using FluentValidation;

namespace Terkwaz.IssueTracker.Application.Features.Issues.Commands.Delete
{
    public class DeleteIssueCommandValidators : AbstractValidator<DeleteIssueCommand>
    {
        public DeleteIssueCommandValidators()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}