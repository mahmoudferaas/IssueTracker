namespace Terkwaz.IssueTracker.Application.Features.Issues.Dtos
{
    public class IssueOutputDto
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public int Assignee { get; set; }
        public string Parent { get; set; }

    }
}