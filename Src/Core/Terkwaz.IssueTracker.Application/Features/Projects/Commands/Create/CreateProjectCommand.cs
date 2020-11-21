using MediatR;
using System.Collections.Generic;
using Terkwaz.IssueTracker.Application.Common.Dtos;
using Terkwaz.IssueTracker.Domain.Entities;

namespace Terkwaz.IssueTracker.Application.Features.Projects.Commands.Create
{
    public class CreateProjectCommand : IRequest<Output>
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public int OwnerId { get; set; }
        //public User Owner { get; set; }
        //public List<ProjectParticipants> ProjectParticipants { get; set; }
        //public List<Issue> Issues { get; set; }
    }
}