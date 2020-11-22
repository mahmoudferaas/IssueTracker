using MediatR;
using System.Collections.Generic;
using Terkwaz.IssueTracker.Application.Common.Dtos;

namespace Terkwaz.IssueTracker.Application.Features.ProjectParticipants.Command.Delete
{
    public class DeleteProjectParticipantsCommand : IRequest<Output>
    {
        public int ProjectId { get; set; }
        public int OwnerId { get; set; }
        public List<string> ParticipantEmails { get; set; }
    }
}