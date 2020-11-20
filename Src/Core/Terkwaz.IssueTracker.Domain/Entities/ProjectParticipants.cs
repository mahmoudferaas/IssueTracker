using Terkwaz.IssueTracker.Domain.Common;

namespace Terkwaz.IssueTracker.Domain.Entities
{
    public class ProjectParticipants : Entity
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int ParticipantId { get; set; }
        public User Participant { get; set; }
    }
}