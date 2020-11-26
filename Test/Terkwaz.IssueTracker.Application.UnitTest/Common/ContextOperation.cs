using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Common.Interfaces;

namespace Terkwaz.IssueTracker.Application.UnitTest.Common
{
    public class ContextOperation
    {
        public static async Task<T> CreateEntity<T>(IIssueTrackerDbContext context, T entity) where T : class
        {
            // insert initial entity
            entity = context.Add(entity).Entity;
            await context.SaveChangesAsync(CancellationToken.None);
            return entity;
        }
    }
}