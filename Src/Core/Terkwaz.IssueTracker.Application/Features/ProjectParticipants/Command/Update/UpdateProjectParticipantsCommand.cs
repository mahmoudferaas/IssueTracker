using MediatR;
using Terkwaz.IssueTracker.Application.Common.Dtos;

namespace Terkwaz.IssueTracker.Application.Features.ProjectParticipants.Command.Update
{
    public class UpdateProjectParticipantsCommand : IRequest<Output>
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int ParticipantId { get; set; }
    }
}