using System.Collections.Generic;

namespace Terkwaz.IssueTracker.Application.Features.Users.Comands.Dtos
{
    public class GetAllUsersOutput
    {
        public List<BaseUserOutput> Users { get; set; }
    }
}