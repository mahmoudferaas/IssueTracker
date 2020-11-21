using System.Collections.Generic;

namespace Terkwaz.IssueTracker.Application.Common.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        //public List<ProjectParticipantsDto> ProjectParticipants { get; set; }
        //public List<IssueDto> IssueReporters { get; set; }
        //public List<IssueDto> IssueAssignees { get; set; }
    }
}