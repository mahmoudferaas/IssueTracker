using MediatR;
using Terkwaz.IssueTracker.Application.Common.Dtos;

namespace Terkwaz.IssueTracker.Application.Features.Projects.Commands.Create
{
    public class CreateProjectCommand : IRequest<Output>
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public int OwnerId { get; set; }
        //public UserDto Owner { get; set; }
        //public List<ProjectParticipantsDto> ProjectParticipants { get; set; }
        //public List<IssueDto> Issues { get; set; }
    }
}