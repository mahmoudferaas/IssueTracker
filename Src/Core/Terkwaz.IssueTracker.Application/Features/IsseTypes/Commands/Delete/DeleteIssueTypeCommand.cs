using MediatR;
using Terkwaz.IssueTracker.Application.Common.Dtos;

namespace Terkwaz.IssueTracker.Application.Features.IssueTypes.Commands.Delete
{
    public class DeleteIssueTypeCommand : IRequest<Output>
    {
        public string Id { get; set; }
    }
}