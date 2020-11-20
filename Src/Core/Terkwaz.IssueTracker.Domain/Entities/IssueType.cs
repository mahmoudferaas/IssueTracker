using System.Collections.Generic;
using Terkwaz.IssueTracker.Domain.Common;

namespace Terkwaz.IssueTracker.Domain.Entities
{
    public class IssueType : Entity
    {
        public string Name { get; set; }
        public ICollection<Issue> Issues { get; set; }

    }
}