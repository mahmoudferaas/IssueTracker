using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Domain.Entities;

namespace Terkwaz.IssueTracker.Application.Common.Interfaces
{
    public interface IIssueTrackerDbContext
    {
        DbSet<Project> Projects { get; set; }
        DbSet<Issue> Issues { get; set; }
        DbSet<IssueType> IssueTypes { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<ProjectParticipants> ProjectParticipants { get; set; }
 
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        EntityEntry<T> Add<T>(T entity) where T : class;
    }
}