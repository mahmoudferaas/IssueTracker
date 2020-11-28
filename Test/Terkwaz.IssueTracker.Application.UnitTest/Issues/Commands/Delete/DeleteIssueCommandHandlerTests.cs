using AutoFixture;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Common.Exceptions;
using Terkwaz.IssueTracker.Application.Features.Issues.Commands.Delete;
using Terkwaz.IssueTracker.Application.UnitTest.Common;
using Terkwaz.IssueTracker.Domain.Entities;
using Xunit;

namespace Terkwaz.IssueTracker.Application.UnitTest.Issues.Commands.Delete
{
    public class DeleteIssueCommandHandlerTests : CommandTestBase
    {
        private readonly IFixture _fixture;

        public DeleteIssueCommandHandlerTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async Task Handle_ValidId_EntityShoulDeletedSuccessfully()
        {
            _fixture.RepeatCount = 0;

            //Create entity to inserted and delete it
            var temIssue = _fixture.Create<Issue>();

            // Arrange
            var Issue = await ContextOperation.CreateEntity(_context, temIssue);

            var sut = new DeleteIssueCommandHandler(_context);

            // Act
            await sut.Handle(new DeleteIssueCommand { Id = Issue.Id }, CancellationToken.None);

            // Assert
            _context.Issues.Count().ShouldBe(0);
        }
    }
}