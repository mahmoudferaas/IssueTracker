using FluentValidation;

namespace Terkwaz.IssueTracker.Application.Features.IssueTypes.Commands.Delete
{
    public class DeleteIssueTypesCommandValidators : AbstractValidator<DeleteIssueTypeCommand>
    {
        public DeleteIssueTypesCommandValidators()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}