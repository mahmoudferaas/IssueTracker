using System;
using System.Collections.Generic;
using System.Text;

namespace Terkwaz.IssueTracker.Application.Common.Dtos
{
    public class ProjectParticipantsDto
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }
        public ProjectDto Project { get; set; }
        public int ParticipantId { get; set; }
        public UserDto Participant { get; set; }
    }
}
