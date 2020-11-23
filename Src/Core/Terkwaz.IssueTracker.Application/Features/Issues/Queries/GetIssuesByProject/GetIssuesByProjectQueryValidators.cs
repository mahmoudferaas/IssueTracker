using FluentValidation;

namespace Terkwaz.IssueTracker.Application.Features.Issues.Queries.GetIssuesByProject
{
    public class GetIssuesByProjectQueryValidators : AbstractValidator<GetIssuesByProjectQuery>
    {
        public GetIssuesByProjectQueryValidators()
        {
            RuleFor(x => x.ProjectId).NotEmpty().NotNull();
        }
    }
}