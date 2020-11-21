using MediatR;
using System.Collections.Generic;
using Terkwaz.IssueTracker.Application.Common.Dtos;

namespace Terkwaz.IssueTracker.Application.Features.ProjectParticipants.Queries.GetAllProjectParticipants
{
    public class GetAllProjectParticipantsQuery : IRequest<List<UserDto>>
    {
        public int ProjectId { get; set; }
    }
}