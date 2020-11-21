using System.Collections.Generic;

namespace Terkwaz.IssueTracker.Application.Common.Dtos
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public int OwnerId { get; set; }
        public UserDto Owner { get; set; }
        //public List<ProjectParticipantsDto> ProjectParticipants { get; set; }
        public List<IssueDto> Issues { get; set; }
    }
}