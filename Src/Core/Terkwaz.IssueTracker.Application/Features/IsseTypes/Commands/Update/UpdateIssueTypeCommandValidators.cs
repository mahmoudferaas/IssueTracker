using FluentValidation;

namespace Terkwaz.IssueTracker.Application.Features.IsseTypes.Commands.Update
{
    public class UpdateIssueTypeCommandValidators : AbstractValidator<UpdateIssueTypeCommand>
    {
        public UpdateIssueTypeCommandValidators()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}