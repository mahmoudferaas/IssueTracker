using FluentValidation;

namespace Terkwaz.IssueTracker.Application.Features.IsseTypes.Commands.Create
{
    public class CreateIssueTypeCommandValidators : AbstractValidator<CreateIssueTypeCommand>
    {
        public CreateIssueTypeCommandValidators()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}