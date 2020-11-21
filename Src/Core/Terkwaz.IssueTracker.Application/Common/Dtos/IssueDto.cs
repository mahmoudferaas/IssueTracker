using Terkwaz.IssueTracker.Domain.Enums;

namespace Terkwaz.IssueTracker.Application.Common.Dtos
{
    public class IssueDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReporterId { get; set; }
        //public UserDto Reporter { get; set; }
        public int AssigneeId { get; set; }
        //public UserDto Assignee { get; set; }
        public Status Status { get; set; }
        public int IssueTypeId { get; set; }
        //public IssueTypeDto IssueType { get; set; }
        public int ProjectId { get; set; }
    }
}