using AutoFixture;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Common.Exceptions;
using Terkwaz.IssueTracker.Application.Features.Projects.Commands.Delete;
using Terkwaz.IssueTracker.Application.UnitTest.Common;
using Terkwaz.IssueTracker.Domain.Entities;
using Xunit;

namespace Terkwaz.IssueTracker.Application.UnitTest.Projects.Commands.Delete
{
    public class DeleteProjectCommandHandlerTests : CommandTestBase
    {
        private readonly IFixture _fixture;

        public DeleteProjectCommandHandlerTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async Task Handle_ValidId_EntityShouldNotDeletedBecauseRelatedEntities()
        {
            _fixture.RepeatCount = 1;

            //Create entity to inserted and delete it
            var temProject = _fixture.Create<Project>();

            // Arrange
            var project = await ContextOperation.CreateEntity(_context, temProject);

            var sut = new DeleteProjectCommandHandler(_context);

            // Assert
            await Assert.ThrowsAsync<DeleteFailureException>(() => sut.Handle(new DeleteProjectCommand { Id = project.Id, OwnerId = project.OwnerId }, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ValidId_EntityShoulDeletedSuccessfully()
        {
            _fixture.RepeatCount = 0;

            //Create entity to inserted and delete it
            var temproject = _fixture.Create<Project>();

            // Arrange
            var project = await ContextOperation.CreateEntity(_context, temproject);

            var sut = new DeleteProjectCommandHandler(_context);

            // Act
            await sut.Handle(new DeleteProjectCommand { Id = project.Id , OwnerId = project.OwnerId }, CancellationToken.None);

            // Assert
            _context.Projects.Count().ShouldBe(0);
        }
    }
}