using FluentValidation;
using Terkwaz.IssueTracker.Application.Features.Issues.Commands.Update;

namespace Terkwaz.IssueTracker.Application.Features.Issues.Commands.Create
{
    public class UpdateIssueCommandValidators : AbstractValidator<UpdateIssueCommand>
    {
        public UpdateIssueCommandValidators()
        {
            RuleFor(x => x.ProjectId).NotEmpty().NotNull();
            RuleFor(x => x.IssueTypeId).NotEmpty().NotNull();
            RuleFor(x => x.Status).NotEmpty().NotNull();
            RuleFor(x => x.Title).NotEmpty().NotNull().Length(1, 10);
            //RuleFor(x => x.Description).NotEmpty().NotNull();
        }
    }
}