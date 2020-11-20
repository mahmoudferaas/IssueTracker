using System.Collections.Generic;
using Terkwaz.IssueTracker.Domain.Common;

namespace Terkwaz.IssueTracker.Domain.Entities
{
    public class User : Entity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<ProjectParticipants> ProjectParticipants { get; set; }
        public ICollection<Issue> IssueReporters { get; set; }
        public ICollection<Issue> IssueAssignees { get; set; }

    }
}