using MediatR;
using Terkwaz.IssueTracker.Application.Common.Dtos;
using Terkwaz.IssueTracker.Domain.Enums;

namespace Terkwaz.IssueTracker.Application.Features.Issues.Commands.Update
{
    public class UpdateIssueCommand : IRequest<Output>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AssigneeId { get; set; }
        public Status Status { get; set; }
        public int IssueTypeId { get; set; }
        public int ProjectId { get; set; }
    }
}