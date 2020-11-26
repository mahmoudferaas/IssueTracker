using AutoMapper;
using Moq;
using System;
using Terkwaz.IssueTracker.Persistence;

namespace Terkwaz.IssueTracker.Application.UnitTest.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly IssueTrackerDbContext _context;
        protected readonly Mock<IMapper> _mapperMock;

        public CommandTestBase()
        {
            _context = ContextFactory.Create();
            _mapperMock = new Mock<IMapper>();
        }

        public void Dispose()
        {
            ContextFactory.Destroy(_context);
        }
    }
}