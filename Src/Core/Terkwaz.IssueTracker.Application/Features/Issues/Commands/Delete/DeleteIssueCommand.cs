using MediatR;
using Terkwaz.IssueTracker.Application.Common.Dtos;

namespace Terkwaz.IssueTracker.Application.Features.Issues.Commands.Delete
{
    public class DeleteIssueCommand : IRequest<Output>
    {
        public string Id { get; set; }
    }
}