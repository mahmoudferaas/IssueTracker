using MediatR;
using Terkwaz.IssueTracker.Application.Common.Dtos;

namespace Terkwaz.IssueTracker.Application.Features.Users.Comands.Create
{
    public class CreateUserCommand : IRequest<Output>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public ICollection<ProjectParticipants> ProjectParticipants { get; set; }
        //public ICollection<Issue> IssueReporters { get; set; }
        //public ICollection<Issue> IssueAssignees { get; set; }
    }
}