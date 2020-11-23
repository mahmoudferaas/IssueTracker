using MediatR;
using System.Collections.Generic;
using Terkwaz.IssueTracker.Application.Features.Issues.Dtos;

namespace Terkwaz.IssueTracker.Application.Features.Issues.Queries.GetIssuesByProject
{
    public class GetIssuesByProjectQuery : IRequest<List<IssueOutputDto>>
    {
        public int ProjectId { get; set; }
        public int? AssigneeId { get; set; }
    }
}