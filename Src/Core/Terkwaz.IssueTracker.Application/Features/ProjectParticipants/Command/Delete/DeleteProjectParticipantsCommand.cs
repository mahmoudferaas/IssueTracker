using MediatR;
using Terkwaz.IssueTracker.Application.Common.Dtos;

namespace Terkwaz.IssueTracker.Application.Features.ProjectParticipants.Command.Delete
{
    public class DeleteProjectParticipantsCommand : IRequest<Output>
    {
        public int Id { get; set; }
    }
}