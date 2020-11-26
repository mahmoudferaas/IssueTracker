using Microsoft.EntityFrameworkCore;
using System;
using Terkwaz.IssueTracker.Persistence;

namespace Terkwaz.IssueTracker.Application.UnitTest.Common
{
    public class ContextFactory
    {
        public static IssueTrackerDbContext Create()
        {
            var options = new DbContextOptionsBuilder<IssueTrackerDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var context = new IssueTrackerDbContext(options);

            context.Database.EnsureCreated();

            context.SaveChanges();

            return context;
        }

        public static void Destroy(IssueTrackerDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}