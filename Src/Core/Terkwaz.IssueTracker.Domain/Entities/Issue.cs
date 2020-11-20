using Terkwaz.IssueTracker.Domain.Common;
using Terkwaz.IssueTracker.Domain.Enums;

namespace Terkwaz.IssueTracker.Domain.Entities
{
    public class Issue : Entity<string>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReporterId { get; set; }
        public User Reporter { get; set; }
        public int AssigneeId { get; set; }
        public User Assignee { get; set; }
        public Status Status { get; set; }
        public int IssueTypeId { get; set; }
        public IssueType IssueType { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}