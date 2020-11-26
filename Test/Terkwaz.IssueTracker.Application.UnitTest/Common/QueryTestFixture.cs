using AutoMapper;
using System;
using Terkwaz.IssueTracker.Application.Common.Mappings;
using Terkwaz.IssueTracker.Persistence;
using Xunit;

namespace Terkwaz.IssueTracker.Application.UnitTest.Common
{
    public class QueryTestFixture : IDisposable
    {
        public IssueTrackerDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QueryTestFixture()
        {
            Context = ContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            ContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}