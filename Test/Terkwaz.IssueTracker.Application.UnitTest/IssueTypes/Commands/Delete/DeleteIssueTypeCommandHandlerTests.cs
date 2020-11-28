using AutoFixture;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Common.Exceptions;
using Terkwaz.IssueTracker.Application.Features.IssueTypes.Commands.Delete;
using Terkwaz.IssueTracker.Application.UnitTest.Common;
using Terkwaz.IssueTracker.Domain.Entities;
using Xunit;

namespace Terkwaz.IssueTracker.Application.UnitTest.IssueTypes.Commands.Delete
{
    public class DeleteIssueTypeCommandHandlerTests : CommandTestBase
    {
        private readonly IFixture _fixture;

        public DeleteIssueTypeCommandHandlerTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async Task Handle_ValidId_EntityShouldNotDeletedBecauseRelatedEntities()
        {
            _fixture.RepeatCount = 1;

            //Create entity to inserted and delete it
            var temIssueType = _fixture.Create<IssueType>();

            // Arrange
            var issueType = await ContextOperation.CreateEntity(_context, temIssueType);

            var sut = new DeleteIssueTypeCommandHandler(_context);

            // Assert
            await Assert.ThrowsAsync<DeleteFailureException>(() => sut.Handle(new DeleteIssueTypeCommand { Id = issueType.Id }, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ValidId_EntityShoulDeletedSuccessfully()
        {
            _fixture.RepeatCount = 0;

            //Create entity to inserted and delete it
            var temIssueType = _fixture.Create<IssueType>();

            // Arrange
            var issueType = await ContextOperation.CreateEntity(_context, temIssueType);

            var sut = new DeleteIssueTypeCommandHandler(_context);

            // Act
            await sut.Handle(new DeleteIssueTypeCommand { Id = issueType.Id }, CancellationToken.None);

            // Assert
            _context.IssueTypes.Count().ShouldBe(0);
        }
    }
}