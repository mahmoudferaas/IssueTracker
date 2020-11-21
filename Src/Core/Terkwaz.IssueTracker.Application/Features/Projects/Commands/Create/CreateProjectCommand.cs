using MediatR;
using Terkwaz.IssueTracker.Application.Common.Dtos;

namespace Terkwaz.IssueTracker.Application.Features.Projects.Commands.Create
{
    public class CreateProjectCommand : IRequest<Output>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public int OwnerId { get; set; }
        //public User Owner { get; set; }
        //public ICollection<ProjectParticipants> ProjectParticipants { get; set; }
        //public ICollection<Issue> Issues { get; set; }
    }
}