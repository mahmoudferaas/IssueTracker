using FluentValidation;

namespace Terkwaz.IssueTracker.Application.Features.Issues.Commands.Create
{
    public class CreateIssueCommandValidators : AbstractValidator<CreateIssueCommand>
    {
        public CreateIssueCommandValidators()
        {
            RuleFor(x => x.ProjectId).NotEmpty().NotNull();
            RuleFor(x => x.ReporterId).NotEmpty().NotNull();
            //RuleFor(x => x.AssigneeId).NotEmpty().NotNull();
            RuleFor(x => x.IssueTypeId).NotEmpty().NotNull();
            RuleFor(x => x.Status).NotEmpty().NotNull();
            RuleFor(x => x.Title).NotEmpty().NotNull().Length(1, 10);
            RuleFor(x => x.Description).NotEmpty().NotNull();
        }
    }
}