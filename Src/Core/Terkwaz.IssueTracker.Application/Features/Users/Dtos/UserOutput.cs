using System.Collections.Generic;
using Terkwaz.IssueTracker.Application.Common.Dtos;

namespace Terkwaz.IssueTracker.Application.Features.Users.Comands.Dtos
{
    public class UserOutput
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<ProjectDto> Projects { get; set; }
        public List<IssueDto> IssueAssignees { get; set; }
        public List<IssueDto> IssueReporters { get; set; }
        //public string Password { get; set; }
    }
}