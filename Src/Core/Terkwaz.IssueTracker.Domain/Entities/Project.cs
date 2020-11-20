using System.Collections.Generic;
using Terkwaz.IssueTracker.Domain.Common;

namespace Terkwaz.IssueTracker.Domain.Entities
{
    public class Project : Entity
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public ICollection<ProjectParticipants> ProjectParticipants { get; set; }
        public ICollection<Issue> Issues { get; set; }
    }
}